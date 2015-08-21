using JobAdderTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using System.Xml.Linq;

namespace JobAdderTask.Services
{
    public class JobService
    {
        private XDocument doc;

        public JobService ()
        {
            string Path = HostingEnvironment.MapPath( "~/App_Data/SampleJobs.xml" );
            doc = XDocument.Load( Path );
        }

        public IQueryable<Job> GetJobs ( string Search )
        {
            var query = ReadFile().AsQueryable();

            foreach ( var term in SplitQuery( Search ) )
                query = query.Where( job => job.SearchTitle != null ? job.SearchTitle.ToLowerInvariant().Contains( term ) : false  );

            return query;
        }

        public IEnumerable<Job> ReadFile ()
        {
            var jobElements = doc.Root.Elements();
            List<Job> jobs = new List<Job>();


            foreach ( var jobElement in jobElements ) {
                var job = new Job();

                job.Jid = Convert.ToInt32( jobElement.Attribute( "jid" ).Value );
                job.Reference = jobElement.Attribute( "reference" ).Value;
                job.DatePosted = DateTime.Parse( jobElement.Attribute( "datePosted" ).Value );
                job.DateUpdated = DateTime.Parse( jobElement.Attribute( "dateUpdated" ).Value );

                job.Title = jobElement.Element( "Title" ).Value;
                job.Description = jobElement.Element( "Description" ).Value;
                job.SearchTitle = jobElement.Element( "SearchTitle" ).Value;


                job.Classifications = new List<Classification>();

                var classificationElements = jobElement.Element( "Classifications" ).Elements();

                foreach ( var classificationElement in classificationElements ) {


                    var classification = new Classification();

                    classification.Jid = Convert.ToInt32( classificationElement.Attribute( "jid" ).Value );
                    classification.Id = Convert.ToInt32( classificationElement.Attribute( "id" ).Value );
                    classification.Vid = Convert.ToInt32( classificationElement.Attribute( "vid" ).Value );
                    classification.Name = classificationElement.Attribute( "name" ).Value;

                    classification.Content = classificationElement.Value;

                    job.Classifications.Add( classification );
                }

                jobs.Add( job );
            }

            return jobs;
        }


        public static IList<string> SplitQuery ( string query )
        {
            return !string.IsNullOrWhiteSpace( query ) ? query.Split( new string[] { " ", "-", "|" }, StringSplitOptions.RemoveEmptyEntries ).ToList() : new List<string>();
        }
    }
}



//<Job jid="2008172" reference="2028816" datePosted="2015-06-24" dateUpdated="2015-06-23T21:41:54Z">
//  <Title>Senior Account Executive</Title>
//  <Summary>Award-winning, highly regarded PR and Marketing ​agency looking for AE to work across brands in a broad range of sectors.</Summary>
//  <Description><![CDATA[<strong></strong><strong></strong><strong></strong><strong></strong><strong></strong><strong></strong><strong>The Company</strong><br> <br> Award-winning, highly regarded PR and Marketing&nbsp;&#8203;agency working with brands across the&nbsp;technology, consumer lifestyle, financial services, resource, &#8203;sustainability and not-for-profit sectors.&nbsp;<br> <br> <strong>The Role</strong><br> <br> &nbsp;&#8203;As a strong Account Executive or Senior Account Executive, &#8203;you bring 12+ months experience working in an agency environment. This role needs someone who will hit the ground running, driving media relationships with new and existing contacts and bring the capability to support integrated campaigns across consumer lifestyle, retail, food and drink and lifestyle &amp; leisure.&nbsp;<br> <br> <strong>&amp; You...&nbsp;</strong><br> &#8203;<br> Are confident in working with a diverse media set, have solid &#8203;interpersonal &amp; writing skills and a good&#8203; working&#8203;&nbsp;knowledge of&nbsp;&#8203;supporting &#8203;traditional and social media&nbsp;campaigns.&#8203;&nbsp;You will ask questions, be hungry to learn new skills and ideally have grown an established network of local media contacts&#8203;. &#8203;<br> <br> <strong>33 Talent</strong><br> <em>33 Talent specialises in Big Data, Digital and Communications recruitment and talent management&nbsp;across the APAC region. &nbsp;Our clients include Lenovo, AMEX, SingTel, The Body Shop, Amobee, SAP, WPP Group, McCann Worldgroup, IPG and&nbsp;numerous other corporate, agency and network clients.&nbsp;&nbsp; Please get in touch or feel free to make referrals to&nbsp;hello@jobadder.com&nbsp; We'd love to hear from you!&nbsp;<br> </em><br> <em>33 Talent Pty Ltd</em><br> <em>Recruiter: Sally Thompson - sally@jobadder.com<br> </em>]]></Description>
//  <SearchTitle>Senior Account Executive</SearchTitle>
//  <Classifications>
//    <Classification jid="15365" name="Job Category" vid="636092" id="528">Communications</Classification>
//    <Classification jid="15366" name="Sub-Category" vid="636767" id="4294">PR - Account Executive</Classification>
//    <Classification jid="15405" name="Country" vid="636163" id="1">Australia</Classification>
//    <Classification jid="15410" name="Location" vid="636785" id="1">Sydney</Classification>
//    <Classification jid="16810" name="Area" vid="816806" id="1">All Sydney</Classification>
//    <Classification jid="15368" name="Work Type" vid="636197" id="2">Full Time</Classification>
//  </Classifications>
//  <Fields />
//</Job>


