using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MyEFSample.Fixture
{
    [TestFixture]
    public class CountryFixture
    {
        [Test]
        public void CanCreateAndRetrieveCountry()
        {
            Country c = CreateCountry();
            using (MyContext ctx = GetContext())
            {
                Country c1 = ctx.Countries.First(n => n.Id == c.Id);
                Assert.IsNotNull(c1);
                Assert.That(c1.Name, Is.EqualTo(c.Name));
            }
        }

        private Country CreateCountry()
        {
            using (MyContext ctx = GetContext())
            {
                Country c = new Country
                {
                    Id = Guid.NewGuid(),
                    Name = "country" + Guid.NewGuid().ToString(),
                    Population = 6000000
                };
                ctx.Countries.Add(c);
                ctx.SaveChanges();
                return c;
            }
        }

        [Test]
        public void CanUpdateCountry()
        {
            Country c = CreateCountry();
            using (MyContext ctx = GetContext())
            {
                Country c1 = ctx.Countries.First(n => n.Id == c.Id);
                c1.Name = "new name";
                ctx.SaveChanges();
            }
            using (MyContext ctx = GetContext())
            {
                Country c2 = ctx.Countries.First(n => n.Id == c.Id);
                Assert.That(c2.Name, Is.EqualTo("new name"));
            }
        }

        [Test]
        public void DeliberateInvalidTest()
        {
            Assert.AreEqual(1,2);
        }

        private MyContext GetContext()
        {
            return new MyContext("MyConnection");
        }
    }
}
