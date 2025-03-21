using DVLD_Buisness;
using DVLD_UI.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Tests
{
    public partial class frmTakeTest : Form
    {
        private int _AppointmentID= -1;
        private clsTestType.enTestType _TestType;
        private clsTest _Test;
        private int _TestID=-1;

        public frmTakeTest(int AppointmentID,clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestType = TestType;


        }

        private void _ResetDefaultValues()
        {
          ctrlScheduledTest1.TestType= _TestType;
                ctrlScheduledTest1.LoadData(_AppointmentID);

                if(ctrlScheduledTest1.AppointmentID==-1)
                    btnSave.Enabled = false;
                else
                    btnSave.Enabled = true;


                _TestID = ctrlScheduledTest1.TestID;

                if (_TestID != -1)
                {
                    _Test = clsTest.Find(_TestID);

                    if (_Test.TestResult)
                        rbPass.Checked = true;
                    else
                        rbFail.Checked = true;

                    txtNotes.Text = _Test.Notes;

                    lblUserMessage.Visible = true;
                    btnSave.Enabled = false;
                    rbPass.Enabled = false;
                    rbFail.Enabled = false;
                    txtNotes.Enabled = false;
                }
                else
                    _Test = new clsTest();
        }

        private void _Save()
        {
            _Test.TestResult = rbPass.Checked;
            _Test.CreatedByUserID=clsGlobal.CurrentUser.UserID;
            _Test.TestAppointmentID = _AppointmentID;
            _Test.Notes=txtNotes.Text;

            if (MessageBox.Show("Are you sure you want to save? You cannot change the results after you save", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                ==
                DialogResult.No)
                return;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
      
            _ResetDefaultValues();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
