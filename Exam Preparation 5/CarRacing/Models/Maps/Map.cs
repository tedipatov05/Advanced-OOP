using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Racers.Contracts;
    using Contracts;
    using Utilities.Messages;
    public class Map : IMap
    {
        public Map()
        {

        }
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            var racerOneMultiplier = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
            var racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneMultiplier;

            var racerTwoMultiplier = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
            var racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoMultiplier;

            IRacer winner;

            winner = racerOneChanceOfWinning > racerTwoChanceOfWinning ? racerOne : racerTwo;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }
    }
}
