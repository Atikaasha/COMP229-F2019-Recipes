﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP229_F2019_Recipes.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Recipe> Recipes => context.Recipes;
        
        
        
        
        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.RecipeId == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe dbEntry = context.Recipes
                    .FirstOrDefault(r => r.RecipeId == recipe.RecipeId);
                if (dbEntry != null)
                {
                    dbEntry.Category = recipe.Category;
                    dbEntry.Name = recipe.Name;
                    dbEntry.Ingredients = recipe.Ingredients;
                    dbEntry.Directions = recipe.Directions;
                    dbEntry.Serves = recipe.Serves;
                }
            }
            context.SaveChanges();
        }




        public void SaveReview(Recipe recipe)
        {
            if (recipe.RecipeId == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe dbEntry = context.Recipes
                    .FirstOrDefault(r => r.RecipeId == recipe.RecipeId);
                if (dbEntry != null)
                {
                    dbEntry.Name = recipe.Name;
                    dbEntry.Comment = recipe.Comment;
                }
            }
            context.SaveChanges();
        }



        public Recipe DeleteRecipe(int recipeId)
        {
            Recipe dbEntry = context.Recipes
                .FirstOrDefault(r => r.RecipeId == recipeId);

            if (dbEntry != null)
            {
                context.Recipes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


    }
}
