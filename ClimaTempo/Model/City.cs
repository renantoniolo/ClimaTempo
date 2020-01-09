using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClimaTempo.Model
{
    public partial class City
    {

        [JsonProperty("results")]
        public Result[] Results { get; set; }

    }

    public partial class PlusCode
    {
        [JsonProperty("compound_code")]
        public string CompoundCode { get; set; }

        [JsonProperty("global_code")]
        public string GlobalCode { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("address_components")]
        public AddressComponent[] AddressComponents { get; set; }

        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("plus_code", NullValueHandling = NullValueHandling.Ignore)]
        public PlusCode PlusCode { get; set; }

        [JsonProperty("types")]
        public string[] Types { get; set; }
    }

    public partial class AddressComponent
    {
        [JsonProperty("long_name")]
        public string LongName { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("types")]
        public string[] Types { get; set; }
    }


}
