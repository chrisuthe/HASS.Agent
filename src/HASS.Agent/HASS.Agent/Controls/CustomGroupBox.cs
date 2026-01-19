using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HASS.Agent.Theme;

namespace HASS.Agent.Controls
{
    public class CustomGroupBox : GroupBox
    {
        private Color _borderColor = Color.Empty;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color BorderColor
        {
            get => _borderColor == Color.Empty ? ThemeManager.BorderColor : _borderColor;
            set => _borderColor = value;
        }

        public CustomGroupBox()
        {
            // BorderColor defaults to ThemeManager.BorderColor via the property getter
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var tSize = TextRenderer.MeasureText(Text, Font);

            var borderRect = e.ClipRectangle;
            borderRect.Y += tSize.Height / 2;
            borderRect.Height -= tSize.Height / 2;

            ControlPaint.DrawBorder(e.Graphics, borderRect, BorderColor, ButtonBorderStyle.Solid);

            var textRect = e.ClipRectangle;
            textRect.X += 6;
            textRect.Width = tSize.Width;
            textRect.Height = tSize.Height;
            e.Graphics.FillRectangle(new SolidBrush(BackColor), textRect);
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRect);
        }
    }
}
