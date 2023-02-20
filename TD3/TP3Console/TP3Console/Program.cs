using TP3Console.Models.EntityFramework;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace TP3Console
{
    public class Program
    {
        static void Main(string[] args)
        {
           using (var ctx = new Tp3DevContext())
           {
                /*ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                Film titanic = (from f in ctx.Films
                                where f.Nom == "Titanic"
                                select f).First();

                titanic.Description = " un bateau qui a échoué. Date : " + DateTime.Now;

                int nbChanges = ctx.SaveChanges();

                Console.WriteLine($"Nombres d'enregistrements modifiés ou ajoutés : {nbChanges}");*/

                Categorie categorieAction = ctx.Categories.First(c => c.Nom == "Action");
                Console.WriteLine("Categorie :" + categorieAction.Nom);
                Console.WriteLine("Films : ");

                foreach(var film in ctx.Films.Where(f => f.CategorieNavigation.Nom== categorieAction.Nom).ToList()) 
                {
                    Console.WriteLine(film.Nom);
                }
           }
            /*Console.ReadKey();*/
        }
    }
}