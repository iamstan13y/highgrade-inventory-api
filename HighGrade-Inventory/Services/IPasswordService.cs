namespace HighGradeInventory.API.Services
{
    public interface IPasswordService
    {
        bool VerifyHash(string password, string hashedPassword);
    }
}