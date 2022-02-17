using System;

namespace GeekBrains._SecureDevelopment._Lesson1.Models
{
    internal class Bankcard
    {
        internal int Id { get; set; }   
        internal bool Credit { get; set; }
        internal DateTime ValidDate {get; set; }
        internal int SecreteCode { get; set; }
    }
}
