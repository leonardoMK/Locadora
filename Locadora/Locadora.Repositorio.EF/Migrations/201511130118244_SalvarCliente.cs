namespace Locadora.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalvarCliente : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.jogo", name: "ClienteLocacao", newName: "IdCliente");
            RenameIndex(table: "dbo.jogo", name: "IX_ClienteLocacao", newName: "IX_IdCliente");
            AddColumn("dbo.jogo", "Cliente_Id", c => c.Int());
            AlterColumn("dbo.jogo", "DataDevolucao", c => c.DateTime());
            CreateIndex("dbo.jogo", "Cliente_Id");
            AddForeignKey("dbo.jogo", "Cliente_Id", "dbo.cliente", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.jogo", "Cliente_Id", "dbo.cliente");
            DropIndex("dbo.jogo", new[] { "Cliente_Id" });
            AlterColumn("dbo.jogo", "DataDevolucao", c => c.DateTime(nullable: false));
            DropColumn("dbo.jogo", "Cliente_Id");
            RenameIndex(table: "dbo.jogo", name: "IX_IdCliente", newName: "IX_ClienteLocacao");
            RenameColumn(table: "dbo.jogo", name: "IdCliente", newName: "ClienteLocacao");
        }
    }
}
