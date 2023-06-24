public class UrlProvider 
{
    private int _numberImage;
    private string _urlPage = "http://data.ikppbb.com/test-task-unity-data/pics/";
    private string _fileExtension = ".jpg";
    
    public string Url => $"{_urlPage}{_numberImage}{_fileExtension}";

    public UrlProvider(int numberImage)
    {
        _numberImage = numberImage;
    }
}
