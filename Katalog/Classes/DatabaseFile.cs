using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects;
using Db4objects.Db4o;
using Microsoft.Win32;

namespace Katalog.Classes
{
    public class DatabaseFile
    {

        //public IObjectContainer OpenedDatabase(OpenFileDialog ofd)
        //{
        //    IObjectContainer OpenedDatabaseFile = Db4oFactory.OpenFile(ofd.FileName.ToString());
        //    return OpenedDatabaseFile;
        //}

        //IEmbeddedObjectContainer _MainDatabaseFile;
        //public IEmbeddedObjectContainer MainDatabaseFile()
        //{
        //    try
        //    {
        //        _MainDatabaseFile.Close();
        //    }
        //    catch { }
        //    return _MainDatabaseFile = Db4oEmbedded.OpenFile("MainDatabase.db");
        //}

        //IEmbeddedObjectContainer _DictDatabase;
        //public IEmbeddedObjectContainer DictDatabaseFile()
        //{
        //    try
        //    {
        //        _DictDatabase.Close();
        //    }
        //    catch { }
        //    return _DictDatabase = Db4oEmbedded.OpenFile("DictDatabase.db");
        //}

        public string DB_FILE = "MainDatabase.db";
    }
}
