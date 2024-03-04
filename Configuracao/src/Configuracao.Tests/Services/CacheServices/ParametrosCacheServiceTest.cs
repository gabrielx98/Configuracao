namespace GxpConfiguracao.Tests.Services.CacheServices
{
    using System;
    using System.Threading;
    using FluentValidation.TestHelper;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using GxpConfiguracao.Services.CacheServices;

    [TestFixture]
    public class ParametrosCacheServiceTest
    {
        private static Randomizer _randomizer = new Randomizer(DateTime.Now.Second);

        [Test(Description = "Must set cache in first call")]
        public void MustSetCacheInFirstCall()
        {
            var cacheService = new ParametrosCacheService();

            var key = "KEY_" + _randomizer.GetString(5);
            var databaseValue = "VALUE_" + _randomizer.GetString(10);

            var value = cacheService.ObterValor("MY_MODULE", chave: key, false, () => databaseValue);

            Assert.IsNotNull(value);
            Assert.AreEqual(databaseValue, value);

            var value02 = cacheService.ObterValor(
                "MY_MODULE", 
                chave: key, 
                false, 
                () =>
                {
                    throw new ValidationTestException("Must not call DB!");
                });
            
            Assert.IsNotNull(value02);
            Assert.AreEqual(databaseValue, value02);
        }

        [Test(Description = "Must expire cache after a specified time")]
        public void MustExpireCacheAfterSpecfTime()
        {
            var cacheService = new ParametrosCacheServiceChangedTimeForTests(TimeSpan.FromSeconds(5));

            var key = "KEY_" + _randomizer.GetString(5);
            var databaseValue = "VALUE_" + _randomizer.GetString(10);
            var databaseValue02 = "VALUE_" + _randomizer.GetString(10);

            var value = cacheService.ObterValor("MY_MODULE", chave: key, false, () => databaseValue);

            Assert.IsNotNull(value);
            Assert.AreEqual(databaseValue, value);

            var value02 = cacheService.ObterValor("MY_MODULE", chave: key, false, () => databaseValue02);

            Assert.IsNotNull(value02);
            Assert.AreEqual(databaseValue, value02);

            Thread.Sleep(TimeSpan.FromSeconds(5));

            var value03 = cacheService.ObterValor("MY_MODULE", chave: key, false, () => databaseValue02);

            Assert.IsNotNull(value03);
            Assert.AreEqual(databaseValue02, value03);
        }

        [Test(Description = "Must ignore cache when indicated in call")]
        public void MustIgnoreCacheWhenIndicated()
        {
            var cacheService = new ParametrosCacheService();

            var key = "KEY_" + _randomizer.GetString(5);
            var databaseValue = "VALUE_" + _randomizer.GetString(10);
            var databaseValue02 = "VALUE_" + _randomizer.GetString(10);

            var value = cacheService.ObterValor("MY_MODULE", chave: key, false, () => databaseValue);

            Assert.IsNotNull(value);
            Assert.AreEqual(databaseValue, value);

            var value02 = cacheService.ObterValor("MY_MODULE", chave: key, false, () => databaseValue02);

            Assert.IsNotNull(value02);
            Assert.AreEqual(databaseValue, value02);
            
            var value03 = cacheService.ObterValor("MY_MODULE", chave: key, true, () => databaseValue02);

            Assert.IsNotNull(value03);
            Assert.AreEqual(databaseValue02, value03);
        }

        [Test(Description = "Must not mismatch over different keys")]
        public void MustNotMismatchOverDiffKeys()
        {
            var cacheService = new ParametrosCacheService();

            var value = cacheService.ObterValor("MY_MODULE", chave: "MY_KEY", false, () => "MYVALUE");

            Assert.IsNotNull(value);
            Assert.AreEqual("MYVALUE", value);

            var value02 = cacheService.ObterValor("MY_MODULE", chave: "MY_KEY2", false, () => "MYVALUE_KEY2");

            Assert.IsNotNull(value02);
            Assert.AreEqual("MYVALUE_KEY2", value02);
        }

        [Test(Description = "Must not mismatch over different modules")]
        public void MustNotMismatchOverDiffModules()
        {
            var cacheService = new ParametrosCacheService();

            var value = cacheService.ObterValor("MY_MODULE", chave: "MY_KEY_MODDIFF", false, () => "MYVALUE_MOD1");

            Assert.IsNotNull(value);
            Assert.AreEqual("MYVALUE_MOD1", value);

            var value02 = cacheService.ObterValor("MY_MODULE2", chave: "MY_KEY_MODDIFF", false, () => "MYVALUE_MOD2");

            Assert.IsNotNull(value02);
            Assert.AreEqual("MYVALUE_MOD2", value02);
        }

        [Test(Description = "Must return same value on different Instances")]
        public void MustReturnSameValueDiffinstances()
        {
            var cacheService1 = new ParametrosCacheService();
            var cacheService2 = new ParametrosCacheService();

            var value = cacheService1.ObterValor("MY_MODULE", chave: "MY_KEY_GLOBAL", false, () => "MYVALUE_GLOBAL");

            Assert.IsNotNull(value);
            Assert.AreEqual("MYVALUE_GLOBAL", value);

            var value02 = cacheService2.ObterValor("MY_MODULE", chave: "MY_KEY_GLOBAL", false, () => "MYVALUE_GLOBAL_NOT_VALID");

            Assert.IsNotNull(value02);
            Assert.AreEqual("MYVALUE_GLOBAL", value02);
        }

        public class ParametrosCacheServiceChangedTimeForTests : ParametrosCacheService
        {
            public ParametrosCacheServiceChangedTimeForTests(TimeSpan cacheTime)
                : base()
            {
                InstanceCacheTime = cacheTime;
            }
        }
    }
}
