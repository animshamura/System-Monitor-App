using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SysMonitorApp
{
    public partial class Form1 : Form
    {
        private PerformanceCounter? cpuCounter;
        private PerformanceCounter? ramCounter;
        private BindingList<ProcessModel> processList = new BindingList<ProcessModel>();

        public Form1()
        {
            InitializeComponent();
            InitializeTelemetry();
            SetupGrid();
            LoadProcesses();
        }

        private void InitializeTelemetry()
        {
            try
            {
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Performance Counter Error: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupGrid()
        {
            dgvProcesses.DataSource = processList;
            dgvProcesses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProcesses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProcesses.MultiSelect = false;

            if (dgvProcesses.Columns["MemoryMB"] is DataGridViewColumn memoryColumn)
            {
                memoryColumn.DefaultCellStyle.Format = "N2";
                memoryColumn.HeaderText = "Memory (MB)";
            }
        }

        // Timer Tick: Telemetry update every 1 second
        private void timerMonitor_Tick(object sender, EventArgs e)
        {
            if (cpuCounter == null || ramCounter == null) return;

            try
            {
                float cpu = cpuCounter.NextValue();
                float ram = ramCounter.NextValue();

                lblCpu.Text = $"CPU Usage: {cpu:F1}%";
                pbCpu.Value = Math.Min(100, Math.Max(0, (int)cpu));
                lblRam.Text = $"Available RAM: {ram:N0} MB";
            }
            catch
            {
                // Silently ignore transient performance counter delays
            }
        }

        // Load and Filter Process List
        private void LoadProcesses()
        {
            string searchFilter = txtSearch.Text.Trim().ToLower();
            Process[] activeProcesses = Process.GetProcesses();

            var filtered = activeProcesses
                .Where(p => string.IsNullOrEmpty(searchFilter) || p.ProcessName.ToLower().Contains(searchFilter))
                .Select(p =>
                {
                    double mem = 0;
                    try { mem = p.WorkingSet64 / (1024.0 * 1024.0); } catch { }
                    return new ProcessModel(p.Id, p.ProcessName, mem);
                })
                .OrderByDescending(p => p.MemoryMB)
                .ToList();

            processList.Clear();
            foreach (var item in filtered)
            {
                processList.Add(item);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (dgvProcesses.CurrentRow == null)
            {
                MessageBox.Show("Please select a process from the list.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ProcessModel? selected = dgvProcesses.CurrentRow.DataBoundItem as ProcessModel;
            if (selected == null) return;

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to end '{selected.Name}' (PID: {selected.Id})?",
                "Confirm End Task",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    Process target = Process.GetProcessById(selected.Id);
                    target.Kill();
                    MessageBox.Show($"Successfully terminated '{selected.Name}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProcesses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not terminate process: {ex.Message}", "Access Denied / Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}