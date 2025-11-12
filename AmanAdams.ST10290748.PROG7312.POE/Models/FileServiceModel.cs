using Microsoft.AspNetCore.Http;
using System;
using System.IO;

//Aman Adams
//ST10290748
//PROG7312
//POE PART 3

namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class FileServiceModel
    {
        public string? SaveFile(IFormFile attachment)
        {
            if (attachment == null || attachment.Length == 0)
                return null;

            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(attachment.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                attachment.CopyTo(stream);
            }

            return filePath;
        }
    }
}
//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//

