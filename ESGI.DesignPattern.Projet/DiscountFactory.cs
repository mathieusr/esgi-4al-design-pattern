using System;

namespace ESGI.DesignPattern.Projet
{

    public class DiscountFactory {

        public static IDiscount Create(MarketingCampaign marketing, Money money){

            DiscountFactoryCondition[] conditions = {
                new CrasySalesDay(),
                new OneThousand(),
                new OneHundredAndActive()
            };

            Array.Reverse(conditions);

            Func<MarketingCampaign, Money, IDiscount> toCall = (campaign, money) => new NoDiscount();

            foreach(DiscountFactoryCondition condition in conditions){

                var temp = toCall;
                
                toCall = (campaign, money) => condition.check(campaign, money, temp);
            }

            return toCall(marketing, money);
        }
    }

    public interface DiscountFactoryCondition {

        IDiscount check(MarketingCampaign marketingCampaign, Money money, Func<MarketingCampaign, Money, IDiscount> next);
    }

    public class CrasySalesDay : DiscountFactoryCondition {

        public IDiscount check(MarketingCampaign marketingCampaign, Money money, Func<MarketingCampaign, Money, IDiscount> next){

            if (marketingCampaign.IsCrazySalesDay())
            {
                return new Discount15();
            }

            return next(marketingCampaign, money);
        }
    }

    public class OneThousand : DiscountFactoryCondition {

        public IDiscount check(MarketingCampaign marketingCampaign, Money money, Func<MarketingCampaign, Money, IDiscount> next){

            if (money.MoreThan(Money.OneThousand))
            {
                return new Discount10();
            }

            return next(marketingCampaign, money);
        }
    }

    public class OneHundredAndActive : DiscountFactoryCondition {

        public IDiscount check(MarketingCampaign marketingCampaign, Money money, Func<MarketingCampaign, Money, IDiscount> next){

            if (money.MoreThan(Money.OneHundred) && marketingCampaign.IsActive())
            {
                return new Discount5();
            }

            return next(marketingCampaign, money);
        }
    }
}