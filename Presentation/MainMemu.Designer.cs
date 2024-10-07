namespace _420DA3_Demo_Iterative.Presentation
{
    partial class MainMemu
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
            buttonManageStudents = new Button();
            buttonManageCourses = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // buttonManageStudents
            // 
            buttonManageStudents.Location = new Point(83, 39);
            buttonManageStudents.Name = "buttonManageStudents";
            buttonManageStudents.Size = new Size(217, 34);
            buttonManageStudents.TabIndex = 0;
            buttonManageStudents.Text = "Gerer les etudiants";
            buttonManageStudents.UseVisualStyleBackColor = true;
            buttonManageStudents.Click += buttonManageStudents_Click;
            // 
            // buttonManageCourses
            // 
            buttonManageCourses.Location = new Point(83, 151);
            buttonManageCourses.Name = "buttonManageCourses";
            buttonManageCourses.Size = new Size(217, 34);
            buttonManageCourses.TabIndex = 1;
            buttonManageCourses.Text = "Gerer les cours";
            buttonManageCourses.UseVisualStyleBackColor = true;
            buttonManageCourses.Click += buttonManageCourses_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(123, 273);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(125, 34);
            btnExit.TabIndex = 2;
            btnExit.Text = "&Quitter";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MainMemu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 386);
            Controls.Add(btnExit);
            Controls.Add(buttonManageCourses);
            Controls.Add(buttonManageStudents);
            Name = "MainMemu";
            Text = "MainMemu";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonManageStudents;
        private Button buttonManageCourses;
        private Button btnExit;
    }
}