using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsParser
{
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Security.Policy;
    using System.Text.RegularExpressions;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    class Program
    {
        static void Main(string[] args)
        {

                  
            var sUrl = "http://blsbg.eu/bg/medics/unionlist/";
            const string mainUrl = "http://blsbg.eu/bg/";

            var regions = GetRegions(mainUrl);
            var doctors = new ConcurrentBag<Doctor>();

            var timer = new Stopwatch();
            timer.Start();

            Parallel.ForEach(regions, region =>
            {
                GetDoctors(sUrl, region.Key, region.Value, doctors);
            });

            timer.Stop();
            var time = timer.ElapsedMilliseconds/1000;

            ExportDoctorsToXls(doctors.OrderBy(d => d.RegionName).ThenBy(d=>d.Name).ToList());
        }

        
        private static void GetDoctors(string sUrl, short regionCode, string regionName, ConcurrentBag<Doctor> doctors)
        {
            var responseStr = GetWebResponseStr(sUrl + regionCode);
            var pagesCount = GetPagesCount(responseStr);
            var docs = new ConcurrentBag<Doctor>();

            Parallel.For(1, pagesCount, i =>
            {
                responseStr = GetWebResponseStr(sUrl + regionCode + "?UIN_page=" + i);

                var doctorsPatter = "<td class=\"col-md-1\"\\s+style=\"min-width:48px;\">(.*?)</td><td class=\"col-md-6\"\\s*>(.*?)</td>";
                var matches = Regex.Matches(responseStr.Result, doctorsPatter);

                foreach (Match match in matches)
                {
                    if (match.Success && match.Groups.Count > 2)
                    {
                        var doctorImgTag = match.Groups[1].Value;
                        var doc = ParseDoctorFromImgTag(doctorImgTag, regionName);
                        var docName = match.Groups[2].Value.Trim();

                        if (doc != null)
                        {
                            doc.FullName = docName;
                            docs.Add(doc);
                        }
                    }
                }
            });

            foreach (var doctor in docs)
            {
                doctors.Add(doctor);
            }

            Console.WriteLine("Doctor count:  " + doctors.Count);
        }

        private static Doctor ParseDoctorFromImgTag(string doctorImgTag, string regionName)
        {
            var uinPattern = "id\\s*=\\s*[\"'](\\d+?)[\"']";
            var telPattern = "tel\\s*=\\s*[\"'](.*?)[\"']";
            var specPattern = "spec\\s*=\\s*[\"'](.*?)[\"']";
            var addressAtributePattern = "adr\\s*=\\s*[\"'](.*?)[\"']";
            var workPlacePattern = "wrk\\s*=\\s*[\"'](.*?)[\"']";

            string uin = string.Empty, tel = string.Empty, speciality = string.Empty, workPlace = string.Empty;

            // Get uin
            var match = Regex.Match(doctorImgTag, uinPattern);
            if (match.Success && match.Groups.Count > 1)
            {
                uin = match.Groups[1].Value.Trim();
            }

            //Get tel
            match = Regex.Match(doctorImgTag, telPattern);
            if (match.Success && match.Groups.Count > 1)
            {
                tel = match.Groups[1].Value.Trim();
            }

            //Get speciality
            match = Regex.Match(doctorImgTag, specPattern);
            if (match.Success && match.Groups.Count > 1)
            {
                speciality = match.Groups[1].Value.Trim();
            }

            //Get work place
            match = Regex.Match(doctorImgTag, workPlacePattern);
            if (match.Success && match.Groups.Count > 1)
            {
                workPlace = match.Groups[1].Value.Trim().Replace(@"\&quot;", "'");
            }

            //Get address
            string addressAtribute = string.Empty;
            match = Regex.Match(doctorImgTag, addressAtributePattern);
            if (match.Success && match.Groups.Count > 1)
            {
                addressAtribute = match.Groups[0].Value.Trim().Replace(@"\&quot;", "'");
            }

            var cityPattern = ",\\s+гр.\\s*(.*?),\\s+";
            var villagePattern = "\\s*с.\\s+(.*?),\\s+";
            var districtPattern = ",\\s+общ.\\s*(.*?),\\s+";
            var postCodePattern = ",\\s+пк:\\s*(.*?),\\s+";
            var addressPattern = ",\\s+(п.к.|пк:)\\s+[\\d]+,\\s+(.*?),\\s+";

            string city = string.Empty, village = string.Empty, district = string.Empty, postCode = string.Empty, address = string.Empty;

            match = Regex.Match(addressAtribute, cityPattern);
            if (match.Success && match.Groups.Count > 1)
            {
                city = match.Groups[1].Value.Trim();
            }

            match = Regex.Match(addressAtribute, villagePattern);
            if (match.Success && match.Groups.Count > 1)
            {
                village = match.Groups[1].Value.Trim();
            }

            match = Regex.Match(addressAtribute, districtPattern);
            if (match.Success && match.Groups.Count > 1)
            {
                district = match.Groups[1].Value.Trim();
            }

            match = Regex.Match(addressAtribute, postCodePattern);
            if (match.Success && match.Groups.Count > 1)
            {
                postCode = match.Groups[1].Value.Trim();
            }

            match = Regex.Match(addressAtribute, addressPattern);
            if (match.Success && match.Groups.Count > 2)
            {
                address = match.Groups[2].Value.Trim();
            }

            var doc = new Doctor()
            {
                Uin = uin,
                Speciality = speciality,
                Telephone = tel,
                WorkPlace =  workPlace,
                RegionName = regionName,
                City = city,
                Village = village,
                District = district,
                PostCode = postCode,
                Address = address
            };

            return doc;
        }

        private static int GetPagesCount(Task<string> responseStr)
        {
            var pattern = "<div\\s+class\\s*=\\s*[\"']summary[\"']\\s*>(.*?)<\\s*/div\\s*>";
            var match = Regex.Match(responseStr.Result, pattern);
            var count = 0;

            if (match.Success && match.Groups.Count > 1)
            {
                var numPattern = "(\\d+)(?!.*\\d)";
                var numMatch = Regex.Match(match.Groups[1].Value, numPattern).Groups[1].Value;          
                int.TryParse(numMatch, out count);
            }

            return (int) Math.Ceiling(count / 25.0);
        }

        private static IDictionary<short, string> GetRegions(string mainUrl)
        {
            var regions = new Dictionary<short, string>();

            const string regionMatchStr =
                "<ul\\s+class\\s*=\\s*[\"']dropdown\\s*-\\s*menu[\"']\\s*>\\s*<li><a\\s*href\\s*=\\s*[\"']/bg/site/County_councils[\"']\\s*>Колегии</a></li>(?s)(.*?)<li><span></span></li>";
            const string separateRegionMatchStr =
                "<\\s*li\\s*><\\s*a\\s*href\\s*=\\s*[\"']/bg/medics/unionlist/\\s*(\\d+)[\"']\\s*>.*-\\s+(.+?)<\\s*/a\\s*><\\s*/li\\s*>";

            var responseString = GetWebResponseStr(mainUrl);

            var matches = Regex.Matches(responseString.Result, regionMatchStr);

            foreach (Match match in matches)
            {
                if (match.Success && match.Groups.Count >= 2)
                {
                    var innerResult = match.Groups[1].Value;

                    var innerMatches = Regex.Matches(innerResult, separateRegionMatchStr);

                    foreach (Match innerMatch in innerMatches)
                    {
                        if (innerMatch.Success && innerMatch.Groups.Count > 2)
                        {
                            short regionCode;
                            short.TryParse(innerMatch.Groups[1].Value, out regionCode);
                            var regionName = innerMatch.Groups[2].Value;

                            if (regionCode != default(short) && !regions.ContainsKey(regionCode))
                            {
                                regions[regionCode] = regionName;
                            }
                        }
                    }
                }
            }

            return regions;
        }

        private static async Task<string> GetWebResponseStr(string url)
        {
            var responseString = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Getting web response from URI:  " + url);

                try
                {
                    var webRequest = (HttpWebRequest)WebRequest.Create(url);
                    var response =
                        (HttpWebResponse)
                            await
                                Task.Factory.FromAsync<WebResponse>(webRequest.BeginGetResponse, webRequest.EndGetResponse,
                                    null);
                    responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Web response from URI:  " + url + "  failed");
                }
            }

            return responseString;

        }




        private static void ExportDoctorsToXls(List<Doctor> doctors)
        {
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var fullExcelFilePath = projectPath + Path.DirectorySeparatorChar + "Doctors.xlsx";

            try
            {
                var file = new FileStream(fullExcelFilePath, FileMode.Create);
                var stream = PrepareXlsFile(doctors, file);

                file.Flush();
                file.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("File is not accessible. May be it is open.");
            }
        }

        private static object PrepareXlsFile(IList<Doctor> doctors, Stream fileStream)
        {
            using (var excelPackage = new ExcelPackage(fileStream ?? new MemoryStream()))
            {
                excelPackage.Workbook.Properties.Author = "Radko";
                excelPackage.Workbook.Properties.Title = "Doctors list";
                excelPackage.Workbook.Worksheets.Add("Docotors list");

                var worksheet = excelPackage.Workbook.Worksheets[1];

                worksheet.Cells[1, 1].LoadFromCollection(doctors, true);

                //Setup colors
                var collsCount = doctors.First().GetType().GetProperties().Length;

                using (var range = worksheet.Cells[1, 1, 1, collsCount])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Green);
                }

                //End setup colors

                excelPackage.Save();

                return excelPackage.Stream;
            }
        }
    }

    class Doctor
    {
        private string _fullName;

        public string Uin { get; set; }

        public string Name { get; set; }

        public string Degree { get; set; }

        public string FullName
        {
            get { return this._fullName; }

            set
            {
                var match = Regex.Match(value, "^\\s*(.*?)\\s+(.*)$");

                if (match.Success && match.Groups.Count > 2)
                {
                    this.Degree = match.Groups[1].Value.Trim();
                    this.Name = match.Groups[2].Value.Trim();
                }

                this._fullName = value;
            }
        }

        public string Speciality { get; set; }

        public string Telephone { get; set; }

        public string WorkPlace { get; set; }

        public string RegionName { get; set; }

        public string City { get; set; }

        public string Village { get; set; }

        public string District { get; set; }

        public string PostCode { get; set; }

        public string Address { get; set; }      
    }
}
