using System.Threading.Tasks;
using vega.Models;

namespace vega.Persistence
{
  public interface IVehicleRepository
  {
    Task<Vehicle> GetVehcile(int id);
  }
}