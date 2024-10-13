using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModels.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        public Group Group { get; set; }

        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
