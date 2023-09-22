using AdventuraClick.Model.Helpers;
using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Implementation;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace AdventuraClick.Service.Interfaces
{
    public class UserService : CRUDService<Model.User, UserSearchObject, Database.User, UserInsertRequest, UserUpdateRequest>,
       IUserService
    {
        public UserService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }

        public override Model.User Insert(UserInsertRequest request)
        {

            if (request != null)
            {

                if (_context.Users.Where(a => a.Username == request.Username).Any())
                {
                    throw new UserException("User with that username already exists!");
                }
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new UserException("The two password fields didn't match");
                }

                var newUser = _mapper.Map<User>(request);

                newUser.PasswordSalt = GenerateSalt();

                newUser.PasswordHash = GenerateHash(newUser.PasswordSalt, request.Password);

                newUser.RoleId ??= 1;

                newUser.CreatedAt = DateTime.Now.ToString();

                _context.Users.Add(newUser);
                _context.SaveChanges();
                return _mapper.Map<Model.User>(newUser);
            }
            return null;
        }


        public Model.User Login(string username, string password)
        {
            var entity = _context.Users.Include("Role").
                FirstOrDefault(x => x.Username == username);

            if (entity == null)
            {
                throw new UserException("Not valid credentials!");
            }

            var hash = GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
            {
                throw new UserException("Not valid credentials!");
            }

            return _mapper.Map<Model.User>(entity);
        }

        public override IQueryable<User> AddFilter(IQueryable<User> query, UserSearchObject searchObject = null)
        {
            var filteredQuery = base.AddFilter(query, searchObject);

            if (!string.IsNullOrWhiteSpace(searchObject.UserName))
            {
                filteredQuery = filteredQuery.Where(x => x.Username.StartsWith(searchObject.UserName));
            }
            if (!string.IsNullOrWhiteSpace(searchObject.FullName))
            {
                filteredQuery = filteredQuery.Where(x => (x.FirstName + " " + x.LastName)
                .StartsWith(searchObject.FullName));
            }

            return filteredQuery;
        }

        public override void BeforeInsert(UserInsertRequest request, User entity)
        {

            entity.PasswordSalt = GenerateSalt();

            var hash = GenerateHash(entity.PasswordSalt, request.Password);

            entity.PasswordHash = hash;

            base.BeforeInsert(request, entity);
        }

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);

            byte[] bytes = Encoding.Unicode.GetBytes(password);

            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }

}