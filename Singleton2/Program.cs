using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton2
{
    class Program
    {

        public class ThreadSafeSingleton
        {
            private ThreadSafeSingleton()
            {
                // Читаємо дані з деякого файлу і дістаємо номер останнього запису
                // _logCount = вичитане значення
            }
            private int _logCount = 0;
            private static ThreadSafeSingleton _loggerInstance;
            private static readonly object locker = new object();
            public static ThreadSafeSingleton GetInstance()
            {
                lock (locker)
                {
                    if (_loggerInstance == null)
                    {
                        _loggerInstance = new ThreadSafeSingleton();
                    }
                }
                return _loggerInstance;
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
                ThreadSafeSingleton.GetInstance().Log("Processor створено.");
            }
            public int ProcessTo(int end)
            {
                int sum = 0;
                for (int i = _start; i <= end; ++i)
                {
                    sum += i;
                }
                ThreadSafeSingleton.GetInstance().Log(
                "Processor обчислив деяке значення: " + sum);
                return sum;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ThreadSafeSingleton logger = ThreadSafeSingleton.GetInstance();
            Processor processor = new Processor(1);
            logger.Log("Почалася робота...");
            processor.ProcessTo(5);
            logger.Log("Робота завершилася...");

            Console.ReadKey();
        }
    }
}
