using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cube.Models
{
    public class QuestionAnswer
    {
        public long Id { get; set; }
        public long QuestionsId { get; set; }
        public long AnswersId{ get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Question Question { get; set; }        
        public virtual ICollection<TestQuest> TestQuest { get; set; }
    }
}
