namespace TIPIS_Lab_8_9
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
            this.lenForX = new System.Windows.Forms.NumericUpDown();
            this.lenForY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.lab9 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.lenForX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lenForY)).BeginInit();
            this.SuspendLayout();
            // 
            // lenForX
            // 
            this.lenForX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lenForX.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lenForX.Location = new System.Drawing.Point(158, 32);
            this.lenForX.Maximum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.lenForX.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.lenForX.Name = "lenForX";
            this.lenForX.Size = new System.Drawing.Size(120, 26);
            this.lenForX.TabIndex = 0;
            this.lenForX.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // lenForY
            // 
            this.lenForY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lenForY.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lenForY.Location = new System.Drawing.Point(158, 83);
            this.lenForY.Maximum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.lenForY.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.lenForY.Name = "lenForY";
            this.lenForY.Size = new System.Drawing.Size(120, 26);
            this.lenForY.TabIndex = 1;
            this.lenForY.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ширина по оси X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ширина по оси Y";
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Start.Location = new System.Drawing.Point(332, 52);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(120, 28);
            this.Start.TabIndex = 4;
            this.Start.Text = "Рассчитать";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // lab9
            // 
            this.lab9.AutoSize = true;
            this.lab9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab9.Location = new System.Drawing.Point(230, 136);
            this.lab9.Name = "lab9";
            this.lab9.Size = new System.Drawing.Size(222, 24);
            this.lab9.TabIndex = 8;
            this.lab9.Text = "Рассчитать до порядка n";
            this.lab9.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(608, 250);
            this.Controls.Add(this.lab9);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lenForY);
            this.Controls.Add(this.lenForX);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.lenForX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lenForY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown lenForX;
        private System.Windows.Forms.NumericUpDown lenForY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.CheckBox lab9;
    }
}

