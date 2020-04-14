namespace ProblemSolving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class piccc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubProblems", "probImg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubProblems", "probImg");
        }
    }
}
