
namespace COS_Lab_1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.signalChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtSwing = new System.Windows.Forms.TextBox();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.txtPhase = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbbxN = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.cbbxSignal = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbxLimit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.signalChart)).BeginInit();
            this.SuspendLayout();
            // 
            // signalChart
            // 
            chartArea1.Name = "ChartArea1";
            this.signalChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.signalChart.Legends.Add(legend1);
            this.signalChart.Location = new System.Drawing.Point(12, 147);
            this.signalChart.Name = "signalChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.signalChart.Series.Add(series1);
            this.signalChart.Size = new System.Drawing.Size(1245, 482);
            this.signalChart.TabIndex = 0;
            this.signalChart.Text = "chart1";
            // 
            // txtSwing
            // 
            this.txtSwing.Location = new System.Drawing.Point(242, 20);
            this.txtSwing.Name = "txtSwing";
            this.txtSwing.Size = new System.Drawing.Size(158, 22);
            this.txtSwing.TabIndex = 1;
            this.txtSwing.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEnter_KeyDown);
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(428, 20);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(188, 22);
            this.txtFrequency.TabIndex = 2;
            this.txtFrequency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEnter_KeyDown);
            // 
            // txtPhase
            // 
            this.txtPhase.Location = new System.Drawing.Point(636, 20);
            this.txtPhase.Name = "txtPhase";
            this.txtPhase.Size = new System.Drawing.Size(264, 22);
            this.txtPhase.TabIndex = 3;
            this.txtPhase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEnter_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // cbbxN
            // 
            this.cbbxN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxN.FormattingEnabled = true;
            this.cbbxN.Location = new System.Drawing.Point(922, 20);
            this.cbbxN.Name = "cbbxN";
            this.cbbxN.Size = new System.Drawing.Size(121, 24);
            this.cbbxN.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Введите f (частота) (герцы)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Введите A (амплитуда)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Введите φ (начальная фаза)(радианы)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(919, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Выберите N (количество точек)";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1140, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(121, 29);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Сделать хорошо";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(13, 241);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 17);
            this.labelError.TabIndex = 13;
            // 
            // cbbxSignal
            // 
            this.cbbxSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxSignal.FormattingEnabled = true;
            this.cbbxSignal.Location = new System.Drawing.Point(16, 18);
            this.cbbxSignal.Name = "cbbxSignal";
            this.cbbxSignal.Size = new System.Drawing.Size(209, 24);
            this.cbbxSignal.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Введите тип сигнала";
            // 
            // txtbxLimit
            // 
            this.txtbxLimit.Location = new System.Drawing.Point(16, 69);
            this.txtbxLimit.Name = "txtbxLimit";
            this.txtbxLimit.Size = new System.Drawing.Size(209, 22);
            this.txtbxLimit.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Введите ограничение";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1271, 632);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtbxLimit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbbxSignal);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbxN);
            this.Controls.Add(this.txtPhase);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.txtSwing);
            this.Controls.Add(this.signalChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.signalChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart signalChart;
        private System.Windows.Forms.TextBox txtSwing;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.TextBox txtPhase;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox cbbxN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.ComboBox cbbxSignal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbxLimit;
        private System.Windows.Forms.Label label5;
    }
}

