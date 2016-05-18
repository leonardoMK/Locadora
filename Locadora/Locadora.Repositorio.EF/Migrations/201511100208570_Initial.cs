namespace Locadora.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cliente",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 250),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.jogo",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 250),
                    Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Categoria = c.Int(nullable: false),
                    Descricao = c.String(nullable: false, maxLength: 1500),
                    Selo = c.Int(nullable: false),
                    Imagem = c.String(maxLength: 200),
                    Video = c.String(maxLength: 200),
                    ClienteLocacao = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.cliente", t => t.ClienteLocacao)
                .ForeignKey("dbo.selo", t => t.Selo)
                .ForeignKey("dbo.categoria", t => t.Categoria)
                .Index(t => t.ClienteLocacao)
                .Index(t => t.Selo)
                .Index(t => t.Categoria);

            CreateTable(
                "dbo.selo",
                c => new
                {
                    Id = c.Int(nullable: false, identity: false),
                    Nome = c.String(nullable: false, maxLength: 50),
                })
               .PrimaryKey(t => t.Id);
            CriarSelos();

            CreateTable(
               "dbo.categoria",
               c => new
               {
                   Id = c.Int(nullable: false, identity: false),
                   Nome = c.String(nullable: false, maxLength: 50),
               })
              .PrimaryKey(t => t.Id);
            CriarCategoria();

        }
       
        public override void Down()
        {
            DropForeignKey("dbo.jogo", "ClienteLocacao", "dbo.cliente");
            DropForeignKey("dbo.jogo", "Selo", "dbo.selo");
            DropForeignKey("dbo.jogo", "Categoria", "dbo.categoria");
            DropIndex("dbo.jogo", new[] { "ClienteLocacao" });
            DropIndex("dbo.jogo", new[] { "Selo" });
            DropIndex("dbo.jogo", new[] { "Categoria" });
            DropTable("dbo.jogo");
            DropTable("dbo.cliente");
            DropTable("dbo.selo");
            DropTable("dbo.categoria");
        }


        public void CriarSelos()
        {
            Sql("INSERT INTO dbo.Categoria VALUES (1, 'Bronze')");
            Sql("INSERT INTO dbo.Categoria VALUES (2, 'Prata')");
            Sql("INSERT INTO dbo.Categoria VALUES (3, 'Ouro')");
        }
        public void CriarCategoria()
        {
            Sql("INSERT INTO dbo.Categoria VALUES (1, 'RPG');"+
                " INSERT INTO dbo.Categoria VALUES(2, 'Corrida');"+
                " INSERT INTO dbo.Categoria VALUES(3, 'Aventura');"+
                " INSERT INTO dbo.Categoria VALUES(4, 'Luta');"+
                " INSERT INTO dbo.Categoria VALUES(5, 'Esporte');");
        }
    }
}
