using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ehealth.Dtos
{
    public class NewBuyDto
    {
        public int UserId { get; set; }
        public List<int> ProgramIds { get; set; }
    }
}