using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursovaDB.DAL.Entities
{
    public partial class Citizen
    {
        public Citizen()
        {
            Request = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CityOfResidence { get; set; }
        public string AddressOfResidence { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
