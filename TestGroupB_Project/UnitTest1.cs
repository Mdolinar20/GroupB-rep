using GroupB_Project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace TestGroupB_Project
{
    [TestClass]
    public class ScheduledSessionSubjectTest
    {
        [Fact]
        public void SubjectTest()
        {
            string newSubject = "Math";
            ScheduledSession newScheduledSession = new ScheduledSession();

            newScheduledSession.Subject = newSubject;

            Assert.Equals(newScheduledSession.Subject, newSubject);
            //Assert.NotEqual(newUserId.UserId, newFirstUserId);
        }

        [Theory]
        [InlineData("WepApp", "WepApp")]
        [InlineData("OS", "OS")]
        [InlineData("Java", "Java")]
        public void SubjectAcceptsAllInput(string newSubject, string expected)
        {
            ScheduledSession newScheduledSession = new ScheduledSession();

            newScheduledSession.Subject = newSubject;

            Assert.Equals(newScheduledSession.Subject, expected);
            //Assert.NotEqual(newUser.UserId, expected);
        }
    }
}
