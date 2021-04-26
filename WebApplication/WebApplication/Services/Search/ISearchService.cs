using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Publish;

namespace WebApplication.Services.Search
{
    public interface ISearchService
    {
        public List<SuitableCarModelView> Search(SuitableCarModelView model);
    }
}
