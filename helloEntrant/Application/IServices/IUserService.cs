using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserService
    {
        Task UpdateUserInfo(UserProfile request);

        Task<UserProfile> GetUserInfo(string email);

        //Task AddTests(UserProfile request);
    }
}
