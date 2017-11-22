namespace LocadoraDeVeiculos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes");
            DropForeignKey("dbo.Locacaos", "Vendedor_Id", "dbo.Vendedors");
            DropIndex("dbo.Locacaos", new[] { "Cliente_Id" });
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id" });
            DropIndex("dbo.Locacaos", new[] { "Vendedor_Id" });
            AlterColumn("dbo.Locacaos", "DataLocacao", c => c.String());
            AlterColumn("dbo.Locacaos", "Cliente_Id", c => c.Int());
            AlterColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int());
            AlterColumn("dbo.Locacaos", "Vendedor_Id", c => c.Int());
            CreateIndex("dbo.Locacaos", "Cliente_Id");
            CreateIndex("dbo.Locacaos", "Veiculo_Id");
            CreateIndex("dbo.Locacaos", "Vendedor_Id");
            AddForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes", "Id");
            AddForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes", "Id");
            AddForeignKey("dbo.Locacaos", "Vendedor_Id", "dbo.Vendedors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "Vendedor_Id", "dbo.Vendedors");
            DropForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes");
            DropForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Locacaos", new[] { "Vendedor_Id" });
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id" });
            DropIndex("dbo.Locacaos", new[] { "Cliente_Id" });
            AlterColumn("dbo.Locacaos", "Vendedor_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "Cliente_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "DataLocacao", c => c.String(nullable: false));
            CreateIndex("dbo.Locacaos", "Vendedor_Id");
            CreateIndex("dbo.Locacaos", "Veiculo_Id");
            CreateIndex("dbo.Locacaos", "Cliente_Id");
            AddForeignKey("dbo.Locacaos", "Vendedor_Id", "dbo.Vendedors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes", "Id", cascadeDelete: true);
        }
    }
}
