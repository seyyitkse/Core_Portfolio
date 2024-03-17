using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Proje_API.DAL.Entity
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
