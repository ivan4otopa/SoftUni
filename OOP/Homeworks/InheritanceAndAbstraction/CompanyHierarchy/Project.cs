using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class Project : IProject
    {
        private string projectName;
        private string details;
        public string ProjectName
        {
            get
            {
                return this.projectName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Project Name cannot be empty.");
                }
                this.projectName = value;
            }
        }
        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Details About Project cannot be empty.");
                }
                this.details = value;
            }
        }
        public DateTime ProjectStartDate { get; set; }
        public State State { get; set; }
        public Project(string projectName, DateTime projectStartDate, string details, State state)
        {
            this.ProjectName = projectName;
            this.ProjectStartDate = projectStartDate;
            this.Details = details;
            this.State = state;
        }
        public override void CloseProject()
        {
            this.State = State.Closed;
        }
        public override string ToString()
        {
            return String.Format("Project Name: {0}; Project Start Date: {1}; Detaiils: {2}; State: {3}", this.projectName,
                this.ProjectStartDate, this.details, this.State);
        }
    }
}
