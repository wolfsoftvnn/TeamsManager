using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamsManager.Extensions;
using TeamsManager.Infrastructure.Startup;

namespace TeamsManager
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();

        }
        public void SetStatus(string text)
        {
            // lbStatus: Label trên form
            if (!IsDisposed && lbStatus != null) lbStatus.Text = text;
        }

        /// <summary>
        /// index: 0..total, total: số lượng task
        /// </summary>
        public void SetProgress(int index, int total, string taskName)
        {
            if (IsDisposed || progressBar1 == null) return;
            total = Math.Max(1, total);
            index = Math.Max(0, Math.Min(index, total));
            int percent = (int)Math.Round(index * 100.0 / total);
            progressBar1.SetValueSafe(Math.Max(progressBar1.Minimum, Math.Min(progressBar1.Maximum, percent)));
            if (lbStatus != null) lbStatus.SetTextSafe(taskName) ;
        }
        private void SplashForm_Load(object sender, EventArgs e)
        {

        }
    }
}
