namespace WorldLib.Models
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
        public int    SurfaceArea { get; set; }
        public int?   IndependenceYear { get; set; }
        public int    Population { get; set; }
        public int?   CapitalId { get; set; }

        public Country() { }

        public Country(string code, string name, string continent, string region,
            int surfaceArea, int? independenceYear, int population, int? capitalId)
        {
            Code = code;
            Name = name;
            Continent = continent;
            Region = region;
            SurfaceArea = surfaceArea;
            IndependenceYear = independenceYear;
            Population = population;
            CapitalId = capitalId;
        }
    }
}
