namespace bitwise_enum
{
    using NUnit.Framework;

    [TestFixture]
    public class BitWiseEnumTests
    {
        [Test]
        public void AddingOneValueToPeople()
        {
            var p = new Person { PersonType = PeopleTypes.Dweeb };
            Assert.AreEqual(PeopleTypes.Dweeb, p.PersonType);
        }

        [Test]
        public void AddingOneValueToPeople_TestingHasFlags()
        {
            var p = new Person { PersonType = PeopleTypes.Dweeb };
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Dweeb));
        }

        [Test]
        public void AddingOneValueToPeople_TestingHasFlagsWillFail()
        {
            var p = new Person { PersonType = PeopleTypes.Dweeb };
            Assert.IsFalse(p.PersonType.HasFlag(PeopleTypes.Geek));
        }

        [Test]
        public void AddingTwoValuesToPeople_TestingHasSingleFlag()
        {
            var p = new Person { PersonType = PeopleTypes.Dweeb | PeopleTypes.Geek };
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Geek));
        }

        [Test]
        public void AddingTwoValuesToPeople_TestingHasBothFlags()
        {
            var p = new Person { PersonType = PeopleTypes.Dweeb | PeopleTypes.Geek };
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Dweeb | PeopleTypes.Geek));
        }

        [Test]
        public void AddingTwoValuesToPeople_TestingHasFlagsCanFail()
        {
            var p = new Person { PersonType = PeopleTypes.Dweeb | PeopleTypes.Geek };
            Assert.IsFalse(p.PersonType.HasFlag(PeopleTypes.Dweeb | PeopleTypes.Fanboy));
        }

        [Test]
        public void CanAddValuesAtDifferentTimes()
        {
            var p = new Person();
            //has a default value
            Assert.AreEqual(0, (int) p.PersonType);
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Square));
            //can add a value
            p.PersonType |= PeopleTypes.Nerd;
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Square | PeopleTypes.Nerd));
        }

        [Test]
        public void CanRemoveValuesAtDifferentTimes()
        {
            var p = new Person();
            //has a default value
            Assert.AreEqual(0, (int)p.PersonType);
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Square));
            //can add a value
            p.PersonType |= PeopleTypes.Nerd;
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Square | PeopleTypes.Nerd));
            //can remove a value
            p.PersonType &= ~PeopleTypes.Nerd;
            Assert.IsFalse(p.PersonType.HasFlag(PeopleTypes.Nerd));
        }

        [Test]
        public void CanHaveCompoundEnumValues()
        {
            var p = new Person { PersonType = PeopleTypes.CoolestType };
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.CoolestType));
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Geek));
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Trekkie));
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Geek | PeopleTypes.Trekkie));
        }
        
        /// <summary>
        /// The default value is always present even when not set by object initializer
        /// </summary>
        [Test]
        public void HasDefaultValueWhenSetByObjectInitialiser()
        {
            var p = new Person { PersonType = PeopleTypes.CoolestType };
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Square));
        }

        /// <summary>
        /// The default value is always present even when not set by construction initializer
        /// </summary>
        [Test]
        public void HasDefaultValueWhenConstructed()
        {
            var p = new Person(PeopleTypes.CoolestType);
            Assert.IsTrue(p.PersonType.HasFlag(PeopleTypes.Square));
        }

        [Test]
        public void CanSkipItems()
        {
            //first four but skip geek
            const PeopleTypes People = PeopleTypes.Dweeb | PeopleTypes.Nerd | PeopleTypes.Fanboy;
            Assert.IsFalse(People.HasFlag(PeopleTypes.Geek));
        }
        [Test]
        public void CanSkipItemsWhenAsAProperty()
        {
            //first four but skip geek
            var person = new Person { PersonType = PeopleTypes.Dweeb | PeopleTypes.Nerd | PeopleTypes.Fanboy };
            Assert.IsFalse(person.PersonType.HasFlag(PeopleTypes.Geek));
        }


    }
}