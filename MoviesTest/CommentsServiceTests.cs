using NUnit.Framework;
using Seminar2.Services;
using Seminar2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using Seminar2;


namespace MoviesTest
{
    class CommentsServiceTests
    {
        private IOptions<AppSettings> config;

        [SetUp]
        public void Setup()
        {
            config = Options.Create(new AppSettings
            {
                Secret = "dsadhjcghduihdfhdifd8ih"
            });
        }

        /// <summary>
        /// TODO: AAA - Arrange, Act, Assert
        /// </summary>
        [Test]
        public void TestingTheGetMethod()
        {
            var options = new DbContextOptionsBuilder<MovieDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(TestingTheGetMethod))// "ValidRegisterShouldCreateANewUser")
              .Options;

            using (var context = new MovieDbContext(options))
            {
              //  var usersService = new UsersService(context, config);
                //var commentService = new CommentsService(context);
                //var added = new Seminar2.ViewModel.RegisterPostModel
                //{
                //    Email = "a@a.b",
                //    FirstName = "fdsfsdfs",
                //    LastName = "fdsfs",
                //    Password = "1234567",
                //    Username = "test_username"
                //};
                //var result = usersService.Register(added);

                //Assert.IsNotNull(result);
                //Assert.AreEqual(added.Username, result.Username);
            }
        }
    }
}