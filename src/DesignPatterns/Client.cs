using System;
using Autofac;
using DesignPatterns.Beginner;
using DesignPatterns.Intermediate;

namespace DesignPatterns
{
    public class Client
    {
        public void Execute()
        {
            #region Beginner.Builder
            // Create one director means same construction process
            CommandDirector director = new CommandDirector();

            //Create builders means same product but different representations
            IBuilder b1 = new LoadIntegrationCommandBuilder();
            IBuilder b2 = new ManualIntegrationCommandBuilder();

            // Construct two products
            director.Construct(b1);

            //representation 1
            Command p1 = b1.GetCommand();
            p1.Display();

            director.Construct(b2);
            //representation 2
            Command p2 = b2.GetCommand();
            p2.Display();

            Console.Read();
            #endregion Beginner.Builder

            #region Beginner.Prototype
            Address add = new Address();
            Address add2 = add.DeepCopy();
            #endregion Beginner.Prototype

            #region Beginner.FluentBuilder
            Beginner.Person person = Beginner.Person.New
                .KnownAs.Name("Brajesh").Age(1111).Height(4444)
                .Works.At("Metacube").Getting(5555).As("####");

            Console.Write(person);
            #endregion Beginner.FluentBuilder

            #region Prototype
            Beginner.Person personCopy = CloneManager.DeepCopy(person);
            #endregion Prototype

            #region Adapter
            RawPumpStatus _rawStatus = new RawPumpStatus() { Flow = "9.8", APercent = "67", BPercent = "33" };
            ProcessedPumpStatus _status = Converter.ConvertPumpStatus(_rawStatus);
            #endregion Adapter

            #region Bridge
            var nRenderer = new DesignPatterns.Intermediate.NevronChartRenderer();
            var wRenderer = new DesignPatterns.Intermediate.WatersChartRenderer();

            var nBarChart = new DesignPatterns.Intermediate.BarChart(nRenderer);

            nBarChart.Draw();
            nBarChart.Resize();

            var wBarChart = new DesignPatterns.Intermediate.BarChart(wRenderer);
            wBarChart.Draw();
            wBarChart.Resize();

            var nPieChart = new DesignPatterns.Intermediate.PieChart(nRenderer);

            nPieChart.Draw();
            nPieChart.Resize();

            var wPieChart = new DesignPatterns.Intermediate.PieChart(wRenderer);
            wPieChart.Draw();
            wPieChart.Resize();

            //use dependency injection to resolve any construction dependency
            IOCContainer.CreateContainer(RendererType.Waters);
            var bubbleChart = new DesignPatterns.Intermediate.BubbleChart();
            #endregion Bridge

            #region Observer
            WatchedCollection wc = new WatchedCollection();

            Watcher watcher1 = new Watcher();
            //watch events on collection
            watcher1.Watch(wc);

            Watcher watcher2 = new Watcher();
            //watch events on collection
            watcher2.Watch(wc);

            wc.AddItem("First");
            wc.AddItem("Second");

            wc.RemoveItem("Second");
            #endregion Observer
                
            #region strategy

            Log l = new Log();
            new Exporter<ExportToCSV>().Export(l);

            new Exporter<ExportToWord>().Export(l);

            #endregion strategy

            #region mediater
            var room = new ChatRoom();
            room.SetName("Storm");

            var ram = new Intermediate.Person("ram");
            var rahim = new Intermediate.Person("rahim");

            room.Join(ram);
            room.Join(rahim);

            ram.Say("hi room");
            rahim.Say("oh, hey ram, how r u?");

            var kishan = new Intermediate.Person("kishan");
            room.Join(kishan);
            kishan.Say("hi everyone!");

            ram.PrivateMessage("kishan", "glad you could join us!");

            #endregion mediater

            #region Visitor
            Expression e1 = new Value(2);
            Expression e2 = new Value(3);

            ExpressionEvaluator ev = new ExpressionEvaluator();
            ExpressionPrinter ep = new ExpressionPrinter();

            MultiplicationExpression me = new MultiplicationExpression(e1, e2);
            me.Accept(ev);
            Console.WriteLine($"Visitor.MultiplicationExpressionEvaluator: {ev.getResult()}");//must print 6

            me.Accept(ep);
            Console.WriteLine($"Visitor.MultiplicationExpressionPrinter: {ep.getReport()}");//must print (2 * 3)

            AdditionExpression ae = new AdditionExpression(e1, e2);
            ae.Accept(ev);
            Console.WriteLine($"Visitor.AdditionExpressionEvaluator: {ev.getResult()}");//must print 5

            ae.Accept(ep);
            Console.WriteLine($"Visitor.AdditionExpressionPrinter: {ep.getReport()}");//must print (2 + 3)
            #endregion Visitor

            #region NullObject
            Transaction tr = new Transaction(new NullLogger());
            tr.MakeTransaction();
            #endregion NullObject
        }
    }
}
