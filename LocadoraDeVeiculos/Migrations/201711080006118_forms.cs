namespace LocadoraDeVeiculos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locacaos", "Cliente_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "Vendedor_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locacaos", "Cliente_Id");
            CreateIndex("dbo.Locacaos", "Veiculo_Id");
            CreateIndex("dbo.Locacaos", "Vendedor_Id");
            AddForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "Vendedor_Id", "dbo.Vendedors", "Id", cascadeDelete: true);
            DropColumn("dbo.Locacaos", "Veiculo");
            DropColumn("dbo.Locacaos", "DataDevolucao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locacaos", "DataDevolucao", c => c.String(nullable: false));
            AddColumn("dbo.Locacaos", "Veiculo", c => c.String(nullable: false));
            DropForeignKey("dbo.Locacaos", "Vendedor_Id", "dbo.Vendedors");
            DropForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes");
            DropForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Locacaos", new[] { "Vendedor_Id" });
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id" });
            DropIndex("dbo.Locacaos", new[] { "Cliente_Id" });
            DropColumn("dbo.Locacaos", "Vendedor_Id");
            DropColumn("dbo.Locacaos", "Veiculo_Id");
            DropColumn("dbo.Locacaos", "Cliente_Id");
        }
    }
}
