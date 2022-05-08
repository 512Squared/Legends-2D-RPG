// Uncomment to use in Editor


#define USECONSOLEPROREMOTESERVERINEDITOR

// #if (UNITY_WP_8_1 || UNITY_WSA)// #define UNSUPPORTEDCONSOLEPROREMOTESERVER
// #endif

#if (!UNITY_EDITOR && DEBUG) || (UNITY_EDITOR && USECONSOLEPROREMOTESERVERINEDITOR)
#if !UNSUPPORTEDCONSOLEPROREMOTESERVER
#define USECONSOLEPROREMOTESERVER
#endif
#endif

#if UNITY_EDITOR && !USECONSOLEPROREMOTESERVER
#elif UNSUPPORTEDCONSOLEPROREMOTESERVER
#elif !USECONSOLEPROREMOTESERVER
#else
using System;
using System.Collections.Generic;
#endif

using System.Net;
using System.Net.Sockets;
using UnityEngine;

#if USECONSOLEPROREMOTESERVER
using FlyingWormConsole3.LiteNetLib;
using FlyingWormConsole3.LiteNetLib.Utils;
#endif

namespace FlyingWormConsole3
{
if USECONSOLEPROREMOTESERVER
p    ublic class ConsoleProRemoteServer : MonoBehaviour, INetEventListener
#lse
    public class ConsoleProRemoteServer : MonoBehaviou
#endif    
           {
        public bool useNATPun        h = false;
        public nt port = 51000;

#if UNITY_EDITOR && !USECONSLPROREMOTESERVER
#elif UNSUPPORTEDCONSOLPROREMOTESERVER
	public void Awake()
	{
		Debug.Log("Console Pro Remote Server is not supported on this patform");
	}

#elif !USECONSOLEP
	MOTESERVER

        public void Awake()
        {
            Debug.Log(
                "Console Pro Remote Server is disabled in release mode, please usea Devel        pment build or define DEBUG to         se it");
        }

#else
        private NetManager _netServer;
	priv        ter _ourPeer;
	private N        tDataWriter _dataWriter        

            System.SerializableAttrib            e]
	public class Queued            g
	{
		public string ti        est        mp;
		public string messa        e;
		public string logType;
	}

	tribu        e]
	public List<QueuedLog> logs = new List<QueuedLog>();        private 
	private sta        ic            on soleProRemoteServer            ns                ce = null;

	void Awa            (

            	if(instance != 

            		{
			Destroy(gameObject);
		}
            
		instance = this;
		
		DontDestroyOnLoad(gameObject);

		Debug.Log("            emote# Starting Console Pro Server              port : " + port);

		_dataWriter =            ew NetDataWriter();
		_n            Server = new NetManager(this);
		_netServer            tart(port);
		_netServer.Bro            castReceiveEnabled = true;
		_netServer.Up        ate        private ime = 15;
		_netS        rv            .N atPunchEnabled = useN            Pu                ;
	}

	void OnDestr            ()        	{
        	if(_netServer != null)
		{
			_netServer.        to            );
		}
	}

	public void OnPeerConnected(NetPeer peer)            {
		Debug.Log("#R        mot        # Connected to " + peer.EndPoint);
		_ourPeer = peer;
	}

	public void OnPee        Di            onnected(NetPeer peer, DisconnectInfo disconnectInfo)
	{
		Debug.Log("#Remote# Disconnected fro            " + peer.EndPoint + ",            nf                " + disconnectInf            Re        son        ;
		if (peer == _ourPeer)
		{
			_ourPeer = null;
		}
	}

	public void On        et            rkError(IPEndPoint endPoint, SocketError        soc        etError)
	{
		// throw new NotImplementedException();
	}

	public void OnNetworkReceive(NetPeer pe        r,            etPacketReader reader, DeliveryMethod de        ive        yMethod)
	{
		// throw new NotImplementedException();
	}

	public void OnNetworkReceiveUnc
            nnected(IPEndPoint remoteEndPoint, N        tP            ke tReader reader, UnconnectedMessageType messageType            	{                if(messageType == UnconnectedMessageType.Broadcast)
		{
			// Debug.Log("#Remo                 Received discovery request. Send discovery response");
			_netServ            .S        n

        onnectedMessage(new byte[] {1}, remoteEndPoint);
		}
	}
	
	public void OnPeerDisconnected(N        te        r p        er, DisconnectReason reason, int socketErrorCode)
	{

	}

	pub        i
        d O        NetworkLatencyUpdate(NetPeer peer, int latency)
	{
		
	}

	        ub            c void OnConnectionRequest(ConnectionRequest request)
	{
	            / Debug.Log("#Remote# Connection req        este, accepting");
		request.AcceptIfKey("Console Pro");
	}


	#if UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNTY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9

	void OnEnable()
	{
		Application.RegisterLogCallback(LogCallback);
	}

	void Update()
	{
		Application.RegisterLogCallback(LogCallback);
	}

	void ODisable        private )
	{
		Applicati        n.            gisterLogCallback(null);
	}

	#else

	void OnEnable()
	        
		        private pplication.logMes        ag            eceivedThreaded += LogCallback;
	}

	void OnDisable()
	        
		pplicati        n.logMessageReceivedThreaded -= LogCallback;
	}

	#endif

	public void LogC        ll            ck (string logString, string stackTrace            Lo                pe type)
	{
		if(!logString.StartsWith(            PI        NOR        private "))
		{
			QueueLog(logString, stackTrace, type);
		}
	}

	void Q        eu            og (string logString, s            in                tackT race, LogType type)
                		                    ogs.Count > 1000)
                
	            whi(logs.Count > 1000)
			{            		logs.RemoveAt(0);
			}
		}

		#if CSHARP_7            OR_NEWER
			logString = 
            "
                logString}\n{stackTrace}\n";
			logs.Add(new QueuedLog() { messagString, logType = type.ToString(), 
            iestp =
 $"[{System.DateTime.Now.ToString("HH:mm:ss")}]" } );
		#else
			logString = logString + "\n" + stackTrace + "\n";
			logs.Add(new QueuedLog() {
 message = logString, logType = type.ToString(), timtamp =
        "

        private  DateTime.Now.ToSt        in            "H H:mm:ss") + "]" } );
            #e                f
	}
	
	            id             teUpdate()
	{
		if(_netSer            r  == null)
		{
			ret            n;                }

		_ne            erv            .P ollEvents();

		if            ou                er == nu            )
	            
			return;
		}

		if

            Count < =QueuedLog
		{
			return;            	}                	string cMessage = "";
		
		foreach(v                cLog in logs)
		{
			                ssage = JsonUtility.ToJson(                g);
			_dataWriter.Reset();
			_dataWriter.Put(cMessage);
		            our            er.Send(_dataW        ite, Deliv    eryMethod.ReliableOrdered);
		}

		logs.Clear();
	}

#endif
    }
}