using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStore
{
    internal class Helper
    {
        private static RaceStoreDbEntities2 db;
        public static RaceStoreDbEntities2 GetContext()
        {
            if (db == null)
            {
                db = new RaceStoreDbEntities2();
            }
            return db;
        }
    }
}
