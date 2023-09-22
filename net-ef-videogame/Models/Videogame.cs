using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Modelli
{
    public class Videogame
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Column("software_house_id")]
        public long SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }

        public Videogame(long id, string name, string overview, DateTime releaseDate, long softwareHouse)
        {
            Id = id;
            SetName(name);
            SetOverview(overview);
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouse;
        }

        public Videogame(string name, string overview, DateTime releaseDate, long softwareHouse)
        {
            Id = 0;
            SetName(name);
            SetOverview(overview);
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouse;
        }
        public Videogame() { }
        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Il nome del videogioco non puo essere vuoto o nullo");

            Name = name;
        }

        private void SetOverview(string overview)
        {
            if (string.IsNullOrEmpty(overview))
                throw new Exception("Il contenuto della descrizione non puo essere vuoto o nullo");

            Overview = overview;
        }

        public override string ToString()
        {
            return $@"
{Name.ToUpper()} 

Descrizione:
------------
{Overview}
------------

Data di rilascio: {ReleaseDate}
";
        }
    }
}
