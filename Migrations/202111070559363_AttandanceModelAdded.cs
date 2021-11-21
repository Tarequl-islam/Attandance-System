namespace AttandanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttandanceModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attandances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsEntry = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
            DropTable("dbo.Attandances");
        }
    }
}
