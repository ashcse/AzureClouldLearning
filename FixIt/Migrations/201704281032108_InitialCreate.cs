namespace FixIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FixitTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(maxLength: 80),
                        Title = c.String(maxLength: 80),
                        Notes = c.String(maxLength: 100),
                        PhotoUrl = c.String(maxLength: 300),
                        IsDone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FixitTasks");
        }
    }
}
