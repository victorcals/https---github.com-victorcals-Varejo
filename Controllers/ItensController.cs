﻿using System.Collections.Generic;
using System.Linq;
using Atacadista.Models;
using Microsoft.AspNetCore.Mvc;
namespace Atacadista.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class ItemController : ControllerBase
    {

        private DataContext _context;

        public ItemController(DataContext context) => _context = context;

        private static List<Itens> itens = new List<Itens>();


        
        [Route("Listar")]
        [HttpGet]
        public IActionResult Listar() => 
            Ok(_context.Itens.ToList());


        
        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Itens item)
        {

            _context.Itens.Add(item);
            _context.SaveChanges();
            return Created("", item);

        }

        [Route("buscar/produto")]
        [HttpGet]
        public IActionResult Buscar([FromRoute] string Codigo)
        {
            Itens item =
                _context.Itens.FirstOrDefault
            (
                f => f.Codigo.Equals(Codigo)
            );
            
            return item != null ? Ok(item) : NotFound();
        }


        [Route("deletar/{id}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] int id)
        {
            Itens Item =
                _context.Itens.Find(id);
            if (Item != null)
            {
                _context.Itens.Remove(Item);
                _context.SaveChanges();
                return Ok(Item);
            }
            return NotFound();
        }


        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] Itens item)
        {
            {
            _context.Itens.Update(item);
            _context.SaveChanges();
            return Ok(item);
        }
        }

        /* Baixar SQLlite
        versão utilizada no programa  --version 5.0.4
        https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/5.0.4
        comanda para colcoar no terminak ↓↓
        dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 5.0.4

        site do sqlite 
        https://sqlitebrowser.org/

        */


    }

}