using Microsoft.VisualStudio.TestTools.UnitTesting;
using PurchaseSQLDB;
using MosiacData.DBContexts.Entities;
using MosiacData.DBContexts;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessTest
{
    [TestClass]
    public class JobsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var jobs = new  List<Job>();
            using (var context = new PurchaseSQLDBContext())
            {
               
               jobs = context.Job.ToList();
               
            }
            Assert.IsTrue(jobs.Count() > 1);
        }

        [TestMethod]
        public void FindJobShouldReturnJobById()
        {
            Job job;
            using (var context = new PurchaseSQLDBContext())
            {

                job = context.Job.Where(J => J.job_id == 1).SingleOrDefault();

            }
            Assert.IsTrue(job.job_id == 1);
        }
    }
}
