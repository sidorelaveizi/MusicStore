using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Domain.Entities
{
    public class ShippingDetails
    {
    //    [Required(ErrorMessage = "Please enter a name")]
    //    public string Username { get; set; }

        public int ShippingDetailId { get; set; }
        [Required(ErrorMessage = "Please enter your First Name")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your Last Name")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter the address")]
        [StringLength(70)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        [StringLength(40)]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state name")]
        [StringLength(40)]
        public string State { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Please enter a country name")]
        [StringLength(40)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter the phone number")]
        [StringLength(24)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter the email address")]
        [DisplayName("Email Address")]

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        //public List<OrderDetail> OrderDetails { get; set; }
    }
}
