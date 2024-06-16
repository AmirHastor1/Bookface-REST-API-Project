using Bookface.Models;
using Bookface.Models.Enums;

namespace Bookface.Interfaces
{
    public interface IStatistikaService
    {
        int DajBrojKorisnika();
        int DajBrojModeratora();
        int DajBrojAdministratora();
    }
}
