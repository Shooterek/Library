using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.Services
{
    public class EfReservationsRepository : IReservationsRepository
    {
        private LibraryDbContext _dbContext;

        public EfReservationsRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Reservation> GetReservations()
        {
            return _dbContext.Reservations.Include("Book").Include("Client").ToList();
        }

        public List<Reservation> GetReservationsByClientId(int clientId)
        {
            return _dbContext.Reservations.Where(r => r.ClientId == clientId).ToList();
        }

        public Reservation GetReservationById(int reservationId)
        {
            return _dbContext.Reservations.SingleOrDefault(r=>r.ReservationId == reservationId);
        }

        public Reservation GetReservationWithClientAndBook(int reservationId)
        {
            return _dbContext.Reservations.Include("Client").Include("Book")
                .FirstOrDefault(r => r.ReservationId == reservationId);
        }

        public void AddReservation(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
        }

        public void DeleteReservation(int reservationId)
        {
            var reservation = _dbContext.Reservations.SingleOrDefault(r => r.ReservationId == reservationId);
            if (reservation != null)
            {
                _dbContext.Reservations.Remove(reservation);
                _dbContext.SaveChanges();
            }
        }
    }
}
