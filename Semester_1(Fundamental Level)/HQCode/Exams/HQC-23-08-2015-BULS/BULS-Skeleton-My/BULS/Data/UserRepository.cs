namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using Models;

    public class UsersRepository : Repository<User>
    {
        private readonly Dictionary<string, User> usersByUsername;

        public UsersRepository()
        {
            this.usersByUsername = new Dictionary<string, User>();
        }

        public User GetByUsername(string username)
        {
            if (!this.usersByUsername.ContainsKey(username))
            {
                return null;
            }

            return this.usersByUsername[username];
        }

        public override void Add(User item)
        {
            base.Add(item);
            this.usersByUsername[item.Username] = item;
        }
    }
}
