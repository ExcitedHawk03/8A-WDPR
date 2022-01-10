using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplicatie.context
{
    public class MyContext: IdentityDbContext
    {
        public MyContext(DbContextOptions<MyContext> options): base(options){

        }
    }
}