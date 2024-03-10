namespace MyRent.Interfaces
{
    public interface IFileService
    {
        public Tuple<string,int> SaveImage(IFormFileCollection files,string id);
    }
}
