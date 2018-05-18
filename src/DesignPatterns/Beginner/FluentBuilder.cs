using System;

namespace DesignPatterns.Beginner
{
    public class Person
    {
        public class PersonBuilder
        {
            protected Person _person = new Person();

            public PersonInfoBuilder KnownAs => new PersonInfoBuilder() { _person = _person };
            public PersonJobBuilder Works => new PersonJobBuilder() { _person = _person };

            public static implicit operator Person(PersonBuilder pb) => pb._person;
        }

        //Personal information
        public string Name; public double Age, Height;

        //Job information
        public string Company, Role; public double Salary;

        //Address information
        public string Address; public double PinCode, Phone;

        private Person() { }

        public static PersonBuilder New => new PersonBuilder();
    }
    public class PersonInfoBuilder : Person.PersonBuilder
    {
        public PersonInfoBuilder Name(string n) { _person.Name = n; return this; }
        public PersonInfoBuilder Age(double age) { _person.Age = age; return this; }
        public PersonInfoBuilder Height(double h) { _person.Height = h; return this; }
    }
	public class PersonJobBuilder : Person.PersonBuilder
    {
        public PersonJobBuilder At(string company) { _person.Company = company; return this; }
        public PersonJobBuilder As(string role) { _person.Role = role; return this; }
        public PersonJobBuilder Getting(double salary) { _person.Salary =salary; return this; }
	}
}
