using System;

namespace Labb2Data
{
    public interface IUserRepository
    {
        void AddNewUser(UserDataModel user);
        UserDataModel GetUserById(Guid id);
        UserDataModel LoginUser(UserDataModel user);
    }
}