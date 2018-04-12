using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ehealth.Models;

namespace Ehealth.ViewModels
{
    public class RandomProgramViewModel
    {
        public Program Program { get; set; }
        public List<User> Users { get; set; }
    }
}