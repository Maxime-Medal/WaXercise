namespace WaXercise.Services.Interfaces
{
    public interface IPeopleService
    {
        bool IsAgeIsValid(DateTime dateOfBirth, int maxValue);
        int GetAge(DateTime dateOfBirth);

    }
}
