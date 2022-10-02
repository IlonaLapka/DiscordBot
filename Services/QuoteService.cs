using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
    public class QuoteService
    {
        private List<string> Quotes = new List<string>();
        public QuoteService()
        {
            Quotes = File.ReadAllLines("../../../Quotes.txt").ToList();
        }

        public string GetQuote()
        {
            Random random = new Random();
            return Quotes[random.Next(0, Quotes.Count) - 1];
        }
    }
}
