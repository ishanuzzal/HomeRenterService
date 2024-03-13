namespace MyRent.Interfaces
{
    public interface IFileService
    {
        public Task<Tuple<string,int>> SaveImage(IFormFileCollection files,string apartmentId);
    }
}
