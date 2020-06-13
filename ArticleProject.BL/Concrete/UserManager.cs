
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.BL.Concrete
{
    using Core.Entities.Concrete;
    using BL.Abstract;
    using DAL.Abstract;

    public class UserManager : IUserService
    {
        IUserRepository userRepository;
        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Add(UserAccount user)
        {
            this.userRepository.Add(user);
        }

        public UserAccount GetByMail(string email)
        {
            return this.userRepository.Get(t0 => t0.Email == email);
        }
    }
}
