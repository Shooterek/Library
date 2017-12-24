using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Clients
{
    public class AddEditClientViewModel : BindableBase
    {
        private Client _client;

        public Client Client
        {
            get { return _client; }
            set { SetProperty(ref _client, value);}
        }
    }
}
