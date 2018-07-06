using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Intermediate
{
    public enum LoggerType { Null, FileLogger }
    /*
     * 
        Definition: Provide an object as a surrogate for the lack of an object of a given type.
        The Null object Pattern provides intelligent do nothing behavior, 
            hiding the details from its collaborators.
     */
    public interface ILogger
    {
        void Log();
    }

    public class NullLogger : ILogger
    {
        public void Log()
        {
            //do nothing
        }
    }

    public class ActualLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logger is connected.");
        }
    }

    public class Transaction
    {
        ILogger _log = null;
        public Transaction()
        {
            using (var scope = IOCContainer.Container.BeginLifetimeScope())
            {
                _log = scope.Resolve<ILogger>();
            }
        }
        public Transaction(ILogger logger)
        {
            _log = logger;
        }
        public void MakeTransaction()
        {
            //to do transaction
            _log.Log();
        }
    }

}
