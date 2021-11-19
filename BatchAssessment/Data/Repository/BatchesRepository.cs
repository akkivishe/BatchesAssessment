using BatchAssessment.Data.Repository.IRepository;
using BatchAssessment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchAssessment.Data.Repository
{
    public class BatchesRepository : IBatchesRepository
    {
        private readonly ApplicationDbContext _db;

        public BatchesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CheckAttribute(IEnumerable<Models.Attribute> attributes)
        {
            if (attributes.Count() > 0)
            {
                foreach (var item in attributes)
                {
                    if (string.IsNullOrEmpty(item.Key) || string.IsNullOrEmpty(item.Value))
                        return false;
                }
            }
            return true;

        }

        public bool CheckIfBUExists(string businessUnit)

        {
            if (string.IsNullOrEmpty(businessUnit))
                return false;
            return _db.Batches.Any(bu => bu.BusinessUnit.ToLower().Trim() == businessUnit.ToLower().Trim());
        }

        public bool CreateBatch(Batch batchObj)
        {
            _db.Batches.Add(batchObj);
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public Batch GetBatch(Guid batchId)
        {
            return _db.Batches.Include(b => b.Attributes).ToList().FirstOrDefault(b => b.BatchId == batchId);
        }

        public ICollection<Batch> GetBatches()
        {
            throw new NotImplementedException();
        }
    }
}
