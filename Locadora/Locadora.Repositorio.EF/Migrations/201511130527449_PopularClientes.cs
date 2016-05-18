namespace Locadora.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopularClientes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.jogo", "Cliente_Id", "dbo.cliente");
            DropIndex("dbo.jogo", new[] { "Cliente_Id" });
            DropColumn("dbo.jogo", "Cliente_Id");
            GerarClientes();
        }
        
        public override void Down()
        {
            AddColumn("dbo.jogo", "Cliente_Id", c => c.Int());
            CreateIndex("dbo.jogo", "Cliente_Id");
            AddForeignKey("dbo.jogo", "Cliente_Id", "dbo.cliente", "Id");
        }
        public void GerarClientes()
        {
            Sql("insert into cliente(Nome) values('cliente1')");
            Sql("insert into cliente(Nome) values('cliente2')");
            Sql("insert into cliente(Nome) values('Alguem')");
            Sql("insert into cliente(Nome) values('AClient')");
            Sql("insert into cliente(Nome) values('ClientOne')");
            Sql("insert into cliente(Nome) values('Legolas')");
            Sql("insert into cliente(Nome) values('Gimli')");
            Sql("insert into cliente(Nome) values('Aragorn')");
            Sql("insert into cliente(Nome) values('Gandalf')");

        }
    }
}
