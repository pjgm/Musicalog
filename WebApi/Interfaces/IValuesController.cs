using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Interfaces
{
    public interface IValuesController
    {
        ActionResult<IEnumerable<string>> Get();
        ActionResult<string> Get(int id);
        void Post(string value);
        void Put(int id, string value);
        void Delete(int id);
    }
}
