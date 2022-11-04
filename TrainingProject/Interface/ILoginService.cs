using System.Threading.Tasks;
using TrainingProject.Models;

namespace TrainingProject.Interface
{
    public interface ILoginService
    {
        Task Register(LoginModels loginModels);
    }
}
