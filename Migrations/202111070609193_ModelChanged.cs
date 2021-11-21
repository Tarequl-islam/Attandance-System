namespace AttandanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attandances", "IsEntryId", c => c.Int(nullable: false));
            AddColumn("dbo.People", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Attandances", "IsEntry");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attandances", "IsEntry", c => c.Int(nullable: false));
            DropColumn("dbo.People", "Address");
            DropColumn("dbo.Attandances", "IsEntryId");
        }
    }
}
