using JetBrains.Annotations;

namespace Mmu.Cca.CrossCutting.Areas.Settings.Models
{
    [PublicAPI]
    public class SecuritySettings
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}