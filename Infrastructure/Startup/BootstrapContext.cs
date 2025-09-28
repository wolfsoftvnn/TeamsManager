using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsManager.Infrastructure.Startup.Tasks;

namespace TeamsManager.Infrastructure.Startup
{
    public sealed class BootstrapContext : ApplicationContext
    {
        private readonly StartupContext _ctx;
        private readonly Form _splash;
        private readonly CancellationTokenSource _cts = new();
        private bool _mainOpened;

        public BootstrapContext()
        {
            _ctx = new StartupContext();
            _splash = CreateSplash();
            _splash.FormClosed += (_, __) => { if (!_mainOpened) ExitThread(); };

            _splash.Show();
            _ = StartAsync(); // fire-and-forget (không block UI)
        }
        private async Task StartAsync()
        {
            try
            {
                // Lắp pipeline (EnsureDataDirsTask ưu tiên đầu tiên)
                var tasks = BuildTasks();
                var pipeline = new StartupTaskPipeline(tasks);

                // Wire sự kiện để cập nhật UI Splash
                pipeline.StatusChanged += s => SafeInvoke(_splash, () =>
                {
                    TrySetSplashStatus(s);
                });
                pipeline.ProgressChanged += (i, total, name) => SafeInvoke(_splash, () =>
                {
                    TrySetSplashProgress(i, total, name);
                });
                pipeline.Faulted += ex => SafeInvoke(_splash, () =>
                {
                    TrySetSplashStatus("Lỗi khởi động.");
                });

                await pipeline.RunAsync(_ctx, _cts.Token);

                // Mở MainForm khi xong
                SafeInvoke(_splash, () =>
                {
                    OpenMainAndCloseSplash();
                });
            }
            catch (OperationCanceledException)
            {
                SafeInvoke(_splash, () =>
                {
                    MessageBox.Show(_splash, "Khởi động đã bị hủy.", "Đã hủy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ExitThread();
                });
            }
            catch (Exception ex)
            {
                SafeInvoke(_splash, () =>
                {
                    MessageBox.Show(_splash, ex.Message, "Lỗi khởi động", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ExitThread();
                });
            }
        }

        private List<IStartupTask> BuildTasks()
        {
            var list = new List<IStartupTask>();

            // 1) PHẢI có EnsureDataDirsTask trước tiên
            list.Add(new EnsureDataDirsTask());

            // 2) Thêm các task khác của bạn (nếu có) THEO THỨ TỰ MONG MUỐN:
            //    Đặt ở đây để không phải thay đổi interface IStartupTask
            //    Ví dụ:
            // list.Add(new LoadAppConfigTask());
            // list.Add(new CreateGraphClientTask());
            // list.Add(new ValidateZaloTokenTask());
            // list.Add(new WarmupTemplatesTask());
            // v.v…

            return list;
        }

        private Form CreateSplash()
        {
            // Dùng SplashForm hiện có của bạn.
            // Yêu cầu: SplashForm có 2 method tùy chọn dưới để cập nhật trạng thái:
            //   - SetStatus(string text)
            //   - SetProgress(int value, int max, string? taskName)
            // Nếu chưa có, bạn có thể thêm 2 hàm public này vào SplashForm.
            return new SplashForm();
        }

        private void TrySetSplashStatus(string text)
        {
            // Nếu SplashForm có SetStatus => gọi
            var mi = _splash.GetType().GetMethod("SetStatus");
            mi?.Invoke(_splash, new object[] { text });
        }

        private void TrySetSplashProgress(int index, int total, string? taskName)
        {
            var mi = _splash.GetType().GetMethod("SetProgress");
            mi?.Invoke(_splash, new object[] { index, total, taskName ?? string.Empty });
        }

        private void OpenMainAndCloseSplash()
        {
            if (_mainOpened) return;
            _mainOpened = true;

            var main = new frmMain(_ctx); // frmMain nhận StartupContext
            main.FormClosed += (_, __) => ExitThread();

            _splash.Hide();
            main.Show();
            _splash.Close();
        }

        private static void SafeInvoke(Control ctrl, Action action)
        {
            if (ctrl.IsDisposed) return;
            if (ctrl.InvokeRequired) ctrl.BeginInvoke(action);
            else action();
        }
    }
}
