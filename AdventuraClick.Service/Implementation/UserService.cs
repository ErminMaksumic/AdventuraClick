﻿using AdventuraClick.Model.Helpers;
using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Implementation;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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