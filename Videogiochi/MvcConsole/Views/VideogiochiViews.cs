class VideogiochiViews
{
    public void ShowVideogiochi(List<object> videogiochi)
    {
        foreach (var videogioco in videogiochi)
        {
            Console.WriteLine(videogioco);
            
        }
    }
}