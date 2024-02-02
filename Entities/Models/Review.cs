using System;
using System.Collections.Generic;

namespace Entities;

public partial class Review
{
    public int ReviewId { get; set; }

    public Guid ProductId { get; set; }

    public DateTime ReviewDate { get; set; }

    public string ReviewBy { get; set; } = null!;

    public Guid ReviewById { get; set; }

    public string? Detail { get; set; }

    public decimal? Rating { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public Guid? CreatedById { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public Guid? UpdatedById { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public Guid? DeletedById { get; set; }

    public virtual Product Product { get; set; } = null!;
}
