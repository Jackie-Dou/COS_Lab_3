
namespace COS_Lab_3_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.picbxImage = new System.Windows.Forms.PictureBox();
            this.picbxImageRestore = new System.Windows.Forms.PictureBox();
            this.btApplyFilter = new System.Windows.Forms.Button();
            this.cbbxFilters = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxImageRestore)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(218, 12);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(181, 24);
            this.btnLoadImage.TabIndex = 1;
            this.btnLoadImage.Text = "Загрузить изображение";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // picbxImage
            // 
            this.picbxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbxImage.Location = new System.Drawing.Point(12, 61);
            this.picbxImage.Name = "picbxImage";
            this.picbxImage.Size = new System.Drawing.Size(584, 506);
            this.picbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbxImage.TabIndex = 2;
            this.picbxImage.TabStop = false;
            // 
            // picbxImageRestore
            // 
            this.picbxImageRestore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbxImageRestore.Location = new System.Drawing.Point(618, 61);
            this.picbxImageRestore.Name = "picbxImageRestore";
            this.picbxImageRestore.Size = new System.Drawing.Size(584, 506);
            this.picbxImageRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbxImageRestore.TabIndex = 3;
            this.picbxImageRestore.TabStop = false;
            // 
            // btApplyFilter
            // 
            this.btApplyFilter.Location = new System.Drawing.Point(405, 12);
            this.btApplyFilter.Name = "btApplyFilter";
            this.btApplyFilter.Size = new System.Drawing.Size(181, 24);
            this.btApplyFilter.TabIndex = 10;
            this.btApplyFilter.Text = "Применить фильтр";
            this.btApplyFilter.UseVisualStyleBackColor = true;
            this.btApplyFilter.Click += new System.EventHandler(this.btApplyFilter_Click);
            // 
            // cbbxFilters
            // 
            this.cbbxFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxFilters.FormattingEnabled = true;
            this.cbbxFilters.Location = new System.Drawing.Point(12, 12);
            this.cbbxFilters.Name = "cbbxFilters";
            this.cbbxFilters.Size = new System.Drawing.Size(191, 24);
            this.cbbxFilters.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 580);
            this.Controls.Add(this.cbbxFilters);
            this.Controls.Add(this.btApplyFilter);
            this.Controls.Add(this.picbxImageRestore);
            this.Controls.Add(this.picbxImage);
            this.Controls.Add(this.btnLoadImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picbxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxImageRestore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.PictureBox picbxImage;
        private System.Windows.Forms.PictureBox picbxImageRestore;
        private System.Windows.Forms.Button btApplyFilter;
        private System.Windows.Forms.ComboBox cbbxFilters;
    }
}

