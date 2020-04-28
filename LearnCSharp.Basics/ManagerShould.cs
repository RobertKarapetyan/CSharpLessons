using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnCSharp.Basics
{
    [TestClass]
    public class ManagerShould
    {
        private Manager _manager;
        private EmployeeData _employeeData;

        [TestInitialize]
        public void TestInitialize()
        {
            _employeeData = new EmployeeData
            {
                FirstName = "Albert",
                LastName = "Cervantes"
            };   
            _manager = new Manager(_employeeData.FirstName, _employeeData.LastName, "Manager Task");
        }

        [TestMethod]
        public void ShouldCreateTypesInHeap()
        {
            var objectTypes = new List<Type>();

            var current = _manager.GetType();
            
            while (current.BaseType != null)
            {
                objectTypes.Add(current);
                current = current.BaseType;
            }
            
            Assert.AreEqual("System.Object", current.ToString());
            Assert.AreEqual("LearnCSharp.Basics.Employee", objectTypes[1].ToString());
            Assert.AreEqual("LearnCSharp.Basics.Manager", objectTypes[0].ToString());
            
            Assert.AreEqual("System.RuntimeType", current.GetType().ToString());
            Assert.AreEqual("System.RuntimeType", objectTypes[1].GetType().ToString());
            Assert.AreEqual("System.RuntimeType", objectTypes[0].GetType().ToString());
            
            Assert.AreEqual("System.Type", current.GetType().BaseType.BaseType.ToString());
            Assert.AreEqual("System.Type", objectTypes[1].GetType().BaseType.BaseType.ToString());
            Assert.AreEqual("System.Type", objectTypes[0].GetType().BaseType.BaseType.ToString());
        }

        [TestMethod]
        public void ShouldAlwaysPointToType()
        {
            Employee employee = _manager;
            IEmployee iemployee = _manager;
            object obj = _manager;
            
            Assert.AreEqual(typeof(Manager), employee.GetType());
            Assert.AreEqual(typeof(Manager), iemployee.GetType());
            Assert.AreEqual(typeof(Manager), obj.GetType());
        }
    }
}