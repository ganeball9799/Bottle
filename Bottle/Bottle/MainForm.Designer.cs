
namespace Bottle
{
    partial class MainForm
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
            this.StartKompasButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SetDataButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BuildButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.BottleneckDiameterTextBox = new System.Windows.Forms.TextBox();
            this.BaseDiameterTextBox = new System.Windows.Forms.TextBox();
            this.BottleneckLengthTextBox = new System.Windows.Forms.TextBox();
            this.BaseLengthTextBox = new System.Windows.Forms.TextBox();
            this.LengthFullBottleTextBox = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartKompasButton
            // 
            this.StartKompasButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartKompasButton.Location = new System.Drawing.Point(6, 7);
            this.StartKompasButton.Name = "StartKompasButton";
            this.StartKompasButton.Size = new System.Drawing.Size(285, 40);
            this.StartKompasButton.TabIndex = 3;
            this.StartKompasButton.Text = "Запустить Компас";
            this.StartKompasButton.UseVisualStyleBackColor = true;
            this.StartKompasButton.Click += new System.EventHandler(this.StartKompasButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.SetDataButton);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.BuildButton);
            this.panel2.Controls.Add(this.ClearButton);
            this.panel2.Controls.Add(this.BottleneckDiameterTextBox);
            this.panel2.Controls.Add(this.BaseDiameterTextBox);
            this.panel2.Controls.Add(this.BottleneckLengthTextBox);
            this.panel2.Controls.Add(this.BaseLengthTextBox);
            this.panel2.Controls.Add(this.LengthFullBottleTextBox);
            this.panel2.Location = new System.Drawing.Point(6, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 305);
            this.panel2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(3, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "(от 25 до 65 мм)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "(от 101 до 250 мм)";
            // 
            // SetDataButton
            // 
            this.SetDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SetDataButton.Location = new System.Drawing.Point(12, 224);
            this.SetDataButton.Name = "SetDataButton";
            this.SetDataButton.Size = new System.Drawing.Size(112, 30);
            this.SetDataButton.TabIndex = 2;
            this.SetDataButton.Text = "Заполнить поля";
            this.SetDataButton.UseVisualStyleBackColor = true;
            this.SetDataButton.Click += new System.EventHandler(this.SetDataButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Диаметр горлышка(мм)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Диаметр основания(мм)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Высота горлышка(мм)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Высота основания(мм)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Высота бутылки(мм)";
            // 
            // BuildButton
            // 
            this.BuildButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BuildButton.Location = new System.Drawing.Point(162, 224);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(123, 65);
            this.BuildButton.TabIndex = 2;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.Location = new System.Drawing.Point(12, 259);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(112, 30);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // BottleneckDiameterTextBox
            // 
            this.BottleneckDiameterTextBox.Location = new System.Drawing.Point(165, 176);
            this.BottleneckDiameterTextBox.Name = "BottleneckDiameterTextBox";
            this.BottleneckDiameterTextBox.Size = new System.Drawing.Size(120, 20);
            this.BottleneckDiameterTextBox.TabIndex = 6;
            this.BottleneckDiameterTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // BaseDiameterTextBox
            // 
            this.BaseDiameterTextBox.Location = new System.Drawing.Point(165, 136);
            this.BaseDiameterTextBox.Name = "BaseDiameterTextBox";
            this.BaseDiameterTextBox.Size = new System.Drawing.Size(120, 20);
            this.BaseDiameterTextBox.TabIndex = 5;
            this.BaseDiameterTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // BottleneckLengthTextBox
            // 
            this.BottleneckLengthTextBox.Location = new System.Drawing.Point(165, 97);
            this.BottleneckLengthTextBox.Name = "BottleneckLengthTextBox";
            this.BottleneckLengthTextBox.Size = new System.Drawing.Size(120, 20);
            this.BottleneckLengthTextBox.TabIndex = 4;
            this.BottleneckLengthTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // BaseLengthTextBox
            // 
            this.BaseLengthTextBox.Location = new System.Drawing.Point(165, 55);
            this.BaseLengthTextBox.Name = "BaseLengthTextBox";
            this.BaseLengthTextBox.Size = new System.Drawing.Size(120, 20);
            this.BaseLengthTextBox.TabIndex = 3;
            this.BaseLengthTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // LengthFullBottleTextBox
            // 
            this.LengthFullBottleTextBox.Location = new System.Drawing.Point(165, 15);
            this.LengthFullBottleTextBox.Name = "LengthFullBottleTextBox";
            this.LengthFullBottleTextBox.Size = new System.Drawing.Size(120, 20);
            this.LengthFullBottleTextBox.TabIndex = 2;
            this.LengthFullBottleTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(297, 360);
            this.Controls.Add(this.StartKompasButton);
            this.Controls.Add(this.panel2);
            this.Name = "MainForm";
            this.Text = "Компас-3D:Плагин Бутылка";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StartKompasButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SetDataButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox BottleneckDiameterTextBox;
        private System.Windows.Forms.TextBox BaseDiameterTextBox;
        private System.Windows.Forms.TextBox BottleneckLengthTextBox;
        private System.Windows.Forms.TextBox BaseLengthTextBox;
        private System.Windows.Forms.TextBox LengthFullBottleTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
    }
}

