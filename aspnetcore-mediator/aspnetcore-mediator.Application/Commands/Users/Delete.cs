using aspnetcore_mediator.Persistence;
using MediatR;

namespace aspnetcore_mediator.Application.Commands.Users
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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

                _context.Remove(user);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Could not save changes");
            }
        }
    }
}
