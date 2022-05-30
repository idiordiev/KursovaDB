using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursovaDB.DAL.Entities
{
    public partial class Specialist
    {
        public Specialist()
        {
            Request = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public int? ServiceId { get; set; }

        public virtual SocialService Service { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}
