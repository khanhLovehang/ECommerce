using System;
using System.Collections.Generic;

namespace Entities;

public partial class Shipment
{
    public int ShipmentId { get; set; }

    public DateTime ShipmentDate { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? ZipCode { get; set; }

    public Guid? UserId { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsDefault { get; set; }

    public string? Province { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public Guid? CreatedById { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public Guid? UpdatedById { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public Guid? DeletedById { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
