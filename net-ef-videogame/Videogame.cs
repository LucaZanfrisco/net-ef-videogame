using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class Videogame
    {
        [Key]
        public long Id {  get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Column("software_house_id")]
        public long SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }
    }
}
