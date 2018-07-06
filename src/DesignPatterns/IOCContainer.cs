using Autofac;
using DesignPatterns.Intermediate;

/// <summary>
/// IOC container to introduce dependancies
/// we are using autofac for the purpose
/// </summary>
public class IOCContainer{

    public static IContainer Container = null;
    public static void CreateContainer(RendererType t)
    {
      ContainerBuilder builder = new ContainerBuilder();
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
    public static void CreateLogger(LoggerType lt)
    {
        ContainerBuilder builder = new ContainerBuilder();
        if(lt == LoggerType.FileLogger)
        {
            builder.RegisterType<ActualLogger>().As<ILogger>();
        }
        else
        {
            builder.RegisterType<NullLogger>().As<ILogger>();
        }
        Container = builder.Build();
    }
}