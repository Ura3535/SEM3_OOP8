using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.Examples
{
    class Singleton
    {
        private Singleton() { }
        private int _logCount = 0;
        private static Singleton _singletonInstance = null;
        public static Singleton GetInstance()
        {
            if (_singletonInstance == null)
            {
                _singletonInstance = new Singleton();

            }
            return _singletonInstance;
        }
        public void Log(String message)
        {
            Console.WriteLine(_logCount + ": " + message);
            _logCount++;
        }
    }
    class Processor
    {
        private int _start;
        public Processor(int start)
        {
            _start = start;
            Singleton.GetInstance().Log("Processor створено.");
        }
        public int ProcessTo(int end)
        {
            int sum = 0;
            for (int i = _start; i <= end; ++i)
            {
                sum += i;
            }
            Singleton.GetInstance().Log(
            "Processor обчислив деяке значення: " + sum);
            return sum;
        }
    }
    class SingletomExample
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Singleton logger = Singleton.GetInstance();
            Singleton l1 = Singleton.GetInstance();

            Processor processor = new Processor(1);
            Processor processor1 = new Processor(10);

            logger.Log("Почалася робота...");
            processor.ProcessTo(5);
            logger.Log("Робота завершилася...");

            Console.ReadKey();
        }
    }
}

