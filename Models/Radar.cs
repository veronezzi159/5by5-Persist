using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    public class Radar
    {
        [JsonProperty("radar")]
        public List<Infracao> infracoes { get; set; }
    }
}
