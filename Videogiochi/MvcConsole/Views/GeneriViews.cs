public class GeneriViews
{
    public void ShowGeneri(List<object> generi)
    {
        foreach (var genere in generi)
        {
            Console.WriteLine(genere);
        }
    }
}