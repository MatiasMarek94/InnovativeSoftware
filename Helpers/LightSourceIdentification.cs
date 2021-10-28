using System;

namespace InnovativeSoftware.Helpers
{
    public class ParameterDescriptionAttribute : Attribute
    {
        public ArgumentType ArgumentType { get; }
        
        public ParameterDescriptionAttribute(ArgumentType argumentType)
        {
            ArgumentType = argumentType;
        }
        
        //ReturnsSmartLightFabricant ? 
        

    }
    public enum ArgumentType
    {
        PhilipsHue = 0
    }
}