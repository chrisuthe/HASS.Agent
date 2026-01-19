
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms.Service
{
    partial class ServiceConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceConfig));
            this.PnlTabs = new System.Windows.Forms.Panel();
            this.ServiceTabs = new System.Windows.Forms.TabControl();
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.TabMqtt = new System.Windows.Forms.TabPage();
            this.TabCommands = new System.Windows.Forms.TabPage();
            this.TabSensors = new System.Windows.Forms.TabPage();
            this.PnlTabs.SuspendLayout();
            this.ServiceTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTabs
            // 
            this.PnlTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlTabs.Controls.Add(this.ServiceTabs);
            this.PnlTabs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PnlTabs.Location = new System.Drawing.Point(0, 6);
            this.PnlTabs.Name = "PnlTabs";
            this.PnlTabs.Size = new System.Drawing.Size(909, 653);
            this.PnlTabs.TabIndex = 42;
            // 
            // ServiceTabs
            //
            this.ServiceTabs.AccessibleDescription = "Various tabs for configuring the satellite service.";
            this.ServiceTabs.AccessibleName = "Tabs";
            this.ServiceTabs.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.ServiceTabs.Controls.Add(this.TabGeneral);
            this.ServiceTabs.Controls.Add(this.TabMqtt);
            this.ServiceTabs.Controls.Add(this.TabCommands);
            this.ServiceTabs.Controls.Add(this.TabSensors);
            this.ServiceTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServiceTabs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServiceTabs.Location = new System.Drawing.Point(0, 0);
            this.ServiceTabs.Name = "ServiceTabs";
            this.ServiceTabs.Size = new System.Drawing.Size(907, 651);
            this.ServiceTabs.TabIndex = 0;
            // 
            // TabGeneral
            //
            this.TabGeneral.AccessibleDescription = "Contains the \'general configuration\' controls.";
            this.TabGeneral.AccessibleName = "General";
            this.TabGeneral.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.TabGeneral.AutoScroll = true;
            this.TabGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabGeneral.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabGeneral.Location = new System.Drawing.Point(4, 28);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Size = new System.Drawing.Size(899, 619);
            this.TabGeneral.TabIndex = 0;
            this.TabGeneral.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceConfig_TabGeneral;
            // 
            // TabMqtt
            //
            this.TabMqtt.AccessibleDescription = "Contains the \'mqtt configuration\' controls.";
            this.TabMqtt.AccessibleName = "MQTT";
            this.TabMqtt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabMqtt.Location = new System.Drawing.Point(4, 28);
            this.TabMqtt.Name = "TabMqtt";
            this.TabMqtt.Size = new System.Drawing.Size(899, 619);
            this.TabMqtt.TabIndex = 1;
            this.TabMqtt.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceConfig_TabMqtt;
            // 
            // TabCommands
            //
            this.TabCommands.AccessibleDescription = "Contains the \'commands\' controls.";
            this.TabCommands.AccessibleName = "Commands";
            this.TabCommands.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.TabCommands.AutoScroll = true;
            this.TabCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabCommands.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabCommands.Location = new System.Drawing.Point(4, 28);
            this.TabCommands.Name = "TabCommands";
            this.TabCommands.Size = new System.Drawing.Size(899, 619);
            this.TabCommands.TabIndex = 2;
            this.TabCommands.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceConfig_TabCommands;
            // 
            // TabSensors
            //
            this.TabSensors.AccessibleDescription = "Contains the \'sensors\' controls.";
            this.TabSensors.AccessibleName = "Sensors";
            this.TabSensors.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTab;
            this.TabSensors.AutoScroll = true;
            this.TabSensors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabSensors.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabSensors.Location = new System.Drawing.Point(4, 28);
            this.TabSensors.Name = "TabSensors";
            this.TabSensors.Size = new System.Drawing.Size(899, 619);
            this.TabSensors.TabIndex = 3;
            this.TabSensors.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceConfig_TabSensors;
            // 
            // ServiceConfig
            // 
            this.AccessibleDescription = "Contains the various configuration panels for the satellite service.";
            this.AccessibleName = "Satellite service config";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(909, 660);
            this.Controls.Add(this.PnlTabs);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(657, 598);
            this.Name = "ServiceConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.ServiceConfig_Title;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SensorsConfig_FormClosing);
            this.Load += new System.EventHandler(this.ServiceConfig_Load);
            this.ResizeEnd += new System.EventHandler(this.SensorsConfig_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SensorsConfig_KeyUp);
            this.PnlTabs.ResumeLayout(false);
            this.ServiceTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel PnlTabs;
        private System.Windows.Forms.TabControl ServiceTabs;
        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.TabPage TabSensors;
        private System.Windows.Forms.TabPage TabCommands;
        private System.Windows.Forms.TabPage TabMqtt;
    }
}

