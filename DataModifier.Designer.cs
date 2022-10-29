namespace Battle_Param_Editor
{
    partial class DataModifier
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAdjustBy = new System.Windows.Forms.Label();
            this.nupAdjustment = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nupAdjustment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(6, 29);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(87, 29);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAdjustBy
            // 
            this.lblAdjustBy.AutoSize = true;
            this.lblAdjustBy.Location = new System.Drawing.Point(9, 9);
            this.lblAdjustBy.Name = "lblAdjustBy";
            this.lblAdjustBy.Size = new System.Drawing.Size(53, 13);
            this.lblAdjustBy.TabIndex = 2;
            this.lblAdjustBy.Text = "Adjust by:";
            // 
            // nupAdjustment
            // 
            this.nupAdjustment.Location = new System.Drawing.Point(65, 6);
            this.nupAdjustment.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupAdjustment.Name = "nupAdjustment";
            this.nupAdjustment.Size = new System.Drawing.Size(96, 20);
            this.nupAdjustment.TabIndex = 0;
            this.nupAdjustment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupAdjustment_KeyPress);
            // 
            // DataModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 58);
            this.ControlBox = false;
            this.Controls.Add(this.nupAdjustment);
            this.Controls.Add(this.lblAdjustBy);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DataModifier";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DataModifier";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.nupAdjustment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAdjustBy;
        public System.Windows.Forms.NumericUpDown nupAdjustment;
    }
}