using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLBanSach_API.Entity
{
    public class User : IdentityUser
    {
        public User()
        {
            donDatHangs = new List<DonDatHang>();
        }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "BIT")]
        public bool Gender { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string Address { get; set; }

        public List<DonDatHang> donDatHangs { get; set; }
    }
}
