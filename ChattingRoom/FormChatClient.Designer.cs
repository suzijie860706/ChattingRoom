namespace ChattingRoom
{
    partial class FormChatClient
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChatClient));
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.richTextBoxBoard = new System.Windows.Forms.RichTextBox();
            this.panelButtom = new System.Windows.Forms.Panel();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.groupBoxChannel = new System.Windows.Forms.GroupBox();
            this.buttonAddChannel = new System.Windows.Forms.Button();
            this.listBoxChannel = new System.Windows.Forms.ListBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.labelUserName = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panelButtom.SuspendLayout();
            this.groupBoxChannel.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxMsg.ForeColor = System.Drawing.Color.Silver;
            this.textBoxMsg.Location = new System.Drawing.Point(55, 21);
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(534, 36);
            this.textBoxMsg.TabIndex = 2;
            this.textBoxMsg.Text = "傳訊息到聊天室";
            this.textBoxMsg.WordWrap = false;
            this.textBoxMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMsg_KeyPress);
            // 
            // richTextBoxBoard
            // 
            this.richTextBoxBoard.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBoxBoard.Location = new System.Drawing.Point(175, 0);
            this.richTextBoxBoard.Name = "richTextBoxBoard";
            this.richTextBoxBoard.ReadOnly = true;
            this.richTextBoxBoard.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxBoard.Size = new System.Drawing.Size(607, 388);
            this.richTextBoxBoard.TabIndex = 3;
            this.richTextBoxBoard.Text = "\n\n\n傳訊息到聊天室看看吧!\n這裡是{ }頻道";
            // 
            // panelButtom
            // 
            this.panelButtom.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelButtom.Controls.Add(this.buttonAddFile);
            this.panelButtom.Controls.Add(this.textBoxMsg);
            this.panelButtom.Location = new System.Drawing.Point(175, 388);
            this.panelButtom.Name = "panelButtom";
            this.panelButtom.Size = new System.Drawing.Size(607, 72);
            this.panelButtom.TabIndex = 5;
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonAddFile.Location = new System.Drawing.Point(15, 21);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(40, 36);
            this.buttonAddFile.TabIndex = 3;
            this.buttonAddFile.Text = "＋";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // groupBoxChannel
            // 
            this.groupBoxChannel.Controls.Add(this.buttonAddChannel);
            this.groupBoxChannel.Controls.Add(this.listBoxChannel);
            this.groupBoxChannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxChannel.Location = new System.Drawing.Point(8, 118);
            this.groupBoxChannel.Name = "groupBoxChannel";
            this.groupBoxChannel.Size = new System.Drawing.Size(154, 330);
            this.groupBoxChannel.TabIndex = 7;
            this.groupBoxChannel.TabStop = false;
            this.groupBoxChannel.Text = "聊天室頻道";
            // 
            // buttonAddChannel
            // 
            this.buttonAddChannel.Location = new System.Drawing.Point(125, 0);
            this.buttonAddChannel.Name = "buttonAddChannel";
            this.buttonAddChannel.Size = new System.Drawing.Size(27, 21);
            this.buttonAddChannel.TabIndex = 3;
            this.buttonAddChannel.Text = "+";
            this.buttonAddChannel.UseVisualStyleBackColor = true;
            this.buttonAddChannel.Click += new System.EventHandler(this.buttonAddChannel_Click);
            // 
            // listBoxChannel
            // 
            this.listBoxChannel.BackColor = System.Drawing.Color.PowderBlue;
            this.listBoxChannel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxChannel.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBoxChannel.ForeColor = System.Drawing.Color.Black;
            this.listBoxChannel.FormattingEnabled = true;
            this.listBoxChannel.ItemHeight = 21;
            this.listBoxChannel.Items.AddRange(new object[] {
            "頻道一"});
            this.listBoxChannel.Location = new System.Drawing.Point(7, 25);
            this.listBoxChannel.Name = "listBoxChannel";
            this.listBoxChannel.Size = new System.Drawing.Size(140, 273);
            this.listBoxChannel.TabIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.PowderBlue;
            this.panelLeft.Controls.Add(this.labelUserName);
            this.panelLeft.Controls.Add(this.pictureBoxIcon);
            this.panelLeft.Controls.Add(this.groupBoxChannel);
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(175, 460);
            this.panelLeft.TabIndex = 10;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelUserName.Location = new System.Drawing.Point(52, 69);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(74, 15);
            this.labelUserName.TabIndex = 9;
            this.labelUserName.Text = "UserName";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxIcon.Image = global::ChattingRoom.Properties.Resources._123;
            this.pictureBoxIcon.Location = new System.Drawing.Point(15, 60);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(31, 30);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIcon.TabIndex = 8;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.Click += new System.EventHandler(this.pictureBoxIcon_Click);
            // 
            // FormChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(782, 460);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelButtom);
            this.Controls.Add(this.richTextBoxBoard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChatClient";
            this.Text = "多人聊天室";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChatClient_FormClosing);
            this.Load += new System.EventHandler(this.FormChatClient_Load);
            this.panelButtom.ResumeLayout(false);
            this.panelButtom.PerformLayout();
            this.groupBoxChannel.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.RichTextBox richTextBoxBoard;
        private System.Windows.Forms.Panel panelButtom;
        private System.Windows.Forms.GroupBox groupBoxChannel;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.ListBox listBoxChannel;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Button buttonAddChannel;
    }
}

