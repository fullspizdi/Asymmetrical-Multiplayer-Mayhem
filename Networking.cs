using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

/// <summary>
/// Networking class for handling all network operations within the game.
/// </summary>
public static class Networking
{
    private static TcpListener server;
    private static bool isRunning;

    /// <summary>
    /// Starts the server and listens for incoming connections.
    /// </summary>
    public static void StartServer()
    {
        try
        {
            IPAddress localAddr = IPAddress.Parse(Configurations.ServerIP);
            server = new TcpListener(localAddr, Configurations.ServerPort);
            server.Start();
            isRunning = true;
            Logger.Log("Server started successfully.");

            Thread listenThread = new Thread(ListenForClients);
            listenThread.Start();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to start server: {ex.Message}");
        }
    }

    /// <summary>
    /// Listens for client connections continuously.
    /// </summary>
    private static void ListenForClients()
    {
        try
        {
            while (isRunning)
            {
                TcpClient client = server.AcceptTcpClient();
                Logger.Log("Client connected.");
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error in ListenForClients: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles communication with a connected client.
    /// </summary>
    /// <param name="client">The client to communicate with.</param>
    private static void HandleClientComm(object client)
    {
        TcpClient tcpClient = (TcpClient)client;
        NetworkStream clientStream = tcpClient.GetStream();

        byte[] message = new byte[4096];
        int bytesRead;

        try
        {
            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    Logger.LogError("Error reading from client stream.");
                    break;
                }

                if (bytesRead == 0)
                {
                    Logger.Log("Client disconnected.");
                    break;
                }

                string receivedMessage = Encoding.ASCII.GetString(message, 0, bytesRead);
                Logger.Log($"Received message: {receivedMessage}");

                // Echo back the received message
                clientStream.Write(message, 0, bytesRead);
                clientStream.Flush();
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error handling client communication: {ex.Message}");
        }
        finally
        {
            tcpClient.Close();
        }
    }

    /// <summary>
    /// Stops the server.
    /// </summary>
    public static void StopServer()
    {
        try
        {
            isRunning = false;
            server.Stop();
            Logger.Log("Server stopped successfully.");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to stop server: {ex.Message}");
        }
    }
}
