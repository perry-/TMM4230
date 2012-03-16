using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PersonService" in both code and config file together.
    public class PersonService : IPersonService
    {
        public ArrayList Search(string firstName, string lastName, int age)
        {
            ArrayList people = new ArrayList();
            ArrayList results = new ArrayList();
            people.Add(new Person("Alexander", "Perry", 22));
            people.Add(new Person("Alexander", "Jensen", 34));
            people.Add(new Person("Jens", "Perry", 12));
            people.Add(new Person("Renate", "Jensen", 12));

            foreach (Person person in people)
            {
                if((firstName.ToLower().IndexOf(person.FirstName.ToLower()) != -1) || (lastName.ToLower().IndexOf(person.LastName.ToLower()) != -1))
                {
                    results.Add(person);
                    return results;
                }
            }

            return null;
        }
    }
}
