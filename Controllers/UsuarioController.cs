using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nova_pasta.Models;
using Nova_pasta.Repositorio;

namespace Nova_pasta.Controllers
{
        public class UsuarioController : Controller
        {
        [HttpGet]
        public IActionResult Index(){


        return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form){
            UsuarioModel usuario = new UsuarioModel(
                nome: form["nome"],
                email: form["email"],
                senha: form["senha"],
                dataNascimento: DateTime.Parse(form["dataNascimento"])
            );     
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

            usuarioRepositorio.CadastrarUsuario(usuario);

            return RedirectToAction("Index","Usuario");
        }

        [HttpGet]
        public IActionResult Listar(){

            
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            ViewData["usuarios"] = usuarioRepositorio.Listar();

            return View();
        }
    }
}
