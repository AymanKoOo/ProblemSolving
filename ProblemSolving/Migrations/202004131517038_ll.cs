namespace ProblemSolving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        CategoryDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.cats");
        }
    }
}
