using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Services
{
    public interface IReservationsRepository
    {
        List<Reservation> GetReservations();
        List<Reservation> GetReservationsByClientId(int clientId);
        Reservation GetReservationById(int reservationId);
        Reservation GetReservationWithClientAndBook(int reservationId);
        List<Archive> GetArchive();
        void AddReservation(Reservation reservation);
        void DeleteReservation(int reservationId);
    }
}
