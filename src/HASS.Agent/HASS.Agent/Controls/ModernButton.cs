using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace HASS.Agent.Controls
{
    /// <summary>
    /// A modern button control with rounded corners and smooth visual effects
    /// </summary>
    public class ModernButton : Button
    {
        private int _borderRadius = 6;
        private Color _hoverColor = Color.FromArgb(78, 78, 86);
        private Color _pressedColor = Color.FromArgb(55, 55, 60);
        private Color _focusBorderColor = Color.FromArgb(0, 122, 204);
        private bool _isHovered = false;
        private bool _isPressed = false;

        [Category("Appearance")]
        [Description("The radius of the button corners")]
        [DefaultValue(6)]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The background color when the button is hovered")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HoverColor
        {
            get => _hoverColor;
            set
            {
                _hoverColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The background color when the button is pressed")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color PressedColor
        {
            get => _pressedColor;
            set
            {
                _pressedColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The border color when the button has focus")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color FocusBorderColor
        {
            get => _focusBorderColor;
            set
            {
                _focusBorderColor = value;
                Invalidate();
            }
        }

        public ModernButton()
        {
            // Enable custom painting
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Determine current background color based on state
            Color bgColor;
            if (!Enabled)
            {
                bgColor = Color.FromArgb(50, 50, 53);
            }
            else if (_isPressed)
            {
                bgColor = _pressedColor;
            }
            else if (_isHovered)
            {
                bgColor = _hoverColor;
            }
            else
            {
                bgColor = BackColor;
            }

            // Create rounded rectangle path
            using var path = CreateRoundedRectangle(
                new Rectangle(0, 0, Width - 1, Height - 1),
                _borderRadius);

            // Fill background
            using (var brush = new SolidBrush(bgColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Draw border
            var borderColor = Focused ? _focusBorderColor : Color.FromArgb(100, 100, 100);
            var borderWidth = Focused ? 2f : 1f;
            using (var pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawPath(pen, path);
            }

            // Draw image if present
            if (Image != null)
            {
                var imageRect = GetImageRectangle();
                if (Enabled)
                {
                    e.Graphics.DrawImage(Image, imageRect);
                }
                else
                {
                    // Draw grayscale for disabled state
                    ControlPaint.DrawImageDisabled(e.Graphics, Image, imageRect.X, imageRect.Y, bgColor);
                }
            }

            // Draw text
            var textColor = Enabled ? ForeColor : Color.FromArgb(120, 120, 120);
            var textRect = GetTextRectangle();
            TextRenderer.DrawText(e.Graphics, Text, Font, textRect, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
        }

        private Rectangle GetImageRectangle()
        {
            if (Image == null)
                return Rectangle.Empty;

            int x, y;
            var imgWidth = Image.Width;
            var imgHeight = Image.Height;

            switch (TextImageRelation)
            {
                case TextImageRelation.ImageAboveText:
                    x = (Width - imgWidth) / 2;
                    y = Padding.Top + 8;
                    break;
                case TextImageRelation.ImageBeforeText:
                    x = Padding.Left + 8;
                    y = (Height - imgHeight) / 2;
                    break;
                default:
                    x = (Width - imgWidth) / 2;
                    y = (Height - imgHeight) / 2;
                    break;
            }

            return new Rectangle(x, y, imgWidth, imgHeight);
        }

        private Rectangle GetTextRectangle()
        {
            if (Image == null || TextImageRelation == TextImageRelation.Overlay)
            {
                return new Rectangle(Padding.Left, Padding.Top,
                    Width - Padding.Horizontal, Height - Padding.Vertical);
            }

            var imgRect = GetImageRectangle();

            return TextImageRelation switch
            {
                TextImageRelation.ImageAboveText => new Rectangle(
                    Padding.Left,
                    imgRect.Bottom + 4,
                    Width - Padding.Horizontal,
                    Height - imgRect.Bottom - 4 - Padding.Bottom),
                TextImageRelation.ImageBeforeText => new Rectangle(
                    imgRect.Right + 4,
                    Padding.Top,
                    Width - imgRect.Right - 4 - Padding.Right,
                    Height - Padding.Vertical),
                _ => new Rectangle(Padding.Left, Padding.Top,
                    Width - Padding.Horizontal, Height - Padding.Vertical)
            };
        }

        private static GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;
            var arc = new Rectangle(rect.Location, new Size(diameter, diameter));

            // Top left arc
            path.AddArc(arc, 180, 90);

            // Top right arc
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom right arc
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom left arc
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovered = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovered = false;
            _isPressed = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isPressed = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isPressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();
            base.OnLostFocus(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            Invalidate();
            base.OnEnabledChanged(e);
        }
    }
}
