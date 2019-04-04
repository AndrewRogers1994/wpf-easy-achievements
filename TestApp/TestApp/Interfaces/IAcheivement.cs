using TestApp.Models;

namespace TestApp.Interfaces
{
    public interface IAcheivement
    {
        void OnAcheivementProgress(BaseAcheivement acheivement);
        void OnAcheivementCompleted(BaseAcheivement acheivement);
    }
}
 