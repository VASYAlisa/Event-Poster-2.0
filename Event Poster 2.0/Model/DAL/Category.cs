﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Poster_2._0.Model.DAL
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Категория")]
        public string Name { get; set; }

        //public List<Event> Events { get; set; } 
    }
}