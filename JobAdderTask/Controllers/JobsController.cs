using JobAdderTask.Models;
using JobAdderTask.Services;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace JobAdderTask.Controllers
{
    // api/jobs
    public class JobsController : ApiController
    {
        private JobService _service = new JobService();

        //Get all jobs from job service 
        [ResponseType( typeof( IEnumerable<JobDto> ) )]
        public object GetJobs ( string search, int page = 1, int show = 10 )
        {
            var jobs = _service.GetJobs( search ).ToPagedList( page, show );

            return new JobsPagedList {
                items = jobs.Select( job => new JobDto( job ) ),
                total = jobs.TotalItemCount
            };
        }


    }
}
