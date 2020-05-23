namespace CourseProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.labelMaxDeformationY = new System.Windows.Forms.Label();
            this.labelMaxDeformationX = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPoissonsRatio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelStresOk = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelStress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.textBoxForce = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxThickness = new System.Windows.Forms.TextBox();
            this.textBoxElasticModulus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonGrid = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxResult.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Деформация",
            "Перемещение по оси Х",
            "Перемещение по оси Y",
            "Напряжение"});
            this.comboBox.Location = new System.Drawing.Point(73, 381);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(126, 21);
            this.comboBox.TabIndex = 35;
            this.comboBox.Visible = false;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(12, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Максимальное напряжение:";
            // 
            // labelMaxDeformationY
            // 
            this.labelMaxDeformationY.AutoSize = true;
            this.labelMaxDeformationY.Location = new System.Drawing.Point(178, 41);
            this.labelMaxDeformationY.Name = "labelMaxDeformationY";
            this.labelMaxDeformationY.Size = new System.Drawing.Size(0, 13);
            this.labelMaxDeformationY.TabIndex = 3;
            // 
            // labelMaxDeformationX
            // 
            this.labelMaxDeformationX.AutoSize = true;
            this.labelMaxDeformationX.Location = new System.Drawing.Point(177, 16);
            this.labelMaxDeformationX.Name = "labelMaxDeformationX";
            this.labelMaxDeformationX.Size = new System.Drawing.Size(0, 13);
            this.labelMaxDeformationX.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Макс. смещене по оси Y:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Макс. смещене по оси X:";
            // 
            // textBoxPoissonsRatio
            // 
            this.textBoxPoissonsRatio.Location = new System.Drawing.Point(179, 119);
            this.textBoxPoissonsRatio.Name = "textBoxPoissonsRatio";
            this.textBoxPoissonsRatio.Size = new System.Drawing.Size(51, 20);
            this.textBoxPoissonsRatio.TabIndex = 20;
            this.textBoxPoissonsRatio.Text = "0,35";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(28, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Коэффициент Пуассона";
            // 
            // labelStresOk
            // 
            this.labelStresOk.AutoSize = true;
            this.labelStresOk.Location = new System.Drawing.Point(152, 93);
            this.labelStresOk.Name = "labelStresOk";
            this.labelStresOk.Size = new System.Drawing.Size(0, 13);
            this.labelStresOk.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(12, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Выдержит ли деталь:";
            // 
            // labelStress
            // 
            this.labelStress.AutoSize = true;
            this.labelStress.Location = new System.Drawing.Point(191, 65);
            this.labelStress.Name = "labelStress";
            this.labelStress.Size = new System.Drawing.Size(0, 13);
            this.labelStress.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(28, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Сила:";
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.labelStresOk);
            this.groupBoxResult.Controls.Add(this.label11);
            this.groupBoxResult.Controls.Add(this.labelStress);
            this.groupBoxResult.Controls.Add(this.label9);
            this.groupBoxResult.Controls.Add(this.labelMaxDeformationY);
            this.groupBoxResult.Controls.Add(this.labelMaxDeformationX);
            this.groupBoxResult.Controls.Add(this.label8);
            this.groupBoxResult.Controls.Add(this.label7);
            this.groupBoxResult.Location = new System.Drawing.Point(14, 193);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(277, 115);
            this.groupBoxResult.TabIndex = 33;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Результаты расчетов";
            this.groupBoxResult.Visible = false;
            // 
            // textBoxForce
            // 
            this.textBoxForce.Location = new System.Drawing.Point(71, 61);
            this.textBoxForce.Name = "textBoxForce";
            this.textBoxForce.Size = new System.Drawing.Size(48, 20);
            this.textBoxForce.TabIndex = 18;
            this.textBoxForce.Text = "-6000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPoissonsRatio);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxForce);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxThickness);
            this.groupBox1.Controls.Add(this.textBoxElasticModulus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 154);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходные данные";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(28, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Модуль упругости:";
            // 
            // textBoxThickness
            // 
            this.textBoxThickness.Location = new System.Drawing.Point(129, 28);
            this.textBoxThickness.Name = "textBoxThickness";
            this.textBoxThickness.Size = new System.Drawing.Size(50, 20);
            this.textBoxThickness.TabIndex = 16;
            this.textBoxThickness.Text = "0,04";
            // 
            // textBoxElasticModulus
            // 
            this.textBoxElasticModulus.Location = new System.Drawing.Point(147, 90);
            this.textBoxElasticModulus.Name = "textBoxElasticModulus";
            this.textBoxElasticModulus.Size = new System.Drawing.Size(57, 20);
            this.textBoxElasticModulus.TabIndex = 18;
            this.textBoxElasticModulus.Text = "110E9";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(26, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Толщина детали:";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.ForeColor = System.Drawing.Color.White;
            this.panel.Location = new System.Drawing.Point(303, 11);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(630, 519);
            this.panel.TabIndex = 34;
            // 
            // buttonSolve
            // 
            this.buttonSolve.Enabled = false;
            this.buttonSolve.Location = new System.Drawing.Point(73, 352);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(126, 23);
            this.buttonSolve.TabIndex = 31;
            this.buttonSolve.Text = "Решение";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // buttonGrid
            // 
            this.buttonGrid.Location = new System.Drawing.Point(73, 323);
            this.buttonGrid.Name = "buttonGrid";
            this.buttonGrid.Size = new System.Drawing.Size(126, 23);
            this.buttonGrid.TabIndex = 30;
            this.buttonGrid.Text = "Построить сетку";
            this.buttonGrid.UseVisualStyleBackColor = true;
            this.buttonGrid.Click += new System.EventHandler(this.buttonGrid_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(950, 541);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.buttonGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Кронштейн";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelMaxDeformationY;
        private System.Windows.Forms.Label labelMaxDeformationX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPoissonsRatio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStresOk;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelStress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.TextBox textBoxForce;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxThickness;
        private System.Windows.Forms.TextBox textBoxElasticModulus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Button buttonGrid;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

