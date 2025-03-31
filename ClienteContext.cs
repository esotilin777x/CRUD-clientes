using System.Data.Entity;

namespace CRUDClientes
{
    public class ClienteContext : DbContext
    {
        public ClienteContext() : base("name=ClienteContext") { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
