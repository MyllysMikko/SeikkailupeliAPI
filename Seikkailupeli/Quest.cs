using System.ComponentModel.DataAnnotations;

namespace Seikkailupeli
{
    public class Quest
    {
        [Key]
        public int Id { get; set; }
        public string QuestName { get; set; }
        public string QuestDescription { get; set; }
        public int QuestGoldReward { get; set; }
        public int QuestExpReward { get; set; }
        public bool QuestIsStarted { get; set; }
        public bool QuestIsCompleted { get; set; }




    }
}
