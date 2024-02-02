using System;
using System.Collections.Generic;

namespace Entities;

public partial class Attribute
{
    /// <summary>
    /// Id thuộc tính
    /// </summary>
    public int AttributeId { get; set; }

    public bool? IsDeleted { get; set; }

    public int? Status { get; set; }

    public string? AttributeName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public Guid? CreatedById { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public Guid? UpdatedById { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public Guid? DeletedById { get; set; }

    public int? ParentId { get; set; }

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();
}
