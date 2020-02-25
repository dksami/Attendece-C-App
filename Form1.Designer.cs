namespace Matching_cs
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.user = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pw = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.login = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.325301F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98.6747F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(705, 737);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(12, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 731);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.2809F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.7191F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(690, 731);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 672);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(684, 56);
            this.panel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "STATUS : NOT LOGIN YET";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bunifuCustomLabel2);
            this.panel3.Controls.Add(this.login);
            this.panel3.Controls.Add(this.pw);
            this.panel3.Controls.Add(this.user);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 561);
            this.panel3.TabIndex = 0;
            // 
            // user
            // 
            this.user.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.user.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.user.ForeColor = System.Drawing.Color.White;
            this.user.HintForeColor = System.Drawing.Color.White;
            this.user.HintText = "Username";
            this.user.isPassword = false;
            this.user.LineFocusedColor = System.Drawing.Color.Lavender;
            this.user.LineIdleColor = System.Drawing.Color.White;
            this.user.LineMouseHoverColor = System.Drawing.Color.Lavender;
            this.user.LineThickness = 3;
            this.user.Location = new System.Drawing.Point(30, 131);
            this.user.Margin = new System.Windows.Forms.Padding(4);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(294, 61);
            this.user.TabIndex = 0;
            this.user.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.user.OnValueChanged += new System.EventHandler(this.bunifuMaterialTextbox1_OnValueChanged);
            // 
            // pw
            // 
            this.pw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pw.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.pw.ForeColor = System.Drawing.Color.White;
            this.pw.HintForeColor = System.Drawing.Color.White;
            this.pw.HintText = "Password";
            this.pw.isPassword = false;
            this.pw.LineFocusedColor = System.Drawing.Color.Lavender;
            this.pw.LineIdleColor = System.Drawing.Color.WhiteSmoke;
            this.pw.LineMouseHoverColor = System.Drawing.Color.Lavender;
            this.pw.LineThickness = 3;
            this.pw.Location = new System.Drawing.Point(30, 200);
            this.pw.Margin = new System.Windows.Forms.Padding(4);
            this.pw.Name = "pw";
            this.pw.Size = new System.Drawing.Size(294, 61);
            this.pw.TabIndex = 1;
            this.pw.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // login
            // 
            this.login.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(106)))), ((int)(((byte)(116)))));
            this.login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(106)))), ((int)(((byte)(116)))));
            this.login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.login.BorderRadius = 0;
            this.login.ButtonText = "Login";
            this.login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login.DisabledColor = System.Drawing.Color.Gray;
            this.login.Iconcolor = System.Drawing.Color.Transparent;
            this.login.Iconimage = ((System.Drawing.Image)(resources.GetObject("login.Iconimage")));
            this.login.Iconimage_right = null;
            this.login.Iconimage_right_Selected = null;
            this.login.Iconimage_Selected = null;
            this.login.IconMarginLeft = 0;
            this.login.IconMarginRight = 0;
            this.login.IconRightVisible = true;
            this.login.IconRightZoom = 0D;
            this.login.IconVisible = false;
            this.login.IconZoom = 90D;
            this.login.IsTab = false;
            this.login.Location = new System.Drawing.Point(30, 294);
            this.login.Name = "login";
            this.login.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(106)))), ((int)(((byte)(116)))));
            this.login.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(106)))), ((int)(((byte)(116)))));
            this.login.OnHoverTextColor = System.Drawing.Color.White;
            this.login.selected = false;
            this.login.Size = new System.Drawing.Size(87, 48);
            this.login.TabIndex = 2;
            this.login.Text = "Login";
            this.login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.login.Textcolor = System.Drawing.Color.White;
            this.login.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Franklin Gothic Heavy", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(19, 22);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(167, 61);
            this.bunifuCustomLabel2.TabIndex = 1;
            this.bunifuCustomLabel2.Text = "LOGIN";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(767, 775);
            this.panel4.TabIndex = 1;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(53)))));
            this.BackgroundImage = global::Matching_cs.Properties.Resources._58731_overhead_shot_of_a_macbook_keyboard_against_white_marble_surface___minimal_laptop_keyboard;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(767, 775);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuFlatButton login;
        private Bunifu.Framework.UI.BunifuMaterialTextbox pw;
        private Bunifu.Framework.UI.BunifuMaterialTextbox user;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
    }
}