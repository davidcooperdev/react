// using System;
using MediatR;
using Domain;
using Persistence;

namespace Application.Activities
{

    public class Create
    {
        

        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private DataContext Context;
            
            public Handler(DataContext context)
            {
                this.Context = context;

            }

            public async Task Handle(Command request, CancellationToken CancellationToken)
            {
                this.Context.Activities.Add(request.Activity);
                await this.Context.SaveChangesAsync();

                //return Unit.Value;
            }
        }
    }
}