using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSConvertisseur.Models;
using Microsoft.AspNetCore.Http;

namespace WSConvertisseur.Controllers.Tests
{
    [TestClass()]
    public class DevisesControllerTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            DevisesController controller = new DevisesController();

            var result = controller.GetAll();
            List<Devise> lesDevises = new List<Devise>();

            lesDevises.Add(new Devise(1, "Dollar", 1.08));
            lesDevises.Add(new Devise(2, "Franc Suisse", 1.07));
            lesDevises.Add(new Devise(3, "Yen", 120));


            Assert.IsInstanceOfType(result, typeof(IEnumerable<Devise>));
            CollectionAssert.AreEqual(result.ToList<Devise>(), lesDevises, "Pas de liste de devise, fin pas pareil");


        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            DevisesController controller = new DevisesController();
            // Act
            var result = controller.GetById(1);
          
            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsNull(result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result.Value, typeof(Devise), "Pas une Devise"); // Test du type du contenu (valeur) du retour
            Assert.AreEqual(new Devise(1, "Dollar", 1.08), (Devise?)result.Value, "Devises pas identiques"); //Test de la devise
        }

        [TestMethod()]

        public void GetByID_NotExisting_Return404()
        {
            //Arrange
            DevisesController controller = new();


            //Act
            var result = controller.GetById(4);

            //Assert
/*            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "Pas un ActionResult");
            Assert.IsInstanceOfType(result.Value,null, "Pas une Devise"); // Test du type du contenu (valeur) du retour*/
            Assert.AreEqual(((NotFoundResult)result.Result).StatusCode, StatusCodes.Status404NotFound, "Pas 404");
        }

        [TestMethod()]
        public void Post_ValidObjectPassed_ReturnsObjects()
        {
            DevisesController controller = new();

            Devise uneDevise = new Devise(4, "", 50);
            var result = controller.Post(uneDevise);
            CreatedAtRouteResult routeResult = (CreatedAtRouteResult)result.Result;

            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>));
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtRouteResult));
            Assert.AreEqual(routeResult.StatusCode, StatusCodes.Status201Created, "Pas de 201 crée");
            Assert.AreEqual((Devise)routeResult.Value, uneDevise, "PAS LA BONNE DEVISE");
        }

        /*[TestMethod()]
        public void Post_InvalidObjectPassed_ReturnsObjects()
        {
            DevisesController controller = new();

            Devise uneDevise = new Devise(4, null, 50);
            var result = controller.Post(uneDevise);
            

            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>));
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestResult));
            
        }*/

        [TestMethod()]
        public void Put_Invalid_Return_BadRequest()
        {
            DevisesController controller = new DevisesController();

            var result = controller.Put(5, new Devise(6, "", 50.2));

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));

        }


        [TestMethod()]
        public void Put_Invalid_Return_NotFound()
        {
            DevisesController controller = new DevisesController();

            var result = controller.Put(-1, new Devise(-1, "", 50.2));

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void Put_Valid_Return_NoContent()
        {
            DevisesController controller = new();

            Devise uneDevise = new Devise(6, "Sex", 15.20);
            var result = controller.Put(6, uneDevise);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
            Assert.AreEqual(controller.GetById(6), uneDevise);
        }
    }
}