namespace ProblemSolving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class img : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Problems", "JobImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Problems", "JobImage");
        }
    }
}
