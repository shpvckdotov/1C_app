using DatabaseContext;
using DatabaseModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DishRepository
    {
        public void EditDish(string name, string? nameToChange, float? calories, float? proteint, float? fat, float? carbohydrates, string superhero, Context context)
        {
            var dish = context.Dishes.Single(p => p.Name == name);
            if (nameToChange != "")
            {
                dish.Name = nameToChange;
            }
            if (calories != null)
            {
                dish.Calories = (float)calories;
            }
            if (calories != null)
            {
                dish.Protein = (float)proteint;
            }
            if (calories != null)
            {
                dish.Fat = (float)fat;
            }
            if (calories != null)
            {
                dish.Carbohydrates = (float)carbohydrates;
            }
            if (superhero != "")
            {
                dish.Superhero = context.Superheroes.Single(p => p.Name == superhero);
                dish.SuperheroId = dish.Superhero.Id;
            }
            context.SaveChanges();
        }

        public void DeleteDish(string name, Context context)
        {
            var dish = context.Dishes.First(p => p.Name == name);
            context.Dishes.Remove(dish);
            context.SaveChanges();
        }
        public void SaveDish(string name, float calories, float proteint, float fat, float carbohydrates, string superhero, DateTime dateTime, Context context)
        {
            var dish = new Dish()
            {
                Name = name,
                Calories = calories,
                Protein = proteint,
                Fat = fat,
                Carbohydrates = carbohydrates,
                EatingDate = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc),
                Superhero = context.Superheroes.Single(p => p.Name == superhero),
                SuperheroId = context.Superheroes.Single(p => p.Name == superhero).Id,
            };
            context.Dishes.Add(dish);
            context.SaveChanges();
        }
    }
}
