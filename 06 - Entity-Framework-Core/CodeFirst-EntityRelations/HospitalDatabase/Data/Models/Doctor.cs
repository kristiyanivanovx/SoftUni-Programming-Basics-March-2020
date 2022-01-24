using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }

        public int DoctorId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Speciality { get; set; }

        public ICollection<Visitation> Visitations { get; set; }
    }
}
