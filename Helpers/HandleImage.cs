using MyRent.Interfaces;
using Microsoft.AspNetCore.Hosting;
using MyRent.DbContext;
using MyRent.Mappers;
using HomeRenterService.Mappers;
namespace MyRent.Helpers;

public class HandleImage : IFileService
{
    private IWebHostEnvironment _environment;
    private readonly ApplicationDbContext _context;
    public HandleImage(IWebHostEnvironment environment, ApplicationDbContext context)
    {
        _environment = environment;
        _context = context;
    }
    public async Task<Tuple<string,int>> SaveImage(IFormFileCollection files,string ApartmentId)
    {
        try
        {
            var contentPath = this._environment.ContentRootPath;
            var uploadsPath = Path.Combine(contentPath, "Uploads");

            // Ensure Uploads folder exists
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            // Create folder for the request ID (if it doesn't exist)
            var requestFolderPath = Path.Combine(uploadsPath, ApartmentId);
            if (!Directory.Exists(requestFolderPath))
            {
                Directory.CreateDirectory(requestFolderPath);
            }

            // Loop through each uploaded file
            foreach (var file in files)
            {
                var ext = Path.GetExtension(file.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };

                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(",", allowedExtensions));
                    return new Tuple<string, int>(msg, 0);
                }

                string uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;
                var fullFilePath = Path.Combine(requestFolderPath, newFileName);

                using (var stream = new FileStream(fullFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var Images = ImageMappers.ImageToModel(fullFilePath,ApartmentId);

                var result = await _context.images.AddAsync(Images);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to save image: " + ex.Message);
                }
           
            }

            return new Tuple<string, int>("Success", files.Count()); // Return success message and number of saved files
        }
        catch (Exception ex)
        {
            return new Tuple<string, int>("Error: " + ex.Message, 0);
        }
    }
}
