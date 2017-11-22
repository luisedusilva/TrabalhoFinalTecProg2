namespace LocadoraDeVeiculos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes");
            DropForeignKey("dbo.Locacaos", "Vendedor_Id", "dbo.Vendedors");
            DropIndex("dbo.Locacaos", new[] { "Cliente_Id" });
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id" });
            DropIndex("dbo.Locacaos", new[] { "Vendedor_Id" });
            AddColumn("dbo.Locacaos", "DataLocacao_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "Cliente_Id1", c => c.Int());
            AddColumn("dbo.Locacaos", "Veiculo_Id1", c => c.Int());
            AddColumn("dbo.Locacaos", "Vendedor_Id1", c => c.Int());
            AlterColumn("dbo.Locacaos", "Cliente_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "Vendedor_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locacaos", "Cliente_Id1");
            CreateIndex("dbo.Locacaos", "Veiculo_Id1");
            CreateIndex("dbo.Locacaos", "Vendedor_Id1");
            AddForeignKey("dbo.Locacaos", "Cliente_Id1", "dbo.Clientes", "Id");
            AddForeignKey("dbo.Locacaos", "Veiculo_Id1", "dbo.Veiculoes", "Id");
            AddForeignKey("dbo.Locacaos", "Vendedor_Id1", "dbo.Vendedors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "Vendedor_Id1", "dbo.Vendedors");
            DropForeignKey("dbo.Locacaos", "Veiculo_Id1", "dbo.Veiculoes");
            DropForeignKey("dbo.Locacaos", "Cliente_Id1", "dbo.Clientes");
            DropIndex("dbo.Locacaos", new[] { "Vendedor_Id1" });
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id1" });
            DropIndex("dbo.Locacaos", new[] { "Cliente_Id1" });
            AlterColumn("dbo.Locacaos", "Vendedor_Id", c => c.Int());
            AlterColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int());
            AlterColumn("dbo.Locacaos", "Cliente_Id", c => c.Int());
            DropColumn("dbo.Locacaos", "Vendedor_Id1");
            DropColumn("dbo.Locacaos", "Veiculo_Id1");
            DropColumn("dbo.Locacaos", "Cliente_Id1");
            DropColumn("dbo.Locacaos", "DataLocacao_Id");
            CreateIndex("dbo.Locacaos", "Vendedor_Id");
            CreateIndex("dbo.Locacaos", "Veiculo_Id");
            CreateIndex("dbo.Locacaos", "Cliente_Id");
            AddForeignKey("dbo.Locacaos", "Vendedor_Id", "dbo.Vendedors", "Id");
            AddForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes", "Id");
            AddForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes", "Id");
        }
    }
}
