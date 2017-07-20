using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalProgramming
{
    class Ports
    {
    }

    public class Port : IHaveName
    {
        public Port(string name, string code, City city)
        {
            City = City;
            Name = name;
        }
        public string PortCode { get; private set; }
        public City City { get; private set; }
        public Country Country { get { return City.Country; } }
        public Continent Continent { get { return Country.Continent; } }

        public string Name { get; }
    }

    public class City : IHaveName, IHaveCode
    {

        public City(string name, string code, Country country)
        {
            Country = country;
            Name = name;
        }
        public Country Country { get; private set; }
        public Continent Continent { get { return Country.Continent; } }

        public string Name { get; }

        public string Code { get; }
    }

    public class Country : IHaveName, IHaveCode
    {
        public Country(string name, string code, Continent continent)
        {
            Continent = continent;
            Name = name;
        }
        public Continent Continent { get; private set; }
        public string Name { get; private set; }

        public string Code { get; private set; }
    }

    public class Continent : IHaveName, IHaveCode
    {
        public Continent(string name, string code)
        {
            Name = name;
        }
        public string Name { get; }

        public string Code { get; }
    }

    public interface IHaveName
    {
        string Name { get; }
    }

    public interface IHaveCode
    {
        string Code { get; }
    }

    public class CityPort
    {
        public static readonly Port DonMueng = new Port("Don Meung", "DMK", Bangkok);
        public static readonly City Bangkok = new City("Bangkok", "BKK", Thailand);
        public static readonly Country Thailand = new Country("Thailand", "TH", Asia);
        public static readonly Continent Asia = new Continent("Asia", "AS");

        public static readonly City Melbourne = new City("Melbourne", "MEL", Thailand);
        public static readonly Country Australia = new Country("Australia", "AU", Asia);
        public static readonly Continent Oceania = new Continent("Oceania", "OC");
    }

}
