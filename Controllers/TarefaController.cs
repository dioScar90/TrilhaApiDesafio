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
        public IActionResult PesquisarResult(Tarefa tarefa)
        {
            int idAux = tarefa.Id;
            List<Tarefa> retorno = new();

            Console.WriteLine(
                "\n\n\n\n\n\n" +
                $"Passando por OrganizarPesquisa({idAux})" +
                $"\nData: {tarefa.Status}" +
                "\n\n\n\n\n"
            );

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

            if (tarefa == null)
                return RedirectToAction(nameof(Index));
            
            Console.WriteLine($"Aqui PORRAAAAAAAAAA {tarefa.Titulo}");
            return View(tarefa);
        }

        public List<Tarefa> ObterPorTitulo(string titulo)
        {
            var tarefasDoBanco = _context.Tarefas.Where(
                x => x.Titulo == titulo
            ).ToList();
            
            // Console.WriteLine("<script>alert('aquiiii')</script>");

            // if (tarefasDoBanco == null)
            //     return RedirectToAction(nameof(Index));

            Console.WriteLine($"AQUI PORRAAAAAAAAAA {tarefasDoBanco[0].Id}");
            
            return tarefasDoBanco;
        }

        public List<Tarefa> ObterPorData(DateTime data)
        {
            var tarefasDoBanco = _context.Tarefas.ToList();
            
            // Console.WriteLine("<script>alert('aquiiii')</script>");

            // if (tarefasDoBanco == null)
            //     return RedirectToAction(nameof(Index));
            
            return tarefasDoBanco;
        }

        public List<Tarefa> ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefasDoBanco = _context.Tarefas.ToList();
            
            // Console.WriteLine("<script>alert('aquiiii')</script>");

            // if (tarefasDoBanco == null)
            //     return RedirectToAction(nameof(Index));
            
            return tarefasDoBanco;
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