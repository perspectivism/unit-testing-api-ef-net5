using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace CustomerApi.Tests.Mocks
{
    public class TestDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T>, IAsyncEnumerable<T>
        where T : class
    {
        private ObservableCollection<T> _data;
        private IQueryable _query;

        public TestDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

        public override EntityEntry<T> Add(T item)
        {
            _data.Add(item);
            return item as EntityEntry<T>;
        }

        public override EntityEntry<T> Attach(T item)
        {
            _data.Add(item);
            return item as EntityEntry<T>;
        }

        public override EntityEntry<T> Remove(T item)
        {
            _data.Remove(item);
            return item as EntityEntry<T>;
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return _data.ToAsyncEnumerable().GetAsyncEnumerator();
        }
    }
}