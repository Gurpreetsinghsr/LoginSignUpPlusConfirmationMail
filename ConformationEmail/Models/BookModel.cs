using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConformationEmail.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Auther { get; set; }

        public string Details { get; set; }

        public int Price { get; set; }
    }
}
