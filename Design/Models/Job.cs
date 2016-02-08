using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Job
    {
        public int Jid { get; set; }

        public DateTime DateUpdated { get; set; }

        public DateTime DatePosted { get; set; }

        public string Reference { get; set; }

        public string Title { get; set; }

        //Html
        public string Description { get; set; }

        public string SearchTitle { get; set; }

        public IList<Classification> Classifications { get; set; }
    }


    public class Classification
    {
        public int Id { get; set; }

        public int Jid { get; set; }

        public int Vid { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }
    }
}