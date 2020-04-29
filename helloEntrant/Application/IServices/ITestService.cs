using Application.DTOs.User;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITestService
    {
        Task SaveTests(UserProfile request, string username);
        void MapTests(ref Test test, string name, double mark);
    }
}
