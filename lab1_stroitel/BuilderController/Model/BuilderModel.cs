namespace Model
{
    public class BuilderModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public bool AtWorkStatus { get; set; }
        
        public int BricksPerSession { get; set; }

        public int MinOnBreak { get; set; }
    }
}