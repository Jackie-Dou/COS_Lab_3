
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.signalChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtSwing = new System.Windows.Forms.TextBox();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.txtPhase = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbbxN = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.chartSwing = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPhase = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.signalChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSwing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhase)).BeginInit();
            this.SuspendLayout();
            // 
            // signalChart
            // 
            this.signalChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.signalChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.signalChart.Legends.Add(legend1);
            this.signalChart.Location = new System.Drawing.Point(12, 73);
            this.signalChart.Name = "signalChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.signalChart.Series.Add(series1);
            this.signalChart.Size = new System.Drawing.Size(1249, 284);
            this.signalChart.TabIndex = 0;
            this.signalChart.Text = "chart1";
            // 
            // txtSwing
            // 
            this.txtSwing.Location = new System.Drawing.Point(16, 32);
            this.txtSwing.Name = "txtSwing";
            this.txtSwing.Size = new System.Drawing.Size(121, 22);
            this.txtSwing.TabIndex = 1;
            this.txtSwing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSwing_KeyPress);
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(205, 32);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(121, 22);
            this.txtFrequency.TabIndex = 2;
            this.txtFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrequency_KeyPress);
            // 
            // txtPhase
            // 
            this.txtPhase.Location = new System.Drawing.Point(413, 32);
            this.txtPhase.Name = "txtPhase";
            this.txtPhase.Size = new System.Drawing.Size(121, 22);
            this.txtPhase.TabIndex = 3;
            this.txtPhase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhase_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1273, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
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
            this.cbbxN.Location = new System.Drawing.Point(703, 32);
            this.cbbxN.Name = "cbbxN";
            this.cbbxN.Size = new System.Drawing.Size(121, 24);
            this.cbbxN.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Введите f (частота) (герцы)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Введите A (амплитуда)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Введите φ (начальная фаза)(радианы)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(700, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Выберите N (количество точек)";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(926, 25);
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
            // chartSwing
            // 
            this.chartSwing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartSwing.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSwing.Legends.Add(legend2);
            this.chartSwing.Location = new System.Drawing.Point(12, 401);
            this.chartSwing.Name = "chartSwing";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSwing.Series.Add(series2);
            this.chartSwing.Size = new System.Drawing.Size(604, 300);
            this.chartSwing.TabIndex = 14;
            this.chartSwing.Text = "chart1";
            // 
            // chartPhase
            // 
            this.chartPhase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chartPhase.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartPhase.Legends.Add(legend3);
            this.chartPhase.Location = new System.Drawing.Point(636, 401);
            this.chartPhase.Name = "chartPhase";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartPhase.Series.Add(series3);
            this.chartPhase.Size = new System.Drawing.Size(625, 300);
            this.chartPhase.TabIndex = 15;
            this.chartPhase.Text = "chart2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 380);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Амплитуда";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(633, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Фаза";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 713);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chartPhase);
            this.Controls.Add(this.chartSwing);
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
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.signalChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSwing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart signalChart;
        private System.Windows.Forms.TextBox txtSwing;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.TextBox txtPhase;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox cbbxN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSwing;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

