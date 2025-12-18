using Microsoft.Extensions.Options;
using wa_1235_jk_ecm_v4.Models.DecintellCommon;

namespace wa_1235_jk_ecm_v4.Interface
{

    public interface IAppSettingsService
    {
        DecintellSettings GetAppSettings();
    }

    public class AppSettingsService : IAppSettingsService
    {
        private readonly DecintellSettings _appSettings;

        public AppSettingsService(IOptions<DecintellSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public DecintellSettings GetAppSettings()
        {
            return _appSettings;
        }
    }

}
