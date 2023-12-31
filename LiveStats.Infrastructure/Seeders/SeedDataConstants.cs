﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Infrastructure.Seeders
{
    public class SeedDataConstants
    {
        public const string Path = "../LiveStats.Infrastructure/Seeders/Data/{0}/{1}";

        public const string Identity = "Identity";
        public const string Shared = "Shared";
        public const string Football = "Football";

        public class IdentityConstants
        {
            public const string Users = "users.json";
            public const string Roles = "roles.json";
            public const string UsersRoles = "usersRoles.json";
        }

        public class Sh_Constants
        {
            public const string Nationalities = "nationalities.json";
        }

        public class Fb_Constants
        {
            public const string Competitions = "competitions.json";
            public const string Positions = "positions.json";
            public const string PositionTypes = "positionTypes.json";
            public const string Stadiums = "stadiums.json";
            public const string Teams = "teams.json";
            public const string CompetitionsTeams = "competitionsTeams.json";
        }
    }
}
