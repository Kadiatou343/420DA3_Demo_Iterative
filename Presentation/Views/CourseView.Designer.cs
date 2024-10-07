namespace _420DA3_Demo_Iterative.Presentation.Views
{
    partial class CourseView
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
            buttonExit = new Button();
            buttonSave = new Button();
            buttonReload = new Button();
            tableView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tableView).BeginInit();
            SuspendLayout();
            // 
            // buttonExit
            // 
            buttonExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonExit.Location = new Point(714, 439);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(112, 34);
            buttonExit.TabIndex = 0;
            buttonExit.Text = "&Quitter";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(560, 439);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(148, 34);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Sauvegarder";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonReload
            // 
            buttonReload.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonReload.Location = new Point(384, 439);
            buttonReload.Name = "buttonReload";
            buttonReload.Size = new Size(170, 34);
            buttonReload.TabIndex = 2;
            buttonReload.Text = "Charger Donnees";
            buttonReload.UseVisualStyleBackColor = true;
            buttonReload.Click += buttonReload_Click;
            // 
            // tableView
            // 
            tableView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableView.Location = new Point(12, 12);
            tableView.Name = "tableView";
            tableView.RowHeadersWidth = 62;
            tableView.Size = new Size(814, 421);
            tableView.TabIndex = 3;
            // 
            // CourseView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 485);
            Controls.Add(tableView);
            Controls.Add(buttonReload);
            Controls.Add(buttonSave);
            Controls.Add(buttonExit);
            Name = "CourseView";
            Text = "CourseView";
            ((System.ComponentModel.ISupportInitialize)tableView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonExit;
        private Button buttonSave;
        private Button buttonReload;
        private DataGridView tableView;
    }
}