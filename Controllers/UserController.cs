using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Cache;
using Model;

namespace Controllers
{
    public class UserController
    {
        UserModel userModel = new UserModel();
        public bool LoginUser(string user, string password) {
            return userModel.Login(user, password);
        }
        /*
         * public bool editPassword(int user, string password)
        {
            if (user == UserLoginCache.UserID) {
 
            }
            return true;
        }
         * */
    }
}
