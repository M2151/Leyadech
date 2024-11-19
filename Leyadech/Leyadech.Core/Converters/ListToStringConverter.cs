using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Collections.Generic;
using System.Linq;

public class ListToStringConverter : DefaultTypeConverter
{
    private const string Separator = ";"; // Change to your preferred delimiter

    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        var list = value as List<string>;
        return list != null ? string.Join(Separator, list) : string.Empty;
    }

    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        return string.IsNullOrWhiteSpace(text)
            ? new List<string>()
            : text.Split(Separator).ToList();
    }
}
