using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsManager.Abstractions
{
    public interface IChatRepository
    {
        Task<IReadOnlyList<ChatRecord>> LoadAsync(CancellationToken ct = default);
        Task SaveAsync(IReadOnlyList<ChatRecord> items, CancellationToken ct = default);

        /// <summary>Merge add: thêm các chat mới nếu chưa có trong DB (so Id), không ghi đè record đã có.</summary>
        Task<int> MergeAddOnlyAsync(IReadOnlyList<ChatRecord> newItems, CancellationToken ct = default);
    }
}
