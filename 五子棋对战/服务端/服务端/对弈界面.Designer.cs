namespace 五子棋管理系统
{
    partial class 对弈界面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_Start = new System.Windows.Forms.Button();
            this.pic_Chess = new System.Windows.Forms.PictureBox();
            this.lbl_Caixian = new System.Windows.Forms.Label();
            this.btn_Caixian = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_time2 = new System.Windows.Forms.Label();
            this.lbl_time3 = new System.Windows.Forms.Label();
            this.lbl_time4 = new System.Windows.Forms.Label();
            this.lbl_time1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textIP = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.btnClient = new System.Windows.Forms.Button();
            this.labeltest = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Chess)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Start.Location = new System.Drawing.Point(12, 575);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(125, 35);
            this.btn_Start.TabIndex = 4;
            this.btn_Start.Text = "开始游戏";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // pic_Chess
            // 
            this.pic_Chess.Location = new System.Drawing.Point(12, 12);
            this.pic_Chess.Name = "pic_Chess";
            this.pic_Chess.Size = new System.Drawing.Size(500, 500);
            this.pic_Chess.TabIndex = 3;
            this.pic_Chess.TabStop = false;
            this.pic_Chess.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_Chess_MouseDown);
            // 
            // lbl_Caixian
            // 
            this.lbl_Caixian.AutoSize = true;
            this.lbl_Caixian.Font = new System.Drawing.Font("幼圆", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Caixian.Location = new System.Drawing.Point(597, 105);
            this.lbl_Caixian.Name = "lbl_Caixian";
            this.lbl_Caixian.Size = new System.Drawing.Size(75, 29);
            this.lbl_Caixian.TabIndex = 17;
            this.lbl_Caixian.Text = "猜先";
            // 
            // btn_Caixian
            // 
            this.btn_Caixian.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Caixian.Location = new System.Drawing.Point(569, 157);
            this.btn_Caixian.Name = "btn_Caixian";
            this.btn_Caixian.Size = new System.Drawing.Size(125, 35);
            this.btn_Caixian.TabIndex = 16;
            this.btn_Caixian.Text = "准备";
            this.btn_Caixian.UseVisualStyleBackColor = true;
            this.btn_Caixian.Click += new System.EventHandler(this.btn_Caixian_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(538, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "时间：";
            // 
            // lbl_time2
            // 
            this.lbl_time2.AutoSize = true;
            this.lbl_time2.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_time2.Location = new System.Drawing.Point(649, 37);
            this.lbl_time2.Name = "lbl_time2";
            this.lbl_time2.Size = new System.Drawing.Size(23, 24);
            this.lbl_time2.TabIndex = 13;
            this.lbl_time2.Text = "0";
            // 
            // lbl_time3
            // 
            this.lbl_time3.AutoSize = true;
            this.lbl_time3.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_time3.Location = new System.Drawing.Point(682, 37);
            this.lbl_time3.Name = "lbl_time3";
            this.lbl_time3.Size = new System.Drawing.Size(23, 24);
            this.lbl_time3.TabIndex = 12;
            this.lbl_time3.Text = "0";
            // 
            // lbl_time4
            // 
            this.lbl_time4.AutoSize = true;
            this.lbl_time4.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_time4.Location = new System.Drawing.Point(701, 37);
            this.lbl_time4.Name = "lbl_time4";
            this.lbl_time4.Size = new System.Drawing.Size(23, 24);
            this.lbl_time4.TabIndex = 11;
            this.lbl_time4.Text = "0";
            // 
            // lbl_time1
            // 
            this.lbl_time1.AutoSize = true;
            this.lbl_time1.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_time1.Location = new System.Drawing.Point(629, 37);
            this.lbl_time1.Name = "lbl_time1";
            this.lbl_time1.Size = new System.Drawing.Size(23, 24);
            this.lbl_time1.TabIndex = 10;
            this.lbl_time1.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(666, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = ":";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(527, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 216);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(587, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "IP地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(587, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "端口号";
            // 
            // textIP
            // 
            this.textIP.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textIP.Location = new System.Drawing.Point(542, 414);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(174, 25);
            this.textIP.TabIndex = 23;
            this.textIP.Text = "0.0.0.0";
            // 
            // textPort
            // 
            this.textPort.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPort.Location = new System.Drawing.Point(542, 506);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(174, 25);
            this.textPort.TabIndex = 24;
            this.textPort.Text = "8080";
            // 
            // btnClient
            // 
            this.btnClient.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClient.Location = new System.Drawing.Point(569, 560);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(125, 35);
            this.btnClient.TabIndex = 25;
            this.btnClient.Text = "开始监听";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // labeltest
            // 
            this.labeltest.AutoSize = true;
            this.labeltest.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labeltest.Location = new System.Drawing.Point(177, 578);
            this.labeltest.Name = "labeltest";
            this.labeltest.Size = new System.Drawing.Size(192, 24);
            this.labeltest.TabIndex = 26;
            this.labeltest.Text = "no connection!";
            // 
            // 对弈界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 667);
            this.Controls.Add(this.labeltest);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Caixian);
            this.Controls.Add(this.btn_Caixian);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_time2);
            this.Controls.Add(this.lbl_time3);
            this.Controls.Add(this.lbl_time4);
            this.Controls.Add(this.lbl_time1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.pic_Chess);
            this.Controls.Add(this.groupBox1);
            this.Name = "对弈界面";
            this.Text = "主PC";
            this.Load += new System.EventHandler(this.对弈界面_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Chess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.PictureBox pic_Chess;
        private System.Windows.Forms.Label lbl_Caixian;
        private System.Windows.Forms.Button btn_Caixian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_time2;
        private System.Windows.Forms.Label lbl_time3;
        private System.Windows.Forms.Label lbl_time4;
        private System.Windows.Forms.Label lbl_time1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Label labeltest;
    }
}