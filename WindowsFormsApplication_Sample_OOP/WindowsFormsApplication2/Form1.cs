using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            //Q1
            var list = new List<int>() {1,2,3,4, 5, 8, 99};

            var result = from item in list
			            where item > 2
			            select item;

            foreach (var num in result)
            {
                listBox1.Items.Add(num.ToString());
            }

            //Q2
            var address1 = new Address() 
            {
                Address_id = 1,
                Street = "56 Brimwood blvd.",
                City = "Toronto",
                State = "Ontario",
                Zip = "M1V 1B8"               
            };

            var address2 = new Address()
            {
                Address_id = 2,
                Street = null,
                City = "Toronto",
                State = "Ontario",
                Zip = "M1V 1B8"
            };

            //with full information of address
            var person1 = new Person()
            {
                Person_Id = 1,
                First_Name = "Bill",
                Last_Name = "Teng",
                DOB = DateTime.Now,

                Address_Id = 1,
                Person_Address = address1
            };

            //No street in address
            var person2 = new Person()
            {
                Person_Id = 1,
                First_Name = "Bill",
                Last_Name = "Teng",
                DOB = DateTime.Now,
                
                Address_Id = 2,
                Person_Address = address2
            };

            //No address
            var person3 = new Person()
            {
                Person_Id = 1,
                First_Name = "Bill",
                Last_Name = "Teng",
                DOB = DateTime.Now
            };

            var result1 = person1.Infors();
            var result2 = person2.Infors();
            var result3 = person3.Infors();

            listBox1.Items.Add(result1);
            listBox1.Items.Add(result2);
            listBox1.Items.Add(result3);
        }

    }

    public class Address
    {
        public int Address_id { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public virtual ICollection<Person> Person { get; set; }        
    }

    public partial class Person
    {
        public int Person_Id { get; set; }

        public string First_Name { get; set; }

        public string Middle_Name { get; set; }

        public string Last_Name { get; set; }

        public DateTime DOB { get; set; }

        public int Address_Id { get; set; }

        public Address Person_Address { get; set; }
   
        public string Infors()
        {
            if (this.Person_Address == null)
                return string.Format("{0}, {1} ({2})",
                    this.First_Name, this.Last_Name, this.DOB);

            return string.Format("{0}, {1} ({2}) {3}, {4}",
                    this.First_Name, this.Last_Name, this.DOB, this.Person_Address.Street, this.Person_Address.City);
        }
    }
}
