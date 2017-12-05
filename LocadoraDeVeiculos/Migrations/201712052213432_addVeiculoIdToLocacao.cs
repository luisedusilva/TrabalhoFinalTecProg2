namespace LocadoraDeVeiculos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVeiculoIdToLocacao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes");
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id" });
            RenameColumn(table: "dbo.Locacaos", name: "Veiculo_Id", newName: "VeiculoId");
            AlterColumn("dbo.Locacaos", "VeiculoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Locacaos", "VeiculoId");
            AddForeignKey("dbo.Locacaos", "VeiculoId", "dbo.Veiculoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "VeiculoId", "dbo.Veiculoes");
            DropIndex("dbo.Locacaos", new[] { "VeiculoId" });
            AlterColumn("dbo.Locacaos", "VeiculoId", c => c.Int());
            RenameColumn(table: "dbo.Locacaos", name: "VeiculoId", newName: "Veiculo_Id");
            CreateIndex("dbo.Locacaos", "Veiculo_Id");
            AddForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes", "Id");
        }
    }
}
