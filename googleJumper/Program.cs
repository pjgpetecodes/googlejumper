using System;
using System.Diagnostics;
using System.Threading;
using nanoFramework.Networking;

namespace googleJumper
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            if (!ConnectToWifi())
            {
                Debug.WriteLine("Wifi Failed!");
            }

            Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }

        public static bool ConnectToWifi()
        {

            // Connect the ESP32 Device to the Wi-Fi and check the connection...
            Debug.WriteLine("Program Started, connecting to WiFi.");

            CancellationTokenSource cs = new(60000);
            var success = WifiNetworkHelper.Reconnect(requiresDateTime: true, token: cs.Token);

            if (!success)
            {
                Debug.WriteLine($"Can't connect to wifi: {WifiNetworkHelper.Status}");
                if (WifiNetworkHelper.HelperException != null)
                {
                    Debug.WriteLine($"NetworkHelper.ConnectionError.Exception");
                }
            }

            Debug.WriteLine($"Date and time is now {DateTime.UtcNow}");
            return success;
        }
    }
}
