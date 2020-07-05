namespace Frizerski_salon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Termins", "Zaposleni_IDZaposleni", "dbo.Zaposlenis");
            DropIndex("dbo.Termins", new[] { "Zaposleni_IDZaposleni" });
            CreateTable(
                "dbo.ZaposleniTermins",
                c => new
                    {
                        Zaposleni_IDZaposleni = c.Int(nullable: false),
                        Termin_IDTermin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Zaposleni_IDZaposleni, t.Termin_IDTermin })
                .ForeignKey("dbo.Zaposlenis", t => t.Zaposleni_IDZaposleni, cascadeDelete: true)
                .ForeignKey("dbo.Termins", t => t.Termin_IDTermin, cascadeDelete: true)
                .Index(t => t.Zaposleni_IDZaposleni)
                .Index(t => t.Termin_IDTermin);
            
            AddColumn("dbo.Zaposlenis", "Usluga_IDUsluga", c => c.Int());
            AlterColumn("dbo.Zaposlenis", "tipZaposlenog", c => c.String(nullable: false, maxLength: 1));
            CreateIndex("dbo.Zaposlenis", "Usluga_IDUsluga");
            AddForeignKey("dbo.Zaposlenis", "Usluga_IDUsluga", "dbo.Uslugas", "IDUsluga");
            DropColumn("dbo.Termins", "Zaposleni_IDZaposleni");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Termins", "Zaposleni_IDZaposleni", c => c.Int());
            DropForeignKey("dbo.Zaposlenis", "Usluga_IDUsluga", "dbo.Uslugas");
            DropForeignKey("dbo.ZaposleniTermins", "Termin_IDTermin", "dbo.Termins");
            DropForeignKey("dbo.ZaposleniTermins", "Zaposleni_IDZaposleni", "dbo.Zaposlenis");
            DropIndex("dbo.ZaposleniTermins", new[] { "Termin_IDTermin" });
            DropIndex("dbo.ZaposleniTermins", new[] { "Zaposleni_IDZaposleni" });
            DropIndex("dbo.Zaposlenis", new[] { "Usluga_IDUsluga" });
            AlterColumn("dbo.Zaposlenis", "tipZaposlenog", c => c.String());
            DropColumn("dbo.Zaposlenis", "Usluga_IDUsluga");
            DropTable("dbo.ZaposleniTermins");
            CreateIndex("dbo.Termins", "Zaposleni_IDZaposleni");
            AddForeignKey("dbo.Termins", "Zaposleni_IDZaposleni", "dbo.Zaposlenis", "IDZaposleni");
        }
    }
}
