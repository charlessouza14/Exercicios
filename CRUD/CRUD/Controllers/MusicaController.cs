using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MusicaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Criar(Musica musica)
        {
            Contexto contexto = new Contexto();
            contexto.Musicas.Add(musica);
            contexto.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult BuscarPorCantor([FromQuery] string nome)
        {
            Contexto contexto = new Contexto();
            var buscarMusica = contexto.Musicas.First(m => m.Cantor.Name == nome);
            return Ok(buscarMusica);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Musica musica)
        {
            Contexto contexto = new Contexto();
            var musicaDoBancoDeDados = contexto.Musicas.FirstOrDefault(m => m.Id == musica.Id);
            musicaDoBancoDeDados.Nome = musica.Nome;
            musicaDoBancoDeDados.Cantor = musica.Cantor;
            musicaDoBancoDeDados.Genero = musica.Genero;
            contexto.Musicas.Update(musicaDoBancoDeDados);
            contexto.SaveChanges();
            return Ok(musica);
        }

        [HttpDelete]

        public IActionResult Deletar([FromQuery]int id)
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
