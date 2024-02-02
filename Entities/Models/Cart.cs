using System;
using System.Collections.Generic;

namespace Entities;

public partial class Cart
{
    public int CartId { get; set; }

    public Guid ProductId { get; set; }

    public Guid UserId { get; set; }

    public int? Quanlity { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public Guid? CreatedById { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public Guid? UpdatedById { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public Guid? DeletedById { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
