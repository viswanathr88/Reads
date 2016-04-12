using Epiphany.Model.Services;
using Epiphany.ViewModel.Services;
using Epiphany.ViewModel.Tests.Mock;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Tests
{
    [TestClass]
    public sealed class LogonVMTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            ITimerService timerService = new MockTimerService();
            INavigationService navService = new MockNavigationService();
            ILogonService logonService = new MockLogonService();

            ILogonViewModel vm = null;
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                vm = new LogonViewModel(null, navService, timerService);
            });
            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                vm = new LogonViewModel(logonService, null, timerService);
            });
            
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                vm = new LogonViewModel(logonService, navService, null);
            });

            vm = new LogonViewModel(logonService, navService, timerService);
            Assert.IsNotNull(vm, "VM is null");
            Assert.IsFalse(vm.IsLoading, "IsLoading");
            Assert.IsFalse(vm.IsLoaded, "IsLoaded");
            Assert.IsFalse(vm.IsLoginCompleted, "IsLoginCompleted");
            Assert.IsFalse(vm.IsWaitingForUserInteraction, "IsWaitingForUserInteraction");
            Assert.IsNull(vm.Error, "Error");
            Assert.IsFalse(vm.IsSignInTakingLonger, "IsSignInTakingLonger");
            Assert.IsNotNull(vm.CheckUriForLoginCompletion, "CheckUriForLoginCompletion");
            Assert.IsNotNull(vm.Login, "Login");
            Assert.IsNull(vm.CurrentUri, "CurrentUri");
        }

        [TestMethod]
        public async Task VerifyLoginStepSuccessTest()
        {
            ITimerService timerService = new MockTimerService();
            INavigationService navService = new MockNavigationService();
            MockLogonService logonService = new MockLogonService();

            logonService.PassVerifyLogin = true;

            ILogonViewModel vm = new LogonViewModel(logonService, navService, timerService);
            await vm.LoadAsync(VoidType.Empty);

            Assert.IsTrue(vm.IsLoaded, "IsLoaded");
            Assert.IsTrue(vm.IsLoginCompleted, "IsLoginCompleted");
        }

        [TestMethod]
        public async Task VerifyLoginStepFailureTest()
        {
            ITimerService timerService = new MockTimerService();
            INavigationService navService = new MockNavigationService();
            ILogonService logonService = new MockLogonService();

            // VerifyLogin step will fail
            ILogonViewModel vm = new LogonViewModel(logonService, navService, timerService);
            await vm.LoadAsync(VoidType.Empty);

            Assert.IsNotNull(vm.CurrentUri, "CurrentUri");
            Assert.AreEqual(vm.CurrentUri, logonService.Configuration.AuthorizeUri, "Authorize URI does not match");
        }

        [TestMethod]
        public async Task CheckUriForLoginCompletionTest()
        {
            ITimerService timerService = new MockTimerService();
            INavigationService navService = new MockNavigationService();
            ILogonService logonService = new MockLogonService();

            // VerifyLogin step will fail
            ILogonViewModel vm = new LogonViewModel(logonService, navService, timerService);
            await vm.LoadAsync(VoidType.Empty);



        }
    }
}
