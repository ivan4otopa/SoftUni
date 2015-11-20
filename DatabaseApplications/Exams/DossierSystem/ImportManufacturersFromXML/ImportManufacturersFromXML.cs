namespace ImportManufacturersFromXML
{
    using System;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Xml.Linq;

    using EntityFrameworkMappings;
    
    class ImportManufacturersFromXML
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();
            var xmlDocument = XDocument.Load("../../manufacturers-and-goods.xml");
            var manufacturers =
                from manufacturer in xmlDocument.Descendants("manufacturer")
                select new
                {
                    Name = manufacturer.Attribute("name").Value,
                    Cameras =
                        from camera in xmlDocument.Descendants("camera")
                        select new
                        {
                            Model = 
                                camera.Attribute("model") == null ?
                                null : 
                                camera.Attribute("model").Value,
                            Year = 
                                camera.Attribute("year") == null ?
                                null :
                                camera.Attribute("year").Value,
                            Price = 
                                camera.Attribute("price") == null ?
                                (decimal?)null :
                                decimal.Parse(camera.Attribute("price").Value),
                            Megapixels =
                                camera.Attribute("megapixels") == null ?
                                (int?)null :
                                int.Parse(camera.Attribute("megapixels").Value)
                        },
                    Lenses =
                        from lens in xmlDocument.Descendants("lens")
                        select new
                        {
                            Model =
                                lens.Attribute("model") == null ?
                                null :
                                lens.Attribute("model").Value,
                            Type =
                                lens.Attribute("type") == null ?
                                null :
                                lens.Attribute("type").Value,
                            Price =
                                lens.Attribute("price") == null ?
                                (decimal?)null :
                                decimal.Parse(lens.Attribute("price").Value)
                        }
                };

            foreach (var manufacturer in manufacturers)
            {
                if (context.Manufacturers.Any(m => m.Name == manufacturer.Name))
                {
                    Console.WriteLine(
                        "Manufacturer {0} already exists.",
                        manufacturer.Name
                    );
                }
                else
                {
                    var newManufacturer = new Manufacturer()
                    {
                        Name = manufacturer.Name
                    };

                    context.Manufacturers.Add(newManufacturer);

                    context.SaveChanges();

                    Console.WriteLine(
                        "Successfully added manufacturer {0}.",
                        manufacturer.Name
                    );

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            int cameraYear = 0;

                            foreach (var camera in manufacturer.Cameras)
                            {
                                if (camera.Year != null)
                                {
                                    cameraYear = int.Parse(camera.Year);
                                }

                                context.Cameras.Add(new Camera()
                                {
                                    Model = camera.Model,
                                    Year = cameraYear,
                                    Price = camera.Price,
                                    Megapixels = camera.Megapixels,
                                    ManufacturerId = newManufacturer.Id
                                });
                            }

                            foreach (var lens in manufacturer.Lenses)
                            {
                                context.Lenses.Add(new Lens()
                                {
                                    Model = lens.Model,
                                    Type = lens.Type,
                                    Price = lens.Price,
                                    ManufacturerId = newManufacturer.Id
                                });
                            }

                            context.SaveChanges();
                            transaction.Commit();
                        }
                        catch (DbEntityValidationException)
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }
        }
    }
}
