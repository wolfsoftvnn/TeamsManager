using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsManager.Models;

namespace TeamsManager.Abstractions
{
    public interface IGroupRepository
    {
        /// <summary>Khởi tạo DB + schema an toàn (try/catch nội bộ, không để app crash).</summary>
        Task<bool> EnsureCreatedAsync(CancellationToken ct = default);

        /// <summary>Thêm mới hoặc cập nhật (Name/IsSelected/Type nếu thay đổi).</summary>
        Task UpsertAsync(GroupInfo group, CancellationToken ct = default);

        /// <summary>Upsert danh sách (transaction).</summary>
        Task UpsertManyAsync(IEnumerable<GroupInfo> groups, CancellationToken ct = default);

        /// <summary>Đánh dấu chọn/bỏ chọn nhanh theo id.</summary>
        Task SetSelectedAsync(string idGroup, bool isSelected, CancellationToken ct = default);

        /// <summary>Lấy toàn bộ nhóm.</summary>
        Task<IReadOnlyList<GroupInfo>> GetAllAsync(CancellationToken ct = default);

        /// <summary>Lấy nhóm theo id.</summary>
        Task<GroupInfo?> GetByIdAsync(string idGroup, CancellationToken ct = default);
    }
}
