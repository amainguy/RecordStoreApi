using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RecordStore.Api.Controllers;
using RecordStore.DomainObjects;

namespace RecordStore.Api.Tests.UnitTests
{

    [TestClass]
    public class AccountControllerTests
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private IConfiguration _configuration;
        private AccountController _subject;

        private const string Email = "testuser@test.com";
        private const string Password = "itsAs3cr3t";

        [TestInitialize]
        public void Initialize()
        {
            _signInManager = new FakeSignInManager();
            _userManager = new FakeUserManager();
        }

        [TestMethod]
        public void Login()
        {   
        }

        [TestMethod]
        public void Register()
        {

        }
    }

    public class FakeSignInManager : SignInManager<IdentityUser>
    {
        public FakeSignInManager(): base(
                new FakeUserManager(), 
                Substitute.For<IHttpContextAccessor>(),
                Substitute.For<IUserClaimsPrincipalFactory<IdentityUser>>(),
                Substitute.For<IOptions<IdentityOptions>>(),
                Substitute.For<ILogger<SignInManager<IdentityUser>>>(),
                Substitute.For<IAuthenticationSchemeProvider>())
        { }
    }

    public class FakeUserManager : UserManager<IdentityUser>
    {
        public FakeUserManager() : base(
                Substitute.For<IUserStore<IdentityUser>>(),
                Substitute.For<IOptions<IdentityOptions>>(),
                Substitute.For<IPasswordHasher<IdentityUser>>(),
                new IUserValidator<IdentityUser>[0],
                new IPasswordValidator<IdentityUser>[0],
                Substitute.For<ILookupNormalizer>(),
                Substitute.For<IdentityErrorDescriber>(),
                Substitute.For<IServiceProvider>(),
                Substitute.For<ILogger<UserManager<IdentityUser>>>()
            )
        { }

    }
}
