using System;
using System.Security.Principal; //->Para Obtener el User;
namespace EPM.clases
{
  public class User
  {
	 public User()
	 {
	 }
     public static string getUser()
     {
		 string [] strUser = null;
		 string delimStr = "\\";			
		 WindowsIdentity wId = WindowsIdentity.GetCurrent();
		 strUser = wId.Name.Split(delimStr.ToCharArray());
		 return strUser[1];
     }
  }
}
