using NUnit.Framework;
using ValidationEngineApp;

namespace ValidationEngineTests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void WhenSendingValidEmailAdress_ReturnsTrue()
        {
            var sut = new Validator();
            var result = sut.IsValidEmailAddress("jonasjsk@outlook.com");
            Assert.IsTrue(result);
        }
        [Test]
        public void WhenSendingNoneValidEmailAdress_ReturnsFalse()
        {
            var sut = new Validator();
            var result = sut.IsValidEmailAddress("jonasjsk@outlookcom");
            Assert.IsFalse(result);
        }
        [Test]
        public void WhenSendingEmptyEmailAdress_ReturnsFalse()
        {
            var sut = new Validator();
            var result = sut.IsValidEmailAddress("");
            Assert.IsFalse(result);
        }
        [Test]
        public void WhenSendingNullEmailAdress_ReturnsFalse()
        {
            var sut = new Validator();
            var result = sut.IsValidEmailAddress(null);
            Assert.IsFalse(result);
        }
    }
}
