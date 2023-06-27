// See https://aka.ms/new-console-template for more information
using EntityFramework;

using (var db = new EntityFramework.AppContext())
{
    var user1 = new User { Name = "Arthur", Role = "Admin", Email = "Arthur@mail.ru" };
    var user2 = new User { Name = "klim", Role = "User", Email = "klim@mail.ru" };

    db.Users.Add(user1);
    db.Users.Add(user2);
    db.SaveChanges();
}