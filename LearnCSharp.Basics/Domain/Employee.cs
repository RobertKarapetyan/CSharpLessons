using System;

namespace LearnCSharp.Basics.Domain
{
    public class Employee : IEmployee
    {
        protected readonly string FirstName;
        protected readonly string LastName;
        public int Id;

        public Employee(string firstName, string lastName)
        {
            Id = 123;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Name()
        {
            var result = $"{LastName}, {FirstName}";
            return result;
        }

        public virtual string PerformDuties()
        {
            throw new System.NotImplementedException();
        }

        public Employee Clone()
        {
            var result = (Employee) MemberwiseClone();
            return result;
        }
        
        ~Employee()
        {
            Console.WriteLine("Clean Up");
        }
    }
}