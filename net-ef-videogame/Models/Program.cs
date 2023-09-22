// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using net_ef_videogame.Database;
using net_ef_videogame.Modelli;
using net_ef_videogame.Models;

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

            VideogameManager.AddVideogame();

            break;
        case 2:

            VideogameManager.SearchVideogameById();

            break;
        case 3:

            VideogameManager.SearchVideogamaByName();

            break;
        case 4:
           
            VideogameManager.DeleteVideogameByName();

            break;
        case 5:

            VideogameManager.AddSoftwareHouse();
           
            break;
        case 6:

            VideogameManager.SearchSoftwareHouseById();

            break;
        case 7:
            Console.WriteLine("Arrivederci");
            check = true;
            break;
        default:
            Console.WriteLine("Il numero inserito non effettua nessuna azione");
            break;
    }


}