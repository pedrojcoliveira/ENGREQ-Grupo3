using AMAPP.API.Data;
using AMAPP.API.Models;

namespace AMAPP.API.Repository.AccountBalanceRepository
{
    public class AccountBalanceRepository : RepositoryBase<CheckingAccount>, IAccountBalanceRepository
    {
        public AccountBalanceRepository(ApplicationDbContext context) : base(context)
        {
        }



    }
}
