using System;
using MediatR;
using Domain;
using Persistence;

namespace Application.Activities
{

    public class Details
    {
        

        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private DataContext Context;
            
            public Handler(DataContext context)
            {
                this.Context = context;

            }

            public async Task<Activity>Handle(Query request, CancellationToken CancellationToken)
            {
                return await this.Context.Activities.FindAsync(request.Id);
            }
        }
    }
}