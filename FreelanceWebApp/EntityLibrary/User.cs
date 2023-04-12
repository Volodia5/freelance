using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class User
    {
        public User(int id, string login, string password, string name, string email, string phone, string bio, int avg_Rating, int classificationId, int roleId, int categoryId)
        {
            Id = id;
            Login = login;
            Password = password;
            Name = name;
            Email = email;
            Phone = phone;
            Bio = bio;
            Avg_Rating = avg_Rating;
            ClassificationId = classificationId;
            RoleId = roleId;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public int Avg_Rating { get; set; }
        public int ClassificationId { get; set; }
        public int RoleId { get; set; }
        public int CategoryId { get; set; }

    }
}
