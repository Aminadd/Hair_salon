namespace Frizerski_salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uslugas", "imeFrizera", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Uslugas", "vrsta_usluge", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uslugas", "vrsta_usluge", c => c.String());
            DropColumn("dbo.Uslugas", "imeFrizera");
        }
    }
}
