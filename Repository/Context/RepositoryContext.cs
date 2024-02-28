using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Attribute = Entities.Models.Attribute;

namespace Repository.Context
{
    public partial class RepositoryContext : DbContext
    {

        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Attribute> Attributes { get; set; }

        public virtual DbSet<AttributeValue> AttributeValues { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderProduct> OrderProducts { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Shipment> Shipments { get; set; }

        public virtual DbSet<User> Users { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //            => optionsBuilder.UseSqlServer("Server=ADMIN\\NNKHANH;Database=ECommerce;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.ToTable("Attribute");

                entity.Property(e => e.AttributeId).HasComment("Id thuộc tính");
                entity.Property(e => e.AttributeName).HasMaxLength(100);
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AttributeValue>(entity =>
            {
                entity.ToTable("AttributeValue");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.Value).HasMaxLength(256);

                entity.HasOne(d => d.Attribute).WithMany(p => p.AttributeValues)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_AttributeValue_Attribute");

                entity.HasOne(d => d.Product).WithMany(p => p.AttributeValues)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AttributeValue_Product");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandName).HasMaxLength(100);
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasIndex(e => e.UserId, "IX_Cart");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Product");

                entity.HasOne(d => d.User).WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_User");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(100);
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.ParentId).HasDefaultValue(0);
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).ValueGeneratedNever();
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.OrderDate).HasColumnType("datetime");
                entity.Property(e => e.Status).HasComment("0: Chờ thanh toán, 1: Vận chuyển, 2: Chờ giao hàng, 3: Hoàn thành, 4: Đã hủy, 5: Trà hàng/ Hoàn tiền");
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Payment");

                entity.HasOne(d => d.Shipment).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipmentId)
                    .HasConstraintName("FK_Order_Shipment");

                entity.HasOne(d => d.User).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.ToTable("OrderProduct");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProduct_Order");

                entity.HasOne(d => d.Product).WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProduct_Product");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).ValueGeneratedNever();
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.CreatedName).HasMaxLength(100);
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedName).HasMaxLength(100);
                entity.Property(e => e.PaymentDate).HasColumnType("datetime");
                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("0: Ví ShopeePay, 1: Thẻ Tín dung/Ghi nợ, 2: Thanh toán khi nhận hàng, 3: Chuyển khoản ngân hàng");
                entity.Property(e => e.Status).HasComment("0: Chờ thanh toán, 1: Hoàn thành");
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedName).HasMaxLength(100);

                entity.HasOne(d => d.User).WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_User");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Gender).HasComment("0: Women, 1: Men, 2: Boys, 3: Girls, 4: Unisex");
                entity.Property(e => e.IsSale).HasComment("Có đang sale ko");
                entity.Property(e => e.NewFrom)
                    .HasComment("Hàng mới về từ ngày")
                    .HasColumnType("datetime");
                entity.Property(e => e.NewTo)
                    .HasComment("Hàng mới về đến ngày")
                    .HasColumnType("datetime");
                entity.Property(e => e.OldPrice).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.ProductName).HasMaxLength(255);
                entity.Property(e => e.ProductType).HasComment("0: Simple product, 1: Configurable Product, 2: Grouped Product, 4: Virtual Product, 5: Bundle Product");
                entity.Property(e => e.ShortDescription).HasMaxLength(500);
                entity.Property(e => e.Sku)
                    .HasMaxLength(255)
                    .HasColumnName("SKU");
                entity.Property(e => e.StockStatus).HasComment("0: OutStock, 1: InStock");
                entity.Property(e => e.Thumbnail).HasMaxLength(500);
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.Detail).HasMaxLength(500);
                entity.Property(e => e.Rating).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.ReviewBy).HasMaxLength(100);
                entity.Property(e => e.ReviewDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Product");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.RoleName).HasMaxLength(50);
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipment");

                entity.Property(e => e.Address).HasMaxLength(256);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
                entity.Property(e => e.Province).HasMaxLength(50);
                entity.Property(e => e.ShipmentDate).HasColumnType("datetime");
                entity.Property(e => e.State).HasMaxLength(50);
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.ZipCode).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.Address).HasMaxLength(256);
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.DeletedBy).HasMaxLength(100);
                entity.Property(e => e.DeletedDate).HasColumnType("datetime");
                entity.Property(e => e.Email).HasMaxLength(256);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.Hash).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.PhoneNumber).HasMaxLength(100);
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Role).WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
