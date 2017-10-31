namespace LocadoraDeVeiculos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Luis : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes");
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id" });
            AlterColumn("dbo.Locacaos", "DataLocacao", c => c.String(nullable: false));
            AlterColumn("dbo.Locacaos", "DataDevolucao", c => c.String(nullable: false));
            AlterColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Veiculoes", "Marca", c => c.String(nullable: false));
            AlterColumn("dbo.Veiculoes", "Modelo", c => c.String(nullable: false));
            AlterColumn("dbo.Veiculoes", "Placa", c => c.String(nullable: false));
            AlterColumn("dbo.Vendedors", "Nome", c => c.String(nullable: false));
            CreateIndex("dbo.Locacaos", "Veiculo_Id");
            AddForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes");
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id" });
            AlterColumn("dbo.Vendedors", "Nome", c => c.String());
            AlterColumn("dbo.Veiculoes", "Placa", c => c.String());
            AlterColumn("dbo.Veiculoes", "Modelo", c => c.String());
            AlterColumn("dbo.Veiculoes", "Marca", c => c.String());
            AlterColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int());
            AlterColumn("dbo.Locacaos", "DataDevolucao", c => c.String());
            AlterColumn("dbo.Locacaos", "DataLocacao", c => c.String());
            CreateIndex("dbo.Locacaos", "Veiculo_Id");
            AddForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes", "Id");
        }
    }
}
