using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezeetaAPI.Core.Models;

namespace VezeetaAPI.Core.Repositories
{
    public interface IBookingRepo 
    {
        void ConfirmBooking(int Bookingid, Requests requests);
        void DeleteBooking(int Bookingid);


    }
}
