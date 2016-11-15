using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBeading
{
    public class Repository : IRepository
    {
        private static Repository repository = new Repository();
        private List<CanvasOptionsRequest> responses = new List<CanvasOptionsRequest>();

        public static Repository GetRepository()
        {
            return repository;
        }

        public IEnumerable<CanvasOptionsRequest> GetAllResponses()
        {
            return responses;
        }

        public void AddResponse(CanvasOptionsRequest response)
        {
            responses.Add(response);
        }
    }
}