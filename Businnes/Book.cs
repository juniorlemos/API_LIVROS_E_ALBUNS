namespace Businnes
{
    public class Book : BaseEntity
    {        
        public string Title { get; set; }
    
        public string Author { get; set; }

        public decimal Price { get; set; }

        public DateTime Launch_Date { get; set; }
    }
}
