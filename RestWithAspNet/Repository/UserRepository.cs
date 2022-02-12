using RestWithAspNet.Data.VO;
using RestWithAspNet.Model;
using RestWithAspNet.Model.Context;
using RestWithAspNet.Repository.Generic;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWithAspNet.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidadeCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());

            return _context.Users.FirstOrDefault(u => u.UserName.Equals(user.UserName) && u.Password.Equals(pass));
        }

        public User RefreshUserInfo(User user)
        {
            if(!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;

            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return result;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
