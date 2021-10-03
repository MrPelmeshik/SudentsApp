using NUnit.Framework;
using StudentsApp.Controllers;
using Microsoft.Extensions.Configuration;


namespace UnitTest
{
    public class StudentControllerIndexTest
    {
        private IConfiguration _configuration;

        [SetUp]
        public void SetUp(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Test]
        public void Test1()
        {
            StudentController studentController = new StudentController(_configuration);
            string res = studentController.Index().ToString();
            Assert.AreEqual("", res);
            Assert.Pass();
        }
    }
}