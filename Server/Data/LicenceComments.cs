namespace MoeSystem.Server.Data
{
    public class LicenceComments : BaseModel
    {

        public string Type { get; set; }
        public int LicenceId { get; set; }
        public Licence Licence { get; set; }
        public string Comment { get; set; }



    }
}
