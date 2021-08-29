namespace Core.Utilities.Results
{
    public interface IResult
    {
        //Readonly işlem başarılı mı değil mi
        bool Success { get; }
        //İşlem mesajı başarılı oldu mu olmadı mı
        string Message { get; }
    }
}