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
            /*using (var ctx = new Tp3DevContext())*/
            /*{*/
            /*ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            Film titanic = (from f in ctx.Films
                            where f.Nom == "Titanic"
                            select f).First();

            titanic.Description = " un bateau qui a échoué. Date : " + DateTime.Now;

            int nbChanges = ctx.SaveChanges();

            Console.WriteLine($"Nombres d'enregistrements modifiés ou ajoutés : {nbChanges}");*/

            /*Categorie categorieAction = ctx.Categories
                                                    .Include(c => c.Films)
                                                        .ThenInclude(f => f.Avis)
                                                    .First(c => c.Nom == "Action");
            Console.WriteLine("Categorie :" + categorieAction.Nom);
            Console.WriteLine("Films : ");

            foreach(var film in ctx.Films.Where(f => f.CategorieNavigation.Nom== categorieAction.Nom).ToList()) 
            {
                Console.WriteLine(film.Nom);
            }*/




            /*}*/
            /*Console.ReadKey();*/





            Exo2Q2();
            Console.ReadKey();
        }

        public static void Exo2Q1()
        {
            var ctx = new Tp3DevContext();
            foreach (var film in ctx.Films)
            {
                Console.WriteLine(film.ToString());
            }
        }
        public static void Exo2Q2()
        {
            var ctx = new Tp3DevContext();
            foreach (var email in ctx.Utilisateurs)
            {
                Console.WriteLine(email.ToString());
            }
        }
    }
}