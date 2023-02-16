using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CW7DecoratorApp
{
    /// <summary>
    /// Interface to link decorators and objects
    /// </summary>
    interface IWidget
    {
        void draw();
    }

    /// <summary>
    /// Concrete TextField Class to print a TextField object
    /// </summary>
    class TextField : IWidget
    {
        private int width;
        private int height;

        public TextField(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void draw()
        {
            Console.WriteLine("TextField: " + width + ", " + height);
        }
    }

    /// <summary>
    /// Abstract Decorator Class to establish interface for concrete decorators
    /// </summary>
    abstract class Decorator : IWidget 
    { 
    
        private IWidget wid;

        public Decorator(IWidget wid)
        {
            this.wid = wid;
        }

        public virtual void draw()
        {
            wid.draw();
        }
    }

    /// <summary>
    /// Concrete Decorator class
    /// </summary>
    class BorderDecorator : Decorator
    {
        public BorderDecorator(IWidget w) : base(w) { } // this is how you call parent constructor

        public override void draw()
        {
            Console.Write("I am a border decorator, holding a: ");
            base.draw();
        }

    }

    /// <summary>
    /// Concrete Decorator class
    /// </summary>
    class ScrollDecorator : Decorator
    {
        public ScrollDecorator(IWidget w) : base(w) { } // this is how you call parent constructor

        public override void draw()
        {
            Console.Write("I am a scroll decorator, holding a: ");
            base.draw();
        }
    }

    /// <summary>
    /// New(Added) Concrete Decorator Class
    /// </summary>
    class GridDecorator : Decorator
    {
        public GridDecorator(IWidget w) : base(w) { } // this is how you call parent constructor

        public override void draw()
        {
            Console.Write("I am a grid decorator, holding a: ");
            base.draw();
        }
    }

    /// <summary>
    /// Class that holds main, decorator use here.
    /// </summary>
    class DecoratorDemo
    {
        static void Main(string[] args)
        {
            TextField t = new TextField(320, 400); // creating the TextField

            BorderDecorator b = new BorderDecorator(t); // Stacking first decorator on TextField
            ScrollDecorator s = new ScrollDecorator(b); // Stacking second decorator on TextField
            GridDecorator g = new GridDecorator(s);     // Stacking third decorator on TextField

            g.draw();                                   // Drawing all stacked decorators

            Console.ReadKey();

        }
    }
}
