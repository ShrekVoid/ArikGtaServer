using GTANetworkServer;
using GTANetworkShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArikServer
{
    public class ServerManager : Script
    {
        private bool[] dimensions;
        private const int MainDimension = 0;

        public ServerManager()
        {
			Console.WriteLine("Hello");
            dimensions = new bool[API.getMaxPlayers() + 1];
            dimensions[MainDimension] = true;
            API.onPlayerFinishedDownload += API_onPlayerFinishedDownload;
            API.onClientEventTrigger += API_onClientEventTrigger;
			Console.WriteLine("Im uP");
        }

        private void API_onClientEventTrigger(Client sender, string eventName, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        private void API_onPlayerFinishedDownload(Client player)
        {
			Console.WriteLine("Someone joined");
            int dimension = GetEmptyDimension();
            dimensions[dimension] = true;

            API.setEntityDimension(player, dimension);
            API.freezePlayer(player, true);

            API.setEntityPosition(player, new Vector3(-81.12128, -824.6755, 326.084));
            API.setEntityRotation(player, new Vector3(0, 0, 154.1422));

            string msg = "~o~Welcome to Arik's test server";
            
            API.sendChatMessageToPlayer(player, msg);
            API.sendNotificationToAll(player.name + " has joined the server.");
            API.triggerClientEvent(player, "selection_start");
        }

        private int GetEmptyDimension()
        {
            return Array.IndexOf(dimensions, false);            
        }
    }
}
