using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MyTcpListener
{
    public static void Main()
    {
        TcpListener server = null;
        try
        {
            // Set the TcpListener on port 11000.
            Int32 port = 11000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);

            // Start listening for client requests.
            server.Start();

            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            String data = null;

            // Enter the listening loop.
            while (true)
            {
                Console.Write("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                TcpClient client2 = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                data = null;
                data2 = null;

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();
                NetworkStream stream2 = client2.GetStream();
                int i;
                int j;
                //initialize classes
                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Inform the players of how the game works
                    Console.WriteLine("Choose an action to take: Heavy Attack beats a Block and deals 2 damage " +
                    "Block beats a Quick Attack and heals 1" + " Quick Attack beats a Heavy Attack and deals 1 damage." +
                    " You have 10 seconds every round to choose before you are disconnected")

                    // Inform the players of their options
                    Console.WriteLine("HA = Heavy Attack");
                    Console.WriteLine("BL = Block");
                    Console.WriteLine("QA = Quick Attack");

                    // Listen for what their choice is
                    i = stream.Read(bytes, 0, bytes.Length);
                    j = stream2.Read(bytes, 0, bytes.Length);
                    // Alert the players to choose an Action
                    Console.WriteLine("Choose an action!");

                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    data2 = System.Text.Encoding.ASCII.GetString(bytes, 0, j);

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);
                }

                // Shutdown and end connection
                client.Close();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            // Stop listening for new clients.
            server.Stop();
        }


        Console.WriteLine("\nHit enter to continue...");
        Console.Read();
    }
}
