using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.Models;

namespace FFY.MVP.Users.CheckOut
{
    public class CheckOutEventArgs : EventArgs
    {
        public CheckOutEventArgs(string userId,
            string street,
            string city,
            string country,
            string phoneNumber,
            DateTime sendOn,
            OrderPaymentStatusType orderPaymentStatusType,
            OrderStatusType orderStatusType)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("User Id cannot be null.");
            }

            if (string.IsNullOrEmpty(street))
            {
                throw new ArgumentNullException("Street cannot be null.");
            }

            if (string.IsNullOrEmpty(city))
            {
                throw new ArgumentNullException("City cannot be null.");
            }

            if (string.IsNullOrEmpty(country))
            {
                throw new ArgumentNullException("Country cannot be null.");
            }

            if(string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentNullException("Phone number cannot be null.");
            }

            this.UserId = userId;
            this.Street = street;
            this.City = city;
            this.Country = country;
            this.PhoneNumber = phoneNumber;
            this.SendOn = sendOn;
            this.OrderStatusType = orderStatusType;
            this.OrderPaymentStatusType = orderPaymentStatusType;
        }

        public string UserId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public OrderStatusType OrderStatusType { get; set; }

        public OrderPaymentStatusType OrderPaymentStatusType { get; set; }

        public DateTime SendOn { get; internal set; }
    }
}
