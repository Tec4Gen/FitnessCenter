using System;

namespace Epam.FitnessCenter.Entities
{
    public class Lesson
    {
        public int Id{ get; set; }

        public int IdUserCoach { get; set; }

        public int IdHall{ get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }
    }
}
