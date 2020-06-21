
using System;
using System.Collections.Generic;
using System.Linq;
using PostgresRepository.Models;

namespace PostgresRepository.Database
{
    public class AuthorDataService
    {
        public AuthorModel Create(AuthorModel dto)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.Authors.Add(dto);
                    context.SaveChanges();
                    return dto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AuthorModel> Read()
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var authors = context.Authors.ToList();
                    return authors;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
