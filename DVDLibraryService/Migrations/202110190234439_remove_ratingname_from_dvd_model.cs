namespace DVDLibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_ratingname_from_dvd_model : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dvds", "RatingName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dvds", "RatingName", c => c.String());
        }
    }
}
