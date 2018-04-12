using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ehealth.Models;

namespace Ehealth.ViewModels
{
    public class UserFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public User User { get; set; }
    }
}