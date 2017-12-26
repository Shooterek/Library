using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Services
{
    public class EfClientsRepository : IClientsRepository
    {
        private LibraryDbContext _dbContext;

        public EfClientsRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Client> GetClients()
        {
            return _dbContext.Clients.ToList();
        }

        public Client GetClientById(int clientId)
        {
            return _dbContext.Clients.SingleOrDefault(c => c.ClientId == clientId);
        }

        public void AddClient(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _dbContext.Entry(client).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteClient(int clientId)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.ClientId == clientId);
            if (client != null)
            {
                _dbContext.Entry(client).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
        }

        public List<Reminder> GetReminders()
        {
            return _dbContext.Reminders.ToList();
        }
    }
}
