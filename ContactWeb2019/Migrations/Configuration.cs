namespace ContactWeb2019.Migrations
{
    using ContactWeb2019.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            CreateStates(context);
        }

        private void CreateStates(ApplicationDbContext context)
        {
            foreach (var state in SeedStates)
            {
                var dbState = context.States.FirstOrDefault(s => s.Abbreviation.Equals(state.Abbreviation, StringComparison.InvariantCultureIgnoreCase));
                if (dbState != null)
                {
                    if(!dbState.Name.Equals(state.Name, StringComparison.InvariantCulture))
                        dbState.Name = state.Name;
                }
                else
                {
                    context.States.Add(state);
                }
                    
            }

            context.SaveChanges();
        }

        private static List<State> SeedStates = new List<State>
        {
            new State() { Name = "Alabama", Abbreviation = "AL"},
            new State() { Name = "Alaska", Abbreviation = "AK" },
            new State() { Name = "Arizona", Abbreviation = "AZ"},
            new State() { Name = "Arkansas", Abbreviation = "AR"},
            new State() { Name = "California", Abbreviation = "CA"},
            new State() { Name = "Colorado", Abbreviation = "CO"},
            new State() { Name = "Connecticut", Abbreviation = "CT"},
            new State() { Name = "Delaware", Abbreviation = "DE"},
            new State() { Name = "District of Columbia", Abbreviation = "DC"},
            new State() { Name = "Florida", Abbreviation = "FL"},
            new State() { Name = "Georgia", Abbreviation = "GA"},
            new State() { Name = "Hawaii", Abbreviation = "HI"},
            new State() { Name = "Idaho", Abbreviation = "ID"},
            new State() { Name = "Illinois", Abbreviation = "IL"},
            new State() { Name = "Indiana", Abbreviation = "IN"},
            new State() { Name = "Iowa", Abbreviation = "IA"},
            new State() { Name = "Kansas", Abbreviation = "KS"},
            new State() { Name = "Kentucky", Abbreviation = "KY"},
            new State() { Name = "Louisiana", Abbreviation = "LA"},
            new State() { Name = "Maine", Abbreviation = "ME"},
            new State() { Name = "Maryland", Abbreviation = "MD"},
            new State() { Name = "Massachusetts", Abbreviation = "MS"},
            new State() { Name = "Michigan", Abbreviation = "MI"},
            new State() { Name = "Minnesota", Abbreviation = "MN"},
            new State() { Name = "Mississippi", Abbreviation = "MS"},
            new State() { Name = "Missouri", Abbreviation = "MO"},
            new State() { Name = "Montana", Abbreviation = "MT"},
            new State() { Name = "Nebraska", Abbreviation = "NE"},
            new State() { Name = "Nevada", Abbreviation = "NV"},
            new State() { Name = "New Hampshire", Abbreviation = "NH"},
            new State() { Name = "New Jersey", Abbreviation = "NJ"},
            new State() { Name = "New Mexico", Abbreviation = "NM"},
            new State() { Name = "New York", Abbreviation = "NY"},
            new State() { Name = "North Carolina", Abbreviation = "NC"},
            new State() { Name = "North Dakota", Abbreviation = "ND"},
            new State() { Name = "Ohio", Abbreviation = "OH"},
            new State() { Name = "Oklahoma", Abbreviation = "OK"},
            new State() { Name = "Oregon", Abbreviation = "OR"},
            new State() { Name = "Pennsylvania", Abbreviation = "PA"},
            new State() { Name = "Rhode Island", Abbreviation = "RI"},
            new State() { Name = "South Carolina", Abbreviation = "SC"},
            new State() { Name = "South Dakota", Abbreviation = "SD"},
            new State() { Name = "Tennessee", Abbreviation = "TN"},
            new State() { Name = "Texas", Abbreviation = "TX"},
            new State() { Name = "Utah", Abbreviation = "UT"},
            new State() { Name = "Vermont", Abbreviation = "VT"},
            new State() { Name = "Virginia", Abbreviation = "VA"},
            new State() { Name = "Washington", Abbreviation = "WA"},
            new State() { Name = "West Virginia", Abbreviation = "WV"},
            new State() { Name = "Wisconsin", Abbreviation = "WI"},
            new State() { Name = "Wyoming", Abbreviation = "WY"}
        };
    }
}
