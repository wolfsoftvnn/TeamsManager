using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsManager.Extensions
{
    public static class FileHelper
    {
        private static string NormalizePath(this string? path) => string.IsNullOrWhiteSpace(path) ? string.Empty : Path.GetFullPath(path);

        private static bool EnsureDirectory(string? path, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(path))
            {
                error = "Path is null or empty.";
                return false;
            }
            try
            {
                
                var dir = Path.GetDirectoryName(Path.GetFullPath(path));
                if (string.IsNullOrWhiteSpace(dir)) return true; // root or just a dir already

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static bool TryCreateFolder(this string? folderPath, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                error = "Folder path is null or empty.";
                return false;
            }
            try
            {
                var p = folderPath.NormalizePath();
                if (!Directory.Exists(p))
                    Directory.CreateDirectory(p);

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        /// <summary>Xoá folder. Nếu recursive=true sẽ xoá đệ quy.</summary>
        public static bool TryDeleteFolder(this string? folderPath, bool recursive, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                error = "Folder path is null or empty.";
                return false;
            }
            try
            {
                var p = folderPath.NormalizePath();
                if (!Directory.Exists(p)) return true; // coi như thành công
                Directory.Delete(p, recursive);
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        // ========== File create/delete/copy ==========
        /// <summary>Tạo file rỗng (tự tạo folder cha nếu cần).</summary>
        public static bool TryCreateFile(this string? filePath, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                error = "File path is null or empty.";
                return false;
            }
            try
            {
                var p = filePath.NormalizePath();
                if (!EnsureDirectory(p, out error)) return false;

                if (!File.Exists(p))
                {
                    using (File.Create(p)) { } // tạo rỗng
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
        /// <summary>Xoá file (không lỗi nếu không tồn tại).</summary>
        public static bool TryDeleteFile(this string? filePath, out string error)
        {
            error = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    error = "File path is null or empty.";
                    return false;
                }
                var p = filePath.NormalizePath();
                if (!File.Exists(p)) return true; // coi như OK
                File.Delete(p);
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        /// <summary>Copy file (tự tạo folder đích). </summary>
        public static bool TryCopyFile(this string? srcPath, string? destPath, bool overwrite, out string error)
        {
            error = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(srcPath) || string.IsNullOrWhiteSpace(destPath))
                {
                    error = "Source or destination path is null or empty.";
                    return false;
                }
                var src = srcPath.NormalizePath();
                var dst = destPath.NormalizePath();

                if (!File.Exists(src))
                {
                    error = "Source file not found.";
                    return false;
                }

                if (!EnsureDirectory(dst, out error)) return false;
                File.Copy(src, dst, overwrite);
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        // ========== Write ==========
        public static bool TryWriteAllText(this string? filePath, string? content, Encoding? encoding, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                error = "File path is null or empty.";
                return false;
            }
            try
            {
                
                var p = filePath.NormalizePath();
                if (!EnsureDirectory(p, out error)) return false;

                if (encoding == null) File.WriteAllText(p, content ?? string.Empty);
                else File.WriteAllText(p, content ?? string.Empty, encoding);

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
        public static bool TryWriteAllLines(this string? filePath, string[]? lines, Encoding? encoding, out string error)
        {
            error = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    error = "File path is null or empty.";
                    return false;
                }
                var p = filePath.NormalizePath();
                if (!EnsureDirectory(p, out error)) return false;

                var data = lines ?? Array.Empty<string>();
                if (encoding == null) File.WriteAllLines(p, data);
                else File.WriteAllLines(p, data, encoding);

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        // ========== Read ==========

        public static string ReadAllText(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                var p = filePath.NormalizePath();
                try
                {

                    return File.ReadAllText(p);
                }
                catch (Exception) { }
            }
            return string.Empty;
        }
        public static bool TryReadAllText(this string? filePath, out string content, Encoding? encoding, out string error)
        {
            content = string.Empty;
            error = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    error = "File path is null or empty.";
                    return false;
                }
                var p = filePath.NormalizePath();
                if (!File.Exists(p))
                {
                    error = "File not found.";
                    return false;
                }

                content = encoding == null ? File.ReadAllText(p) : File.ReadAllText(p, encoding);
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static bool TryReadAllLines(this string? filePath, out string[] lines, Encoding? encoding, out string error)
        {
            lines = Array.Empty<string>();
            error = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    error = "File path is null or empty.";
                    return false;
                }
                var p = filePath.NormalizePath();
                if (!File.Exists(p))
                {
                    error = "File not found.";
                    return false;
                }

                lines = encoding == null ? File.ReadAllLines(p) : File.ReadAllLines(p, encoding);
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }



        // ========== Sugar overloads (Encoding mặc định UTF8) ==========


        public static bool TryWriteAllText(this string? filePath, string? content, out string error)
            => TryWriteAllText(filePath, content, new UTF8Encoding(false), out error);

        public static bool TryWriteAllLines(this string? filePath, string[]? lines, out string error)
            => TryWriteAllLines(filePath, lines, new UTF8Encoding(false), out error);

        public static bool TryReadAllText(this string? filePath, out string content, out string error)
            => TryReadAllText(filePath, out content, new UTF8Encoding(false), out error);

        public static bool TryReadAllLines(this string? filePath, out string[] lines, out string error)
            => TryReadAllLines(filePath, out lines, new UTF8Encoding(false), out error);

        public static bool TryWriteAllText(this string? filePath, string? content)
        {
            return TryWriteAllText(filePath, content, new UTF8Encoding(false), out _);
        }

        public static bool TryWriteAllLines(this string? filePath, string[]? lines)
        {
            return TryWriteAllLines(filePath, lines, new UTF8Encoding(false), out _);
        }
    }

}
