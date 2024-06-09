using hiravrt.Models.Nav.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hiravrt.tests.Models.Nav.Contact
{
    class FormModelTests
    {
        private FormModel model;

        [SetUp]
        public void SetUp()
        {
            model = new();
        }

        [Test]
        public void EmptyMessageIsInvalid_Test()
        {
            model.Message = "";
            Assert.That(model.IsValidForm(), Is.False);
        }

        [Test]
        public void NonEmptyMessageIsValid_Test()
        {
            model.Message = "is not empty";
            Assert.That(model.IsValidForm(), Is.True);
        }

        [Test]
        public void ResetTurnsStringVariablesEmpty_Test()
        {
            model.Name = "Name";
            model.Email = "email";
            model.Message = "Message";

            model.Reset();

            Assert.That(model.Name.Length == 0 && model.Email.Length == 0 && model.Message.Length == 0);
        }
    }
}
