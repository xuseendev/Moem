﻿namespace MoeSystem.Shared.Models.LicenceStatus
{
    public class LicenceStatusDto : BaseLicenceStatusDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
