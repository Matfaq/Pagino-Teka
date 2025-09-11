namespace Pagino_Teka.Models
{
    /// <summary>
    /// Model reprezentujący autora książki.
    /// </summary>
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
