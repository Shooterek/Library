using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Services
{
    public interface IClientsRepository
    {
        List<Client> GetClients();
        Client GetClientById(int clientId);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int clientId);
    }
}
