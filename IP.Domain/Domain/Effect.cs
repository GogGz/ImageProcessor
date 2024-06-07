using IP.Domain.Enums;

namespace IP.Domain.Domian
{
    public class Effect : Entity<int>
    {
        public string Name { get; set; }
        public string Setting { get; set; } // Json for storing Dynamic settings
        public EffectType EffectType { get; set; }
    }
}
