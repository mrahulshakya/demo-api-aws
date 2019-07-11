using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    public interface IDataProvider
    {
        Task<IList<CountryDetail>> GetAll();

        Task<CountryDetail> Get(string code);

        Task<CountryDetail> Add(CountryDetail detail);
    }
}