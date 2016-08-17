namespace MoviebasePartDeux.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "CreationDate", c => c.String());
        }
    }
}
