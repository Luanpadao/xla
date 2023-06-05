namespace comPLC
{
    partial class IPSHala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPSHala));
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_devices = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_man = new System.Windows.Forms.Button();
            this.btn_auto = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_readPLC = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_qr = new System.Windows.Forms.TextBox();
            this.btn_scan = new System.Windows.Forms.Button();
            this.btn_oncam = new System.Windows.Forms.Button();
            this.tm_scan = new System.Windows.Forms.Timer(this.components);
            this.tm_write = new System.Windows.Forms.Timer(this.components);
            this.tm_readdata = new System.Windows.Forms.Timer(this.components);
            this.lb_now = new System.Windows.Forms.Label();
            this.tm_now = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btn_gray = new System.Windows.Forms.Button();
            this.tm_init = new System.Windows.Forms.Timer(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.trbar_threshold = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_threshold = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbar_threshold)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_ip
            // 
            this.txt_ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ip.Location = new System.Drawing.Point(86, 55);
            this.txt_ip.Multiline = true;
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(121, 23);
            this.txt_ip.TabIndex = 0;
            this.txt_ip.Text = "192.168.0.1";
            this.txt_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_check
            // 
            this.btn_check.Font = new System.Drawing.Font(".VnArial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_check.ForeColor = System.Drawing.Color.Black;
            this.btn_check.Location = new System.Drawing.Point(213, 55);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(96, 23);
            this.btn_check.TabIndex = 1;
            this.btn_check.Text = "Connect to PLC";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font(".VnArial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(91, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(493, 45);
            this.label1.TabIndex = 6;
            this.label1.Text = "PRODUCT CLASSIFICATION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Cyan;
            this.groupBox1.Controls.Add(this.cbb_devices);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_check);
            this.groupBox1.Controls.Add(this.txt_ip);
            this.groupBox1.Font = new System.Drawing.Font(".VnArial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(5, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 91);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SETTING:";
            // 
            // cbb_devices
            // 
            this.cbb_devices.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_devices.FormattingEnabled = true;
            this.cbb_devices.Location = new System.Drawing.Point(86, 26);
            this.cbb_devices.Name = "cbb_devices";
            this.cbb_devices.Size = new System.Drawing.Size(223, 23);
            this.cbb_devices.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font(".VnArial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(22, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Camera:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font(".VnArial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter IP:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Cyan;
            this.groupBox2.Controls.Add(this.btn_stop);
            this.groupBox2.Controls.Add(this.btn_man);
            this.groupBox2.Controls.Add(this.btn_auto);
            this.groupBox2.Font = new System.Drawing.Font(".VnArial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(333, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 91);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONTROL:";
            // 
            // btn_stop
            // 
            this.btn_stop.Font = new System.Drawing.Font(".VnArial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.ForeColor = System.Drawing.Color.Black;
            this.btn_stop.Location = new System.Drawing.Point(198, 37);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(65, 28);
            this.btn_stop.TabIndex = 2;
            this.btn_stop.Text = "STOP";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_man
            // 
            this.btn_man.Font = new System.Drawing.Font(".VnArial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_man.ForeColor = System.Drawing.Color.Black;
            this.btn_man.Location = new System.Drawing.Point(115, 37);
            this.btn_man.Name = "btn_man";
            this.btn_man.Size = new System.Drawing.Size(77, 28);
            this.btn_man.TabIndex = 1;
            this.btn_man.Text = "MANUAL";
            this.btn_man.UseVisualStyleBackColor = true;
            this.btn_man.Click += new System.EventHandler(this.btn_man_Click);
            // 
            // btn_auto
            // 
            this.btn_auto.Font = new System.Drawing.Font(".VnArial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_auto.ForeColor = System.Drawing.Color.Black;
            this.btn_auto.Location = new System.Drawing.Point(45, 37);
            this.btn_auto.Name = "btn_auto";
            this.btn_auto.Size = new System.Drawing.Size(64, 28);
            this.btn_auto.TabIndex = 0;
            this.btn_auto.Text = "AUTO";
            this.btn_auto.UseVisualStyleBackColor = true;
            this.btn_auto.Click += new System.EventHandler(this.btn_auto_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Cyan;
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tb_readPLC);
            this.groupBox3.Controls.Add(this.btn_send);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tb_qr);
            this.groupBox3.Font = new System.Drawing.Font(".VnArial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(5, 392);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(630, 109);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "COMMUNICATION:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font(".VnArial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(366, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Read from PLC:";
            // 
            // tb_readPLC
            // 
            this.tb_readPLC.Font = new System.Drawing.Font(".VnArial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_readPLC.Location = new System.Drawing.Point(369, 46);
            this.tb_readPLC.Multiline = true;
            this.tb_readPLC.Name = "tb_readPLC";
            this.tb_readPLC.Size = new System.Drawing.Size(244, 22);
            this.tb_readPLC.TabIndex = 12;
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font(".VnArial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.ForeColor = System.Drawing.Color.Black;
            this.btn_send.Location = new System.Drawing.Point(11, 74);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(182, 23);
            this.btn_send.TabIndex = 11;
            this.btn_send.Text = "Send to PLC Siemens S7 - 1200";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font(".VnArial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "QR code data:";
            // 
            // tb_qr
            // 
            this.tb_qr.Font = new System.Drawing.Font(".VnArial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_qr.Location = new System.Drawing.Point(12, 46);
            this.tb_qr.Multiline = true;
            this.tb_qr.Name = "tb_qr";
            this.tb_qr.Size = new System.Drawing.Size(234, 22);
            this.tb_qr.TabIndex = 0;
            // 
            // btn_scan
            // 
            this.btn_scan.Font = new System.Drawing.Font(".VnArial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_scan.ForeColor = System.Drawing.Color.Black;
            this.btn_scan.Location = new System.Drawing.Point(395, 343);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(81, 33);
            this.btn_scan.TabIndex = 11;
            this.btn_scan.Text = "SCAN";
            this.btn_scan.UseVisualStyleBackColor = true;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // btn_oncam
            // 
            this.btn_oncam.Font = new System.Drawing.Font(".VnArial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_oncam.ForeColor = System.Drawing.Color.Black;
            this.btn_oncam.Location = new System.Drawing.Point(395, 305);
            this.btn_oncam.Name = "btn_oncam";
            this.btn_oncam.Size = new System.Drawing.Size(81, 33);
            this.btn_oncam.TabIndex = 12;
            this.btn_oncam.Text = "TURN ON";
            this.btn_oncam.UseVisualStyleBackColor = true;
            this.btn_oncam.Click += new System.EventHandler(this.btn_oncam_Click);
            // 
            // tm_scan
            // 
            this.tm_scan.Tick += new System.EventHandler(this.tm_scan_Tick);
            // 
            // tm_write
            // 
            this.tm_write.Tick += new System.EventHandler(this.tm_write_Tick);
            // 
            // tm_readdata
            // 
            this.tm_readdata.Interval = 330;
            this.tm_readdata.Tick += new System.EventHandler(this.tm_readdata_Tick);
            // 
            // lb_now
            // 
            this.lb_now.AutoSize = true;
            this.lb_now.Font = new System.Drawing.Font(".VnArial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_now.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lb_now.Location = new System.Drawing.Point(498, 505);
            this.lb_now.Name = "lb_now";
            this.lb_now.Size = new System.Drawing.Size(120, 17);
            this.lb_now.TabIndex = 14;
            this.lb_now.Text = "##/##/#### ##:##";
            this.lb_now.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tm_now
            // 
            this.tm_now.Interval = 500;
            this.tm_now.Tick += new System.EventHandler(this.tm_now_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font(".VnArial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(2, 505);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(277, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Automated Storage and Retrieval System";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_gray
            // 
            this.btn_gray.Location = new System.Drawing.Point(658, 90);
            this.btn_gray.Name = "btn_gray";
            this.btn_gray.Size = new System.Drawing.Size(55, 29);
            this.btn_gray.TabIndex = 19;
            this.btn_gray.Text = "Chance";
            this.btn_gray.UseVisualStyleBackColor = true;
            this.btn_gray.Visible = false;
            this.btn_gray.Click += new System.EventHandler(this.btn_gray_Click);
            // 
            // tm_init
            // 
            this.tm_init.Tick += new System.EventHandler(this.tm_init_Tick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(395, 161);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(240, 137);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::comPLC.Properties.Resources.Logo_IUH__1_;
            this.pictureBox3.Location = new System.Drawing.Point(5, 13);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(80, 45);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::comPLC.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(590, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(5, 161);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font(".VnArial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(395, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Filter";
            // 
            // trbar_threshold
            // 
            this.trbar_threshold.Location = new System.Drawing.Point(482, 304);
            this.trbar_threshold.Maximum = 255;
            this.trbar_threshold.Name = "trbar_threshold";
            this.trbar_threshold.Size = new System.Drawing.Size(153, 45);
            this.trbar_threshold.TabIndex = 21;
            this.trbar_threshold.Value = 150;
            this.trbar_threshold.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font(".VnArial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(498, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Threshold:";
            // 
            // tb_threshold
            // 
            this.tb_threshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_threshold.Location = new System.Drawing.Point(573, 335);
            this.tb_threshold.Multiline = true;
            this.tb_threshold.Name = "tb_threshold";
            this.tb_threshold.Size = new System.Drawing.Size(45, 23);
            this.tb_threshold.TabIndex = 22;
            this.tb_threshold.Text = "###";
            this.tb_threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_threshold.TextChanged += new System.EventHandler(this.tb_threshold_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(521, 364);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 19);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "Sensor ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // IPSHala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(639, 525);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_threshold);
            this.Controls.Add(this.trbar_threshold);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_scan);
            this.Controls.Add(this.btn_gray);
            this.Controls.Add(this.btn_oncam);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_now);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IPSHala";
            this.Text = "IPSHala";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IPSHala_FormClosed);
            this.Load += new System.EventHandler(this.IPSHala_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbar_threshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_devices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_readPLC;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_qr;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_man;
        private System.Windows.Forms.Button btn_auto;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.Button btn_oncam;
        private System.Windows.Forms.Timer tm_scan;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer tm_write;
        private System.Windows.Forms.Timer tm_readdata;
        private System.Windows.Forms.Label lb_now;
        private System.Windows.Forms.Timer tm_now;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btn_gray;
        private System.Windows.Forms.Timer tm_init;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trbar_threshold;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_threshold;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

