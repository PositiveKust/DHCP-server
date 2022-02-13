
namespace DHCP_Server_KP_Project
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.общееToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonStrart = new System.Windows.Forms.Button();
            this.Maintimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIPUse = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownMask = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownTimeRezervation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCountIPAddres = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.таблицаАдрессовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerRezervation = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeRezervation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountIPAddres)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.общееToolStripMenuItem,
            this.таблицаАдрессовToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(291, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // общееToolStripMenuItem
            // 
            this.общееToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.общееToolStripMenuItem.Name = "общееToolStripMenuItem";
            this.общееToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.общееToolStripMenuItem.Text = "Общее";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // ButtonStrart
            // 
            this.ButtonStrart.Location = new System.Drawing.Point(15, 183);
            this.ButtonStrart.Name = "ButtonStrart";
            this.ButtonStrart.Size = new System.Drawing.Size(252, 42);
            this.ButtonStrart.TabIndex = 1;
            this.ButtonStrart.Text = "Запустить сервер";
            this.ButtonStrart.UseVisualStyleBackColor = true;
            this.ButtonStrart.Click += new System.EventHandler(this.Strart_Click);
            // 
            // Maintimer
            // 
            this.Maintimer.Interval = 1000;
            this.Maintimer.Tick += new System.EventHandler(this.Maintimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Начальный IP-адресс \r\nдля использования";
            // 
            // textBoxIPUse
            // 
            this.textBoxIPUse.Location = new System.Drawing.Point(177, 40);
            this.textBoxIPUse.Name = "textBoxIPUse";
            this.textBoxIPUse.Size = new System.Drawing.Size(107, 22);
            this.textBoxIPUse.TabIndex = 3;
            this.textBoxIPUse.Text = "192.168.1.1";
            this.textBoxIPUse.TextChanged += new System.EventHandler(this.textBoxIPUse_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Маска подсети";
            // 
            // numericUpDownMask
            // 
            this.numericUpDownMask.Enabled = false;
            this.numericUpDownMask.InterceptArrowKeys = false;
            this.numericUpDownMask.Location = new System.Drawing.Point(177, 79);
            this.numericUpDownMask.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownMask.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownMask.Name = "numericUpDownMask";
            this.numericUpDownMask.ReadOnly = true;
            this.numericUpDownMask.Size = new System.Drawing.Size(57, 22);
            this.numericUpDownMask.TabIndex = 7;
            this.numericUpDownMask.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 34);
            this.label5.TabIndex = 8;
            this.label5.Text = "Время резервирования \r\nв секундах";
            // 
            // numericUpDownTimeRezervation
            // 
            this.numericUpDownTimeRezervation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownTimeRezervation.Location = new System.Drawing.Point(177, 155);
            this.numericUpDownTimeRezervation.Maximum = new decimal(new int[] {
            65635,
            0,
            0,
            0});
            this.numericUpDownTimeRezervation.Minimum = new decimal(new int[] {
            4100,
            0,
            0,
            0});
            this.numericUpDownTimeRezervation.Name = "numericUpDownTimeRezervation";
            this.numericUpDownTimeRezervation.Size = new System.Drawing.Size(73, 22);
            this.numericUpDownTimeRezervation.TabIndex = 9;
            this.numericUpDownTimeRezervation.Tag = "";
            this.numericUpDownTimeRezervation.Value = new decimal(new int[] {
            25200,
            0,
            0,
            0});
            // 
            // numericUpDownCountIPAddres
            // 
            this.numericUpDownCountIPAddres.Location = new System.Drawing.Point(177, 107);
            this.numericUpDownCountIPAddres.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownCountIPAddres.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownCountIPAddres.Name = "numericUpDownCountIPAddres";
            this.numericUpDownCountIPAddres.Size = new System.Drawing.Size(57, 22);
            this.numericUpDownCountIPAddres.TabIndex = 11;
            this.numericUpDownCountIPAddres.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownCountIPAddres.ValueChanged += new System.EventHandler(this.numericUpDownCountIPAddres_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Размер пула адресов";
            // 
            // таблицаАдрессовToolStripMenuItem
            // 
            this.таблицаАдрессовToolStripMenuItem.Name = "таблицаАдрессовToolStripMenuItem";
            this.таблицаАдрессовToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.таблицаАдрессовToolStripMenuItem.Text = "Таблица адресов";
            this.таблицаАдрессовToolStripMenuItem.Click += new System.EventHandler(this.таблицаАдрессовToolStripMenuItem_Click);
            // 
            // TimerRezervation
            // 
            this.TimerRezervation.Interval = 60000;
            this.TimerRezervation.Tick += new System.EventHandler(this.TimerRezervation_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 235);
            this.Controls.Add(this.numericUpDownCountIPAddres);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownTimeRezervation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownMask);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxIPUse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonStrart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "DHCP-сервер";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeRezervation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountIPAddres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem общееToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button ButtonStrart;
        private System.Windows.Forms.Timer Maintimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIPUse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownMask;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeRezervation;
        private System.Windows.Forms.NumericUpDown numericUpDownCountIPAddres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem таблицаАдрессовToolStripMenuItem;
        private System.Windows.Forms.Timer TimerRezervation;
    }
}

