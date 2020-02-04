using System;
using System.Collections.Generic;
using System.Data;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
  public class BurgerRepository
  {
    private readonly IDbConnection _db;
    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Burger> Get()
    {
      string sql = "SELECT * FROM burgers";
      return _db.Query<Burger>(sql);
    }
    internal Burger GetById(int Id)
    {
      string sql = "SELECT * FROM burgers WHERE id = @Id";
      return _db.QueryFirstOrDefault<Burger>(sql, new { Id });
    }

    internal Burger Create(Burger newData)
    {
      string sql = @"
      INSERT INTO burgers 
      (name, description, price)
      VALUES 
      (@Name, @Description, @Price);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }
    internal void Edit(Burger update)
    {
      string sql = @"
      UPDATE burgers
      SET 
      name = @Name,
      description = @Description,
      price = @Price
      WHERE id = @Id;";
      _db.Execute(sql, update);
    }
    internal void Delete(int Id)
    {
      string sql = "DELETE FROM burgers WHERE id = @Id";
      _db.Execute(sql, new { Id });
    }
  }

}