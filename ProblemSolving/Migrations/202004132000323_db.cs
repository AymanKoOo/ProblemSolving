namespace ProblemSolving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        ProblemID = c.Int(nullable: false, identity: true),
                        ProblemName = c.String(nullable: false),
                        ProblemDescription = c.String(nullable: false),
                        catId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProblemID)
                .ForeignKey("dbo.cats", t => t.catId, cascadeDelete: true)
                .Index(t => t.catId);
            
            CreateTable(
                "dbo.SubProblems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SubProbName = c.String(nullable: false),
                        SubProbNameDescription = c.String(nullable: false),
                        problemId = c.Int(nullable: false),
                        code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Problems", t => t.problemId, cascadeDelete: true)
                .Index(t => t.problemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubProblems", "problemId", "dbo.Problems");
            DropForeignKey("dbo.Problems", "catId", "dbo.cats");
            DropIndex("dbo.SubProblems", new[] { "problemId" });
            DropIndex("dbo.Problems", new[] { "catId" });
            DropTable("dbo.SubProblems");
            DropTable("dbo.Problems");
        }
    }
}
