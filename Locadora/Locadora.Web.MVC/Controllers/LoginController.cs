﻿using Locadora.Dominio;
using Locadora.Dominio.Servicos;
using Locadora.Repositorio.EF;
using Locadora.Web.MVC.Helpers;
using Locadora.Web.MVC.Models;
using Locadora.Web.MVC.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Locadora.Web.MVC.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                ServicoAutenticacao servicoAutenticacao = FabricaDeModulos.CriarServicoAutenticacao();

                Usuario usuarioAutenticado = servicoAutenticacao.BuscarPorAutenticacao(loginModel.Email, loginModel.Password);

                if (usuarioAutenticado != null)
                {
                    ControleDeSessao.CriarSessao(usuarioAutenticado);
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("INVALID_LOGIN", "Usuário ou senha inválidos.");
            return View("Index", loginModel);
        }

        public ActionResult Sair()
        {
            ControleDeSessao.Encerrar();
            return RedirectToAction("Index");
        }
    }
}