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
            
            tarefas = tarefas.OrderBy(o => o.Data).ToList();
            
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
        public IActionResult ResultadoDaPesquisa(Tarefa tarefa)
        {
            int idAux = tarefa.Id;
            
            switch (idAux)
            {
                case 1:
                    var tarefa1 = _context.Tarefas.Where(
                        x => x.Titulo == tarefa.Titulo
                    ).ToList();

                    return tarefa1 == null ? NotFound() : View(tarefa1);
                case 2:
                    var tarefa2 = _context.Tarefas.Where(
                        x => x.Data == tarefa.Data
                    ).ToList();

                    return tarefa2 == null ? NotFound() : View(tarefa2);
                case 3:
                    var tarefa3 = _context.Tarefas.Where(
                        x => x.Status == tarefa.Status
                    ).ToList();

                    return tarefa3 == null ? NotFound() : View(tarefa3);
                default:
                    return NotFound();
            }
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