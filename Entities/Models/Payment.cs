using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// 0: Chờ thanh toán, 1: Hoàn thành
    /// </summary>
    public int? Status { get; set; }

    /// <summary>
    /// 0: Ví ShopeePay, 1: Thẻ Tín dung/Ghi nợ, 2: Thanh toán khi nhận hàng, 3: Chuyển khoản ngân hàng
    /// </summary>
    public string? PaymentMethod { get; set; }

    public decimal? Amount { get; set; }

    public Guid UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? CreatedName { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public string? UpdatedName { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public string? DeletedName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
