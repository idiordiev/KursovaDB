using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursovaDB.DAL.Entities
{
    public partial class SocialService
    {
        public SocialService()
        {
            Specialist = new HashSet<Specialist>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ServiceDescription { get; set; }

        public virtual ICollection<Specialist> Specialist { get; set; }
    }
}
