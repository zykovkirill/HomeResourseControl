using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Home
    {
        /// <summary>Идентификатор</summary>
        public int Id { get; set; }
        /// <summary>Адрес</summary>
        public string Address { get; set; }
        public ICollection<WaterMetr> WaterMetrs { get; set; }
        public Home()
        {
            WaterMetrs = new List<WaterMetr>();
        }
    }
}