using System;
using System.Collections.Generic;

namespace bier_backend_with_aut_mysql.Models
{
    public partial class Bier
    {
        public int Id { get; set; }
        public string? Naam { get; set; }
        public string? Brouwer { get; set; }
        public string? Type { get; set; }
        public string? Gisting { get; set; }
        public float? Perc { get; set; }
        public decimal InkoopPrijs { get; set; }
    }
}
