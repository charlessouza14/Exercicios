using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MusicaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Criar([FromBody] Musica musica)
        {
            Contexto contexto = new Contexto();
            var criarNome = contexto.Musicas.Include(m => m.Cantor.Nome);               
            if (musica.Nome == null)
            {
                return Ok("Por favor, inserir um nome válido");
            }
            if (musica.Cantor.Nome == null)
            {
                return Ok("Por favor, inserir um nome válido");
            }
            contexto.Musicas.Add(musica);
            contexto.SaveChanges();
            return Ok("Criado com sucesso!");
        }

        // api/musica/1
        // api/musica?id=1
        [HttpGet]
        public IActionResult BuscarPorId([FromQuery] int id)
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

        [HttpGet]
        [Route("BuscarPorNome")]
        public IActionResult BuscarPorNome([FromQuery] string nome)
        {
            Contexto contexto = new Contexto();
            var buscarMusica = contexto.Musicas.FirstOrDefault(m => m.Cantor.Nome.ToLower() == nome);
            buscarMusica = contexto.Musicas.Include(m => m.Cantor)
                .FirstOrDefault(m => m.Cantor.Nome == nome);
            if (buscarMusica == null)
            {
                return Ok("Cantor não encontrado, por favor tente outro!");
            }
            return Ok(buscarMusica);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Musica musica)
        {
            Contexto contexto = new Contexto();            
            var musicaDoBancoDeDados = contexto.Musicas.First(m => m.Id == musica.Id);
            musicaDoBancoDeDados.Nome = musica.Nome;
            musicaDoBancoDeDados.Cantor.Nome = musica.Cantor.Nome;
            musicaDoBancoDeDados.Cantor.DataDeNascimento = musica.Cantor.DataDeNascimento;
            musicaDoBancoDeDados.Genero = musica.Genero;
            contexto.Musicas.Update(musicaDoBancoDeDados);
            contexto.SaveChanges();
            return Ok(musicaDoBancoDeDados);
        }


        [HttpDelete]
        public IActionResult Deletar([FromQuery] int id)
        {
            Contexto contexto = new Contexto();
            var deletarMusica = contexto.Musicas.FirstOrDefault(m => m.Id == id);           
            if (deletarMusica == null)
            {
                return Ok("Musica não encontrada, por favor envie um Id valido");
            }

            contexto.Musicas.Remove(deletarMusica);
            contexto.SaveChanges();
            return Ok("Musica excluida com sucesso!");
        }


    }

    
}
