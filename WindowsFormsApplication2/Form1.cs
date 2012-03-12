using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            showResults();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                showResults();
            }
        }


        private void showResults()
        {
            string fornavn, etternavn, alder;
            fornavn = fornavnBox.Text;
            etternavn = etternavnBox.Text;
            alder = alderBox.Text;

            bool result = Search(fornavn, etternavn);

            if(result == true)
            {
                MessageBox.Show("Person eksisterer i listen");
            }
            else
            {
                MessageBox.Show("Person eksisterer ikke i listen");
            }
            
            /*MessageBox.Show("Fornavn: " + fornavn +
                        "\n" + "Etternavn: " + etternavn +
                        "\n" + "Alder: " + alder, "Resultat",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);*/

        }

        private bool Search(string f, string e)
        {
            PersonServiceClient client = new PersonServiceClient();
            bool result = client.Search(f, e);
            client.Close();
            return result;
        }
    }
}
