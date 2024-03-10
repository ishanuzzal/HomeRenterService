using MyRent.Interfaces;
using Microsoft.AspNetCore.Hosting;
namespace MyRent.Helpers
{
    public class HandleImage : IFileService
    {
        private IWebHostEnvironment _environment;
        public HandleImage(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public Tuple<string,int> SaveImage(IFormFileCollection files,string id)
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
                var requestFolderPath = Path.Combine(uploadsPath, id);
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
                }

                return new Tuple<string, int>("Success", files.Count()); // Return success message and number of saved files
            }
            catch (Exception ex)
            {
                return new Tuple<string, int>("Error: " + ex.Message, 0);
            }
        }
    }
}
