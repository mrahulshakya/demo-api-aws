using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    public class MemoryDataProvider : IDataProvider
    {
        public List<CountryDetail> Countries => new List<CountryDetail>
              {
              new CountryDetail{
                     name= "Russia",
                        flag= "f/f3/Flag_of_Russia.svg",
                        area= 17075200,
                        population= 146989754
                    },
              new CountryDetail{
                    name= "Canada",
                    flag= "c/cf/Flag_of_Canada.svg",
                    area= 9976140,
                    population= 36624199
              },
              new CountryDetail{
                name= "United States",
                flag= "a/a4/Flag_of_the_United_States.svg",
                area= 9629091,
                population= 324459463
              },
              new CountryDetail{
                name= "China",
                flag= "f/fa/Flag_of_the_People%27s_Republic_of_China.svg",
                area= 9596960,
                population= 1409517397
              }
              };

        public async Task<CountryDetail> Add(CountryDetail detail)
        {
            Countries.Add(detail);
            return await Task.FromResult(detail);
        }

        public async Task<CountryDetail> Get(string code)
        {
            return await Task.FromResult(Countries.FirstOrDefault(x =>
            string.Equals(code, x.code, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task<IList<CountryDetail>> GetAll()
        {
            return await Task.FromResult(Countries);
        }
    }
}