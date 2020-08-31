using OnlineExamApp.Common;
using OnlineExamApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Services
{
    public class CustomerServices : ICustomerService
    {
        private examlibrarydbContext _context;

        public CustomerServices(examlibrarydbContext context)
        {
            _context = context;
        }

        public Customeraccount Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Customeraccount.SingleOrDefault(x => x.EmailId == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<Customeraccount> GetAll()
        {
            return _context.Customeraccount;
        }

        public Customeraccount GetById(int id)
        {
            return _context.Customeraccount.Find(id);
        }

        public Customeraccount Create(Customeraccount user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Customeraccount.Any(x => x.EmailId == user.EmailId))
                throw new AppException("Username \"" + user.EmailId + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.RoleId = 0;
          //  user.CustId = 0;

            _context.Customeraccount.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(Customeraccount userParam, string password = null)
        {
            var user = _context.Customeraccount.Find(userParam.CustId);

            if (user == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.EmailId) && userParam.EmailId != user.EmailId)
            {
                // throw error if the new username is already taken
                if (_context.Customeraccount.Any(x => x.EmailId == userParam.EmailId))
                    throw new AppException("Username " + userParam.EmailId + " is already taken");

                user.EmailId = userParam.EmailId;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Customeraccount.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Customeraccount.Find(id);
            if (user != null)
            {
                _context.Customeraccount.Remove(user);
                _context.SaveChanges();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public Customeraccount GetByEmailId(string emailid)
        {
            return _context.Customeraccount.Find(emailid);
        }
    }
}
