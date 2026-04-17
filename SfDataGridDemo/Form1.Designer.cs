namespace SfDataGridDemo
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
            dataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            SuspendLayout();
            // 
            // dataGrid
            // 
            dataGrid.AccessibleName = "Table";
            dataGrid.Location = new System.Drawing.Point(42, 49);
            dataGrid.Name = "dataGrid";
            dataGrid.Size = new System.Drawing.Size(671, 334);
            dataGrid.Style.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            dataGrid.Style.CheckBoxStyle.CheckedBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dataGrid.Style.CheckBoxStyle.CheckedBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dataGrid.Style.CheckBoxStyle.IndeterminateBorderColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dataGrid.Style.DragPreviewRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGrid.Style.DragPreviewRowStyle.RowCountIndicatorBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dataGrid.Style.DragPreviewRowStyle.RowCountIndicatorTextColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGrid.Style.HyperlinkStyle.DefaultLinkColor = System.Drawing.Color.FromArgb(0, 120, 215);
            dataGrid.TabIndex = 0;
            dataGrid.Text = "sfDataGrid1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(dataGrid);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid dataGrid;
    }
}

