using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Race
{
    using Utilities;
    public class Race : IRace
    {
        private string racename;
        private int numberofLaps;
        private readonly ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            pilots = new List<IPilot>();
            TookPlace = false;

        }
        public string RaceName
        {
            get => this.racename;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) ||  value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this.racename = value;
            }
        }

        public int NumberOfLaps
        {
            get => numberofLaps;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberofLaps = value;
            }
        }


        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        => this.pilots.Add(pilot);

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {RaceName} race has: ");
            sb.AppendLine($"Participants: {pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            string tookplace = TookPlace == true ? "Yes" : "No";
            sb.Append($"Took place: {tookplace}");

            return sb.ToString();

        }
    }
}
