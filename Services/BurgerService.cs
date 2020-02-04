using System;
using burgershack.Models;
using System.Collections.Generic;
using burgershack.Repositories;

namespace burgershack.Services
{
  public class BurgerService
  {
    private readonly BurgerRepository _repo;
    public BurgerService(BurgerRepository br)
    {
      _repo = br;
    }
    public IEnumerable<Burger> Get()
    {
      return _repo.Get();
    }
    internal Burger GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }


    internal Burger Edit(Burger update)
    {
      var exists = _repo.GetById(update.Id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Edit(update);
      return update;

    }

    internal Burger Create(Burger newData)
    {
      _repo.Create(newData);
      return newData;
    }


    internal string Delete(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(id);
      return "Successfully Deleted";

    }
  }
}