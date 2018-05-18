using System;
namespace DesignPatterns
{
    public class Person
    {
        //Personal information
        public string Name; public double Age, Height;

        //Job information
        public string Company, Role; public double Salary;

        //Address information
        public string Address; public double PinCode, Phone;
    }

    public class PersonBuilder
    {
        protected Person _person = new Person();
        public PersonInfoBuilder KnownAs => new PersonInfoBuilder(){_person = _person};
        public PersonJobBuilder Works => new PersonJobBuilder(){_person = _person};

        public static implicit operator Person(PersonBuilder pb) => pb._person;
    }
    public class PersonInfoBuilder : PersonBuilder
    {
        public PersonInfoBuilder Name(string n) { _person.Name = n; return this; }
        public PersonInfoBuilder Age(double age) { _person.Age = age; return this; }
        public PersonInfoBuilder Height(double h) { _person.Height = h; return this; }
    }
	public class PersonJobBuilder : PersonBuilder
	{
        public PersonJobBuilder At(string company) { _person.Company = company; return this; }
        public PersonJobBuilder As(string role) { _person.Role = role; return this; }
        public PersonJobBuilder Getting(double salary) { _person.Salary =salary; return this; }
	}

	public class Demo
	{
		public static void Main(string[] args)
        {
			PersonBuilder pb = new PersonBuilder();
			Person person = pb
				.KnownAs.Name("Brajesh").Age(1111).Height(4444)
				.Works.At("Metacube").Getting(5555).As("####");

			Console.Write(person);
		}
	}
}
