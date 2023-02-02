namespace Model.Dto.SignalR
{
    public class CharacterPositionDto
    {
        public long CharacterId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double MapWidth { get; set; }
        public double MapHeight { get; set; }
    }
}
