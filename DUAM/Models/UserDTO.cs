using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUAM.Models
{
    internal class UserDTO
    {
        public string FullName { get; set; }
        public DateTime? LastAccess { get; set; }
        public int DaysAgoCount { get; set; }

        public static IList<UserDTO> GetUsers(IQueryable<User> users) 
        {
            IList<UserDTO> usersDTOs = new List<UserDTO>();
            
            foreach (var user in users)
            {
                var item = new UserDTO()
                {
                    FullName = user.FullName,
                    LastAccess = user.LastAccess,
                    DaysAgoCount = (int)(DateTime.Now - user.LastAccess ?? TimeSpan.MaxValue).Days
                };
                usersDTOs.Add(item);
            }
            return usersDTOs;
        }
    }
}
