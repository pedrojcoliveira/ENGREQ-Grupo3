using AMAPP.API.Data;
using AMAPP.API.Models;

namespace AMAPP.API.Repository.ProdutoRepository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
