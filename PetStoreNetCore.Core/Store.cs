using System;
using System.ComponentModel.DataAnnotations;

namespace PetStoreNetCore.Core
{
    public partial class Store
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string StoreName { get; set; }

        [Required, StringLength(80)]
        public string StreetName { get; set; }

        [Required, StringLength(80)]
        public string City { get; set; }
        public int PostalCode { get; set; }

        [Required]
        public Countries Country { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
