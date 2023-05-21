using System.Net;
using Application.Exceptions;
using Application.Features.Authentication.Commands;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class AuthenticationRepositoryAsync : GenericRepositoryAsync<User>, IAuthenticationRepositoryAsync
{
    private IDataShapeHelper<User> _dataShaper;
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<User> _users;
    private readonly IMapper _mapper;

    public AuthenticationRepositoryAsync(ApplicationDbContext dbContext, IDataShapeHelper<User> dataShaper,
        IMapper mapper) : base(dbContext)
    {
        _dataShaper = dataShaper;
        _users = dbContext.Set<User>();
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public static async Task<User> SignIn(SignInCommand request, ApplicationDbContext _context)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u =>
            u.Email == request.Credential || u.Login == request.Credential);

        if (user == null)
        {
            throw new KeyNotFoundException("Incorrect credential or password");
        }

        var verifyPw = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

        if (!verifyPw)
        {
            throw new KeyNotFoundException("Incorrect credential or password");
        }
        return user;
    }
}