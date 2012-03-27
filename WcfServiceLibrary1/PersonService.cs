
using System.Collections.Generic;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PersonService" in both code and config file together.
    public class PersonService : IPersonService
    {
        List<Person> people = new List<Person>();
        List<Person> results = new List<Person>();

        public List<Person> Search(string firstName, string lastName, int age)
        {
            PropagateList();

                foreach (Person person in people)
                {
                    if ((person.FirstName.ToLower().Contains(firstName.ToLower()) && !firstName.Equals("")) ||
                        (person.LastName.ToLower().Contains(lastName.ToLower()) && !lastName.Equals("")))
                    {
                        results.Add(person);
                    }else if(person.Age == age)
                    {
                        results.Add(person);
                    }
                }

            if(firstName.Equals("") && lastName.Equals("") && age.Equals(0))
            {
                return people;
            }

            return results;

        }

        private void PropagateList()
        {
            people.Add(new Person("Alexander", "Perry", 22));
            people.Add(new Person("Alexander", "Jensen", 34));
            people.Add(new Person("Jens", "Perry", 12));
            people.Add(new Person("Renate", "Jensen", 12));
            people.Add(new Person("Nils", "Jensen", 22));
            people.Add(new Person("Anne", "Nilsen", 34));
            people.Add(new Person("Anne", "Jensen", 23));
            people.Add(new Person("Arne", "Jensen", 24)); 
        }
    }
}
