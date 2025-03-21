using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.People.My_Controls
{
    public partial class ctrlPersonWithfilter : UserControl
    {

        //Defining a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;

        //create a protected event top raise the event with a parameter

        protected virtual void PersonSelected(int PersonID)
        {
            Action <int> handler = OnPersonSelected;
            if (handler != null)
                handler(PersonID);//raise the event with the parameter
        }

        private bool _ShowAddPersonBtn = true;

        public bool ShowAddPersonBtn
        {
            get { return _ShowAddPersonBtn; }

            set
            {
                _ShowAddPersonBtn = value;
                btnAddNewPerson.Visible = _ShowAddPersonBtn;
            }
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        public int PersonID
        {
            get { return personCard1.PersonID; }
        }

        public void FilterFocus()
        {
            txtFilter.Focus();
        }

        public clsPerson SelectedPersonInfo
        {
            get
            {
                return personCard1.SelectedPersonInfo;
            }            
        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFilter.SelectedIndex = 1;
            txtFilter.Text=PersonID.ToString();
            _FindPerson();

            if (OnPersonSelected != null )
                //raising the event with the parameter
                OnPersonSelected(personCard1.PersonID);

        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();

            if (OnPersonSelected != null && FilterEnabled)
                //raising the event with the parameter
                OnPersonSelected(personCard1.PersonID);
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            //Handle The Received data
            cbFilter.SelectedIndex = 1;
            txtFilter.Text = PersonID.ToString();
            personCard1.LoadPersonInfo(PersonID);
        }
        public ctrlPersonWithfilter()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //check if the pressed key is Enter (character code is 13)

            if (e.KeyChar == (char)13)
                btnSearch.PerformClick();

            if(cbFilter.Text == "Person ID")
            e.Handled=!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void _FindPerson()
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            switch (cbFilter.Text)
            {
                case "Person ID":
                    personCard1.LoadPersonInfo(int.Parse(txtFilter.Text.Trim()));
                    break;
                case "National No":
                    personCard1.LoadPersonInfo(txtFilter.Text.Trim());
                    break;
            }   
            
            if(OnPersonSelected != null&&FilterEnabled)
                //raising the event with the parameter
            OnPersonSelected(personCard1.PersonID);
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

     
                txtFilter.Text = "";
                txtFilter.Focus();
     
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _FindPerson();
        }


        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {

        }

        private void personCard1_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            txtFilter.Focus();
        }
    }
}
