using DyDrums.Services;

namespace DyDrums.Controllers
{
    public class ConnectionController
    {
        private readonly SerialManager serialManager;

        public ConnectionController(SerialManager serialManager)
        {
            this.serialManager = serialManager;

        }
    }
}
