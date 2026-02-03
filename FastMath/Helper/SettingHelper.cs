using FastMath.Core.Factories;
using FastMath.Core.Helpers;
using FastMath.Core.Interfaces;
using FastMath.Core.Models;
using FastMath.Core.Models.OperationsWorld.OperationParameters;
using FastMath.Core.Models.UserConfiguration;
using FastMath.Serialization;

namespace FastMath.Helper
{
    public class SettingHelper<T> : IGetUserSetting
        where T : OperationSettingParametersBase, new()
    {
        public OperationSettingParametersBase OperationParameter { get; init; }
        public IDataLayer<UserSettingCollection> UserSetting { get; }

        public SettingHelper(ICurrentUser currentUser, 
                            [FromKeyedServices(DataLayerKeys.xml)] IDataLayer<UserSettingCollection> userSetting, 
                            ICreate<OperationSettingParametersBase> originParameterFactory)
        {
            UserSetting = userSetting;
            string userName = currentUser.TheUser;

            UserSettingCollection AllConfigs = UserSetting.Read();

            // looking specific for user configs
            var tempUserSettings = AllConfigs.Users.FirstOrDefault(v => v.Name == userName)!;

            bool saveSettingsRequired = false;
            if (tempUserSettings is null)
            {
                tempUserSettings = new() { Name = userName };
                saveSettingsRequired = true;
            }

            // get user configs
            UserSetting UserSettings = tempUserSettings;

            T? operationParameters = UserSettings.ParametersList.OfType<T>().FirstOrDefault();

            if (operationParameters is null)
            {
                T parameter = originParameterFactory.Create(typeof(T)) as T
                                ?? throw new OperationCreationFactoryException($"Factory doesn't have match for type: {typeof(T)}");

                operationParameters = parameter;
                UserSettings.ParametersList.Add(operationParameters);
                saveSettingsRequired = true;
            }

            OperationParameter = operationParameters;

            if (saveSettingsRequired is true)
            {
                UserSetting.Write(AllConfigs);
            }
        }

        public SimpleOperationBaseInitData GetUsableSettings()
        {
            var NbSuggestedElement = OperationParameter.NbSuggested;

            var OperandOption1 = OperandCreationParameterHelper.Create(OperationParameter.RangeParameterLeft!);
            var OperandOption2 = OperandCreationParameterHelper.Create(OperationParameter.RangeParameterRight!);

            return new SimpleOperationBaseInitData(NbSuggestedElement, OperandOption1, OperandOption2);
        }
    }
}
