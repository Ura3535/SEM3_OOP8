using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Examples
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            Facade facade = new Facade();
            facade.PrintData();
            int data = facade.GetData();
            int newData = facade.ProcessData(data);
            facade.SetData(newData);
            facade.PrintData();

            Console.Read();
        }
    }


    // "Subsystem ClassA" 
    class DataBase
    {
        int data;

        public DataBase()
        {
            data = 1;
        }

        public int Load()
        {
            return data;
        }

        public void Save(int data)
        {
            this.data = data;
        }
    }

    class Processor
    {
        public Processor() { }

        public int Process(int data)
        {
            int tmp = data + 1;
            return tmp;
        }
    }

    class Printer
    {
        public Printer() { }

        public void Print(int data)
        {
            Console.WriteLine("data = {0}", data);
        }
    }

    // "Facade" 
    class Facade
    {
        DataBase dataBase;
        Processor processor;
        Printer printer;

        public Facade()
        {
            dataBase = new DataBase();
            processor = new Processor();
            printer = new Printer();
        }

        public int GetData()
        {
            return dataBase.Load();
        }

        public void SetData(int data)
        {
            dataBase.Save(data);
        }

        public int ProcessData(int data)
        {
            return processor.Process(data);
        }

        public void PrintData()
        {
            printer.Print(dataBase.Load());
        }
    }
}
