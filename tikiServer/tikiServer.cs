using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace tikiServer
{
    class tikiServer
    {

        static TcpListener serverSocket;
        static TcpClient clientSocket;
        static List<serverClient> clients = new List<serverClient>();
        private static dbHandler dbMan = new dbHandler();

        static void Main(string[] args)
        {


            //startup message
            Console.WriteLine(getTimeStamp() + "<Info> Starting TikiServer.....");
            //end startup
            //start DB Connection
            bool dbConnGood = dbMan.dbConnected();
            if (dbConnGood)
            {
                Console.WriteLine(getTimeStamp() + "<Info> Database connection is good......");
            }
            //setup server connection
            serverSocket = new TcpListener(System.Net.IPAddress.Loopback, 8989);
            clientSocket = default(TcpClient);
            serverSocket.Start();
            Console.WriteLine(getTimeStamp() + "<Info> Server started and is listening for connections on port 8989.....");
            //end setup server connection
            System.Threading.Thread listenerThread = new System.Threading.Thread(listener);
            // System.Threading.Thread messageListener = new System.Threading.Thread(recMessages);
            listenerThread.Start();
            //messageListener.Start();
        }
        static private string getTimeStamp()
        {
            DateTime sysTime = System.DateTime.Now;
            string timeStamp = string.Format("{0}/{1}/{2} {3}" +
                "", sysTime.Month,sysTime.Day,sysTime.Year, DateTime.Now.ToString("HH:mm"));

            return (timeStamp);
        }

        //listen for clients
        private static void listener()
        {
            int connectionID = 0;

            while (true)
            {
                try
                {
                    clientSocket = serverSocket.AcceptTcpClient();
                    connectionID++;
                    Console.WriteLine(getTimeStamp() + "<Info> A client connected and was assigned ID # " + connectionID + ".");
                    serverClient tempClient = new serverClient(clientSocket, connectionID);
                    clients.Add(tempClient);
                    System.Threading.Thread messageListener = new System.Threading.Thread(() => recMessages(clients[clients.Count - 1]));
                    messageListener.Start();

                }
                catch (Exception exc)
                {
                    Console.WriteLine(getTimeStamp() + "<ERROR> An error has occurred:  " + exc.StackTrace);
                }

            }
        }

        //handle messages
        private static void recMessages(serverClient myClient)
        {
            while (true)
            {

                try
                {
                    if (myClient.myClientInfo.Connected)
                    {
                        NetworkStream netStream = myClient.myClientInfo.GetStream();
                        byte[] bytesFrom = new byte[65536];
                        netStream.Read(bytesFrom, 0, myClient.myClientInfo.ReceiveBufferSize);
                        string clientMsg = System.Text.Encoding.ASCII.GetString(bytesFrom);
                        clientMsg = clientMsg.Substring(0, clientMsg.IndexOf("#tiki#"));
                        Console.WriteLine(getTimeStamp() + "<Info> Received: " + clientMsg + " from clientID: " + myClient.connectionID);
                        netStream.Flush();
                        string serverResponse = "#alert#Test received!#tiki#";
                        byte[] sendMsg = Encoding.ASCII.GetBytes(serverResponse);
                        netStream.Write(sendMsg, 0, sendMsg.Length);
                        netStream.Flush();
                        Console.WriteLine(getTimeStamp() + "Server replied to clientID: " + myClient.connectionID);
                    }
                }
                catch (Exception exc)
                {
                    //Console.WriteLine("<Warning> An error occurred but the server continues on!");
                    //terminate connection
                    myClient.myClientInfo.Close();
                    Console.WriteLine(getTimeStamp() + "Connection to client with ID: " + myClient.connectionID + " was closed.");
                    Console.WriteLine(getTimeStamp() + "Terminating message handler for clientID: " + myClient.connectionID);
                    break;
                    //Console.WriteLine(exc.StackTrace);
                }

            }
            return;
        }

        //send messages
    }
}
