using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Context;
using SistemaTarefas.Models;

namespace SistemaTarefas.Controllers 
{
    public class TarefaController : Controller 
    {
        private readonly AgendaContext _context;
        public TarefaController(AgendaContext context) 
        {
            _context = context;
        }
        public ActionResult Index() 
        {
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }

        public ActionResult Criar() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Tarefa tarefa) 
        {
            if(ModelState.IsValid) 
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }

        public ActionResult Editar(int id) 
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null)
                return RedirectToAction(nameof(Index));
            return View(tarefa);
        }

        [HttpPost]
        public ActionResult Editar(Tarefa tarefa) 
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Detalhes(int id) 
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa is null) 
                return RedirectToAction(nameof(Index));
            return View(tarefa);    
        }

        public ActionResult Deletar(int id) 
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa is null)
                return RedirectToAction(nameof(Index));
            return View(tarefa);
        }

        [HttpPost]
        public ActionResult Deletar(Tarefa tarefa) 
        {
            var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        
    }
}