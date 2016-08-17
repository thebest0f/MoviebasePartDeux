namespace MoviebasePartDeux.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKtoMovie : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "GenreRefId");
            RenameIndex(table: "dbo.Movies", name: "IX_GenreId", newName: "IX_GenreRefId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_GenreRefId", newName: "IX_GenreId");
            RenameColumn(table: "dbo.Movies", name: "GenreRefId", newName: "GenreId");
        }
    }
}
