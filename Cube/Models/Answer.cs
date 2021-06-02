using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class Answer
    {
        public long Id { get; set; }
        public string AnswerName { get; set; }

        public virtual ICollection<QuestionAnswer> QuestionAnswer { get; set; }
    }
}
