namespace InnovativeSoftware.Repositories.Models.PhilipsHue
{
    public class SuccesDTO
    {
        public SuccesDTO(bool LightsStateOn)
        {
            _lightsStateOn = LightsStateOn;
        }

        public bool _lightsStateOn { get; }
    }
}