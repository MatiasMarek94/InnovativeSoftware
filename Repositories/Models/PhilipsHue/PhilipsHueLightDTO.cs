using System;
using Newtonsoft.Json;

namespace InnovativeSoftware.Repositories.Models.PhilipsHue
{
    public class PhilipsHueLightDTO
    {
        [JsonProperty("state")] public StateClass State { get; set; }

        [JsonProperty("swupdate")] public Swupdate Swupdate { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("modelid")] public string Modelid { get; set; }

        [JsonProperty("manufacturername")] public string Manufacturername { get; set; }

        [JsonProperty("productname")] public string Productname { get; set; }

        [JsonProperty("capabilities")] public Capabilities Capabilities { get; set; }

        [JsonProperty("config")] public Config Config { get; set; }

        [JsonProperty("uniqueid")] public string Uniqueid { get; set; }

        [JsonProperty("swversion")] public string Swversion { get; set; }

        [JsonProperty("swconfigid", NullValueHandling = NullValueHandling.Ignore)]
        public string Swconfigid { get; set; }

        [JsonProperty("productid", NullValueHandling = NullValueHandling.Ignore)]
        public string Productid { get; set; }
    }

    public partial class Capabilities
    {
        [JsonProperty("certified")] public bool Certified { get; set; }

        [JsonProperty("control")] public Control Control { get; set; }

        [JsonProperty("streaming")] public Streaming Streaming { get; set; }
    }

    public partial class Control
    {
        [JsonProperty("mindimlevel")] public long Mindimlevel { get; set; }

        [JsonProperty("maxlumen")] public long Maxlumen { get; set; }

        [JsonProperty("colorgamuttype", NullValueHandling = NullValueHandling.Ignore)]
        public string Colorgamuttype { get; set; }

        [JsonProperty("colorgamut", NullValueHandling = NullValueHandling.Ignore)]
        public double[][] Colorgamut { get; set; }

        [JsonProperty("ct", NullValueHandling = NullValueHandling.Ignore)]
        public Ct Ct { get; set; }
    }

    public partial class Ct
    {
        [JsonProperty("min")] public long Min { get; set; }

        [JsonProperty("max")] public long Max { get; set; }
    }

    public partial class Streaming
    {
        [JsonProperty("renderer")] public bool Renderer { get; set; }

        [JsonProperty("proxy")] public bool Proxy { get; set; }
    }

    public partial class Config
    {
        [JsonProperty("archetype")] public string Archetype { get; set; }

        [JsonProperty("function")] public Function Function { get; set; }

        [JsonProperty("direction")] public Direction Direction { get; set; }

        [JsonProperty("startup")] public Startup Startup { get; set; }
    }

    public partial class Startup
    {
        [JsonProperty("mode")] public StartupMode Mode { get; set; }

        [JsonProperty("configured")] public bool Configured { get; set; }
    }

    public partial class StateClass
    {
        [JsonProperty("on")] public bool On { get; set; }

        [JsonProperty("bri")] public long Bri { get; set; }

        [JsonProperty("alert")] public Alert Alert { get; set; }

        [JsonProperty("mode")] public StateMode Mode { get; set; }

        [JsonProperty("reachable")] public bool Reachable { get; set; }

        [JsonProperty("hue", NullValueHandling = NullValueHandling.Ignore)]
        public long? Hue { get; set; }

        [JsonProperty("sat", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sat { get; set; }

        [JsonProperty("effect", NullValueHandling = NullValueHandling.Ignore)]
        public Alert? Effect { get; set; }

        [JsonProperty("xy", NullValueHandling = NullValueHandling.Ignore)]
        public double[] Xy { get; set; }

        [JsonProperty("colormode", NullValueHandling = NullValueHandling.Ignore)]
        public string Colormode { get; set; }

        [JsonProperty("ct", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ct { get; set; }
    }

    public partial class Swupdate
    {
        [JsonProperty("state")] public StateEnum State { get; set; }

        [JsonProperty("lastinstall")] public DateTimeOffset Lastinstall { get; set; }
    }

    public enum Direction
    {
        Downwards,
        Omnidirectional,
        Upwards
    };

    public enum Function
    {
        Decorative,
        Functional,
        Mixed
    };

    public enum StartupMode
    {
        Safety
    };

    public enum Manufacturername
    {
        SignifyNetherlandsBV
    };

    public enum Alert
    {
        None,
        Select
    };

    public enum StateMode
    {
        Homeautomation
    };

    public enum StateEnum
    {
        Noupdates
    };
}