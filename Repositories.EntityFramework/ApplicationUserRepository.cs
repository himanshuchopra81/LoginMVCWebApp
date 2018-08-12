using Business;
using System.Data.Entity;

namespace Repositories.EntityFramework
{
    public class ApplicationUserRepository : Repository<ApplicationUser>
    {
        public ApplicationUserRepository(DbContext content) : base(content)
        {
        }
    }
}
