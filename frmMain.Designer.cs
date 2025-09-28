namespace TeamsManager
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tbClientSecrect = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tbClientId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbTenant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tbAccountId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 505);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 27);
            this.panel1.TabIndex = 1;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(6, 7);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(38, 15);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "label1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 505);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 477);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(786, 377);
            this.panel2.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(5, 34);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 338);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 150;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 29);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chat Groups";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 380);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(786, 94);
            this.panel4.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel6.Size = new System.Drawing.Size(688, 88);
            this.panel6.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(0, 5);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(688, 78);
            this.textBox1.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(691, 3);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel5.Size = new System.Drawing.Size(92, 88);
            this.panel5.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 78);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel10);
            this.tabPage2.Controls.Add(this.panel9);
            this.tabPage2.Controls.Add(this.panel8);
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 477);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.tbClientSecrect);
            this.panel10.Controls.Add(this.label5);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(3, 90);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panel10.Size = new System.Drawing.Size(786, 29);
            this.panel10.TabIndex = 5;
            // 
            // tbClientSecrect
            // 
            this.tbClientSecrect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbClientSecrect.Location = new System.Drawing.Point(83, 3);
            this.tbClientSecrect.Name = "tbClientSecrect";
            this.tbClientSecrect.Size = new System.Drawing.Size(693, 23);
            this.tbClientSecrect.TabIndex = 2;
            this.tbClientSecrect.TextChanged += new System.EventHandler(this.tbClientSecrect_TextChanged);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Client Secret";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tbClientId);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 61);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panel9.Size = new System.Drawing.Size(786, 29);
            this.panel9.TabIndex = 4;
            // 
            // tbClientId
            // 
            this.tbClientId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbClientId.Location = new System.Drawing.Point(83, 3);
            this.tbClientId.Name = "tbClientId";
            this.tbClientId.Size = new System.Drawing.Size(693, 23);
            this.tbClientId.TabIndex = 2;
            this.tbClientId.TextChanged += new System.EventHandler(this.tbClientId_TextChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Client Id:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tbTenant);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 32);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panel8.Size = new System.Drawing.Size(786, 29);
            this.panel8.TabIndex = 3;
            // 
            // tbTenant
            // 
            this.tbTenant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTenant.Location = new System.Drawing.Point(83, 3);
            this.tbTenant.Name = "tbTenant";
            this.tbTenant.Size = new System.Drawing.Size(693, 23);
            this.tbTenant.TabIndex = 2;
            this.tbTenant.TextChanged += new System.EventHandler(this.tbTenant_TextChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tenant Id:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tbAccountId);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.panel7.Size = new System.Drawing.Size(786, 29);
            this.panel7.TabIndex = 2;
            // 
            // tbAccountId
            // 
            this.tbAccountId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAccountId.Location = new System.Drawing.Point(83, 3);
            this.tbAccountId.Name = "tbAccountId";
            this.tbAccountId.Size = new System.Drawing.Size(693, 23);
            this.tbAccountId.TabIndex = 2;
            this.tbAccountId.TextChanged += new System.EventHandler(this.tbAccountId_TextChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Account Id:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 532);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Label lbStatus;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Panel panel3;
        private Label label1;
        private Panel panel4;
        private Panel panel5;
        private Button button1;
        private TabPage tabPage2;
        private Panel panel6;
        private TextBox textBox1;
        private Panel panel10;
        private TextBox tbClientSecrect;
        private Label label5;
        private Panel panel9;
        private TextBox tbClientId;
        private Label label4;
        private Panel panel8;
        private TextBox tbTenant;
        private Label label3;
        private Panel panel7;
        private TextBox tbAccountId;
        private Label label2;
    }
}