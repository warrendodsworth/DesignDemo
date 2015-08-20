using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderTask.Models
{
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

        public string Location { get; set; }

        public string Country { get; set; }


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

            Location = item.Classifications.Where( c => c.Name == "Location" ).Select( c => c.Content ).FirstOrDefault();

            Country = item.Classifications.Where( c => c.Name == "Country" ).Select( c => c.Content ).FirstOrDefault();
        }

        public JobDto ()
        {
        }

    }
}