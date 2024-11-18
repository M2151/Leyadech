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
        public List<Mother> MotherData { get; set; }
        public List<Volunteer> VolunteerData { get; set; }
        public List<HelpRequest> RequestData { get; set; }
        public List<HelpSuggest> SuggestData { get; set; }
        public List<Volunteering> VolunteeringData { get; set; }
        public DataContext(DataPathes path)
        {
            _path = path;
            if (!File.Exists(_path.MotherPath))
                File.Create(_path.MotherPath).Close();
            if (!File.Exists(_path.VolunteerPath))
                File.Create(_path.VolunteerPath).Close();
            if (!File.Exists(_path.RequestPath))
                File.Create(_path.RequestPath).Close();
            if (!File.Exists(_path.SuggestPath))
                File.Create(_path.SuggestPath).Close();
            if (!File.Exists(_path.VolunteeringPath))
                File.Create(_path.VolunteeringPath).Close();
        }

        public bool LoadMotherData()
        {

            try
            {
                if (new FileInfo(_path.MotherPath).Length > 0)
                {
                    using (var reader = new StreamReader(_path.MotherPath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<MotherMap>();
                        MotherData = csv.GetRecords<Mother>().ToList();
                    }
                }
                else
                    MotherData = new List<Mother>();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Mother data: {ex.Message}");
                return false;
            }
        }

        public bool LoadRequestData()
        {
            try
            {
                if (new FileInfo(_path.MotherPath).Length > 0)
                {
                    using (var reader = new StreamReader(_path.RequestPath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<RequestMap>();
                        RequestData = csv.GetRecords<HelpRequest>().ToList();
                    }
                }
                else
                    RequestData = new List<HelpRequest>();
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
                if (new FileInfo(_path.MotherPath).Length > 0)
                {
                    using (var reader = new StreamReader(_path.SuggestPath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        SuggestData = csv.GetRecords<HelpSuggest>().ToList();
                    }
                }
                else
                    SuggestData=new List<HelpSuggest>();
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
                if (new FileInfo(_path.MotherPath).Length > 0)
                {
                    using (var reader = new StreamReader(_path.VolunteerPath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        VolunteerData = csv.GetRecords<Volunteer>().ToList();
                    }
                }
                else
                    VolunteerData=new List<Volunteer>();
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
                if (new FileInfo(_path.MotherPath).Length > 0)
                {
                    using (var reader = new StreamReader(_path.VolunteeringPath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        VolunteeringData = csv.GetRecords<Volunteering>().ToList();
                    }
                }
                else
                {
                    VolunteeringData=new List<Volunteering>();
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
                    csv.Context.RegisterClassMap<MotherMap>();
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
                    csv.Context.RegisterClassMap<RequestMap>();
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
            public string MotherPath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Data", "mother_data.csv");
            public string VolunteerPath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Data", "volunteer_data.csv");
            public string RequestPath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Data", "request_data.csv");
            public string SuggestPath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Data", "suggest_data.csv");
            public string VolunteeringPath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Data", "volunteering_data.csv");
        }
    }
}
