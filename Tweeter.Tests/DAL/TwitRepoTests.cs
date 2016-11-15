using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweeter.DAL;
using Moq;
using System.Data.Entity;
using Tweeter.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tweeter.Tests
{
    [TestClass]
    public class TwitRepoTests
    {
        private Mock<DbSet<ApplicationUser>> mock_users { get; set; }
        private Mock<TweeterContext> mock_context { get; set; }
        private TweeterRepository Repo { get; set; }
        private List<Twit> users { get; set; }
        private Twit twit1;
        private Twit twit2;

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<TweeterContext>();
            mock_users = new Mock<DbSet<ApplicationUser>>();
            Repo = new TweeterRepository(mock_context.Object);
            twit1 = new Twit
            {
                Username = "tweet-tweet"
            };
            twit2 = new Twit
            {
                Username = "YourMomsATwit"
            };

            /*
             * 1. Install Identity into Tweeter.Tests (using statement needed)
             * 2. Create a mock context that uses 'UserManager' instead of 'TweeterContext' 
             */


        }

        public void ConnectMocksToDatabase()
        {
            users = new List<ApplicationUser>();
            var queryable_list = users.AsQueryable();

            mock_users.As<IQueryable<ApplicationUser>>().Setup(a => a.Provider).Returns(queryable_list.Provider);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(a => a.Expression).Returns(queryable_list.Expression);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(a => a.ElementType).Returns(queryable_list.ElementType);
            mock_users.As<IQueryable<ApplicationUser>>().Setup(a => a.GetEnumerator()).Returns(queryable_list.GetEnumerator());

            /*
             * Mocks the 'Users' getting that returns a list of ApplicationUsers.
             * mock_user_manager_context.Setup(C => c.Users).Returns(mock_users.Object);
             * 
             */


            /* If wejust add a Username field to the Twit model
             * mock_context.Setup(c => c.TweeterUsers).Returns(mock.user.Object); Assuming mock_users is List<Twit>
             */
            

            mock_context.Setup(c => c.TweeterUsers).Returns(mock.user.Object);
        }

        [TestMethod]
        public void CanMakeInstanceOfRepo()
        {
            TweeterRepository Repo = new TweeterRepository();
            Assert.IsNotNull(Repo);
        }

        [TestMethod]
        public void RepoCanAccessContext()
        {
            TweeterRepository Repo = new TweeterRepository(mock_context.Object);
            Assert.IsNotNull(Repo);
        }

        [TestMethod]
        public void GetUsernames()
        {
            TweeterRepository Repo = new TweeterRepository(mock_context.Object);

            List<Twit> allUsers = Repo.GetAllUsernames();

            CollectionAssert.AreEqual(allUsers, users);
        } 
    }
}

