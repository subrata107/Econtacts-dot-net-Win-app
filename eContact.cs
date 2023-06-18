using Econtacts.eContactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Econtacts
{
    public partial class eContact : Form
    {
        
        public eContact()
        {
            InitializeComponent();
        }
        
        eContactClass eC = new eContactClass();
        private void eContact_Load(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            label7.Text = "";
            bool success=false;
            eC.FirstName = textBox1.Text;     
            eC.LastName = textBox2.Text;
            eC.ContactNum = textBox3.Text;
            eC.City = textBox4.Text;
            
            if (eC.FirstName != "" && eC.LastName !="" && eC.ContactNum !="" && eC.City !="" )
            {
                 success = eC.Insert(eC);
                
            }
            else
            {
                
                
                label6.Text="Blank record Not Allowed for Insertion";
            }

            if (success == true)
            {

                label7.Text = "Records Inserted";

                DataTable dt = eC.ShowAllRecords();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show(" Error inserting record");
                label6.Text = "";
            }
           

        }

        private void ShowAllRecords_Click(object sender, EventArgs e)
        {
            DataTable dt = eC.ShowAllRecords();
            dataGridView1.DataSource = dt;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            label7.Text = "";
            bool success = false;
            eC.FirstName = textBox1.Text;
            eC.LastName = textBox2.Text;
            eC.ContactNum = textBox3.Text;
            eC.City = textBox4.Text;

            if (eC.FirstName != "" && eC.LastName != "" && eC.ContactNum != "" && eC.City != "")
            {
                success = eC.Update(eC);

            }
            else
            {
                label6.Text = "Blank record Not Allowed for Updation";
            }

            if (success == true)
            {
                label7.Text = "Updation Successful";

                DataTable dt = eC.ShowAllRecords();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show(" Error Updating record");
                label6.Text = "";
            }

        }

        private void Delete_Click(object sender, EventArgs e)

        {
            label6.Text = "";
            label7.Text = "";
            bool success = false;

            eC.ContactNum = textBox3.Text;


            if (eC.ContactNum != "")
            {
                success = eC.Delete(eC);

            }
            else
            {
                label6.Text = "Provide your Contact# to Delete";
            }

            if (success == true)
            {
                label7.Text = "Record Deleted Successfully";

                DataTable dt = eC.ShowAllRecords();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show(" Error Deleting record");
                label6.Text = "";
            }

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            label7.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
         
    }
}
