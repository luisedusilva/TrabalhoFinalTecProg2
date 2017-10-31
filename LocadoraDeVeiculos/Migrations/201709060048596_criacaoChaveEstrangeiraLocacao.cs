namespace LocadoraDeVeiculos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaoChaveEstrangeiraLocacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locacaos", "Veiculo_Id", c => c.Int());
            CreateIndex("dbo.Locacaos", "Veiculo_Id");
            AddForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "Veiculo_Id", "dbo.Veiculoes");
            DropIndex("dbo.Locacaos", new[] { "Veiculo_Id" });
            DropColumn("dbo.Locacaos", "Veiculo_Id");
        }
    }
}
