
using System;
using System.Collections.Generic;
using System.Linq;
using API.Domain;
using PostgresRepository.Models;

namespace PostgresRepository.Database
{
    public class AuthorDataService
    {
        public Author Create(Author dto)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    context.Authors.Add(new AuthorModel { FullName = dto.FullName, Email = dto.Email });
                    context.SaveChanges();
                    return dto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Author> Read()
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var authors = context.Authors.ToList();
                    return authors.Select(x => new Author
                    {
                        Id = x.Id,
                        FullName = x.FullName,
                        Email = x.Email
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Author Read(int id)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var author = context.Authors.FirstOrDefault(x => x.Id == id);
                    return new Author
                    {
                        Id = author.Id,
                        FullName = author.FullName,
                        Email = author.Email
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
