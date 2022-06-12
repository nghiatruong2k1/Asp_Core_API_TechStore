using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Application.Models
{
    public partial class TechStoreContext : DbContext
    {
        public TechStoreContext()
        {
        }

        public TechStoreContext(DbContextOptions<TechStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand0256> Brand0256s { get; set; }
        public virtual DbSet<Category0256> Category0256s { get; set; }
        public virtual DbSet<Image0256> Image0256s { get; set; }
        public virtual DbSet<Order0256> Order0256s { get; set; }
        public virtual DbSet<OrderDetail0256> OrderDetail0256s { get; set; }
        public virtual DbSet<OrderStatus0256> OrderStatus0256s { get; set; }
        public virtual DbSet<OrderVoucher0256> OrderVoucher0256s { get; set; }
        public virtual DbSet<Product0256> Product0256s { get; set; }
        public virtual DbSet<ProductImage0256> ProductImage0256s { get; set; }
        public virtual DbSet<ProductRating0256> ProductRating0256s { get; set; }
        public virtual DbSet<ProductType0256> ProductType0256s { get; set; }
        public virtual DbSet<Slider0256> Slider0256s { get; set; }
        public virtual DbSet<User0256> User0256s { get; set; }
        public virtual DbSet<UserType0256> UserType0256s { get; set; }
        public virtual DbSet<ViewBrand0256> ViewBrand0256s { get; set; }
        public virtual DbSet<ViewCategory0256> ViewCategory0256s { get; set; }
        public virtual DbSet<ViewOrder0256> ViewOrder0256s { get; set; }
        public virtual DbSet<ViewOrderDetail0256> ViewOrderDetail0256s { get; set; }
        public virtual DbSet<ViewProduct0256> ViewProduct0256s { get; set; }
        public virtual DbSet<ViewProductImage0256> ViewProductImage0256s { get; set; }
        public virtual DbSet<ViewSlider0256> ViewSlider0256s { get; set; }
        public virtual DbSet<ViewStatisOrder0256> ViewStatisOrder0256s { get; set; }
        public virtual DbSet<ViewStatisUser0256> ViewStatisUser0256s { get; set; }
        public virtual DbSet<ViewUser0256> ViewUser0256s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseNpgsql();
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_Vietnam.1258");

            modelBuilder.Entity<Brand0256>(entity =>
            {
                entity.ToTable("Brand_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.IsPopular).HasColumnName("isPopular");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.OrderIndex).HasColumnName("orderIndex");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");
            });

            modelBuilder.Entity<Category0256>(entity =>
            {
                entity.ToTable("Category_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.IsPopular).HasColumnName("isPopular");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.OrderIndex).HasColumnName("orderIndex");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");
            });

            modelBuilder.Entity<Image0256>(entity =>
            {
                entity.ToTable("Image_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.Url).HasColumnName("url");
            });

            modelBuilder.Entity<Order0256>(entity =>
            {
                entity.ToTable("Order_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(3)
                    .HasColumnName("createDate");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.UpdateDate)
                    .HasPrecision(3)
                    .HasColumnName("updateDate");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.VoucherSale).HasColumnName("voucherSale");
            });

            modelBuilder.Entity<OrderDetail0256>(entity =>
            {
                entity.ToTable("OrderDetail_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<OrderStatus0256>(entity =>
            {
                entity.ToTable("OrderStatus_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<OrderVoucher0256>(entity =>
            {
                entity.ToTable("OrderVoucher_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.EndDate).HasColumnName("endDate");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.ShortDes)
                    .HasMaxLength(2000)
                    .HasColumnName("shortDes");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Product0256>(entity =>
            {
                entity.ToTable("Product_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.BrandId).HasColumnName("brandId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.CurrencyUnit)
                    .HasMaxLength(1)
                    .HasColumnName("currencyUnit");

                entity.Property(e => e.FullDes).HasColumnName("fullDes");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Properties).HasColumnName("properties");

                entity.Property(e => e.SalePrice).HasColumnName("salePrice");

                entity.Property(e => e.ShortDes)
                    .HasMaxLength(2000)
                    .HasColumnName("shortDes");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");
            });

            modelBuilder.Entity<ProductImage0256>(entity =>
            {
                entity.ToTable("ProductImage_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.Alt)
                    .HasMaxLength(100)
                    .HasColumnName("alt");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.IsDefault)
                    .HasColumnName("isDefault")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ProductId).HasColumnName("productId");
            });

            modelBuilder.Entity<ProductRating0256>(entity =>
            {
                entity.ToTable("ProductRating_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.FullDes).HasColumnName("fullDes");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Vote).HasColumnName("vote");
            });

            modelBuilder.Entity<ProductType0256>(entity =>
            {
                entity.ToTable("ProductType_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Slider0256>(entity =>
            {
                entity.ToTable("Slider_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.Alt)
                    .HasMaxLength(100)
                    .HasColumnName("alt");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.OrderIndex).HasColumnName("orderIndex");
            });

            modelBuilder.Entity<User0256>(entity =>
            {
                entity.ToTable("User_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("firstName");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("lastName");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");
            });

            modelBuilder.Entity<UserType0256>(entity =>
            {
                entity.ToTable("UserType_0256");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.IsPublic)
                    .HasColumnName("isPublic")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.IsTrash)
                    .HasColumnName("isTrash")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.ShortDes)
                    .HasMaxLength(200)
                    .HasColumnName("shortDes");
            });

            modelBuilder.Entity<ViewBrand0256>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ViewBrand_0256");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");

                entity.Property(e => e.IsPopular).HasColumnName("isPopular");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.IsTrash).HasColumnName("isTrash");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.OrderIndex).HasColumnName("orderIndex");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");
            });

            modelBuilder.Entity<ViewCategory0256>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ViewCategory_0256");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");

                entity.Property(e => e.IsPopular).HasColumnName("isPopular");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.IsTrash).HasColumnName("isTrash");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.OrderIndex).HasColumnName("orderIndex");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");
            });

            modelBuilder.Entity<ViewOrder0256>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ViewOrder_0256");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(3)
                    .HasColumnName("createDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("firstName");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.IsTrash).HasColumnName("isTrash");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("lastName");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(100)
                    .HasColumnName("statusName");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.VoucherSale).HasColumnName("voucherSale");
            });

            modelBuilder.Entity<ViewOrderDetail0256>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ViewOrderDetail_0256");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(100)
                    .HasColumnName("brandName");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .HasColumnName("categoryName");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.IsTrash).HasColumnName("isTrash");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(100)
                    .HasColumnName("typeName");
            });

            modelBuilder.Entity<ViewProduct0256>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ViewProduct_0256");

                entity.Property(e => e.Alias)
                    .HasMaxLength(100)
                    .HasColumnName("alias");

                entity.Property(e => e.BrandId).HasColumnName("brandId");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(100)
                    .HasColumnName("brandName");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .HasColumnName("categoryName");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.CurrencyUnit)
                    .HasMaxLength(1)
                    .HasColumnName("currencyUnit");

                entity.Property(e => e.FullDes).HasColumnName("fullDes");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.IsTrash).HasColumnName("isTrash");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Properties).HasColumnName("properties");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.SalePrice).HasColumnName("salePrice");

                entity.Property(e => e.ShortDes)
                    .HasMaxLength(2000)
                    .HasColumnName("shortDes");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(100)
                    .HasColumnName("typeName");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");
            });

            modelBuilder.Entity<ViewProductImage0256>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ViewProductImage_0256");

                entity.Property(e => e.Alt)
                    .HasMaxLength(100)
                    .HasColumnName("alt");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.IsTrash).HasColumnName("isTrash");

                entity.Property(e => e.ProductId).HasColumnName("productId");
            });

            modelBuilder.Entity<ViewSlider0256>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ViewSlider_0256");

                entity.Property(e => e.Alt)
                    .HasMaxLength(100)
                    .HasColumnName("alt");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.IsTrash).HasColumnName("isTrash");

                entity.Property(e => e.OrderIndex).HasColumnName("orderIndex");
            });

            modelBuilder.Entity<ViewStatisOrder0256>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ViewStatisOrder_0256");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(3)
                    .HasColumnName("createDate");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(100)
                    .HasColumnName("statusName");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<ViewStatisUser0256>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ViewStatisUser_0256");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<ViewUser0256>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ViewUser_0256");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("firstName");

                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.ImageUrl).HasColumnName("imageUrl");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.IsTrash).HasColumnName("isTrash");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("lastName");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(100)
                    .HasColumnName("typeName");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
