namespace Project1
{
    partial class uxForm1
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
            this.uxStartButton = new System.Windows.Forms.Button();
            this.uxStopButton = new System.Windows.Forms.Button();
            this.uxResetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxStartButton
            // 
            this.uxStartButton.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxStartButton.Location = new System.Drawing.Point(177, 318);
            this.uxStartButton.Name = "uxStartButton";
            this.uxStartButton.Size = new System.Drawing.Size(112, 41);
            this.uxStartButton.TabIndex = 0;
            this.uxStartButton.Text = "Start";
            this.uxStartButton.UseVisualStyleBackColor = true;
            this.uxStartButton.Click += new System.EventHandler(this.uxStartButton_Click);
            // 
            // uxStopButton
            // 
            this.uxStopButton.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxStopButton.Location = new System.Drawing.Point(373, 318);
            this.uxStopButton.Name = "uxStopButton";
            this.uxStopButton.Size = new System.Drawing.Size(113, 41);
            this.uxStopButton.TabIndex = 1;
            this.uxStopButton.Text = "Stop";
            this.uxStopButton.UseVisualStyleBackColor = true;
            this.uxStopButton.Click += new System.EventHandler(this.uxStopButton_Click);
            // 
            // uxResetButton
            // 
            this.uxResetButton.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxResetButton.Location = new System.Drawing.Point(584, 318);
            this.uxResetButton.Name = "uxResetButton";
            this.uxResetButton.Size = new System.Drawing.Size(97, 41);
            this.uxResetButton.TabIndex = 2;
            this.uxResetButton.Text = "Reset";
            this.uxResetButton.UseVisualStyleBackColor = true;
            this.uxResetButton.Click += new System.EventHandler(this.uxResetButton_Click);
            // 
            // uxForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(908, 383);
            this.Controls.Add(this.uxResetButton);
            this.Controls.Add(this.uxStopButton);
            this.Controls.Add(this.uxStartButton);
            this.Name = "uxForm1";
            this.Text = "Heat Transfer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxStartButton;
        private System.Windows.Forms.Button uxStopButton;
        private System.Windows.Forms.Button uxResetButton;
    }
}

