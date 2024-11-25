using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private int LessThanNeededToAttack = Random.Shared.Next(1, 30);
        private int TooPowerFullFoe = 1000;
        private int MIN_ATTACK_HP = 30;
        private string testName = GenerateRandomString();
        private int testDamage = Random.Shared.Next(1, 10);
        private int testHp = Random.Shared.Next(30, 100);
        private Warrior testWarrior;
        private const int LessThanZero = -7;
        [Test]
        public void WarriorConstructorInitialisedShouldNotBeNull()
        {
            testWarrior = new Warrior(testName, testDamage, testHp);

            Assert.IsNotNull(testWarrior);
        }

        [Test]
        public void NamePropertyOfWarriorShouldInitialiseCorrectly()
        {
            testWarrior = new Warrior(testName, testDamage, testHp);
            Assert.AreEqual(testWarrior.Name, testName);
        }

        [Test]
        public void DamagePropertyOfWarriorShouldInitialiseCorrectly()
        {
            testWarrior = new Warrior(testName, testDamage, testHp);
            Assert.AreEqual(testWarrior.Damage, testDamage);
        }

        [Test]
        public void HpPropertyOfWarriorShouldInitialiseCorrectly()
        {
            testWarrior = new Warrior(testName, testDamage, testHp);
            Assert.AreEqual(testWarrior.HP, testHp);
        }

        [TestCase(null), TestCase(""), TestCase("\r\n")]
        public void IncorrectNameShouldThrowException(string invalidName)
        {

            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior(invalidName, testDamage, testHp));
        }

        [TestCase(0), TestCase(LessThanZero)]
        public void IncorrectDamageShouldThrowExceptionLessThanOrEqualToZero(int invalidDamage)
        {

            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior(testName, invalidDamage, testHp));
        }

        [TestCase(LessThanZero)]
        public void IncorrectHpShouldThrowExceptionLessThanZero(int invalidHp)
        {
            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior(testName, testDamage, invalidHp));
        }

        [Test]
        public void AttackShouldThrowExceptionIfNotEnoughHpToAttack()
        {
            testWarrior = new Warrior(testName, testDamage, LessThanNeededToAttack);

            Assert.Throws<InvalidOperationException>(
                () => testWarrior.Attack(new Warrior(testName, testDamage, testHp)));
        }

        [Test]
        public void AttackShouldThrowExceptionIfOpponentHpTooLow()
        {
            testWarrior = new Warrior(testName, testDamage, testHp);

            Assert.Throws<InvalidOperationException>(
                () => testWarrior.Attack(new Warrior(testName, testDamage, LessThanNeededToAttack)));
        }

        [Test]
        public void AttackShouldThrowExceptionIfOpponentTooPowerful()
        {
            testWarrior = new Warrior(testName, testDamage, testHp);

            Assert.Throws<InvalidOperationException>(
                () => testWarrior.Attack(new Warrior(testName, TooPowerFullFoe, testHp)));
        }

        [Test]
        public void AttackHaveToLowerHpCorrectly()
        {
            Warrior weakWarrior = new Warrior(testName, testDamage, testHp);
            int damage = testDamage * 2;
            int hp = testHp * 2;
            Warrior strongWarrior = new Warrior(testName, damage, hp);

            strongWarrior.Attack(weakWarrior);
            
            Assert.That(weakWarrior.HP,Is.EqualTo((testHp - testDamage*2)));
            Assert.That(strongWarrior.HP,Is.EqualTo(hp - testDamage));

        }
        [Test]
        public void AttackHaveToLowersToZeroHp()
        {
            Warrior weakWarrior = new Warrior(testName, testDamage, testHp);
            
            int hp = testHp * 2;
            Warrior strongWarrior = new Warrior(testName, testHp + 1, hp);

            strongWarrior.Attack(weakWarrior);

            Assert.That(weakWarrior.HP, Is.EqualTo((0)));
            
        }

        private static readonly (char Begin, int Length)[] _characterGroups = { ('a', 26), ('A', 26), ('0', 10) };                                  // Random string generator

        private static string GenerateRandomString()
        {
            char[] content = new char[Random.Shared.Next(5, 30)];

            for (int i = 0; i < content.Length; i++)
            {
                int randomGroupIndex = Random.Shared.Next(_characterGroups.Length);
                content[i] = (char)(_characterGroups[randomGroupIndex].Begin + Random.Shared.Next(_characterGroups[randomGroupIndex].Length));
            }

            return new string(content);
        }
    }
}