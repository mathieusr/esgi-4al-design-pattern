using System;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {
        [Fact]
        public void Discount()
        {
            var campaign = new MarketingCampaign(new MockClockService(new DateTime(2020, 07, 08)));
            var net = new Money(1002);
            var discount = DiscountFactory.Create(campaign, net);
            
            var total = discount.DiscountFor(net);

            Assert.Equal(new Money(901.8m), total);
        }
    }
}

