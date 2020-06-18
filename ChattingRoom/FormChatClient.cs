using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
namespace ChattingRoom
{
    
    public partial class FormChatClient : Form
    {
        ChatClient Client ;
        strHandler MsgHandler;
        //會員資料
        ClientData clientData;
        //附件 圖片上傳
        FileStream fileStream;
        int i = 0;
        public FormChatClient()
        {
            InitializeComponent();
            MsgHandler = AddMsg;
        }
        //登入視窗關閉判斷
        private void FormChatClient_Load(object sender, EventArgs e)
        {
            //登入視窗先顯示
            FormLogin f = new FormLogin();
            f.ShowDialog();

            if (f.DialogResult == DialogResult.OK)
            {
                clientData = FormLogin.clientData;
                labelUserName.Text = FireBase.GetData(clientData);
            }
        }
        private void textBoxMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') SendMsg(textBoxMsg.Text);
        }
        private void SendMsg(string Msg)
        {
            try
            {
                if (Client == null)
                {
                    Client = ChatClient.Connect(ChatSetting.IP);
                    Client.newListener(MsgComeIn);
                    Client.CloseException(ExceptionServerExit);

                    richTextBoxBoard.SelectionColor = Color.Blue;
                    Client.Send($"歡迎　{FireBase.GetData(clientData)}　加入。");
                }
                if (textBoxMsg.Text.Length > 0)
                {
                    Client.Send(FireBase.GetData(clientData) + "：" + Msg);
                    textBoxMsg.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("無法連接伺服器端");
                return;
            }
        }
        private void MsgComeIn(string s)
        {
            this.Invoke(MsgHandler, new object[] { s });//安全地調用UI控制項外的執行緒
            // richTextBoxBoard.Invoke(MsgHandler, s); 較容易懂的寫法
        }
        private void AddMsg(string s)
        {
            richTextBoxBoard.AppendText("\n" + s);
         //   MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(s));
   //         pictureBoxIcon.Image = Image.FromStream(ms);
            richTextBoxBoard.ScrollToCaret();
        }
        private void FormChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {//當視窗關閉時，視作用戶離開聊天室
            ExitChatRoom();
        }
        public void ExitChatRoom()
        {
            if (Client != null)
            {
                if (Client.socket.Connected) Client.Send(FireBase.GetData(clientData) + " 已離開");
                Client.Dispose();
                Client.listenThread.Abort();
            }
        }
        public void ExceptionServerExit()
        {
            if (Client.socket != null) //當不是自己失去連線時
            {
                MessageBox.Show("與伺服器失去連線");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxIcon_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "請選擇圖片";
            openFileDialog.Filter = "影像檔案(*.bmp*.jpg*.jpeg*.gif*.ico)|*.bmp;*.jpg;*.jpeg;*.gif;*.ico";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxIcon.Load(openFileDialog.FileName);
            }
            
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            /*
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Title = "請選擇圖片";
            openFileDialog.Filter = "圖像檔(*.jpeg*.jpg*.png*.ico*.gif)|*.jepg;*.jpg;*.png;*.ico;*.gif";
            //"All Files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                fileStream = new FileStream(openFileDialog.FileName,FileMode.OpenOrCreate,FileAccess.ReadWrite);
                BinaryReader br = new BinaryReader(fileStream);
                int dl = (int)fileStream.Length;
                Byte[] picture = br.ReadBytes(dl);
                SendPic(picture);

//                MemoryStream ms = new MemoryStream(picture);
                
                //Bitmap bmp = new Bitmap(fs);
   //             pictureBoxIcon.Image = Image.FromStream(ms);
                /*Clipboard.SetDataObject(Image.FromFile(openFileDialog.FileName));
                IDataObject iData = Clipboard.GetDataObject();

                // DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
                richTextBoxBoard.ReadOnly = false;
                richTextBoxBoard.Text += Environment.NewLine;
                richTextBoxBoard.SelectionStart = richTextBoxBoard.Text.Length;
                richTextBoxBoard.Paste();
                richTextBoxBoard.ReadOnly = true;
                */

        }

        private void buttonAddChannel_Click(object sender, EventArgs e)
        {

        }
    }
}
    
