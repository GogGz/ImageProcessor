namespace IP.Application.UseCases.Image.Commands.Models
{
    public class BlurEffectModel : EffectModel
    {
        public BlurEffectModel()
        {
            EffectSetting = new BlurEffectSettingModel();
        }
        public BlurEffectModel(BlurEffectSettingModel resizeEffectSettingModel)
        {
            EffectSetting = resizeEffectSettingModel;
        }
    }
}
