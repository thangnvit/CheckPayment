namespace WindowsFormsApplication1
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
            this.btnopen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cmbSelect = new System.Windows.Forms.GroupBox();
            this.cmbAmOrPm = new System.Windows.Forms.ComboBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnTongHop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnopen
            // 
            this.btnopen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnopen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnopen.ForeColor = System.Drawing.Color.Black;
            this.btnopen.Location = new System.Drawing.Point(354, 138);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(130, 53);
            this.btnopen.TabIndex = 2;
            this.btnopen.Text = "Check File Thanh Toán ";
            this.btnopen.UseVisualStyleBackColor = true;
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmbSelect
            // 
            this.cmbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSelect.Controls.Add(this.btnThanhToan);
            this.cmbSelect.Controls.Add(this.btnTongHop);
            this.cmbSelect.Location = new System.Drawing.Point(33, 88);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(182, 138);
            this.cmbSelect.TabIndex = 3;
            this.cmbSelect.TabStop = false;
            this.cmbSelect.Text = "Thêm File :";
            // 
            // cmbAmOrPm
            // 
            this.cmbAmOrPm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAmOrPm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmOrPm.FormattingEnabled = true;
            this.cmbAmOrPm.Items.AddRange(new object[] {
            "Sáng",
            "Chiều"});
            this.cmbAmOrPm.Location = new System.Drawing.Point(230, 33);
            this.cmbAmOrPm.Name = "cmbAmOrPm";
            this.cmbAmOrPm.Size = new System.Drawing.Size(112, 21);
            this.cmbAmOrPm.TabIndex = 1;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.ForeColor = System.Drawing.Color.Black;
            this.btnThanhToan.Location = new System.Drawing.Point(42, 93);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(94, 23);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "File Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnTongHop
            // 
            this.btnTongHop.ForeColor = System.Drawing.Color.Black;
            this.btnTongHop.Location = new System.Drawing.Point(42, 38);
            this.btnTongHop.Name = "btnTongHop";
            this.btnTongHop.Size = new System.Drawing.Size(94, 23);
            this.btnTongHop.TabIndex = 0;
            this.btnTongHop.Text = "FIle Tổng Hợp";
            this.btnTongHop.UseVisualStyleBackColor = true;
            this.btnTongHop.Click += new System.EventHandler(this.btnTongHop_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mời bạn chọn thời gian nhập file:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 299);
            this.Controls.Add(this.btnopen);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.cmbAmOrPm);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Gray;
            this.Name = "Form1";
            this.Text = "Quản Lý";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmbSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnopen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox cmbSelect;
        private System.Windows.Forms.ComboBox cmbAmOrPm;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnTongHop;
        private System.Windows.Forms.Label label1;
    }
}

