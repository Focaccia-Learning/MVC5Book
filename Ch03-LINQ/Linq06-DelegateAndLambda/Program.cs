using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq06_DelegateAndLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleObject.MyCallbackHandler cb;

            // 匿名委派 anonymous delegate
            cb = delegate (object callbackData)
            {
                Console.WriteLine(callbackData);
            };

            var o = new ExampleObject();
            o.Invoke(delegate (object callbackData)
            {
                Console.WriteLine(callbackData);
            });

            // .net FrameWork 3.5　後可以這樣寫更精簡
            // Lambda expression implementation.
            o.Invoke(d => Console.WriteLine(d));

            Console.ReadLine();
        }
    }

    public class ExampleObject
    {
        public delegate void MyEventHandler(object sender, EventArgs e);
        public event MyEventHandler MyEvent;

        public ExampleObject()
        {
        }

        public void Invoke()
        {
            if (this.MyEvent != null)
                this.MyEvent(this, new EventArgs());
        }

        public delegate void MyCallbackHandler(object callbackData);

        public void Invoke(MyCallbackHandler handler)
        {
            if (handler != null)
                handler("CALLBACK"); // CALLBACK
        }
    }
}
