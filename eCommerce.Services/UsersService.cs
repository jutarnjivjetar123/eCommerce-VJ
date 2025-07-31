using System;
using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using eCommerce.Models;
using eCommerce.Models.Entities;
using eCommerce.Models.Requests;
using eCommerce.Services.Interfaces;
using MapsterMapper;
using Microsoft.Identity.Client;

namespace eCommerce.Services;

public class UsersService(AppDbContext dbContext, IMapper mapper) : IUsersService
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;
    public List<UserResponse> GetList()
    {
        List<UserResponse> result = new List<UserResponse>();

        var list = _dbContext.Users.ToList();

        result = _mapper.Map(list, result);

        return result;
    }

    public UserResponse Insert(UserInsertRequest request)
    {
        if (request.Password != request.PasswordConfirmation)
        {
            throw new Exception("Password and password confirmation must be the same");
        }

        User user = new User();
        _mapper.Map(request, user);

        user.PasswordSalt = GenerateSalt();
        user.PasswordHash = GenerateHash(user.PasswordSalt, request.Password);

        _dbContext.Add(user);
        _dbContext.SaveChanges();

        return _mapper.Map<User, UserResponse>(user);
    }

    public static string GenerateSalt()
    {
        var byteArray = RNGCryptoServiceProvider.GetBytes(16);

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

    public UserResponse Update(int id, UserUpdateRequest request)
    {
        var entity = _dbContext.Users.Find(id);

        _mapper.Map(request, entity);

        if (!string.IsNullOrEmpty(request.Password))
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Password and password confirmation must be the same");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
        }

        _dbContext.SaveChanges();

        return _mapper.Map<UserResponse>(entity);
    }
}
