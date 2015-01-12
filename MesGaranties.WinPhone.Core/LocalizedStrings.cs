namespace MesGaranties.WinPhone.Core
{
    /// <summary>
    /// Permet d'accéder aux ressources de chaîne.
    /// </summary>
    public class LocalizedStrings
    {
        private static Resources.Resources _localizedResources = new Resources.Resources();

        public Resources.Resources LocalizedResources { get { return _localizedResources; } }
    }
}