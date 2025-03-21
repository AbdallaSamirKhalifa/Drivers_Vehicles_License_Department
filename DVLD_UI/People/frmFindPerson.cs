using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.People
{
    public partial class frmFindPerson : Form
    {
        //declaring th delegate for the event
        public delegate void DataBackEventHandler(object sender, int PersonID);
        //declare an event from the delegate
        public event DataBackEventHandler DataBack;
        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlPersonWithfilter1.PersonID);
            this.Close();
        }
    }
}
