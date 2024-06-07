namespace IP.Application.UseCases.Image.Commands.Models
{
    public class ResizeEffectModel : EffectModel
    {
        public ResizeEffectModel()
        {
            EffectSetting = new ResizeEffectSettingModel();
        }
        public ResizeEffectModel(ResizeEffectSettingModel resizeEffectSettingModel)
        {
            EffectSetting = resizeEffectSettingModel;
        }
    }
}
