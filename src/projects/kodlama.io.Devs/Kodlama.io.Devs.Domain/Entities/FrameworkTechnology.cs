using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class FrameworkTechnology:Entity
    {
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public FrameworkTechnology() { }

        public FrameworkTechnology(int id,int programmingLanguageId, string name):this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
        }
    }
}
