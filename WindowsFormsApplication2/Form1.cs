using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
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
            fornavnBox.KeyDown += OnKeyDownHandler;
            etternavnBox.KeyDown += OnKeyDownHandler;
            alderBox.KeyDown += OnKeyDownHandler;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ShowResults();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowResults();
            }
        }


        private void ShowResults()
        {
            string fornavn, etternavn;
            int alder;
            fornavn = fornavnBox.Text;
            etternavn = etternavnBox.Text;
            alder = 0;

            if(alderBox.Text != "")
            {
                alder = Convert.ToInt32(alderBox.Text);
            }

            ArrayList result = Search(fornavn, etternavn, alder);

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

        private ArrayList Search(string f, string e, int a)
        {
                PersonServiceClient client = new PersonServiceClient();
                ArrayList result = client.Search(f, e, a);
                client.Close();
                return result;

            
            
        }
    }
}
