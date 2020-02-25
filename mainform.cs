using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using SecuGen.FDxSDKPro.Windows;
using Matching_cs;

namespace sgdm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>

      private SGFingerPrintManager m_FPM;

      private bool m_LedOn = false;
      private Int32 m_ImageWidth;
      private Int32 m_ImageHeight;
      private Byte[] m_RegMin1;
      private Byte[] m_RegMin2;
      private Byte[] m_VrfMin;
      private SGFPMDeviceList[] m_DevList; // Used for EnumerateDevice

      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage tabPage1;
      private System.Windows.Forms.TabPage tabPage2;
      private System.Windows.Forms.TabPage tabPage3;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox comboBoxDeviceName;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Button BtnCapture1;
      private System.Windows.Forms.Button BtnCapture2;
      private System.Windows.Forms.Button BtnCapture3;
      private System.Windows.Forms.PictureBox pictureBoxR2;
      private System.Windows.Forms.PictureBox pictureBoxV1;
      private System.Windows.Forms.PictureBox pictureBoxR1;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.TextBox textBrightness;
      private System.Windows.Forms.TextBox textGain;
      private System.Windows.Forms.TextBox textContrast;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.Button ConfigBtn;
      private System.Windows.Forms.TextBox textImgQuality;
      private System.Windows.Forms.ComboBox comboBox1;
      private System.Windows.Forms.GroupBox groupBox6;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.ComboBox comboBoxSecuLevel_V;
      private System.Windows.Forms.ComboBox comboBoxSecuLevel_R;
      private System.Windows.Forms.Button GetBtn;
      private System.Windows.Forms.TextBox textDeviceID;
      private System.Windows.Forms.TextBox textSerialNum;
      private System.Windows.Forms.TextBox textImageWidth;
      private System.Windows.Forms.TextBox textImageHeight;
      private System.Windows.Forms.TextBox textImageDPI;
      private System.Windows.Forms.ProgressBar progressBar_R1;
      private System.Windows.Forms.ProgressBar progressBar_R2;
      private System.Windows.Forms.ProgressBar progressBar_V1;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.TextBox textTimeout;
      private System.Windows.Forms.Button BtnRegister;
      private System.Windows.Forms.Button BtnVerify;
      internal System.Windows.Forms.GroupBox GroupBox8;
      internal System.Windows.Forms.Button SetBrightnessBtn;
      private System.Windows.Forms.TextBox textFWVersion;
      private System.Windows.Forms.Button GetLiveImageBtn;
      private System.Windows.Forms.Button GetImageBtn;
      internal System.Windows.Forms.NumericUpDown BrightnessUpDown;
      private System.Windows.Forms.CheckBox CheckBoxAutoOn;
      private System.Windows.Forms.Button EnumerateBtn;
      private System.Windows.Forms.Button OpenDeviceBtn;
      private System.Windows.Forms.Label StatusBar;
      

      public MainForm()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if (components != null) 
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
		  this.tabControl1 = new System.Windows.Forms.TabControl();
		  this.tabPage2 = new System.Windows.Forms.TabPage();
		  this.CheckBoxAutoOn = new System.Windows.Forms.CheckBox();
		  this.GroupBox8 = new System.Windows.Forms.GroupBox();
		  this.BrightnessUpDown = new System.Windows.Forms.NumericUpDown();
		  this.SetBrightnessBtn = new System.Windows.Forms.Button();
		  this.ConfigBtn = new System.Windows.Forms.Button();
		  this.groupBox4 = new System.Windows.Forms.GroupBox();
		  this.textTimeout = new System.Windows.Forms.TextBox();
		  this.label16 = new System.Windows.Forms.Label();
		  this.label15 = new System.Windows.Forms.Label();
		  this.textImgQuality = new System.Windows.Forms.TextBox();
		  this.GetLiveImageBtn = new System.Windows.Forms.Button();
		  this.GetImageBtn = new System.Windows.Forms.Button();
		  this.pictureBox1 = new System.Windows.Forms.PictureBox();
		  this.tabPage3 = new System.Windows.Forms.TabPage();
		  this.BtnVerify = new System.Windows.Forms.Button();
		  this.BtnRegister = new System.Windows.Forms.Button();
		  this.groupBox6 = new System.Windows.Forms.GroupBox();
		  this.comboBoxSecuLevel_V = new System.Windows.Forms.ComboBox();
		  this.label14 = new System.Windows.Forms.Label();
		  this.label4 = new System.Windows.Forms.Label();
		  this.comboBoxSecuLevel_R = new System.Windows.Forms.ComboBox();
		  this.groupBox2 = new System.Windows.Forms.GroupBox();
		  this.progressBar_V1 = new System.Windows.Forms.ProgressBar();
		  this.pictureBoxV1 = new System.Windows.Forms.PictureBox();
		  this.BtnCapture3 = new System.Windows.Forms.Button();
		  this.comboBox1 = new System.Windows.Forms.ComboBox();
		  this.groupBox1 = new System.Windows.Forms.GroupBox();
		  this.progressBar_R2 = new System.Windows.Forms.ProgressBar();
		  this.progressBar_R1 = new System.Windows.Forms.ProgressBar();
		  this.pictureBoxR2 = new System.Windows.Forms.PictureBox();
		  this.pictureBoxR1 = new System.Windows.Forms.PictureBox();
		  this.BtnCapture1 = new System.Windows.Forms.Button();
		  this.BtnCapture2 = new System.Windows.Forms.Button();
		  this.tabPage1 = new System.Windows.Forms.TabPage();
		  this.GetBtn = new System.Windows.Forms.Button();
		  this.groupBox3 = new System.Windows.Forms.GroupBox();
		  this.textImageDPI = new System.Windows.Forms.TextBox();
		  this.textImageHeight = new System.Windows.Forms.TextBox();
		  this.textImageWidth = new System.Windows.Forms.TextBox();
		  this.textSerialNum = new System.Windows.Forms.TextBox();
		  this.textFWVersion = new System.Windows.Forms.TextBox();
		  this.textDeviceID = new System.Windows.Forms.TextBox();
		  this.textBrightness = new System.Windows.Forms.TextBox();
		  this.textGain = new System.Windows.Forms.TextBox();
		  this.textContrast = new System.Windows.Forms.TextBox();
		  this.label12 = new System.Windows.Forms.Label();
		  this.label11 = new System.Windows.Forms.Label();
		  this.label10 = new System.Windows.Forms.Label();
		  this.label9 = new System.Windows.Forms.Label();
		  this.label8 = new System.Windows.Forms.Label();
		  this.label7 = new System.Windows.Forms.Label();
		  this.label6 = new System.Windows.Forms.Label();
		  this.label5 = new System.Windows.Forms.Label();
		  this.label13 = new System.Windows.Forms.Label();
		  this.comboBoxDeviceName = new System.Windows.Forms.ComboBox();
		  this.label1 = new System.Windows.Forms.Label();
		  this.StatusBar = new System.Windows.Forms.Label();
		  this.EnumerateBtn = new System.Windows.Forms.Button();
		  this.OpenDeviceBtn = new System.Windows.Forms.Button();
		  this.tabControl1.SuspendLayout();
		  this.tabPage2.SuspendLayout();
		  this.GroupBox8.SuspendLayout();
		  ((System.ComponentModel.ISupportInitialize)(this.BrightnessUpDown)).BeginInit();
		  this.groupBox4.SuspendLayout();
		  this.tabPage3.SuspendLayout();
		  this.groupBox6.SuspendLayout();
		  this.groupBox2.SuspendLayout();
		  this.groupBox1.SuspendLayout();
		  this.tabPage1.SuspendLayout();
		  this.groupBox3.SuspendLayout();
		  this.SuspendLayout();
		  // 
		  // tabControl1
		  // 
		  this.tabControl1.Controls.Add(this.tabPage2);
		  this.tabControl1.Controls.Add(this.tabPage3);
		  this.tabControl1.Controls.Add(this.tabPage1);
		  this.tabControl1.Location = new System.Drawing.Point(0, 40);
		  this.tabControl1.Name = "tabControl1";
		  this.tabControl1.SelectedIndex = 0;
		  this.tabControl1.Size = new System.Drawing.Size(416, 404);
		  this.tabControl1.TabIndex = 0;
		  // 
		  // tabPage2
		  // 
		  this.tabPage2.Controls.Add(this.CheckBoxAutoOn);
		  this.tabPage2.Controls.Add(this.GroupBox8);
		  this.tabPage2.Controls.Add(this.ConfigBtn);
		  this.tabPage2.Controls.Add(this.groupBox4);
		  this.tabPage2.Controls.Add(this.GetLiveImageBtn);
		  this.tabPage2.Controls.Add(this.GetImageBtn);
		  this.tabPage2.Controls.Add(this.pictureBox1);
		  this.tabPage2.Location = new System.Drawing.Point(4, 22);
		  this.tabPage2.Name = "tabPage2";
		  this.tabPage2.Size = new System.Drawing.Size(408, 378);
		  this.tabPage2.TabIndex = 1;
		  this.tabPage2.Text = "  Image  ";
		  // 
		  // CheckBoxAutoOn
		  // 
		  this.CheckBoxAutoOn.Enabled = false;
		  this.CheckBoxAutoOn.Location = new System.Drawing.Point(12, 356);
		  this.CheckBoxAutoOn.Name = "CheckBoxAutoOn";
		  this.CheckBoxAutoOn.Size = new System.Drawing.Size(248, 16);
		  this.CheckBoxAutoOn.TabIndex = 19;
		  this.CheckBoxAutoOn.Text = "Enable AutoOn Event (FDU03, FDU04)";
		  this.CheckBoxAutoOn.CheckedChanged += new System.EventHandler(this.CheckBoxAutoOn_CheckedChanged);
		  // 
		  // GroupBox8
		  // 
		  this.GroupBox8.Controls.Add(this.BrightnessUpDown);
		  this.GroupBox8.Controls.Add(this.SetBrightnessBtn);
		  this.GroupBox8.Location = new System.Drawing.Point(280, 200);
		  this.GroupBox8.Name = "GroupBox8";
		  this.GroupBox8.Size = new System.Drawing.Size(120, 148);
		  this.GroupBox8.TabIndex = 18;
		  this.GroupBox8.TabStop = false;
		  this.GroupBox8.Text = "Brightness";
		  // 
		  // BrightnessUpDown
		  // 
		  this.BrightnessUpDown.Increment = new System.Decimal(new int[] {
																			 10,
																			 0,
																			 0,
																			 0});
		  this.BrightnessUpDown.Location = new System.Drawing.Point(8, 24);
		  this.BrightnessUpDown.Name = "BrightnessUpDown";
		  this.BrightnessUpDown.Size = new System.Drawing.Size(44, 20);
		  this.BrightnessUpDown.TabIndex = 20;
		  this.BrightnessUpDown.Value = new System.Decimal(new int[] {
																		 70,
																		 0,
																		 0,
																		 0});
		  // 
		  // SetBrightnessBtn
		  // 
		  this.SetBrightnessBtn.Location = new System.Drawing.Point(56, 24);
		  this.SetBrightnessBtn.Name = "SetBrightnessBtn";
		  this.SetBrightnessBtn.Size = new System.Drawing.Size(56, 20);
		  this.SetBrightnessBtn.TabIndex = 19;
		  this.SetBrightnessBtn.Text = "Apply";
		  this.SetBrightnessBtn.Click += new System.EventHandler(this.SetBrightnessBtn_Click);
		  // 
		  // ConfigBtn
		  // 
		  this.ConfigBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
		  this.ConfigBtn.Location = new System.Drawing.Point(324, 12);
		  this.ConfigBtn.Name = "ConfigBtn";
		  this.ConfigBtn.Size = new System.Drawing.Size(76, 24);
		  this.ConfigBtn.TabIndex = 12;
		  this.ConfigBtn.Text = "Config...";
		  this.ConfigBtn.Click += new System.EventHandler(this.ConfigBtn_Click);
		  // 
		  // groupBox4
		  // 
		  this.groupBox4.Controls.Add(this.textTimeout);
		  this.groupBox4.Controls.Add(this.label16);
		  this.groupBox4.Controls.Add(this.label15);
		  this.groupBox4.Controls.Add(this.textImgQuality);
		  this.groupBox4.Location = new System.Drawing.Point(280, 52);
		  this.groupBox4.Name = "groupBox4";
		  this.groupBox4.Size = new System.Drawing.Size(120, 140);
		  this.groupBox4.TabIndex = 11;
		  this.groupBox4.TabStop = false;
		  this.groupBox4.Text = "LiveCapture";
		  // 
		  // textTimeout
		  // 
		  this.textTimeout.Location = new System.Drawing.Point(8, 80);
		  this.textTimeout.Name = "textTimeout";
		  this.textTimeout.Size = new System.Drawing.Size(88, 20);
		  this.textTimeout.TabIndex = 18;
		  this.textTimeout.Text = "10000";
		  // 
		  // label16
		  // 
		  this.label16.Location = new System.Drawing.Point(8, 64);
		  this.label16.Name = "label16";
		  this.label16.Size = new System.Drawing.Size(96, 24);
		  this.label16.TabIndex = 17;
		  this.label16.Text = "Capture Timeout";
		  // 
		  // label15
		  // 
		  this.label15.Location = new System.Drawing.Point(8, 20);
		  this.label15.Name = "label15";
		  this.label15.Size = new System.Drawing.Size(96, 16);
		  this.label15.TabIndex = 16;
		  this.label15.Text = "Image Quality:";
		  // 
		  // textImgQuality
		  // 
		  this.textImgQuality.Location = new System.Drawing.Point(8, 36);
		  this.textImgQuality.MaxLength = 3;
		  this.textImgQuality.Name = "textImgQuality";
		  this.textImgQuality.Size = new System.Drawing.Size(88, 20);
		  this.textImgQuality.TabIndex = 15;
		  this.textImgQuality.Text = "50";
		  // 
		  // GetLiveImageBtn
		  // 
		  this.GetLiveImageBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
		  this.GetLiveImageBtn.Location = new System.Drawing.Point(100, 12);
		  this.GetLiveImageBtn.Name = "GetLiveImageBtn";
		  this.GetLiveImageBtn.Size = new System.Drawing.Size(76, 24);
		  this.GetLiveImageBtn.TabIndex = 8;
		  this.GetLiveImageBtn.Text = "LiveCapture";
		  this.GetLiveImageBtn.Click += new System.EventHandler(this.GetLiveImageBtn_Click);
		  // 
		  // GetImageBtn
		  // 
		  this.GetImageBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
		  this.GetImageBtn.Location = new System.Drawing.Point(12, 12);
		  this.GetImageBtn.Name = "GetImageBtn";
		  this.GetImageBtn.Size = new System.Drawing.Size(76, 24);
		  this.GetImageBtn.TabIndex = 7;
		  this.GetImageBtn.Text = "Capture";
		  this.GetImageBtn.Click += new System.EventHandler(this.GetImageBtn_Click);
		  // 
		  // pictureBox1
		  // 
		  this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
		  this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		  this.pictureBox1.Location = new System.Drawing.Point(8, 48);
		  this.pictureBox1.Name = "pictureBox1";
		  this.pictureBox1.Size = new System.Drawing.Size(260, 300);
		  this.pictureBox1.TabIndex = 5;
		  this.pictureBox1.TabStop = false;
		  // 
		  // tabPage3
		  // 
		  this.tabPage3.Controls.Add(this.BtnVerify);
		  this.tabPage3.Controls.Add(this.BtnRegister);
		  this.tabPage3.Controls.Add(this.groupBox6);
		  this.tabPage3.Controls.Add(this.groupBox2);
		  this.tabPage3.Controls.Add(this.groupBox1);
		  this.tabPage3.Location = new System.Drawing.Point(4, 22);
		  this.tabPage3.Name = "tabPage3";
		  this.tabPage3.Size = new System.Drawing.Size(408, 378);
		  this.tabPage3.TabIndex = 2;
		  this.tabPage3.Text = "Register/Verify";
		  // 
		  // BtnVerify
		  // 
		  this.BtnVerify.BackColor = System.Drawing.SystemColors.Desktop;
		  this.BtnVerify.ForeColor = System.Drawing.SystemColors.HighlightText;
		  this.BtnVerify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  this.BtnVerify.Location = new System.Drawing.Point(280, 308);
		  this.BtnVerify.Name = "BtnVerify";
		  this.BtnVerify.Size = new System.Drawing.Size(108, 23);
		  this.BtnVerify.TabIndex = 34;
		  this.BtnVerify.Text = "Verify";
		  this.BtnVerify.Click += new System.EventHandler(this.BtnVerify_Click);
		  // 
		  // BtnRegister
		  // 
		  this.BtnRegister.BackColor = System.Drawing.SystemColors.Desktop;
		  this.BtnRegister.ForeColor = System.Drawing.SystemColors.HighlightText;
		  this.BtnRegister.Location = new System.Drawing.Point(52, 308);
		  this.BtnRegister.Name = "BtnRegister";
		  this.BtnRegister.Size = new System.Drawing.Size(132, 23);
		  this.BtnRegister.TabIndex = 33;
		  this.BtnRegister.Text = "Register";
		  this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
		  // 
		  // groupBox6
		  // 
		  this.groupBox6.Controls.Add(this.comboBoxSecuLevel_V);
		  this.groupBox6.Controls.Add(this.label14);
		  this.groupBox6.Controls.Add(this.label4);
		  this.groupBox6.Controls.Add(this.comboBoxSecuLevel_R);
		  this.groupBox6.Location = new System.Drawing.Point(8, 8);
		  this.groupBox6.Name = "groupBox6";
		  this.groupBox6.Size = new System.Drawing.Size(392, 56);
		  this.groupBox6.TabIndex = 30;
		  this.groupBox6.TabStop = false;
		  this.groupBox6.Text = "Security Level";
		  // 
		  // comboBoxSecuLevel_V
		  // 
		  this.comboBoxSecuLevel_V.Items.AddRange(new object[] {
																   "LOWEST",
																   "LOWER",
																   "LOW",
																   "BELOW_NORMAL",
																   "NORMAL",
																   "ABOVE_NORMAL",
																   "HIGH",
																   "HIGHER",
																   "HIGHEST"});
		  this.comboBoxSecuLevel_V.Location = new System.Drawing.Point(272, 24);
		  this.comboBoxSecuLevel_V.Name = "comboBoxSecuLevel_V";
		  this.comboBoxSecuLevel_V.Size = new System.Drawing.Size(112, 21);
		  this.comboBoxSecuLevel_V.TabIndex = 24;
		  this.comboBoxSecuLevel_V.Text = "NORMAL";
		  // 
		  // label14
		  // 
		  this.label14.Location = new System.Drawing.Point(208, 24);
		  this.label14.Name = "label14";
		  this.label14.Size = new System.Drawing.Size(64, 24);
		  this.label14.TabIndex = 23;
		  this.label14.Text = "Verification";
		  // 
		  // label4
		  // 
		  this.label4.Location = new System.Drawing.Point(8, 24);
		  this.label4.Name = "label4";
		  this.label4.Size = new System.Drawing.Size(72, 24);
		  this.label4.TabIndex = 22;
		  this.label4.Text = "Registration";
		  // 
		  // comboBoxSecuLevel_R
		  // 
		  this.comboBoxSecuLevel_R.Items.AddRange(new object[] {
																   "LOWEST",
																   "LOWER",
																   "LOW",
																   "BELOW_NORMAL",
																   "NORMAL",
																   "ABOVE_NORMAL",
																   "HIGH",
																   "HIGHER",
																   "HIGHEST"});
		  this.comboBoxSecuLevel_R.Location = new System.Drawing.Point(80, 24);
		  this.comboBoxSecuLevel_R.Name = "comboBoxSecuLevel_R";
		  this.comboBoxSecuLevel_R.Size = new System.Drawing.Size(112, 21);
		  this.comboBoxSecuLevel_R.TabIndex = 21;
		  this.comboBoxSecuLevel_R.Text = "NORMAL";
		  // 
		  // groupBox2
		  // 
		  this.groupBox2.Controls.Add(this.progressBar_V1);
		  this.groupBox2.Controls.Add(this.pictureBoxV1);
		  this.groupBox2.Controls.Add(this.BtnCapture3);
		  this.groupBox2.Controls.Add(this.comboBox1);
		  this.groupBox2.Location = new System.Drawing.Point(264, 76);
		  this.groupBox2.Name = "groupBox2";
		  this.groupBox2.Size = new System.Drawing.Size(136, 220);
		  this.groupBox2.TabIndex = 29;
		  this.groupBox2.TabStop = false;
		  this.groupBox2.Text = "Verification";
		  // 
		  // progressBar_V1
		  // 
		  this.progressBar_V1.Location = new System.Drawing.Point(16, 152);
		  this.progressBar_V1.Name = "progressBar_V1";
		  this.progressBar_V1.Size = new System.Drawing.Size(104, 12);
		  this.progressBar_V1.TabIndex = 31;
		  // 
		  // pictureBoxV1
		  // 
		  this.pictureBoxV1.BackColor = System.Drawing.SystemColors.Window;
		  this.pictureBoxV1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		  this.pictureBoxV1.Location = new System.Drawing.Point(16, 24);
		  this.pictureBoxV1.Name = "pictureBoxV1";
		  this.pictureBoxV1.Size = new System.Drawing.Size(104, 128);
		  this.pictureBoxV1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		  this.pictureBoxV1.TabIndex = 29;
		  this.pictureBoxV1.TabStop = false;
		  // 
		  // BtnCapture3
		  // 
		  this.BtnCapture3.BackColor = System.Drawing.SystemColors.ActiveBorder;
		  this.BtnCapture3.Location = new System.Drawing.Point(16, 176);
		  this.BtnCapture3.Name = "BtnCapture3";
		  this.BtnCapture3.Size = new System.Drawing.Size(104, 23);
		  this.BtnCapture3.TabIndex = 27;
		  this.BtnCapture3.Text = "Capture V1";
		  this.BtnCapture3.Click += new System.EventHandler(this.BtnCapture3_Click);
		  // 
		  // comboBox1
		  // 
		  this.comboBox1.Items.AddRange(new object[] {
														 "LOWEST",
														 "LOWER",
														 "LOW",
														 "BELOW_NORMAL",
														 "NORMAL",
														 "ABOVE_NORMAL",
														 "HIGH",
														 "HIGHER",
														 "HIGHEST"});
		  this.comboBox1.Location = new System.Drawing.Point(48, -40);
		  this.comboBox1.Name = "comboBox1";
		  this.comboBox1.Size = new System.Drawing.Size(88, 20);
		  this.comboBox1.TabIndex = 30;
		  this.comboBox1.Text = "NORMAL";
		  // 
		  // groupBox1
		  // 
		  this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
		  this.groupBox1.Controls.Add(this.progressBar_R2);
		  this.groupBox1.Controls.Add(this.progressBar_R1);
		  this.groupBox1.Controls.Add(this.pictureBoxR2);
		  this.groupBox1.Controls.Add(this.pictureBoxR1);
		  this.groupBox1.Controls.Add(this.BtnCapture1);
		  this.groupBox1.Controls.Add(this.BtnCapture2);
		  this.groupBox1.Location = new System.Drawing.Point(8, 76);
		  this.groupBox1.Name = "groupBox1";
		  this.groupBox1.Size = new System.Drawing.Size(244, 220);
		  this.groupBox1.TabIndex = 28;
		  this.groupBox1.TabStop = false;
		  this.groupBox1.Text = "Registration";
		  // 
		  // progressBar_R2
		  // 
		  this.progressBar_R2.Location = new System.Drawing.Point(128, 152);
		  this.progressBar_R2.Name = "progressBar_R2";
		  this.progressBar_R2.Size = new System.Drawing.Size(104, 12);
		  this.progressBar_R2.TabIndex = 29;
		  // 
		  // progressBar_R1
		  // 
		  this.progressBar_R1.Location = new System.Drawing.Point(8, 152);
		  this.progressBar_R1.Name = "progressBar_R1";
		  this.progressBar_R1.Size = new System.Drawing.Size(104, 12);
		  this.progressBar_R1.TabIndex = 28;
		  // 
		  // pictureBoxR2
		  // 
		  this.pictureBoxR2.BackColor = System.Drawing.SystemColors.Window;
		  this.pictureBoxR2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		  this.pictureBoxR2.Location = new System.Drawing.Point(128, 24);
		  this.pictureBoxR2.Name = "pictureBoxR2";
		  this.pictureBoxR2.Size = new System.Drawing.Size(104, 128);
		  this.pictureBoxR2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		  this.pictureBoxR2.TabIndex = 27;
		  this.pictureBoxR2.TabStop = false;
		  // 
		  // pictureBoxR1
		  // 
		  this.pictureBoxR1.BackColor = System.Drawing.SystemColors.Window;
		  this.pictureBoxR1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		  this.pictureBoxR1.Location = new System.Drawing.Point(8, 24);
		  this.pictureBoxR1.Name = "pictureBoxR1";
		  this.pictureBoxR1.Size = new System.Drawing.Size(104, 128);
		  this.pictureBoxR1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		  this.pictureBoxR1.TabIndex = 26;
		  this.pictureBoxR1.TabStop = false;
		  // 
		  // BtnCapture1
		  // 
		  this.BtnCapture1.BackColor = System.Drawing.SystemColors.ActiveBorder;
		  this.BtnCapture1.Location = new System.Drawing.Point(8, 176);
		  this.BtnCapture1.Name = "BtnCapture1";
		  this.BtnCapture1.Size = new System.Drawing.Size(104, 23);
		  this.BtnCapture1.TabIndex = 23;
		  this.BtnCapture1.Text = "Capture R1";
		  this.BtnCapture1.Click += new System.EventHandler(this.BtnCapture1_Click);
		  // 
		  // BtnCapture2
		  // 
		  this.BtnCapture2.BackColor = System.Drawing.SystemColors.ActiveBorder;
		  this.BtnCapture2.Location = new System.Drawing.Point(128, 176);
		  this.BtnCapture2.Name = "BtnCapture2";
		  this.BtnCapture2.Size = new System.Drawing.Size(104, 23);
		  this.BtnCapture2.TabIndex = 24;
		  this.BtnCapture2.Text = "Capture R2";
		  this.BtnCapture2.Click += new System.EventHandler(this.BtnCapture2_Click);
		  // 
		  // tabPage1
		  // 
		  this.tabPage1.Controls.Add(this.GetBtn);
		  this.tabPage1.Controls.Add(this.groupBox3);
		  this.tabPage1.Location = new System.Drawing.Point(4, 22);
		  this.tabPage1.Name = "tabPage1";
		  this.tabPage1.Size = new System.Drawing.Size(408, 378);
		  this.tabPage1.TabIndex = 0;
		  this.tabPage1.Text = "DeviceInfo";
		  // 
		  // GetBtn
		  // 
		  this.GetBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
		  this.GetBtn.Location = new System.Drawing.Point(288, 16);
		  this.GetBtn.Name = "GetBtn";
		  this.GetBtn.Size = new System.Drawing.Size(96, 24);
		  this.GetBtn.TabIndex = 43;
		  this.GetBtn.Text = "Get";
		  this.GetBtn.Click += new System.EventHandler(this.GetBtn_Click);
		  // 
		  // groupBox3
		  // 
		  this.groupBox3.Controls.Add(this.textImageDPI);
		  this.groupBox3.Controls.Add(this.textImageHeight);
		  this.groupBox3.Controls.Add(this.textImageWidth);
		  this.groupBox3.Controls.Add(this.textSerialNum);
		  this.groupBox3.Controls.Add(this.textFWVersion);
		  this.groupBox3.Controls.Add(this.textDeviceID);
		  this.groupBox3.Controls.Add(this.textBrightness);
		  this.groupBox3.Controls.Add(this.textGain);
		  this.groupBox3.Controls.Add(this.textContrast);
		  this.groupBox3.Controls.Add(this.label12);
		  this.groupBox3.Controls.Add(this.label11);
		  this.groupBox3.Controls.Add(this.label10);
		  this.groupBox3.Controls.Add(this.label9);
		  this.groupBox3.Controls.Add(this.label8);
		  this.groupBox3.Controls.Add(this.label7);
		  this.groupBox3.Controls.Add(this.label6);
		  this.groupBox3.Controls.Add(this.label5);
		  this.groupBox3.Controls.Add(this.label13);
		  this.groupBox3.Location = new System.Drawing.Point(8, 8);
		  this.groupBox3.Name = "groupBox3";
		  this.groupBox3.Size = new System.Drawing.Size(264, 248);
		  this.groupBox3.TabIndex = 41;
		  this.groupBox3.TabStop = false;
		  this.groupBox3.Text = "DeviceInfo";
		  // 
		  // textImageDPI
		  // 
		  this.textImageDPI.Enabled = false;
		  this.textImageDPI.Location = new System.Drawing.Point(96, 144);
		  this.textImageDPI.Name = "textImageDPI";
		  this.textImageDPI.Size = new System.Drawing.Size(152, 20);
		  this.textImageDPI.TabIndex = 66;
		  this.textImageDPI.Text = "";
		  // 
		  // textImageHeight
		  // 
		  this.textImageHeight.Enabled = false;
		  this.textImageHeight.Location = new System.Drawing.Point(96, 120);
		  this.textImageHeight.Name = "textImageHeight";
		  this.textImageHeight.Size = new System.Drawing.Size(152, 20);
		  this.textImageHeight.TabIndex = 65;
		  this.textImageHeight.Text = "";
		  // 
		  // textImageWidth
		  // 
		  this.textImageWidth.Enabled = false;
		  this.textImageWidth.Location = new System.Drawing.Point(96, 96);
		  this.textImageWidth.Name = "textImageWidth";
		  this.textImageWidth.Size = new System.Drawing.Size(152, 20);
		  this.textImageWidth.TabIndex = 64;
		  this.textImageWidth.Text = "";
		  // 
		  // textSerialNum
		  // 
		  this.textSerialNum.Enabled = false;
		  this.textSerialNum.Location = new System.Drawing.Point(96, 72);
		  this.textSerialNum.Name = "textSerialNum";
		  this.textSerialNum.Size = new System.Drawing.Size(152, 20);
		  this.textSerialNum.TabIndex = 63;
		  this.textSerialNum.Text = "";
		  // 
		  // textFWVersion
		  // 
		  this.textFWVersion.Enabled = false;
		  this.textFWVersion.Location = new System.Drawing.Point(96, 48);
		  this.textFWVersion.Name = "textFWVersion";
		  this.textFWVersion.Size = new System.Drawing.Size(152, 20);
		  this.textFWVersion.TabIndex = 62;
		  this.textFWVersion.Text = "";
		  // 
		  // textDeviceID
		  // 
		  this.textDeviceID.Enabled = false;
		  this.textDeviceID.Location = new System.Drawing.Point(96, 24);
		  this.textDeviceID.Name = "textDeviceID";
		  this.textDeviceID.Size = new System.Drawing.Size(152, 20);
		  this.textDeviceID.TabIndex = 61;
		  this.textDeviceID.Text = "";
		  // 
		  // textBrightness
		  // 
		  this.textBrightness.Enabled = false;
		  this.textBrightness.Location = new System.Drawing.Point(96, 168);
		  this.textBrightness.Name = "textBrightness";
		  this.textBrightness.Size = new System.Drawing.Size(152, 20);
		  this.textBrightness.TabIndex = 58;
		  this.textBrightness.Text = "";
		  // 
		  // textGain
		  // 
		  this.textGain.Enabled = false;
		  this.textGain.Location = new System.Drawing.Point(96, 216);
		  this.textGain.Name = "textGain";
		  this.textGain.Size = new System.Drawing.Size(152, 20);
		  this.textGain.TabIndex = 57;
		  this.textGain.Text = "";
		  // 
		  // textContrast
		  // 
		  this.textContrast.Enabled = false;
		  this.textContrast.Location = new System.Drawing.Point(96, 192);
		  this.textContrast.Name = "textContrast";
		  this.textContrast.Size = new System.Drawing.Size(152, 20);
		  this.textContrast.TabIndex = 56;
		  this.textContrast.Text = "";
		  // 
		  // label12
		  // 
		  this.label12.Location = new System.Drawing.Point(16, 216);
		  this.label12.Name = "label12";
		  this.label12.Size = new System.Drawing.Size(72, 16);
		  this.label12.TabIndex = 55;
		  this.label12.Text = "Gain";
		  this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // label11
		  // 
		  this.label11.Location = new System.Drawing.Point(16, 192);
		  this.label11.Name = "label11";
		  this.label11.Size = new System.Drawing.Size(72, 16);
		  this.label11.TabIndex = 54;
		  this.label11.Text = "Contrast";
		  this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // label10
		  // 
		  this.label10.Location = new System.Drawing.Point(16, 168);
		  this.label10.Name = "label10";
		  this.label10.Size = new System.Drawing.Size(72, 16);
		  this.label10.TabIndex = 53;
		  this.label10.Text = "Brightness";
		  this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // label9
		  // 
		  this.label9.Location = new System.Drawing.Point(16, 144);
		  this.label9.Name = "label9";
		  this.label9.Size = new System.Drawing.Size(72, 16);
		  this.label9.TabIndex = 51;
		  this.label9.Text = "Image DPI";
		  this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // label8
		  // 
		  this.label8.Location = new System.Drawing.Point(16, 72);
		  this.label8.Name = "label8";
		  this.label8.Size = new System.Drawing.Size(72, 16);
		  this.label8.TabIndex = 49;
		  this.label8.Text = "Serial #";
		  this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // label7
		  // 
		  this.label7.Location = new System.Drawing.Point(16, 48);
		  this.label7.Name = "label7";
		  this.label7.Size = new System.Drawing.Size(72, 16);
		  this.label7.TabIndex = 47;
		  this.label7.Text = "F/W Version";
		  this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // label6
		  // 
		  this.label6.Location = new System.Drawing.Point(16, 120);
		  this.label6.Name = "label6";
		  this.label6.Size = new System.Drawing.Size(72, 16);
		  this.label6.TabIndex = 45;
		  this.label6.Text = "Image Height";
		  this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // label5
		  // 
		  this.label5.Location = new System.Drawing.Point(16, 96);
		  this.label5.Name = "label5";
		  this.label5.Size = new System.Drawing.Size(72, 16);
		  this.label5.TabIndex = 43;
		  this.label5.Text = "Image Width";
		  this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // label13
		  // 
		  this.label13.Location = new System.Drawing.Point(16, 24);
		  this.label13.Name = "label13";
		  this.label13.Size = new System.Drawing.Size(72, 16);
		  this.label13.TabIndex = 41;
		  this.label13.Text = "Device ID";
		  this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		  // 
		  // comboBoxDeviceName
		  // 
		  this.comboBoxDeviceName.Location = new System.Drawing.Point(84, 8);
		  this.comboBoxDeviceName.Name = "comboBoxDeviceName";
		  this.comboBoxDeviceName.Size = new System.Drawing.Size(152, 21);
		  this.comboBoxDeviceName.TabIndex = 1;
		  // 
		  // label1
		  // 
		  this.label1.Location = new System.Drawing.Point(8, 8);
		  this.label1.Name = "label1";
		  this.label1.Size = new System.Drawing.Size(72, 24);
		  this.label1.TabIndex = 3;
		  this.label1.Text = "Device Name";
		  // 
		  // StatusBar
		  // 
		  this.StatusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		  this.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
		  this.StatusBar.ForeColor = System.Drawing.SystemColors.Highlight;
		  this.StatusBar.Location = new System.Drawing.Point(0, 457);
		  this.StatusBar.Name = "StatusBar";
		  this.StatusBar.Size = new System.Drawing.Size(416, 24);
		  this.StatusBar.TabIndex = 7;
		  this.StatusBar.Text = "Click Init Button";
		  // 
		  // EnumerateBtn
		  // 
		  this.EnumerateBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
		  this.EnumerateBtn.Location = new System.Drawing.Point(332, 8);
		  this.EnumerateBtn.Name = "EnumerateBtn";
		  this.EnumerateBtn.Size = new System.Drawing.Size(72, 24);
		  this.EnumerateBtn.TabIndex = 8;
		  this.EnumerateBtn.Text = "Enumerate";
		  this.EnumerateBtn.Click += new System.EventHandler(this.EnumerateBtn_Click);
		  // 
		  // OpenDeviceBtn
		  // 
		  this.OpenDeviceBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
		  this.OpenDeviceBtn.Location = new System.Drawing.Point(248, 8);
		  this.OpenDeviceBtn.Name = "OpenDeviceBtn";
		  this.OpenDeviceBtn.Size = new System.Drawing.Size(72, 24);
		  this.OpenDeviceBtn.TabIndex = 9;
		  this.OpenDeviceBtn.Text = "Init";
		  this.OpenDeviceBtn.Click += new System.EventHandler(this.OpenDeviceBtn_Click);
		  // 
		  // MainForm
		  // 
		  this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		  this.ClientSize = new System.Drawing.Size(416, 481);
		  this.Controls.Add(this.OpenDeviceBtn);
		  this.Controls.Add(this.EnumerateBtn);
		  this.Controls.Add(this.label1);
		  this.Controls.Add(this.comboBoxDeviceName);
		  this.Controls.Add(this.tabControl1);
		  this.Controls.Add(this.StatusBar);
		  this.Name = "MainForm";
		  this.Text = "Matching C# Sample";
		  this.Load += new System.EventHandler(this.MainForm_Load);
		  this.tabControl1.ResumeLayout(false);
		  this.tabPage2.ResumeLayout(false);
		  this.GroupBox8.ResumeLayout(false);
		  ((System.ComponentModel.ISupportInitialize)(this.BrightnessUpDown)).EndInit();
		  this.groupBox4.ResumeLayout(false);
		  this.tabPage3.ResumeLayout(false);
		  this.groupBox6.ResumeLayout(false);
		  this.groupBox2.ResumeLayout(false);
		  this.groupBox1.ResumeLayout(false);
		  this.tabPage1.ResumeLayout(false);
		  this.groupBox3.ResumeLayout(false);
		  this.ResumeLayout(false);

	  }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main() 
      {
         Application.Run(new Form1());
      }

      ///////////////////////
      /// Create SGFingerPrintManager Object
      /// new SGFingerPrintManager()
      private void MainForm_Load(object sender, System.EventArgs e)
      {
         m_LedOn = false;

         m_RegMin1 = new Byte[400];
         m_RegMin2 = new Byte[400];
         m_VrfMin  = new Byte[400];
         
         comboBoxSecuLevel_R.SelectedIndex = 4;
         comboBoxSecuLevel_V.SelectedIndex = 3;
         EnableButtons(false);

         m_FPM = new SGFingerPrintManager();
         EnumerateBtn_Click(sender, e);
      }

      ///////////////////////
      /// EnumerateDevice(), GetEnumDeviceInfo()
      /// EnumerateDevice() can be called before Initializing SGFingerPrintManager
      private void EnumerateBtn_Click(object sender, System.EventArgs e)
      {
         Int32 iError;
         string enum_device;

         comboBoxDeviceName.Items.Clear();
        
         // Enumerate Device
         iError = m_FPM.EnumerateDevice();
         
         // Get enumeration info into SGFPMDeviceList
         m_DevList = new SGFPMDeviceList[m_FPM.NumberOfDevice];
         
         for (int i = 0; i < m_FPM.NumberOfDevice; i++)
         {
            m_DevList[i] = new SGFPMDeviceList(); 
            m_FPM.GetEnumDeviceInfo(i, m_DevList[i]);
            enum_device = m_DevList[i].DevName.ToString() +" : " + m_DevList[i].DevID;
            comboBoxDeviceName.Items.Add(enum_device);
         }

         if (comboBoxDeviceName.Items.Count > 0)
         {
             // Add Auto Selection
             enum_device = "Auto Selection";
             comboBoxDeviceName.Items.Add(enum_device);

             comboBoxDeviceName.SelectedIndex = 0;  //First selected one
         }

      }

      
      ///////////////////////
      // Initialize SGFingerprint manage with device name
      // Init(), OpenDeice()
      private void OpenDeviceBtn_Click(object sender, System.EventArgs e)
      {
         if (m_FPM.NumberOfDevice == 0)
            return;

         Int32 iError;
         SGFPMDeviceName device_name;
         Int32 device_id;

         Int32 numberOfDevices = comboBoxDeviceName.Items.Count;
         Int32 deviceSelected = comboBoxDeviceName.SelectedIndex;
         Boolean autoSelection = (deviceSelected == (numberOfDevices - 1));  // Last index

         if (autoSelection)
         {
             // Order of search: Hamster IV(HFDU04) -> Plus(HFDU03) -> III (HFDU02)
             device_name = SGFPMDeviceName.DEV_AUTO;

             device_id = (Int32)(SGFPMPortAddr.USB_AUTO_DETECT);
         }
         else 
         {
             device_name = m_DevList[deviceSelected].DevName;
             device_id = m_DevList[deviceSelected].DevID;
         }

         iError = m_FPM.Init(device_name);
         iError = m_FPM.OpenDevice(device_id);

         CheckBoxAutoOn.Enabled = false; 
         if (iError == (Int32)SGFPMError.ERROR_NONE)
         {
            GetBtn_Click(sender, e); 
            StatusBar.Text = "Initialization Success";
            EnableButtons(true);
           
            // FDU03, FDU04 only
            if ((device_name == SGFPMDeviceName.DEV_FDU03) || (device_name == SGFPMDeviceName.DEV_FDU04))
                   CheckBoxAutoOn.Enabled = true;
         }
         else
            DisplayError("OpenDevice()", iError);
      }

      ///////////////////////
      /// SetLedOn()
      private void LedBtn_Click(object sender, System.EventArgs e)
      {
         m_LedOn = !m_LedOn;
         m_FPM.SetLedOn(m_LedOn);
      }
    
      ///////////////////////
      /// Configure()
      private void ConfigBtn_Click(object sender, System.EventArgs e)
      {
         m_FPM.Configure((int)this.Handle);
      }

      ///////////////////////
      /// GetImage()
      private void GetImageBtn_Click(object sender, System.EventArgs e)
      {
         Int32 iError;
         Int32 elap_time;
         Byte[] fp_image;

         elap_time = Environment.TickCount;
         fp_image = new Byte[m_ImageWidth*m_ImageHeight];

         iError = m_FPM.GetImage(fp_image);

         if (iError == (Int32)SGFPMError.ERROR_NONE)
         {
            elap_time = Environment.TickCount - elap_time;
            DrawImage(fp_image, pictureBox1 );
            StatusBar.Text = "Capture Time : " + elap_time + " ms";
         }
         else
            DisplayError("GetImage()", iError);
      }


      ///////////////////////
      /// GetImageEx()
      private void GetLiveImageBtn_Click(object sender, System.EventArgs e)
      {
         Int32 iError;
         Int32 timeout;
         Int32 quality;
         Byte[] fp_image;
         Int32 elap_time;

         timeout = Convert.ToInt32(textTimeout.Text);
         quality = Convert.ToInt32(textImgQuality.Text);
         fp_image = new Byte[m_ImageWidth*m_ImageHeight];
         elap_time = Environment.TickCount;

         iError = m_FPM.GetImageEx(fp_image, timeout, this.pictureBox1.Handle.ToInt32(), quality);

         if (iError == 0)
         {
            elap_time = Environment.TickCount - elap_time;
            StatusBar.Text = "Capture Time : " + elap_time + "millisec";
         }
         else
            DisplayError("GetLiveImageEx()", iError);
      }


      ///////////////////////
      /// GetImage(), GetImageQuality(), CreateTemplate
      private void BtnCapture1_Click(object sender, System.EventArgs e)
      {
         Int32 iError;
         Byte[] fp_image;
         Int32 img_qlty;

         fp_image = new Byte[m_ImageWidth*m_ImageHeight];
         img_qlty = 0;
         
         iError =m_FPM.GetImage(fp_image);

         m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
         progressBar_R1.Value = img_qlty;

         if (iError == (Int32)SGFPMError.ERROR_NONE)
         {
            DrawImage(fp_image, pictureBoxR1);
            iError = m_FPM.CreateTemplate(fp_image, m_RegMin1);
           
			 if (iError == (Int32)SGFPMError.ERROR_NONE)
               StatusBar.Text = "First image is captured";
            else
               DisplayError("CreateTemplate()", iError);
         }
         else
            DisplayError("GetImage()", iError);
      }

      ///////////////////////
      /// GetImage(), GetImageQuality(), CreateTemplate
      private void BtnCapture2_Click(object sender, System.EventArgs e)
      {
         Int32 iError;
         Byte[] fp_image;
         Int32 img_qlty;

         fp_image = new Byte[m_ImageWidth*m_ImageHeight];
         img_qlty = 0;
         
         iError =m_FPM.GetImage(fp_image);
         m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
         progressBar_R2.Value = img_qlty;

         if (iError == (Int32)SGFPMError.ERROR_NONE)
         {
            DrawImage(fp_image, pictureBoxR2);
            iError = m_FPM.CreateTemplate(fp_image, m_RegMin2);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
               StatusBar.Text = "Second image is captured";
            else
               DisplayError("CreateTemplate()", iError);
         }
         else
            DisplayError("GetImage()", iError);

      }

      ///////////////////////
      /// GetImage(), GetImageQuality(), CreateTemplate
      private void BtnCapture3_Click(object sender, System.EventArgs e)
      {
         Int32 iError;
         Byte[] fp_image;
         Int32 img_qlty;

         fp_image = new Byte[m_ImageWidth*m_ImageHeight];
         img_qlty = 0;
         
         iError =m_FPM.GetImage(fp_image);

         m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
         progressBar_V1.Value = img_qlty;

         if (iError == (Int32)SGFPMError.ERROR_NONE)
         {
            DrawImage(fp_image, pictureBoxV1 );
            iError = m_FPM.CreateTemplate(null, fp_image, m_VrfMin);

            if (iError == (Int32)SGFPMError.ERROR_NONE)
               StatusBar.Text = "Image for verification is captured";
            else
               DisplayError("CreateTemplate()", iError);
         }
         else
            DisplayError("GetImage()", iError);
      }


      ///////////////////////
      /// MatchTemplate(), GetMatchingScore()
      private void BtnRegister_Click(object sender, System.EventArgs e)
      {
         Int32 iError;
         bool matched = false;
         Int32 match_score = 0;
         SGFPMSecurityLevel secu_level; //

         secu_level = (SGFPMSecurityLevel)comboBoxSecuLevel_R.SelectedIndex;
        
         iError = m_FPM.MatchTemplate(m_RegMin1, m_RegMin2, secu_level, ref matched); 
         iError = m_FPM.GetMatchingScore(m_RegMin1, m_RegMin2, ref match_score);

         if (iError == (Int32)SGFPMError.ERROR_NONE)
         {
            if (matched)
               StatusBar.Text = "Registration Success, Matching Score: " + match_score;
            else
               StatusBar.Text = "Registration Failed";
         }
         else
            DisplayError("GetMatchingScore()", iError);

      }
      
      ///////////////////////
      /// MatchTemplate(), GetMatchingScore()
      private void BtnVerify_Click(object sender, System.EventArgs e)
      {
         Int32 iError;
         bool matched1 = false; 
         bool matched2 = false;
         SGFPMSecurityLevel secu_level;

         secu_level = (SGFPMSecurityLevel)comboBoxSecuLevel_V.SelectedIndex;

         iError = m_FPM.MatchTemplate(m_RegMin1, m_VrfMin, secu_level, ref matched1);
         iError = m_FPM.MatchTemplate(m_RegMin2, m_VrfMin, secu_level, ref matched2);

         if (iError == (Int32)SGFPMError.ERROR_NONE)
         {
            if (matched1 & matched2)
               StatusBar.Text = "Verification Success";
            else
               StatusBar.Text = "Verification Failed";
         }
         else
            DisplayError("MatchTemplate()", iError);
      }


      ///////////////////////
      /// GetDeviceInfo()
      private void GetBtn_Click(object sender, System.EventArgs e)
      {
         SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
         Int32 iError = m_FPM.GetDeviceInfo(pInfo);

         if (iError == (Int32)SGFPMError.ERROR_NONE)
         {
            m_ImageWidth = pInfo.ImageWidth;
            m_ImageHeight = pInfo.ImageHeight;

            textDeviceID.Text = Convert.ToString(pInfo.DeviceID);
            textImageDPI.Text	   = Convert.ToString(pInfo.ImageDPI);
            textFWVersion.Text	   = Convert.ToString(pInfo.FWVersion, 16);

            ASCIIEncoding encoding = new ASCIIEncoding();
            textSerialNum.Text = encoding.GetString(pInfo.DeviceSN);
           
            textImageHeight.Text = Convert.ToString(pInfo.ImageHeight);
            textImageWidth.Text  = Convert.ToString(pInfo.ImageWidth);
            textBrightness.Text   = Convert.ToString(pInfo.Brightness);
            textContrast.Text	   = Convert.ToString(pInfo.Contrast);
            textGain.Text         = Convert.ToString(pInfo.Gain);

            BrightnessUpDown.Value = pInfo.Brightness;
         }
      }

      ///////////////////////
      private void SetBrightnessBtn_Click(object sender, System.EventArgs e)
      {
         Int32 iError;
         Int32 brightness;

         brightness = (int)BrightnessUpDown.Value;
         iError = m_FPM.SetBrightness(brightness);
         if (iError == (Int32)SGFPMError.ERROR_NONE)
         {
            StatusBar.Text = "SetBrightness success";
            GetBtn_Click(sender, e);
         }
         else
            DisplayError("SetBrightness()", iError);

      }
      

      ///////////////////////
      private void CheckBoxAutoOn_CheckedChanged(object sender, System.EventArgs e)
      {
         if (CheckBoxAutoOn.Checked)
            m_FPM.EnableAutoOnEvent(true, (int)this.Handle);
         else
            m_FPM.EnableAutoOnEvent(false, 0);
      }
      
      ///////////////////////
      protected override void WndProc(ref Message message)
      {
         if (message.Msg == (int)SGFPMMessages.DEV_AUTOONEVENT)
         {
            if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_ON)
               StatusBar.Text = "Device Message: Finger On";
            else if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_OFF)
               StatusBar.Text = "Device Message: Finger Off";
         }
         base.WndProc(ref message);
      }

      ///////////////////////
      private void DrawImage(Byte[] imgData, PictureBox picBox)
      {
         int colorval;
         Bitmap bmp = new Bitmap(m_ImageWidth, m_ImageHeight);
         picBox.Image = (Image)bmp;

         for (int i=0; i<bmp.Width; i++)
         {
            for (int j=0; j<bmp.Height; j++)
            {
               colorval = (int)imgData[(j*m_ImageWidth)+ i];
               bmp.SetPixel(i,j,Color.FromArgb(colorval,colorval, colorval));
            }
         }
         picBox.Refresh();
      }

      ///////////////////////
      private void EnableButtons(bool enable)
      {
         ConfigBtn.Enabled = enable;       
         GetImageBtn.Enabled = enable;
         GetLiveImageBtn.Enabled = enable;
         BtnCapture1.Enabled = enable;
         BtnCapture2.Enabled = enable;          
         BtnCapture3.Enabled = enable;          
         BtnRegister.Enabled = enable;          
         BtnVerify.Enabled = enable;
         GetBtn.Enabled = enable;
         SetBrightnessBtn.Enabled = enable;
      }

      ///////////////////////
      void DisplayError(string funcName, int iError)
      {
         string text ="";
         
         switch (iError)
         {
            case 0:                             //SGFDX_ERROR_NONE				= 0,
               text = "Error none";
               break;

            case 1:                             //SGFDX_ERROR_CREATION_FAILED	= 1,
               text = "Can not create object";
               break;

            case 2:                             //   SGFDX_ERROR_FUNCTION_FAILED	= 2,
               text = "Function Failed";
               break;

            case 3:                             //   SGFDX_ERROR_INVALID_PARAM	= 3,
               text = "Invalid Parameter";
               break;

            case 4:                          //   SGFDX_ERROR_NOT_USED			= 4,
               text = "Not used function";
               break;

            case 5:                                //SGFDX_ERROR_DLLLOAD_FAILED	= 5,
               text = "Can not create object";
               break;

            case 6:                                //SGFDX_ERROR_DLLLOAD_FAILED_DRV	= 6,
               text = "Can not load device driver";
               break;
            case 7:                                //SGFDX_ERROR_DLLLOAD_FAILED_ALGO = 7,
               text = "Can not load sgfpamx.dll";
               break;

            case 51:                //SGFDX_ERROR_SYSLOAD_FAILED	   = 51,	// system file load fail
               text = "Can not load driver kernel file";
               break;
            
            case 52:                //SGFDX_ERROR_INITIALIZE_FAILED  = 52,   // chip initialize fail
               text = "Failed to initialize the device";
               break;
            
            case 53:                //SGFDX_ERROR_LINE_DROPPED		   = 53,   // image data drop
               text = "Data transmission is not good";
               break;
            
            case 54:                //SGFDX_ERROR_TIME_OUT			   = 54,   // getliveimage timeout error
               text = "Time out";
               break;
            
            case 55:                //SGFDX_ERROR_DEVICE_NOT_FOUND	= 55,   // device not found
               text = "Device not found";
               break;
            
            case 56:                //SGFDX_ERROR_DRVLOAD_FAILED	   = 56,   // dll file load fail
               text = "Can not load driver file";
               break;
            
            case 57:                //SGFDX_ERROR_WRONG_IMAGE		   = 57,   // wrong image
               text = "Wrong Image";
               break;
            
            case 58:                //SGFDX_ERROR_LACK_OF_BANDWIDTH  = 58,   // USB Bandwith Lack Error
               text = "Lack of USB Bandwith";
               break;
            
            case 59:                //SGFDX_ERROR_DEV_ALREADY_OPEN	= 59,   // Device Exclusive access Error
               text = "Device is already opened";
               break;
            
            case 60:                //SGFDX_ERROR_GETSN_FAILED		   = 60,   // Fail to get Device Serial Number
               text = "Device serial number error";
               break;

            case 61:                //SGFDX_ERROR_UNSUPPORTED_DEV		   = 61,   // Unsupported device
               text = "Unsupported device";
               break;

               // Extract & Verification error
            case 101:                //SGFDX_ERROR_FEAT_NUMBER		= 101, // utoo small number of minutiae
               text = "The number of minutiae is too small";
               break;

            case 102:                //SGFDX_ERROR_INVALID_TEMPLATE_TYPE		= 102, // wrong template type
               text = "Template is invalid";
               break;

            case 103:                //SGFDX_ERROR_INVALID_TEMPLATE1		= 103, // wrong template type
               text = "1st template is invalid";
               break;

            case 104:                //SGFDX_ERROR_INVALID_TEMPLATE2		= 104, // vwrong template type
               text = "2nd template is invalid";
               break;

            case 105:                //SGFDX_ERROR_EXTRACT_FAIL		= 105, // extraction fail
               text = "Minutiae extraction failed";
               break;

            case 106:                //SGFDX_ERROR_MATCH_FAIL		= 106, // matching  fail
               text = "Matching failed";
               break;

         }

         text = funcName + " Error # " + iError + " :" + text; 
         StatusBar.Text = text;
      }

      
	}
}


