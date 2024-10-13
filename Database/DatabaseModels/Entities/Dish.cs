using DatabaseModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        [ForeignKey(nameof(Superhero))]
        public int SuperheroId { get; set; }

        public Superhero Superhero { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }

        [Required]
        public DateTime EatingDate { get; set; }
    }
}
