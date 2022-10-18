using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    public class TarefaController : Controller
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        public IActionResult Pesquisar()
        {
            return View();
        }
        
        public IActionResult Editar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
                return NotFound();
            
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            var tarefaDoBanco = _context.Tarefas.Find(tarefa.Id);

            tarefaDoBanco.Titulo = tarefa.Titulo;
            tarefaDoBanco.Descricao = tarefa.Descricao;
            tarefaDoBanco.Data = tarefa.Data;
            tarefaDoBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaDoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
                return RedirectToAction(nameof(Index));
            
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult OrganizarPesquisa(Tarefa tarefa)
        {
            int idAux = tarefa.Id;
            var retorno = tarefa;

            switch (idAux)
            {
                case 1:
                    retorno = ObterPorTitulo(tarefa.Titulo);
                    break;
                case 2:
                    retorno = ObterPorData(tarefa.Data);
                    break;
                case 3:
                    retorno = ObterPorStatus(tarefa.Status);
                    break;
            }
        }

        [HttpPost]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefasDoBanco = _context.Tarefas.Find(tarefa.Titulo);
            
            Console.WriteLine("<script>alert('aquiiii')</script>");

            if (tarefasDoBanco == null)
                return RedirectToAction(nameof(Index));
            
            return tarefasDoBanco;
        }

        [HttpPost]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefasDoBanco = _context.Tarefas.Find(tarefa.Data);
            
            Console.WriteLine("<script>alert('aquiiii')</script>");

            if (tarefasDoBanco == null)
                return RedirectToAction(nameof(Index));
            
            return View(tarefasDoBanco);
        }

        [HttpPost]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefasDoBanco = _context.Tarefas.Find(tarefa.Status);
            
            Console.WriteLine("<script>alert('aquiiii')</script>");

            if (tarefasDoBanco == null)
                return RedirectToAction(nameof(Index));
            
            return View(tarefasDoBanco);
        }

        public IActionResult Deletar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
                return RedirectToAction(nameof(Index));
            
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Deletar(Tarefa tarefa)
        {
            var tarefaDoBanco = _context.Tarefas.Find(tarefa.Id);

            _context.Tarefas.Remove(tarefaDoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}