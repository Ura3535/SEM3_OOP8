using System;
namespace FactoryMethodExample
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class VectorCreator
    {
        public abstract Vector CreateVector(int D);
    }

    public class ZeroVectorCreator : VectorCreator
    {
        public override Vector CreateVector(int type)
        {
            switch (type)
            {
                case 1: return new Vector1D();
                case 2: return new Vector2D();
                default: throw new ArgumentException("Invalid type.");
            }
        }
    }

    public class RandomVectorCreator : VectorCreator
    {
        readonly Random random = new Random();
        public override Vector CreateVector(int type)
        {
            switch (type)
            {
                case 1: return new Vector1D(random.NextDouble() * byte.MaxValue);
                case 2: return new Vector2D(random.NextDouble() * byte.MaxValue, random.NextDouble() * byte.MaxValue);
                default: throw new ArgumentException("Invalid type.");
            }
        }
    }

    public abstract class Vector
    {
        public int D { get; protected set; }

        public abstract double GetNorm();
        public abstract void Normalize();
        public abstract void Print();
    }

    public class Vector1D : Vector
    {
        public double X1;

        public Vector1D()
        {
            D = 1;
            X1 = 0;
        }

        public Vector1D(double X1)
        {
            D = 1;
            this.X1 = X1;
        }

        public override double GetNorm()
        {
            return Math.Abs(X1);
        }

        public override void Normalize()
        {
            double norm = GetNorm();
            if(norm != 0)
            {
                X1 /= norm;
            }
        }

        public override void Print()
        {
            Console.WriteLine(X1);
        }
    }

    public class Vector2D : Vector
    {
        public double X1;
        public double X2;

        public Vector2D()
        {
            D = 1;
            X1 = 0;
            X2 = 0;
        }

        public Vector2D(double X1, double X2)
        {
            D = 1;
            this.X1 = X1;
            this.X2 = X2;
        }

        public override double GetNorm()
        {
            return Math.Sqrt(X1*X1 + X2*X2);
        }

        public override void Normalize()
        {
            double norm = GetNorm();
            if (norm != 0)
            {
                X1 /= norm;
                X2 /= norm;
            }
        }
        public override void Print()
        {
            Console.WriteLine("{0} {1}", X1, X2);
        }
    }

    class MainApp
    {
        static void Main()
        {
            
            VectorCreator creator = new ZeroVectorCreator();
            Vector vector = creator.CreateVector(1);
            vector.Print();
            vector = creator.CreateVector(2);
            vector.Print();
            Console.WriteLine(vector.GetNorm());

            Console.WriteLine();

            creator = new RandomVectorCreator();
            vector = creator.CreateVector(1);
            vector.Print();
            vector = creator.CreateVector(2);
            vector.Print();
            Console.WriteLine(vector.GetNorm());
            vector.Normalize();
            vector.Print();

            Console.ReadKey();
        }
    }
}

