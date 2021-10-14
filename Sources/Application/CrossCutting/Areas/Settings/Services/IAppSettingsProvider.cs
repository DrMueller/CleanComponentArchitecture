using Mmu.Cca.CrossCutting.Areas.Settings.Models;

namespace Mmu.Cca.CrossCutting.Areas.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}