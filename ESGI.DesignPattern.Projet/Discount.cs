using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESGI.DesignPattern.Projet
{
    public interface IDiscount {

        Money DiscountFor(Money netprice);
    }

    public class Discount15: IDiscount
    {

        public Money DiscountFor(Money netPrice)
        {
            return netPrice.ReduceBy(15);
        }
    }

    public class Discount10: IDiscount
    {

        public Money DiscountFor(Money netPrice)
        {
            return netPrice.ReduceBy(10);
        }
    }

    public class Discount5: IDiscount
    {

        public Money DiscountFor(Money netPrice)
        {
            return netPrice.ReduceBy(5);
        }
    }

    public class NoDiscount: IDiscount
    {

        public Money DiscountFor(Money netPrice)
        {
            return netPrice;
        }
    }
}
