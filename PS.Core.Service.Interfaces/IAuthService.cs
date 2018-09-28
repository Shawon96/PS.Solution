using PS.Core.Entities.Other;
using PS.Core.Entities.Owner;
using PS.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Service.Interface
{
   public interface IAuthService
    {
        bool ChangePassword( string Cpassword,string newpassword,string conpassword, int ownerid);
        bool ChanPassword( string Cpassword,string newpassword,string conpassword,int userid);     
        int login(string aUserName, string password);
        int getType(int id);
    }
}
