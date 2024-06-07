using IP.Domain.Enums;

namespace IP.Application.UseCases.Image.Commands.Models
{
    public abstract class EffectModel
    {
        public string Name { get; set; }
        public EffectType EffectType { get; set; }
        public virtual EffectSettingModel EffectSetting { get; set; }
    }
}
