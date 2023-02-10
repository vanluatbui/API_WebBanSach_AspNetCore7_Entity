using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLBanSach_API.Entity
{
    [Table("ChuDe")]
    public class ChuDe
    {
        public ChuDe()
        {
            Sachs = new List<Sach>();
        }

        [Key]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(5)]
        public string MaChuDe { get; set; }

        [MaxLength(50)]
        public string TenChuDe { get; set; }

        public List<Sach> Sachs { get; set; }
    }
}
