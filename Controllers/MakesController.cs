using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
  public class MakesController : Controller
  {
    private readonly VegaDbContext context;
    private readonly AutoMapper.IMapper mapper;
    public MakesController(VegaDbContext context, AutoMapper.IMapper mapper)
    {
      this.mapper = mapper;
      this.context = context;

    }

    [HttpGet("/api/makes")]
    public async Task<IEnumerable<MakeResource>> GetMakes()
    {
      var makes = await context.Makes.Include(m => m.Models).ToListAsync();

      return mapper.Map<List<Make>, List<MakeResource>>(makes);
    }
  }
}