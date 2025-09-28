using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsManager.Infrastructure.Config;

namespace TeamsManager.Infrastructure.Startup
{
    public class StartupContext
    {
        /// <summary> Cấu hình tài khoản App-only để gọi Graph. </summary>
        public AccountConfig Account { get; private set; } = new();

        /// <summary> Gán lại Account (ví dụ sau khi người dùng bấm Save). </summary>
        public void SetAccount(AccountConfig account)
        {
            Account = account ?? new AccountConfig();
        }

        /// <summary>GraphServiceClient dùng App-only (Client Credentials)</summary>
        public GraphServiceClient? Graph { get; set; }

        // UI hooks
        public Action<string>? SetStatus { get; set; }
        public Action<int>? SetProgress { get; set; }

        // Errors (không crash app)
        public List<string> Errors { get; } = new();

        public void ReportStatus(string message, int? progress = null)
        {
            if (!string.IsNullOrEmpty(message))
                SetStatus?.Invoke(message);

            if (progress.HasValue)
                SetProgress?.Invoke(progress.Value);
        }

    }
}
