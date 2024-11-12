using CsvHelper;
using CsvHelper.Configuration;
using leyadech.server.DTO;
using Microsoft.Extensions.Logging;
using System.Formats.Asn1;
using System.Globalization;

namespace leyadech.server.Service
{
    public class DataContext : IDataContext
    {
       

        readonly DataPathes _path;

        public DataContext(DataPathes path)
        {
            _path = path;
        }

        public List<Mother> MotherData { get; set; }
        public List<Volunteer> VolunteerData { get; set; }
        public List<HelpRequest> RequestData { get ; set; }
        public List<HelpSuggest> SuggestData { get; set ; }
        public List<Volunteering> VolunteeringData { get; set; }

        public bool LoadMotherData()
        {
            try
            {
                using (var reader = new StreamReader(_path.MotherPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    MotherData = csv.GetRecords<Mother>().ToList();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadRequestData()
        {
            try
            {
                using (var reader = new StreamReader(_path.RequestPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    RequestData = csv.GetRecords<HelpRequest>().ToList();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadSuggestData()
        {
            try
            {
                using (var reader = new StreamReader(_path.SuggestPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    SuggestData= csv.GetRecords<HelpSuggest>().ToList();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadVolunteerData()
        {
            try
            {
                using (var reader = new StreamReader(_path.VolunteerPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    VolunteerData = csv.GetRecords<Volunteer>().ToList();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadVolunteeringData()
        {
            try
            {
                using (var reader = new StreamReader(_path.VolunteeringPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    VolunteeringData = csv.GetRecords<Volunteering>().ToList();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveMotherData()
        {
            try
            {
                if (File.Exists(_path.MotherPath))
                    File.Delete(_path.MotherPath);
                using (var writer = new StreamWriter(_path.MotherPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(MotherData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

       

        public bool SaveRequestData()
        {
            try
            {
                if (File.Exists(_path.RequestPath))
                    File.Delete(_path.RequestPath);
                using (var writer = new StreamWriter(_path.RequestPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(RequestData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    

        public bool SaveSuggestData()
        {
            try
            {
                if (File.Exists(_path.SuggestPath))
                    File.Delete(_path.SuggestPath);
                using (var writer = new StreamWriter(_path.SuggestPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(SuggestData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

       
        public bool SaveVolunteerData()
        {
            try
            {
                if (File.Exists(_path.VolunteerPath))
                    File.Delete(_path.VolunteerPath);
                using (var writer = new StreamWriter(_path.VolunteerPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(VolunteerData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveVolunteeringData()
        {
            try
            {
                if (File.Exists(_path.VolunteeringPath))
                    File.Delete(_path.VolunteeringPath);
                using (var writer = new StreamWriter(_path.VolunteeringPath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(VolunteeringData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

     

        public class DataPathes
        {
            public string MotherPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "mother_data.csv");
            public string VolunteerPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "volunteer_data.csv");
            public string RequestPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "request_data.csv");
            public string SuggestPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "suggest_data.csv");
            public string VolunteeringPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "Data", "volunteering_data.csv");
        }
    }
}
