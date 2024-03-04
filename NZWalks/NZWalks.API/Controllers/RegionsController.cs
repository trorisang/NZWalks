using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("Regions")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

      

        [HttpGet]
       public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();

            //return DTO regions
            //var regionsDTO = new List<Models.DTO.Region>();

            //foreach (var Regions in regions)
            //{
            //    regionsDTO.Add(new Models.DTO.Region()
            //    {
            //        Id = Regions.Id,
            //        Code = Regions.Code,
            //        Name = Regions.Name,
            //        Area = Regions.Area,
            //        Lat = Regions.Lat,
            //        Long = Regions.Long,
            //        Population = Regions.Population,
            //    });
            //}

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
        }
    }
}
