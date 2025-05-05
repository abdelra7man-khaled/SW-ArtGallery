using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Art_Gallery
{
    public partial class Report1 : Form
    {
        CrystalReport1 cr1;
        public Report1()
        {
            InitializeComponent();
        }

        private void Report1_Load(object sender, EventArgs e)
        {
            cr1 = new CrystalReport1();
            crystalReportViewer1.ReportSource = cr1;
        }

      
    }
}
