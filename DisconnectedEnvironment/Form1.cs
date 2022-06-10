using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisconnectedEnvironment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        

            // TODO: This line of code loads data into the 'hRDataSet.empdetails' table. You can move, or remove it, as needed.
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);
            //This line of code loads data into the hRDataSet.Empdetails table. this would appear in form 1 load event
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            cbDesignation.Enabled = false;
            cbDepartment.Enabled = false;
            cbDesignation.Items.Add("MANAGER");
            cbDepartment.Items.Add("AUTHOR");
            cbDesignation.Items.Add("DESIGNER");
            cbDepartment.Items.Add("MARKETING");
            cbDepartment.Items.Add("FINANCE");
            cbDepartment.Items.Add("IDD");
            cmdSave.Enabled = false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string Code;

            cmdSave.Enabled = true;
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtState.Enabled = true;
            txtCountry.Enabled = true;
            cbDesignation.Enabled = true;
            cbDepartment.Enabled = true;
            txtName.Text = "";
            txtAddress.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            cbDesignation.Text = "";
            cbDepartment.Text = "";
            int ctr, len;
            string codeval;
            dt = hRDataSet.Tables["empdetails"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            Code = dr["ccode"].ToString();
            codeval = Code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr >= 0) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtCode.Text = "C00" + ctr;
            }
            else if ((ctr >= 9) && (ctr < 99))
            {
                ctr = ctr + 1;
                txtCode.Text = "C0" + ctr;
            }
            else if (ctr >= 99)
            {
                ctr = ctr + 1;
                txtCode.Text = "C" + ctr;
            }
            cmdAdd.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            DataRow dr;
            string Code;

            Code = txtCode.Text;
            dr = hRDataSet.Tables["empdetails"].Rows.Find(Code);
            dr.Delete();
            empdetailsTableAdapter.Update(hRDataSet);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            

            dt = hRDataSet.Tables["empdetails"];
            dr = dt.NewRow();
            dr[0] = txtCode.Text;
            dr[1] = txtName.Text;
            dr[2] = txtAddress.Text;
            dr[3] = txtState.Text;
            dr[4] = txtCountry.Text;
            dr[5] = cbDesignation.SelectedItem;
            dr[6] = cbDepartment.SelectedItem;
            dt.Rows.Add(dr);
            empdetailsTableAdapter.Update(hRDataSet);
            txtCode.Text = System.Convert.ToString(dr[0]);
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            cbDesignation.Enabled = false;
            cbDepartment.Enabled = false;
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;
            string Code;

            cmdSave.Enabled = true;
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtState.Enabled = true;
            txtCountry.Enabled = true;
            cbDesignation.Enabled = true;
            cbDepartment.Enabled = true;
            txtName.Text = "";
            txtAddress.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            cbDesignation.Text = "";
            cbDepartment.Text = "";
            int ctr, len;
            string codeval;
            dt = hRDataSet.Tables["empdetails"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            Code = dr["ccode"].ToString();
            codeval = Code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr >= 0) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtCode.Text = "C00" + ctr;
            }
            else if ((ctr >= 9) && (ctr < 99))
            {
                ctr = ctr + 1;
                txtCode.Text = "C0" + ctr;
            }
            else if (ctr >= 99)
            {
                ctr = ctr + 1;
                txtCode.Text = "C" + ctr;
            }
            cmdAdd.Enabled = false;
        }
    }
}
