using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_G.K
{
    class ValidateUser : AbstractCLass
    {
        public override bool IsvalidAdmin(string userName, string password)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var q = from p in context.Admins
                    where p.Name == userName
                    && p.Password == password
                    select p;
            if (q.Any())
                return true;
            else
                return false;
        }

        public override bool IsvalidUser(string userName, string password)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var q = from p in context.Users
                    where p.User_Name == userName
                    && p.User_password == password
                    select p;
            if (q.Any())
                return true;
            else
                return false;
        }

        public bool checkUser(string userName)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var q = from p in context.Users
                    where p.User_Name == userName
                    select p;
            if (q.Any())
                return true;
            else
                return false;
        }
    }
}
