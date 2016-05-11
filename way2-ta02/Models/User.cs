using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using way2_ta02.Business;
using way2_ta02.Business.Service;

namespace way2_ta02.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "login")]
        public String Login { get; set; }

        [JsonProperty(PropertyName = "avatar_url")]
        public String ProfilePictureUrl { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public String Email { get; set; }

        [JsonProperty(PropertyName = "location")]
        public String Location { get; set; }

        public static User Load(String user)
        {
            try
            {
                User testUser = HttpContext.Current.Session["user"] as User;

                if (testUser == null || testUser.Login != user)
                    HttpContext.Current.Session["user"] = new SearchService().getUser(user);

                return HttpContext.Current.Session["user"] as User;
            }
            catch (NullReferenceException) {
                return new SearchService().getUser(user);
            }
        }
    }
}