namespace MoviebasePartDeux.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                        MovieDirector = c.String(),
                        MovieYear = c.Int(nullable: false),
                        MovieDesc = c.String(),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
