
namespace DHCP_Server_KP_Project
{
    partial class TableRezervingIPForm
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
            this.MainTable = new System.Windows.Forms.DataGridView();
            this.IPAdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmploymentAddresses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeRezervationIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MACclitnts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTable
            // 
            this.MainTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.MainTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IPAdress,
            this.EmploymentAddresses,
            this.TimeRezervationIP,
            this.MACclitnts});
            this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTable.Location = new System.Drawing.Point(0, 30);
            this.MainTable.Name = "MainTable";
            this.MainTable.ReadOnly = true;
            this.MainTable.RowHeadersWidth = 51;
            this.MainTable.RowTemplate.Height = 24;
            this.MainTable.Size = new System.Drawing.Size(800, 420);
            this.MainTable.TabIndex = 1;
            // 
            // IPAdress
            // 
            this.IPAdress.HeaderText = "IP-адрес";
            this.IPAdress.MinimumWidth = 6;
            this.IPAdress.Name = "IPAdress";
            this.IPAdress.ReadOnly = true;
            this.IPAdress.Width = 93;
            // 
            // EmploymentAddresses
            // 
            this.EmploymentAddresses.HeaderText = "Свободность IP";
            this.EmploymentAddresses.MinimumWidth = 6;
            this.EmploymentAddresses.Name = "EmploymentAddresses";
            this.EmploymentAddresses.ReadOnly = true;
            this.EmploymentAddresses.Width = 127;
            // 
            // TimeRezervationIP
            // 
            this.TimeRezervationIP.HeaderText = "Время резервирования, сек";
            this.TimeRezervationIP.MinimumWidth = 6;
            this.TimeRezervationIP.Name = "TimeRezervationIP";
            this.TimeRezervationIP.ReadOnly = true;
            this.TimeRezervationIP.Width = 182;
            // 
            // MACclitnts
            // 
            this.MACclitnts.HeaderText = "MAC-клиента";
            this.MACclitnts.MinimumWidth = 6;
            this.MACclitnts.Name = "MACclitnts";
            this.MACclitnts.ReadOnly = true;
            this.MACclitnts.Width = 125;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // TableRezervingIPForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.MainTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TableRezervingIPForm";
            this.Text = "Таблица занятости IP-адресов";
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView MainTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAdress;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmploymentAddresses;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeRezervationIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACclitnts;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}