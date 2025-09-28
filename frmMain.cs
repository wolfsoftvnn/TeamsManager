using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using TeamsManager.Extensions;
using TeamsManager.Infrastructure.Config;
using TeamsManager.Infrastructure.Startup;

namespace TeamsManager
{
    public partial class frmMain : Form
    {
        public StartupContext _ctx { get; set; }
        public frmMain(StartupContext _ctx)
        {
            InitializeComponent();
            this._ctx = _ctx;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"{System.Windows.Forms.Application.ProductName} {System.Windows.Forms.Application.ProductVersion}";
            initAccountCog();
        }
        private void initAccountCog()
        {
            tbAccountId.Text = _ctx.Account.UserUpn;
            tbTenant.Text = _ctx.Account.TenantId;
            tbClientId.Text = _ctx.Account.ClientId;
            tbClientSecrect.Text = _ctx.Account.ClientSecret;
        }

        private static async Task<List<(string Id, string? Name, string Kind)>> ListAllGroupsAsync(GraphServiceClient graph)
        {
            var results = new List<(string, string?, string)>();

            var page = await graph.Groups.GetAsync(req =>
            {
                // Lấy những field đủ để phân loại
                req.QueryParameters.Select = new[] { "id", "displayName", "groupTypes", "mailEnabled", "securityEnabled", "mail", "visibility" };
                req.QueryParameters.Top = 50;
            });

            while (page?.Value != null)
            {
                foreach (var g in page.Value)
                {
                    if (g.Id is null) continue;
                    string kind =
                        (g.GroupTypes?.Contains("Unified") ?? false) ? "Microsoft 365 Group" :
                        (g.SecurityEnabled ?? false) ? "Security group" :
                        (g.MailEnabled ?? false) ? "Distribution list" :
                        "Other";

                    results.Add((g.Id, g.DisplayName, kind));
                }

                if (page.OdataNextLink is null) break;
                page = await graph.Groups.WithUrl(page.OdataNextLink).GetAsync();
            }

            return results;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            
        }

        private static async Task<string> ResolveUserIdAsync(GraphServiceClient graph, string upnOrId)
        {
            // Nếu là GUID -> trả luôn
            if (Guid.TryParse(upnOrId, out _)) return upnOrId;

            // Ngược lại, coi như UPN/email -> tìm ObjectId
            // GET /users/{upn}
            var user = await graph.Users[upnOrId].GetAsync(req =>
            {
                req.QueryParameters.Select = new[] { "id", "userPrincipalName", "displayName" };
            });

            if (user?.Id is string id) return id;

            // Fallback: dùng filter (phòng trường hợp UPN có alias)
            var page = await graph.Users.GetAsync(req =>
            {
                req.QueryParameters.Filter = $"userPrincipalName eq '{upnOrId.Replace("'", "''")}'";
                req.QueryParameters.Select = new[] { "id" };
                req.QueryParameters.Top = 1;
            });
            var found = page?.Value?.FirstOrDefault()?.Id;
            if (string.IsNullOrEmpty(found))
                throw new InvalidOperationException($"Không tìm thấy user: {upnOrId}");
            return found!;
        }
        private sealed record ChatRow(string Id, string? Topic, List<string> Members);

        private async void button1_Click_1(object sender, EventArgs e)
        {

            FileHelper.TryWriteAllText(@"C:\Users\cnetp\OneDrive\Desktop\GiaBac\hhhhh.txt", "kcalamcka");
          

            //var cred = new ClientSecretCredential(tenantId, clientId, clientSecret);
            //var graph = new GraphServiceClient(cred, new[] { "https://graph.microsoft.com/.default" });
            ////var userId = await ResolveUserIdAsync(graph, "adfmobi@adfmobi.onmicrosoft.com");
            ////MessageBox.Show(userId);
            //try
            //{
            //    var upnOrId = "adfmobi@adfmobi.onmicrosoft.com";
            //    var page = await graph.Users[upnOrId].Chats.GetAsync(req =>
            //    {
            //        req.QueryParameters.Top = 50;
            //        req.QueryParameters.Select = new[] { "id", "topic", "chatType" };
            //        req.QueryParameters.Expand = new[] { "members" };
            //    });

            //    var rows = new List<(string Id, string Topic, List<string> Members)>();
            //    while (page?.Value != null)
            //    {
            //        foreach (var chat in page.Value)
            //        {
            //            //if (!string.Equals(chat.ChatType?.ToString(), "group", StringComparison.OrdinalIgnoreCase))
            //            //    continue;

            //            var members = new List<string>();
            //            if (chat.Members is not null)
            //            {
            //                foreach (var m in chat.Members.OfType<AadUserConversationMember>())
            //                    if (!string.IsNullOrWhiteSpace(m.DisplayName)) members.Add(m.DisplayName!);
            //            }

            //            rows.Add((chat.Id ?? "", string.IsNullOrWhiteSpace(chat.Topic) ? "(no topic)" : chat.Topic!, members));
            //        }

            //        if (page.OdataNextLink is null) break;
            //        page = await graph.Users[upnOrId].Chats.WithUrl(page.OdataNextLink).GetAsync();
            //    }

            //    if (rows.Count == 0) Console.WriteLine("Không thấy group chat nào.");
            //    else
            //    {
            //        Console.WriteLine($"== Group chats của {upnOrId} ==");
            //        foreach (var r in rows)
            //        {
            //            Console.WriteLine($"{r.Id} | {r.Topic} | members: {string.Join(", ", r.Members)}");
            //            MessageBox.Show($"{r.Id} | {r.Topic} | members: {string.Join(", ", r.Members)}");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Message: " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //MessageBox.Show("done");
        }

        private void tbAccountId_TextChanged(object sender, EventArgs e)
        {
            _ctx.Account.UserUpn = tbAccountId.Text.Trim();
            if (tbAccountId.IsHandleCreated)
                _ctx.Account.Save();
        }

        private void tbTenant_TextChanged(object sender, EventArgs e)
        {
            _ctx.Account.TenantId = tbTenant.Text.Trim();
            if (tbTenant.IsHandleCreated)
                _ctx.Account.Save();
        }

        private void tbClientId_TextChanged(object sender, EventArgs e)
        {
            _ctx.Account.ClientId = tbClientId.Text.Trim();
            if (tbClientId.IsHandleCreated)
                _ctx.Account.Save();
        }

        private void tbClientSecrect_TextChanged(object sender, EventArgs e)
        {
            _ctx.Account.ClientSecret = tbClientSecrect.Text.Trim();
            if (tbClientSecrect.IsHandleCreated)
                _ctx.Account.Save();
        }

        private static async Task<List<ChatRow>> ListGroupChatsAsync(GraphServiceClient graph, string userId)
        {
            var rows = new List<ChatRow>();

            var page = await graph.Users[userId].Chats.GetAsync(req =>
            {
                req.QueryParameters.Top = 50;
                req.QueryParameters.Select = new[] { "id", "topic", "chatType" };
                req.QueryParameters.Expand = new[] { "members" }; // lấy luôn thành viên
            });

            while (page?.Value != null)
            {
                foreach (var chat in page.Value)
                {
                    if (!string.Equals(chat.ChatType?.ToString(), "group", StringComparison.OrdinalIgnoreCase))
                        continue;

                    var memberNames = new List<string>();
                    if (chat.Members != null)
                    {
                        foreach (var m in chat.Members.OfType<AadUserConversationMember>())
                        {
                            if (!string.IsNullOrWhiteSpace(m.DisplayName))
                                memberNames.Add(m.DisplayName!);
                        }
                    }

                    rows.Add(new ChatRow(
                        Id: chat.Id ?? "",
                        Topic: string.IsNullOrWhiteSpace(chat.Topic) ? "(no topic)" : chat.Topic,
                        Members: memberNames
                    ));
                }

                if (page.OdataNextLink is null) break;
                page = await graph.Users[userId].Chats.WithUrl(page.OdataNextLink).GetAsync();
            }

            return rows;
        }
    }
}