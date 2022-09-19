namespace DVDLibraryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_rating_field_to_dvd_model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dvds", "RatingName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dvds", "RatingName");
        }
    }
}
