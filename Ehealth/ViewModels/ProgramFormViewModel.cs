using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Ehealth.Models;

namespace Ehealth.ViewModels
{
    public class ProgramFormViewModel
    {
        public IEnumerable<ProgramType> ProgramTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Program Type")]
        [Required]
        public byte? ProgramTypeId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Program" : "New Program";
            }
        }

        public ProgramFormViewModel()
        {
            Id = 0;
        }

        public ProgramFormViewModel(Program program)
        {
            Id = program.Id;
            Name = program.Name;
            ReleaseDate = program.ReleaseDate;
            NumberInStock = program.NumberInStock;
            ProgramTypeId = program.ProgramTypeId;
        }
    }
}