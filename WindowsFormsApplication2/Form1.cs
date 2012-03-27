using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WcfServiceLibrary1;
using WindowsFormsApplication2.PersonServiceReference;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            firstNameBox.KeyDown += OnKeyDownHandler;
            lastNameBox.KeyDown += OnKeyDownHandler;
            ageBox.KeyDown += OnKeyDownHandler;
        }


        private void SearchBtn_Click(object sender, EventArgs e)
        {
            ShowResults(firstNameBox.Text, lastNameBox.Text, ageBox.Text);
        }


        private void ShowAllBtn_Click(object sender, EventArgs e)
        {
            ShowResults("", "", "");
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowResults(firstNameBox.Text, lastNameBox.Text, ageBox.Text);
            }
        }


        private void ShowResults(string firstName, string lastName, string age)
        {
            int ageInt = 0;

            if(!age.Equals(""))
            {
                ageInt = Convert.ToInt32(age);
            }

            List<Person> result = Search(firstName, lastName, ageInt);
            Resultslist.Items.Clear();

            if (result != null)
            {
                foreach (Person person in result)
                {
                    if (person != null)
                    {
                        Resultslist.Items.Add(person.FirstName + " " + person.LastName + " - " + person.Age);
                    }
                }
            }
        }

        private List<Person> Search(string f, string e, int a)
        {
                PersonServiceClient client = new PersonServiceClient();
                List<Person> result = client.Search(f, e, a);
                client.Close();
                return result;
            
        }

        

        

    }
}
