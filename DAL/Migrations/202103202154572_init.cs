namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartProduct",
                c => new
                    {
                        CartID = c.String(nullable: false, maxLength: 128),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CartID, t.ProductID })
                .ForeignKey("dbo.Cart", t => t.CartID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CartID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Image = c.String(),
                        BirthDay = c.DateTime(nullable: false, storeType: "date"),
                        Country = c.String(maxLength: 20),
                        City = c.String(maxLength: 20),
                        Street = c.String(maxLength: 20),
                        PaymentCard = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderHeader",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClientID = c.String(maxLength: 128),
                        OrderDate = c.DateTime(nullable: false, storeType: "date"),
                        TotalPrice = c.Double(nullable: false),
                        CouponDiscount = c.Double(nullable: false),
                        ItemsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ClientID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false, storeType: "date"),
                        TotalPrice = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        ProductID = c.Int(),
                        OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderHeader", t => t.OrderID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(maxLength: 300),
                        Rate = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        PriceSale = c.Double(nullable: false),
                        MainImage = c.String(),
                        SecondaryImage = c.String(),
                        AnotherImage = c.String(),
                        Status = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        ColorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Color", t => t.ColorID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.ColorID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true, name: "CategoryName_index");
            
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ColorName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.ColorName, unique: true, name: "ColorName_index");
            
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.WishlistProducts",
                c => new
                    {
                        Wishlist_ID = c.String(nullable: false, maxLength: 128),
                        Product_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Wishlist_ID, t.Product_ID })
                .ForeignKey("dbo.Wishlists", t => t.Wishlist_ID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_ID, cascadeDelete: true)
                .Index(t => t.Wishlist_ID)
                .Index(t => t.Product_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CartProduct", "ProductID", "dbo.Product");
            DropForeignKey("dbo.CartProduct", "CartID", "dbo.Cart");
            DropForeignKey("dbo.Cart", "ID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Wishlists", "ID", "dbo.AspNetUsers");
            DropForeignKey("dbo.WishlistProducts", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.WishlistProducts", "Wishlist_ID", "dbo.Wishlists");
            DropForeignKey("dbo.Product", "ColorID", "dbo.Color");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.OrderHeader");
            DropForeignKey("dbo.OrderHeader", "ClientID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.WishlistProducts", new[] { "Product_ID" });
            DropIndex("dbo.WishlistProducts", new[] { "Wishlist_ID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Wishlists", new[] { "ID" });
            DropIndex("dbo.Color", "ColorName_index");
            DropIndex("dbo.Category", "CategoryName_index");
            DropIndex("dbo.Product", new[] { "ColorID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderHeader", new[] { "ClientID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Cart", new[] { "ID" });
            DropIndex("dbo.CartProduct", new[] { "ProductID" });
            DropIndex("dbo.CartProduct", new[] { "CartID" });
            DropTable("dbo.WishlistProducts");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Wishlists");
            DropTable("dbo.Color");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.OrderHeader");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Cart");
            DropTable("dbo.CartProduct");
        }
    }
}
