﻿using System.ComponentModel.DataAnnotations;

namespace MoeSystem.Shared.Models.LicenceDocument
{
    public class BaseLicenceDocumentDto
    {
        [Required, Range(1, int.MaxValue)]

        public int DocumentTypeId { get; set; }
        [Required]

        public string DocumentName { get; set; }
        public int? LicenceId { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string FileExtension { get; set; }
    }
}
