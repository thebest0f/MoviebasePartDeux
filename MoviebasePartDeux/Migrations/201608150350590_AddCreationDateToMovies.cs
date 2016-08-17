namespace MoviebasePartDeux.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreationDateToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "CreationDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "CreationDate");
        }
    }
}
