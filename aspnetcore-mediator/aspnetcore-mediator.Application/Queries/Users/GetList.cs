using MediatR;
using aspnetcore_mediator.Persistence;
using Microsoft.EntityFrameworkCore;
using aspnetcore_mediator.Domain.Entities;

namespace aspnetcore_mediator.Application.Queries.Users
{
    public class GetList
    {
        public class Query : IRequest<List<User>> { }

        public class Handler : IRequestHandler<Query, List<User>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<User>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _context.Users.ToListAsync();

                return users;
            }
        }
    }
}
