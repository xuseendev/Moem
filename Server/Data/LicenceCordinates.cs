namespace MoeSystem.Server.Data
{
    public class LicenceCordinates : BaseModel
    {
    
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

    }
}
