using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ehealth.Models;

namespace Ehealth.ViewModels
{
    public class ArticleFormViewModel
    {
        public IEnumerable<ArticleType> ArticleTypes { get; set; }
        public Article Article { get; set; }

        public string Title
        {
            get
            {
                if (Article != null && Article.Id != 0)
                    return "Edit Article";

                return "New Article";
            }
        }
    }
}