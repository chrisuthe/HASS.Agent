using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigTrayIcon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LblInfo1 = new Label();
            CbUseModernIcon = new CheckBox();
            CbDefaultMenu = new CheckBox();
            CbShowWebView = new CheckBox();
            TbWebViewUrl = new TextBox();
            LblWebViewUrl = new Label();
            LblX = new Label();
            LblWebViewSize = new Label();
            BtnShowWebViewPreview = new System.Windows.Forms.Button();
            NumWebViewWidth = new System.Windows.Forms.NumericUpDown();
            NumWebViewHeight = new System.Windows.Forms.NumericUpDown();
            BtnWebViewReset = new System.Windows.Forms.Button();
            CbWebViewKeepLoaded = new CheckBox();
            LblInfo2 = new Label();
            CbWebViewShowMenuOnLeftClick = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)NumWebViewWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumWebViewHeight).BeginInit();
            SuspendLayout();
            // 
            // LblInfo1
            // 
            LblInfo1.AccessibleDescription = "Tray icon information.";
            LblInfo1.AccessibleName = "Information";
            LblInfo1.AccessibleRole = AccessibleRole.StaticText;
            LblInfo1.Font = new Font("Segoe UI", 10F);
            LblInfo1.Location = new Point(70, 102);
            LblInfo1.Name = "LblInfo1";
            LblInfo1.Size = new Size(541, 36);
            LblInfo1.TabIndex = 31;
            LblInfo1.Text = "Control the behaviour of the tray icon when it is right-clicked.";
            // 
            // CbUseModernIcon
            // 
            CbUseModernIcon.AccessibleDescription = "If enabled, modern white and transparent icon will be used";
            CbUseModernIcon.AccessibleName = "Use modern icon";
            CbUseModernIcon.AccessibleRole = AccessibleRole.CheckButton;
            CbUseModernIcon.AutoSize = true;
            CbUseModernIcon.Font = new Font("Segoe UI", 10F);
            CbUseModernIcon.Location = new Point(70, 42);
            CbUseModernIcon.Name = "CbUseModernIcon";
            CbUseModernIcon.Size = new Size(160, 23);
            CbUseModernIcon.TabIndex = 50;
            CbUseModernIcon.Text = Languages.ConfigTrayIcon_CbUseModernIcon;
            CbUseModernIcon.UseVisualStyleBackColor = true;
            // 
            // CbDefaultMenu
            // 
            CbDefaultMenu.AccessibleDescription = "If enabled, right clicking the system tray icon will show the default menu.";
            CbDefaultMenu.AccessibleName = "Show default menu";
            CbDefaultMenu.AccessibleRole = AccessibleRole.CheckButton;
            CbDefaultMenu.AutoSize = true;
            CbDefaultMenu.Checked = true;
            CbDefaultMenu.CheckState = CheckState.Checked;
            CbDefaultMenu.Font = new Font("Segoe UI", 10F);
            CbDefaultMenu.Location = new Point(70, 141);
            CbDefaultMenu.Name = "CbDefaultMenu";
            CbDefaultMenu.Size = new Size(149, 23);
            CbDefaultMenu.TabIndex = 0;
            CbDefaultMenu.Text = Languages.ConfigTrayIcon_CbDefaultMenu;
            CbDefaultMenu.UseVisualStyleBackColor = true;
            CbDefaultMenu.CheckedChanged += CbDefaultMenu_CheckedChanged;
            // 
            // CbShowWebView
            // 
            CbShowWebView.AccessibleDescription = "If enabled, right clicking the system tray icon will show a webview with the url you provide.";
            CbShowWebView.AccessibleName = "Show webview";
            CbShowWebView.AccessibleRole = AccessibleRole.CheckButton;
            CbShowWebView.AutoSize = true;
            CbShowWebView.Font = new Font("Segoe UI", 10F);
            CbShowWebView.Location = new Point(70, 209);
            CbShowWebView.Name = "CbShowWebView";
            CbShowWebView.Size = new Size(121, 23);
            CbShowWebView.TabIndex = 1;
            CbShowWebView.Text = Languages.ConfigTrayIcon_CbShowWebView;
            CbShowWebView.UseVisualStyleBackColor = true;
            CbShowWebView.CheckedChanged += CbShowWebView_CheckedChanged;
            // 
            // TbWebViewUrl
            // 
            TbWebViewUrl.AccessibleDescription = "The URL to show. Defaults to the Home Assistant API's URL.";
            TbWebViewUrl.AccessibleName = "URL";
            TbWebViewUrl.AccessibleRole = AccessibleRole.Text;
            TbWebViewUrl.BackColor = Color.FromArgb(63, 63, 70);
            TbWebViewUrl.BorderStyle = BorderStyle.FixedSingle;
            TbWebViewUrl.Enabled = false;
            TbWebViewUrl.Font = new Font("Segoe UI", 10F);
            TbWebViewUrl.ForeColor = Color.FromArgb(241, 241, 241);
            TbWebViewUrl.Location = new Point(90, 280);
            TbWebViewUrl.Name = "TbWebViewUrl";
            TbWebViewUrl.Size = new Size(521, 25);
            TbWebViewUrl.TabIndex = 2;
            // 
            // LblWebViewUrl
            // 
            LblWebViewUrl.AccessibleDescription = "URL textbox description";
            LblWebViewUrl.AccessibleName = "URL info";
            LblWebViewUrl.AccessibleRole = AccessibleRole.StaticText;
            LblWebViewUrl.AutoSize = true;
            LblWebViewUrl.Font = new Font("Segoe UI", 10F);
            LblWebViewUrl.Location = new Point(87, 258);
            LblWebViewUrl.Name = "LblWebViewUrl";
            LblWebViewUrl.Size = new Size(415, 19);
            LblWebViewUrl.TabIndex = 49;
            LblWebViewUrl.Text = "&WebView URL (For instance, your Home Assistant Dashboard URL)";
            // 
            // LblX
            // 
            LblX.AccessibleDescription = "Shows X, meaning 'by' in this context.";
            LblX.AccessibleName = "X info";
            LblX.AccessibleRole = AccessibleRole.StaticText;
            LblX.AutoSize = true;
            LblX.Font = new Font("Segoe UI", 10F);
            LblX.Location = new Point(184, 350);
            LblX.Name = "LblX";
            LblX.Size = new Size(17, 19);
            LblX.TabIndex = 53;
            LblX.Text = "X";
            // 
            // LblWebViewSize
            // 
            LblWebViewSize.AccessibleDescription = "Size description.";
            LblWebViewSize.AccessibleName = "Size info";
            LblWebViewSize.AccessibleRole = AccessibleRole.StaticText;
            LblWebViewSize.AutoSize = true;
            LblWebViewSize.Font = new Font("Segoe UI", 10F);
            LblWebViewSize.Location = new Point(85, 326);
            LblWebViewSize.Name = "LblWebViewSize";
            LblWebViewSize.Size = new Size(58, 19);
            LblWebViewSize.TabIndex = 51;
            LblWebViewSize.Text = "Size (px)";
            // 
            // BtnShowWebViewPreview
            //
            BtnShowWebViewPreview.AccessibleDescription = "Shows the webview, using the currently configured values.";
            BtnShowWebViewPreview.AccessibleName = "Webview preview";
            BtnShowWebViewPreview.AccessibleRole = AccessibleRole.PushButton;
            BtnShowWebViewPreview.BackColor = Color.FromArgb(63, 63, 70);
            BtnShowWebViewPreview.Enabled = false;
            BtnShowWebViewPreview.FlatStyle = FlatStyle.Flat;
            BtnShowWebViewPreview.Font = new Font("Segoe UI", 10F);
            BtnShowWebViewPreview.ForeColor = Color.FromArgb(241, 241, 241);
            BtnShowWebViewPreview.Location = new Point(405, 348);
            BtnShowWebViewPreview.Name = "BtnShowWebViewPreview";
            BtnShowWebViewPreview.Size = new Size(206, 26);
            BtnShowWebViewPreview.TabIndex = 6;
            BtnShowWebViewPreview.Text = Languages.ConfigTrayIcon_BtnShowWebViewPreview;
            BtnShowWebViewPreview.UseVisualStyleBackColor = false;
            BtnShowWebViewPreview.Click += BtnShowWebViewPreview_Click;
            // 
            // NumWebViewWidth
            //
            NumWebViewWidth.AccessibleDescription = "The width of the webview. Only accepts numeric values.";
            NumWebViewWidth.AccessibleName = "Width";
            NumWebViewWidth.AccessibleRole = AccessibleRole.Text;
            NumWebViewWidth.BackColor = Color.FromArgb(63, 63, 70);
            NumWebViewWidth.BorderStyle = BorderStyle.FixedSingle;
            NumWebViewWidth.Enabled = false;
            NumWebViewWidth.Font = new Font("Segoe UI", 10F);
            NumWebViewWidth.ForeColor = Color.FromArgb(241, 241, 241);
            NumWebViewWidth.Location = new Point(87, 348);
            NumWebViewWidth.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NumWebViewWidth.Name = "NumWebViewWidth";
            NumWebViewWidth.Size = new Size(83, 25);
            NumWebViewWidth.TabIndex = 3;
            NumWebViewWidth.Value = new decimal(new int[] { 700, 0, 0, 0 });
            // 
            // NumWebViewHeight
            //
            NumWebViewHeight.AccessibleDescription = "The height of the webview. Only accepts numeric values.";
            NumWebViewHeight.AccessibleName = "Height";
            NumWebViewHeight.AccessibleRole = AccessibleRole.Text;
            NumWebViewHeight.BackColor = Color.FromArgb(63, 63, 70);
            NumWebViewHeight.BorderStyle = BorderStyle.FixedSingle;
            NumWebViewHeight.Enabled = false;
            NumWebViewHeight.Font = new Font("Segoe UI", 10F);
            NumWebViewHeight.ForeColor = Color.FromArgb(241, 241, 241);
            NumWebViewHeight.Location = new Point(218, 348);
            NumWebViewHeight.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NumWebViewHeight.Name = "NumWebViewHeight";
            NumWebViewHeight.Size = new Size(83, 25);
            NumWebViewHeight.TabIndex = 4;
            NumWebViewHeight.Value = new decimal(new int[] { 560, 0, 0, 0 });
            // 
            // BtnWebViewReset
            //
            BtnWebViewReset.AccessibleDescription = "Resets the width and height values to their defaults.";
            BtnWebViewReset.AccessibleName = "Reset webview";
            BtnWebViewReset.AccessibleRole = AccessibleRole.PushButton;
            BtnWebViewReset.BackColor = Color.FromArgb(63, 63, 70);
            BtnWebViewReset.Enabled = false;
            BtnWebViewReset.FlatStyle = FlatStyle.Flat;
            BtnWebViewReset.Font = new Font("Segoe UI", 10F);
            BtnWebViewReset.ForeColor = Color.FromArgb(241, 241, 241);
            BtnWebViewReset.Image = Properties.Resources.reset_24;
            BtnWebViewReset.Location = new Point(317, 348);
            BtnWebViewReset.Name = "BtnWebViewReset";
            BtnWebViewReset.Size = new Size(51, 26);
            BtnWebViewReset.TabIndex = 5;
            BtnWebViewReset.TextImageRelation = TextImageRelation.Overlay;
            BtnWebViewReset.UseVisualStyleBackColor = false;
            BtnWebViewReset.Click += BtnWebViewReset_Click;
            // 
            // CbWebViewKeepLoaded
            // 
            CbWebViewKeepLoaded.AccessibleDescription = "Keeps the webview loaded in the background, resulting in faster loading when invoked.";
            CbWebViewKeepLoaded.AccessibleName = "Background loading";
            CbWebViewKeepLoaded.AccessibleRole = AccessibleRole.CheckButton;
            CbWebViewKeepLoaded.AutoSize = true;
            CbWebViewKeepLoaded.Checked = true;
            CbWebViewKeepLoaded.CheckState = CheckState.Checked;
            CbWebViewKeepLoaded.Enabled = false;
            CbWebViewKeepLoaded.Font = new Font("Segoe UI", 10F);
            CbWebViewKeepLoaded.Location = new Point(90, 405);
            CbWebViewKeepLoaded.Name = "CbWebViewKeepLoaded";
            CbWebViewKeepLoaded.Size = new Size(253, 23);
            CbWebViewKeepLoaded.TabIndex = 7;
            CbWebViewKeepLoaded.Text = Languages.ConfigTrayIcon_CbWebViewKeepLoaded;
            CbWebViewKeepLoaded.UseVisualStyleBackColor = true;
            // 
            // LblInfo2
            // 
            LblInfo2.AccessibleDescription = "Background loading information.";
            LblInfo2.AccessibleName = "Background loading info";
            LblInfo2.AccessibleRole = AccessibleRole.StaticText;
            LblInfo2.AutoSize = true;
            LblInfo2.Enabled = false;
            LblInfo2.Font = new Font("Segoe UI", 10F);
            LblInfo2.Location = new Point(107, 435);
            LblInfo2.Name = "LblInfo2";
            LblInfo2.Size = new Size(330, 19);
            LblInfo2.TabIndex = 76;
            LblInfo2.Text = "(This uses extra resources, but reduces loading time.)";
            // 
            // CbWebViewShowMenuOnLeftClick
            // 
            CbWebViewShowMenuOnLeftClick.AccessibleDescription = "If enabled, left clicking the system tray icon will show the default menu.";
            CbWebViewShowMenuOnLeftClick.AccessibleName = "Show default menu on left click";
            CbWebViewShowMenuOnLeftClick.AccessibleRole = AccessibleRole.CheckButton;
            CbWebViewShowMenuOnLeftClick.AutoSize = true;
            CbWebViewShowMenuOnLeftClick.Enabled = false;
            CbWebViewShowMenuOnLeftClick.Font = new Font("Segoe UI", 10F);
            CbWebViewShowMenuOnLeftClick.Location = new Point(90, 487);
            CbWebViewShowMenuOnLeftClick.Name = "CbWebViewShowMenuOnLeftClick";
            CbWebViewShowMenuOnLeftClick.Size = new Size(265, 23);
            CbWebViewShowMenuOnLeftClick.TabIndex = 77;
            CbWebViewShowMenuOnLeftClick.Text = Languages.ConfigTrayIcon_CbWebViewShowMenuOnLeftClick;
            CbWebViewShowMenuOnLeftClick.UseVisualStyleBackColor = true;
            // 
            // ConfigTrayIcon
            // 
            AccessibleDescription = "Panel containing the tray icon configuration.";
            AccessibleName = "Tray icon";
            AccessibleRole = AccessibleRole.Pane;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(CbWebViewShowMenuOnLeftClick);
            Controls.Add(LblInfo2);
            Controls.Add(CbWebViewKeepLoaded);
            Controls.Add(BtnWebViewReset);
            Controls.Add(NumWebViewHeight);
            Controls.Add(NumWebViewWidth);
            Controls.Add(BtnShowWebViewPreview);
            Controls.Add(LblX);
            Controls.Add(LblWebViewSize);
            Controls.Add(TbWebViewUrl);
            Controls.Add(LblWebViewUrl);
            Controls.Add(CbShowWebView);
            Controls.Add(LblInfo1);
            Controls.Add(CbDefaultMenu);
            Controls.Add(CbUseModernIcon);
            ForeColor = Color.FromArgb(241, 241, 241);
            Margin = new Padding(4);
            Name = "ConfigTrayIcon";
            Size = new Size(700, 544);
            Load += ConfigTrayIcon_Load;
            ((System.ComponentModel.ISupportInitialize)NumWebViewWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumWebViewHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label LblInfo1;
        internal System.Windows.Forms.CheckBox CbUseModernIcon;
        internal System.Windows.Forms.CheckBox CbDefaultMenu;
        internal CheckBox CbShowWebView;
        internal TextBox TbWebViewUrl;
        internal System.Windows.Forms.Button BtnShowWebViewPreview;
        internal Label LblWebViewUrl;
        internal Label LblX;
        internal Label LblWebViewSize;
        internal System.Windows.Forms.NumericUpDown NumWebViewWidth;
        internal System.Windows.Forms.NumericUpDown NumWebViewHeight;
        internal System.Windows.Forms.Button BtnWebViewReset;
        internal CheckBox CbWebViewKeepLoaded;
        internal Label LblInfo2;
        internal CheckBox CbWebViewShowMenuOnLeftClick;
    }
}
