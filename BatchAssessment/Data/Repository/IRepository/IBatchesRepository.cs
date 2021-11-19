using BatchAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchAssessment.Data.Repository.IRepository
{
    public interface IBatchesRepository
    {
        ICollection<Batch> GetBatches();

        Batch GetBatch(Guid batchId);
        bool CreateBatch(Batch batchObj);
        bool CheckIfBUExists(string businessUnitName);
        bool CheckAttribute(IEnumerable<Models.Attribute> attributesList);
    }
}
