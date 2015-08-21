using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderTask.Models
{
    //Flat object for REST API Transfer
    public class JobDto
    {
        public int Jid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }          //Html

        public string Reference { get; set; }

        public string SearchTitle { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime DateUpdated { get; set; }


        public bool IsNew { get; set; }

        public string Area { get; set; }

        public string Location { get; set; }

        public string Country { get; set; }


        public string Category { get; set; }

        public string SubCategory { get; set; }

        public string WorkType { get; set; }

        public JobDto ( Job item )
        {
            Jid = item.Jid;

            Title = item.Title;

            Description = item.Description;

            Reference = item.Reference;

            SearchTitle = item.SearchTitle;


            DatePosted = item.DatePosted;

            DateUpdated = item.DateUpdated;


            IsNew = item.DatePosted.Date == DateTime.UtcNow.Date;

            Area = item.Classifications.Where( c => c.Name == "Area" ).Select( c => c.Content ).FirstOrDefault();

            Location = item.Classifications.Where( c => c.Name == "Location" ).Select( c => c.Content ).FirstOrDefault();

            Country = item.Classifications.Where( c => c.Name == "Country" ).Select( c => c.Content ).FirstOrDefault();


            Category = item.Classifications.Where( c => c.Name == "Job Category" ).Select( c => c.Content ).FirstOrDefault();

            SubCategory = item.Classifications.Where( c => c.Name == "Sub-Category" ).Select( c => c.Content ).FirstOrDefault();

            WorkType = item.Classifications.Where( c => c.Name == "Work Type" ).Select( c => c.Content ).FirstOrDefault();
        }

        public JobDto ()
        {
        }

    }

    //For transfer
    public class JobsPagedList
    {
        public IEnumerable<JobDto> items { get; set; }
        public int total { get; set; }
    }
}