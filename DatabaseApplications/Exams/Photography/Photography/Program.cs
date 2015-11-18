namespace Photography
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
            var context = new PhotographySystemEntities();

            //1.ListManufacturerModel
            //var cameras = context.Cameras
            //    .OrderBy(c => c.Manufacturer.Name + " " + c.Model)
            //    .Select(c => c.Manufacturer.Name + " " + c.Model);

            //foreach (var camera in cameras)
            //{
            //    Console.WriteLine(camera);
            //}

            //2.ExportManufacturerAndCameraAsJSON
            //var manufacturers = context.Manufacturers
            //    .OrderBy(m => m.Name)
            //    .Select(m => new
            //    {
            //        manufacturer = m.Name,
            //        cameras = m.Cameras
            //            .OrderBy(c => c.Model)
            //            .Select(c => new 
            //            {
            //                c.Model,
            //                c.Price
            //            })
            //    });

            //string json = JsonConvert.SerializeObject(manufacturers, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("../../manufacturers-and-cameras.json", json);

            //3.ExportPhotographsAsXML
            //var photographs = context.Photographs
            //    .OrderBy(p => p.Title)
            //    .Select(p => new
            //    {
            //        p.Title ,
            //        CategoryName = p.Category.Name,
            //        p.Link,
            //        CameraMegapixels = p.Equipment.Camera.Megapixels,
            //        Camera = p.Equipment.Camera.Manufacturer.Name + " " + p.Equipment.Camera.Model,
            //        Lens = p.Equipment.Lens.Model,
            //        LensPrice = p.Equipment.Lens.Price
            //    });

            //var settings = new XmlWriterSettings()
            //{
            //    Indent = true,
            //    NewLineChars = "\n"
            //};

            //using (var writer = XmlWriter.Create("../../photographs.xml", settings))
            //{
            //    writer.WriteStartDocument();
            //    writer.WriteStartElement("photographs");

            //    foreach (var photograph in photographs)
            //    {
            //        writer.WriteStartElement("photograph");
            //        writer.WriteAttributeString("title", photograph.Title);
            //        writer.WriteStartElement("category");
            //        writer.WriteString(photograph.CategoryName);
            //        writer.WriteEndElement();
            //        writer.WriteStartElement("link");
            //        writer.WriteString(photograph.Link);
            //        writer.WriteEndElement();
            //        writer.WriteStartElement("equipment");
            //        writer.WriteStartElement("camera");
            //        writer.WriteAttributeString("megapixels", photograph.CameraMegapixels.ToString());
            //        writer.WriteString(photograph.Camera);
            //        writer.WriteEndElement();
            //        writer.WriteStartElement("lens");

            //        if (photograph.LensPrice != null)
            //        {
            //            writer.WriteAttributeString("price", Math.Round((decimal)photograph.LensPrice, 2).ToString());
            //        }

            //        writer.WriteString(photograph.Lens);
            //        writer.WriteEndElement();
            //        writer.WriteEndElement();
            //        writer.WriteEndElement();
            //    }

            //    writer.WriteEndElement();
            //    writer.WriteEndDocument();
            //}

            //4.ImportManufacturerAndLensesFromXML
            var xmlDocument = XDocument.Load("../../manufacturers-and-lenses.xml");
            var manufacturers =
                from manufacturer in xmlDocument.Descendants("manufacturer")
                select new
                {
                    Name = manufacturer.Element("manufacturer-name").Value,
                    Lenses = manufacturer.Element("lenses") == null ? null :
                        from lens in manufacturer.Descendants("lens")
                        select new
                        {
                            Model = lens.Attribute("model").Value,
                            Type = lens.Attribute("type").Value,
                            Price = lens.Attribute("price") == null ? null : lens.Attribute("price").Value
                        }
                };
            int manufacturerNumber = 1;

            foreach (var manufacturer in manufacturers)
            {
                Console.WriteLine("Prcessing manufacturer #{0}", manufacturerNumber);

                if (!context.Manufacturers.Any(m => m.Name == manufacturer.Name))
                {
                    context.Manufacturers.Add(new Manufacturer()
                    {
                        Name = manufacturer.Name
                    });
                    Console.WriteLine("Created manufacturer: {0}", manufacturer.Name);
                }
                else
                {
                    Console.WriteLine("Existing manufacturer: {0}", manufacturer.Name);
                }

                context.SaveChanges();

                foreach (var lens in manufacturer.Lenses)
                {
                    if (!context.Lenses.Any(l => l.Model == lens.Model))
                    {
                        if (lens.Price != null)
	                    {
                            context.Lenses.Add(new Lens()
                            {
                                Model = lens.Model,
                                Type = lens.Type,
                                Price = decimal.Parse(lens.Price),
                                ManufacturerId = context.Manufacturers.Where(m => m.Name == manufacturer.Name).FirstOrDefault().Id
                            });
                        }
                        else
                        {
                            context.Lenses.Add(new Lens()
                            {
                                Model = lens.Model,
                                Type = lens.Type,
                                Price = null,
                                ManufacturerId = context.Manufacturers.Where(m => m.Name == manufacturer.Name).FirstOrDefault().Id
                            });
                        }

                        Console.WriteLine("Created lens: {0}", lens.Model);
                    }
                    else
                    {
                        Console.WriteLine("Existing lens: {0}", lens.Model);
                    }
                }

                manufacturerNumber++;
            }

            context.SaveChanges();
        }
    }
}
