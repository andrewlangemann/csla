﻿using System.Configuration.Provider;
using System.Reflection;
using System.Web.Security;
using Csla.Testing.Business.Security;
using UnitDriven;

#if NUNIT
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestSetup = NUnit.Framework.SetUpAttribute;
#elif MSTEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace Csla.Test.Silverlight.Security
{
  public partial class SecurityTests
  {
#if SILVERLIGHT
    //NUnit tests do not
    [TestSetup]
    public void Setup()
    {
      InitMockMembershipProvider();
      InitMockRoleProvider();
    }
#endif

    private void InitMockRoleProvider()
    {
      var role = new MockRoleProvider();
      role.Initialize("MockRoleProvider",null);
      typeof(ProviderCollection).GetField("_ReadOnly", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Roles.Providers, false);
      Roles.Providers.Clear();
      Roles.Providers.Add(role);
    }

    private void InitMockMembershipProvider()
    {
      //Little reflection to assure that the Membership.Providers can be modified
      var provider = new MockMembershipProvider();
      provider.Initialize("MockMembershipProvider",null);
      typeof(ProviderCollection).GetField("_ReadOnly", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Membership.Providers, false);
      Membership.Providers.Clear();
      Membership.Providers.Add(provider);
    }

    [TestMethod]
    public void SetCSLAPrincipalLocal()
    {
      SilverlightPrincipal.Logout();
      SilverlightPrincipal.LoginUsingCSLA(SilverlightPrincipal.VALID_TEST_UID, SilverlightPrincipal.VALID_TEST_PWD);
      Assert.IsNotNull(Csla.ApplicationContext.User);
      Assert.AreEqual(true, Csla.ApplicationContext.User.Identity.IsAuthenticated);
      Assert.AreEqual("SilverlightIdentity", Csla.ApplicationContext.User.Identity.Name);
      Assert.AreEqual("SilverLight", Csla.ApplicationContext.User.Identity.AuthenticationType);
      Assert.AreEqual(true, Csla.ApplicationContext.User.IsInRole(AdminRoleName));

      SilverlightPrincipal.Logout();
      SilverlightPrincipal.LoginUsingCSLA("invalidusername", SilverlightPrincipal.VALID_TEST_PWD);
      Assert.IsNotNull(Csla.ApplicationContext.User);
      Assert.AreEqual(false, Csla.ApplicationContext.User.Identity.IsAuthenticated);
      Assert.AreEqual("", Csla.ApplicationContext.User.Identity.Name);
      Assert.AreEqual(false, Csla.ApplicationContext.User.IsInRole(AdminRoleName));
      Assert.AreEqual("Csla", Csla.ApplicationContext.User.Identity.AuthenticationType);
    }

    #region Login Using Membership Principal
#if !CLIENTONLY
    [TestMethod]
    public void SetMembershipPrincipalWebServer()
    {
      SilverlightPrincipal.Logout();
      SilverlightPrincipal.LoginUsingMembershipProviderWebServer(SilverlightPrincipal.VALID_TEST_UID, SilverlightPrincipal.VALID_TEST_PWD);
      Assert.IsNotNull(Csla.ApplicationContext.User);
      Assert.AreEqual(true, Csla.ApplicationContext.User.Identity.IsAuthenticated);
      Assert.AreEqual(SilverlightPrincipal.VALID_TEST_UID, Csla.ApplicationContext.User.Identity.Name);
      Assert.AreEqual(true, Csla.ApplicationContext.User.IsInRole("User Role"));
    }

    [TestMethod]
    public void SetMembershipPrincipalDataPortal()
    {
      SilverlightPrincipal.Logout();
      SilverlightPrincipal.LoginUsingMembershipProviderDataPortal(SilverlightPrincipal.VALID_TEST_UID, SilverlightPrincipal.VALID_TEST_PWD);
      Assert.IsNotNull(Csla.ApplicationContext.User);
      Assert.AreEqual(true, Csla.ApplicationContext.User.Identity.IsAuthenticated);
      Assert.AreEqual(SilverlightPrincipal.VALID_TEST_UID, Csla.ApplicationContext.User.Identity.Name);
      Assert.AreEqual(true, Csla.ApplicationContext.User.IsInRole("User Role"));
    }

    [TestMethod]
    public void SetInvalidMembershipPrincipal()
    {
      SilverlightPrincipal.Logout();
      SilverlightPrincipal.LoginUsingMembershipProviderDataPortal("invalidusername", SilverlightPrincipal.VALID_TEST_PWD);
      Assert.IsNotNull(Csla.ApplicationContext.User);
      Assert.AreEqual(false, Csla.ApplicationContext.User.Identity.IsAuthenticated);
      Assert.AreEqual("", Csla.ApplicationContext.User.Identity.Name);
      Assert.AreEqual(false, Csla.ApplicationContext.User.IsInRole(AdminRoleName));
    }
#endif
    #endregion

  }
}
