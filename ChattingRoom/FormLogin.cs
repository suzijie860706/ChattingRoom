using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace ChattingRoom
{
    public partial class FormLogin : Form
    {
        public static ClientData clientData;

        public FormLogin()
        {       
            InitializeComponent();
        }
        private void FormSignIn_Load(object sender, EventArgs e)
        {
            clientData = new ClientData();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            SignIn();
        }
        public void SignIn()
        {

            buttonSignIn.Enabled = false;
            //
            //帳號密碼驗證
            //
            if (textBoxUserName.Text == "")
            {
                MessageBox.Show("請輸入使用者名稱");
                buttonSignIn.Enabled = true;
                return;
            }
            else if (textBoxUserName.Text.IndexOf(" ") > -1)
            {
                MessageBox.Show("請輸入有效的字元");
                buttonSignIn.Enabled = true;
                return;
            }
            //將姓名寫入資料庫
            clientData.Name = textBoxUserName.Text;
            string result = FireBase.SetData(clientData, checkBoxAnonymous.Checked);
            if (result == "Error")
            {
                MessageBox.Show("與伺服器連結失敗");
                buttonSignIn.Enabled = true;
                return;
            }
            //轉換視窗
            FormChatClient f = new FormChatClient();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("登入成功");
            this.Close();

        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBoxAnonymous_CheckedChanged(object sender, EventArgs e)
        {//這個順序很重要，順序錯會影響到textChanged
            if (checkBoxAnonymous.Checked)
            {
                textBoxUserName.ForeColor = Color.Black;
                textBoxUserName.Text = "Anonymous";
                textBoxUserName.ReadOnly = true;
            }
            else
            {
                textBoxUserName.ReadOnly = false;
                textBoxUserName.Text = "使用者名稱";
                textBoxUserName.ForeColor = Color.Silver;
            }
        }
        #region 浮水印製作
        private void textBoxUserName_Enter(object sender, EventArgs e)
        {//  當要點擊文字框時，浮水印還在，則清空浮水印
            if (textBoxUserName.ForeColor == Color.Silver)
            {
                textBoxUserName.ForeColor = Color.Black;
                textBoxUserName.Text = "";
            }
        }

        private void textBoxUserName_Leave(object sender, EventArgs e)
        {//當使用者名稱為空白，再次浮現浮水印
            if (textBoxUserName.Text == "" && textBoxUserName.ForeColor == Color.Black)
            {
                textBoxUserName.Text = "使用者名稱";
                textBoxUserName.ForeColor = Color.Silver;
            }
        }
        #endregion

        private void textBoxUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SignIn();
            }
            
        }
    }
}
