using Locadora.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Dominio.Servicos
{
    public class ServicoAutenticacao
    {
        private IUsuarioRepositorio usuarioRepositorio;
        private IServicoCriptografia servicoCriptografia;
        public ServicoAutenticacao(IUsuarioRepositorio usuarioRepositorio, IServicoCriptografia servicoCriptografia)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.servicoCriptografia = servicoCriptografia;
        }

        public Usuario BuscarPorAutenticacao(string email, string password)
        {
            var usuario = usuarioRepositorio.BuscarPorEmail(email);
            if (usuario != null)
            {
                string senhaCriptografada = servicoCriptografia.CriptografarSenha(password);
                if (senhaCriptografada == usuario.Senha)
                {
                    return usuario;
                }
            }
            return null;
        }
    }
}
