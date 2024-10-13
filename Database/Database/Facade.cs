using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContext;
using Core;

namespace Database
{
    public class Facade
    {
        private DishRepository _dishRepository = new DishRepository();
        private SuperheroRepository _superheroRepository = new SuperheroRepository();
        Context _context;
        public Facade()
        {
            _context = new Context();
        }

        public void RecordSuperhero(string name, string sex)
        {
            _superheroRepository.SaveSuperhero(name, sex, _context);
        }
        public void RecordDish(string name, float calories, float proteint, float fat, float carbohydrates, DateTime dateTime,  string superhero)
        {
            _dishRepository.SaveDish(name, calories, proteint, fat, carbohydrates, superhero, dateTime,  _context);
        }
        
        public void DeleteDish(string name)
        {
            _dishRepository.DeleteDish(name, _context);
        }
        public void DeleteSuperhero(string name)
        {
            _superheroRepository.DeleteSuperhero(name, _context);
        }
        public void RedactDish(string name, string? nameToChange, float? calories, float? proteint, float? fat, float? carbohydrates, string superhero)
        {
            _dishRepository.EditDish(name, nameToChange, calories, proteint, fat, carbohydrates, superhero, _context);
        }
        public void RedactSuperhero(string name, string nameToChange, string sex)
        {
            _superheroRepository.EditSuperhero(name, nameToChange, sex, _context);
        }
        void graph()
        {
            
        }
    }
}
