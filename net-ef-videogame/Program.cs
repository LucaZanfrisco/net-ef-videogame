// See https://aka.ms/new-console-template for more information

using net_ef_videogame;

Console.WriteLine("Benvenuto nella gestione di Videogichi");



bool check = false;

while(!check)
{
    Console.Write(@"
==================================MENU==================================

1 - Inserire un nuovo videogioco
2 - Ricerca un videogioco per ID
3 - Ricercare tutti i videogiochi per nome
4 - Cancellare un videogioco
5 - Inserire una software house
6 - Stampare tutti i videogiochi di una software house
7 - Esci

========================================================================
Seleziona un numero per svolgere una azione: ");
    int choice = 0;
    try
    {
        choice = int.Parse(Console.ReadLine());
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    switch(choice)
    {
        case 1:
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

            break;
        case 2:
            using(VideogameContext db = new VideogameContext())
            {
                try
                {
                    Console.Write("Inserire l'id di videogioco da cercare: ");
                    int inputId = int.Parse(Console.ReadLine());

                    List<Videogame> videgameById = db.Videogames.Where(videogame => videogame.Id == inputId).ToList<Videogame>();

                    foreach(Videogame videogame in videgameById)
                    {
                        Console.WriteLine(videogame.ToString());
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            break;
        case 3:
            using(VideogameContext db = new VideogameContext())
            {
                try
                {
                    Console.Write("Inserire il nome del videogioco da cercare: ");
                    string inputName = Console.ReadLine();

                    List<Videogame> videogameByName = db.Videogames.Where(videogame => videogame.Name == inputName).ToList<Videogame>();

                    foreach(Videogame videogame in videogameByName)
                    {
                        Console.WriteLine(videogame.ToString());
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            break;
        case 4:
            using(VideogameContext db = new VideogameContext())
            {
                try
                {
                    Console.Write("Inserire il nome del videogioco da cancellare: ");
                    string deleteName = Console.ReadLine();

                    List<Videogame> videogames = db.Videogames.Where(videogame => videogame.Name == deleteName).ToList<Videogame>();

                    db.Remove(videogames.FirstOrDefault());
                    db.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            break;
        case 5:

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
            break;
        case 6:

            break;
        case 7:
            break;
        default:
            Console.WriteLine("Il numero inserito non effettua nessuna azione");
            break;
    }


}