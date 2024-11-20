using CsvHelper;
using CsvHelper.Configuration;
using Leyadech.Core.Entities;
using Leyadech.Data.Mapping;
using System.Formats.Asn1;
using System.Globalization;

namespace Leyadech.Data
{
    public class DataContext 
    {
        private readonly DataPathes _path;
        public List<Mother> MotherData { get; set; }
        public List<Volunteer> VolunteerData { get; set; }
        public List<Request> RequestData { get; set; }
        public List<Suggest> SuggestData { get; set; }
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
            LoadMotherData();
            LoadRequestData();
            LoadSuggestData();
            LoadVolunteeringData();
            LoadVolunteerData();
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
                        RequestData = csv.GetRecords<Request>().ToList();
                    }
                }
                else
                    RequestData = new List<Request>();
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
                        SuggestData = csv.GetRecords<Suggest>().ToList();
                    }
                }
                else
                    SuggestData=new List<Suggest>();
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
            private readonly string _basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Leyadech.Data", "Data");
            public string MotherPath { get; set; }
            public string VolunteerPath { get; set; } 
            public string RequestPath { get; set; }
            public string SuggestPath { get; set; } 
            public string VolunteeringPath { get; set; }
            public DataPathes() 
            {
                MotherPath = Path.Combine(_basePath, "mother_data.csv");
                RequestPath = Path.Combine(_basePath, "request_data.csv");
                SuggestPath = Path.Combine(_basePath, "suggest_data.csv");
                VolunteerPath = Path.Combine(_basePath, "volunteer_data.csv");
                VolunteeringPath = Path.Combine(_basePath, "volunteering_data.csv");
            }
        }
    }
}
