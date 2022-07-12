using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Framly
{
    public class FYLocalization : MonoBehaviour
    {
        [SerializeField] int _localizationIndex = 0;
        IEnumerator Start()
        {
            yield return LocalizationSettings.InitializationOperation;
            SetLocale(_localizationIndex);
        }

        public void SetLocale(int index = 0)
        {
            _localizationIndex = index;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localizationIndex];
        }
    }
}