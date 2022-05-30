using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursovaDB.DAL.Entities
{
    public partial class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string RequestDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? QueuedNumber { get; set; }
        public int? CitizenId { get; set; }
        public int? SpecialistId { get; set; }
        public int? StatusId { get; set; }

        public virtual Citizen Citizen { get; set; }
        public virtual Specialist Specialist { get; set; }
        public virtual RequestStatus Status { get; set; }
    }
}
