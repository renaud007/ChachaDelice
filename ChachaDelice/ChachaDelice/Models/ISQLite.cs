using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChachaDelice.Models
{
   public interface ISQLite 
    {
        SQLiteConnection GetConnection(); 
    }
}
