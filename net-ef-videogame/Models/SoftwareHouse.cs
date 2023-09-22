using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Modelli
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

        public SoftwareHouse(string name, string taxId, string city, string country)
        {
            SetName(name);
            SetTaxId(taxId);
            SetCity(city);
            SetCountry(country);
        }
        public SoftwareHouse() { }
        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Il nome della software house non puo essere vuoto");
            }
            Name = name;
        }

        private void SetTaxId(string taxId)
        {
            if (string.IsNullOrEmpty(taxId))
            {
                throw new Exception("La tax id non puo essere vuota");
            }
            TaxId = taxId;
        }

        private void SetCity(string city)
        {
            if (string.IsNullOrEmpty(City))
            {
                throw new Exception("La citta non puo essere vuota");
            }
            City = city;
        }
        private void SetCountry(string country)
        {
            if (string.IsNullOrEmpty(Country))
            {
                throw new Exception("Lo stato non puo essere nullo");
            }
            Country = country;
        }
        public override string ToString()
        {
            return $@"
ID: {Id} - Name: {Name}
------------";
        }

    }
}
