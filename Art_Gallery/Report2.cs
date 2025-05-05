using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;


namespace Art_Gallery
{
    public partial class Report2 : Form
    {
        CrystalReport2 cr2;
        public Report2()
        {
            InitializeComponent();
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void Report2_Load(object sender, EventArgs e)
        {
            cr2 = new CrystalReport2();
            foreach(ParameterDiscreteValue v in cr2.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }
        }

        private void generate_button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                cr2.SetParameterValue(0, comboBox1.Text);
                cr2.SetParameterValue(1, Convert.ToInt32(textBox2.Text));
                cr2.SetParameterValue(2, Convert.ToInt32(textBox3.Text));
                crystalReportViewer1.ReportSource = cr2;
            }
            else
                MessageBox.Show("Fill all required data !");
        }
    }
}
