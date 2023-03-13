using Microsoft.AspNetCore.Components;
using System.Net;
using Toolbelt.Blazor;

namespace MoeSystem.Client.Services
{
    public class QrCodesGenerator : IQrCodeGenerator
    {
        public async Task<string> GenerateQrCode(string qrcodeText)
        {
            String qrCode = "";
            // using (MemoryStream ms = new MemoryStream())
            // {
            //     QrCodeGenerator qrCodeGenerator = new QrCodeGenerator();
            //     QrCodeData
            // }
            await Task.CompletedTask;
            return qrcodeText;
        }
    }
}
