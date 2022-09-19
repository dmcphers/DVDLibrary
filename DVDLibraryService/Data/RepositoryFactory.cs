using DVDLibraryService.Data.Interfaces;
using DVDLibraryService.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DVDLibraryService.Data
{
    public class RepositoryFactory
    {
        public static IDVDRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new DVDRepositoryMock();

                case "EntityFramework":
                    return new DVDRepositoryEF();

                //case "ADO":
                //    return new DVDRepositoryADO();

                default:
                    throw new Exception("Mode in web config is not valid");

            }
        }
    }
}