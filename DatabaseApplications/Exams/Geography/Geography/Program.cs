namespace Geography
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            //1.ListContinentNames
            //var continents = context.Continents
            //    .Select(c => c.ContinentName);

            //foreach (var continentName in continents)
            //{
            //    Console.WriteLine(continentName);
            //}

            //2.ExportRiversAsJSON
            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    riverName = r.RiverName,
                    riverLength = r.Length,
                    countries = r.Countries
                        .OrderBy(c => c.CountryName)
                        .Select(c => c.CountryName)
                });

            string json = JsonConvert.SerializeObject(rivers, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("../../rivers.json", json);

            //3.ExportMonasteriesByCountryAsXML
            //var countriesMonasteries = context.Countries
            //    .OrderBy(c => c.CountryName)
            //    .Select(c => new
            //    {
            //        Name = c.CountryName,
            //        Monasteries = c.Monasteries
            //            .OrderBy(m => m.Name)
            //            .Select(m => m.Name)
            //    });

            //var settings = new XmlWriterSettings()
            //{
            //    Indent = true,
            //    NewLineChars = "\n"
            //};

            //using (XmlWriter writer = XmlWriter.Create("../../monasteries.xml", settings))
            //{
            //    writer.WriteStartDocument();
            //    writer.WriteStartElement("monasteries");

            //    foreach (var country in countriesMonasteries)
            //    {
            //        if (country.Monasteries.Any())
            //        {
            //            writer.WriteStartElement("country");
            //            writer.WriteAttributeString("name", country.Name);

            //            foreach (var monastery in country.Monasteries)
            //            {
            //                writer.WriteStartElement("monastery");
            //                writer.WriteString(monastery);
            //                writer.WriteEndElement();
            //            }

            //            writer.WriteEndElement();
            //        }
            //    }

            //    writer.WriteEndElement();
            //    writer.WriteEndDocument();
            //}

            //4.ImportRiversFromXml
            //var xmlDocument = XDocument.Load("../../rivers.xml");
            //var rivers =
            //    from river in xmlDocument.Descendants("river")
            //    select new
            //    {
            //        Name = river.Element("name") == null ? null : river.Element("name").Value,
            //        Length = river.Element("length") == null ? null : river.Element("length").Value,
            //        Outflow = river.Element("outflow") == null ? null : river.Element("outflow").Value,
            //        DrainageArea = river.Element("drainage-area") == null ? null : river.Element("drainage-area").Value,
            //        AverageDischarge = river.Element("average-discharge") == null ? null : river.Element("average-discharge").Value,
            //        Countries = river.Element("countries") == null ? null : 
            //            from country in river.Descendants("country")
            //            select new
            //            {
            //                Name = country.Value
            //            }
            //    };

            //foreach (var river in rivers)
            //{
            //    if (river.Name == null)
            //    {
            //        ShowError("name");

            //        continue;
            //    }
                
            //    if (river.Length == null)
            //    {
            //        ShowError("length");

            //        continue;
            //    }

            //    if (river.Outflow == null)
            //    {
            //        ShowError("outflow");

            //        continue;
            //    }

            //    if (!context.Rivers.Any(r => r.RiverName == river.Name))
            //    {
            //        if (river.DrainageArea != null && river.AverageDischarge != null)
            //        {
            //            context.Rivers.Add(new River()
            //            {
            //                RiverName = river.Name,
            //                Length = int.Parse(river.Length),
            //                DrainageArea = int.Parse(river.DrainageArea),
            //                AverageDischarge = int.Parse(river.AverageDischarge),
            //                Outflow = river.Outflow
            //            });
            //        }
            //        else if (river.DrainageArea != null && river.AverageDischarge == null)
            //        {
            //            context.Rivers.Add(new River()
            //            {
            //                RiverName = river.Name,
            //                Length = int.Parse(river.Length),
            //                DrainageArea = int.Parse(river.DrainageArea),
            //                AverageDischarge = null,
            //                Outflow = river.Outflow
            //            });
            //        }
            //        else if (river.DrainageArea == null && river.AverageDischarge != null)
            //        {
            //            context.Rivers.Add(new River()
            //            {
            //                RiverName = river.Name,
            //                Length = int.Parse(river.Length),
            //                DrainageArea = null,
            //                AverageDischarge = int.Parse(river.AverageDischarge),
            //                Outflow = river.Outflow
            //            });
            //        }
            //        else
            //        {
            //            context.Rivers.Add(new River()
            //            {
            //                RiverName = river.Name,
            //                Length = int.Parse(river.Length),
            //                DrainageArea = null,
            //                AverageDischarge = null,
            //                Outflow = river.Outflow
            //            });
            //        }
            //    }

            //    context.SaveChanges();

            //    var currentRiver = context.Rivers.Where(r => r.RiverName == river.Name).FirstOrDefault();

            //    foreach (var country in river.Countries)
            //    {
            //        if (country == null)
            //        {
            //            ShowError("country");

            //            continue;
            //        }

            //        var currentCountry = context.Countries.Where(c => c.CountryName == country.Name).FirstOrDefault();

            //        currentCountry.Rivers.Add(currentRiver);
            //    }
            //}

            //context.SaveChanges();      
        }

        //static void ShowError(string missingElementName)
        //{
        //    throw new InvalidOperationException(string.Format("River {0} is missing!", missingElementName));
        //}
    }
}
