using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ESGI.DesignPattern.Projet
{
    public interface IClockService
    {
        DateTime Now();
    }

    public class ClockService : IClockService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }

    public class MockClockService : IClockService
    {
        private DateTime _dateTimeToReturn;

        public MockClockService(DateTime dateTimeToReturn)
        {
            _dateTimeToReturn = dateTimeToReturn;
        }

        public DateTime Now()
        {
            return _dateTimeToReturn;
        }
    }
    
    public interface IBaseMarketingCampaign
    {
        bool IsActive();

        bool IsCrazySalesDay();
    }

    public class MarketingCampaign: IBaseMarketingCampaign
    {
        private IClockService clockService;

        public MarketingCampaign(IClockService clockService) {

            this.clockService = clockService;
        }

        public bool IsActive()
        {
            return (long)clockService.Now().TimeOfDay.TotalMilliseconds % 2 == 0;
        }

        public bool IsCrazySalesDay()
        {
            return clockService.Now().DayOfWeek.Equals(DayOfWeek.Friday);
        }
    }
}
