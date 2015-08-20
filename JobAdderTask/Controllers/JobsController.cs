using JobAdderTask.Models;
using JobAdderTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PagedList;

namespace JobAdderTask.Controllers
{
    // api/jobs
    public class JobsController : ApiController
    {
        private JobService _service = new JobService();

        //Get all jobs from job service 
        public object GetJobs ( int page = 1, int show = 10 )
        {
            var jobs = _service.ReadFile().ToPagedList( page, show );

            return new {
                items = jobs.Select( job => new JobDto( job ) ),
                total = jobs.TotalItemCount
            };
        }

    }
}
