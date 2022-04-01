using Microsoft.AspNetCore.Mvc;
using star.Model;
using star.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace star.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio; 
        }

        [HttpGet]
        public async Task<IEnumerable<Pessoa>> GetPessoas()
        {
            return await _pessoaRepositorio.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoas(int id)
        {
            return await _pessoaRepositorio.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoas([FromBody] Pessoa pessoa)
        {
            var novaPessoa = await _pessoaRepositorio.Create(pessoa);
            return CreatedAtAction(nameof(GetPessoas), new { id = novaPessoa.Id }, novaPessoa);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePessoa(int id)
        {
            var pessoaDelete = await _pessoaRepositorio.Get(id);
            if (pessoaDelete == null)
            {
                return NotFound();
            }
                await _pessoaRepositorio.Delete(pessoaDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutPessoa(int id, [FromBody] Pessoa pessoa)
        {
            if(id != pessoa.Id)
            {
                return BadRequest();
            }
            await _pessoaRepositorio.Update(pessoa);

            return NoContent();
        }
         
    }
}
