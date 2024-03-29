﻿using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLotAPIs
{
    public class MSMQ
    {
        public void SendMessage(string msg, object value)
        {
            MessageQueue messageQueue = null;
            string description = msg;
            string path = @".\Private$\temp";

            try
            {
                if (MessageQueue.Exists(path))
                {
                    messageQueue = new MessageQueue(path);
                }
                else
                {
                    MessageQueue.Create(path);
                    messageQueue = new MessageQueue(path);
                }
                string result = msg + value;
                messageQueue.Send(result, description);
            }
            catch
            {
                throw;
            }
        }

        public string ReceiveMessage()
        {
            MessageQueue MyQueue = null;
            string result = null;
            string path = @".\Private$\temp";
            try
            {
                MyQueue = new MessageQueue(path);
                Message[] message = MyQueue.GetAllMessages();
                if (message.Length > 0)
                {
                    foreach (Message msg in message)
                    {
                        msg.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                        result = msg.Body.ToString();
                        MyQueue.Receive();
                        File.WriteAllText(@"C:\Users\Srinidhi\source\repos\ParkingLotAPIs\ParkingLotAPIs\ReceiveMessages.txt", result);
                    }
                    MyQueue.Refresh();
                }
                else
                {
                    Console.WriteLine("No Message");
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
