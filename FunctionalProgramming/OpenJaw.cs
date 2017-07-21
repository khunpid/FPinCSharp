using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FunctionalProgramming
{
    public static class OpenJaw
    {

        public static (IEnumerable<IEnumerable<FlightSegment>> OJ, IEnumerable<FlightSegment> Other) AllOpenJaws(this FlightQuery flightQuery)
        {
            var allOpenJaws = AllOpenJawsInternal(flightQuery);
            var allOpenJawsFlatten = allOpenJaws.SelectMany(x => x);
            IEnumerable<FlightSegment> allSegments = flightQuery.FlightSegments;
            return (allOpenJaws, allSegments.Except(allOpenJawsFlatten));
        }
        public static IEnumerable<IEnumerable<FlightSegment>> AllOpenJawsInternal(this FlightQuery flightQuery)
        {
            var head = flightQuery.FlightSegments.First();
            var tail = flightQuery.FlightSegments.Skip(1);

            var originList = flightQuery.FlightSegments.Select(segment => (segment.Origin, segment.Departure));
            var destinationList = flightQuery.FlightSegments.Select(segment => (segment.Destination, segment.Departure));

            if (tail.Count() >= 1)
            {
                var openJaw = tail.Where(elem => elem.Destination == head.Origin && elem.Departure > head.Departure);
                var other = tail.Except(openJaw);
                if (openJaw.Any())
                {
                    return new[] { openJaw.Prepend(head) }.Concat(
                        other.Any()
                            ? new FlightQuery { FlightSegments = other.ToArray() }.AllOpenJawsInternal()
                            : new List<IEnumerable<FlightSegment>>().ToArray());
                }
                else
                {
                    tail.Print("tail");
                    return new FlightQuery { FlightSegments = tail.ToArray() }.AllOpenJawsInternal();
                }
            }

            return new List<IEnumerable<FlightSegment>>().ToArray();
        }

        public static void OpenJawDemo(params string[] itinerary)
        {
            var flightQueryList = CreateFlightQuery(itinerary);
            var allOpenJaws = flightQueryList.AllOpenJaws();
            "+".HR(60);
            flightQueryList.FlightSegments.Select(x => x).Print("Full Itinerary");
            allOpenJaws.OJ.ToList().ForEach(x => x.Print("OpenJaws"));
            allOpenJaws.Other.Print("Other");
            "-".HR(60);
        }

        public static void HR(this string theString, int length)
        {
            Console.WriteLine("{0}", Enumerable.Repeat(theString, length).JoinToStringWith("").Substring(0, length));

        }

        public static FlightQuery CreateFlightQuery(params string[] itinerary)
        {
            return new FlightQuery
            {
                FlightSegments = itinerary.SelectMany((leg, j) =>
                {
                    var cities = leg.Split('-');
                    return cities
                        .Take(cities.Length - 1) // Skip the last one
                        .Select((city, i) =>
                            new FlightSegment
                            (
                                city,
                                cities[i + 1],
                                (j + 1) * (i + 1) + (j + 1)
                            )
                        );
                }).ToArray()
            };
        }

    }

    public class FlightQuery
    {
        public FlightSegment[] FlightSegments
        {
            get; set;
        }
    }

    public class FlightSegment
    {
        public FlightSegment(string origin, string destination, int departure)
        {
            Origin = origin;
            Destination = destination;
            Departure = departure;
        }

        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public int Departure { get; private set; }

        public override string ToString()
        {
            return string.Format($"({Origin},{Destination})");
        }
    }


}
