using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsManager.Extensions;

namespace TeamsManager.Infrastructure.Config
{
    public static class DataPaths
    {
        private static readonly string RootDir = Path.Combine($@"C:\{Application.CompanyName.ToLower()}\{Application.ProductName.ToLower()}");
        
        public static readonly string CogsDir = Path.Combine(RootDir,"cogs");
        
        public static readonly string DbDir = Path.Combine(RootDir,"database");

        public static readonly string ChatsDbPath =
            Path.Combine(RootDir, "chats.json");

        public static readonly string LogPath =
            Path.Combine(RootDir, "logs.txt");

        public static void Ensure()
        {
            FileHelper.TryCreateFolder(RootDir, out _);

            FileHelper.TryCreateFolder(CogsDir, out _);
            FileHelper.TryCreateFolder(DbDir, out _);
        }
    }
}
