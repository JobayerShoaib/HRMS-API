using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setups.Countries.Queries.QRM
{
    public class CountryGetDataListRM
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryNameUC { get; set; }
        public string CountryShortCode { get; set; }
        public bool IsDefault { get; set; }
    }
}
