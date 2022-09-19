namespace DVDLibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removevirtrating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Dvds", new[] { "RatingId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Dvds", "RatingId");
            AddForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings", "RatingId", cascadeDelete: true);
        }
    }
}
