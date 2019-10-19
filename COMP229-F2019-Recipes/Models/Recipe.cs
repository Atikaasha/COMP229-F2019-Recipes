﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace COMP229_F2019_Recipes.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public String Category{ get; set; }
        public String Name { get; set; }
        public String Ingredients { get; set; }
        public String Directions { get; set; }
        public double Serves { get; set; }
        public String Comment { get; set; }
    }

}
