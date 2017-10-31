namespace LocadoraDeVeiculos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class veiculo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes");
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id" });
            AddColumn("dbo.Locacaos", "Veiculo", c => c.String(nullable: false));
            DropColumn("dbo.Locacaos", "Veiculo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Locacaos", "Veiculo");
            CreateIndex("dbo.Locacaos", "Veiculo_Id");
            AddForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes", "Id", cascadeDelete: true);
        }
    }
}
