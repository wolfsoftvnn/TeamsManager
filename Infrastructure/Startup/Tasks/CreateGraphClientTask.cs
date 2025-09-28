using Azure.Identity;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsManager.Infrastructure.Startup.Tasks
{
    public sealed class CreateGraphClientTask : IStartupTask
    {
        public string Name => "Tạo GraphServiceClient (App-only)";
        public int Order => 0; // sau khi có Account

        public Task RunAsync(StartupContext ctx, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var a = ctx.Account;
            if (a == null ||
                string.IsNullOrWhiteSpace(a.TenantId) ||
                string.IsNullOrWhiteSpace(a.ClientId) ||
                string.IsNullOrWhiteSpace(a.ClientSecret))
            {
                // Không ném lỗi: cho phép vào MainForm để người dùng nhập config
                return Task.CompletedTask;
            }

            var credential = new ClientSecretCredential(a.TenantId, a.ClientId, a.ClientSecret);
            ctx.Graph = new GraphServiceClient(credential, new[] { "https://graph.microsoft.com/.default" });
            return Task.CompletedTask;
        }
    }
}
