using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Birthday_Contact_Book
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadFile();
            CheckForBirthDays();
            UpdateDisplayMember();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(new Person());

            listBox1.SelectedIndex = listBox1.Items.Count-1;

            
        }
        private void UpdateDisplayMember()
        {
            //reseting and updating
            listBox1.DisplayMember = "";
            listBox1.DisplayMember = "Name";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                return;
            }
            int savedIndex = listBox1.SelectedIndex;
            
            if (savedIndex - 1 > 0)
            {
                //apply the remove function to the previous item.
                listBox1.SelectedIndex = savedIndex - 1;
            }
            else if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
            //selectedIndex is the highlighted value
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }
            //cast object listbox1 to person class object
            Person person = (Person)listBox1.SelectedItem;

            textName.Text = person._name;
            textEmail.Text = person._email;
            textAddress.Text = person._email;
            birthdayPicker.Value = person._birthday;
            textNotes.Text = person._notes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }
            Person person = (Person)listBox1.SelectedItem;

            person._name = textName.Text;
            person._email = textEmail.Text;
            person._address = textAddress.Text;
            person._birthday = birthdayPicker.Value;
            person._notes = textNotes.Text;

            UpdateDisplayMember();

            SaveFile();
        }

        private void CheckForBirthDays()
        {
            Person person;
            string birthdays = "";

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                person = listBox1.Items[i] as Person;

                if (person != null && person._birthday.Day == DateTime.Today.Day && person._birthday.Month == DateTime.Today.Month)
                {
                    birthdays += person._name + "is " + (DateTime.Today.Year - person._birthday.Year).ToString() + "today! \n";
                        
                }
            }
            if (birthdays != "")
            {
                MessageBox.Show(birthdays, "Birthdays!");
            }
        }
        private void SaveFile()
        {
            try
            {
                SaveFile saveFile = new SaveFile();
                saveFile.people = listBox1.Items.Cast<Person>().ToList();

                XmlHelper.Save(saveFile, "Info.mic");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the contact list" + ex.ToString());
            }
        }
        private void LoadFile()
        {
            try
            {
                SaveFile saveFile = XmlHelper.Load("Info.mic");

                for (int i = 0; i < saveFile.people.Count; i++)
                {
                    listBox1.Items.Add(saveFile.people[i]);
                }
            }
            catch 
            {
               
            }
        }
    }
}
