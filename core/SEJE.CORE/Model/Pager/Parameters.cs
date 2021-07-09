using SEJE.CORE.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace SEJE.CORE.Model.Pager
{
    public class Parameters : IDtoBase
    {
        [Range(1, int.MaxValue, ErrorMessage = "The {0} field not is valid.")]
        public int CurrentPage { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The {0} field not is valid.")]
        public int PageSize { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The {0} field not is valid.")]
        public int MaxPage { get; set; }
    }
}
