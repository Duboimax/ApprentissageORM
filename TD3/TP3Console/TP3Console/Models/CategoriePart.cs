using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TP3Console.Models.EntityFramework;
public partial class Categorie
{
    public override string? ToString()
    {
        return $"Categorie : {this.Id} : {this.Nom}";
    }
}
