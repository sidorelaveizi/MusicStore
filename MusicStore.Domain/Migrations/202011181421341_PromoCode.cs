namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PromoCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsFree", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsFree");
        }
    }
}
