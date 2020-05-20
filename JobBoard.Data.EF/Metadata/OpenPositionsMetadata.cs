using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data.EF
{
    public class OpenPositionsMetadata
    {
        [Required]
        [Display(Name ="Position ID")]
        public int OpenPositionID { get; set; }
        [Required]
        [Display(Name ="Location")]
        public int LocationID { get; set; }
        [Required]
        [Display(Name ="Position")]
        public int PositionID { get; set; }
    }
    [MetadataType(typeof(OpenPositionsMetadata))]
    public partial class OpenPosition
    {
    }
}
