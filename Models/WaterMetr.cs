using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class WaterMetr
    {
        /// <summary>Идентификатор</summary>
        public int Id { get; set; }
        /// <summary>Заводской номер</summary>
        public int Number { get; set; }
        /// <summary>Показания</summary>
        public int Indications { get; set; }

        public int? HomeId { get; set; }
        public Home Home { get; set; }
    }
}