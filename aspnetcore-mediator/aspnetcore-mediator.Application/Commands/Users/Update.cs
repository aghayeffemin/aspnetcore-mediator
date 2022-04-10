using aspnetcore_mediator.Persistence;
using FluentValidation;
using MediatR;

namespace aspnetcore_mediator.Application.Commands.Users
{
    public class Update
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                var user = await _context.Users.FindAsync(request.Id);

                if (user == null)
                    throw new KeyNotFoundException($"User record for key {request.Id} not found.");

                user.Username = request.Username;
                user.Name = request.Name;
                user.Surname = request.Surname;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Could not save changes");
            }
        }
    }
}
