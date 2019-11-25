using devmusic.api.ETypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devmusic.api.ViewModels
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Code { get; set; }
        public ETypeAuthor Category { get; set; }

        public string CategoryDescription
        {
            get { return Category.ToString(); }

        }
    }
}
