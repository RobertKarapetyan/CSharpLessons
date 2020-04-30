using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnCSharp.Basics.Boxing
{
    [TestClass]
    public class EntityShould
    {
        [TestMethod]
        public void ShouldTurnToObjectAfterBoxing()
        {
            var entity = new Entity();
            IEntity iEntity = entity;
            object obj = entity;
            
            Assert.AreEqual(typeof(Entity), iEntity.GetType());
            Assert.AreEqual(typeof(Entity), obj.GetType());
        }

        [TestMethod]
        public void ShouldBoxThenChangeValues()
        {
            var entity = new Entity(1, 1);
            object obj = entity;
            entity.Change(2, 2);
            
            Assert.AreEqual(2, entity.X);
            Assert.AreEqual(2, entity.Y);
            Assert.AreEqual(1, ((Entity) obj).X);
            Assert.AreEqual(1, ((Entity) obj).Y);

            entity = (Entity) obj;
            entity.Change(2, 2);
            obj = entity;
            
            Assert.AreEqual(2, entity.X);
            Assert.AreEqual(2, entity.Y);
            Assert.AreEqual(2, ((Entity) obj).X);
            Assert.AreEqual(2, ((Entity) obj).Y);
        }

        [TestMethod]
        public void ShouldBoxThenChangeValuesWithInterfaces()
        {
            var entity = new Entity(1, 1);
            IEntity iEntity = entity;
            iEntity.Change(2, 2);
            
            Assert.AreEqual(1, entity.X);
            Assert.AreEqual(1, entity.Y);
            Assert.AreEqual(2, ((Entity) iEntity).X);
            Assert.AreEqual(2, ((Entity) iEntity).Y);
        }
    }
}