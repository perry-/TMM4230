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
        

        public int Add(int a, int b)
        {
            return a + b;
        }

        public bool Search(string fornavn, string etternavn)
        {
            ArrayList people = new ArrayList();
            people.Add("Alexander");

            foreach (string person in people)
            {
                if(fornavn.ToLower().IndexOf(person.ToLower()) != -1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
