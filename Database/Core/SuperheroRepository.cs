using DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseModels.Entities;

namespace Core
{
    public class SuperheroRepository
    {
        public void DeleteSuperhero(string name, Context context)
        {
            var superhero = context.Superheroes.First(p => p.Name == name);
            context.Superheroes.Remove(superhero);
            context.SaveChanges();
        }
        public void EditSuperhero(string name, string nameToChange, string sex, Context context)
        {
            var superhero = context.Superheroes.Single(p => p.Name == name);
            if (nameToChange != "")
            {
                superhero.Name = nameToChange;
            }
            if(sex != "")
            {
                superhero.Sex = sex;
            }
            context.SaveChanges();
        }
        public void SaveSuperhero(string name, string sex, Context context)
        {
            var superhero = new Superhero()
            {
                Name = name,
                Sex = sex,
            };
            context.Superheroes.Add(superhero);
            context.SaveChanges();
        }
    }
}
