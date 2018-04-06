using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /*
     As the defination goes:
     A factory is the location of a concrete class in the code at which objects are constructed.

     The intent in employing the pattern is to insulate the creation of objects from their usage and to create families of related objects without having to depend on their concrete classes.
    
     We chose this pattern because we wanted to have a single access point for instance creation for a family of classes.
     */
    //Empty vocabulary of actual object
    public interface IPerson
    {
        string GetName();
    }

    public class Villager : IPerson
    {
        public string GetName()
        {
            return "Village Person";
        }
    }

    public class CityPerson : IPerson
    {
        public string GetName()
        {
            return "City Person";
        }
    }

    public enum PersonType
    {
        Rural,
        Urban
    }

    /// <summary>
    /// Implementation of Factory - Used to create objects
    /// </summary>
    public class Factory
    {
        public IPerson GetPerson(PersonType type)
        {
            switch (type)
            {
                case PersonType.Rural:
                    return new Villager();
                case PersonType.Urban:
                    return new CityPerson();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
