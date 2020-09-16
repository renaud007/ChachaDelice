using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using ChachaDelice.iOS;
using ChachaDelice.Models;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly:  Dependency(typeof(ChachaDelice.iOS.SQLite_IOS))]
namespace ChachaDelice.iOS
{
    class SQLite_IOS : ISQLite
    {
        SQLiteConnection ISQLite.GetConnection()
        {
            var sqliteFileName="MyDatabase.db3";
            var documentPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var nomDeDossier = Path.Combine(documentPath,"..", "dossierContenantLaBd");
            var path = Path.Combine(nomDeDossier, sqliteFileName);
            var cn = new SQLiteConnection(path);
            return cn;
        }
    }
}