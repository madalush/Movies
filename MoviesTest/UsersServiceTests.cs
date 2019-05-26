using NUnit.Framework;
using Seminar2.Services;
using Seminar2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using Seminar2;

namespace Tests
{
    public class UsersServiceTests
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
        public void ValidRegisterShouldCreateANewUser()
        {
            var options = new DbContextOptionsBuilder<MovieDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(ValidRegisterShouldCreateANewUser))// "ValidRegisterShouldCreateANewUser")
              .Options;

            using (var context = new MovieDbContext(options))
            {
                var usersService = new UsersService(context, config);
                var added = new Seminar2.ViewModel.RegisterPostModel
                {
                    Email = "a@a.b",
                    FirstName = "fdsfsdfs",
                    LastName = "fdsfs",
                    Password = "1234567",
                    Username = "test_username"
                };
                var result = usersService.Register(added);

                Assert.IsNotNull(result);
                Assert.AreEqual(added.Username, result.Username);
            }
        }
        [Test]
        public void ValidAuthenticate()
        {
            var options = new DbContextOptionsBuilder<MovieDbContext>()
              .UseInMemoryDatabase(databaseName: nameof(ValidAuthenticate))// "ValidRegisterShouldCreateANewUser")
              .Options;

            using (var context = new MovieDbContext(options))
            {
                var usersService = new UsersService(context, config);
                var added = new Seminar2.ViewModel.RegisterPostModel
                {
                    Email = "a@a.b",
                    FirstName = "fdsfsdfs",
                    LastName = "fdsfs",
                    Password = "1234567",
                    Username = "test_username"
                };
               usersService.Register(added);
                var loggedIn = new Seminar2.ViewModel.LoginPostModel
                {
                   
                    Password = "1234567",
                    Username = "test_username"
                };
                var result = usersService.Authenticate(added.Username,added.Password);

                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Id);
                Assert.AreEqual(loggedIn.Username, result.Username);
                Assert.IsNotNull(result.Token);
            }
        }




    }
}