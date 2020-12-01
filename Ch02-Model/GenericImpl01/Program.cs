using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericImpl01
{
    class Program
    {
        static void Main(string[] args)
        {
            SortUtil<SortClass> util = new SortUtil<SortClass>();
            SortClass s1 = new SortClass();

            util.Sort(s1);
            util.SortDesc(s1);


            //2-14
            DataQuery<DataItem> dataQuery = new DataQuery<DataItem>();
            var a = dataQuery.Query().ToList();

            Console.ReadLine();

        }
    }

    public class SortClass : ISortable
    {
        public void Sort()
        {
            Console.WriteLine("Sort() called.");
        }

        public void SortDesc()
        {
            Console.WriteLine("SortDesc() called.");
        }
    }

    public interface ISortable
    {
        void Sort();
        void SortDesc();
    }

    /// <summary>
    /// 用來排序
    /// </summary>
    public class SortUtil
    {
        public void Sort(object target)
        {
            if (target is ISortable)
                ((ISortable)target).Sort();
        }

        public void SortDesc(object target)
        {
            if (target is ISortable)
                ((ISortable)target).SortDesc();
        }
    }

    /// <summary>
    /// 進行優化：可以在編譯的時候就進行檢查 
    /// 而只有 SortUtil<T> 還不夠 
    /// 可以用 where T : ISortable 方式限制這個物件只能用 有繼承 ISortable 的類別
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SortUtil<T> where T : ISortable
    {
        public void Sort(T target)
        {
            target.Sort();
        }

        public void SortDesc(T target)
        {
            target.SortDesc();
        }
    }


    #region page:2-14


    public class DataItem
    {
        public DataItem()
        {
            Console.WriteLine("DataItem Created.");
        }
    }


    /// <summary>
    /// 建立一個產生亂數迴圈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataQuery<T> where T : class, new()
    {
        private Random rnd = new Random();
        private int rows = 0;

        public DataQuery()
        {
            this.rows = rnd.Next(1, 10);
        }

        public IEnumerable<T> Query()
        {
            for (int i = 0; i < this.rows; i++)
            {
                T item = new T();
                yield return item;
            }
        }
    }
    #endregion


}
