using Microsoft.EntityFrameworkCore;
using net_ef_videogame.Database;
using net_ef_videogame.Modelli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public static class VideogameManager
    {

        public static void AddVideogame()
        {
            using(VideogameContext db = new VideogameContext())
            {
                try
                {
                    List<SoftwareHouse> softwareHouses = db.SoftwareHouses.ToList<SoftwareHouse>();

                    if(softwareHouses.Count > 0)
                    {
                        Console.Write("Inserire il nome del videogioco: ");
                        string name = Console.ReadLine();

                        Console.Write("Inserire la descrizione: ");
                        string overview = Console.ReadLine();

                        Console.Write("Inserie la data di rilascio (dd/mm/yyyy): ");
                        DateTime releaseDate = DateTime.Parse(Console.ReadLine());

                        foreach(SoftwareHouse house in softwareHouses)
                        {
                            Console.WriteLine(house.ToString());
                        }
                        Console.WriteLine("Inserire il numero della software house: ");

                        long softwareHouseNumber = long.Parse(Console.ReadLine());

                        Videogame newVideogame = new Videogame(name, overview, releaseDate, softwareHouseNumber);
                        db.Add(newVideogame);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Non è possibile inserire un videogioco senza una software house.");
                        Console.WriteLine("Inserire prima una software house");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void SearchVideogameById()
        {
            using(VideogameContext db = new VideogameContext())
            {
                try
                {
                    Console.Write("Inserire l'id del videogioco da cercare: ");
                    int inputId = int.Parse(Console.ReadLine());

                    Videogame videgameById = db.Videogames.Where(videogame => videogame.Id == inputId).FirstOrDefault<Videogame>();

                    if(videgameById != null)
                    {
                        Console.WriteLine(videgameById.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Nessun videogame trovato");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public static void SearchVideogamaByName()
        {
            using(VideogameContext db = new VideogameContext())
            {
                try
                {
                    Console.Write("Inserire il nome del videogioco da cercare: ");
                    string inputName = Console.ReadLine();

                    List<Videogame> videogameByName = db.Videogames.Where(videogame => videogame.Name == inputName).ToList<Videogame>();
                    if(videogameByName.Count > 0)
                    {
                        foreach(Videogame videogame in videogameByName)
                        {
                            Console.WriteLine(videogame.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nessun videogame trovato");
                    }
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public static void DeleteVideogameByName()
        {
            using(VideogameContext db = new VideogameContext())
            {
                try
                {
                    Console.Write("Inserire il nome del videogioco da cancellare: ");
                    string deleteName = Console.ReadLine();

                    Videogame videogames = db.Videogames.Where(videogame => videogame.Name == deleteName).FirstOrDefault<Videogame>();
                    if(videogames != null)
                    {
                        Console.WriteLine("Videogioco trovato e cancellato");
                        db.Remove(videogames);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Nessun videogioco trovato");
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void AddSoftwareHouse()
        {
            using(VideogameContext db = new VideogameContext())
            {
                try
                {
                    Console.Write("Inserire il nome della software house: ");
                    string name = Console.ReadLine();

                    Console.Write("Inserire il codice Tax: ");
                    string tax = Console.ReadLine();

                    Console.Write("Inserie la citta: ");
                    string city = Console.ReadLine();

                    Console.Write("Inserie lo stato: ");
                    string country = Console.ReadLine();

                    SoftwareHouse newSoftwareHouse = new SoftwareHouse(name, tax, city, country);
                    db.Add(newSoftwareHouse);
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public static void SearchSoftwareHouseById()
        {
            using(VideogameContext db = new VideogameContext())
            {
                try
                {
                    Console.Write("Inserire l'id della software house da cercare: ");
                    int softwareHouseId = int.Parse(Console.ReadLine());

                    List<SoftwareHouse> softwareHouses = db.SoftwareHouses.Where(softwareHouse => softwareHouse.Id == softwareHouseId).Include(softwareHouse => softwareHouse.Videogames).ToList<SoftwareHouse>();
                    if(softwareHouses.Count > 0)
                    {
                        foreach(SoftwareHouse softwareHouse in softwareHouses)
                        {
                            Console.WriteLine(softwareHouse.ToString());
                            Console.WriteLine(softwareHouse.Videogames);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Nessuna software house con id {softwareHouseId} inserito");
                    }


                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

}
