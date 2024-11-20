using CsvHelper.Configuration;
using Leyadech.Core.Entities;

namespace Leyadech.Data.Mapping
{
    public class MotherMap:ClassMap<Mother>
    {
        public MotherMap()
        {
            Map(mother => mother.Id);
            Map(mother => mother.FirstName);
            Map(mother => mother.LastName);
            Map(mother => mother.Address);
            Map(mother => mother.Email);
            Map(mother => mother.PhoneNumber);
            Map(mother => mother.BirthDate);
            Map(mother => mother.JoinDate);
            Map(mother => mother.Status);
            Map(mother => mother.FamilySize);
            Map(mother => mother.ChildrenBelow7);
            Map(mother => mother.HelpKindNeeded);
            Map(mother => mother.SpecialRequests).TypeConverter<ListToStringConverter>();
            Map(mother => mother.IsStandingOrder);
            
        }
    }
}
