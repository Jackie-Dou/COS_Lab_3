
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
            this.btNoFilter = new System.Windows.Forms.RadioButton();
            this.btBlurFilter = new System.Windows.Forms.RadioButton();
            this.btSharpnessFilter = new System.Windows.Forms.RadioButton();
            this.btEmbossingFilter = new System.Windows.Forms.RadioButton();
            this.btEdgeDetectionFilter = new System.Windows.Forms.RadioButton();
            this.btApplyFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picbxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxImageRestore)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(1041, 531);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(181, 28);
            this.btnLoadImage.TabIndex = 1;
            this.btnLoadImage.Text = "Загрузить изображение";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // picbxImage
            // 
            this.picbxImage.Location = new System.Drawing.Point(12, 12);
            this.picbxImage.Name = "picbxImage";
            this.picbxImage.Size = new System.Drawing.Size(584, 506);
            this.picbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbxImage.TabIndex = 2;
            this.picbxImage.TabStop = false;
            // 
            // picbxImageRestore
            // 
            this.picbxImageRestore.Location = new System.Drawing.Point(638, 12);
            this.picbxImageRestore.Name = "picbxImageRestore";
            this.picbxImageRestore.Size = new System.Drawing.Size(584, 506);
            this.picbxImageRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbxImageRestore.TabIndex = 3;
            this.picbxImageRestore.TabStop = false;
            // 
            // btNoFilter
            // 
            this.btNoFilter.AutoSize = true;
            this.btNoFilter.Location = new System.Drawing.Point(12, 535);
            this.btNoFilter.Name = "btNoFilter";
            this.btNoFilter.Size = new System.Drawing.Size(116, 21);
            this.btNoFilter.TabIndex = 5;
            this.btNoFilter.TabStop = true;
            this.btNoFilter.Text = "Без Фильтра";
            this.btNoFilter.UseVisualStyleBackColor = true;
            this.btNoFilter.CheckedChanged += new System.EventHandler(this.btNoFilter_CheckedChanged);
            // 
            // btBlurFilter
            // 
            this.btBlurFilter.AutoSize = true;
            this.btBlurFilter.Location = new System.Drawing.Point(134, 535);
            this.btBlurFilter.Name = "btBlurFilter";
            this.btBlurFilter.Size = new System.Drawing.Size(95, 21);
            this.btBlurFilter.TabIndex = 6;
            this.btBlurFilter.TabStop = true;
            this.btBlurFilter.Text = "Размытие";
            this.btBlurFilter.UseVisualStyleBackColor = true;
            this.btBlurFilter.CheckedChanged += new System.EventHandler(this.btBlurFilter_CheckedChanged);
            // 
            // btSharpnessFilter
            // 
            this.btSharpnessFilter.AutoSize = true;
            this.btSharpnessFilter.Location = new System.Drawing.Point(283, 535);
            this.btSharpnessFilter.Name = "btSharpnessFilter";
            this.btSharpnessFilter.Size = new System.Drawing.Size(89, 21);
            this.btSharpnessFilter.TabIndex = 7;
            this.btSharpnessFilter.TabStop = true;
            this.btSharpnessFilter.Text = "Резкость";
            this.btSharpnessFilter.UseVisualStyleBackColor = true;
            this.btSharpnessFilter.CheckedChanged += new System.EventHandler(this.btSharpnessFilter_CheckedChanged);
            // 
            // btEmbossingFilter
            // 
            this.btEmbossingFilter.AutoSize = true;
            this.btEmbossingFilter.Location = new System.Drawing.Point(405, 535);
            this.btEmbossingFilter.Name = "btEmbossingFilter";
            this.btEmbossingFilter.Size = new System.Drawing.Size(96, 21);
            this.btEmbossingFilter.TabIndex = 8;
            this.btEmbossingFilter.TabStop = true;
            this.btEmbossingFilter.Text = "Трафарет";
            this.btEmbossingFilter.UseVisualStyleBackColor = true;
            this.btEmbossingFilter.CheckedChanged += new System.EventHandler(this.btEmbossingFilter_CheckedChanged);
            // 
            // btEdgeDetectionFilter
            // 
            this.btEdgeDetectionFilter.AutoSize = true;
            this.btEdgeDetectionFilter.Location = new System.Drawing.Point(548, 535);
            this.btEdgeDetectionFilter.Name = "btEdgeDetectionFilter";
            this.btEdgeDetectionFilter.Size = new System.Drawing.Size(87, 21);
            this.btEdgeDetectionFilter.TabIndex = 9;
            this.btEdgeDetectionFilter.TabStop = true;
            this.btEdgeDetectionFilter.Text = "Границы";
            this.btEdgeDetectionFilter.UseVisualStyleBackColor = true;
            this.btEdgeDetectionFilter.CheckedChanged += new System.EventHandler(this.btEdgeDetectionFilter_CheckedChanged);
            // 
            // btApplyFilter
            // 
            this.btApplyFilter.Location = new System.Drawing.Point(810, 531);
            this.btApplyFilter.Name = "btApplyFilter";
            this.btApplyFilter.Size = new System.Drawing.Size(181, 28);
            this.btApplyFilter.TabIndex = 10;
            this.btApplyFilter.Text = "Применить фильтр";
            this.btApplyFilter.UseVisualStyleBackColor = true;
            this.btApplyFilter.Click += new System.EventHandler(this.btApplyFilter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 571);
            this.Controls.Add(this.btApplyFilter);
            this.Controls.Add(this.btEdgeDetectionFilter);
            this.Controls.Add(this.btEmbossingFilter);
            this.Controls.Add(this.btSharpnessFilter);
            this.Controls.Add(this.btBlurFilter);
            this.Controls.Add(this.btNoFilter);
            this.Controls.Add(this.picbxImageRestore);
            this.Controls.Add(this.picbxImage);
            this.Controls.Add(this.btnLoadImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picbxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbxImageRestore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.PictureBox picbxImage;
        private System.Windows.Forms.PictureBox picbxImageRestore;
        private System.Windows.Forms.RadioButton btNoFilter;
        private System.Windows.Forms.RadioButton btBlurFilter;
        private System.Windows.Forms.RadioButton btSharpnessFilter;
        private System.Windows.Forms.RadioButton btEmbossingFilter;
        private System.Windows.Forms.RadioButton btEdgeDetectionFilter;
        private System.Windows.Forms.Button btApplyFilter;
    }
}

