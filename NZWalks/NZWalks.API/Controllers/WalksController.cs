using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            //Fetch data from db
            var walksDomain = await walkRepository.GetAllAsync();

            //Convert domain walks to DTO Walks
            var walksDTO = mapper.Map<List<Models.DTO.Walk>>(walksDomain);

            //return respond
            return Ok(walksDTO);
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            //GET WALK DOMAIN OBJECT ROM DATABASE
            var walkDomain = await walkRepository.GetAsync(id);

            //convert  domain  object  to dto
            var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);

            //return
            return Ok(walkDTO);
        }

        [HttpPost]
        public async  Task<IActionResult> AddWalkAsync([FromBody] Models.DTO.AddWalkRequest addWalkRequest)
        {
            //CONVERT DTO TO OBJECT
            var walkDomain = new Models.Domain.Walk
            {
                Length = addWalkRequest.Length,
                Name = addWalkRequest.Name,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId
            };

            //PASS DOMAIN OBJECR
            walkDomain = await walkRepository.AddAsync(walkDomain);

            //CONVERT THE DOMAIN OBJECT TO DTO
            var walkDTO = new Models.DTO.Walk
            {
                Id = walkDomain.Id,
                Lenght = walkDomain.Length,
                Name = walkDomain.Name,
                RegionId = walkDomain.RegionId,
                WalkDifficultyId = walkDomain.WalkDifficultyId
            };
            //
            return CreatedAtAction(nameof(GetWalkAsync),new { id = walkDTO.Id}, walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkRequest updateWalkRequest)
        {
            //CONVERT DTO TO DOMAIN OBJECT
            var walkDomain = new Models.Domain.Walk
            {
                Length = updateWalkRequest.Length,
                Name = updateWalkRequest.Name,
                RegionId = updateWalkRequest.RegionId,
                WalkDifficultyId = updateWalkRequest.WalkDifficultyId
            };


            //PASS DETAILS TO REPOSITORY - GET DOMAIN OBJECT IN RESONSE
            walkDomain = await walkRepository.UpdateAsync(id, walkDomain);

            //HANDLE NULL
            if(walkDomain == null)
            {
                return NotFound("This ID was");
            }

                var walkDTO = new Models.DTO.Walk
                {
                    Id = walkDomain.Id,
                    Lenght = walkDomain.Length,
                    Name = walkDomain.Name,
                    RegionId = walkDomain.RegionId,
                    WalkDifficultyId = walkDomain.WalkDifficultyId
                };
            return Ok(walkDTO);
            //CONVERT
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            var walkDomain = await walkRepository.DeleteAsync(id);
            if(walkDomain == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);

            return Ok(walkDTO);
        }

    }
}
