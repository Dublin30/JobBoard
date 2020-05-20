using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data.EF
{
    public class JobBoardMetadata
    {

    }
    [MetadataType(typeof(JobBoardMetadata))]
    public partial class JobBoard
    {
    }
}
