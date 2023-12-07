using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ChristmasTree c = new ChristmasTree();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d1.Decorations = "garlands";

            d2.SetComponent(d1);
            d2.Shine();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Tree
    {
    }

    // "ConcreteComponent"
    class ChristmasTree : Tree
    {
    }
    // "Decorator"
    abstract class Decorator : Tree
    {
        protected Tree tree;

        public void SetComponent(Tree tree)
        {
            this.tree = tree;
        }
    }

    // "ConcreteDecoratorA"
    class ConcreteDecoratorA: Decorator
    {
        public string Decorations { get; set; }
    }
    // "ConcreteDecoratorA"
    class ConcreteDecoratorB : Decorator
    {
        public void Shine()
        {
            Console.WriteLine("Christmas tree shines");
        }
    }
}
