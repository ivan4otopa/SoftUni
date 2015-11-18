//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QueryExistingDatabaseImportExportData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Team
    {
        public Team()
        {
            this.HomeTeamMatches = new HashSet<TeamMatch>();
            this.AwayTeamMatches = new HashSet<TeamMatch>();
            this.Leagues = new HashSet<League>();
        }
    
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string CountryCode { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual ICollection<TeamMatch> HomeTeamMatches { get; set; }
        public virtual ICollection<TeamMatch> AwayTeamMatches { get; set; }
        public virtual ICollection<League> Leagues { get; set; }
    }
}
