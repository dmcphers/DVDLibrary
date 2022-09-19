namespace DVDLibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        ReleaseYear = c.Int(nullable: false),
                        DirectorName = c.String(maxLength: 50),
                        RatingId = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.DvdId)
                .ForeignKey("dbo.Ratings", t => t.RatingId)
                .Index(t => t.RatingId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RatingName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Dvds", new[] { "RatingId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Dvds");
        }
    }
}
