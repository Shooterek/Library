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
            LoadData = new RelayCommand(LoadReservations);
            EndReservationCommand = new RelayCommand<Reservation>(OnReservationEnd);
        }

        private void OnReservationEnd(Reservation reservation)
        {
            _reservationsRepository.DeleteReservation(reservation.ReservationId);
        }

        private ObservableCollection<Reservation> _reservations;
        public ObservableCollection<Reservation> Reservations
        {
            get { return _reservations; }
            set { SetProperty(ref _reservations, value);}
        }

        private void LoadReservations()
        {
            Reservations = new ObservableCollection<Reservation>(_reservationsRepository.GetReservations());
        }

        public RelayCommand LoadData { get; set; }
        public RelayCommand<Reservation> EndReservationCommand { get; set; }
    }
}
