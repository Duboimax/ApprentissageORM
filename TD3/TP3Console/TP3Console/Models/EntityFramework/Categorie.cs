﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TP3Console.Models.EntityFramework;

[Table("categorie")]
public partial class Categorie
{
    /*private ILazyLoader _lazyLoader;
    public Categorie(ILazyLoader lazyLoader)
    {
        _lazyLoader = lazyLoader;
    }*/

    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nom")]
    [StringLength(50)]
    public string Nom { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

   /* private ICollection<Film> films;*/

    [InverseProperty("CategorieNavigation")]
    public  virtual ICollection<Film> Films { get; set; } =  new List<Film>();
    /*{
        get
        get
        {
            return _lazyLoader.Load(this, ref films);
        }
        set { films = value; }
    }*/
}
