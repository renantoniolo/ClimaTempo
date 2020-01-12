﻿using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ClimaTempo.Model
{
    
    public partial class Weather
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("currently")]
        public Currently Currently { get; set; }

        [JsonProperty("daily")]
        public Daily Daily { get; set; }

        [JsonProperty("flags")]
        public Flags Flags { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }
    }

    public partial class Currently
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("precipIntensity")]
        public double PrecipIntensity { get; set; }

        [JsonProperty("precipProbability")]
        public double PrecipProbability { get; set; }

        [JsonProperty("precipType")]
        public string PrecipType { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("apparentTemperature")]
        public double ApparentTemperature { get; set; }

        [JsonProperty("dewPoint")]
        public double DewPoint { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("windSpeed")]
        public double WindSpeed { get; set; }

        [JsonProperty("windGust")]
        public double WindGust { get; set; }

        [JsonProperty("windBearing")]
        public long WindBearing { get; set; }

        [JsonProperty("cloudCover")]
        public double CloudCover { get; set; }

        [JsonProperty("uvIndex")]
        public long UvIndex { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("ozone")]
        public double Ozone { get; set; }
    }

    public partial class Daily
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }
    }

    public partial class Datum
    {

        [JsonIgnore]
        public string Day { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("sunriseTime")]
        public long SunriseTime { get; set; }

        [JsonProperty("sunsetTime")]
        public long SunsetTime { get; set; }

        [JsonProperty("moonPhase")]
        public double MoonPhase { get; set; }

        [JsonProperty("precipIntensity")]
        public double PrecipIntensity { get; set; }

        [JsonProperty("precipIntensityMax")]
        public double PrecipIntensityMax { get; set; }

        [JsonProperty("precipIntensityMaxTime")]
        public long PrecipIntensityMaxTime { get; set; }

        [JsonProperty("precipProbability")]
        public double PrecipProbability { get; set; }

        [JsonProperty("precipType")]
        public string PrecipType { get; set; }

        private double temperatureHigh;
        [JsonProperty("temperatureHigh")]
        public double TemperatureHigh
        {
            get { return Math.Round(temperatureHigh, 0); }
            set { temperatureHigh = value; }
        }

        [JsonProperty("temperatureHighTime")]
        public long TemperatureHighTime { get; set; }

        private double temperatureLow;
        [JsonProperty("temperatureLow")]
        public double TemperatureLow
        {
            get { return Math.Round(temperatureLow, 0); }
            set { temperatureLow = value; }
        }

        [JsonProperty("temperatureLowTime")]
        public long TemperatureLowTime { get; set; }

        [JsonProperty("apparentTemperatureHigh")]
        public double ApparentTemperatureHigh { get; set; }

        [JsonProperty("apparentTemperatureHighTime")]
        public long ApparentTemperatureHighTime { get; set; }

        [JsonProperty("apparentTemperatureLow")]
        public double ApparentTemperatureLow { get; set; }

        [JsonProperty("apparentTemperatureLowTime")]
        public long ApparentTemperatureLowTime { get; set; }

        [JsonProperty("dewPoint")]
        public double DewPoint { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("windSpeed")]
        public double WindSpeed { get; set; }

        [JsonProperty("windGust")]
        public double WindGust { get; set; }

        [JsonProperty("windGustTime")]
        public long WindGustTime { get; set; }

        [JsonProperty("windBearing")]
        public long WindBearing { get; set; }

        [JsonProperty("cloudCover")]
        public double CloudCover { get; set; }

        [JsonProperty("uvIndex")]
        public long UvIndex { get; set; }

        [JsonProperty("uvIndexTime")]
        public long UvIndexTime { get; set; }

        [JsonProperty("visibility")]
        public double Visibility { get; set; }

        [JsonProperty("ozone")]
        public double Ozone { get; set; }

        [JsonProperty("temperatureMin")]
        public double TemperatureMin { get; set; }

        [JsonProperty("temperatureMinTime")]
        public long TemperatureMinTime { get; set; }

        [JsonProperty("temperatureMax")]
        public double TemperatureMax { get; set; }

        [JsonProperty("temperatureMaxTime")]
        public long TemperatureMaxTime { get; set; }

        [JsonProperty("apparentTemperatureMin")]
        public double ApparentTemperatureMin { get; set; }

        [JsonProperty("apparentTemperatureMinTime")]
        public long ApparentTemperatureMinTime { get; set; }

        [JsonProperty("apparentTemperatureMax")]
        public double ApparentTemperatureMax { get; set; }

        [JsonProperty("apparentTemperatureMaxTime")]
        public long ApparentTemperatureMaxTime { get; set; }
    }

    public partial class Flags
    {
        [JsonProperty("sources")]
        public string[] Sources { get; set; }

        [JsonProperty("nearest-station")]
        public double NearestStation { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }
}

