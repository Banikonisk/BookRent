using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Book
{
    public class UpdateBookRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}