namespace MoeSystem.Server.Data
{
    public class LicenceCordinates : BaseModel
    {

        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }

    }
}
