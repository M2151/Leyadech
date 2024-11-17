using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using Newtonsoft.Json;

public class ListToJsonConverter : DefaultTypeConverter
{
    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        return JsonConvert.SerializeObject(value);
    }

    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        return JsonConvert.DeserializeObject<List<string>>(text) ?? new List<string>();
    }
}
