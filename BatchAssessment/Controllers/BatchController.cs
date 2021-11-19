using AutoMapper;
using BatchAssessment.Data.Repository.IRepository;
using BatchAssessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private IBatchesRepository _batchRepo;
        private readonly IMapper _mapper;

        public BatchController(IBatchesRepository batchRepo, IMapper mapper)
        {
            _batchRepo = batchRepo;
            _mapper = mapper;
        }


        [HttpGet("batchId:Guid", Name = "GetBatch")]
        public IActionResult GetBatch(Guid batchId)
        {
            var batchObj = _batchRepo.GetBatch(batchId);
            if (batchObj == null)
                return NotFound();

            return Ok(batchObj);
        }

        [HttpPost]
        public IActionResult CreateBatch([FromBody] Batch batch)
        {
            if (batch == null)
                return BadRequest(ModelState);

            if (_batchRepo.CheckIfBUExists(batch.BusinessUnit))
            {
                ModelState.AddModelError("", "Business Unit Exists.");
                return StatusCode(400, ModelState);
            }

            if (_batchRepo.CheckAttribute(batch.Attributes))
            {
                ModelState.AddModelError("", "Business Unit Exists.");
                return StatusCode(400, ModelState);
            }

            if (_batchRepo.CreateBatch(batch))
            {
                return CreatedAtRoute("GetBatch", new { batchId = batch.BatchId }, batch);
            }

            ModelState.AddModelError("", $"Something went wrong while creating Batch {batch}");
            return StatusCode(400, ModelState);

        }

    }
}
