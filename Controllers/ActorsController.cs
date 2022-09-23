using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _service;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        

        public ActorsController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IActorService service)
        {
            this.hostingEnvironment = hostingEnvironment;
            _service = service;
        }

    
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Actorvm avm)
        {
            var k = ProcessUploadFile(avm);
            Actor actor = new Actor()
            {
                ProfilePictureUrl = k,
                FullName = avm.FullName,
                Bio = avm.Bio,
            };
           await _service.AddAsync(actor);
            
            return View();

        }

        [Obsolete]

        private string ProcessUploadFile(Actorvm model)
        {
            string uniqueFileName = null;
            if (model.ProfilePictureUrl != null)
            {
                string photoUpload = Path.Combine(hostingEnvironment.WebRootPath, "Image");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePictureUrl.FileName;
                string filepath = Path.Combine(photoUpload, uniqueFileName);
                using (var filename = new FileStream(filepath, FileMode.Create))
                {
                    model.ProfilePictureUrl.CopyTo(filename);
                }
            }
            return uniqueFileName;
        }

        public async Task<IActionResult> Details(Actorvm avm, int id)
        {
            var k = ProcessUploadFile(avm);
            var ActorDetails = await _service.GetByIdAsync(id);
            if(ActorDetails == null) return View("Not Found");
            return View(ActorDetails);

           
        }
        public async Task<IActionResult> Edit(int id)
        {
            var ActorDetails = await _service.GetByIdAsync(id);
            if (ActorDetails == null) return View("Not Found");
            return View(ActorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureUrl, Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
           
            await _service.UpdateAsync(id, actor);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if(actorDetails == null) return View("NotFound");

            return View(actorDetails);

        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));


        }
    }
}
