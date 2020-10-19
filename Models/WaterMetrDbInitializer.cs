using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Test.Models
{
    public class WaterMetrDbInitializer : DropCreateDatabaseAlways<WaterMetrContext>
    {
        protected override void Seed(WaterMetrContext db)
        {
            db.WaterMetrs.Add(new WaterMetr { Number = 1, Indications = 2 });
            db.WaterMetrs.Add(new WaterMetr { Number = 2, Indications = 3 });
            db.WaterMetrs.Add(new WaterMetr { Number = 3, Indications = 4 });

            base.Seed(db);
        }
    }
}