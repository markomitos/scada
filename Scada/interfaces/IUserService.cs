using Scada.models;
using System.Linq;
using System.ServiceModel;

namespace Scada.interfaces
{
    [ServiceContract]

    public interface IUserService
    {
        [OperationContract]
        bool RegisterUser(string username, string password);

        [OperationContract]
        string LogInUser(string username, string password);

        [OperationContract]
        bool Logout(string token);
    }
}