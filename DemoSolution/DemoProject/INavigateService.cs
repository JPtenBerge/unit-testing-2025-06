
namespace DemoProject
{
    public interface INavigateService
    {
        void Next<T>(List<T> data, int? currentActiveIndex);
    }
}