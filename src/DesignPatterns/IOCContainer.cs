using Autofac;
using DesignPatterns.Intermediate;
public class IOCContainer{
    public static IContainer Container = null;
    public static void CreateContainer(RendererType t)
    {
      ContainerBuilder builder = new ContainerBuilder();
      //builder.RegisterType<TodayWriter>().As<IDateWriter>();
      if(t == RendererType.Nevron)
      {
          builder.RegisterType<NevronChartRenderer>().As<IRenderer>();
      }
      else 
      {
          builder.RegisterType<WatersChartRenderer>().As<IRenderer>();
      }
      Container = builder.Build();
    }
}