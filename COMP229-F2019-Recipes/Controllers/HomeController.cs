﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using COMP229_F2019_Recipes.Models;

namespace COMP229_F2019_Recipes.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeRepository repository;

        public HomeController(IRecipeRepository repo)
        {
            repository = repo;
        }

        // default action method
        public ViewResult Index()
        {
            return View();
        }
        /// <summary>
        /// This method returns the AddRecipe view (GET)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }
        /// <summary>
        /// This method is used to save the new recipe into the RecipeList (POST)
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult AddRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                Repository.AddRecipe(recipe);
                return View("AddRecipe", recipe);
            }
            else
            {
                return View();
            }
        }
        /// <summary>
        /// This method returns RecipeList view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult RecipeList()
        {
            return View(repository.Recipes);
        }
        /// <summary>
        /// This method return ViewRecipe view (GET)
        /// </summary>
        /// <returns></returns>
        public ViewResult ViewRecipe(int RecipeId)
        {
            return View(Repository.RecipeList
                .Where(r => r.RecipeId == RecipeId)
                .FirstOrDefault());
    }
        /// <summary>
        /// This method returns ReviewRecipe view (GET)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult ReviewRecipe(int RecipeId)
        {
            return View(Repository.RecipeList
                .Where(r => r.RecipeId == RecipeId)
                .FirstOrDefault());
        }
        /// <summary>
        /// This method is used to save a recipe review into ReviewRecipe (POST)
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult ReviewRecipe()
        {
            return View("Index");
        }
    }
}
