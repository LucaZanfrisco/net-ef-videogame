using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class SoftwareHouse
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100), Column("tax_id")]
        public string TaxId { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string Country { get; set; }
        public List<Videogame> Videogames { get; set; }

        public SoftwareHouse(string name,string taxId, string city, string country) 
        {
            SetName(name);
            this.TaxId = taxId;
            this.City = city;
            this.Country = country;
        }

        private void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Il nome della software house non puo essere vuoto");
            }
            this.Name = name;
        }

        private()

        public override string ToString()
        {
            return $@"
ID: {this.Id} - Name: {this.Name}
------------";
        }

    }
}
