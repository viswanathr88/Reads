using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.Model.Tests
{
    public static class AssertHelper
    {
        public async static Task<T> ThrowsExceptionAsync<T>(Func<Task> testCode) where T : Exception
        {
            try
            {
                await testCode();
                Assert.ThrowsException<T>(() => { }); // Use default behavior.
            }
            catch (T exception)
            {
                return exception;
            }
            // Never reached. Compiler doesn't know Assert.Throws above always throws.
            return null;
        }
    }
}
