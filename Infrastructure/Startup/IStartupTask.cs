using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsManager.Infrastructure.Startup
{
    /// <summary>
    /// Một tác vụ khởi động chạy khi SplashForm mở app.
    /// </summary>
    public interface IStartupTask
    {
        string Name { get; }
        int Order { get; } // nhỏ hơn => chạy trước
        Task RunAsync(StartupContext ctx, CancellationToken ct);
    }
}
