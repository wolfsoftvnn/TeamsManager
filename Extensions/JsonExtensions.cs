using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace TeamsManager.Extensions
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions DefaultOptions = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public static async Task<T?> LoadJsonAsync<T>(this string path, CancellationToken ct = default)
        {
            if (!File.Exists(path)) return default;
            await using var fs = File.OpenRead(path);
            return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(fs, DefaultOptions, ct);
        }

        public static async Task SaveJsonAsync<T>(this string path, T value, CancellationToken ct = default)
        {
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            await using var fs = File.Create(path);
            await System.Text.Json.JsonSerializer.SerializeAsync(fs, value, DefaultOptions, ct);
        }
        public static string ToJsonString(this object obj, bool indented = false)
        {
            if (obj == null) return string.Empty;

            var formatting = indented ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None;
            try
            {
                return JsonConvert.SerializeObject(obj, formatting);
            }
            catch
            {
                return string.Empty; // tránh crash
            }
        }
    }
}
