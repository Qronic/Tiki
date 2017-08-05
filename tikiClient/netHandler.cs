using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace tikiClient
{
    static class netHandler
    {
        static TcpClient clientSocket = new TcpClient();
        static public bool loggedIn = false;
        static public string errorMsg = "";
        static private string username = "";
        static private string password = "";


        public static void connect(string userName, string passWord)
        {
            //hardcoded for now
            username = userName;
            password = passWord;
            if (!clientSocket.Connected)
            {
                clientSocket.Connect("127.0.0.1", 8989);

            }
            if (clientSocket.Connected)
            {
                //login
                string myMsgToSend = string.Format("#login#{0}#delim#{1}#tiki#", username, password); //tiki messages begin with a request tag, here #login# and end with a #tiki# tag
                msgHandler(myMsgToSend);
            }
        }

        //handleMsg
        public static void msgHandler(string msg)
        {
            //while (clientSocket.Connected)
            // {
            try
            {
                NetworkStream netStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(msg);
                netStream.Write(outStream, 0, outStream.Length);
                netStream.Flush();
                byte[] inStream = new byte[65536];
                netStream.Read(inStream, 0, clientSocket.ReceiveBufferSize);
                string serverResponse = Encoding.ASCII.GetString(inStream);
                serverResponse = serverResponse.Substring(0, serverResponse.IndexOf("#tiki#"));
                //System.Windows.Forms.MessageBox.Show("Client received: " + serverResponse + " from server!");
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("<ERROR>: " + exc.StackTrace);
            }

            //}



        }

        private static void serverMessageManager(string msg)
        {
            string msgTag = msg.Substring(0, msg.IndexOf('#')); //gets the message tag, so we know what we are doing
            switch (msg)
            {
                case "loggedin":
                    //System.Windows.Forms.MessageBox.Show("You have been logged in!");
                    loggedIn = true;
                    break;
                case "nouser":
                    //System.Windows.Forms.MessageBox.Show("Username not found!");
                    errorMsg = "Username not found!";
                    break;
                default:
                    break;
            }
        }
    }
}
