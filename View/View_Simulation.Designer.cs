namespace FlightSim
{
    partial class View_Simulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_Simulation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDecrementSpeed = new System.Windows.Forms.Button();
            this.btnIncrementSpeed = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.tbxXmlFile = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(25, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1506, 765);
            this.panel1.TabIndex = 0;
            // 
            // btnDecrementSpeed
            // 
            this.btnDecrementSpeed.Enabled = false;
            this.btnDecrementSpeed.Location = new System.Drawing.Point(25, 25);
            this.btnDecrementSpeed.Name = "btnDecrementSpeed";
            this.btnDecrementSpeed.Size = new System.Drawing.Size(100, 35);
            this.btnDecrementSpeed.TabIndex = 1;
            this.btnDecrementSpeed.Text = "Ralentir";
            this.btnDecrementSpeed.UseVisualStyleBackColor = true;
            this.btnDecrementSpeed.Click += new System.EventHandler(this.btnDecrementSpeed_Click);
            // 
            // btnIncrementSpeed
            // 
            this.btnIncrementSpeed.Enabled = false;
            this.btnIncrementSpeed.Location = new System.Drawing.Point(25, 116);
            this.btnIncrementSpeed.Name = "btnIncrementSpeed";
            this.btnIncrementSpeed.Size = new System.Drawing.Size(100, 35);
            this.btnIncrementSpeed.TabIndex = 2;
            this.btnIncrementSpeed.Text = "Accélérer";
            this.btnIncrementSpeed.UseVisualStyleBackColor = true;
            this.btnIncrementSpeed.Click += new System.EventHandler(this.btnIncrementSpeed_Click);
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(25, 80);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(100, 20);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "00 : 00 : 00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxXmlFile
            // 
            this.tbxXmlFile.Location = new System.Drawing.Point(190, 25);
            this.tbxXmlFile.Name = "tbxXmlFile";
            this.tbxXmlFile.Size = new System.Drawing.Size(160, 20);
            this.tbxXmlFile.TabIndex = 4;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(190, 51);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(160, 25);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Charger";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // View_Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 961);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tbxXmlFile);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnIncrementSpeed);
            this.Controls.Add(this.btnDecrementSpeed);
            this.Controls.Add(this.panel1);
            this.Name = "View_Simulation";
            this.Text = "Simulateur de vol";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox tbxXmlFile;

        private System.Windows.Forms.Button btnIncrementSpeed;
        private System.Windows.Forms.Label lblTime;

        private System.Windows.Forms.Button btnDecrementSpeed;

        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}