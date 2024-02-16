using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Order
{
    public Guid OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public bool? IsDeleted { get; set; }

    /// <summary>
    /// 0: Chờ thanh toán, 1: Vận chuyển, 2: Chờ giao hàng, 3: Hoàn thành, 4: Đã hủy, 5: Trà hàng/ Hoàn tiền
    /// </summary>
    public int? Status { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? ShipmentId { get; set; }

    public Guid UserId { get; set; }

    public Guid PaymentId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public Guid? CreatedById { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public Guid? UpdatedById { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public Guid? DeletedById { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Payment Payment { get; set; } = null!;

    public virtual Shipment? Shipment { get; set; }

    public virtual User User { get; set; } = null!;
}
