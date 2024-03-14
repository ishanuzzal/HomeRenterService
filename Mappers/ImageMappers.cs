using MyRent.Model;

namespace HomeRenterService.Mappers
{
    public class ImageMappers
    {
        public static Images ImageToModel(string path, string apartmentId)
        {
            return new Images
            {
                path = path,
                ApartmentId = apartmentId,
                uploadDate = DateTime.Now,
            };
        }
    }
}
