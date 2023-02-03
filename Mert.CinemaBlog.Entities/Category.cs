using Mert.CinemaBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mert.CinemaBlog.Entities
{
    public class Category : EntityBase , IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Article> Articles { get; set; }
    }
}
