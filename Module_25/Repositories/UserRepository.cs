namespace Module_25.Repositories
{
    internal class UserRepository
    {

        public User GetUserById(int id)
        {
            using (var db = new AppContext())
            {
                return db.Users.FirstOrDefault();
            }
        }
        public List<User> GetAllUsers()
        {
            using (var db = new AppContext())
            {
                return db.Users.ToList();
            }
        }

        public bool RemoveUser(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Remove(user);
                return true;
            }
        }

        public bool AddUser(User user)
        {
            using (var db = new AppContext())
            {
                db.Users.Add(user);
                return true;
            }
        }

        public bool UpdateName(int id, string NewName)
        {
            using (var db = new AppContext())
            {
                User user = GetUserById(id);
                user.Name = NewName;
                db.SaveChanges();
                return true;
            }
        }
    }
}
