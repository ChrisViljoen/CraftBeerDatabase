namespace CraftBeerDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Beer
    {
        public int Id { get; set; }

        public string Brewery { get; set; }

        public string Style { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.#}")]
        public Nullable<decimal> ABV { get; set; }   
             
        public Nullable<int> IBU { get; set; }
    }
}
