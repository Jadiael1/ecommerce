using Application.Wrappers;
using MediatR;

namespace Application.Features.Authentication.Commands;

public class SignInCommand : IRequest<Response<object>>
{
    public string Credential { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public class SignInCommandHandler : IRequestHandler<SignInCommand, Response<object>>
    {
        public async Task<Response<object>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Credential) && !string.IsNullOrEmpty(request.Password))
            {
                var result = BCrypt.Net.BCrypt.Verify(request.Password, request.Password);
            }
            await Task.Delay(100);
            return new Response<object>(new { Id = 1, Name = "Name1" });
        }
    }
}