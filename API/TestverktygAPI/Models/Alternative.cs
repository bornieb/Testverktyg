﻿namespace TestverktygAPI.Models
{
    public class Alternative
    {
        public int AlternativeId { get; set; }
        public string AlternativeText { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
