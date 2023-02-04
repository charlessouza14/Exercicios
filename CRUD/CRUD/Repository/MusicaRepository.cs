using CRUD.Controllers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

namespace CRUD.Repository.Interfaces
{
    public class MusicaRepository : ControllerBase
    {
        public void Adicionar(Musica musica)
        {
            Contexto contexto = new Contexto();
            contexto.Musicas.Add(musica);        
            contexto.SaveChanges();
        }

        // se for void não terá retorno, logo terei que mudar o modificador de acesso.
        public IActionResult BuscarPorId(int id)
        {
            Contexto contexto = new Contexto();
            var buscarPorId = contexto.Musicas
                .Include(m => m.Cantor)
                .FirstOrDefault(m => m.Id == id);

            if (buscarPorId == null)
            {
                return Ok("Id não encontrado, por favor tente outro!");
            }
            return Ok(buscarPorId);

        }
        public IActionResult BuscarPorNome(string nome)
        {
            Contexto contexto = new Contexto();
            var buscarPorNome = contexto.Musicas.FirstOrDefault(m => m.Cantor.Nome.ToLower() == nome);
            contexto.Musicas
                .Include(m => m.Cantor)
                .FirstOrDefault(m => m.Cantor.Nome == nome);
            if (buscarPorNome == null)
            {
                return Ok("Cantor não encontrado, por favor tente outro!");
            }
            return Ok(buscarPorNome);

        }
        public IActionResult Atualizar(Musica musica)
        {
            Contexto contexto = new Contexto();
            var atualizar = contexto.Musicas.FirstOrDefault(m => m.Id == musica.Id);
            contexto.Musicas
                .Include(m => m.Cantor)
                .FirstOrDefault(m => m.Cantor.Nome == musica.Cantor.Nome);

            atualizar.Nome = musica.Nome;
            atualizar.Genero = musica.Genero;         
            
            contexto.Musicas.Update(atualizar);

            contexto.SaveChanges();
            return Ok(atualizar);
        }

        public void Deletar(int id)
        {
            Contexto contexto = new Contexto();
            var deletar = contexto.Musicas.FirstOrDefault(m => m.Id == id);
            contexto.Musicas.Remove(deletar);
            contexto.SaveChanges();

        }
        
    }

}