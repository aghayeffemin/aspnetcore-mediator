using MediatR;
using aspnetcore_mediator.Persistence;
using aspnetcore_mediator.Domain.Entities;

namespace aspnetcore_mediator.Application.Queries.Users
{
    public class GetById
    {
        public class Query : IRequest<User>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);

                if (user == null)
                    throw new KeyNotFoundException($"User record for key {request.Id} not found.");

                return user;
            }
        }
    }
}
