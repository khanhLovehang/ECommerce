﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Product
{
    public Guid ProductId { get; set; }

    public string? Sku { get; set; }

    public bool? IsDeleted { get; set; }

    public int? Status { get; set; }

    /// <summary>
    /// 0: Simple product, 1: Configurable Product, 2: Grouped Product, 4: Virtual Product, 5: Bundle Product
    /// </summary>
    [Range(0, 5, ErrorMessage = "ProductType is from 0 to 5.")]
    public int? ProductType { get; set; }

    [Required(ErrorMessage = "Product name is a required field.")]
    [MaxLength(500, ErrorMessage = "Maximum length for the Name is 500 characters.")]
    public string ProductName { get; set; } = null!;

    public decimal? Price { get; set; }

    public decimal? OldPrice { get; set; }

    public int? CategoryId { get; set; }

    public int? BrandId { get; set; }

    [MaxLength(500, ErrorMessage = "Maximum length for the ShortDescription is 500 characters.")]
    public string? ShortDescription { get; set; }

    [MaxLength(1000, ErrorMessage = "Maximum length for the Description is 1000 characters.")]
    public string? Description { get; set; }

    public int? DiscountPercent { get; set; }

    public int? QuantitySold { get; set; }

    public string? Thumbnail { get; set; }

    /// <summary>
    /// 0: Women, 1: Men, 2: Boys, 3: Girls, 4: Unisex
    /// </summary>
    [Range(0, 4, ErrorMessage = "Gender is from 0 to 4.")]
    public int? Gender { get; set; }

    public int? Age { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public Guid? CreatedById { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public Guid? UpdatedById { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? DeletedBy { get; set; }

    public Guid? DeletedById { get; set; }

    public int? Quantity { get; set; }

    /// <summary>
    /// 0: OutStock, 1: InStock
    /// </summary>
    [Range(0, 1, ErrorMessage = "StockStatus is from 0 to 1.")]
    public int? StockStatus { get; set; }

    /// <summary>
    /// Hàng mới về từ ngày
    /// </summary>
    public DateTime? NewFrom { get; set; }

    /// <summary>
    /// Hàng mới về đến ngày
    /// </summary>
    public DateTime? NewTo { get; set; }

    /// <summary>
    /// Có đang sale ko
    /// </summary>
    public bool? IsSale { get; set; }

    public bool? IsNew { get; set; }

    public bool? IsRecommend { get; set; }

    public bool? IsShowOnMainPage { get; set; }

    public bool? IsVisibility { get; set; }

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
