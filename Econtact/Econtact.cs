using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Econtact.econtactClasses;

namespace Econtact
{
    public partial class Econtact : Form
    {
        public Econtact()
        {
            InitializeComponent();
        }
        contactClass c = new contactClass();

        private void Econtact_Load(object sender, EventArgs e)
        {
            //Load data onto GridView
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblContactNumber_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtboxContactNumber.Text;
            c.Address = txtBoxAddress.Text;
            c.Gender = cmbGender.Text;

            bool success = c.Insert(c);
            if (success == true)
            {
                //Successfully inserted
                MessageBox.Show("New Contact Successfully added");
            }
            else
            {
                //Failed to insert data
                MessageBox.Show("Failed to add new Contact. Try again.");

            }

                //Load data onto GridView
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
        
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get value from text box
            string keyword = txtBoxSearch.Text;
            SqlConnection conn = new SqlConnection(myconnstr);

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tbl_contact WHERE FirstName LIKE '%" + keyword + "%' OR LastName LIKE '%" + keyword + "%' OR Address LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvContactList.DataSource = dt;
        }
    }
}
