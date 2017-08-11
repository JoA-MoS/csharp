using System;
using System.Collections.Generic;

namespace QuotingDojo.Models
{
    public class UserQuote
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quote { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public UserQuote() { }

        public UserQuote(int id, string name, string quote, DateTime created)
        {
            Id = id;
            Name = name;
            Quote = quote;
            Created = created;

        }
        public UserQuote(string name, string quote)
        {
            Name = name;
            Quote = quote;
        }

        public UserQuote(Dictionary<string, object> item) : this(int.Parse(item["id"].ToString()),
                                                                    item["name"].ToString(),
                                                                    item["quote"].ToString(),
                                                                    DateTime.Parse(item["created"].ToString())
                                                                    )
        { }

        public static List<UserQuote> ConvertListOfDictionaries(List<Dictionary<string, object>> items)
        {
            List<UserQuote> userQuotes = new List<UserQuote>();
            foreach (Dictionary<string, object> item in items)
            {
                userQuotes.Add(new UserQuote(item));
            }
            return userQuotes;
        }



    }
}
