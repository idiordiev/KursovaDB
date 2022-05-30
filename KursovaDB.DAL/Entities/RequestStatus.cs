using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursovaDB.DAL.Entities
{
    public partial class RequestStatus
    {
        public RequestStatus()
        {
            Request = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Request> Request { get; set; }
    }
}
