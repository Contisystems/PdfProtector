using Microsoft.Extensions.Configuration;
using PdfProtector;

var configuration = new ConfigurationBuilder()
     .AddJsonFile($"appsettings.json");

var config = configuration.Build();

try
{
    var inputFolder = config["Inputs:InFolder"]; ;
    var outputFolder = config["Inputs:OutFolder"]; ;
    var ownerPassword = config["Inputs:OwnerPassword"];
    bool isToProtect = bool.Parse(config["Inputs:isToProtect"]);

    var filesPath = Directory.EnumerateFiles(inputFolder, "*.pdf");

    foreach (var path in filesPath)
    {
        FileInfo fileInfo = new FileInfo(path);
        var filename = fileInfo.Name;
        PDF.Protect(inputFolder, outputFolder, filename, isToProtect, ownerPassword);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw ex;
}