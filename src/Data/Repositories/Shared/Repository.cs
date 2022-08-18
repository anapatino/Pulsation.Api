﻿using System.Linq.Expressions;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Shared;

public class Repository <TEntity> where TEntity : class
{
    protected readonly PulsationsDbContext Context;

    public Repository(PulsationsDbContext context)
    {
        Context = context;
    }

    public void Save(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
    }

    public bool HasAny(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Any(predicate);
    }

    public virtual TEntity? Find(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().FirstOrDefault(predicate);
    }

    public virtual List<TEntity> Filter(
        Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Where(predicate).ToList();
    }

    public virtual List<TEntity> GetAll()
    {
        return Context.Set<TEntity>().AsNoTracking().ToList();
    }

    public void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        Context.SaveChangesAsync();
    }
}
