namespace Weather.App.Queries
{
    public class SearchCityByNameQuery
    {
        public string Query { get; set; }

        public SearchCityByNameQuery(string query)
        {
            Query = query;
        }
    }
}
