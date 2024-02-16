using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public Guid? CreatedById { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public Guid? UpdatedById { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public Guid? DeletedById { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
