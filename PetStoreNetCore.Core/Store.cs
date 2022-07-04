using System;

namespace PetStoreNetCore.Core
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
