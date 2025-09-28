using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsManager.Infrastructure.Config;

namespace TeamsManager.Infrastructure.Database
{
    public class AppDb
    {
        private static string? _cs;

        /// <summary>
        /// Gọi 1 lần (sau EnsureDataDirsTask).
        /// Tạo thư mục data/db và cấu hình connection string tới app.db.
        /// </summary>
        public static void Configure()
        {
           
            var dbPath = Path.Combine(DataPaths.DbDir, "app.db");
            
            _cs = new SqliteConnectionStringBuilder
            {
                DataSource = dbPath,
                Mode = SqliteOpenMode.ReadWriteCreate,
                Cache = SqliteCacheMode.Default

            }.ToString();
        }
        /// <summary>
        /// Mở kết nối tới app.db. Bật WAL/synchronous để cân bằng bền vững & hiệu năng.
        /// Strict: ném lỗi nếu chưa Configure hoặc lỗi IO/SQLite.
        /// </summary>
        public static IDbConnection Open()
        {
            if (string.IsNullOrWhiteSpace(_cs))
                throw new InvalidOperationException("AppDb chưa được cấu hình. Hãy chạy EnsureDataDirsTask và EnsureAppDbTask trước khi dùng DB.");

            var conn = new SqliteConnection(_cs);
            conn.Open();

            using var pragma = conn.CreateCommand();
            pragma.CommandText = @"PRAGMA journal_mode=WAL; PRAGMA synchronous=NORMAL;";
            pragma.ExecuteNonQuery();

            return conn;
        }

    }
}
