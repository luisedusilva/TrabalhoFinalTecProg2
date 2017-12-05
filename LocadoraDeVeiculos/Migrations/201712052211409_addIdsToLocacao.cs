namespace LocadoraDeVeiculos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIdsToLocacao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Locacaos", "Vendedor_Id", "dbo.Vendedors");
            DropIndex("dbo.Locacaos", new[] { "Cliente_Id" });
            DropIndex("dbo.Locacaos", new[] { "Vendedor_Id" });
            RenameColumn(table: "dbo.Locacaos", name: "Cliente_Id", newName: "ClienteId");
            RenameColumn(table: "dbo.Locacaos", name: "Vendedor_Id", newName: "VendedorId");
            AlterColumn("dbo.Locacaos", "ClienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacaos", "VendedorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Locacaos", "ClienteId");
            CreateIndex("dbo.Locacaos", "VendedorId");
            AddForeignKey("dbo.Locacaos", "ClienteId", "dbo.Clientes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "VendedorId", "dbo.Vendedors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "VendedorId", "dbo.Vendedors");
            DropForeignKey("dbo.Locacaos", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Locacaos", new[] { "VendedorId" });
            DropIndex("dbo.Locacaos", new[] { "ClienteId" });
            AlterColumn("dbo.Locacaos", "VendedorId", c => c.Int());
            AlterColumn("dbo.Locacaos", "ClienteId", c => c.Int());
            RenameColumn(table: "dbo.Locacaos", name: "VendedorId", newName: "Vendedor_Id");
            RenameColumn(table: "dbo.Locacaos", name: "ClienteId", newName: "Cliente_Id");
            CreateIndex("dbo.Locacaos", "Vendedor_Id");
            CreateIndex("dbo.Locacaos", "Cliente_Id");
            AddForeignKey("dbo.Locacaos", "Vendedor_Id", "dbo.Vendedors", "Id");
            AddForeignKey("dbo.Locacaos", "Cliente_Id", "dbo.Clientes", "Id");
        }
    }
}
