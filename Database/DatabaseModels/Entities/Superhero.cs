using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModels.Entities
{
    public class Superhero
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Dish> Dishes{ get; set; }

        public string Sex { get; set; }
    }
}