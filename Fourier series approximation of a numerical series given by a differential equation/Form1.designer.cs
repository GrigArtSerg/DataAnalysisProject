namespace TIPIS_Lab_4_5
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
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
            this.components = new System.ComponentModel.Container();
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.button = new System.Windows.Forms.Button();
            this.A_holder = new System.Windows.Forms.NumericUpDown();
            this.D_Holder = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CoefEnter = new System.Windows.Forms.Label();
            this.DetOtCulc = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.B_holder = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.C_holder = new System.Windows.Forms.NumericUpDown();
            this.PerT = new System.Windows.Forms.Label();
            this.PerTVal = new System.Windows.Forms.Label();
            this.Lab5 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.A_holder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.D_Holder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_holder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_holder)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraph
            // 
            this.zedGraph.Location = new System.Drawing.Point(12, 33);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.ScrollGrace = 0D;
            this.zedGraph.ScrollMaxX = 0D;
            this.zedGraph.ScrollMaxY = 0D;
            this.zedGraph.ScrollMaxY2 = 0D;
            this.zedGraph.ScrollMinX = 0D;
            this.zedGraph.ScrollMinY = 0D;
            this.zedGraph.ScrollMinY2 = 0D;
            this.zedGraph.Size = new System.Drawing.Size(587, 426);
            this.zedGraph.TabIndex = 0;
            this.zedGraph.Load += new System.EventHandler(this.ZedGraph_Load);
            // 
            // button
            // 
            this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button.Location = new System.Drawing.Point(307, 5);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(154, 24);
            this.button.TabIndex = 1;
            this.button.Text = "Рассчитать прогноз";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.Button_Click);
            // 
            // A_holder
            // 
            this.A_holder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.A_holder.Location = new System.Drawing.Point(35, 7);
            this.A_holder.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.A_holder.Name = "A_holder";
            this.A_holder.Size = new System.Drawing.Size(45, 23);
            this.A_holder.TabIndex = 2;
            this.A_holder.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // D_Holder
            // 
            this.D_Holder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.D_Holder.Location = new System.Drawing.Point(258, 7);
            this.D_Holder.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.D_Holder.Name = "D_Holder";
            this.D_Holder.Size = new System.Drawing.Size(43, 23);
            this.D_Holder.TabIndex = 3;
            this.D_Holder.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(234, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "D";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(605, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Коэффициент детерминации:";
            // 
            // CoefEnter
            // 
            this.CoefEnter.AutoSize = true;
            this.CoefEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CoefEnter.Location = new System.Drawing.Point(605, 61);
            this.CoefEnter.Name = "CoefEnter";
            this.CoefEnter.Size = new System.Drawing.Size(48, 17);
            this.CoefEnter.TabIndex = 7;
            this.CoefEnter.Text = "_____";
            // 
            // DetOtCulc
            // 
            this.DetOtCulc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DetOtCulc.Location = new System.Drawing.Point(606, 97);
            this.DetOtCulc.Name = "DetOtCulc";
            this.DetOtCulc.Size = new System.Drawing.Size(187, 52);
            this.DetOtCulc.TabIndex = 8;
            this.DetOtCulc.Text = "Рассчитать корреляцию коэффициента детерминации от количества рассчетных значений" +
    "";
            this.DetOtCulc.UseVisualStyleBackColor = true;
            this.DetOtCulc.Click += new System.EventHandler(this.DetOtCulc_Click);
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Clear.Location = new System.Drawing.Point(608, 433);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(89, 26);
            this.Clear.TabIndex = 9;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Button1_Click);
            // 
            // B_holder
            // 
            this.B_holder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_holder.Location = new System.Drawing.Point(109, 7);
            this.B_holder.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.B_holder.Name = "B_holder";
            this.B_holder.Size = new System.Drawing.Size(45, 23);
            this.B_holder.TabIndex = 10;
            this.B_holder.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(86, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(160, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "C";
            // 
            // C_holder
            // 
            this.C_holder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.C_holder.Location = new System.Drawing.Point(183, 7);
            this.C_holder.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.C_holder.Name = "C_holder";
            this.C_holder.Size = new System.Drawing.Size(45, 23);
            this.C_holder.TabIndex = 12;
            this.C_holder.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // PerT
            // 
            this.PerT.AutoSize = true;
            this.PerT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PerT.Location = new System.Drawing.Point(608, 156);
            this.PerT.Name = "PerT";
            this.PerT.Size = new System.Drawing.Size(62, 17);
            this.PerT.TabIndex = 14;
            this.PerT.Text = "Период:";
            // 
            // PerTVal
            // 
            this.PerTVal.AutoSize = true;
            this.PerTVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PerTVal.Location = new System.Drawing.Point(676, 156);
            this.PerTVal.Name = "PerTVal";
            this.PerTVal.Size = new System.Drawing.Size(64, 17);
            this.PerTVal.TabIndex = 15;
            this.PerTVal.Text = "_______";
            // 
            // Lab5
            // 
            this.Lab5.AutoSize = true;
            this.Lab5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Lab5.Location = new System.Drawing.Point(608, 187);
            this.Lab5.Name = "Lab5";
            this.Lab5.Size = new System.Drawing.Size(119, 21);
            this.Lab5.TabIndex = 16;
            this.Lab5.Text = "До N порядка";
            this.Lab5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 472);
            this.Controls.Add(this.Lab5);
            this.Controls.Add(this.PerTVal);
            this.Controls.Add(this.PerT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.C_holder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.B_holder);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.DetOtCulc);
            this.Controls.Add(this.CoefEnter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.D_Holder);
            this.Controls.Add(this.A_holder);
            this.Controls.Add(this.button);
            this.Controls.Add(this.zedGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.A_holder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.D_Holder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_holder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_holder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private ZedGraph.ZedGraphControl zedGraph;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.NumericUpDown A_holder;
        private System.Windows.Forms.NumericUpDown D_Holder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CoefEnter;
        private System.Windows.Forms.Button DetOtCulc;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.NumericUpDown B_holder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown C_holder;
        private System.Windows.Forms.Label PerT;
        private System.Windows.Forms.Label PerTVal;
        private System.Windows.Forms.CheckBox Lab5;
    }
}

