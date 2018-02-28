﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace EasyNetQ
{
    public abstract class RequestMessageHandler<TMessage>
        : IRequestHandler<RequestMessage<TMessage>>
        where TMessage : class
    {
        public Task Handle(
            RequestMessage<TMessage> requestMessage,
            CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(
                () => this.Run(requestMessage.Message));
        }

        public abstract void Run(TMessage message);
    }
}
