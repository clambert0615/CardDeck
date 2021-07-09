using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CardDeck.Models
{
    public static class SessionHelper
    {
        public static void WriteObjectAsJson(this ISession session, string key, Deck deck)
        {
            session.SetString(key, JsonConvert.SerializeObject(deck));
        }

        public static Deck ReadObjectFromJson<Deck>(this ISession session, string key)
        {
            string jsonString = session.GetString(key);
            return JsonConvert.DeserializeObject<Deck>(jsonString);
        }
    }
}
