namespace keylogger
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tCheckKey = new System.Windows.Forms.Timer(this.components);
            this.tWriteKeys = new System.Windows.Forms.Timer(this.components);
            this.tUploadData = new System.Windows.Forms.Timer(this.components);
            this.tbLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tCheckKey
            // 
            this.tCheckKey.Interval = 1;
            this.tCheckKey.Tick += new System.EventHandler(this.tCheckKey_Tick);
            // 
            // tWriteKeys
            // 
            this.tWriteKeys.Interval = 1000;
            this.tWriteKeys.Tick += new System.EventHandler(this.tWriteKeys_Tick);
            // 
            // tUploadData
            // 
            this.tUploadData.Interval = 1000;
            this.tUploadData.Tick += new System.EventHandler(this.tUploadData_Tick);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(23, 13);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(100, 20);
            this.tbLog.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(158, 77);
            this.Controls.Add(this.tbLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tCheckKey;
        private System.Windows.Forms.Timer tWriteKeys;
        private System.Windows.Forms.Timer tUploadData;
        private System.Windows.Forms.TextBox tbLog;
    }
}

