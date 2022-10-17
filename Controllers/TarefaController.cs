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