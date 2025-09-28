using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsManager.UI
{
    [ToolboxItem(true)]
    public class ModernProgressBar : Control
    {
        private int _value;
        private int _maximum = 100;
        private int _barRadius = 10;
        private int _barHeight = 12;

        [Browsable(true)]
        [DefaultValue(0)]
        public int Value
        {
            get => _value;
            set
            {
                int v = Math.Max(0, Math.Min(Maximum, value));
                if (v != _value)
                {
                    _value = v;
                    Invalidate();
                }
            }
        }

        [Browsable(true)]
        [DefaultValue(100)]
        public int Maximum
        {
            get => _maximum;
            set
            {
                _maximum = Math.Max(1, value);
                if (_value > _maximum) _value = _maximum;
                Invalidate();
            }
        }

        [Browsable(true)]
        [DefaultValue(10)]
        public int BarRadius
        {
            get => _barRadius; set { _barRadius = Math.Max(0, value); Invalidate(); }
        }

        [Browsable(true)]
        [DefaultValue(12)]
        public int BarHeight
        {
            get => _barHeight; set { _barHeight = Math.Max(4, value); Invalidate(); }
        }

        [Browsable(true)]
        public Color TrackColor { get; set; } = Color.FromArgb(40, 60, 90);

        [Browsable(true)]
        public Color FillStart { get; set; } = Color.FromArgb(0, 164, 255);

        [Browsable(true)]
        public Color FillEnd { get; set; } = Color.FromArgb(0, 119, 255);

        [Browsable(true)]
        public bool ShowText { get; set; } = false;

        [Browsable(true)]
        public Font TextFont { get; set; } = new Font("Segoe UI", 9f, FontStyle.Bold);

        public ModernProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);
            Height = 22;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = ClientRectangle;

            // center bar vertically
            var barRect = new Rectangle(0, (rect.Height - _barHeight) / 2, rect.Width, _barHeight);

            using (var path = RoundedRect(barRect, _barRadius))
            using (var track = new SolidBrush(TrackColor))
            {
                g.FillPath(track, path);
            }

            float pct = _maximum == 0 ? 0 : (float)_value / _maximum;
            int fillWidth = (int)Math.Round(barRect.Width * pct);
            if (fillWidth > 0)
            {
                var fillRect = new Rectangle(barRect.X, barRect.Y, fillWidth, barRect.Height);
                using (var path = RoundedRect(fillRect, _barRadius))
                using (var lg = new LinearGradientBrush(fillRect, FillStart, FillEnd, 0f))
                {
                    g.FillPath(lg, path);
                }
            }

            if (ShowText)
            {
                string text = $"{(int)(pct * 100)}%";
                using var f = TextFont;
                var size = g.MeasureString(text, f);
                var p = new PointF(rect.Width - size.Width - 6, (rect.Height - size.Height) / 2f - 1);
                using var sb = new SolidBrush(Color.FromArgb(220, 240, 255));
                g.DrawString(text, f, sb, p);
            }
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(bounds);
                return path;
            }
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
