using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void CheckIfDummyLoosesHealthCorrectly()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health);
        }
        [Test]
        public void DeadDummyShouldThrowExceptionWhenAttacked()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
        }
        [Test]
        public void DummyGiveExperienceWhenDies()
        {
            Dummy dummy = new Dummy(0, 10);

            int exp = dummy.GiveExperience();

            Assert.AreEqual(10, exp);
        }
        [Test]
        public void DummyCannotGiveExperienceWhenDead()
        {
            Dummy dummy = new Dummy(2, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}