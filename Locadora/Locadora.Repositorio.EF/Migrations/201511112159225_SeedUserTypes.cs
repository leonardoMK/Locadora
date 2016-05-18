namespace Locadora.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserTypes : DbMigration
    {
        public override void Up()
        {
            PopularPermissoes();
            PopularUsuarios();
        }
        
        public override void Down()
        {
        }
        public void PopularPermissoes()
        {
            Sql("insert into Permissao (Nome) values('ADMIN');");
            Sql("insert into Permissao (Nome) values('OPERADOR');");
        }
        public void PopularUsuarios()
        {
            Sql("insert into usuario (Email,NomeCompleto,Senha) values('adm@cwi.com.br','administrador','F4EF43109FFAD3EA8DBE2E3356A9CE77');");
            Sql("insert into usuario (Email,NomeCompleto,Senha) values('op@cwi.com.br','operador','DB6A8F0081B293E97CD5D4E11CE39371');");
        }
    }
}
