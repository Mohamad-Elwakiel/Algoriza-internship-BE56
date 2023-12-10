using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezeetaAPI.Core.Models;
using VezeetaAPI.Core.Repositories;

namespace VezeetaApi.EF.Repositories
{
    public class BookingRepo : IBookingRepo
    {
        private readonly IbaseRepository<Requests> _baseRequest;
        private readonly ApplicationDbContext _context;
        public BookingRepo(IbaseRepository<Requests> baseRequest, ApplicationDbContext context)
        {
            _baseRequest = baseRequest; 
            _context = context; 
            
        }
        public void ConfirmBooking(int Bookingid, Requests requests)
        {
            var ConfirmedBooking = new Requests
            {
                RequestsId = Bookingid,
                RequestState =requests.RequestState,


            };
            _context.requests.Update(ConfirmedBooking);

        }

        public void DeleteBooking(int Bookingid) 
        {
            var booking = new Requests() { RequestsId = Bookingid };    
            _context.requests.Remove(booking);
        }
        public IEnumerable<Requests> GetAllByPage(int id,int page = 1, int pageSize = 10)
        {

            var result = _context.Set<Requests>().Where(x =>  id == x.DoctorId).ToList();
            return result.Skip(page - 1 * pageSize).Take(pageSize).ToList();
        }
    }
}
