using HASS.Agent.Functions;
using HASS.Agent.Models.Internal;
using HASS.Agent.Resources.Localization;
using Newtonsoft.Json;
using Serilog;

namespace HASS.Agent.Forms.Commands.CommandConfig
{
    public partial class WebViewCommandConfig : ThemeAwareForm
    {
        // dragging source: https://stackoverflow.com/a/19357125
        private bool _dragging;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;
        
        public WebViewInfo WebViewInfo { get; private set; } = null;

        public WebViewCommandConfig(string webViewInfo = "")
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(webViewInfo)) return;
            var webViewPackage = JsonConvert.DeserializeObject<WebViewInfo>(webViewInfo);
            if (webViewPackage == null) return;

            WebViewInfo = webViewPackage;
        }

        private void WebViewCommandConfig_Load(object sender, EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // populate screen list
            PopulateScreenList();

            // set the size and coords
            if (WebViewInfo == null) SetCurrentVariables();
            else SetStoredVariables();

            // show ourselves
            Opacity = 100;
        }

        private void PopulateScreenList()
        {
            CbScreen.Items.Clear();
            CbScreen.Items.Add("Primary Screen");

            var screens = Screen.AllScreens;
            for (var i = 0; i < screens.Length; i++)
            {
                var screen = screens[i];
                var isPrimary = screen.Primary ? " (Primary)" : "";
                CbScreen.Items.Add($"Screen {i + 1}: {screen.Bounds.Width}x{screen.Bounds.Height}{isPrimary}");
            }

            // default to primary
            CbScreen.SelectedIndex = 0;
        }

        private void SetCurrentVariables()
        {
            NumSizeHeight.Value = Height;
            NumSizeWidth.Value = Width;

            NumLocationX.Value = Location.X;
            NumLocationY.Value = Location.Y;
        }

        private void SetStoredVariables()
        {
            try
            {
                TbUrl.Text = WebViewInfo.Url;

                CbCenterScreen.Checked = WebViewInfo.CenterScreen;
                CbShowTitleBar.Checked = WebViewInfo.ShowTitleBar;
                CbTopMost.Checked = WebViewInfo.TopMost;

                NumSizeHeight.Value = WebViewInfo.Height;
                NumSizeWidth.Value = WebViewInfo.Width;

                NumLocationX.Value = WebViewInfo.X;
                NumLocationY.Value = WebViewInfo.Y;

                // set screen selection (index 0 is "Primary", so screen index needs +1)
                var screenIndex = WebViewInfo.ScreenIndex < 0 ? 0 : WebViewInfo.ScreenIndex + 1;
                if (screenIndex < CbScreen.Items.Count)
                    CbScreen.SelectedIndex = screenIndex;
                else
                    CbScreen.SelectedIndex = 0;

                Height = (int)NumSizeHeight.Value;
                Width = (int)NumSizeWidth.Value;

                if (!CbCenterScreen.Checked)
                {
                    Location = new Point((int)NumLocationX.Value, (int)NumLocationY.Value);
                }
            }
            catch (Exception ex)
            {
                Log.Error("[WEBVIEWCONFIG] Unable to set stored settings: {err}", ex.Message);

                MessageBox.Show(this, Languages.WebViewCommandConfig_SetStoredVariables_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SetCurrentVariables();
            }
        }

        private void WebViewCommandConfig_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                // refresh the window
                Refresh();

                // set the new size and coords
                SetCurrentVariables();
            }
            catch
            {
                // best effort
            }
        }

        private void WebViewCommandConfig_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            WebViewInfo ??= new WebViewInfo();

            WebViewInfo.Url = TbUrl.Text;

            WebViewInfo.Height = (int)NumSizeHeight.Value;
            WebViewInfo.Width = (int)NumSizeWidth.Value;

            WebViewInfo.X = (int)NumLocationX.Value;
            WebViewInfo.Y = (int)NumLocationY.Value;

            WebViewInfo.CenterScreen = CbCenterScreen.Checked;
            WebViewInfo.ShowTitleBar = CbShowTitleBar.Checked;
            WebViewInfo.TopMost = CbTopMost.Checked;

            // save screen selection (index 0 is "Primary" = -1, others are screen index)
            WebViewInfo.ScreenIndex = CbScreen.SelectedIndex == 0 ? -1 : CbScreen.SelectedIndex - 1;

            DialogResult = DialogResult.OK;
        }

        private void CbShowTitleBar_CheckedChanged(object sender, EventArgs e)
        {
            ControlBox = CbShowTitleBar.Checked;
        }

        private void WebViewCommandConfig_MouseDown(object sender, MouseEventArgs e)
        {
            // we've started dragging
            _dragging = true;

            // set the location
            _dragCursorPoint = Cursor.Position;
            _dragFormPoint = Location;
        }

        private void WebViewCommandConfig_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging) return;

            // move the form according to the mouse's location
            var dif = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
            Location = Point.Add(_dragFormPoint, new Size(dif));
        }

        private void WebViewCommandConfig_MouseUp(object sender, MouseEventArgs e)
        {
            // we're done dragging
            _dragging = false;

            // set the new size and coords
            SetCurrentVariables();
        }

        private void CbTopMost_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = CbTopMost.Checked;
        }
    }
}
