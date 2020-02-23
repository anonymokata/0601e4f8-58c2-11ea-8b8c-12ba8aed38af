using System;
using System.Collections.Generic;
using System.Text;
using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKadaTests
{
    [TestClass]
    public class InputTimeExceptionsTest
    {
        [TestMethod]
        public void whenValidateMethodFindsAnExceptionItThrowsArgumentException()
        {
            InputTimeExceptions exceptions = new InputTimeExceptions();
            try
            {
                exceptions.validate();
            } 
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
            }   
        }
    }
}
