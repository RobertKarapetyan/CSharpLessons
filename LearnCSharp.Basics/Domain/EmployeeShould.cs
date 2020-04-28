using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnCSharp.Basics.Domain
{
    [TestClass]
    public class EmployeeShould
    {
        private Employee _employee;
        private EmployeeData _employeeData;

        [TestInitialize]
        public void TestInitialize()
        {
            _employeeData = new EmployeeData
            {
                FirstName = "Albert", LastName = "Cervantes"
            };
            
            _employee = new Employee(_employeeData.FirstName, _employeeData.LastName);
        }
        
        [TestMethod]
        public void ShouldAccessPublicField()
        {
            (typeof(Employee)).GetField("Id").GetValue(_employee);
        }

        [TestMethod]
        public void ShouldNotAccessProtectedField()
        {
            var  exception = new Exception();
            
            try
            {
                (typeof(Employee)).GetField("FirstName").GetValue(_employee);
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                Assert.AreEqual(typeof(NullReferenceException), exception.GetType());
            }
        }

        [TestMethod]
        public void ShouldClone()
        {
            var otherEmployee = _employee.Clone();
            Assert.IsFalse(object.ReferenceEquals(_employee, otherEmployee)); 
            
            Assert.AreEqual(_employee.Id, otherEmployee.Id);
            otherEmployee.Id++;
            Assert.AreNotEqual(_employee.Id, otherEmployee.Id);
        }
    }
}