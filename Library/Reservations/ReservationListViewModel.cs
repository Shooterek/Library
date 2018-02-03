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
    public class ReservationListViewModel : BindableBase
    {
        private IReservationsRepository _reservationsRepository;

        public ReservationListViewModel(IReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
            LoadData = new RelayCommand(OnLoadReservations);
            EndReservationCommand = new RelayCommand<Reservation>(OnEndReservation);
            ClearSearchInputCommand = new RelayCommand(OnClearSearchInput);
        }

        public RelayCommand LoadData { get; set; }
        public RelayCommand<Reservation> EndReservationCommand { get; set; }
        public RelayCommand ClearSearchInputCommand { get; set; }
        public event Action Done = delegate { };

        private List<Reservation> _allReservations;
        private ObservableCollection<Reservation> _reservations;
        public ObservableCollection<Reservation> Reservations
        {
            get { return _reservations; }
            set { SetProperty(ref _reservations, value);}
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

        private void OnLoadReservations()
        {
            _allReservations = _reservationsRepository.GetReservations();
            Reservations = new ObservableCollection<Reservation>(_allReservations);
        }

        private void OnEndReservation(Reservation reservation)
        {
            _reservationsRepository.DeleteReservation(reservation.ReservationId);
            Done();
        }
        private void OnClearSearchInput()
        {
            SearchInput = null;
        }

        private void FilterRervations(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Reservations = new ObservableCollection<Reservation>(_allReservations);
            }
            else
            {
                Reservations = new ObservableCollection<Reservation>(_allReservations.Where(c => c.Book.Title.ToLower().Contains(searchInput)));
            }
        }

    }
}
