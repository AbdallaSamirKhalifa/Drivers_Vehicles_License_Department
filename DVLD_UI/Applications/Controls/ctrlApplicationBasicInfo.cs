﻿using DVLD_Buisness;
using DVLD_UI.GlobalClasses;
using DVLD_UI.My_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Controls
{

    
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private clsApplication _Application;

        private int _ApplicationID;

        public int ApplicationID{ get { return _ApplicationID; } }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;
            lblApplicationID.Text = "???";
            lblStatus.Text = "???";
            lblFees.Text = "$$$";
            lblType.Text = "???";
            lblApplicant.Text = "????";
            lblDate.Text = "??/??/????";
            lblStatusDate.Text = "??/??/????";
            lblCreatedByUser.Text = "????";
        }
        public void LoadApplicationInfo(int ApplicationID)
        {

            _Application=clsApplication.FindBaseApplication(ApplicationID);

            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                _FillApplicationInfo();
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationTypeInfo.Title;
            lblApplicant.Text = _Application.ApplicantFullName;
            lblDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort( _Application.LastStatusDate );
            lblCreatedByUser.Text = _Application.CreatedByUserInfo.UserName;

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_Application.PersonInfo.ID);
            frm.ShowDialog();

            //refresh
            LoadApplicationInfo(_ApplicationID);
        }
    }
}
