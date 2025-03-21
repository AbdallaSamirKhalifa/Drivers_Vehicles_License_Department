using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Licenses.Local_Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {

        private int _PersonID=-1;
        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
        }
        
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ctrlPersonWithfilter1.LoadPersonInfo(_PersonID);
                ctrlDriverLicenses1.LoadByPersonID(_PersonID);  
                ctrlPersonWithfilter1.FilterEnabled = false;
            }
            else
            {
                ctrlPersonWithfilter1.FilterEnabled = true;
                ctrlPersonWithfilter1.FilterFocus();
            }

        }

        private void ctrlPersonWithfilter1_OnPersonSelected(int PersonID)
        {
            _PersonID = PersonID;
            if(_PersonID != -1)
            {
                ctrlDriverLicenses1.LoadByPersonID(PersonID);
            }else
                ctrlDriverLicenses1.Clear();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
