namespace SysMonitorApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.ProgressBar pbCpu;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.Timer timerMonitor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCpu = new System.Windows.Forms.Label();
            this.pbCpu = new System.Windows.Forms.ProgressBar();
            this.lblRam = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnKill = new System.Windows.Forms.Button();
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).BeginInit();
            this.SuspendLayout();

            // lblCpu
            this.lblCpu.AutoSize = true;
            this.lblCpu.Location = new System.Drawing.Point(12, 15);
            this.lblCpu.Text = "CPU Usage: 0%";

            // pbCpu
            this.pbCpu.Location = new System.Drawing.Point(130, 12);
            this.pbCpu.Size = new System.Drawing.Size(250, 20);

            // lblRam
            this.lblRam.AutoSize = true;
            this.lblRam.Location = new System.Drawing.Point(400, 15);
            this.lblRam.Text = "Available RAM: 0 MB";

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 50);
            this.lblSearch.Text = "Search Process:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(105, 47);
            this.txtSearch.Size = new System.Drawing.Size(200, 22);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(320, 45);
            this.btnRefresh.Size = new System.Drawing.Size(100, 26);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnKill
            this.btnKill.Location = new System.Drawing.Point(430, 45);
            this.btnKill.Size = new System.Drawing.Size(100, 26);
            this.btnKill.Text = "End Task";
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);

            // dgvProcesses
            this.dgvProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProcesses.Location = new System.Drawing.Point(12, 85);
            this.dgvProcesses.Size = new System.Drawing.Size(760, 345);

            // timerMonitor
            this.timerMonitor.Enabled = true;
            this.timerMonitor.Interval = 1000;
            this.timerMonitor.Tick += new System.EventHandler(this.timerMonitor_Tick);

            // Form1
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.lblCpu);
            this.Controls.Add(this.pbCpu);
            this.Controls.Add(this.lblRam);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.dgvProcesses);
            this.Text = "System Telemetry & Process Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}