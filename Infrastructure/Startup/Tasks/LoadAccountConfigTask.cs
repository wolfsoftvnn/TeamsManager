using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsManager.Infrastructure.Config;

namespace TeamsManager.Infrastructure.Startup.Tasks
{
    public sealed class LoadAccountConfigTask : IStartupTask
    {
        public string Name => "Nạp AccountConfig";
        public int Order => -50; // sau EnsureDataDirs

        public Task RunAsync(StartupContext ctx, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            var acc = AccountCogExtension.Init();
            ctx.SetAccount(acc);
            return Task.CompletedTask;
        }
    }
}
