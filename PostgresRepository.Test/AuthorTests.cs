using System;
using API.Domain;
using PostgresRepository.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PostgresRepository.Test
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void CreateAuthor()
        {
            try
            {
                var dto = new Author
                {
                    FullName = "James Bond",
                    Email = "bond@james.com",
                };
                var result = new AuthorDataService().Create(dto);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(true, ex.Message);
            }
        }
        [TestMethod]
        public void GetAuthors()
        {
            try
            {
                var result = new AuthorDataService().Read();
                Assert.IsTrue(result != null);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(true, ex.Message);
            }
        }
    }
}
