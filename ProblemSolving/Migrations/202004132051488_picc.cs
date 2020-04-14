namespace ProblemSolving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class picc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Problems", "probImg", c => c.String());
            DropColumn("dbo.Problems", "JobImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Problems", "JobImage", c => c.String());
            DropColumn("dbo.Problems", "probImg");
        }
    }
}
