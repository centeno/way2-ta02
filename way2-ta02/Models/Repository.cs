using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using way2_ta02.Business;
using way2_ta02.Business.Service;

namespace way2_ta02.Models
{
    public class Repository
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public User Owner { get; set; }

        [JsonProperty(PropertyName = "description")]
        public String Description { get; set; }

        [JsonProperty(PropertyName = "language")]
        public String Language { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime Updated { get; set; }

        [JsonProperty(PropertyName = "contributors_url")]
        public String ContributorsUrl { get; set; }
    
        [JsonIgnore]
        public IList<User> Contributors
        {
            get
            {
                return new SearchService().getContributors(this.ContributorsUrl);
            }
        }

        public bool Favorite { get; set; }
    }
}