﻿using System.ComponentModel.DataAnnotations;

namespace Seikkailupeli
{
    public class PutQuest
    {
        //[Key]
        //public int Id { get; set; }
        //public string QuestName { get; set; }
        public bool QuestIsStarted { get; set; }
        public bool QuestIsCompleted { get; set; }

    }
}
