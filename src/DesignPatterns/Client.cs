using DesignPatterns.Beginner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Client
    {
        public static void Main()
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
            Person person = Person.New
                .KnownAs.Name("Brajesh").Age(1111).Height(4444)
                .Works.At("Metacube").Getting(5555).As("####");

            Console.Write(person);
            #endregion Beginner.FluentBuilder

            #region Prototype
            Person personCopy = CloneManager.DeepCopy<Person>(person);
            #endregion Prototype
        }
    }
}
