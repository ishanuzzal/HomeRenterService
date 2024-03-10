namespace MyRent.Interfaces
{
    public interface IGettingIds
    {
        public Task<string> getOwnerId(string username);
        //public string getRenterId(string username);
    }
}
