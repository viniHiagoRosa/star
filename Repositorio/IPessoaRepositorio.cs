using star.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace star.Repositorio
{
    public interface IPessoaRepositorio
    {
        Task<IEnumerable<Pessoa>> Get();
        Task<Pessoa> Get(int id);

        Task<Pessoa> Create(Pessoa pessoa);

        Task Update(Pessoa pessoa); 
        Task Delete(int id);
    }
}
