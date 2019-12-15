using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class ClientStory : MonoBehaviour
{
    #region private members 	
    private TcpClient socketConnection;
    private Thread clientReceiveThread;
    #endregion
    // Use this for initialization 	
    public GameObject hand;
    public GameObject weapon;
    public GameObject headgear1;
    public GameObject headgear2;
    public GameObject head;
    public DeerRun Caveman;
    public string animfile;
    public volatile String serverMessage;
    void Start()
    {
        ConnectToTcpServer();
    }
    // Update is called once per frame
    void Update()
    {
        if (serverMessage!=null && serverMessage!="" && serverMessage.Length>0)

        {

            process(serverMessage);
            serverMessage = null;
        }
    }
    /// <summary> 	
    /// Setup socket connection. 	
    /// </summary> 	
    private void ConnectToTcpServer()
    {

        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
      
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }


    }
    /// <summary> 	
    /// Runs in background clientReceiveThread; Listens for incomming data. 	
    /// </summary>     
    private void ListenForData()
    {
        try
        {
            socketConnection = new TcpClient("127.0.0.1", 65432);
            Byte[] bytes = new Byte[1024];
            while (true)
            {
                // Get a stream object for reading 				
                using (NetworkStream stream = socketConnection.GetStream())
                {
                    int length;
                    // Read incomming stream into byte arrary. 					
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        // Convert byte array to string message. 						
                       serverMessage = Encoding.ASCII.GetString(incommingData);


                        // CHARACTER hunter|HEADGEAR cap|threw|WEAPON spear


                    }
                    
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }
    /// <summary> 	
    /// Send message to server using socket connection. 	
    /// </summary> 	
    private void SendMessage()
    {
        if (socketConnection == null)
        {
            return;
        }
        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                string clientMessage = "This is a message from one of your clients.";
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("Client sent his message - should be received by server");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    public void process(String serverMessage)
    {
        AttachToPart comp = gameObject.GetComponent<AttachToPart>();
        String[] token = serverMessage.Split('|');
        Debug.Log( "tokeeeeeen"+token);
        if (token[1].Split(' ')[1].Equals("cap"))
        {
            headgear1 = Instantiate(headgear1);
            comp.toattach = headgear1;
            
            comp.parent = head;
            comp.attach(new Vector3(2.28f,0,0),false);

        }
        else
        {
            headgear2 = Instantiate(headgear2);
            comp.toattach = headgear2;
            comp.parent = head;
            comp.attach(new Vector3(2.28f, 0, 0),false);

        }
        if (token.Length > 2)
        {
            if (token[2].Equals("threw"))
            {
                animfile = "Caveman\\Spear Throw Straight.anim";
            }
            else
            {
                animfile = "Caveman\\Walking.anim";
            }
           

            if (token.Length > 3)
            {
                weapon = Instantiate(weapon);
                comp.toattach = weapon;
                comp.parent = hand;
                comp.attach(new Vector3(1.6f, 1f, 0), true);
            }
        }

        Caveman.addAnimation(false, 5f, 0, animfile, 2f, true);
        Caveman.playStart();



    }
}