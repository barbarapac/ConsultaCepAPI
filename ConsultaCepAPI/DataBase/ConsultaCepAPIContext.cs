using ConsultaCepAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCepAPI.DataBase
{
    public class ConsultaCepAPIContext : DbContext
    {
        public ConsultaCepAPIContext(DbContextOptions<ConsultaCepAPIContext> options) : base(options)
        {

        }

        public DbSet<CEP> Ceps { get; set; }
    }
}
