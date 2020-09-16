using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChachaDelice.Droid;
using ChachaDelice.Models;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace ChachaDelice.Droid
{
    class SQLite_Android : ISQLite
    {
        SQLiteConnection ISQLite.GetConnection()
        {
            var sqliteFileName = "MyDatabase.db3";
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFileName);

            var cn = new SQLiteConnection(path);
            return cn;
        }
    }
}