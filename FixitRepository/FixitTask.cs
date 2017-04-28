using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixitRepository
{
    public class FixitTask
    {
        public int Id { get; set; }

        [StringLength(80)]
        public string  CreatedBy { get; set; }

        [StringLength(80)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Notes { get; set; }

        [StringLength(300)]
        public string PhotoUrl { get; set; }

        public bool IsDone { get; set; }


    }
}
