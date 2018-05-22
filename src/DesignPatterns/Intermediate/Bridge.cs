using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace DesignPatterns.Intermediate
{
    /*
     Definition: Decouple an abstraction from its implementation so that the two can vary independently.

     */

    public enum RendererType { Nevron, Waters } 
    //Abstraction
    public interface IRenderer
    {
        void Draw();
        void Resize();
    }

    //First handler
    public class NevronChartRenderer : IRenderer
    {
        public NevronChartRenderer() {}
        public void Draw() => Console.WriteLine("Nevron renderer handling of Draw.");
        public void Resize() => Console.WriteLine("Nevron renderer handling of Resize.");
    }

    //Second handler
    public class WatersChartRenderer : IRenderer
    {
        public WatersChartRenderer() {}
        public void Draw() => Console.WriteLine("Waters renderer handling of Draw.");
        public void Resize() => Console.WriteLine("Waters renderer handling of Resize.");
    }

    //Bridge
    public abstract class Chart{
        IRenderer _renderer = null;
        public Chart()
        {
            using (var scope = IOCContainer.Container.BeginLifetimeScope())
            {
                _renderer = scope.Resolve<IRenderer>();
            }
        }
        public Chart(IRenderer _r) { _renderer = _r; }
        public virtual void Draw() => _renderer.Draw();
        public virtual void Resize() => _renderer.Resize();
    }

    public class PieChart : Chart
    {
        public PieChart(IRenderer _r) : base(_r) {}

        public override void Draw() {
            base.Draw();
            //Pie chart related stuffs.
        }
        public override void Resize() {
            base.Resize();
            //Pie chart related stuffs.
        }
    }

    public class BarChart : Chart
    {
        public BarChart(IRenderer _r) : base(_r) {}
        public override void Draw() {
            base.Draw();
            //Bar chart related stuffs.
        }
        public override void Resize() {
            base.Resize();
            //Bar chart related stuffs.
        }
    }

    /// <summary>
    /// Chart control with dependency injection
    /// </summary>
    public class BubbleChart : Chart{

        public override void Draw() {
            base.Draw();
            //Bubble chart related stuffs.
        }
        public override void Resize() {
            base.Resize();
            //Bubble chart related stuffs.
        }
    }
}