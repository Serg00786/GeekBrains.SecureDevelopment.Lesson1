using System;

namespace GeekBrains._SecureDevelopment._Lesson1.Models
{
    public class Bankcard
    {
        public int Id { get; set; }   
        public bool Credit { get; set; }
        public DateTime ValidDate {get; set; }
        public int SecreteCode { get; set; }
    }

    public class Bankcard1
    {
        public string Id { get; set; }
        public  string Credit { get; set; }
        public string ValidDate { get; set; }
        public string SecreteCode { get; set; }
    }
}
