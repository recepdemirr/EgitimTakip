using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    public class TrainingSubjectsMap
    {
        [ForeignKey(nameof(Training))]
        public int TrainingId { get; set; }
        public virtual Training Training { get; set; }

        [ForeignKey(nameof(TrainingSubject))]
        public int TrainingSubjectId { get; set; }
        public virtual TrainingSubjects TrainingSubject { get; set; }
        public int Duration { get; set; }
    }
}
