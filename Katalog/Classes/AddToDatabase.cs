using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace Katalog.Classes
{
    public class AddToDatabase
    {
        public void AddToDatabaseFunct(string Name, int ValueInDatabase, string Unit, Dictionary<string, string> Details, Subproduct[] Subprod)
        {
            addStoreComm(new DatabaseClass()
                                        {
                                            IDProduct = Guid.NewGuid().ToString(),
                                            Name = Name,
                                            ValueInDatabase = ValueInDatabase,
                                            Unit = Unit,
                                            Details = Details,
                                            Subprod = Subprod
                                        });                        
        }

        public void AddToDatabaseFunct(string Name, int ValueInDatabase, string Unit, Dictionary<string, string> Details)
        {
            addStoreComm(new DatabaseClass() 
                                        { 
                                            IDProduct = Guid.NewGuid().ToString(), 
                                            Name = Name, 
                                            ValueInDatabase = ValueInDatabase, 
                                            Unit = Unit, 
                                            Details = Details 
                                        });
        }

        public void AddToDatabaseFunct(string Name, int ValueInDatabase, string Unit, Subproduct[] Subprod)
        {
            addStoreComm(new DatabaseClass() 
                                        { 
                                            IDProduct = Guid.NewGuid().ToString(), 
                                            Name = Name, 
                                            ValueInDatabase = ValueInDatabase, 
                                            Unit = Unit, 
                                            Subprod = Subprod 
                                        });
        }

        public void AddToDatabaseFunct(string Name, int ValueInDatabase, string Unit)
        {
            addStoreComm(new DatabaseClass() 
                                        { 
                                            IDProduct = Guid.NewGuid().ToString(), 
                                            Name = Name, 
                                            ValueInDatabase = ValueInDatabase, 
                                            Unit = Unit 
                                        });           
        }

        void addStoreComm(DatabaseClass item)
        {
            DatabaseFile _db = new DatabaseFile();
            using (IObjectContainer db = Db4oFactory.OpenFile(_db.DB_FILE))
            {
                db.Store(item);
                db.Commit();
            }
        }
    }
}
