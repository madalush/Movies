using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar2.ViewModel
{
    public class CommentListDto
    {
        public IEnumerable<GetCommentsDto> CommentsList { get; set; } = new List<GetCommentsDto>();
    }
}
