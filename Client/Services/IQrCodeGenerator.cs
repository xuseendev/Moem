using Microsoft.AspNetCore.Components;
using System.Net;
using Toolbelt.Blazor;

namespace MoeSystem.Client.Services
{
    public interface IQrCodeGenerator
    {
        Task<string> GenerateQrCode(string qrcodeText);

    }
}
