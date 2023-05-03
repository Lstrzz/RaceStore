using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceStore
{
    internal class Helper
    {
        private static RaceStoreDbEntities3 db;
        public static RaceStoreDbEntities3 GetContext()
        {
            if (db == null)
            {
                db = new RaceStoreDbEntities3();
            }
            return db;
        }
    }
}
