namespace Frizerski_salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Zaposlenis", "Usluga_IDUsluga", "dbo.Uslugas");
            DropIndex("dbo.Zaposlenis", new[] { "Usluga_IDUsluga" });
            CreateTable(
                "dbo.ZaposleniUslugas",
                c => new
                    {
                        Zaposleni_IDZaposleni = c.Int(nullable: false),
                        Usluga_IDUsluga = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Zaposleni_IDZaposleni, t.Usluga_IDUsluga })
                .ForeignKey("dbo.Zaposlenis", t => t.Zaposleni_IDZaposleni, cascadeDelete: true)
                .ForeignKey("dbo.Uslugas", t => t.Usluga_IDUsluga, cascadeDelete: true)
                .Index(t => t.Zaposleni_IDZaposleni)
                .Index(t => t.Usluga_IDUsluga);
            
            DropColumn("dbo.Zaposlenis", "Usluga_IDUsluga");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zaposlenis", "Usluga_IDUsluga", c => c.Int());
            DropForeignKey("dbo.ZaposleniUslugas", "Usluga_IDUsluga", "dbo.Uslugas");
            DropForeignKey("dbo.ZaposleniUslugas", "Zaposleni_IDZaposleni", "dbo.Zaposlenis");
            DropIndex("dbo.ZaposleniUslugas", new[] { "Usluga_IDUsluga" });
            DropIndex("dbo.ZaposleniUslugas", new[] { "Zaposleni_IDZaposleni" });
            DropTable("dbo.ZaposleniUslugas");
            CreateIndex("dbo.Zaposlenis", "Usluga_IDUsluga");
            AddForeignKey("dbo.Zaposlenis", "Usluga_IDUsluga", "dbo.Uslugas", "IDUsluga");
        }
    }
}
