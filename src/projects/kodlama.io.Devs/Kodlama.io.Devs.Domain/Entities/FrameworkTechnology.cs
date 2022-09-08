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
        public ProgrammingLanguage? ProgrammingLanguage { get; set; }
        public int ProgrammigLanguageId { get; set; }
        public string Name { get; set; }

        public FrameworkTechnology() { }

        public FrameworkTechnology(int id,int programmigLanguageId, string name):this()
        {
            Id = id;
            ProgrammigLanguageId = programmigLanguageId;
            Name = name;
        }
    }
}
