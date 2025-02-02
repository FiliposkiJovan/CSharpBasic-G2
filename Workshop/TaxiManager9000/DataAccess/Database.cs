﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public abstract class Database<T> : IDatabase<T> where T : BaseEntity
    {
        protected List<T> _items;

        public Database()
        {
            _items = new List<T>();
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public void Insert(T item)
        {
            T itemToInsert = AutoIncrementId(item);

            _items.Add(itemToInsert);
        }

        protected T AutoIncrementId(T item)
        {
            int currentId = 0;

            if (_items.Count > 0)
            {
                currentId = _items.OrderByDescending(x => x.Id).First().Id;
            }

            item.Id = ++currentId;

            return item;
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void Update(T item)
        {
            // do nothing
        }
    }
}
