using System.Windows.Forms;

namespace Game
{
    partial class Form1
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
            this.imgCross = new System.Windows.Forms.DataGridView();
            this.topData = new System.Windows.Forms.DataGridView();
            this.leftData = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftData)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCross
            // 
            this.imgCross.AllowUserToResizeColumns = false;
            this.imgCross.AllowUserToResizeRows = false;
            this.imgCross.BackgroundColor = System.Drawing.SystemColors.Control;
            this.imgCross.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.imgCross.ColumnHeadersVisible = false;
            this.imgCross.Location = new System.Drawing.Point(140, 252);
            this.imgCross.Margin = new System.Windows.Forms.Padding(6);
            this.imgCross.Name = "imgCross";
            this.imgCross.ReadOnly = true;
            this.imgCross.RowHeadersVisible = false;
            this.imgCross.RowHeadersWidth = 50;
            this.imgCross.RowTemplate.Height = 50;
            this.imgCross.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.imgCross.ShowCellToolTips = false;
            this.imgCross.Size = new System.Drawing.Size(201, 220);
            this.imgCross.TabIndex = 2;
            this.imgCross.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.imgCross_CellClick);
            this.imgCross.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.imgCross_CellMouseDown);
            this.imgCross.SelectionChanged += new System.EventHandler(this.imgCross_SelectionChanged);
            // 
            // topData
            // 
            this.topData.AllowUserToResizeColumns = false;
            this.topData.AllowUserToResizeRows = false;
            this.topData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.topData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.topData.ColumnHeadersVisible = false;
            this.topData.Enabled = false;
            this.topData.Location = new System.Drawing.Point(141, 119);
            this.topData.Margin = new System.Windows.Forms.Padding(6);
            this.topData.Name = "topData";
            this.topData.RowHeadersVisible = false;
            this.topData.RowHeadersWidth = 82;
            this.topData.RowTemplate.Height = 25;
            this.topData.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.topData.Size = new System.Drawing.Size(200, 134);
            this.topData.TabIndex = 3;
            this.topData.SelectionChanged += new System.EventHandler(this.topData_SelectionChanged);
            // 
            // leftData
            // 
            this.leftData.AllowUserToResizeColumns = false;
            this.leftData.AllowUserToResizeRows = false;
            this.leftData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.leftData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leftData.ColumnHeadersVisible = false;
            this.leftData.Enabled = false;
            this.leftData.Location = new System.Drawing.Point(19, 252);
            this.leftData.Margin = new System.Windows.Forms.Padding(6);
            this.leftData.Name = "leftData";
            this.leftData.RowHeadersVisible = false;
            this.leftData.RowHeadersWidth = 82;
            this.leftData.RowTemplate.Height = 25;
            this.leftData.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.leftData.Size = new System.Drawing.Size(123, 220);
            this.leftData.TabIndex = 4;
            this.leftData.SelectionChanged += new System.EventHandler(this.leftData_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(19, 42);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "Обновить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(227, 42);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 49);
            this.button2.TabIndex = 7;
            this.button2.Text = "Проверить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 519);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.leftData);
            this.Controls.Add(this.topData);
            this.Controls.Add(this.imgCross);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imgCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView imgCross;
        private DataGridView topData;
        private DataGridView leftData;
        private Button button1;
        private Button button2;
    }
}