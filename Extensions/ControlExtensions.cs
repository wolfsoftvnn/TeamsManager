using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsManager.Extensions
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Set Text an toàn từ bất kỳ thread nào.
        /// </summary>
        public static void SetTextSafe(this Control control, string text)
        {
            if (control == null || control.IsDisposed) return;

            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action<Control, string>(SetTextSafe), control, text);
            }
            else
            {
                control.Text = text;
            }
        }

        /// <summary>
        /// Set Value an toàn cho ProgressBar.
        /// </summary>
        public static void SetValueSafe(this ProgressBar bar, int value)
        {
            if (bar == null || bar.IsDisposed) return;

            if (bar.InvokeRequired)
            {
                bar.BeginInvoke(new Action<ProgressBar, int>(SetValueSafe), bar, value);
            }
            else
            {
                bar.Value = Math.Max(bar.Minimum, Math.Min(bar.Maximum, value));
            }
        }
    }
}
