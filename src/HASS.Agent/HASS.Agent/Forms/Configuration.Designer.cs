using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.MenuList = new System.Windows.Forms.ListBox();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.BtnHelp = new System.Windows.Forms.Button();
            this.BtnStore = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // MenuList
            //
            this.MenuList.AccessibleDescription = "Navigation menu for configuration sections.";
            this.MenuList.AccessibleName = "Configuration menu";
            this.MenuList.AccessibleRole = System.Windows.Forms.AccessibleRole.List;
            this.MenuList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.MenuList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MenuList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MenuList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.MenuList.FormattingEnabled = true;
            this.MenuList.IntegralHeight = false;
            this.MenuList.ItemHeight = 32;
            this.MenuList.Location = new System.Drawing.Point(0, 0);
            this.MenuList.Name = "MenuList";
            this.MenuList.Size = new System.Drawing.Size(180, 550);
            this.MenuList.TabIndex = 0;
            this.MenuList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.MenuList_DrawItem);
            this.MenuList.SelectedIndexChanged += new System.EventHandler(this.MenuList_SelectedIndexChanged);
            //
            // ContentPanel
            //
            this.ContentPanel.AccessibleDescription = "Contains the configuration controls for the selected section.";
            this.ContentPanel.AccessibleName = "Configuration content";
            this.ContentPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ContentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContentPanel.Location = new System.Drawing.Point(180, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(706, 550);
            this.ContentPanel.TabIndex = 1;
            //
            // BtnAbout
            //
            this.BtnAbout.AccessibleDescription = "Opens the about window.";
            this.BtnAbout.AccessibleName = "About";
            this.BtnAbout.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAbout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Location = new System.Drawing.Point(-1, 556);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(172, 31);
            this.BtnAbout.TabIndex = 3;
            this.BtnAbout.Text = Languages.Configuration_BtnAbout;
            this.BtnAbout.UseVisualStyleBackColor = false;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            //
            // BtnHelp
            //
            this.BtnHelp.AccessibleDescription = "Opens the help and contact window.";
            this.BtnHelp.AccessibleName = "Help";
            this.BtnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHelp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Location = new System.Drawing.Point(177, 556);
            this.BtnHelp.Name = "BtnHelp";
            this.BtnHelp.Size = new System.Drawing.Size(172, 31);
            this.BtnHelp.TabIndex = 2;
            this.BtnHelp.Text = Languages.Configuration_BtnHelp;
            this.BtnHelp.UseVisualStyleBackColor = false;
            this.BtnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            //
            // BtnStore
            //
            this.BtnStore.AccessibleDescription = "Saves your settings and closes the window. Might show a messagebox with additiona" +
    "l info.";
            this.BtnStore.AccessibleName = "Save and close";
            this.BtnStore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(533, 556);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(352, 31);
            this.BtnStore.TabIndex = 0;
            this.BtnStore.Text = Languages.Configuration_BtnStore;
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            //
            // BtnClose
            //
            this.BtnClose.AccessibleDescription = "Closes the window without saving your changes.";
            this.BtnClose.AccessibleName = "Close no save";
            this.BtnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Location = new System.Drawing.Point(355, 556);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(172, 31);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Text = Languages.Configuration_BtnClose;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            //
            // Configuration
            //
            this.AccessibleDescription = "Contains the various configuration panels for HASS.Agent.";
            this.AccessibleName = "Configuration";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(886, 588);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.MenuList);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.BtnHelp);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.Configuration_Title;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configuration_FormClosing);
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.ResizeEnd += new System.EventHandler(this.Configuration_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Configuration_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox MenuList;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.Button BtnHelp;
        private System.Windows.Forms.Button BtnStore;
        private System.Windows.Forms.Button BtnClose;
    }
}
