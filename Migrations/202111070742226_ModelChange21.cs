namespace AttandanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChange21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attandances", "PersonId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attandances", "PersonId");
        }
    }
}
