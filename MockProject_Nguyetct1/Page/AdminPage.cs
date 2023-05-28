using AutoCore.Helpers;
using AutomationWebDriver.Extension;
using MockProject_Nguyetct1.Models;
using MockProject_Nguyetct1.Page;
using OpenQA.Selenium;

namespace MockProject_Nguyetct1.Test
{
    /// <summary>
    /// Where the foundation code for the Admin page testing
    /// </summary>
    public class AdminPage : BasePage
    {
        /// <summary>
        /// Contrutor inherited driver from BasePage's driver.
        /// </summary>
        /// <param name="driver"></param>
        public AdminPage(IWebDriver driver) : base(driver)
        {
        }

        #region Declare and init loactors:
        public By adminBtn = By.XPath("//a[@href='/web/index.php/admin/viewAdminModule']");
        private By jobBtn = By.CssSelector(".oxd-topbar-body>nav[role='navigation']>ul>li:nth-child(2)");
        private By jobTitleBtn = By.CssSelector(".oxd-topbar-body>nav[role='navigation']>ul>li:nth-child(2)>ul>li:nth-child(1)");
        private By addJobBtn = By.CssSelector(".orangehrm-header-container>div>button");
        public By jobTitleInput = By.CssSelector("form>div:nth-child(1)>div>div:last-child>input");
        public By jobDescriptionInput = By.CssSelector("form>div:nth-child(2)>div>div:last-child>textarea");
        private By noteInput = By.CssSelector("form>div:nth-child(4)>div>div:last-child>textarea");
        private By saveJobBtn = By.CssSelector("button[type='submit']");
        private By messageBox = By.CssSelector(".oxd-toast-start>div:last-child>p:first-child");

        private By jobDiv = By.CssSelector(".oxd-table-card");
        private By updateJobButton(int i) => By.CssSelector($".oxd-table-card:nth-child({i + 1})>div>div:nth-child(4)>div>button:last-child");
        private By deleteJobButton(int i) => By.CssSelector($".oxd-table-card:nth-child({i + 1})>div>div:nth-child(4)>div>button:first-child");
        private By confirmdeleteButton = By.CssSelector(".orangehrm-modal-footer>button:last-child");
        private readonly By loading = By.CssSelector(".oxd-form-loader");



        #endregion


        /// <summary>
        /// Click buttons and input data.
        /// </summary>
        #region Add job title
        public void ClickAdminBtn()
        {
            driver.Click(adminBtn);
        }

        public void ClickJobBtn()
        {
            driver.Click(jobBtn);
        }

        public void ClickJobTitleBtn()
        {
            driver.Click(jobTitleBtn);
        }

        public void ClickAddJobTitleBtn()
        {
            driver.Click(addJobBtn);
        }

        public void InputJobTitle(string title)
        {

            driver.TypeText(jobTitleInput, title);
        }
        public void InputJobDescription(string desc)
        {
            driver.TypeText(jobDescriptionInput, desc);
        }

        public void InputNote(string note)
        {
            driver.TypeText(noteInput, note);
        }
        public void ClickSaveJob()
        {
            driver.Click(saveJobBtn);
        }

        public void ClickEditJobBtn(int i)
        {
            //driver.WaitUntilLocatorInVisible(loading);
            //driver.WaitUntilLocatorVisible(updateJobButton(i));
            driver.Click(updateJobButton(i));
        }

        public void ClickDeleteJobBtn(int i)
        {
            driver.Click(deleteJobButton(i));
        }

        public void ClickDeleteConfirmBtn()
        {
            driver.Click(confirmdeleteButton);
        }
        #endregion


        /// <summary>
        /// Gẹt Jobs init
        /// </summary>
        /// <returns></returns>
        public static List<Job> GetJobs()
        {
            var jobs = CSVHelper.GetDataFromCsvHelper<Job>("Job");
            return jobs.ToList();
        }

        /// <summary>
        /// Get jobs for update
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Job> GetJobsUpdate()
        {
            var jobs = CSVHelper.GetDataFromCsvHelper<Job>("JobUpdate");
            return jobs;
        }
        /// <summary>
        /// Get content in message box
        /// </summary>
        /// <returns></returns>
        public string GetMessageAdminPage()
        {
            var result = driver.GetMessage(messageBox);
            if (result != null && result != "" || result.Equals("成功") || result.Equals("Success"))
            {
                return "Success";
            }
            return "Message not exist";
        }
        /// <summary>
        /// Get all job from website
        /// </summary>
        /// <returns></returns>
        public List<Job> GetAllJobs()
        {
            //Init list data:
            var list = new List<Job>();

            //Finds multiple web elements on the web page
            IList<IWebElement> jobs = driver.FindElements(jobDiv);

            foreach (var job in jobs)
            {
                list.Add(new Job
                {
                    JobTitle = job.FindElement(By.CssSelector(".oxd-table-card>div>div:nth-child(2)>div")).Text,
                    JobDescription = job.FindElement(By.CssSelector(".oxd-table-card>div>div:nth-child(3)>div")).Text,
                }); ;
            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                return new List<Job>();
            }
        }

        public int SearchJob(Job job)
        {
            //Search Job after get job from website
            var allJobResult = GetAllJobs();

            for (var i = 0; i < allJobResult.Count; i++)
            {
                if (allJobResult[i].JobTitle == job.JobTitle)
                {
                    return i;
                }
            }

            return -1;

        }

        public void UpdateJobs(Job job)
        {
            Thread.Sleep(1000);
            //Get jobs update
            var jobsUpdate = GetJobsUpdate()?.ToList();

            //Search Job after get job from website
            var existed = SearchJob(job);
            if (existed != -1)
            {
                //Use Id to mapping job update with job init:
                var jobUpdate = jobsUpdate?.FirstOrDefault(s => s.Id == job.Id);
                if (jobUpdate == null)
                {
                    return;
                }

                //Thread.Sleep(5000);
                ClickEditJobBtn(existed);
                driver.Clear(jobTitleInput);
                InputJobTitle(jobUpdate.JobTitle);
                driver.Clear(jobDescriptionInput);
                InputJobDescription(jobUpdate.JobDescription);
                ClickSaveJob();
            }
        }

        public void DeleteJobs(Job job)
        {
            //Search Job after get job from website
            var existed = SearchJob(job);

            if (existed != -1)
            {

                Thread.Sleep(1000);
                ClickDeleteJobBtn(existed);
                Thread.Sleep(1000);
                ClickDeleteConfirmBtn();
            }
            else
            {
                return;
            }
        }

    }
}
