using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBeading
{
    public interface IRepository
    {
        IEnumerable<CanvasOptionsRequest> GetAllResponses();
        void AddResponse(CanvasOptionsRequest response);
    }
}
