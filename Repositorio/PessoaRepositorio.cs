using Microsoft.EntityFrameworkCore;
using star.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace star.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        public readonly PessoaContext _context;
        public PessoaRepositorio(PessoaContext context)
        {
            _context = context;
        }
        public async Task<Pessoa> Create(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task Delete(int id)
        {
            var pessoaDelete = await _context.Pessoas.FindAsync(id);
            _context.Pessoas.Remove(pessoaDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pessoa>> Get()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> Get(int id)
        {
            return  await _context.Pessoas.FindAsync(id);
        }

        public async Task Update(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
