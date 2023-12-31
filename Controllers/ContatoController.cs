using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trabalho_Back_End.Context;
using Trabalho_Back_End.Entities;

namespace Trabalho_Back_End.Controllers
{
     [ApiController]
    [Route("[Controller]")]
    public class ContatoController : Controller
    {
         private readonly AgendaContext _context;
        
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new {id = contato.Id}, contato); // ele manda o id recém criado e informações do contato

        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id){
            var contato = _context.Contatos.Find(id);

            if(contato == null)
                return NotFound();
        
            return Ok(contato);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var contatos = _context.Contatos;
            return Ok(contatos);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome){
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            return Ok(contatos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato){
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
                return NotFound();
            
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
                return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}