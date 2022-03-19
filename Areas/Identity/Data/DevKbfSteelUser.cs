using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DevKbfSteel.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the DevKbfSteelUser class
    public class DevKbfSteelUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string firstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string  lastName { get; set; }
    }
}
