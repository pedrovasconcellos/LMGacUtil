using LMGacUtil.CustomControl;

namespace LMGacUtil
{
    partial class FrmMain
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtnInstallCom = new System.Windows.Forms.Button();
            this.LblListMessage = new System.Windows.Forms.Label();
            this.btnLogClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.mylist = new System.Windows.Forms.ListView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnIIsRestart = new System.Windows.Forms.Button();
            this.btnUnstall = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnInstallCom);
            this.splitContainer1.Panel1.Controls.Add(this.LblListMessage);
            this.splitContainer1.Panel1.Controls.Add(this.btnLogClear);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnCheck);
            this.splitContainer1.Panel1.Controls.Add(this.txtFilter);
            this.splitContainer1.Panel1.Controls.Add(this.mylist);
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.btnIIsRestart);
            this.splitContainer1.Panel1.Controls.Add(this.btnUnstall);
            this.splitContainer1.Panel1.Controls.Add(this.btnInstall);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtLog);
            this.splitContainer1.Size = new System.Drawing.Size(719, 440);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 12;
            // 
            // BtnInstallCom
            // 
            this.BtnInstallCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnInstallCom.Location = new System.Drawing.Point(641, 152);
            this.BtnInstallCom.Name = "BtnInstallCom";
            this.BtnInstallCom.Size = new System.Drawing.Size(75, 23);
            this.BtnInstallCom.TabIndex = 16;
            this.BtnInstallCom.Text = "Intall&Com+";
            this.BtnInstallCom.UseVisualStyleBackColor = true;
            this.BtnInstallCom.Click += new System.EventHandler(this.button1_Click);
            // 
            // LblListMessage
            // 
            this.LblListMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblListMessage.BackColor = System.Drawing.SystemColors.Control;
            this.LblListMessage.Location = new System.Drawing.Point(3, 36);
            this.LblListMessage.Name = "LblListMessage";
            this.LblListMessage.Size = new System.Drawing.Size(632, 13);
            this.LblListMessage.TabIndex = 15;
            this.LblListMessage.Text = "label2";
            this.LblListMessage.Click += new System.EventHandler(this.LblListMessage_Click);
            // 
            // btnLogClear
            // 
            this.btnLogClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogClear.Location = new System.Drawing.Point(641, 181);
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Size = new System.Drawing.Size(75, 23);
            this.btnLogClear.TabIndex = 7;
            this.btnLogClear.Text = "Clear &Log";
            this.btnLogClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Filter";
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.Location = new System.Drawing.Point(641, 36);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "&Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(48, 10);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(587, 20);
            this.txtFilter.TabIndex = 11;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // mylist
            // 
            this.mylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mylist.CheckBoxes = true;
            this.mylist.Location = new System.Drawing.Point(3, 52);
            this.mylist.Name = "mylist";
            this.mylist.Size = new System.Drawing.Size(632, 183);
            this.mylist.TabIndex = 5;
            this.mylist.UseCompatibleStateImageBehavior = false;
            this.mylist.View = System.Windows.Forms.View.Details;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(641, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnIIsRestart
            // 
            this.btnIIsRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIIsRestart.Location = new System.Drawing.Point(641, 123);
            this.btnIIsRestart.Name = "btnIIsRestart";
            this.btnIIsRestart.Size = new System.Drawing.Size(75, 23);
            this.btnIIsRestart.TabIndex = 13;
            this.btnIIsRestart.Text = "II&S Restart";
            this.btnIIsRestart.UseVisualStyleBackColor = true;
            this.btnIIsRestart.Click += new System.EventHandler(this.btnIIsRestart_Click);
            // 
            // btnUnstall
            // 
            this.btnUnstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnstall.Location = new System.Drawing.Point(641, 94);
            this.btnUnstall.Name = "btnUnstall";
            this.btnUnstall.Size = new System.Drawing.Size(75, 23);
            this.btnUnstall.TabIndex = 8;
            this.btnUnstall.Text = "&Unstall";
            this.btnUnstall.UseVisualStyleBackColor = true;
            this.btnUnstall.Click += new System.EventHandler(this.btnUnstall_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstall.Location = new System.Drawing.Point(641, 65);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 23);
            this.btnInstall.TabIndex = 9;
            this.btnInstall.Text = "&Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.SystemColors.Info;
            this.txtLog.Location = new System.Drawing.Point(3, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(713, 166);
            this.txtLog.TabIndex = 6;
            this.txtLog.Text = "Inicializado";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 464);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(250, 360);
            this.Name = "FrmMain";
            this.Text = "LMGacUtil";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ListView mylist;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnIIsRestart;
        private System.Windows.Forms.Button btnUnstall;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnLogClear;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblListMessage;
        private System.Windows.Forms.Button BtnInstallCom;
    }
}

