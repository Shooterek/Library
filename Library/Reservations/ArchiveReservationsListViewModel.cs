using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Services;

namespace Library.Reservations
{
    public class ArchiveReservationsListViewModel : BindableBase
    {
        private IReservationsRepository _reservationsRepository;

        public ArchiveReservationsListViewModel(IReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
            LoadData = new RelayCommand(OnLoadData);
            ClearSearchInputCommand = new RelayCommand(OnClearSearchInput);
        }

        public RelayCommand LoadData { get; set; }
        public RelayCommand ClearSearchInputCommand { get; set; }

        private List<Archive> _allReservations;
        private ObservableCollection<Archive> _reservations;
        public ObservableCollection<Archive> Reservations
        {
            get { return _reservations; }
            set
            {
                SetProperty(ref _reservations, value);
            } 
        }

        private string _searchInput;
        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterRervations(_searchInput);
            }
        }

        private void OnLoadData()
        {
            _allReservations = _reservationsRepository.GetArchive();
            Reservations = new ObservableCollection<Archive>(_allReservations);
        }

        private void OnClearSearchInput()
        {
            SearchInput = null;
        }

        private void FilterRervations(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Reservations = new ObservableCollection<Archive>(_allReservations);
            }
            else
            {
                Reservations = new ObservableCollection<Archive>(_allReservations.Where(c => c.Book.Title.ToLower().Contains(searchInput)));
            }
        }
    }
}
