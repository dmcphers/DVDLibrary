namespace DVDLibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvirtrating : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Dvds", "RatingId");
            AddForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings", "RatingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Dvds", new[] { "RatingId" });
        }
    }
}
