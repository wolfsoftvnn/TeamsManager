using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsManager.Infrastructure.Startup
{
    public sealed class StartupTaskPipeline
    {
        public event Action<int, int, string>? ProgressChanged; // (index, total, taskName)
        public event Action<string>? StatusChanged;              // ghi chú trạng thái
        public event Action<Exception>? Faulted;                 // báo lỗi

        private readonly IReadOnlyList<IStartupTask> _tasks;

        public StartupTaskPipeline(IReadOnlyList<IStartupTask> tasks)
        {
            _tasks = tasks ?? Array.Empty<IStartupTask>();
        }

        public async Task RunAsync(StartupContext ctx, CancellationToken ct)
        {
            int total = _tasks.Count;
            for (int i = 0; i < total; i++)
            {
                ct.ThrowIfCancellationRequested();
                var t = _tasks[i];
                try
                {
                    StatusChanged?.Invoke($"[{i + 1}/{total}] {t.Name}…");
                    ProgressChanged?.Invoke(i, total, t.Name);
                    await t.RunAsync(ctx, ct).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Faulted?.Invoke(ex);
                    throw;
                }
            }
            // Hoàn tất
            ProgressChanged?.Invoke(total, total, "Hoàn tất");
            StatusChanged?.Invoke("Khởi động hoàn tất.");
        }
    }
}
