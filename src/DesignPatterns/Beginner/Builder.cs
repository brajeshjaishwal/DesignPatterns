using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Beginner
{
    /*
     * Separate the construction of a complex object from its representation so that the
     * same construction process (Director) can create different representations (Builders).
     * 
     * 
     */

    /// <summary>
    /// Same construction process
    /// </summary>
    public class CommandDirector
    {
        public void Construct(IBuilder b)
        {
            b.SetId();
        }
    }

    public interface IBuilder
    {
        void SetId();
        Command GetCommand();
    }

    /// <summary>
    /// Representation 1 of the same product
    /// </summary>
    public class LoadIntegrationCommandBuilder : IBuilder
    {
        Command p = new Command();
        public void SetId()
        {
            p.SetId(CommandId.LoadIntegration);
        }
        public Command GetCommand()
        {
            return p;
        }
    }

    /// <summary>
    /// Representation 2 of the same product
    /// </summary>
    public class ManualIntegrationCommandBuilder : IBuilder
    {
        Command p = new Command();
        public void SetId()
        {
            p.SetId(CommandId.ManualIntegration);
        }
        public Command GetCommand()
        {
            return p;
        }
    }

    public class Command
    {
        public CommandId Id;

        public void SetId(CommandId id)
        {
            Id = id;
        }

        public void Display()
        {
            Console.WriteLine("\nFeature list ...");
            Console.WriteLine($"Command id: {Id}");
            Console.WriteLine();
        }
    }

    public enum CommandId { LoadIntegration, ManualIntegration }
}
