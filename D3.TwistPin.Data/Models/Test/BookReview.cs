using System;

namespace D3.TwistPin.Data.Models.Test
{
    public class BookReview
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        public Book Book { get; set; }  
    }
}