using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.My_Forms
{
    public partial class frmPersonDetails : Form
    {
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            personCard1.LoadPersonInfo(PersonID);
        }
        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            personCard1.LoadPersonInfo(NationalNo);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}
