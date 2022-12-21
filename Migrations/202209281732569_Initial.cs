namespace GroupBCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.movies",
                c => new
                    {
                        movie_id = c.Int(nullable: false, identity: true),
                        movie_name = c.String(nullable: false, maxLength: 100),
                        genre = c.String(nullable: false, maxLength: 100),
                        runtime = c.String(nullable: false, maxLength: 100),
                        release_date = c.String(nullable: false, maxLength: 100),
                        language = c.String(nullable: false, maxLength: 100),
                        subtitle = c.String(nullable: false, maxLength: 100),
                        description = c.String(nullable: false),
                        image_path = c.String(nullable: false, maxLength: 100),
                        video_path = c.String(nullable: false, maxLength: 1000),
                        rating = c.String(nullable: false, maxLength: 100),
                        director = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.movie_id);
            
            CreateTable(
                "dbo.shows",
                c => new
                    {
                        show_id = c.Int(nullable: false, identity: true),
                        movie_id = c.Int(nullable: false),
                        theater_id = c.Int(nullable: false),
                        date = c.DateTime(nullable: false, storeType: "date"),
                        timing = c.Time(precision: 7),
                        price = c.Double(),
                    })
                .PrimaryKey(t => t.show_id)
                .ForeignKey("dbo.movies", t => t.movie_id, cascadeDelete: true)
                .ForeignKey("dbo.theaters", t => t.theater_id, cascadeDelete: true)
                .Index(t => t.movie_id)
                .Index(t => t.theater_id);
            
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        show_id = c.Int(),
                        total_tickets = c.Int(nullable: false),
                        total_cost = c.Double(nullable: false),
                        date = c.DateTime(nullable: false, storeType: "date"),
                        card_id = c.Int(),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.shows", t => t.show_id)
                .ForeignKey("dbo.users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.show_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        last_name = c.String(nullable: false, maxLength: 25),
                        first_name = c.String(nullable: false, maxLength: 25),
                        phone = c.String(nullable: false, maxLength: 15),
                        street_no = c.String(nullable: false, maxLength: 4),
                        street_name = c.String(nullable: false, maxLength: 20),
                        city = c.String(nullable: false, maxLength: 15),
                        province = c.String(nullable: false, maxLength: 15),
                        postal_code = c.String(nullable: false, maxLength: 7),
                        country = c.String(nullable: false, maxLength: 15),
                        email = c.String(nullable: false, maxLength: 100),
                        password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.theaters",
                c => new
                    {
                        theater_id = c.Int(nullable: false, identity: true),
                        theater_name = c.String(nullable: false, maxLength: 100),
                        city = c.String(maxLength: 20),
                        country = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.theater_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.shows", "theater_id", "dbo.theaters");
            DropForeignKey("dbo.orders", "user_id", "dbo.users");
            DropForeignKey("dbo.orders", "show_id", "dbo.shows");
            DropForeignKey("dbo.shows", "movie_id", "dbo.movies");
            DropIndex("dbo.orders", new[] { "show_id" });
            DropIndex("dbo.orders", new[] { "user_id" });
            DropIndex("dbo.shows", new[] { "theater_id" });
            DropIndex("dbo.shows", new[] { "movie_id" });
            DropTable("dbo.theaters");
            DropTable("dbo.users");
            DropTable("dbo.orders");
            DropTable("dbo.shows");
            DropTable("dbo.movies");
        }
    }
}
