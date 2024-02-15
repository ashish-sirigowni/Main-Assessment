﻿using Main_Assessment.Entity;

namespace Main_Assessment.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> GetAllUsers();
        User GetUser(string userID);
        void EditUser(User user);
        void DeleteUser(string userID);
        User ValidteUser(string email, string password);
    }
}
