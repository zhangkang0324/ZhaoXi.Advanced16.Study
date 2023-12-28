using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DB.Model.ModelDTO
{
    public class UserInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public UserStateEnum State { get; set; }
    }


    public enum UserStateEnum
    {
        Nomal = 1,
        Frazen = 2,
        Deleted = 3
    }
}
