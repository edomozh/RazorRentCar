namespace RentApp.Services
{
    using RentApp.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("[controller]")]
    [ApiController]
    public class Photos : ControllerBase
    {
        readonly AppDbContext context;

        public Photos(AppDbContext db)
        {
            context = db;
        }

        [Route("GetPhoto")]
        [HttpGet]
        public ActionResult GetPhoto(ulong id)
        {
            var image = context.Photos.AsNoTracking().FirstOrDefault(p => p.Id == id);
            
            if (image == null) 
                return new EmptyResult();

            return File(image.Value!, "image/jpg");
        }
    }
}
