namespace Soma.Api.Extensions;

public static class FormFileExtensions
{
    public static async Task<(string name, byte[] content)> GetFile(this IFormFile file)
    {
        await using Stream fileStream = file.OpenReadStream();
        using StreamContent reader = new (fileStream, 4096);
        byte[] content = await reader.ReadAsByteArrayAsync();

        return (file.FileName, content);
    }
}