using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsManager.Infrastructure.Config;

namespace TeamsManager.Infrastructure.Startup.Tasks
{
    public sealed class EnsureDataDirsTask : IStartupTask
    {
        public string Name => "Khởi tạo thư mục dữ liệu";
        public int Order => -100; // luôn đầu tiên
        public Task RunAsync(StartupContext ctx, CancellationToken ct)
        {
            try
            {
                DataPaths.Ensure();
            }
            catch (Exception ex) 
            { 
                ctx.Errors.Add($"Data dir: {ex.Message}");
            }
            return Task.CompletedTask;
        }
    }
}
