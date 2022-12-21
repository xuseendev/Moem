namespace MoeSystem.Server.Data
{
    public class Query
    {
        public IQueryable<Licence> GetLicences =>
            new List<Licence>().AsQueryable();
    }
}
