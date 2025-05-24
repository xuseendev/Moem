namespace MoeSystem.Shared.Models.LicenceComment
{
    public class LicenceCommentDto : BaseLicenceCommentDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
