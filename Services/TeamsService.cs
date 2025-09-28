using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsManager.Abstractions;
using TeamsManager.Infrastructure.Startup;

namespace TeamsManager.Services
{
    public class TeamsService
    {
        private readonly StartupContext _ctx;
        private readonly IChatRepository _repo;

        public TeamsService(StartupContext ctx, IChatRepository repo)
        {
            _ctx = ctx;
            _repo = repo;
        }

        public sealed record ChatInfo(string Id, string? Topic, string Type, int MemberCount);

        /// <summary>Lấy danh sách group chats của User(UPN) qua App-only (Chat.ReadBasic.All).</summary>
        public async Task<IReadOnlyList<ChatInfo>> GetUserGroupChatsAsync(string userUpn, CancellationToken ct = default)
        {
            var client = _ctx.Graph ?? throw new InvalidOperationException("Graph chưa khởi tạo.");
            if (string.IsNullOrWhiteSpace(userUpn)) throw new ArgumentNullException(nameof(userUpn));

            var page = await client.Users[userUpn].Chats.GetAsync(req =>
            {
                req.QueryParameters.Filter = "chatType eq 'group'";
                req.QueryParameters.Top = 50;
                req.QueryParameters.Select = new[] { "id", "topic", "chatType" };
            }, ct);

            var list = new List<ChatInfo>();
            while (page != null)
            {
                if (page.Value != null)
                {
                    foreach (var c in page.Value)
                    {
                        int memberCount = 0;
                        try
                        {
                            var members = await client.Chats[c.Id].Members.GetAsync(q =>
                            {
                                q.QueryParameters.Top = 1;
                                q.QueryParameters.Count = true;
                            }, ct);
                            memberCount = (int?)members?.OdataCount ?? 0;
                        }
                        catch { /* ignore */ }

                        list.Add(new ChatInfo(c.Id!, c.Topic, c.ChatType?.ToString() ?? "group", memberCount));
                    }
                }

                if (page.OdataNextLink == null) break;
                page = await client.Users[userUpn].Chats.GetAsync(req => req.QueryParameters.Top = 50, ct);
            }

            return list;
        }

        /// <summary>Đồng bộ các chat lấy được vào kho JSON (merge-add-only).</summary>
        public async Task<int> SyncChatsToRepositoryAsync(IEnumerable<ChatInfo> chats, CancellationToken ct = default)
        {
            var records = chats.Select(c => new ChatRecord
            {
                Selected = false,
                Id = c.Id,
                Name = c.Topic ?? string.Empty,
                Type = c.Type
            }).ToList();

            return await _repo.MergeAddOnlyAsync(records, ct);
        }
    }
}
