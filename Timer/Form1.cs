using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.VisualBasic; // 입력값이 숫자인지를 확인하는 IsNumeric를 위해 추가

namespace Timer
{
    public partial class Form1 : Form
    {
        int CountOrgNum = 0; // 초기 카운터

        private bool IntCheck()
        {
            if (Information.IsNumeric(this.txtNum.Text)) //IsNumeric : 숫자이면 true 아니면 false
            {
                return true;
            }
            else
            {
                MessageBox.Show("숫자를 입력하세요~", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void txtCountDown_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            if (IntCheck())
            {
                this.CountOrgNum = Convert.ToInt32(this.txtNum.Text);
                this.Timer.Enabled = true; //Enabled 은 키는 거 
                this.txtNum.ReadOnly = true; //읽기전용
            }
            else
            {
                this.txtNum.Text = ""; //초기화
                this.txtNum.Focus();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if(this.CountOrgNum < 1)
            {
                this.Timer.Enabled = false;
                this.txtNum.ReadOnly = false;
                this.txtNum.Text = "";
                this.txtCountDown.Text = "";
                MessageBox.Show("펑!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.txtNum.Focus();
            }
            else
            {
                this.CountOrgNum--;
                this.txtCountDown.Text = Convert.ToString(this.CountOrgNum);
            }
        }      
    }
}
