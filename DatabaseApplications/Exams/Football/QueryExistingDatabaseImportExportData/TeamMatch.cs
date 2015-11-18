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
    
    public partial class TeamMatch
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public Nullable<int> HomeGoals { get; set; }
        public Nullable<int> AwayGoals { get; set; }
        public Nullable<System.DateTime> MatchDate { get; set; }
        public Nullable<int> LeagueId { get; set; }
    
        public virtual League League { get; set; }
        public virtual Team AwayTeam { get; set; }
        public virtual Team HomeTeam { get; set; }
    }
}
