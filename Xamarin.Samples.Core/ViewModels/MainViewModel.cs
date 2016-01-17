using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Samples.Core.Model;

namespace Xamarin.Samples.Core.ViewModels
{
    public class MainViewModel
        : MvxViewModel
    {
        private List<Client> _clients;

        public MainViewModel()
        {
            _clients = new List<Client>
            {
                new Client { Id=1, Name = "Client 1", City="London" },
                new Client { Id=2, Name = "Client 2", City="Mumbai" },
                new Client { Id=3, Name = "Client 3", City="New York" },
                new Client { Id=4, Name = "Client 4", City="London" },
                new Client { Id=5, Name = "Client 5", City="London" },
            };

            ShowClientDetailsCommand = new MvxCommand<int>(ShowClientDetails);
        }

        public List<Client> Clients
        {
            get { return _clients; }
            set { _clients = value; }
        }

        public ICommand ShowClientDetailsCommand
        {
            get;
            private set;
        }

        private void ShowClientDetails(int clientId)
        {
            ShowViewModel<ClientDetailsViewModel>(new { Id = clientId });
        }
    }
}
