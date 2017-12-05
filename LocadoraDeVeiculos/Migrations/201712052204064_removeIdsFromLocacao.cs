namespace LocadoraDeVeiculos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeIdsFromLocacao : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Locacaos", new[] { "Cliente_Id1" });
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id1" });
            DropIndex("dbo.Locacaos", new[] { "Vendedor_Id1" });
            DropColumn("dbo.Locacaos", "Cliente_Id");
            DropColumn("dbo.Locacaos", "Veiculo_Id");
            DropColumn("dbo.Locacaos", "Vendedor_Id");
            RenameColumn(table: "dbo.Locacaos", name: "Cliente_Id1", newName: "Cliente_Id");
            RenameColumn(table: "dbo.Locacaos", name: "Veiculo_Id1", newName: "Veiculo_Id");
            RenameColumn(table: "dbo.Locacaos", name: "Vendedor_Id1", newName: "Vendedor_Id");
            AlterColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int());
            AlterColumn("dbo.Locacaos", "Cliente_Id", c => c.Int());
            AlterColumn("dbo.Locacaos", "Vendedor_Id", c => c.Int());
            CreateIndex("dbo.Locacaos", "Cliente_Id");
            CreateIndex("dbo.Locacaos", "Veiculo_Id");
            CreateIndex("dbo.Locacaos", "Vendedor_Id");
            DropColumn("dbo.Locacaos", "DataLocacao_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locacaos", "DataLocacao_Id", c => c.Int(nullable: false));
            DropIndex("dbo.Locacaos", new[] { "Vendedor_Id" });
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id" });
            DropIndex("dbo.Locacaos", new[] { "Cliente_Id" });
            AlterColumn("dbo.Locacaos", "Vendedor_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "Cliente_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Locacaos", name: "Vendedor_Id", newName: "Vendedor_Id1");
            RenameColumn(table: "dbo.Locacaos", name: "Veiculo_Id", newName: "Veiculo_Id1");
            RenameColumn(table: "dbo.Locacaos", name: "Cliente_Id", newName: "Cliente_Id1");
            AddColumn("dbo.Locacaos", "Vendedor_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Locacaos", "Cliente_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locacaos", "Vendedor_Id1");
            CreateIndex("dbo.Locacaos", "Veiculo_Id1");
            CreateIndex("dbo.Locacaos", "Cliente_Id1");
        }
    }
}
