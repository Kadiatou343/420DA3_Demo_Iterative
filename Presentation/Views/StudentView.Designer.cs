namespace _420DA3_Demo_Iterative.Presentation.Views
{
    partial class StudentView
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
            buttonExit.Location = new Point(751, 446);
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
            buttonSave.Location = new Point(589, 446);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(156, 34);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Sauvegarder";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonReload
            // 
            buttonReload.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonReload.Location = new Point(393, 446);
            buttonReload.Name = "buttonReload";
            buttonReload.Size = new Size(190, 34);
            buttonReload.TabIndex = 2;
            buttonReload.Text = "Charger Donnees";
            buttonReload.UseVisualStyleBackColor = true;
            buttonReload.Click += button3_Click;
            // 
            // tableView
            // 
            tableView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableView.Location = new Point(12, 12);
            tableView.Name = "tableView";
            tableView.RowHeadersWidth = 62;
            tableView.Size = new Size(851, 428);
            tableView.TabIndex = 3;
            // 
            // StudentView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 492);
            Controls.Add(tableView);
            Controls.Add(buttonReload);
            Controls.Add(buttonSave);
            Controls.Add(buttonExit);
            Name = "StudentView";
            Text = "StudentView";
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