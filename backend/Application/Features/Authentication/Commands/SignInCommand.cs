using Application.DTOs.SignIn;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;


namespace Application.Features.Authentication.Commands;

public class SignInCommand : IRequest<Response<ResponseSignInDto>>
{
    public string Credential { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    [JsonIgnore]
    public string Token { get; set; } = string.Empty;
    [JsonIgnore]
    public User? User { get; set; }

    public class SignInCommandHandler : IRequestHandler<SignInCommand, Response<ResponseSignInDto>>
    {
        private readonly IAuthenticationRepositoryAsync _authenticationRepositoryAsync;
        private readonly IMapper _mapper;

        public SignInCommandHandler(IAuthenticationRepositoryAsync authenticationRepositoryAsync, IMapper mapper)
        {
            _authenticationRepositoryAsync = authenticationRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<ResponseSignInDto>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(100, cancellationToken);
            var response = new ResponseSignInDto
            {
                User = request.User,
                Expiration = DateTime.Now.AddHours(8),
                Token = request.Token,
                TokenType = "Bearer"
            };
            response.User!.Password = "***********";
            return new Response<ResponseSignInDto>(response, "successful login");
        }

    }
}