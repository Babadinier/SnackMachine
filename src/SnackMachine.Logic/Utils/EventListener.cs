﻿using System.Threading;
using System.Threading.Tasks;
using DDDInPractice.Logic.Common;
using NHibernate.Event;

namespace DDDInPractice.Logic.Utils
{
    internal class EventListener : IPostInsertEventListener, 
        IPostDeleteEventListener, 
        IPostUpdateEventListener, 
        IPostCollectionUpdateEventListener
    {
        public Task OnPostInsertAsync(PostInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void OnPostInsert(PostInsertEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public Task OnPostDeleteAsync(PostDeleteEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void OnPostDelete(PostDeleteEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public Task OnPostUpdateAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void OnPostUpdate(PostUpdateEvent @event)
        {
            DispatchEvents(@event.Entity as AggregateRoot);
        }

        public Task OnPostUpdateCollectionAsync(PostCollectionUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void OnPostUpdateCollection(PostCollectionUpdateEvent @event)
        {
            DispatchEvents(@event.AffectedOwnerOrNull as AggregateRoot);
        }

        private void DispatchEvents(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot == null)
                return;

            foreach (IDomainEvent domainEvent in aggregateRoot.DomainEvents)
            {
                DomainEvents.Dispatch(domainEvent);
            }

            aggregateRoot.ClearEvents();
        }
    }
}
