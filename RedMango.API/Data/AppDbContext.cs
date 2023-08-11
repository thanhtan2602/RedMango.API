using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedMango.API.Models;

namespace RedMango.API.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MenuItem>().HasData(new MenuItem
            {
                Id = 1,
                Name = "Spring Roll",
                Description = "Spring Roll Description",
                Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 2,
                Name = "Spring Roll 2",
                Description = "Spring Roll Description",
                Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 3,
                Name = "Spring Roll 3",
                Description = "Spring Roll Description",
                Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 4,
                Name = "Spring Roll 4",
                Description = "Spring Roll Description",
                Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 5,
                Name = "Spring Roll 5",
                Description = "Spring Roll Description",
                Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 6,
                Name = "Spring Roll 6",
                Description = "Spring Roll Description",
                Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 7,
                Name = "Spring Roll 7",
                Description = "Spring Roll Description",
                Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 8,
                Name = "Spring Roll 8",
                Description = "Spring Roll Description",
                Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 9,
                Name = "Spring Roll 9",
                Description = "Spring Roll Description",
                Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 10,
                Name = "Spring Roll 10",
                Description = "Spring Roll Description",
                Image = "https://cdn.tgdd.vn//Files/News/2023/04/15/toan-bo-thong-tin-ve-ios-17-ngay-ra-mat-tinh-nang-thumb-560x292-1.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            });
        }
    }
}
