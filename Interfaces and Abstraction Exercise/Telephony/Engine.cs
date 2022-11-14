using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly StationaryPhone stationaryPhone;
        private readonly Smartphone smartphone;

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        private Engine()
        {
            stationaryPhone = new StationaryPhone();
            smartphone = new Smartphone();
        }

        public void Start()
        {
            string[] phoneNumbers = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach(string phoneNumber in phoneNumbers)
            {
                if (!ValidateNumber(phoneNumber))
                {
                    writer.WriteLine("Invalid number!");
                }
                else if(phoneNumber.Length == 10)
                {
                    writer.WriteLine(smartphone.Call(phoneNumber));
                }
                else if(phoneNumber.Length == 7)
                {
                    writer.WriteLine(stationaryPhone.Call(phoneNumber));
                }

            }
            foreach(string url in urls)
            {
                if (!ValidateUrl(url))
                {
                    writer.WriteLine("Invalid URL!");
                }
                else
                {
                    writer.WriteLine(smartphone.BrowseURL(url));
                }
            }

        }
        private bool ValidateNumber(string number)
        {
            foreach(char ch in number)
            {
                if (!Char.IsDigit(ch))
                {
                    return false;
                }

            }

            return true;
        }
        private bool ValidateUrl(string url)
        {
            foreach (char ch in url)
            {
                if (Char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
