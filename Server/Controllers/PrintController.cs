using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoeSystem.Server.Contracts;

namespace Server.Controllers
{

    public class PrintController : Controller
    {
        private readonly ILicenceRepository licenceRepository;

        public PrintController(ILicenceRepository licenceRepository)
        {
            this.licenceRepository = licenceRepository;
        }

        public async Task<IActionResult> PrintLicence(int id)
        {
            var licenceDetail = await licenceRepository.GetLicenceDetailPrint(id);
            return View(licenceDetail);
        }
    }
}