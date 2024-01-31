using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
namespace Appcompras.Conexiones
{
   public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://appcompras-9d71e-default-rtdb.firebaseio.com/");
    }
}
