using aspnetcore_mediator.Domain.Entities;
using aspnetcore_mediator.Persistence;
using FluentValidation;
using MediatR;

namespace aspnetcore_mediator.Application.Commands.Users
{
    public class Add
    {
        public class Command : IRequest
        {
            public string Username { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Username).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    Username = request.Username,
                    Name = request.Name,
                    Surname = request.Surname
                };

                await _context.Users.AddAsync(user);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Could not save changes");
            }
        }
    }
}
