﻿using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class UserDatabase : Database<User>, IUserDatabase
    {
        private readonly List<User> _users;

        public UserDatabase()
        {
            _users = new List<User>();
            Seed();
        }

        public void Insert(User user)
        {
            User userToInsert = AutoIncrementId(user);

            _users.Add(userToInsert);
        }

        public User GetByUserNameAndPassword(string username, string password)
        {
            return _users.FirstOrDefault(user => user.UserName == username &&
                                                 user.Password == password);
        }

         public User GetByUserName(string username)
        {
            return _users.FirstOrDefault(user => user.UserName == username);
        }

        private User AutoIncrementId(User user)
        {
            int currentId = 0;

            if (_users.Count > 0)
            {
                currentId = _users.OrderByDescending(x => x.Id).First().Id;
            }

            user.Id = ++currentId;

            return user;
        }

        private void Seed()
        {
            _users.AddRange(new List<User>()
            {
                AutoIncrementId(new User("test69", "test69", Domain.Enums.Role.Administrator)),
                AutoIncrementId(new User("test1", "test1", Domain.Enums.Role.Manager)),
                AutoIncrementId(new User("test2", "test2", Domain.Enums.Role.Maintainance)),
                AutoIncrementId(new User("test3", "test3", Domain.Enums.Role.Administrator))
            });
        }

        public void Remove(User user)
        {
            _users.Remove(user);
        }
    }
}
