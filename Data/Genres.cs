namespace learnRazor.Data;

public class Genres
{
    public static IList<string> GetGenres()
    {
        /*
         * <option selected>Genres</option>
        <option value="Romantic">Romantic</option>
        <option value="Comedy">Comedy</option>
        <option value="Horror">Horror</option>
        <option value="Western">Western</option>
        <option value="Action">Action</option>
         */
        return new List<string>
        {
            "Romantic",
            "Comedy",
            "Horror",
            "Western",
            "Action",
        };
    }
}