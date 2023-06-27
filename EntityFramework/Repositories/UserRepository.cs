using EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class UserRepository
    {
        private AppContext _context;

        public User GetUserById(int id) { return _context.Users.Where(b => b.Id == id).First(); }

        public List<User> GetAllUsers() { return _context.Users.ToList(); }

        public void AddNewUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void UpdateUserNameById(int id, string userName)
        {
            GetUserById(id).Name = userName;
            _context.SaveChanges();
        }

        public bool IsContainsBookByUser(Book book, int userId) { return GetUserById(userId).Books.Contains(book); }

        public int GetCountBooksByUser(int userId) { return GetUserById(userId).Books.Count(); }


    }
}
