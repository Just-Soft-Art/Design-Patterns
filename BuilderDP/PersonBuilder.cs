using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDP
{
    public class Person
    {
        private string Name { get; }
        private string LastName { get; }
        private int YearOfBirth { get; }
        private int Age { get; }

        private Person(string name, string lastName, int yearOfBirth, int age)
        {
            Name = name;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
            Age = age;
        }

        public class Builder
        {
            private string _name;
            private string _lastName;
            private int _yearOfBirth;
            private int _age;

            public Builder WithName(string name)
            {
                _name = name;
                return this;
            }

            public Builder WithLastName(string lastName)
            {
                _lastName = lastName;
                return this;
            }

            public Builder WithYearOfBirth(int yearOfBirth)
            {
                if (yearOfBirth > DateTime.Now.Year || yearOfBirth < 1900)
                {
                    throw new Exception("Invalid year of birth");
                }
                _age = DateTime.Now.Year - yearOfBirth;
                _yearOfBirth = yearOfBirth;
                return this;
            }

            public Person Build()
            {
                return new Person(_name, _lastName, _yearOfBirth, _age);
            }
        }
    }

}
