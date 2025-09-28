using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsManager.Extensions;

namespace TeamsManager.Infrastructure.Config
{
    public class AccountConfig
    {
        public string TenantId { get; set; } = "";
        public string ClientId { get; set; } = "";
        public string ClientSecret { get; set; } = "";
        public string UserUpn { get; set; } = "";   // email/UPN để gọi /users/{upn}/chats
    }
    public static class AccountCogExtension
    {

        static string path = Path.Combine(DataPaths.CogsDir, "account.config.json");
        public static AccountConfig Init()
        {
            string json = FileHelper.ReadAllText(path);
            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    var o = JsonConvert.DeserializeObject<AccountConfig>(json);
                    if (o != null)
                    {
                        return o;
                    }
                }
                catch (Exception) { }
            }
            return new AccountConfig
            {
                TenantId = "",
                ClientId = "",
                ClientSecret = "",
                UserUpn = ""
            };
        }
        public static void Save(this AccountConfig o)
        {
            if (o != null)
            {
                FileHelper.TryWriteAllText(path, o.ToJsonString());
            }   
        }
    }
}
