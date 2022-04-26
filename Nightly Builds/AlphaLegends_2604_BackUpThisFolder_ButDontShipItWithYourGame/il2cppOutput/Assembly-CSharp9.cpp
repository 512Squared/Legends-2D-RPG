#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>


template <typename T1>
struct VirtualActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1>
struct VirtualFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3>
struct VirtualFuncInvoker3
{
	typedef R (*Func)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename R, typename T1, typename T2, typename T3, typename T4, typename T5>
struct VirtualFuncInvoker5
{
	typedef R (*Func)(void*, T1, T2, T3, T4, T5, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, p1, p2, p3, p4, p5, invokeData.method);
	}
};
template <typename T1>
struct GenericVirtualActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
struct InterfaceActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename R>
struct InterfaceFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1>
struct GenericInterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct InvokerActionInvoker2;
template <typename T1, typename T2>
struct InvokerActionInvoker2<T1*, T2*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2)
	{
		void* params[2] = { p1, p2 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};
template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3;
template <typename T1, typename T2, typename T3>
struct InvokerActionInvoker3<T1*, T2*, T3*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2, T3* p3)
	{
		void* params[3] = { p1, p2, p3 };
		method->invoker_method(methodPtr, method, obj, params, NULL);
	}
};

// System.Threading.AsyncLocal`1<System.Globalization.CultureInfo>
struct AsyncLocal_1_t1D3339EA4C8650D2DEDDF9553E5C932B3DC2CCFD;
// System.Collections.ObjectModel.Collection`1<System.Net.NetworkInformation.GatewayIPAddressInformation>
struct Collection_1_tAA30BCAC05A7C0F54CEE311DF69028C96E69A079;
// System.Collections.ObjectModel.Collection`1<System.Net.NetworkInformation.UnicastIPAddressInformation>
struct Collection_1_tFCFDED5321BE15CA8D30D61CF04DDE693BB0CB5B;
// System.Collections.Generic.Dictionary`2<System.Net.IPEndPoint,FlyingWormConsole3.LiteNetLib.ConnectionRequest>
struct Dictionary_2_t1CE654E2C4E08E33B3C449A5971A7ECB484C6A68;
// System.Collections.Generic.Dictionary`2<System.Net.IPEndPoint,FlyingWormConsole3.LiteNetLib.NetPeer>
struct Dictionary_2_t6DAA31C75893B6F025B1715061A316C828EA35EB;
// System.Collections.Generic.Dictionary`2<System.Net.IPEndPoint,FlyingWormConsole3.LiteNetLib.Utils.NtpRequest>
struct Dictionary_2_tD4FA8A8923573ECC57088CBAEC0E4333709B90B7;
// System.Collections.Generic.Dictionary`2<System.Int32,System.Text.Encoding>
struct Dictionary_2_t87EDE08B2E48F793A22DE50D6B3CC2E7EBB2DB54;
// System.Collections.Generic.Dictionary`2<System.Object,System.Object>
struct Dictionary_2_t14FE4A752A83D53771C584E4C8D14E01F2AFD7BA;
// System.Collections.Generic.Dictionary`2<System.Type,FlyingWormConsole3.LiteNetLib.Utils.NetSerializer/CustomType>
struct Dictionary_2_t5EE36A10F9DEF39A9016F3998D768275F9B3C326;
// System.Collections.Generic.Dictionary`2<System.UInt16,System.UInt16>
struct Dictionary_2_tA7395733826D49EAFAAFD65320953B6D32A24EA4;
// System.Collections.Generic.Dictionary`2<System.UInt16,FlyingWormConsole3.LiteNetLib.NetPeer/IncomingFragments>
struct Dictionary_2_t59D759394C709A891846E81AECDFCDBAE94746A1;
// System.Collections.Generic.Dictionary`2<System.UInt64,System.Object>
struct Dictionary_2_t01A465CD199FB14D59FEC2DC7DDE76D2CD0A09F4;
// System.Collections.Generic.Dictionary`2<System.UInt64,FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate>
struct Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951;
// System.EventHandler`1<System.Net.Sockets.SocketAsyncEventArgs>
struct EventHandler_1_t5D3FC4609BD8133ED1226D6D49A1D8076B16A9ED;
// System.Collections.Generic.IEqualityComparer`1<System.Type>
struct IEqualityComparer_1_t0C79004BFE79D9DBCE6C2250109D31D468A9A68E;
// System.Collections.Generic.IEqualityComparer`1<System.UInt64>
struct IEqualityComparer_1_t958EAC5D5BD188327B4736D6F82A08EA1476A4C8;
// System.Collections.Generic.IList`1<System.String>
struct IList_1_t97B3B39CDB830632CF9A846DD5FD149D333D9EDB;
// System.Collections.Generic.Dictionary`2/KeyCollection<System.Type,FlyingWormConsole3.LiteNetLib.Utils.NetSerializer/CustomType>
struct KeyCollection_t4EEF82D16025086C3E59199E5D415BDCC8A8ED0B;
// System.Collections.Generic.Dictionary`2/KeyCollection<System.UInt64,FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate>
struct KeyCollection_tE9AC5F7BFA71AD32B3C09BFA088AA4BA6EE8613D;
// System.Collections.Generic.List`1<FlyingWormConsole3.LiteNetLib.NetPeer>
struct List_1_tD7F9F96C55C6BCA0B8046273C342507E6FD1B006;
// System.Collections.Generic.List`1<System.Object>
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D;
// System.Collections.Generic.List`1<System.String>
struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD;
// System.Collections.Generic.Queue`1<FlyingWormConsole3.LiteNetLib.BaseChannel>
struct Queue_1_tD09EA56D6BAC52D37599D139B72F2D34213FC22A;
// System.Collections.Generic.Queue`1<System.Int32>
struct Queue_1_tCA24E420CB13C6411AEFC3ECE9E62219F7937A1E;
// System.Collections.Generic.Queue`1<FlyingWormConsole3.LiteNetLib.NetEvent>
struct Queue_1_t7BFD6CD7312A946FFBF0334977E496A4D6E5787C;
// System.Collections.Generic.Queue`1<FlyingWormConsole3.LiteNetLib.NetPacket>
struct Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C;
// System.Collections.Generic.Queue`1<System.Object>
struct Queue_1_tE9EF546915795972C3BFD68FBB8FA859D3BAF3B5;
// System.Net.Sockets.Socket/TaskSocketAsyncEventArgs`1<System.Net.Sockets.Socket>
struct TaskSocketAsyncEventArgs_1_tEB937620E5B15D91E5BFEFFA707CF800930F8401;
// System.Threading.Tasks.Task`1<System.Int32>
struct Task_1_t4C228DE57804012969575431CFF12D57C875552D;
// System.Collections.Generic.Dictionary`2/ValueCollection<System.Type,FlyingWormConsole3.LiteNetLib.Utils.NetSerializer/CustomType>
struct ValueCollection_tF8FDE74E8E6861A823329F130B350B828B8FBA1D;
// System.Collections.Generic.Dictionary`2/ValueCollection<System.UInt64,FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate>
struct ValueCollection_t2577CC584993ADC75878EE7A1FB656005AA10306;
// System.Collections.Generic.Dictionary`2/Entry<System.Type,FlyingWormConsole3.LiteNetLib.Utils.NetSerializer/CustomType>[]
struct EntryU5BU5D_t156A27B7E6145C1383AC9C9880E8147A90CCFB38;
// System.Collections.Generic.Dictionary`2/Entry<System.UInt64,FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate>[]
struct EntryU5BU5D_t762C9873E03ABD2EAE235E73ECDBA51FCB9EFAD9;
// FlyingWormConsole3.LiteNetLib.BaseChannel[]
struct BaseChannelU5BU5D_t71E8F4647253D2712361CB1E8733BB197E2FE0B9;
// System.Boolean[]
struct BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4;
// System.Byte[]
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
// System.Double[]
struct DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE;
// System.Net.IPAddress[]
struct IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D;
// System.Int16[]
struct Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB;
// System.Int32[]
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
// System.Int64[]
struct Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D;
// System.IntPtr[]
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
// FlyingWormConsole3.LiteNetLib.NetPacket[]
struct NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F;
// FlyingWormConsole3.LiteNetLib.NetPeer[]
struct NetPeerU5BU5D_t6ACD82DA7A2921F61314AD481D4FEEE66153A96C;
// System.Net.NetworkInformation.NetworkInterface[]
struct NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080;
// System.Object[]
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;
// System.SByte[]
struct SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913;
// System.Single[]
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
// System.String[]
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
// System.UInt16[]
struct UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83;
// System.UInt32[]
struct UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA;
// System.UInt64[]
struct UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299;
// FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket[]
struct PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003;
// System.ArgumentException
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263;
// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C;
// System.Threading.AutoResetEvent
struct AutoResetEvent_t7F792F3F7AD11BEF7B411E771D98E5266A8CE7C0;
// FlyingWormConsole3.LiteNetLib.BaseChannel
struct BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215;
// System.Globalization.CodePageDataItem
struct CodePageDataItem_t52460FA30AE37F4F26ACB81055E58002262F19F2;
// FlyingWormConsole3.LiteNetLib.Layers.Crc32cLayer
struct Crc32cLayer_t799B2010955281BD2F31EBA62AF0091A14642304;
// System.Globalization.CultureInfo
struct CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0;
// System.Text.DecoderFallback
struct DecoderFallback_t7324102215E4ED41EC065C02EB501CB0BC23CD90;
// System.Delegate
struct Delegate_t;
// System.DelegateData
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
// System.Text.EncoderFallback
struct EncoderFallback_tD2C40CE114AA9D8E1F7196608B2D088548015293;
// System.Text.Encoding
struct Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095;
// System.Net.EndPoint
struct EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564;
// System.Exception
struct Exception_t;
// System.Threading.ExecutionContext
struct ExecutionContext_t9D6EDFD92F0B2D391751963E2D77A8B03CB81710;
// System.IAsyncResult
struct IAsyncResult_t7B9B5A0ECB35DCEC31B8A8122C37D687369253B5;
// FlyingWormConsole3.LiteNetLib.IDeliveryEventListener
struct IDeliveryEventListener_t3D281039C1CA6DC86390701B72CF99F1F0A64E95;
// System.Collections.IDictionary
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
// FlyingWormConsole3.LiteNetLib.INetEventListener
struct INetEventListener_t01A5B932375BFB019A4B3B4DB3BBDFA0A5A36F14;
// FlyingWormConsole3.LiteNetLib.INtpEventListener
struct INtpEventListener_t7DF6B598AA8CD8CD36CE1AC5CD995369883ACB21;
// System.IOAsyncCallback
struct IOAsyncCallback_tDBBA8BBDA6B203613680E77BD4AD6320A1268388;
// System.Net.IPAddress
struct IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484;
// System.Net.IPEndPoint
struct IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB;
// System.Net.IPHostEntry
struct IPHostEntry_tAAAEB0F40DB9F28BE601B5FE7DA1D76191C94490;
// System.Security.Principal.IPrincipal
struct IPrincipal_tE7AF5096287F6C3472585E124CB38FF2A51EAB5F;
// System.Threading.InternalThread
struct InternalThread_tF40B7BFCBD60C82BD8475A22FF5186CA10293687;
// System.InvalidOperationException
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB;
// FlyingWormConsole3.LiteNetLib.Utils.InvalidTypeException
struct InvalidTypeException_t79DD32863BA9B2D1CE6C8E068D8E97ADABA8C741;
// System.LocalDataStoreHolder
struct LocalDataStoreHolder_t789DD474AE5141213C2105CE57830ECFC2D3C03F;
// System.LocalDataStoreMgr
struct LocalDataStoreMgr_t205F1783D5CC2B148E829B5882E5406FF9A3AC1E;
// System.Reflection.MethodInfo
struct MethodInfo_t;
// System.MulticastDelegate
struct MulticastDelegate_t;
// FlyingWormConsole3.LiteNetLib.NatPunchModule
struct NatPunchModule_t81631A48708194B218EF85A59D6E12CC58334752;
// FlyingWormConsole3.LiteNetLib.Utils.NetDataReader
struct NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54;
// FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter
struct NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA;
// FlyingWormConsole3.LiteNetLib.NetEvent
struct NetEvent_tA0FD096AF6E78990A09C560EC724A2E7D8D4676E;
// FlyingWormConsole3.LiteNetLib.NetManager
struct NetManager_t8B66EC65CAFC8455974B02C8945955F328277191;
// FlyingWormConsole3.LiteNetLib.NetPacket
struct NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED;
// FlyingWormConsole3.LiteNetLib.NetPacketPool
struct NetPacketPool_tECE1CA68CDADE3C4E45A5FBCA8B25CC30F62DBF3;
// FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor
struct NetPacketProcessor_tC008551263AC0F46812FF0AE3127ABF0D975E873;
// FlyingWormConsole3.LiteNetLib.NetPeer
struct NetPeer_t882A117D59790FE03D2D349C441B30690D04637B;
// FlyingWormConsole3.LiteNetLib.Utils.NetSerializer
struct NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9;
// FlyingWormConsole3.LiteNetLib.NetSocket
struct NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4;
// FlyingWormConsole3.LiteNetLib.NetStatistics
struct NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20;
// System.Net.NetworkInformation.NetworkInterface
struct NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A;
// FlyingWormConsole3.LiteNetLib.Utils.NtpPacket
struct NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA;
// FlyingWormConsole3.LiteNetLib.Utils.NtpRequest
struct NtpRequest_tFFBFC24434D3C3F9B5A288721A636B37D4382399;
// FlyingWormConsole3.LiteNetLib.Layers.PacketLayerBase
struct PacketLayerBase_t45CF70BC52F3CBAE7EC7F885A16F3FB7753C23C6;
// System.Threading.ParameterizedThreadStart
struct ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9;
// FlyingWormConsole3.LiteNetLib.Utils.ParseException
struct ParseException_tE9D15FFE30722D3687DD4C6333903C530E2D0261;
// System.Threading.ReaderWriterLockSlim
struct ReaderWriterLockSlim_t3BF29C18C9FC0EE07209EDD54D938EA473FB3906;
// FlyingWormConsole3.LiteNetLib.ReliableChannel
struct ReliableChannel_tCF02F710AA06E981A959C4528BD13D2ED96B4014;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
// System.Net.Sockets.SafeSocketHandle
struct SafeSocketHandle_t5A597D30D951E736B750ED09D5B3AB72F98407EE;
// System.Threading.SemaphoreSlim
struct SemaphoreSlim_t0D5CB5685D9BFA5BF95CEC6E7395490F933E8DB2;
// FlyingWormConsole3.LiteNetLib.SequencedChannel
struct SequencedChannel_t33A970479102C6CA1094ABFF02F6ACB1E1DC3ED1;
// System.Net.Sockets.Socket
struct Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E;
// System.Net.Sockets.SocketException
struct SocketException_t6D10102A62EA871BD31748E026A372DB6804083B;
// System.Diagnostics.Stopwatch
struct Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043;
// System.String
struct String_t;
// System.Threading.Thread
struct Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer
struct XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198;
// FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate
struct SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5;
// FlyingWormConsole3.LiteNetLib.NetPeer/IncomingFragments
struct IncomingFragments_t062075061BAB497A25F999656003E8A69AE21661;
// FlyingWormConsole3.LiteNetLib.Utils.NetSerializer/CustomType
struct CustomType_t4542089B28CECEEA8A877EDA8CE931EFE7ADB166;
// System.Net.Sockets.Socket/CachedEventArgs
struct CachedEventArgs_tF0692E89962FD1A045B17BC985F838C11FB6822C;
// System.Net.Sockets.Socket/Int32TaskSocketAsyncEventArgs
struct Int32TaskSocketAsyncEventArgs_t36C5FC82499ED9DAFE7F05C38EF92D77A0B248E9;

IL2CPP_EXTERN_C RuntimeClass* ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Convert_t7097FF336D592F7C06D88A98349A44646F91EFFC_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Dictionary_2_t5EE36A10F9DEF39A9016F3998D768275F9B3C326_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Exception_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ICollection_1_t5C03FBFD5ECBDE4EAB8C4ED582DDFCF702EB5DC7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IDisposable_t030E0496B4E0E4E4F086825007979AF51F7248C5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnumerator_1_tA218C3658C89562941B7435E73E48E2EDC26D9BD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ObjectDisposedException_tC5FB29E8E980E2010A2F6A5B9B791089419F89EB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ParseException_tE9D15FFE30722D3687DD4C6333903C530E2D0261_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* RuntimeObject_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SocketError_t4AD3BECF393E3FD8C5238C4AE47B768B3ABC07B8_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* SocketException_t6D10102A62EA871BD31748E026A372DB6804083B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* String_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral017221BEF045A541084C808DB03B1A82115AE841;
IL2CPP_EXTERN_C String_t* _stringLiteral06C05B24B8AC51D50C3AA294D70C5E1E28E9A0E3;
IL2CPP_EXTERN_C String_t* _stringLiteral10F509F15EC5C6178F7787F554341A601F904E65;
IL2CPP_EXTERN_C String_t* _stringLiteral12F50ECCACB6B631723240678DADBCDA9DE90533;
IL2CPP_EXTERN_C String_t* _stringLiteral19CFC720389256CE284BB852E13BDB48224B840F;
IL2CPP_EXTERN_C String_t* _stringLiteral1DA333AC28D289B0B3DAAF2AF1E2CD4188F6ACF2;
IL2CPP_EXTERN_C String_t* _stringLiteral20578EED957D25675AEB69A727D4556E455C76A9;
IL2CPP_EXTERN_C String_t* _stringLiteral32189949CB1CA4A6EBB1A643EBE2DB69713D5407;
IL2CPP_EXTERN_C String_t* _stringLiteral3B19916E896E08666992C24EA969EE6DE3B95722;
IL2CPP_EXTERN_C String_t* _stringLiteral49BEFE76EF933CC018C51D77F66B724C36F2CE09;
IL2CPP_EXTERN_C String_t* _stringLiteral5486305FD2AB390DB38D4EE1F93074A684EDAF0F;
IL2CPP_EXTERN_C String_t* _stringLiteral54CC87BDCC203DBF3D08732C8F6B081BD50E7D62;
IL2CPP_EXTERN_C String_t* _stringLiteral5FC154761871B7293BA5D77E57A16A71359FE4E5;
IL2CPP_EXTERN_C String_t* _stringLiteral6474EBE79D288AAD27635D1581EA921D28D400BC;
IL2CPP_EXTERN_C String_t* _stringLiteral6A616A2BD726354344808434F427B73FA98BDD24;
IL2CPP_EXTERN_C String_t* _stringLiteral76C3D4024DE9EE847070E35CC5A197DC21F66FEE;
IL2CPP_EXTERN_C String_t* _stringLiteral77B615B8ED1ABB8FC1395D85A5AE524A9789D947;
IL2CPP_EXTERN_C String_t* _stringLiteral7B3C7E8130D1BF6705EFAAA4A72196B92A79769A;
IL2CPP_EXTERN_C String_t* _stringLiteral7DD59D78C0272A304AE65AAD0A7F0C9312EFBB7F;
IL2CPP_EXTERN_C String_t* _stringLiteral868EE9733DC26168EACBAC88A44D9E3DE178486F;
IL2CPP_EXTERN_C String_t* _stringLiteral88F1D02FAC5553C102E3A23C9A363D07A9C89238;
IL2CPP_EXTERN_C String_t* _stringLiteral9C6758427B6A2155E30FAC90008DE4117AAEB0DA;
IL2CPP_EXTERN_C String_t* _stringLiteralA9FFA609F3AF81CBA0BEF31B92E98F7C0B64DA06;
IL2CPP_EXTERN_C String_t* _stringLiteralAA624EFEF42571531D3DE3085352235F0E96D583;
IL2CPP_EXTERN_C String_t* _stringLiteralB3F14BF976EFD974E34846B742502C802FABAE9D;
IL2CPP_EXTERN_C String_t* _stringLiteralC90CADE37127E5B15A609569628F61937A864B5A;
IL2CPP_EXTERN_C String_t* _stringLiteralCB77237BCD39404C795BCB8688C2D3153355EBA0;
IL2CPP_EXTERN_C String_t* _stringLiteralCDCAEAC0EC16DAB2B94EB8085B3301CCA8654423;
IL2CPP_EXTERN_C String_t* _stringLiteralE246E702789502BB6581EC616DB67856E46BFF26;
IL2CPP_EXTERN_C String_t* _stringLiteralF39AFC06F0127ED41BF2DBB29047355062D8065C;
IL2CPP_EXTERN_C String_t* _stringLiteralF62357F27A8ABD4B2897C89CFE2ABB3A9468CB41;
IL2CPP_EXTERN_C String_t* _stringLiteralF9B144615946F6A86FEB5C383BF883FFC8AC62F8;
IL2CPP_EXTERN_C const RuntimeMethod* ArraySegment_1__ctor_m664EA6AD314FAA6BCA4F6D0586AEF01559537F20_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Array_Resize_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m82FEC5823560947D2B12C8D675AED2C190DF4F3F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* CRC32C__cctor_mBA8BFE64B4AEE422BD3E1E73C9B4E6DB100EF79B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_TryGetValue_mB702FBA6DE5A2796549B6AB3BAB29390901942C2_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2__ctor_m18669342C6857F217E5625EA0AD8ED2DD525FBB5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2__ctor_m8EB72C4EC23EFF571DFEDF3AA392DF7D38CB64B4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_Clear_mC6C7AEBB0F980A717A87C0D12377984A464F0934_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NetPacketProcessor_GetCallbackFromData_m4CA0F0219BE90B2EEBCED623E0B4F4A3066E8F8B_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NetSocket_ReceiveLogic_mB9B9845B26858ABC03AA0407E0CB399E68F3B9C7_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NetUtils_ResolveAddress_mAAAD87D508A5A6ABBEECA1A855A71EA4EC446BB4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NtpPacket_CheckTimestamps_m3CCEBF5C7B0D0BCA9F164E284A27360D31FAF2A4_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NtpPacket_ValidateReply_m15201D6A185C7D3C87594B52A742209DDA5D6366_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NtpPacket_ValidateRequest_m6071DCC338700F7187D68393D565E6F73C366E2F_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* NtpPacket__ctor_m960562C86ECE0569F0E3D017222FD6E8DC9AAD31_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Queue_1_Dequeue_m7A34883DDDA022398188F8BC0D48204E767A9230_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE;
struct IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D;
struct Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D;
struct NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F;
struct NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080;
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918;
struct SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913;
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C;
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
struct UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83;
struct UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA;
struct UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299;
struct PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Collections.Generic.Dictionary`2<System.Type,FlyingWormConsole3.LiteNetLib.Utils.NetSerializer/CustomType>
struct Dictionary_2_t5EE36A10F9DEF39A9016F3998D768275F9B3C326  : public RuntimeObject
{
	// System.Int32[] System.Collections.Generic.Dictionary`2::_buckets
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ____buckets_0;
	// System.Collections.Generic.Dictionary`2/Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::_entries
	EntryU5BU5D_t156A27B7E6145C1383AC9C9880E8147A90CCFB38* ____entries_1;
	// System.Int32 System.Collections.Generic.Dictionary`2::_count
	int32_t ____count_2;
	// System.Int32 System.Collections.Generic.Dictionary`2::_freeList
	int32_t ____freeList_3;
	// System.Int32 System.Collections.Generic.Dictionary`2::_freeCount
	int32_t ____freeCount_4;
	// System.Int32 System.Collections.Generic.Dictionary`2::_version
	int32_t ____version_5;
	// System.Collections.Generic.IEqualityComparer`1<TKey> System.Collections.Generic.Dictionary`2::_comparer
	RuntimeObject* ____comparer_6;
	// System.Collections.Generic.Dictionary`2/KeyCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::_keys
	KeyCollection_t4EEF82D16025086C3E59199E5D415BDCC8A8ED0B* ____keys_7;
	// System.Collections.Generic.Dictionary`2/ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::_values
	ValueCollection_tF8FDE74E8E6861A823329F130B350B828B8FBA1D* ____values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject* ____syncRoot_9;
};

// System.Collections.Generic.Dictionary`2<System.UInt64,FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate>
struct Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951  : public RuntimeObject
{
	// System.Int32[] System.Collections.Generic.Dictionary`2::_buckets
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ____buckets_0;
	// System.Collections.Generic.Dictionary`2/Entry<TKey,TValue>[] System.Collections.Generic.Dictionary`2::_entries
	EntryU5BU5D_t762C9873E03ABD2EAE235E73ECDBA51FCB9EFAD9* ____entries_1;
	// System.Int32 System.Collections.Generic.Dictionary`2::_count
	int32_t ____count_2;
	// System.Int32 System.Collections.Generic.Dictionary`2::_freeList
	int32_t ____freeList_3;
	// System.Int32 System.Collections.Generic.Dictionary`2::_freeCount
	int32_t ____freeCount_4;
	// System.Int32 System.Collections.Generic.Dictionary`2::_version
	int32_t ____version_5;
	// System.Collections.Generic.IEqualityComparer`1<TKey> System.Collections.Generic.Dictionary`2::_comparer
	RuntimeObject* ____comparer_6;
	// System.Collections.Generic.Dictionary`2/KeyCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::_keys
	KeyCollection_tE9AC5F7BFA71AD32B3C09BFA088AA4BA6EE8613D* ____keys_7;
	// System.Collections.Generic.Dictionary`2/ValueCollection<TKey,TValue> System.Collections.Generic.Dictionary`2::_values
	ValueCollection_t2577CC584993ADC75878EE7A1FB656005AA10306* ____values_8;
	// System.Object System.Collections.Generic.Dictionary`2::_syncRoot
	RuntimeObject* ____syncRoot_9;
};

// System.EmptyArray`1<System.Object>
struct EmptyArray_1_tDF0DD7256B115243AA6BD5558417387A734240EE  : public RuntimeObject
{
};

struct EmptyArray_1_tDF0DD7256B115243AA6BD5558417387A734240EE_StaticFields
{
	// T[] System.EmptyArray`1::Value
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___Value_0;
};

// System.Collections.Generic.List`1<System.Object>
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___s_emptyArray_5;
};

// System.Collections.Generic.List`1<System.String>
struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD  : public RuntimeObject
{
	// T[] System.Collections.Generic.List`1::_items
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ____items_1;
	// System.Int32 System.Collections.Generic.List`1::_size
	int32_t ____size_2;
	// System.Int32 System.Collections.Generic.List`1::_version
	int32_t ____version_3;
	// System.Object System.Collections.Generic.List`1::_syncRoot
	RuntimeObject* ____syncRoot_4;
};

struct List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_StaticFields
{
	// T[] System.Collections.Generic.List`1::s_emptyArray
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___s_emptyArray_5;
};

// System.Collections.Generic.Queue`1<FlyingWormConsole3.LiteNetLib.NetPacket>
struct Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C  : public RuntimeObject
{
	// T[] System.Collections.Generic.Queue`1::_array
	NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F* ____array_0;
	// System.Int32 System.Collections.Generic.Queue`1::_head
	int32_t ____head_1;
	// System.Int32 System.Collections.Generic.Queue`1::_tail
	int32_t ____tail_2;
	// System.Int32 System.Collections.Generic.Queue`1::_size
	int32_t ____size_3;
	// System.Int32 System.Collections.Generic.Queue`1::_version
	int32_t ____version_4;
	// System.Object System.Collections.Generic.Queue`1::_syncRoot
	RuntimeObject* ____syncRoot_5;
};

// System.Collections.Generic.Queue`1<System.Object>
struct Queue_1_tE9EF546915795972C3BFD68FBB8FA859D3BAF3B5  : public RuntimeObject
{
	// T[] System.Collections.Generic.Queue`1::_array
	ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ____array_0;
	// System.Int32 System.Collections.Generic.Queue`1::_head
	int32_t ____head_1;
	// System.Int32 System.Collections.Generic.Queue`1::_tail
	int32_t ____tail_2;
	// System.Int32 System.Collections.Generic.Queue`1::_size
	int32_t ____size_3;
	// System.Int32 System.Collections.Generic.Queue`1::_version
	int32_t ____version_4;
	// System.Object System.Collections.Generic.Queue`1::_syncRoot
	RuntimeObject* ____syncRoot_5;
};
struct Il2CppArrayBounds;

// FlyingWormConsole3.LiteNetLib.BaseChannel
struct BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215  : public RuntimeObject
{
	// FlyingWormConsole3.LiteNetLib.NetPeer FlyingWormConsole3.LiteNetLib.BaseChannel::Peer
	NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___Peer_0;
	// System.Collections.Generic.Queue`1<FlyingWormConsole3.LiteNetLib.NetPacket> FlyingWormConsole3.LiteNetLib.BaseChannel::OutgoingQueue
	Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* ___OutgoingQueue_1;
	// System.Int32 FlyingWormConsole3.LiteNetLib.BaseChannel::_isAddedToPeerChannelSendQueue
	int32_t ____isAddedToPeerChannelSendQueue_2;
};

// FlyingWormConsole3.LiteNetLib.Utils.CRC32C
struct CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A  : public RuntimeObject
{
};

struct CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields
{
	// System.UInt32[] FlyingWormConsole3.LiteNetLib.Utils.CRC32C::Table
	UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* ___Table_2;
};

// System.Runtime.ConstrainedExecution.CriticalFinalizerObject
struct CriticalFinalizerObject_t1DCAB623CAEA6529A96F5F3EDE3C7048A6E313C9  : public RuntimeObject
{
};

// System.Text.Encoding
struct Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095  : public RuntimeObject
{
	// System.Int32 System.Text.Encoding::m_codePage
	int32_t ___m_codePage_9;
	// System.Globalization.CodePageDataItem System.Text.Encoding::dataItem
	CodePageDataItem_t52460FA30AE37F4F26ACB81055E58002262F19F2* ___dataItem_10;
	// System.Boolean System.Text.Encoding::m_deserializedFromEverett
	bool ___m_deserializedFromEverett_11;
	// System.Boolean System.Text.Encoding::m_isReadOnly
	bool ___m_isReadOnly_12;
	// System.Text.EncoderFallback System.Text.Encoding::encoderFallback
	EncoderFallback_tD2C40CE114AA9D8E1F7196608B2D088548015293* ___encoderFallback_13;
	// System.Text.DecoderFallback System.Text.Encoding::decoderFallback
	DecoderFallback_t7324102215E4ED41EC065C02EB501CB0BC23CD90* ___decoderFallback_14;
};

struct Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095_StaticFields
{
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::defaultEncoding
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___defaultEncoding_0;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::unicodeEncoding
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___unicodeEncoding_1;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::bigEndianUnicode
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___bigEndianUnicode_2;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::utf7Encoding
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___utf7Encoding_3;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::utf8Encoding
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___utf8Encoding_4;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::utf32Encoding
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___utf32Encoding_5;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::asciiEncoding
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___asciiEncoding_6;
	// System.Text.Encoding modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::latin1Encoding
	Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* ___latin1Encoding_7;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.Text.Encoding> modreq(System.Runtime.CompilerServices.IsVolatile) System.Text.Encoding::encodings
	Dictionary_2_t87EDE08B2E48F793A22DE50D6B3CC2E7EBB2DB54* ___encodings_8;
	// System.Object System.Text.Encoding::s_InternalSyncObject
	RuntimeObject* ___s_InternalSyncObject_15;
};

// System.Net.EndPoint
struct EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564  : public RuntimeObject
{
};

// FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter
struct FastBitConverter_t45993CF42228786C192DD3A9B900DBCC42FE76D1  : public RuntimeObject
{
};

// System.Net.NetworkInformation.GatewayIPAddressInformationCollection
struct GatewayIPAddressInformationCollection_t4D24D7B02E632A5F8DBE65DBFB751C2EC925E817  : public RuntimeObject
{
	// System.Collections.ObjectModel.Collection`1<System.Net.NetworkInformation.GatewayIPAddressInformation> System.Net.NetworkInformation.GatewayIPAddressInformationCollection::addresses
	Collection_1_tAA30BCAC05A7C0F54CEE311DF69028C96E69A079* ___addresses_0;
};

// System.Net.IPAddress
struct IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484  : public RuntimeObject
{
	// System.UInt32 System.Net.IPAddress::_addressOrScopeId
	uint32_t ____addressOrScopeId_8;
	// System.UInt16[] System.Net.IPAddress::_numbers
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* ____numbers_9;
	// System.String System.Net.IPAddress::_toString
	String_t* ____toString_10;
	// System.Int32 System.Net.IPAddress::_hashCode
	int32_t ____hashCode_11;
};

struct IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_StaticFields
{
	// System.Net.IPAddress System.Net.IPAddress::Any
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ___Any_0;
	// System.Net.IPAddress System.Net.IPAddress::Loopback
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ___Loopback_1;
	// System.Net.IPAddress System.Net.IPAddress::Broadcast
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ___Broadcast_2;
	// System.Net.IPAddress System.Net.IPAddress::None
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ___None_3;
	// System.Net.IPAddress System.Net.IPAddress::IPv6Any
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ___IPv6Any_5;
	// System.Net.IPAddress System.Net.IPAddress::IPv6Loopback
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ___IPv6Loopback_6;
	// System.Net.IPAddress System.Net.IPAddress::IPv6None
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ___IPv6None_7;
};

// System.Net.NetworkInformation.IPAddressInformation
struct IPAddressInformation_t88AEE176C5711B91C890536A43B17C95690A07A7  : public RuntimeObject
{
};

// System.Net.IPHostEntry
struct IPHostEntry_tAAAEB0F40DB9F28BE601B5FE7DA1D76191C94490  : public RuntimeObject
{
	// System.String System.Net.IPHostEntry::hostName
	String_t* ___hostName_0;
	// System.String[] System.Net.IPHostEntry::aliases
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___aliases_1;
	// System.Net.IPAddress[] System.Net.IPHostEntry::addressList
	IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* ___addressList_2;
	// System.Boolean System.Net.IPHostEntry::isTrustedHost
	bool ___isTrustedHost_3;
};

// System.Net.NetworkInformation.IPInterfaceProperties
struct IPInterfaceProperties_t60A00D504E4F72CAFE4C0AE4DA6A062B44D1512F  : public RuntimeObject
{
};

// FlyingWormConsole3.LiteNetLib.NetConstants
struct NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779  : public RuntimeObject
{
};

struct NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_StaticFields
{
	// System.Int32[] FlyingWormConsole3.LiteNetLib.NetConstants::PossibleMtu
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___PossibleMtu_11;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetConstants::MaxPacketSize
	int32_t ___MaxPacketSize_12;
};

// FlyingWormConsole3.LiteNetLib.Utils.NetDataReader
struct NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54  : public RuntimeObject
{
	// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::_data
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ____data_0;
	// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::_position
	int32_t ____position_1;
	// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::_dataSize
	int32_t ____dataSize_2;
	// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::_offset
	int32_t ____offset_3;
};

// FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter
struct NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA  : public RuntimeObject
{
	// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::_data
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ____data_0;
	// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::_position
	int32_t ____position_1;
	// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::_autoResize
	bool ____autoResize_3;
};

// FlyingWormConsole3.LiteNetLib.NetManager
struct NetManager_t8B66EC65CAFC8455974B02C8945955F328277191  : public RuntimeObject
{
	// FlyingWormConsole3.LiteNetLib.NetSocket FlyingWormConsole3.LiteNetLib.NetManager::_socket
	NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* ____socket_0;
	// System.Threading.Thread FlyingWormConsole3.LiteNetLib.NetManager::_logicThread
	Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* ____logicThread_1;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::_manualMode
	bool ____manualMode_2;
	// System.Threading.AutoResetEvent FlyingWormConsole3.LiteNetLib.NetManager::_updateTriggerEvent
	AutoResetEvent_t7F792F3F7AD11BEF7B411E771D98E5266A8CE7C0* ____updateTriggerEvent_3;
	// System.Collections.Generic.Queue`1<FlyingWormConsole3.LiteNetLib.NetEvent> FlyingWormConsole3.LiteNetLib.NetManager::_netEventsQueue
	Queue_1_t7BFD6CD7312A946FFBF0334977E496A4D6E5787C* ____netEventsQueue_4;
	// FlyingWormConsole3.LiteNetLib.NetEvent FlyingWormConsole3.LiteNetLib.NetManager::_netEventPoolHead
	NetEvent_tA0FD096AF6E78990A09C560EC724A2E7D8D4676E* ____netEventPoolHead_5;
	// FlyingWormConsole3.LiteNetLib.INetEventListener FlyingWormConsole3.LiteNetLib.NetManager::_netEventListener
	RuntimeObject* ____netEventListener_6;
	// FlyingWormConsole3.LiteNetLib.IDeliveryEventListener FlyingWormConsole3.LiteNetLib.NetManager::_deliveryEventListener
	RuntimeObject* ____deliveryEventListener_7;
	// FlyingWormConsole3.LiteNetLib.INtpEventListener FlyingWormConsole3.LiteNetLib.NetManager::_ntpEventListener
	RuntimeObject* ____ntpEventListener_8;
	// System.Collections.Generic.Dictionary`2<System.Net.IPEndPoint,FlyingWormConsole3.LiteNetLib.NetPeer> FlyingWormConsole3.LiteNetLib.NetManager::_peersDict
	Dictionary_2_t6DAA31C75893B6F025B1715061A316C828EA35EB* ____peersDict_9;
	// System.Collections.Generic.Dictionary`2<System.Net.IPEndPoint,FlyingWormConsole3.LiteNetLib.ConnectionRequest> FlyingWormConsole3.LiteNetLib.NetManager::_requestsDict
	Dictionary_2_t1CE654E2C4E08E33B3C449A5971A7ECB484C6A68* ____requestsDict_10;
	// System.Collections.Generic.Dictionary`2<System.Net.IPEndPoint,FlyingWormConsole3.LiteNetLib.Utils.NtpRequest> FlyingWormConsole3.LiteNetLib.NetManager::_ntpRequests
	Dictionary_2_tD4FA8A8923573ECC57088CBAEC0E4333709B90B7* ____ntpRequests_11;
	// System.Threading.ReaderWriterLockSlim FlyingWormConsole3.LiteNetLib.NetManager::_peersLock
	ReaderWriterLockSlim_t3BF29C18C9FC0EE07209EDD54D938EA473FB3906* ____peersLock_12;
	// FlyingWormConsole3.LiteNetLib.NetPeer modreq(System.Runtime.CompilerServices.IsVolatile) FlyingWormConsole3.LiteNetLib.NetManager::_headPeer
	NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ____headPeer_13;
	// System.Int32 modreq(System.Runtime.CompilerServices.IsVolatile) FlyingWormConsole3.LiteNetLib.NetManager::_connectedPeersCount
	int32_t ____connectedPeersCount_14;
	// System.Collections.Generic.List`1<FlyingWormConsole3.LiteNetLib.NetPeer> FlyingWormConsole3.LiteNetLib.NetManager::_connectedPeerListCache
	List_1_tD7F9F96C55C6BCA0B8046273C342507E6FD1B006* ____connectedPeerListCache_15;
	// FlyingWormConsole3.LiteNetLib.NetPeer[] FlyingWormConsole3.LiteNetLib.NetManager::_peersArray
	NetPeerU5BU5D_t6ACD82DA7A2921F61314AD481D4FEEE66153A96C* ____peersArray_16;
	// FlyingWormConsole3.LiteNetLib.Layers.PacketLayerBase FlyingWormConsole3.LiteNetLib.NetManager::_extraPacketLayer
	PacketLayerBase_t45CF70BC52F3CBAE7EC7F885A16F3FB7753C23C6* ____extraPacketLayer_17;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetManager::_lastPeerId
	int32_t ____lastPeerId_18;
	// System.Collections.Generic.Queue`1<System.Int32> FlyingWormConsole3.LiteNetLib.NetManager::_peerIds
	Queue_1_tCA24E420CB13C6411AEFC3ECE9E62219F7937A1E* ____peerIds_19;
	// System.Byte FlyingWormConsole3.LiteNetLib.NetManager::_channelsCount
	uint8_t ____channelsCount_20;
	// System.Object FlyingWormConsole3.LiteNetLib.NetManager::_eventLock
	RuntimeObject* ____eventLock_21;
	// FlyingWormConsole3.LiteNetLib.NetPacketPool FlyingWormConsole3.LiteNetLib.NetManager::NetPacketPool
	NetPacketPool_tECE1CA68CDADE3C4E45A5FBCA8B25CC30F62DBF3* ___NetPacketPool_22;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::UnconnectedMessagesEnabled
	bool ___UnconnectedMessagesEnabled_23;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::NatPunchEnabled
	bool ___NatPunchEnabled_24;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetManager::UpdateTime
	int32_t ___UpdateTime_25;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetManager::PingInterval
	int32_t ___PingInterval_26;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetManager::DisconnectTimeout
	int32_t ___DisconnectTimeout_27;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::SimulatePacketLoss
	bool ___SimulatePacketLoss_28;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::SimulateLatency
	bool ___SimulateLatency_29;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetManager::SimulationPacketLossChance
	int32_t ___SimulationPacketLossChance_30;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetManager::SimulationMinLatency
	int32_t ___SimulationMinLatency_31;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetManager::SimulationMaxLatency
	int32_t ___SimulationMaxLatency_32;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::UnsyncedEvents
	bool ___UnsyncedEvents_33;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::UnsyncedReceiveEvent
	bool ___UnsyncedReceiveEvent_34;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::UnsyncedDeliveryEvent
	bool ___UnsyncedDeliveryEvent_35;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::BroadcastReceiveEnabled
	bool ___BroadcastReceiveEnabled_36;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetManager::ReconnectDelay
	int32_t ___ReconnectDelay_37;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetManager::MaxConnectAttempts
	int32_t ___MaxConnectAttempts_38;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::ReuseAddress
	bool ___ReuseAddress_39;
	// FlyingWormConsole3.LiteNetLib.NetStatistics FlyingWormConsole3.LiteNetLib.NetManager::Statistics
	NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* ___Statistics_40;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::EnableStatistics
	bool ___EnableStatistics_41;
	// FlyingWormConsole3.LiteNetLib.NatPunchModule FlyingWormConsole3.LiteNetLib.NetManager::NatPunchModule
	NatPunchModule_t81631A48708194B218EF85A59D6E12CC58334752* ___NatPunchModule_42;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::AutoRecycle
	bool ___AutoRecycle_43;
	// FlyingWormConsole3.LiteNetLib.IPv6Mode FlyingWormConsole3.LiteNetLib.NetManager::IPv6Enabled
	int32_t ___IPv6Enabled_44;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetManager::MtuOverride
	int32_t ___MtuOverride_45;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::UseSafeMtu
	bool ___UseSafeMtu_46;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetManager::DisconnectOnUnreachable
	bool ___DisconnectOnUnreachable_47;
};

// FlyingWormConsole3.LiteNetLib.NetPacket
struct NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED  : public RuntimeObject
{
	// System.Byte[] FlyingWormConsole3.LiteNetLib.NetPacket::RawData
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___RawData_2;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPacket::Size
	int32_t ___Size_3;
	// System.Object FlyingWormConsole3.LiteNetLib.NetPacket::UserData
	RuntimeObject* ___UserData_4;
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.NetPacket::Next
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___Next_5;
};

struct NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED_StaticFields
{
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPacket::LastProperty
	int32_t ___LastProperty_0;
	// System.Int32[] FlyingWormConsole3.LiteNetLib.NetPacket::HeaderSizes
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___HeaderSizes_1;
};

// FlyingWormConsole3.LiteNetLib.NetPacketPool
struct NetPacketPool_tECE1CA68CDADE3C4E45A5FBCA8B25CC30F62DBF3  : public RuntimeObject
{
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.NetPacketPool::_head
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____head_0;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPacketPool::_count
	int32_t ____count_1;
	// System.Object FlyingWormConsole3.LiteNetLib.NetPacketPool::_lock
	RuntimeObject* ____lock_2;
};

// FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor
struct NetPacketProcessor_tC008551263AC0F46812FF0AE3127ABF0D975E873  : public RuntimeObject
{
	// FlyingWormConsole3.LiteNetLib.Utils.NetSerializer FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::_netSerializer
	NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9* ____netSerializer_0;
	// System.Collections.Generic.Dictionary`2<System.UInt64,FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate> FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::_callbacks
	Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951* ____callbacks_1;
	// FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::_netDataWriter
	NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* ____netDataWriter_2;
};

// FlyingWormConsole3.LiteNetLib.NetPeer
struct NetPeer_t882A117D59790FE03D2D349C441B30690D04637B  : public RuntimeObject
{
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_rtt
	int32_t ____rtt_0;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_avgRtt
	int32_t ____avgRtt_1;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_rttCount
	int32_t ____rttCount_2;
	// System.Double FlyingWormConsole3.LiteNetLib.NetPeer::_resendDelay
	double ____resendDelay_3;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_pingSendTimer
	int32_t ____pingSendTimer_4;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_rttResetTimer
	int32_t ____rttResetTimer_5;
	// System.Diagnostics.Stopwatch FlyingWormConsole3.LiteNetLib.NetPeer::_pingTimer
	Stopwatch_tA188A210449E22C07053A7D3014DD182C7369043* ____pingTimer_6;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_timeSinceLastPacket
	int32_t ____timeSinceLastPacket_7;
	// System.Int64 FlyingWormConsole3.LiteNetLib.NetPeer::_remoteDelta
	int64_t ____remoteDelta_8;
	// FlyingWormConsole3.LiteNetLib.NetPacketPool FlyingWormConsole3.LiteNetLib.NetPeer::_packetPool
	NetPacketPool_tECE1CA68CDADE3C4E45A5FBCA8B25CC30F62DBF3* ____packetPool_9;
	// System.Object FlyingWormConsole3.LiteNetLib.NetPeer::_shutdownLock
	RuntimeObject* ____shutdownLock_10;
	// FlyingWormConsole3.LiteNetLib.NetPeer modreq(System.Runtime.CompilerServices.IsVolatile) FlyingWormConsole3.LiteNetLib.NetPeer::NextPeer
	NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___NextPeer_11;
	// FlyingWormConsole3.LiteNetLib.NetPeer FlyingWormConsole3.LiteNetLib.NetPeer::PrevPeer
	NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___PrevPeer_12;
	// System.Collections.Generic.Queue`1<FlyingWormConsole3.LiteNetLib.NetPacket> FlyingWormConsole3.LiteNetLib.NetPeer::_unreliableChannel
	Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* ____unreliableChannel_13;
	// System.Collections.Generic.Queue`1<FlyingWormConsole3.LiteNetLib.BaseChannel> FlyingWormConsole3.LiteNetLib.NetPeer::_channelSendQueue
	Queue_1_tD09EA56D6BAC52D37599D139B72F2D34213FC22A* ____channelSendQueue_14;
	// FlyingWormConsole3.LiteNetLib.BaseChannel[] FlyingWormConsole3.LiteNetLib.NetPeer::_channels
	BaseChannelU5BU5D_t71E8F4647253D2712361CB1E8733BB197E2FE0B9* ____channels_15;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_mtu
	int32_t ____mtu_16;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_mtuIdx
	int32_t ____mtuIdx_17;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetPeer::_finishMtu
	bool ____finishMtu_18;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_mtuCheckTimer
	int32_t ____mtuCheckTimer_19;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_mtuCheckAttempts
	int32_t ____mtuCheckAttempts_20;
	// System.Object FlyingWormConsole3.LiteNetLib.NetPeer::_mtuMutex
	RuntimeObject* ____mtuMutex_23;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_fragmentId
	int32_t ____fragmentId_24;
	// System.Collections.Generic.Dictionary`2<System.UInt16,FlyingWormConsole3.LiteNetLib.NetPeer/IncomingFragments> FlyingWormConsole3.LiteNetLib.NetPeer::_holdedFragments
	Dictionary_2_t59D759394C709A891846E81AECDFCDBAE94746A1* ____holdedFragments_25;
	// System.Collections.Generic.Dictionary`2<System.UInt16,System.UInt16> FlyingWormConsole3.LiteNetLib.NetPeer::_deliveredFragments
	Dictionary_2_tA7395733826D49EAFAAFD65320953B6D32A24EA4* ____deliveredFragments_26;
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.NetPeer::_mergeData
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____mergeData_27;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_mergePos
	int32_t ____mergePos_28;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_mergeCount
	int32_t ____mergeCount_29;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_connectAttempts
	int32_t ____connectAttempts_30;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_connectTimer
	int32_t ____connectTimer_31;
	// System.Int64 FlyingWormConsole3.LiteNetLib.NetPeer::_connectTime
	int64_t ____connectTime_32;
	// System.Byte FlyingWormConsole3.LiteNetLib.NetPeer::_connectNum
	uint8_t ____connectNum_33;
	// FlyingWormConsole3.LiteNetLib.ConnectionState FlyingWormConsole3.LiteNetLib.NetPeer::_connectionState
	uint8_t ____connectionState_34;
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.NetPeer::_shutdownPacket
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____shutdownPacket_35;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::_shutdownTimer
	int32_t ____shutdownTimer_37;
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.NetPeer::_pingPacket
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____pingPacket_38;
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.NetPeer::_pongPacket
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____pongPacket_39;
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.NetPeer::_connectRequestPacket
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____connectRequestPacket_40;
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.NetPeer::_connectAcceptPacket
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____connectAcceptPacket_41;
	// System.Net.IPEndPoint FlyingWormConsole3.LiteNetLib.NetPeer::EndPoint
	IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___EndPoint_42;
	// FlyingWormConsole3.LiteNetLib.NetManager FlyingWormConsole3.LiteNetLib.NetPeer::NetManager
	NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* ___NetManager_43;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer::Id
	int32_t ___Id_44;
	// System.Object FlyingWormConsole3.LiteNetLib.NetPeer::Tag
	RuntimeObject* ___Tag_45;
	// FlyingWormConsole3.LiteNetLib.NetStatistics FlyingWormConsole3.LiteNetLib.NetPeer::Statistics
	NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* ___Statistics_46;
};

// FlyingWormConsole3.LiteNetLib.Utils.NetSerializer
struct NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9  : public RuntimeObject
{
	// FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter FlyingWormConsole3.LiteNetLib.Utils.NetSerializer::_writer
	NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* ____writer_0;
	// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetSerializer::_maxStringLength
	int32_t ____maxStringLength_1;
	// System.Collections.Generic.Dictionary`2<System.Type,FlyingWormConsole3.LiteNetLib.Utils.NetSerializer/CustomType> FlyingWormConsole3.LiteNetLib.Utils.NetSerializer::_registeredTypes
	Dictionary_2_t5EE36A10F9DEF39A9016F3998D768275F9B3C326* ____registeredTypes_2;
};

// FlyingWormConsole3.LiteNetLib.NetSocket
struct NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4  : public RuntimeObject
{
	// System.Net.Sockets.Socket FlyingWormConsole3.LiteNetLib.NetSocket::_udpSocketv4
	Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* ____udpSocketv4_1;
	// System.Net.Sockets.Socket FlyingWormConsole3.LiteNetLib.NetSocket::_udpSocketv6
	Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* ____udpSocketv6_2;
	// System.Threading.Thread FlyingWormConsole3.LiteNetLib.NetSocket::_threadv4
	Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* ____threadv4_3;
	// System.Threading.Thread FlyingWormConsole3.LiteNetLib.NetSocket::_threadv6
	Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* ____threadv6_4;
	// System.Net.IPEndPoint FlyingWormConsole3.LiteNetLib.NetSocket::_bufferEndPointv4
	IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ____bufferEndPointv4_5;
	// System.Net.IPEndPoint FlyingWormConsole3.LiteNetLib.NetSocket::_bufferEndPointv6
	IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ____bufferEndPointv6_6;
	// FlyingWormConsole3.LiteNetLib.NetManager FlyingWormConsole3.LiteNetLib.NetSocket::_listener
	NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* ____listener_7;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetSocket::<LocalPort>k__BackingField
	int32_t ___U3CLocalPortU3Ek__BackingField_11;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) FlyingWormConsole3.LiteNetLib.NetSocket::IsRunning
	bool ___IsRunning_12;
};

struct NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_StaticFields
{
	// System.Net.IPAddress FlyingWormConsole3.LiteNetLib.NetSocket::MulticastAddressV6
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ___MulticastAddressV6_9;
	// System.Boolean FlyingWormConsole3.LiteNetLib.NetSocket::IPv6Support
	bool ___IPv6Support_10;
};

// FlyingWormConsole3.LiteNetLib.NetStatistics
struct NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20  : public RuntimeObject
{
	// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::_packetsSent
	int64_t ____packetsSent_0;
	// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::_packetsReceived
	int64_t ____packetsReceived_1;
	// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::_bytesSent
	int64_t ____bytesSent_2;
	// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::_bytesReceived
	int64_t ____bytesReceived_3;
	// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::_packetLoss
	int64_t ____packetLoss_4;
};

// FlyingWormConsole3.LiteNetLib.NetUtils
struct NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF  : public RuntimeObject
{
};

struct NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_StaticFields
{
	// System.Collections.Generic.List`1<System.String> FlyingWormConsole3.LiteNetLib.NetUtils::IpList
	List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* ___IpList_0;
};

// System.Net.NetworkInformation.NetworkInterface
struct NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A  : public RuntimeObject
{
};

// FlyingWormConsole3.LiteNetLib.Utils.NtpRequest
struct NtpRequest_tFFBFC24434D3C3F9B5A288721A636B37D4382399  : public RuntimeObject
{
	// System.Net.IPEndPoint FlyingWormConsole3.LiteNetLib.Utils.NtpRequest::_ntpEndPoint
	IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ____ntpEndPoint_3;
	// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NtpRequest::_resendTime
	int32_t ____resendTime_4;
	// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NtpRequest::_killTime
	int32_t ____killTime_5;
};

// FlyingWormConsole3.LiteNetLib.Layers.PacketLayerBase
struct PacketLayerBase_t45CF70BC52F3CBAE7EC7F885A16F3FB7753C23C6  : public RuntimeObject
{
	// System.Int32 FlyingWormConsole3.LiteNetLib.Layers.PacketLayerBase::ExtraPacketSizeForLayer
	int32_t ___ExtraPacketSizeForLayer_0;
};

// System.Net.Sockets.Socket
struct Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E  : public RuntimeObject
{
	// System.Net.Sockets.Socket/CachedEventArgs System.Net.Sockets.Socket::_cachedTaskEventArgs
	CachedEventArgs_tF0692E89962FD1A045B17BC985F838C11FB6822C* ____cachedTaskEventArgs_6;
	// System.Boolean System.Net.Sockets.Socket::is_closed
	bool ___is_closed_13;
	// System.Boolean System.Net.Sockets.Socket::is_listening
	bool ___is_listening_14;
	// System.Int32 System.Net.Sockets.Socket::linger_timeout
	int32_t ___linger_timeout_15;
	// System.Net.Sockets.AddressFamily System.Net.Sockets.Socket::addressFamily
	int32_t ___addressFamily_16;
	// System.Net.Sockets.SocketType System.Net.Sockets.Socket::socketType
	int32_t ___socketType_17;
	// System.Net.Sockets.ProtocolType System.Net.Sockets.Socket::protocolType
	int32_t ___protocolType_18;
	// System.Net.Sockets.SafeSocketHandle System.Net.Sockets.Socket::m_Handle
	SafeSocketHandle_t5A597D30D951E736B750ED09D5B3AB72F98407EE* ___m_Handle_19;
	// System.Net.EndPoint System.Net.Sockets.Socket::seed_endpoint
	EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* ___seed_endpoint_20;
	// System.Threading.SemaphoreSlim System.Net.Sockets.Socket::ReadSem
	SemaphoreSlim_t0D5CB5685D9BFA5BF95CEC6E7395490F933E8DB2* ___ReadSem_21;
	// System.Threading.SemaphoreSlim System.Net.Sockets.Socket::WriteSem
	SemaphoreSlim_t0D5CB5685D9BFA5BF95CEC6E7395490F933E8DB2* ___WriteSem_22;
	// System.Boolean System.Net.Sockets.Socket::is_blocking
	bool ___is_blocking_23;
	// System.Boolean System.Net.Sockets.Socket::is_bound
	bool ___is_bound_24;
	// System.Boolean System.Net.Sockets.Socket::is_connected
	bool ___is_connected_25;
	// System.Int32 System.Net.Sockets.Socket::m_IntCleanedUp
	int32_t ___m_IntCleanedUp_26;
	// System.Boolean System.Net.Sockets.Socket::connect_in_progress
	bool ___connect_in_progress_27;
};

struct Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E_StaticFields
{
	// System.EventHandler`1<System.Net.Sockets.SocketAsyncEventArgs> System.Net.Sockets.Socket::AcceptCompletedHandler
	EventHandler_1_t5D3FC4609BD8133ED1226D6D49A1D8076B16A9ED* ___AcceptCompletedHandler_0;
	// System.EventHandler`1<System.Net.Sockets.SocketAsyncEventArgs> System.Net.Sockets.Socket::ReceiveCompletedHandler
	EventHandler_1_t5D3FC4609BD8133ED1226D6D49A1D8076B16A9ED* ___ReceiveCompletedHandler_1;
	// System.EventHandler`1<System.Net.Sockets.SocketAsyncEventArgs> System.Net.Sockets.Socket::SendCompletedHandler
	EventHandler_1_t5D3FC4609BD8133ED1226D6D49A1D8076B16A9ED* ___SendCompletedHandler_2;
	// System.Net.Sockets.Socket/TaskSocketAsyncEventArgs`1<System.Net.Sockets.Socket> System.Net.Sockets.Socket::s_rentedSocketSentinel
	TaskSocketAsyncEventArgs_1_tEB937620E5B15D91E5BFEFFA707CF800930F8401* ___s_rentedSocketSentinel_3;
	// System.Net.Sockets.Socket/Int32TaskSocketAsyncEventArgs System.Net.Sockets.Socket::s_rentedInt32Sentinel
	Int32TaskSocketAsyncEventArgs_t36C5FC82499ED9DAFE7F05C38EF92D77A0B248E9* ___s_rentedInt32Sentinel_4;
	// System.Threading.Tasks.Task`1<System.Int32> System.Net.Sockets.Socket::s_zeroTask
	Task_1_t4C228DE57804012969575431CFF12D57C875552D* ___s_zeroTask_5;
	// System.Object System.Net.Sockets.Socket::s_InternalSyncObject
	RuntimeObject* ___s_InternalSyncObject_7;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.Net.Sockets.Socket::s_SupportsIPv4
	bool ___s_SupportsIPv4_8;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.Net.Sockets.Socket::s_SupportsIPv6
	bool ___s_SupportsIPv6_9;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.Net.Sockets.Socket::s_OSSupportsIPv6
	bool ___s_OSSupportsIPv6_10;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.Net.Sockets.Socket::s_Initialized
	bool ___s_Initialized_11;
	// System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile) System.Net.Sockets.Socket::s_LoggingEnabled
	bool ___s_LoggingEnabled_12;
	// System.AsyncCallback System.Net.Sockets.Socket::AcceptAsyncCallback
	AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___AcceptAsyncCallback_28;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginAcceptCallback
	IOAsyncCallback_tDBBA8BBDA6B203613680E77BD4AD6320A1268388* ___BeginAcceptCallback_29;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginAcceptReceiveCallback
	IOAsyncCallback_tDBBA8BBDA6B203613680E77BD4AD6320A1268388* ___BeginAcceptReceiveCallback_30;
	// System.AsyncCallback System.Net.Sockets.Socket::ConnectAsyncCallback
	AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___ConnectAsyncCallback_31;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginConnectCallback
	IOAsyncCallback_tDBBA8BBDA6B203613680E77BD4AD6320A1268388* ___BeginConnectCallback_32;
	// System.AsyncCallback System.Net.Sockets.Socket::DisconnectAsyncCallback
	AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___DisconnectAsyncCallback_33;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginDisconnectCallback
	IOAsyncCallback_tDBBA8BBDA6B203613680E77BD4AD6320A1268388* ___BeginDisconnectCallback_34;
	// System.AsyncCallback System.Net.Sockets.Socket::ReceiveAsyncCallback
	AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___ReceiveAsyncCallback_35;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginReceiveCallback
	IOAsyncCallback_tDBBA8BBDA6B203613680E77BD4AD6320A1268388* ___BeginReceiveCallback_36;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginReceiveGenericCallback
	IOAsyncCallback_tDBBA8BBDA6B203613680E77BD4AD6320A1268388* ___BeginReceiveGenericCallback_37;
	// System.AsyncCallback System.Net.Sockets.Socket::ReceiveFromAsyncCallback
	AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___ReceiveFromAsyncCallback_38;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginReceiveFromCallback
	IOAsyncCallback_tDBBA8BBDA6B203613680E77BD4AD6320A1268388* ___BeginReceiveFromCallback_39;
	// System.AsyncCallback System.Net.Sockets.Socket::SendAsyncCallback
	AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___SendAsyncCallback_40;
	// System.IOAsyncCallback System.Net.Sockets.Socket::BeginSendGenericCallback
	IOAsyncCallback_tDBBA8BBDA6B203613680E77BD4AD6320A1268388* ___BeginSendGenericCallback_41;
	// System.AsyncCallback System.Net.Sockets.Socket::SendToAsyncCallback
	AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___SendToAsyncCallback_42;
};

// System.String
struct String_t  : public RuntimeObject
{
	// System.Int32 System.String::_stringLength
	int32_t ____stringLength_4;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_5;
};

struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

// System.Net.NetworkInformation.UnicastIPAddressInformationCollection
struct UnicastIPAddressInformationCollection_tB4D61C9127DFB4168CA3855020CCEB59B75C6EDA  : public RuntimeObject
{
	// System.Collections.ObjectModel.Collection`1<System.Net.NetworkInformation.UnicastIPAddressInformation> System.Net.NetworkInformation.UnicastIPAddressInformationCollection::addresses
	Collection_1_tFCFDED5321BE15CA8D30D61CF04DDE693BB0CB5B* ___addresses_0;
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// FlyingWormConsole3.LiteNetLib.NetPeer/IncomingFragments
struct IncomingFragments_t062075061BAB497A25F999656003E8A69AE21661  : public RuntimeObject
{
	// FlyingWormConsole3.LiteNetLib.NetPacket[] FlyingWormConsole3.LiteNetLib.NetPeer/IncomingFragments::Fragments
	NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F* ___Fragments_0;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer/IncomingFragments::ReceivedCount
	int32_t ___ReceivedCount_1;
	// System.Int32 FlyingWormConsole3.LiteNetLib.NetPeer/IncomingFragments::TotalSize
	int32_t ___TotalSize_2;
	// System.Byte FlyingWormConsole3.LiteNetLib.NetPeer/IncomingFragments::ChannelId
	uint8_t ___ChannelId_3;
};

// FlyingWormConsole3.LiteNetLib.Utils.NetSerializer/CustomType
struct CustomType_t4542089B28CECEEA8A877EDA8CE931EFE7ADB166  : public RuntimeObject
{
};

// System.ArraySegment`1<System.Byte>
struct ArraySegment_1_t3DC888623B720A071D69279F1FCB95A109195093 
{
	// T[] System.ArraySegment`1::_array
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ____array_1;
	// System.Int32 System.ArraySegment`1::_offset
	int32_t ____offset_2;
	// System.Int32 System.ArraySegment`1::_count
	int32_t ____count_3;
};

struct ArraySegment_1_t3DC888623B720A071D69279F1FCB95A109195093_StaticFields
{
	// System.ArraySegment`1<T> System.ArraySegment`1::<Empty>k__BackingField
	ArraySegment_1_t3DC888623B720A071D69279F1FCB95A109195093 ___U3CEmptyU3Ek__BackingField_0;
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// System.Byte
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	// System.Byte System.Byte::m_value
	uint8_t ___m_value_0;
};

// System.Char
struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17 
{
	// System.Char System.Char::m_value
	Il2CppChar ___m_value_0;
};

struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17_StaticFields
{
	// System.Byte[] System.Char::s_categoryForLatin1
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___s_categoryForLatin1_3;
};

// FlyingWormConsole3.LiteNetLib.Layers.Crc32cLayer
struct Crc32cLayer_t799B2010955281BD2F31EBA62AF0091A14642304  : public PacketLayerBase_t45CF70BC52F3CBAE7EC7F885A16F3FB7753C23C6
{
};

// System.DateTime
struct DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D 
{
	// System.UInt64 System.DateTime::_dateData
	uint64_t ____dateData_46;
};

struct DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_StaticFields
{
	// System.Int32[] System.DateTime::s_daysToMonth365
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___s_daysToMonth365_30;
	// System.Int32[] System.DateTime::s_daysToMonth366
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___s_daysToMonth366_31;
	// System.DateTime System.DateTime::MinValue
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___MinValue_32;
	// System.DateTime System.DateTime::MaxValue
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___MaxValue_33;
	// System.DateTime System.DateTime::UnixEpoch
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___UnixEpoch_34;
};

// System.Double
struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	// System.Double System.Double::m_value
	double ___m_value_0;
};

// System.Net.IPEndPoint
struct IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB  : public EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564
{
	// System.Net.IPAddress System.Net.IPEndPoint::_address
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ____address_0;
	// System.Int32 System.Net.IPEndPoint::_port
	int32_t ____port_1;
};

struct IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_StaticFields
{
	// System.Net.IPEndPoint System.Net.IPEndPoint::Any
	IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___Any_2;
	// System.Net.IPEndPoint System.Net.IPEndPoint::IPv6Any
	IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___IPv6Any_3;
};

// System.Int16
struct Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175 
{
	// System.Int16 System.Int16::m_value
	int16_t ___m_value_0;
};

// System.Int32
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;
};

// System.Int64
struct Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3 
{
	// System.Int64 System.Int64::m_value
	int64_t ___m_value_0;
};

// System.IntPtr
struct IntPtr_t 
{
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;
};

// FlyingWormConsole3.LiteNetLib.ReliableChannel
struct ReliableChannel_tCF02F710AA06E981A959C4528BD13D2ED96B4014  : public BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215
{
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.ReliableChannel::_outgoingAcks
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____outgoingAcks_3;
	// FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket[] FlyingWormConsole3.LiteNetLib.ReliableChannel::_pendingPackets
	PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* ____pendingPackets_4;
	// FlyingWormConsole3.LiteNetLib.NetPacket[] FlyingWormConsole3.LiteNetLib.ReliableChannel::_receivedPackets
	NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F* ____receivedPackets_5;
	// System.Boolean[] FlyingWormConsole3.LiteNetLib.ReliableChannel::_earlyReceived
	BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* ____earlyReceived_6;
	// System.Int32 FlyingWormConsole3.LiteNetLib.ReliableChannel::_localSeqence
	int32_t ____localSeqence_7;
	// System.Int32 FlyingWormConsole3.LiteNetLib.ReliableChannel::_remoteSequence
	int32_t ____remoteSequence_8;
	// System.Int32 FlyingWormConsole3.LiteNetLib.ReliableChannel::_localWindowStart
	int32_t ____localWindowStart_9;
	// System.Int32 FlyingWormConsole3.LiteNetLib.ReliableChannel::_remoteWindowStart
	int32_t ____remoteWindowStart_10;
	// System.Boolean FlyingWormConsole3.LiteNetLib.ReliableChannel::_mustSendAcks
	bool ____mustSendAcks_11;
	// FlyingWormConsole3.LiteNetLib.DeliveryMethod FlyingWormConsole3.LiteNetLib.ReliableChannel::_deliveryMethod
	uint8_t ____deliveryMethod_12;
	// System.Boolean FlyingWormConsole3.LiteNetLib.ReliableChannel::_ordered
	bool ____ordered_13;
	// System.Int32 FlyingWormConsole3.LiteNetLib.ReliableChannel::_windowSize
	int32_t ____windowSize_14;
	// System.Byte FlyingWormConsole3.LiteNetLib.ReliableChannel::_id
	uint8_t ____id_16;
};

// System.SByte
struct SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5 
{
	// System.SByte System.SByte::m_value
	int8_t ___m_value_0;
};

// FlyingWormConsole3.LiteNetLib.SequencedChannel
struct SequencedChannel_t33A970479102C6CA1094ABFF02F6ACB1E1DC3ED1  : public BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215
{
	// System.Int32 FlyingWormConsole3.LiteNetLib.SequencedChannel::_localSequence
	int32_t ____localSequence_3;
	// System.UInt16 FlyingWormConsole3.LiteNetLib.SequencedChannel::_remoteSequence
	uint16_t ____remoteSequence_4;
	// System.Boolean FlyingWormConsole3.LiteNetLib.SequencedChannel::_reliable
	bool ____reliable_5;
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.SequencedChannel::_lastPacket
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____lastPacket_6;
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.SequencedChannel::_ackPacket
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____ackPacket_7;
	// System.Boolean FlyingWormConsole3.LiteNetLib.SequencedChannel::_mustSendAck
	bool ____mustSendAck_8;
	// System.Byte FlyingWormConsole3.LiteNetLib.SequencedChannel::_id
	uint8_t ____id_9;
	// System.Int64 FlyingWormConsole3.LiteNetLib.SequencedChannel::_lastPacketSendTime
	int64_t ____lastPacketSendTime_10;
};

// System.Single
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	// System.Single System.Single::m_value
	float ___m_value_0;
};

// System.Threading.Thread
struct Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F  : public CriticalFinalizerObject_t1DCAB623CAEA6529A96F5F3EDE3C7048A6E313C9
{
	// System.Threading.InternalThread System.Threading.Thread::internal_thread
	InternalThread_tF40B7BFCBD60C82BD8475A22FF5186CA10293687* ___internal_thread_6;
	// System.Object System.Threading.Thread::m_ThreadStartArg
	RuntimeObject* ___m_ThreadStartArg_7;
	// System.Object System.Threading.Thread::pending_exception
	RuntimeObject* ___pending_exception_8;
	// System.MulticastDelegate System.Threading.Thread::m_Delegate
	MulticastDelegate_t* ___m_Delegate_10;
	// System.Threading.ExecutionContext System.Threading.Thread::m_ExecutionContext
	ExecutionContext_t9D6EDFD92F0B2D391751963E2D77A8B03CB81710* ___m_ExecutionContext_11;
	// System.Boolean System.Threading.Thread::m_ExecutionContextBelongsToOuterScope
	bool ___m_ExecutionContextBelongsToOuterScope_12;
	// System.Security.Principal.IPrincipal System.Threading.Thread::principal
	RuntimeObject* ___principal_13;
	// System.Int32 System.Threading.Thread::principal_version
	int32_t ___principal_version_14;
};

struct Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F_StaticFields
{
	// System.LocalDataStoreMgr System.Threading.Thread::s_LocalDataStoreMgr
	LocalDataStoreMgr_t205F1783D5CC2B148E829B5882E5406FF9A3AC1E* ___s_LocalDataStoreMgr_0;
	// System.Threading.AsyncLocal`1<System.Globalization.CultureInfo> System.Threading.Thread::s_asyncLocalCurrentCulture
	AsyncLocal_1_t1D3339EA4C8650D2DEDDF9553E5C932B3DC2CCFD* ___s_asyncLocalCurrentCulture_4;
	// System.Threading.AsyncLocal`1<System.Globalization.CultureInfo> System.Threading.Thread::s_asyncLocalCurrentUICulture
	AsyncLocal_1_t1D3339EA4C8650D2DEDDF9553E5C932B3DC2CCFD* ___s_asyncLocalCurrentUICulture_5;
};

struct Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F_ThreadStaticFields
{
	// System.LocalDataStoreHolder System.Threading.Thread::s_LocalDataStore
	LocalDataStoreHolder_t789DD474AE5141213C2105CE57830ECFC2D3C03F* ___s_LocalDataStore_1;
	// System.Globalization.CultureInfo System.Threading.Thread::m_CurrentCulture
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___m_CurrentCulture_2;
	// System.Globalization.CultureInfo System.Threading.Thread::m_CurrentUICulture
	CultureInfo_t9BA817D41AD55AC8BD07480DD8AC22F8FFA378E0* ___m_CurrentUICulture_3;
	// System.Threading.Thread System.Threading.Thread::current_thread
	Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* ___current_thread_9;
};

// System.TimeSpan
struct TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A 
{
	// System.Int64 System.TimeSpan::_ticks
	int64_t ____ticks_22;
};

struct TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_StaticFields
{
	// System.TimeSpan System.TimeSpan::Zero
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___Zero_19;
	// System.TimeSpan System.TimeSpan::MaxValue
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___MaxValue_20;
	// System.TimeSpan System.TimeSpan::MinValue
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___MinValue_21;
};

// System.UInt16
struct UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455 
{
	// System.UInt16 System.UInt16::m_value
	uint16_t ___m_value_0;
};

// System.UInt32
struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	// System.UInt32 System.UInt32::m_value
	uint32_t ___m_value_0;
};

// System.UInt64
struct UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF 
{
	// System.UInt64 System.UInt64::m_value
	uint64_t ___m_value_0;
};

// System.Net.NetworkInformation.UnicastIPAddressInformation
struct UnicastIPAddressInformation_t4ACCADE9FBC1F8243A602439C94301E2C30295F3  : public IPAddressInformation_t88AEE176C5711B91C890536A43B17C95690A07A7
{
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};

// FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer
struct XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198  : public PacketLayerBase_t45CF70BC52F3CBAE7EC7F885A16F3FB7753C23C6
{
	// System.Byte[] FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer::_byteKey
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ____byteKey_1;
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=12
struct __StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F__padding[12];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=28
struct __StaticArrayInitTypeSizeU3D28_t523FB00435F599517548D4C121316CFE1B43E6C2 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D28_t523FB00435F599517548D4C121316CFE1B43E6C2__padding[28];
	};
};

// FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter/ConverterHelperDouble
struct ConverterHelperDouble_t96DC6EE768B7969E3AEA90AE956FA9641E1CF49D 
{
	union
	{
		#pragma pack(push, tp, 1)
		struct
		{
			// System.UInt64 FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter/ConverterHelperDouble::Along
			uint64_t ___Along_0;
		};
		#pragma pack(pop, tp)
		struct
		{
			uint64_t ___Along_0_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Double FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter/ConverterHelperDouble::Adouble
			double ___Adouble_1;
		};
		#pragma pack(pop, tp)
		struct
		{
			double ___Adouble_1_forAlignmentOnly;
		};
	};
};

// FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter/ConverterHelperFloat
struct ConverterHelperFloat_t32B37DDAF4EAE04DD7637BDA96DA12255B6D974C 
{
	union
	{
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter/ConverterHelperFloat::Aint
			int32_t ___Aint_0;
		};
		#pragma pack(pop, tp)
		struct
		{
			int32_t ___Aint_0_forAlignmentOnly;
		};
		#pragma pack(push, tp, 1)
		struct
		{
			// System.Single FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter/ConverterHelperFloat::Afloat
			float ___Afloat_1;
		};
		#pragma pack(pop, tp)
		struct
		{
			float ___Afloat_1_forAlignmentOnly;
		};
	};
};

// FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket
struct PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6 
{
	// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket::_packet
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____packet_0;
	// System.Int64 FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket::_timeStamp
	int64_t ____timeStamp_1;
	// System.Boolean FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket::_isSent
	bool ____isSent_2;
};
// Native definition for P/Invoke marshalling of FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket
struct PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshaled_pinvoke
{
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____packet_0;
	int64_t ____timeStamp_1;
	int32_t ____isSent_2;
};
// Native definition for COM marshalling of FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket
struct PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshaled_com
{
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ____packet_0;
	int64_t ____timeStamp_1;
	int32_t ____isSent_2;
};

// System.Nullable`1<System.DateTime>
struct Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC 
{
	// System.Boolean System.Nullable`1::hasValue
	bool ___hasValue_0;
	// T System.Nullable`1::value
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___value_1;
};

// <PrivateImplementationDetails>
struct U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA  : public RuntimeObject
{
};

struct U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA_StaticFields
{
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=12 <PrivateImplementationDetails>::4636993D3E1DA4E9D6B8F87B79E8F7C6D018580D52661950EABC3845C5897A4D
	__StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F ___4636993D3E1DA4E9D6B8F87B79E8F7C6D018580D52661950EABC3845C5897A4D_0;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=28 <PrivateImplementationDetails>::D79537A2F838755D540F3ECC461338CA43D2B18AEA28361726B8A7882AE00D99
	__StaticArrayInitTypeSizeU3D28_t523FB00435F599517548D4C121316CFE1B43E6C2 ___D79537A2F838755D540F3ECC461338CA43D2B18AEA28361726B8A7882AE00D99_1;
};

// System.Delegate
struct Delegate_t  : public RuntimeObject
{
	// System.IntPtr System.Delegate::method_ptr
	Il2CppMethodPointer ___method_ptr_0;
	// System.IntPtr System.Delegate::invoke_impl
	intptr_t ___invoke_impl_1;
	// System.Object System.Delegate::m_target
	RuntimeObject* ___m_target_2;
	// System.IntPtr System.Delegate::method
	intptr_t ___method_3;
	// System.IntPtr System.Delegate::delegate_trampoline
	intptr_t ___delegate_trampoline_4;
	// System.IntPtr System.Delegate::extra_arg
	intptr_t ___extra_arg_5;
	// System.IntPtr System.Delegate::method_code
	intptr_t ___method_code_6;
	// System.IntPtr System.Delegate::interp_method
	intptr_t ___interp_method_7;
	// System.IntPtr System.Delegate::interp_invoke_impl
	intptr_t ___interp_invoke_impl_8;
	// System.Reflection.MethodInfo System.Delegate::method_info
	MethodInfo_t* ___method_info_9;
	// System.Reflection.MethodInfo System.Delegate::original_method_info
	MethodInfo_t* ___original_method_info_10;
	// System.DelegateData System.Delegate::data
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	// System.Boolean System.Delegate::method_is_virtual
	bool ___method_is_virtual_12;
};
// Native definition for P/Invoke marshalling of System.Delegate
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};
// Native definition for COM marshalling of System.Delegate
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr_0;
	intptr_t ___invoke_impl_1;
	Il2CppIUnknown* ___m_target_2;
	intptr_t ___method_3;
	intptr_t ___delegate_trampoline_4;
	intptr_t ___extra_arg_5;
	intptr_t ___method_code_6;
	intptr_t ___interp_method_7;
	intptr_t ___interp_invoke_impl_8;
	MethodInfo_t* ___method_info_9;
	MethodInfo_t* ___original_method_info_10;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data_11;
	int32_t ___method_is_virtual_12;
};

// System.Exception
struct Exception_t  : public RuntimeObject
{
	// System.String System.Exception::_className
	String_t* ____className_1;
	// System.String System.Exception::_message
	String_t* ____message_2;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_3;
	// System.Exception System.Exception::_innerException
	Exception_t* ____innerException_4;
	// System.String System.Exception::_helpURL
	String_t* ____helpURL_5;
	// System.Object System.Exception::_stackTrace
	RuntimeObject* ____stackTrace_6;
	// System.String System.Exception::_stackTraceString
	String_t* ____stackTraceString_7;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_8;
	// System.Int32 System.Exception::_remoteStackIndex
	int32_t ____remoteStackIndex_9;
	// System.Object System.Exception::_dynamicMethods
	RuntimeObject* ____dynamicMethods_10;
	// System.Int32 System.Exception::_HResult
	int32_t ____HResult_11;
	// System.String System.Exception::_source
	String_t* ____source_12;
	// System.Runtime.Serialization.SafeSerializationManager System.Exception::_safeSerializationManager
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	// System.Diagnostics.StackTrace[] System.Exception::captured_traces
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	// System.IntPtr[] System.Exception::native_trace_ips
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips_15;
	// System.Int32 System.Exception::caught_in_unmanaged
	int32_t ___caught_in_unmanaged_16;
};

struct Exception_t_StaticFields
{
	// System.Object System.Exception::s_EDILock
	RuntimeObject* ___s_EDILock_0;
};
// Native definition for P/Invoke marshalling of System.Exception
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};
// Native definition for COM marshalling of System.Exception
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};

// System.MulticastDelegate
struct MulticastDelegate_t  : public Delegate_t
{
	// System.Delegate[] System.MulticastDelegate::delegates
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates_13;
};
// Native definition for P/Invoke marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates_13;
};
// Native definition for COM marshalling of System.MulticastDelegate
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates_13;
};

// FlyingWormConsole3.LiteNetLib.Utils.NtpPacket
struct NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA  : public RuntimeObject
{
	// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::<Bytes>k__BackingField
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___U3CBytesU3Ek__BackingField_1;
	// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::<DestinationTimestamp>k__BackingField
	Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC ___U3CDestinationTimestampU3Ek__BackingField_2;
};

struct NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_StaticFields
{
	// System.DateTime FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::Epoch
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___Epoch_0;
};

// FlyingWormConsole3.LiteNetLib.Utils.ParseException
struct ParseException_tE9D15FFE30722D3687DD4C6333903C530E2D0261  : public Exception_t
{
};

// System.SystemException
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};

// System.ArgumentException
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
	// System.String System.ArgumentException::_paramName
	String_t* ____paramName_18;
};

// System.AsyncCallback
struct AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C  : public MulticastDelegate_t
{
};

// System.Runtime.InteropServices.ExternalException
struct ExternalException_t419875A3CD3C551692EDBBC99E4927E69F2E1F4C  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// System.InvalidOperationException
struct InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};

// System.Threading.ParameterizedThreadStart
struct ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9  : public MulticastDelegate_t
{
};

// FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate
struct SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5  : public MulticastDelegate_t
{
};

// FlyingWormConsole3.LiteNetLib.Utils.InvalidTypeException
struct InvalidTypeException_t79DD32863BA9B2D1CE6C8E068D8E97ADABA8C741  : public ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263
{
};

// System.ObjectDisposedException
struct ObjectDisposedException_tC5FB29E8E980E2010A2F6A5B9B791089419F89EB  : public InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB
{
	// System.String System.ObjectDisposedException::_objectName
	String_t* ____objectName_18;
};

// System.ComponentModel.Win32Exception
struct Win32Exception_t15A75629914EB77C816D8219D93ED78E50C74BE9  : public ExternalException_t419875A3CD3C551692EDBBC99E4927E69F2E1F4C
{
	// System.Int32 System.ComponentModel.Win32Exception::nativeErrorCode
	int32_t ___nativeErrorCode_18;
};

// System.Net.Sockets.SocketException
struct SocketException_t6D10102A62EA871BD31748E026A372DB6804083B  : public Win32Exception_t15A75629914EB77C816D8219D93ED78E50C74BE9
{
	// System.Net.EndPoint System.Net.Sockets.SocketException::m_EndPoint
	EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* ___m_EndPoint_19;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
// System.Object[]
struct ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918  : public RuntimeArray
{
	ALIGN_FIELD (8) RuntimeObject* m_Items[1];

	inline RuntimeObject* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, RuntimeObject* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline RuntimeObject* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline RuntimeObject** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, RuntimeObject* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.Byte[]
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031  : public RuntimeArray
{
	ALIGN_FIELD (8) uint8_t m_Items[1];

	inline uint8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint8_t value)
	{
		m_Items[index] = value;
	}
};
// System.Net.IPAddress[]
struct IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D  : public RuntimeArray
{
	ALIGN_FIELD (8) IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* m_Items[1];

	inline IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.Net.NetworkInformation.NetworkInterface[]
struct NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080  : public RuntimeArray
{
	ALIGN_FIELD (8) NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A* m_Items[1];

	inline NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket[]
struct PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003  : public RuntimeArray
{
	ALIGN_FIELD (8) PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6 m_Items[1];

	inline PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6 GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6 value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)&((m_Items + index)->____packet_0), (void*)NULL);
	}
	inline PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6 GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6 value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)&((m_Items + index)->____packet_0), (void*)NULL);
	}
};
// FlyingWormConsole3.LiteNetLib.NetPacket[]
struct NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F  : public RuntimeArray
{
	ALIGN_FIELD (8) NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* m_Items[1];

	inline NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.Boolean[]
struct BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4  : public RuntimeArray
{
	ALIGN_FIELD (8) bool m_Items[1];

	inline bool GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline bool* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, bool value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline bool GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline bool* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, bool value)
	{
		m_Items[index] = value;
	}
};
// System.UInt32[]
struct UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA  : public RuntimeArray
{
	ALIGN_FIELD (8) uint32_t m_Items[1];

	inline uint32_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint32_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint32_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint32_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint32_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint32_t value)
	{
		m_Items[index] = value;
	}
};
// System.UInt16[]
struct UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83  : public RuntimeArray
{
	ALIGN_FIELD (8) uint16_t m_Items[1];

	inline uint16_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint16_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint16_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint16_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint16_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint16_t value)
	{
		m_Items[index] = value;
	}
};
// System.Int16[]
struct Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB  : public RuntimeArray
{
	ALIGN_FIELD (8) int16_t m_Items[1];

	inline int16_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline int16_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, int16_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline int16_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline int16_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, int16_t value)
	{
		m_Items[index] = value;
	}
};
// System.Int64[]
struct Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D  : public RuntimeArray
{
	ALIGN_FIELD (8) int64_t m_Items[1];

	inline int64_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline int64_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, int64_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline int64_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline int64_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, int64_t value)
	{
		m_Items[index] = value;
	}
};
// System.UInt64[]
struct UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299  : public RuntimeArray
{
	ALIGN_FIELD (8) uint64_t m_Items[1];

	inline uint64_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline uint64_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, uint64_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline uint64_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline uint64_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, uint64_t value)
	{
		m_Items[index] = value;
	}
};
// System.Int32[]
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C  : public RuntimeArray
{
	ALIGN_FIELD (8) int32_t m_Items[1];

	inline int32_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline int32_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, int32_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline int32_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline int32_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, int32_t value)
	{
		m_Items[index] = value;
	}
};
// System.Single[]
struct SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C  : public RuntimeArray
{
	ALIGN_FIELD (8) float m_Items[1];

	inline float GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline float* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, float value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline float GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline float* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, float value)
	{
		m_Items[index] = value;
	}
};
// System.Double[]
struct DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE  : public RuntimeArray
{
	ALIGN_FIELD (8) double m_Items[1];

	inline double GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline double* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, double value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline double GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline double* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, double value)
	{
		m_Items[index] = value;
	}
};
// System.String[]
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248  : public RuntimeArray
{
	ALIGN_FIELD (8) String_t* m_Items[1];

	inline String_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline String_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, String_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline String_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline String_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, String_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};
// System.SByte[]
struct SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913  : public RuntimeArray
{
	ALIGN_FIELD (8) int8_t m_Items[1];

	inline int8_t GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline int8_t* GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, int8_t value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
	}
	inline int8_t GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline int8_t* GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, int8_t value)
	{
		m_Items[index] = value;
	}
};
// System.Delegate[]
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771  : public RuntimeArray
{
	ALIGN_FIELD (8) Delegate_t* m_Items[1];

	inline Delegate_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Delegate_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};


// T[] System.Array::Empty<System.Object>()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_gshared_inline (const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1<System.Object>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1<System.Object>::Clear()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Clear_m16C1F2C61FED5955F10EB36BC1CB2DF34B128994_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;
// System.Int32 System.Collections.Generic.List`1<System.Object>::get_Count()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;
// T System.Collections.Generic.List`1<System.Object>::get_Item(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* List_1_get_Item_m33561245D64798C2AB07584C0EC4F240E4839A38_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, int32_t ___index0, const RuntimeMethod* method) ;
// T System.Collections.Generic.Queue`1<System.Object>::Dequeue()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Queue_1_Dequeue_m86B243DF9EC238316EC3D27DF3E0AB8DB0987E84_gshared (Queue_1_tE9EF546915795972C3BFD68FBB8FA859D3BAF3B5* __this, const RuntimeMethod* method) ;
// System.Int32 System.Collections.Generic.Queue`1<System.Object>::get_Count()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Queue_1_get_Count_m1768ADA9855B7CDA14C9C42E098A287F1A39C3A2_gshared_inline (Queue_1_tE9EF546915795972C3BFD68FBB8FA859D3BAF3B5* __this, const RuntimeMethod* method) ;
// System.Void System.ArraySegment`1<System.Byte>::.ctor(T[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArraySegment_1__ctor_m664EA6AD314FAA6BCA4F6D0586AEF01559537F20_gshared (ArraySegment_1_t3DC888623B720A071D69279F1FCB95A109195093* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___array0, int32_t ___offset1, int32_t ___count2, const RuntimeMethod* method) ;
// System.Void System.Array::Resize<System.Byte>(T[]&,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Array_Resize_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m82FEC5823560947D2B12C8D675AED2C190DF4F3F_gshared (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** ___array0, int32_t ___newSize1, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<System.UInt64,System.Object>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Dictionary_2__ctor_m5DA5AA64DE7BDB71265D475EF0B2D2E815A32E27_gshared (Dictionary_2_t01A465CD199FB14D59FEC2DC7DDE76D2CD0A09F4* __this, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.Dictionary`2<System.UInt64,System.Object>::TryGetValue(TKey,TValue&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Dictionary_2_TryGetValue_m610AC9FAFAA596802CD176D49D81FC2E15278ABF_gshared (Dictionary_2_t01A465CD199FB14D59FEC2DC7DDE76D2CD0A09F4* __this, uint64_t ___key0, RuntimeObject** ___value1, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<System.Object,System.Object>::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Dictionary_2__ctor_m5B32FBC624618211EB461D59CFBB10E987FD1329_gshared (Dictionary_2_t14FE4A752A83D53771C584E4C8D14E01F2AFD7BA* __this, const RuntimeMethod* method) ;
// T System.Nullable`1<System.DateTime>::get_Value()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_gshared (Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC* __this, const RuntimeMethod* method) ;
// System.Void System.Nullable`1<System.DateTime>::.ctor(T)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF_gshared (Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC* __this, DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___value0, const RuntimeMethod* method) ;
// System.Boolean System.Nullable`1<System.DateTime>::get_HasValue()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_gshared_inline (Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC* __this, const RuntimeMethod* method) ;

// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
// System.Net.Sockets.AddressFamily System.Net.Sockets.Socket::get_AddressFamily()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Socket_get_AddressFamily_m42C390D31345314080EC35356ACFBBFF7E1123E5_inline (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, const RuntimeMethod* method) ;
// System.Object System.Net.Sockets.Socket::GetSocketOption(System.Net.Sockets.SocketOptionLevel,System.Net.Sockets.SocketOptionName)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Socket_GetSocketOption_m39C453F9FA4D1EC664C660851CED73271B1162A2 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, int32_t ___optionLevel0, int32_t ___optionName1, const RuntimeMethod* method) ;
// System.Int16 System.Net.Sockets.Socket::get_Ttl()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int16_t Socket_get_Ttl_m385CF8BC3C7F4050AAE714C777FB7C6BBCC23472 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::SetSocketOption(System.Net.Sockets.SocketOptionLevel,System.Net.Sockets.SocketOptionName,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_SetSocketOption_m19085C1856DE21260294680B7725610D71D66A58 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, int32_t ___optionLevel0, int32_t ___optionName1, int32_t ___optionValue2, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::set_Ttl(System.Int16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_set_Ttl_m181E7794B74DEB52091B3D0CDDB745717B2A4F67 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, int16_t ___value0, const RuntimeMethod* method) ;
// System.Net.IPAddress System.Net.IPAddress::Parse(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* IPAddress_Parse_mD7BEF4D6060D8BE776F559C5F81F195A9917CF1C (String_t* ___ipString0, const RuntimeMethod* method) ;
// System.Boolean System.Net.Sockets.Socket::get_OSSupportsIPv6()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Socket_get_OSSupportsIPv6_m45BC8FD78EDFCB853CA509A8DDD23EF42203B6D4 (const RuntimeMethod* method) ;
// System.Net.Sockets.SocketError System.Net.Sockets.SocketException::get_SocketErrorCode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t SocketException_get_SocketErrorCode_m84FB2D308F046A24A1355975F3BF689C988224C6 (SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetDebug::WriteError(System.String,System.Object[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDebug_WriteError_m950356DF95AA0DB66BD907F841C4C9BBDCFF25E3 (String_t* ___str0, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___args1, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetManager::OnMessageReceived(FlyingWormConsole3.LiteNetLib.NetPacket,System.Net.Sockets.SocketError,System.Net.IPEndPoint)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetManager_OnMessageReceived_m7A0F0633BF526D18C57AE9EE0AA5AD12CB1AC5CF (NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, int32_t ___errorCode1, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___remoteEndPoint2, const RuntimeMethod* method) ;
// System.Boolean FlyingWormConsole3.LiteNetLib.NetSocket::ManualReceive(System.Net.Sockets.Socket,System.Net.EndPoint)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetSocket_ManualReceive_m1241FB2E52D803C062FE595923EEDE40BD084417 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* ___socket0, EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* ___bufferEndPoint1, const RuntimeMethod* method) ;
// System.Int32 System.Net.Sockets.Socket::get_Available()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Socket_get_Available_mDF4623F5A739F3F642D25A8905E0AF35BD7D7757 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, const RuntimeMethod* method) ;
// FlyingWormConsole3.LiteNetLib.NetPacket FlyingWormConsole3.LiteNetLib.NetPacketPool::GetPacket(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* NetPacketPool_GetPacket_mBB645C34FDEC48B469212DF385ABAA48456F942C (NetPacketPool_tECE1CA68CDADE3C4E45A5FBCA8B25CC30F62DBF3* __this, int32_t ___size0, const RuntimeMethod* method) ;
// System.Int32 System.Net.Sockets.Socket::ReceiveFrom(System.Byte[],System.Int32,System.Int32,System.Net.Sockets.SocketFlags,System.Net.EndPoint&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Socket_ReceiveFrom_m780282028E62CDD6021E3B8917656AC820878E6E (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___buffer0, int32_t ___offset1, int32_t ___size2, int32_t ___socketFlags3, EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564** ___remoteEP4, const RuntimeMethod* method) ;
// System.Boolean FlyingWormConsole3.LiteNetLib.NetSocket::ProcessError(System.Net.Sockets.SocketException,System.Net.EndPoint)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetSocket_ProcessError_mF5A149E092372829D95D5A0C22A4602B2A8A4720 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* ___ex0, EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* ___bufferEndPoint1, const RuntimeMethod* method) ;
// System.Void System.Net.IPEndPoint::.ctor(System.Net.IPAddress,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IPEndPoint__ctor_m902C98F9E3F36B20B3C2E030AA91B62E2BC7A85A (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* __this, IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ___address0, int32_t ___port1, const RuntimeMethod* method) ;
// System.Boolean System.Net.Sockets.Socket::Poll(System.Int32,System.Net.Sockets.SelectMode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Socket_Poll_m65D8E383FBE5A1D4A115942182620422B6646B98 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, int32_t ___microSeconds0, int32_t ___mode1, const RuntimeMethod* method) ;
// System.Boolean FlyingWormConsole3.LiteNetLib.NetSocket::IsActive()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetSocket_IsActive_m898D8B9D8568756AFCEF631AD2EAA82B813BA65F (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::.ctor(System.Net.Sockets.AddressFamily,System.Net.Sockets.SocketType,System.Net.Sockets.ProtocolType)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket__ctor_m35F1F4B4872E251867DA16460F06E903A30E4595 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, int32_t ___addressFamily0, int32_t ___socketType1, int32_t ___protocolType2, const RuntimeMethod* method) ;
// System.Boolean FlyingWormConsole3.LiteNetLib.NetSocket::BindSocket(System.Net.Sockets.Socket,System.Net.IPEndPoint,System.Boolean,FlyingWormConsole3.LiteNetLib.IPv6Mode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetSocket_BindSocket_mBA79B7AC17A4E04F397AA744126B2015F991570F (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* ___socket0, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___ep1, bool ___reuseAddress2, int32_t ___ipv6Mode3, const RuntimeMethod* method) ;
// System.Net.EndPoint System.Net.Sockets.Socket::get_LocalEndPoint()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* Socket_get_LocalEndPoint_m3A2B4E60F0096E2DB31F7C28EF3CDE148D256E26 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, const RuntimeMethod* method) ;
// System.Int32 System.Net.IPEndPoint::get_Port()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t IPEndPoint_get_Port_mFBE1AF1C9CC7E68A46BF46AD3869CC9DC01CF429_inline (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetSocket::set_LocalPort(System.Int32)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void NetSocket_set_LocalPort_m5131B89E161C3020415092F25760AB4038583ED9_inline (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Void System.Threading.ParameterizedThreadStart::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ParameterizedThreadStart__ctor_m31EA734851CB478E822BAB7E1B479CA4FDBF2718 (ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) ;
// System.Void System.Threading.Thread::.ctor(System.Threading.ParameterizedThreadStart)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Thread__ctor_m7319B115C7E11770EEEC7F1D4A01A50E29550700 (Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* __this, ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9* ___start0, const RuntimeMethod* method) ;
// System.Int32 FlyingWormConsole3.LiteNetLib.NetSocket::get_LocalPort()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t NetSocket_get_LocalPort_mD789615311CD7E8F790B46A9D99C72CCAF3D78E3_inline (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, const RuntimeMethod* method) ;
// System.String System.Int32::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5 (int32_t* __this, const RuntimeMethod* method) ;
// System.String System.String::Concat(System.String,System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m9B13B47FCB3DF61144D9647DDA05F527377251B0 (String_t* ___str00, String_t* ___str11, String_t* ___str22, const RuntimeMethod* method) ;
// System.Void System.Threading.Thread::set_Name(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Thread_set_Name_m53E2BA6E84C04A6393EA5E470E516703CB892E4A (Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* __this, String_t* ___value0, const RuntimeMethod* method) ;
// System.Void System.Threading.Thread::set_IsBackground(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Thread_set_IsBackground_m45F00BD4C46F9B8A7C46A20A170B22BABB8FBA30 (Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* __this, bool ___value0, const RuntimeMethod* method) ;
// System.Void System.Threading.Thread::Start(System.Object)
IL2CPP_EXTERN_C IL2CPP_NO_INLINE IL2CPP_METHOD_ATTR void Thread_Start_m64E3F27883C3CCCE7209F5D2BD268A33D4C71566 (Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* __this, RuntimeObject* ___parameter0, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::set_ReceiveTimeout(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_set_ReceiveTimeout_m64104AED8D1B18294EB55BDA58DC291A4BEEAD9B (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::set_SendTimeout(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_set_SendTimeout_m3C8E026F2961EBB32E1EA7B66657DE53E8A60679 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::set_ReceiveBufferSize(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_set_ReceiveBufferSize_mFCBD973C71C5E4883D3E3C6E822652373ED9CCD6 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::set_SendBufferSize(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_set_SendBufferSize_mBFC47E7A4581A220FBFE8B113CE828EFD7F4EF33 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::set_ExclusiveAddressUse(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_set_ExclusiveAddressUse_m3F9A655F123086A025AD1736933B0754A5A6DF7F (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, bool ___value0, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::SetSocketOption(System.Net.Sockets.SocketOptionLevel,System.Net.Sockets.SocketOptionName,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_SetSocketOption_mE47F5DEEA190E45317AEEE6F1506940CB8E943A1 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, int32_t ___optionLevel0, int32_t ___optionName1, bool ___optionValue2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetSocket::set_Ttl(System.Int16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSocket_set_Ttl_mBA8E187DB9240FD9DDE34664E679C9AFD1975117 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, int16_t ___value0, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::set_DontFragment(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_set_DontFragment_mCF6F7D2735A7FD4E327617826C62ED015001DFF6 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, bool ___value0, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::set_EnableBroadcast(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_set_EnableBroadcast_m8C25D9941F2D9BD40277F8D3395400993F4CF1CF (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, bool ___value0, const RuntimeMethod* method) ;
// System.Void System.Net.Sockets.Socket::Bind(System.Net.EndPoint)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_Bind_m137559EBA78A72ED4ADF8B56F5C535CE638165AA (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* ___localEP0, const RuntimeMethod* method) ;
// System.Int32 System.Net.Sockets.Socket::SendTo(System.Byte[],System.Int32,System.Int32,System.Net.Sockets.SocketFlags,System.Net.EndPoint)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Socket_SendTo_m07A6D82F7ABD61B6B9C87931035FCF793AA3D6F6 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___buffer0, int32_t ___offset1, int32_t ___size2, int32_t ___socketFlags3, EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* ___remoteEP4, const RuntimeMethod* method) ;
// System.String System.String::Concat(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_mAF2CE02CC0CB7460753D0A1A91CCF2B1E9804C5D (String_t* ___str00, String_t* ___str11, const RuntimeMethod* method) ;
// T[] System.Array::Empty<System.Object>()
inline ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_inline (const RuntimeMethod* method)
{
	return ((  ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* (*) (const RuntimeMethod*))Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_gshared_inline)(method);
}
// System.Void System.Net.Sockets.Socket::Close()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Socket_Close_m5EBF3D8BE2C42EF8037BC9372CE7760B1717EEE4 (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, const RuntimeMethod* method) ;
// System.Threading.Thread System.Threading.Thread::get_CurrentThread()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* Thread_get_CurrentThread_m835AD1DF1C0D10BABE1A5427CC4B357C991B25AB (const RuntimeMethod* method) ;
// System.Void System.Threading.Thread::Join()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Thread_Join_mB756581AAF5EB028081256E0517892BC8867779F (Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* __this, const RuntimeMethod* method) ;
// System.Int64 System.Threading.Interlocked::Read(System.Int64&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t Interlocked_Read_m646D69AAE03D57B78525D89642A5F951BA21CD28 (int64_t* ___location0, const RuntimeMethod* method) ;
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_PacketsSent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_PacketsSent_mA577EC1A59E042EE9EAFC04C4E2CC88466524477 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) ;
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_PacketLoss()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_PacketLoss_m162D4310CEE65B5C9A3E9FC84DD123A0CE172C03 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) ;
// System.Int64 System.Threading.Interlocked::Exchange(System.Int64&,System.Int64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t Interlocked_Exchange_mBBDC634C2A0C3F3226B1CA1F0773DDEAA8B2A227 (int64_t* ___location10, int64_t ___value1, const RuntimeMethod* method) ;
// System.Int64 System.Threading.Interlocked::Increment(System.Int64&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t Interlocked_Increment_m92616415B56E5497A3D07233BB7C2D263AB3D5A0 (int64_t* ___location0, const RuntimeMethod* method) ;
// System.Int64 System.Threading.Interlocked::Add(System.Int64&,System.Int64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t Interlocked_Add_mBF0FD78E930DEDDA2EEB0E9884FA2D8198D0EEC8 (int64_t* ___location10, int64_t ___value1, const RuntimeMethod* method) ;
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_BytesReceived()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_BytesReceived_m72AADEF43817A82E30A24817B6D099EA1245C5BD (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) ;
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_PacketsReceived()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_PacketsReceived_m0D9F0A427B092313E684596E5AF41ED2D2AACB43 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) ;
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_BytesSent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_BytesSent_mE84550EBF4569895FB32065400D2CA913BA2A3AF (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) ;
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_PacketLossPercent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_PacketLossPercent_mBF57554E91B93658BA228F681EAC813F85319A88 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) ;
// System.String System.String::Format(System.String,System.Object[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Format_m74FC0A1259DFA02F3DF6538FC7F3ACF3E1AF0C55 (String_t* ___format0, ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* ___args1, const RuntimeMethod* method) ;
// System.Net.IPAddress FlyingWormConsole3.LiteNetLib.NetUtils::ResolveAddress(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* NetUtils_ResolveAddress_mAAAD87D508A5A6ABBEECA1A855A71EA4EC446BB4 (String_t* ___hostStr0, const RuntimeMethod* method) ;
// System.Boolean System.String::op_Equality(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_op_Equality_m0D685A924E5CD78078F248ED1726DA5A9D7D6AC0 (String_t* ___a0, String_t* ___b1, const RuntimeMethod* method) ;
// System.Boolean System.Net.IPAddress::TryParse(System.String,System.Net.IPAddress&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool IPAddress_TryParse_mB8DC9EE090ED3BE8F8C9D419759AA9FF4A498D3B (String_t* ___ipString0, IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484** ___address1, const RuntimeMethod* method) ;
// System.Net.IPAddress FlyingWormConsole3.LiteNetLib.NetUtils::ResolveAddress(System.String,System.Net.Sockets.AddressFamily)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* NetUtils_ResolveAddress_mEB46B825C1F872874194C85D34A0846A614DB5BF (String_t* ___hostStr0, int32_t ___addressFamily1, const RuntimeMethod* method) ;
// System.Void System.ArgumentException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465 (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* __this, String_t* ___message0, const RuntimeMethod* method) ;
// System.Net.IPHostEntry System.Net.Dns::GetHostEntry(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR IPHostEntry_tAAAEB0F40DB9F28BE601B5FE7DA1D76191C94490* Dns_GetHostEntry_m01156278E5CDAE38B7E1B2EC617F505A4B836D02 (String_t* ___hostNameOrAddress0, const RuntimeMethod* method) ;
// System.Net.IPAddress[] System.Net.IPHostEntry::get_AddressList()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* IPHostEntry_get_AddressList_m9D14D52EFB41C53C9C4A36D438E1333A99B7AA71_inline (IPHostEntry_tAAAEB0F40DB9F28BE601B5FE7DA1D76191C94490* __this, const RuntimeMethod* method) ;
// System.Net.Sockets.AddressFamily System.Net.IPAddress::get_AddressFamily()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t IPAddress_get_AddressFamily_m1CE4BCCE499BD70B22F9E37B3F266F9306A98C21 (IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1<System.String>::.ctor()
inline void List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*, const RuntimeMethod*))List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared)(__this, method);
}
// System.Void FlyingWormConsole3.LiteNetLib.NetUtils::GetLocalIpList(System.Collections.Generic.IList`1<System.String>,FlyingWormConsole3.LiteNetLib.LocalAddrType)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetUtils_GetLocalIpList_m6DF77B2F0E1C6B7E39B1C5BF1938B741742C11F1 (RuntimeObject* ___targetList0, int32_t ___addrType1, const RuntimeMethod* method) ;
// System.Net.NetworkInformation.NetworkInterface[] System.Net.NetworkInformation.NetworkInterface::GetAllNetworkInterfaces()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080* NetworkInterface_GetAllNetworkInterfaces_mD3638D31C8C05E882CE28542D17821C95FCABE9D (const RuntimeMethod* method) ;
// System.String System.Net.Dns::GetHostName()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Dns_GetHostName_mF728787FF8A38620054B934FD08E021460A7C14D (const RuntimeMethod* method) ;
// System.Void System.Threading.Monitor::Exit(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Monitor_Exit_m25A154960F91391E10E4CDA245ECDF4BA94D56A9 (RuntimeObject* ___obj0, const RuntimeMethod* method) ;
// System.Void System.Threading.Monitor::Enter(System.Object,System.Boolean&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Monitor_Enter_m00506757392936AA62DBE2C5FFBEE69EE920C4D4 (RuntimeObject* ___obj0, bool* ___lockTaken1, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.List`1<System.String>::Clear()
inline void List_1_Clear_mC6C7AEBB0F980A717A87C0D12377984A464F0934_inline (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*, const RuntimeMethod*))List_1_Clear_m16C1F2C61FED5955F10EB36BC1CB2DF34B128994_gshared_inline)(__this, method);
}
// System.Int32 System.Collections.Generic.List`1<System.String>::get_Count()
inline int32_t List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_inline (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*, const RuntimeMethod*))List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline)(__this, method);
}
// T System.Collections.Generic.List`1<System.String>::get_Item(System.Int32)
inline String_t* List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8 (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* __this, int32_t ___index0, const RuntimeMethod* method)
{
	return ((  String_t* (*) (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*, int32_t, const RuntimeMethod*))List_1_get_Item_m33561245D64798C2AB07584C0EC4F240E4839A38_gshared)(__this, ___index0, method);
}
// System.Void FlyingWormConsole3.LiteNetLib.BaseChannel::.ctor(FlyingWormConsole3.LiteNetLib.NetPeer)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BaseChannel__ctor_m6EC2E55242CB43181FED32EF1A74C51ACAFACAD6 (BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215* __this, NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___peer0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetPacket::.ctor(FlyingWormConsole3.LiteNetLib.PacketProperty,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacket__ctor_m64EDA1B3C197027137887A26852E9E5490DEA8C8 (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* __this, uint8_t ___property0, int32_t ___size1, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetPacket::set_ChannelId(System.Byte)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacket_set_ChannelId_mF020D3EEF06D9CE0344D731F2E13CE41DA4395CB (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* __this, uint8_t ___value0, const RuntimeMethod* method) ;
// System.UInt16 FlyingWormConsole3.LiteNetLib.NetPacket::get_Sequence()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint16_t NetPacket_get_Sequence_m2388D004EF4D404ED0C3FB4DA95CA2E56C80E4F9 (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* __this, const RuntimeMethod* method) ;
// System.Int32 FlyingWormConsole3.LiteNetLib.NetUtils::RelativeSequenceNumber(System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetUtils_RelativeSequenceNumber_mCA9FAA443395636279506E0E0F9C8D6905935D49 (int32_t ___number0, int32_t ___expected1, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetStatistics::IncrementPacketLoss()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetStatistics_IncrementPacketLoss_m6AF8CA81D7D3064EB05121D8D499BCF5C72763BC (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) ;
// System.Boolean FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket::Clear(FlyingWormConsole3.LiteNetLib.NetPeer)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PendingPacket_Clear_m6C98ACC437234C8DC24341538EE5505B6824E87A (PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* __this, NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___peer0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetPeer::SendUserData(FlyingWormConsole3.LiteNetLib.NetPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPeer_SendUserData_mDD3D17B669432BDAE9F54A7A7959A369943D4951 (NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, const RuntimeMethod* method) ;
// System.DateTime System.DateTime::get_UtcNow()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D DateTime_get_UtcNow_m5D776FFEBC81592B361E4C7AF373297C5DFB46FD (const RuntimeMethod* method) ;
// System.Int64 System.DateTime::get_Ticks()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t DateTime_get_Ticks_mC2CF04ED0EAB425C72C2532FFC5743777F3C93A6 (DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* __this, const RuntimeMethod* method) ;
// T System.Collections.Generic.Queue`1<FlyingWormConsole3.LiteNetLib.NetPacket>::Dequeue()
inline NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* Queue_1_Dequeue_m7A34883DDDA022398188F8BC0D48204E767A9230 (Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* __this, const RuntimeMethod* method)
{
	return ((  NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* (*) (Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C*, const RuntimeMethod*))Queue_1_Dequeue_m86B243DF9EC238316EC3D27DF3E0AB8DB0987E84_gshared)(__this, method);
}
// System.Void FlyingWormConsole3.LiteNetLib.NetPacket::set_Sequence(System.UInt16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacket_set_Sequence_m5849CD30F14F09CBB8541CF80CF6091F6409D9CB (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* __this, uint16_t ___value0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket::Init(FlyingWormConsole3.LiteNetLib.NetPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PendingPacket_Init_m81B1EEE319B344975B7C1CD2AF155266ABAAD762 (PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, const RuntimeMethod* method) ;
// System.Int32 System.Collections.Generic.Queue`1<FlyingWormConsole3.LiteNetLib.NetPacket>::get_Count()
inline int32_t Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_inline (Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* __this, const RuntimeMethod* method)
{
	return ((  int32_t (*) (Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C*, const RuntimeMethod*))Queue_1_get_Count_m1768ADA9855B7CDA14C9C42E098A287F1A39C3A2_gshared_inline)(__this, method);
}
// System.Void FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket::TrySend(System.Int64,FlyingWormConsole3.LiteNetLib.NetPeer,System.Boolean&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PendingPacket_TrySend_mA021BAF5368005E4EF0491B65374BF73A9BF81A6 (PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* __this, int64_t ___currentTime0, NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___peer1, bool* ___hasPacket2, const RuntimeMethod* method) ;
// FlyingWormConsole3.LiteNetLib.PacketProperty FlyingWormConsole3.LiteNetLib.NetPacket::get_Property()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t NetPacket_get_Property_m7C25C6BE2668D9B1B39F462ACDEBA56ADD8D7252 (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.ReliableChannel::ProcessAck(FlyingWormConsole3.LiteNetLib.NetPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ReliableChannel_ProcessAck_m7C2322827BF50314E9D02C719195990347900E21 (ReliableChannel_tCF02F710AA06E981A959C4528BD13D2ED96B4014* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.BaseChannel::AddToPeerChannelSendQueue()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void BaseChannel_AddToPeerChannelSendQueue_mB2D37C382AD242C4D11C3A82C6ECF316B55BE28F (BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetPeer::AddReliablePacket(FlyingWormConsole3.LiteNetLib.DeliveryMethod,FlyingWormConsole3.LiteNetLib.NetPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPeer_AddReliablePacket_m2DBE9508AE12C58F5559AB9D55B31E62A5AA85FE (NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* __this, uint8_t ___method0, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___p1, const RuntimeMethod* method) ;
// System.String System.UInt16::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* UInt16_ToString_m57629B7E74D92A54414073D5C27D6827C93A4DD5 (uint16_t* __this, const RuntimeMethod* method) ;
// System.String FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* PendingPacket_ToString_mBD46DB34274B209C3C3E26B4EF268425C023B179 (PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* __this, const RuntimeMethod* method) ;
// System.Double FlyingWormConsole3.LiteNetLib.NetPeer::get_ResendDelay()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR double NetPeer_get_ResendDelay_m6D44FEF7BA647CA1047274DB58A7B9A2FDC64A12_inline (NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetPeer::RecycleAndDeliver(FlyingWormConsole3.LiteNetLib.NetPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPeer_RecycleAndDeliver_m15E0F1F670435B7AFBE8BFC2203C1B383454A28E (NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetPacketPool::Recycle(FlyingWormConsole3.LiteNetLib.NetPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacketPool_Recycle_m872D8D50F3E68B326EEEA6F15E9762DD15FD7431 (NetPacketPool_tECE1CA68CDADE3C4E45A5FBCA8B25CC30F62DBF3* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, const RuntimeMethod* method) ;
// System.Boolean FlyingWormConsole3.LiteNetLib.NetPacket::get_IsFragmented()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetPacket_get_IsFragmented_mB4ABDC6D0BB76F3FAFF9932559F177CAE2BA7D79 (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetStatistics::AddPacketLoss(System.Int64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetStatistics_AddPacketLoss_mAA70198C7E49704F5821DE577543473AD6327039 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, int64_t ___packetLoss0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.NetManager::CreateReceiveEvent(FlyingWormConsole3.LiteNetLib.NetPacket,FlyingWormConsole3.LiteNetLib.DeliveryMethod,System.Int32,FlyingWormConsole3.LiteNetLib.NetPeer)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetManager_CreateReceiveEvent_m7CEE7A198F953707702446BCD45F2913E855D095 (NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, uint8_t ___method1, int32_t ___headerSize2, NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___fromPeer3, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::WriteLittleEndian(System.Byte[],System.Int32,System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_WriteLittleEndian_m381E59B59A43CB94E0B537FB44F0C0B4E1BEA561 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___buffer0, int32_t ___offset1, uint64_t ___data2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::WriteLittleEndian(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_WriteLittleEndian_m74DABA75442771598F637407CEBFD9E66DF60DB7 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___buffer0, int32_t ___offset1, int32_t ___data2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::WriteLittleEndian(System.Byte[],System.Int32,System.Int16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_WriteLittleEndian_m1E1C0AE20BD2FCB97F656DE97253FD064ED9BB38 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___buffer0, int32_t ___offset1, int16_t ___data2, const RuntimeMethod* method) ;
// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::get_Data()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* NetDataWriter_get_Data_m57195A7D8184C5AFAE3D3DEF4069D8AD9A7390AD_inline (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, const RuntimeMethod* method) ;
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::get_Length()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t NetDataWriter_get_Length_m7947782000AC2E7C7B6152A12F4FCA2064948AEC_inline (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::SetSource(FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_SetSource_mBB8783DD38E3E8036B963E9DB1E9938BEB3016DB (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* ___dataWriter0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::SetSource(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_SetSource_mF38EADB55AB83471FB3659699E2D72CB729F6EB2 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___source0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::SetSource(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_SetSource_mAE98AD0CF76E7AD14F84DBD771B680A060C27361 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___source0, int32_t ___offset1, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::SetSource(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_SetSource_m001BD5F3E22403AF65DD828572FC45C5D1AE0410 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___source0, int32_t ___offset1, int32_t ___maxSize2, const RuntimeMethod* method) ;
// System.String FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetString(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NetDataReader_GetString_m19541292BC49A3CE2F5A6EEE17B474171A6C63D5 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, int32_t ___maxLength0, const RuntimeMethod* method) ;
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetInt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataReader_GetInt_m92B368B698EC12119AC71237D7ADC180941F471A (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Net.IPEndPoint FlyingWormConsole3.LiteNetLib.NetUtils::MakeEndPoint(System.String,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* NetUtils_MakeEndPoint_mF3EC8D450B5146C27AEF82F7962734F09ACBB1A1 (String_t* ___hostStr0, int32_t ___port1, const RuntimeMethod* method) ;
// System.UInt16 System.BitConverter::ToUInt16(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint16_t BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, int32_t ___startIndex1, const RuntimeMethod* method) ;
// System.Void System.Buffer::BlockCopy(System.Array,System.Int32,System.Array,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9 (RuntimeArray* ___src0, int32_t ___srcOffset1, RuntimeArray* ___dst2, int32_t ___dstOffset3, int32_t ___count4, const RuntimeMethod* method) ;
// System.String FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NetDataReader_GetString_mE8A0E283EB6059B7D6449F895FB6AACF7A0C795C (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Char System.BitConverter::ToChar(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar BitConverter_ToChar_mC94CFD2ABBB997AD4101A7EADA468FFD47F52EA0 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, int32_t ___startIndex1, const RuntimeMethod* method) ;
// System.Int16 System.BitConverter::ToInt16(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int16_t BitConverter_ToInt16_mC4F4FF7F02DC025F64047372BD5B25540F3EFC62 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, int32_t ___startIndex1, const RuntimeMethod* method) ;
// System.Int64 System.BitConverter::ToInt64(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t BitConverter_ToInt64_m1CDA079BFD3222894DB58B69449E0110ED37AB1C (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, int32_t ___startIndex1, const RuntimeMethod* method) ;
// System.UInt64 System.BitConverter::ToUInt64(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t BitConverter_ToUInt64_mD74DF4F6535FC635EB8697FC5175A7D99E3C62BF (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, int32_t ___startIndex1, const RuntimeMethod* method) ;
// System.Int32 System.BitConverter::ToInt32(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t BitConverter_ToInt32_m745DF4DCC23461AB3035A92BC0C4D59AE12E6880 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, int32_t ___startIndex1, const RuntimeMethod* method) ;
// System.UInt32 System.BitConverter::ToUInt32(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t BitConverter_ToUInt32_m7EFCF9D77ACD0F2DA29F69587DDF6130391E6164 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, int32_t ___startIndex1, const RuntimeMethod* method) ;
// System.Single System.BitConverter::ToSingle(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float BitConverter_ToSingle_m385AA8335F6A788C1AD54295BA8352FFADD91F36 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, int32_t ___startIndex1, const RuntimeMethod* method) ;
// System.Double System.BitConverter::ToDouble(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double BitConverter_ToDouble_mEE089DB60AD05ED4B0F2670D8313E17668ECC289 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, int32_t ___startIndex1, const RuntimeMethod* method) ;
// System.Text.Encoding System.Text.Encoding::get_UTF8()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336 (const RuntimeMethod* method) ;
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::get_AvailableBytes()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Void System.ArraySegment`1<System.Byte>::.ctor(T[],System.Int32,System.Int32)
inline void ArraySegment_1__ctor_m664EA6AD314FAA6BCA4F6D0586AEF01559537F20 (ArraySegment_1_t3DC888623B720A071D69279F1FCB95A109195093* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___array0, int32_t ___offset1, int32_t ___count2, const RuntimeMethod* method)
{
	((  void (*) (ArraySegment_1_t3DC888623B720A071D69279F1FCB95A109195093*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t, const RuntimeMethod*))ArraySegment_1__ctor_m664EA6AD314FAA6BCA4F6D0586AEF01559537F20_gshared)(__this, ___array0, ___offset1, ___count2, method);
}
// System.Byte FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetByte()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t NetDataReader_GetByte_m06FB4658EC622986718080254ECFD259DD406BF6 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.SByte FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetSByte()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int8_t NetDataReader_GetSByte_m06DBC7E501228FAD46AD4547131711438B10D650 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetBool()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_GetBool_m0A6A345E1F2AC6472D3A454AEF7F9C87241C5F4C (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Char FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetChar()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar NetDataReader_GetChar_mA1AAFAF04C9ACCF416B0EE481F6D7C6284DA2E03 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Int16 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetShort()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int16_t NetDataReader_GetShort_mE2FEF7B9AFA93170712E89277FE1C61C5D0FCAE8 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.UInt16 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetUShort()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint16_t NetDataReader_GetUShort_m01E2634AB533AC3ED170991D133981BB0D000DC4 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.UInt32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetUInt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t NetDataReader_GetUInt_mDE5E7DFB66C920FA43257752522AD792CA8AA1E2 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Int64 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetLong()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetDataReader_GetLong_m1B2BE011BE6E224D9FAE094DC1EECE9C3B473259 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.UInt64 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetULong()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t NetDataReader_GetULong_mEDAAFDA63ECC73E4FFFD0557116F0C80DE08C8A2 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Single FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetFloat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float NetDataReader_GetFloat_m44A56D47D422411B6ED9B633BFA5A64AC3AFE570 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Double FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetDouble()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double NetDataReader_GetDouble_m7F09CDB38083D759FF6E9EA5C572553FFE9B0055 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekInt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataReader_PeekInt_m55892788150A79450F06BCF4B1D0C5182444AD51 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetUShort(System.UInt16&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetUShort_m45ED0659977BEA633E6E00C3CDCA9F74ECF92B53 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, uint16_t* ___result0, const RuntimeMethod* method) ;
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetString(System.String&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetString_m7BB02F8DD26F7D8F32FCBD644B5DCE1C9CB557F1 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, String_t** ___result0, const RuntimeMethod* method) ;
// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetBytesWithLength()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* NetDataReader_GetBytesWithLength_m4B076429B78EDBEFB110F065B7024A4C147EB075 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::.ctor(System.Boolean,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter__ctor_m4693B3955597A9E39B4BE364F76A0499DDEAED24 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, bool ___autoResize0, int32_t ___initialSize1, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m3D5E4569AAE00E996F2C31B62D003DE00D942184 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___data0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_mE912955AE675D8A7F03FEACAAA4F2E467DE3BED5 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___data0, int32_t ___offset1, int32_t ___length2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter__ctor_m146E2C307B585380552FB2583AC8FFCE97CD9B71 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_mCB88FC274D037CA1454EC1B65FA7E4DC05EA24B2 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, String_t* ___value0, const RuntimeMethod* method) ;
// System.Void System.Array::Resize<System.Byte>(T[]&,System.Int32)
inline void Array_Resize_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m82FEC5823560947D2B12C8D675AED2C190DF4F3F (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** ___array0, int32_t ___newSize1, const RuntimeMethod* method)
{
	((  void (*) (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**, int32_t, const RuntimeMethod*))Array_Resize_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m82FEC5823560947D2B12C8D675AED2C190DF4F3F_gshared)(___array0, ___newSize1, method);
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::ResizeIfNeed(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, int32_t ___newSize0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_m6B2778DF75A49DC012513A1C0AEC198F165E761C (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, float ___value2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_mBF60A9EB8FD38FFFE8EA1B8B1B5407C4499DD063 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, double ___value2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.Int64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_m3217BA7AFFB8FC748D049D69CC84FC905D049AA0 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, int64_t ___value2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_m9D1EC7459D20F918B45C5ED54DAC7B95CA35F064 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, uint64_t ___value2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_mD6649FCFC54EBFAC500F6647222F8A40B37DF0FD (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, int32_t ___value2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_mE205091FC74A54D5580EF718A92652CCCF3FC942 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, uint32_t ___value2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.UInt16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_mC6C3C3E1FA097BB0C9E04A5032DBFC51E46FEC79 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, uint16_t ___value2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.Int16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_mF3C15486890268B6B1334D47252E3011CEFB2039 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, int16_t ___value2, const RuntimeMethod* method) ;
// System.Int32 System.Array::get_Length()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t Array_get_Length_m361285FB7CF44045DC369834D1CD01F72F94EF57 (RuntimeArray* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.Array,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_m48347B1BD5A82113D78A2F53F26B14D533DBCC4C (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, RuntimeArray* ___arr0, int32_t ___sz1, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.UInt16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m0363C535F50B54ADE25B798FE915DD5F44C3E67E (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, uint16_t ___value0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.String,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m0D6FB9A38A8E3695AB15F993E07B15B059DCF1C4 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, String_t* ___value0, int32_t ___maxLength1, const RuntimeMethod* method) ;
// System.Net.IPAddress System.Net.IPEndPoint::get_Address()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* IPEndPoint_get_Address_m72F783CB76E10E9DBDF680CCC1DAAED201BABB1C_inline (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m8E5EC9D4DC507B28075C5BCCD2C6E182761BD008 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Boolean System.String::IsNullOrEmpty(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_IsNullOrEmpty_m54CF0907E7C4F3AFB2E796A13DC751ECBB8DB64A (String_t* ___value0, const RuntimeMethod* method) ;
// System.Int32 System.String::get_Length()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<System.UInt64,FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate>::.ctor()
inline void Dictionary_2__ctor_m8EB72C4EC23EFF571DFEDF3AA392DF7D38CB64B4 (Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951* __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951*, const RuntimeMethod*))Dictionary_2__ctor_m5DA5AA64DE7BDB71265D475EF0B2D2E815A32E27_gshared)(__this, method);
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetSerializer::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSerializer__ctor_mAA76478A51CF1FB20AC3BACE500372304165E227 (NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetSerializer::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSerializer__ctor_mAF76FAA200E47115DA26D4557E06B4D886ED8439 (NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9* __this, int32_t ___maxStringLength0, const RuntimeMethod* method) ;
// System.Boolean System.Collections.Generic.Dictionary`2<System.UInt64,FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate>::TryGetValue(TKey,TValue&)
inline bool Dictionary_2_TryGetValue_mB702FBA6DE5A2796549B6AB3BAB29390901942C2 (Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951* __this, uint64_t ___key0, SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5** ___value1, const RuntimeMethod* method)
{
	return ((  bool (*) (Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951*, uint64_t, SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5**, const RuntimeMethod*))Dictionary_2_TryGetValue_m610AC9FAFAA596802CD176D49D81FC2E15278ABF_gshared)(__this, ___key0, ___value1, method);
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.ParseException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ParseException__ctor_m8ED6DE7E0C569D47FFBCC0CEFB36054B89887A89 (ParseException_tE9D15FFE30722D3687DD4C6333903C530E2D0261* __this, String_t* ___message0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::ReadPacket(FlyingWormConsole3.LiteNetLib.Utils.NetDataReader)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacketProcessor_ReadPacket_m206C9605EF5B79980E88806C62B9EC7D5615F283 (NetPacketProcessor_tC008551263AC0F46812FF0AE3127ABF0D975E873* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::ReadPacket(FlyingWormConsole3.LiteNetLib.Utils.NetDataReader,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacketProcessor_ReadPacket_m2B71725B7C1227473CF780FD9A915A2244FBC4CD (NetPacketProcessor_tC008551263AC0F46812FF0AE3127ABF0D975E873* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate::Invoke(FlyingWormConsole3.LiteNetLib.Utils.NetDataReader,System.Object)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_inline (SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method) ;
// System.Void System.Exception::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Exception__ctor_m9B2BD92CD68916245A75109105D9071C9D430E7F (Exception_t* __this, String_t* ___message0, const RuntimeMethod* method) ;
// System.Void System.Collections.Generic.Dictionary`2<System.Type,FlyingWormConsole3.LiteNetLib.Utils.NetSerializer/CustomType>::.ctor()
inline void Dictionary_2__ctor_m18669342C6857F217E5625EA0AD8ED2DD525FBB5 (Dictionary_2_t5EE36A10F9DEF39A9016F3998D768275F9B3C326* __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t5EE36A10F9DEF39A9016F3998D768275F9B3C326*, const RuntimeMethod*))Dictionary_2__ctor_m5B32FBC624618211EB461D59CFBB10E987FD1329_gshared)(__this, method);
}
// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_Bytes()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// System.TimeSpan FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::GetTimeSpan32(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A NtpPacket_GetTimeSpan32_mB1470558FF64457DC2A58DEFA8316D51F191C7A2 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, const RuntimeMethod* method) ;
// System.UInt32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::GetUInt32BE(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t NtpPacket_GetUInt32BE_m46AA79D2DE54C64DE667B3CF89F5E6E4595B4780 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, const RuntimeMethod* method) ;
// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::GetDateTime64(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_GetDateTime64_m0C883DDC0D399BA2A28321B6FF4B1490EF94C214 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::SetDateTime64(System.Int32,System.Nullable`1<System.DateTime>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_SetDateTime64_m7BE5278F49B27CC52BDBB252ED4E24640A3BBB17 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC ___value1, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::CheckTimestamps()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_CheckTimestamps_m3CCEBF5C7B0D0BCA9F164E284A27360D31FAF2A4 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_ReceiveTimestamp()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_get_ReceiveTimestamp_m28518CC74140DFEDBA65A56700161E922AFF68B1 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// T System.Nullable`1<System.DateTime>::get_Value()
inline DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991 (Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC* __this, const RuntimeMethod* method)
{
	return ((  DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D (*) (Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC*, const RuntimeMethod*))Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_gshared)(__this, method);
}
// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_OriginTimestamp()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_get_OriginTimestamp_m197B753E1FB93333A8C71E80FB00F5956A831934 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// System.TimeSpan System.DateTime::op_Subtraction(System.DateTime,System.DateTime)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A DateTime_op_Subtraction_m41335EF0E6DCD52B23C64916CB973A0B4A9E0387 (DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___d10, DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___d21, const RuntimeMethod* method) ;
// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_DestinationTimestamp()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_get_DestinationTimestamp_mE42F8228932E2256F3F9FF2181059183172B2A9F_inline (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_TransmitTimestamp()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_get_TransmitTimestamp_m44347BB393BE6B6E0562BC198C467E2BBD1F458B (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// System.TimeSpan System.TimeSpan::op_Addition(System.TimeSpan,System.TimeSpan)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TimeSpan_op_Addition_m4CA781FA121EB39944AE59C6BDD9304C42E74DFB (TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___t10, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___t21, const RuntimeMethod* method) ;
// System.TimeSpan System.TimeSpan::op_Subtraction(System.TimeSpan,System.TimeSpan)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TimeSpan_op_Subtraction_mFFB8933364C5E1E2187CA0605445893F2872FBB8 (TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___t10, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___t21, const RuntimeMethod* method) ;
// System.Int64 System.TimeSpan::get_Ticks()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int64_t TimeSpan_get_Ticks_mC50131E57621F29FACC53B3241432ABB874FA1B5_inline (TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* __this, const RuntimeMethod* method) ;
// System.TimeSpan System.TimeSpan::FromTicks(System.Int64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TimeSpan_FromTicks_mFA529928E79B4BF5EC0265418844B196D8979A73 (int64_t ___value0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::.ctor(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket__ctor_m960562C86ECE0569F0E3D017222FD6E8DC9AAD31 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::set_Mode(FlyingWormConsole3.LiteNetLib.Utils.NtpMode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_set_Mode_m1B6AB1ECACD207C0CB5D7EF156D4A8C812C6461A (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::set_VersionNumber(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_set_VersionNumber_mCD751D64904F8310FA57DF1CA1FADB5459803694 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___value0, const RuntimeMethod* method) ;
// System.Void System.Nullable`1<System.DateTime>::.ctor(T)
inline void Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF (Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC* __this, DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___value0, const RuntimeMethod* method)
{
	((  void (*) (Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC*, DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D, const RuntimeMethod*))Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF_gshared)(__this, ___value0, method);
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::set_TransmitTimestamp(System.Nullable`1<System.DateTime>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_set_TransmitTimestamp_mAC3742940FC5B29A1890993B55B14A934774A70E (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC ___value0, const RuntimeMethod* method) ;
// System.Void System.ArgumentException::.ctor(System.String,System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentException__ctor_m8F9D40CE19D19B698A70F9A258640EB52DB39B62 (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* __this, String_t* ___message0, String_t* ___paramName1, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::set_Bytes(System.Byte[])
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void NtpPacket_set_Bytes_m5DB6D8A635A7BEBA520F0509B46508BB6C42BF37_inline (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::set_DestinationTimestamp(System.Nullable`1<System.DateTime>)
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void NtpPacket_set_DestinationTimestamp_mAA50539DD3E9E8D85DEE9E64F3D153570F065FB1_inline (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC ___value0, const RuntimeMethod* method) ;
// FlyingWormConsole3.LiteNetLib.Utils.NtpMode FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_Mode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_get_Mode_m87035DFF507EDCB50A20ACBED4E96C6B81685A82 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// System.Void System.InvalidOperationException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162 (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* __this, String_t* ___message0, const RuntimeMethod* method) ;
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_VersionNumber()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_get_VersionNumber_m347EE1EAF30F02BDEA43D5F8FBFEE852154894F8 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// System.Boolean System.Nullable`1<System.DateTime>::get_HasValue()
inline bool Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_inline (Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC*, const RuntimeMethod*))Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_gshared_inline)(__this, method);
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_Stratum()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_get_Stratum_mC9D6B92A3A8F7C614C6F516917C7465C962E2D57 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// System.UInt32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_ReferenceId()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t NtpPacket_get_ReferenceId_mB909F1CBCCFB444CE0A51409253BA41B220EF087 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// System.String System.String::Format(System.String,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Format_m8C122B26BC5AA10E2550AECA16E57DAE10F07E30 (String_t* ___format0, RuntimeObject* ___arg01, const RuntimeMethod* method) ;
// FlyingWormConsole3.LiteNetLib.Utils.NtpLeapIndicator FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_LeapIndicator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_get_LeapIndicator_mE780E5229CFAF4136F83BB6FE32C44F468F52F74 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// System.UInt64 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::GetUInt64BE(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t NtpPacket_GetUInt64BE_m00F31C44FC7380393A61453B6B70FD7D3F387D42 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, const RuntimeMethod* method) ;
// System.Int64 System.Convert::ToInt64(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t Convert_ToInt64_m5B707D520332D512D2B81C10D2F4044FA468C3A4 (double ___value0, const RuntimeMethod* method) ;
// System.Void System.DateTime::.ctor(System.Int64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DateTime__ctor_m64AFCE84ABB24698256EB9F635EFD0A221823441 (DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* __this, int64_t ___ticks0, const RuntimeMethod* method) ;
// System.UInt64 System.Convert::ToUInt64(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t Convert_ToUInt64_m4990F2CE28C4CE3079D458BA578EFBA46D875B3E (double ___value0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::SetUInt64BE(System.Int32,System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_SetUInt64BE_m455597219DFE9922931AF25FC972D7B59767BCAE (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, uint64_t ___value1, const RuntimeMethod* method) ;
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::GetInt32BE(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_GetInt32BE_m01746D745E6D9E3B705A31519FF451CFD10C09AD (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, const RuntimeMethod* method) ;
// System.TimeSpan System.TimeSpan::FromSeconds(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TimeSpan_FromSeconds_mE585CC8180040ED064DC8B6546E6C94A129BFFC5 (double ___value0, const RuntimeMethod* method) ;
// System.UInt64 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::SwapEndianness(System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t NtpPacket_SwapEndianness_m4177304D7E853C3D8FF98217ADC9F0A7C7442332 (uint64_t ___x0, const RuntimeMethod* method) ;
// System.UInt32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::SwapEndianness(System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t NtpPacket_SwapEndianness_m2C5DA2CC50F40E084890E6F948E42E6B8207F3B4 (uint32_t ___x0, const RuntimeMethod* method) ;
// System.Void System.DateTime::.ctor(System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void DateTime__ctor_mA3BF7CE28807F0A02634FD43913FAAFD989CEE88 (DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* __this, int32_t ___year0, int32_t ___month1, int32_t ___day2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket__ctor_m443C2A6A5BA9A9172E59F1BC1B9C5DE485E5B2E7 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) ;
// System.Int32 FlyingWormConsole3.LiteNetLib.NetSocket::SendTo(System.Byte[],System.Int32,System.Int32,System.Net.IPEndPoint,System.Net.Sockets.SocketError&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetSocket_SendTo_mEBB7CBE898383F3C5E94F453005B7F3A68C1D469 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___data0, int32_t ___offset1, int32_t ___size2, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___remoteEndPoint3, int32_t* ___errorCode4, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Layers.PacketLayerBase::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PacketLayerBase__ctor_m8F0B3F00218E79F387DFD9B589BE5AE6FE460593 (PacketLayerBase_t45CF70BC52F3CBAE7EC7F885A16F3FB7753C23C6* __this, int32_t ___extraPacketSizeForLayer0, const RuntimeMethod* method) ;
// System.UInt32 FlyingWormConsole3.LiteNetLib.Utils.CRC32C::Compute(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t CRC32C_Compute_m6ABD4B61DCD74A62046F40911343ECD3F4C45E38 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___input0, int32_t ___offset1, int32_t ___length2, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XorEncryptLayer__ctor_m0DD3A792F23BE3D9F27897069BAB87EE13C744A0 (XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198* __this, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer::SetKey(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XorEncryptLayer_SetKey_mC28876F5A98E49511AD705C719910983A1FE748A (XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___key0, const RuntimeMethod* method) ;
// System.Void FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer::SetKey(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XorEncryptLayer_SetKey_m9DB3995363BB05B8A35B07BF208AD2F4A856E270 (XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198* __this, String_t* ___key0, const RuntimeMethod* method) ;
// System.Char System.String::get_Chars(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3 (String_t* __this, int32_t ___index0, const RuntimeMethod* method) ;
// System.Void System.Array::Clear(System.Array,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Array_Clear_m48B57EC27CADC3463CA98A33373D557DA587FF1B (RuntimeArray* ___array0, int32_t ___index1, int32_t ___length2, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.NetPeer/IncomingFragments::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IncomingFragments__ctor_m0227078114A0D0610509AF3BCCA79CE8E1F22023 (IncomingFragments_t062075061BAB497A25F999656003E8A69AE21661* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Int32 FlyingWormConsole3.LiteNetLib.NetSocket::get_LocalPort()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetSocket_get_LocalPort_mD789615311CD7E8F790B46A9D99C72CCAF3D78E3 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, const RuntimeMethod* method) 
{
	{
		// public int LocalPort { get; private set; }
		int32_t L_0 = __this->___U3CLocalPortU3Ek__BackingField_11;
		return L_0;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetSocket::set_LocalPort(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSocket_set_LocalPort_m5131B89E161C3020415092F25760AB4038583ED9 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		// public int LocalPort { get; private set; }
		int32_t L_0 = ___value0;
		__this->___U3CLocalPortU3Ek__BackingField_11 = L_0;
		return;
	}
}
// System.Int16 FlyingWormConsole3.LiteNetLib.NetSocket::get_Ttl()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int16_t NetSocket_get_Ttl_m314FB1A53914D3EAD062F1D5FE747697FA9508F8 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (_udpSocketv4.AddressFamily == AddressFamily.InterNetworkV6)
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_0 = __this->____udpSocketv4_1;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = Socket_get_AddressFamily_m42C390D31345314080EC35356ACFBBFF7E1123E5_inline(L_0, NULL);
		if ((!(((uint32_t)L_1) == ((uint32_t)((int32_t)23)))))
		{
			goto IL_0024;
		}
	}
	{
		// return (short)_udpSocketv4.GetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.HopLimit);
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_2 = __this->____udpSocketv4_1;
		NullCheck(L_2);
		RuntimeObject* L_3;
		L_3 = Socket_GetSocketOption_m39C453F9FA4D1EC664C660851CED73271B1162A2(L_2, ((int32_t)41), ((int32_t)21), NULL);
		return ((*(int16_t*)((int16_t*)(int16_t*)UnBox(L_3, Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_il2cpp_TypeInfo_var))));
	}

IL_0024:
	{
		// return _udpSocketv4.Ttl;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_4 = __this->____udpSocketv4_1;
		NullCheck(L_4);
		int16_t L_5;
		L_5 = Socket_get_Ttl_m385CF8BC3C7F4050AAE714C777FB7C6BBCC23472(L_4, NULL);
		return L_5;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetSocket::set_Ttl(System.Int16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSocket_set_Ttl_mBA8E187DB9240FD9DDE34664E679C9AFD1975117 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, int16_t ___value0, const RuntimeMethod* method) 
{
	{
		// if (_udpSocketv4.AddressFamily == AddressFamily.InterNetworkV6)
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_0 = __this->____udpSocketv4_1;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = Socket_get_AddressFamily_m42C390D31345314080EC35356ACFBBFF7E1123E5_inline(L_0, NULL);
		if ((!(((uint32_t)L_1) == ((uint32_t)((int32_t)23)))))
		{
			goto IL_0020;
		}
	}
	{
		// _udpSocketv4.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.HopLimit, value);
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_2 = __this->____udpSocketv4_1;
		int16_t L_3 = ___value0;
		NullCheck(L_2);
		Socket_SetSocketOption_m19085C1856DE21260294680B7725610D71D66A58(L_2, ((int32_t)41), ((int32_t)21), L_3, NULL);
		return;
	}

IL_0020:
	{
		// _udpSocketv4.Ttl = value;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_4 = __this->____udpSocketv4_1;
		int16_t L_5 = ___value0;
		NullCheck(L_4);
		Socket_set_Ttl_m181E7794B74DEB52091B3D0CDDB745717B2A4F67(L_4, L_5, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetSocket::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSocket__cctor_m6B3234849A4105B5EA5FA68A694A3F1ABDEB86D9 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral5486305FD2AB390DB38D4EE1F93074A684EDAF0F);
		s_Il2CppMethodInitialized = true;
	}
	{
		// private static readonly IPAddress MulticastAddressV6 = IPAddress.Parse("ff02::1");
		il2cpp_codegen_runtime_class_init_inline(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_0;
		L_0 = IPAddress_Parse_mD7BEF4D6060D8BE776F559C5F81F195A9917CF1C(_stringLiteral5486305FD2AB390DB38D4EE1F93074A684EDAF0F, NULL);
		((NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_StaticFields*)il2cpp_codegen_static_fields_for(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var))->___MulticastAddressV6_9 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_StaticFields*)il2cpp_codegen_static_fields_for(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var))->___MulticastAddressV6_9), (void*)L_0);
		// IPv6Support = Socket.OSSupportsIPv6;
		il2cpp_codegen_runtime_class_init_inline(Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E_il2cpp_TypeInfo_var);
		bool L_1;
		L_1 = Socket_get_OSSupportsIPv6_m45BC8FD78EDFCB853CA509A8DDD23EF42203B6D4(NULL);
		((NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_StaticFields*)il2cpp_codegen_static_fields_for(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var))->___IPv6Support_10 = L_1;
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetSocket::.ctor(FlyingWormConsole3.LiteNetLib.NetManager)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSocket__ctor_mB78769A78CC4D803A5A03C2930E2D537216A0C28 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* ___listener0, const RuntimeMethod* method) 
{
	{
		// public NetSocket(NetManager listener)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// _listener = listener;
		NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_0 = ___listener0;
		__this->____listener_7 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____listener_7), (void*)L_0);
		// }
		return;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.NetSocket::IsActive()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetSocket_IsActive_m898D8B9D8568756AFCEF631AD2EAA82B813BA65F (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, const RuntimeMethod* method) 
{
	{
		// return IsRunning;
		bool L_0 = __this->___IsRunning_12;
		il2cpp_codegen_memory_barrier();
		return L_0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.NetSocket::ProcessError(System.Net.Sockets.SocketException,System.Net.EndPoint)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetSocket_ProcessError_mF5A149E092372829D95D5A0C22A4602B2A8A4720 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* ___ex0, EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* ___bufferEndPoint1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral7B3C7E8130D1BF6705EFAAA4A72196B92A79769A);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// switch (ex.SocketErrorCode)
		SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_0 = ___ex0;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = SocketException_get_SocketErrorCode_m84FB2D308F046A24A1355975F3BF689C988224C6(L_0, NULL);
		V_0 = L_1;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) > ((int32_t)((int32_t)10038))))
		{
			goto IL_0021;
		}
	}
	{
		int32_t L_3 = V_0;
		if ((((int32_t)L_3) == ((int32_t)((int32_t)10004))))
		{
			goto IL_003b;
		}
	}
	{
		int32_t L_4 = V_0;
		if ((((int32_t)L_4) == ((int32_t)((int32_t)10038))))
		{
			goto IL_003b;
		}
	}
	{
		goto IL_003d;
	}

IL_0021:
	{
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) == ((int32_t)((int32_t)10040))))
		{
			goto IL_007c;
		}
	}
	{
		int32_t L_6 = V_0;
		if ((((int32_t)L_6) == ((int32_t)((int32_t)10054))))
		{
			goto IL_007c;
		}
	}
	{
		int32_t L_7 = V_0;
		if ((((int32_t)L_7) == ((int32_t)((int32_t)10060))))
		{
			goto IL_007c;
		}
	}
	{
		goto IL_003d;
	}

IL_003b:
	{
		// return true;
		return (bool)1;
	}

IL_003d:
	{
		// NetDebug.WriteError("[R]Error code: {0} - {1}", (int)ex.SocketErrorCode,
		//     ex.ToString());
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_8 = (ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)(ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)SZArrayNew(ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var, (uint32_t)2);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_9 = L_8;
		SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_10 = ___ex0;
		NullCheck(L_10);
		int32_t L_11;
		L_11 = SocketException_get_SocketErrorCode_m84FB2D308F046A24A1355975F3BF689C988224C6(L_10, NULL);
		int32_t L_12 = ((int32_t)L_11);
		RuntimeObject* L_13 = Box(Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_il2cpp_TypeInfo_var, &L_12);
		NullCheck(L_9);
		ArrayElementTypeCheck (L_9, L_13);
		(L_9)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject*)L_13);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_14 = L_9;
		SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_15 = ___ex0;
		NullCheck(L_15);
		String_t* L_16;
		L_16 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_15);
		NullCheck(L_14);
		ArrayElementTypeCheck (L_14, L_16);
		(L_14)->SetAt(static_cast<il2cpp_array_size_t>(1), (RuntimeObject*)L_16);
		il2cpp_codegen_runtime_class_init_inline(NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var);
		NetDebug_WriteError_m950356DF95AA0DB66BD907F841C4C9BBDCFF25E3(_stringLiteral7B3C7E8130D1BF6705EFAAA4A72196B92A79769A, L_14, NULL);
		// _listener.OnMessageReceived(null, ex.SocketErrorCode, (IPEndPoint)bufferEndPoint);
		NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_17 = __this->____listener_7;
		SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_18 = ___ex0;
		NullCheck(L_18);
		int32_t L_19;
		L_19 = SocketException_get_SocketErrorCode_m84FB2D308F046A24A1355975F3BF689C988224C6(L_18, NULL);
		EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* L_20 = ___bufferEndPoint1;
		NullCheck(L_17);
		NetManager_OnMessageReceived_m7A0F0633BF526D18C57AE9EE0AA5AD12CB1AC5CF(L_17, (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED*)NULL, L_19, ((IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)CastclassClass((RuntimeObject*)L_20, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var)), NULL);
	}

IL_007c:
	{
		// return false;
		return (bool)0;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetSocket::ManualReceive()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSocket_ManualReceive_m31C8A1519AE883B42EF0B71F139DB1E98989FA72 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, const RuntimeMethod* method) 
{
	{
		// ManualReceive(_udpSocketv4, _bufferEndPointv4);
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_0 = __this->____udpSocketv4_1;
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_1 = __this->____bufferEndPointv4_5;
		bool L_2;
		L_2 = NetSocket_ManualReceive_m1241FB2E52D803C062FE595923EEDE40BD084417(__this, L_0, L_1, NULL);
		// if (_udpSocketv6 != null && _udpSocketv6 != _udpSocketv4)
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_3 = __this->____udpSocketv6_2;
		if (!L_3)
		{
			goto IL_003c;
		}
	}
	{
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_4 = __this->____udpSocketv6_2;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_5 = __this->____udpSocketv4_1;
		if ((((RuntimeObject*)(Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)L_4) == ((RuntimeObject*)(Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)L_5)))
		{
			goto IL_003c;
		}
	}
	{
		// ManualReceive(_udpSocketv6, _bufferEndPointv6);
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_6 = __this->____udpSocketv6_2;
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_7 = __this->____bufferEndPointv6_6;
		bool L_8;
		L_8 = NetSocket_ManualReceive_m1241FB2E52D803C062FE595923EEDE40BD084417(__this, L_6, L_7, NULL);
	}

IL_003c:
	{
		// }
		return;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.NetSocket::ManualReceive(System.Net.Sockets.Socket,System.Net.EndPoint)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetSocket_ManualReceive_m1241FB2E52D803C062FE595923EEDE40BD084417 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* ___socket0, EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* ___bufferEndPoint1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	bool V_1 = false;
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* V_2 = NULL;
	SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* V_3 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	try
	{// begin try (depth: 1)
		{
			// int available = socket.Available;
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_0 = ___socket0;
			NullCheck(L_0);
			int32_t L_1;
			L_1 = Socket_get_Available_mDF4623F5A739F3F642D25A8905E0AF35BD7D7757(L_0, NULL);
			V_0 = L_1;
			// if (available == 0)
			int32_t L_2 = V_0;
			if (L_2)
			{
				goto IL_005b_1;
			}
		}
		{
			// return false;
			V_1 = (bool)0;
			goto IL_0074;
		}

IL_000e_1:
		{
			// var packet = _listener.NetPacketPool.GetPacket(NetConstants.MaxPacketSize);
			NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_3 = __this->____listener_7;
			NullCheck(L_3);
			NetPacketPool_tECE1CA68CDADE3C4E45A5FBCA8B25CC30F62DBF3* L_4 = L_3->___NetPacketPool_22;
			il2cpp_codegen_runtime_class_init_inline(NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_il2cpp_TypeInfo_var);
			int32_t L_5 = ((NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_StaticFields*)il2cpp_codegen_static_fields_for(NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_il2cpp_TypeInfo_var))->___MaxPacketSize_12;
			NullCheck(L_4);
			NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_6;
			L_6 = NetPacketPool_GetPacket_mBB645C34FDEC48B469212DF385ABAA48456F942C(L_4, L_5, NULL);
			V_2 = L_6;
			// packet.Size = socket.ReceiveFrom(packet.RawData, 0, NetConstants.MaxPacketSize, SocketFlags.None,
			//     ref bufferEndPoint);
			NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_7 = V_2;
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_8 = ___socket0;
			NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_9 = V_2;
			NullCheck(L_9);
			ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_10 = L_9->___RawData_2;
			int32_t L_11 = ((NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_StaticFields*)il2cpp_codegen_static_fields_for(NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_il2cpp_TypeInfo_var))->___MaxPacketSize_12;
			NullCheck(L_8);
			int32_t L_12;
			L_12 = Socket_ReceiveFrom_m780282028E62CDD6021E3B8917656AC820878E6E(L_8, L_10, 0, L_11, 0, (&___bufferEndPoint1), NULL);
			NullCheck(L_7);
			L_7->___Size_3 = L_12;
			// _listener.OnMessageReceived(packet, 0, (IPEndPoint)bufferEndPoint);
			NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_13 = __this->____listener_7;
			NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_14 = V_2;
			EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* L_15 = ___bufferEndPoint1;
			NullCheck(L_13);
			NetManager_OnMessageReceived_m7A0F0633BF526D18C57AE9EE0AA5AD12CB1AC5CF(L_13, L_14, 0, ((IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)CastclassClass((RuntimeObject*)L_15, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var)), NULL);
			// available -= packet.Size;
			int32_t L_16 = V_0;
			NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_17 = V_2;
			NullCheck(L_17);
			int32_t L_18 = L_17->___Size_3;
			V_0 = ((int32_t)il2cpp_codegen_subtract(L_16, L_18));
		}

IL_005b_1:
		{
			// while (available > 0)
			int32_t L_19 = V_0;
			if ((((int32_t)L_19) > ((int32_t)0)))
			{
				goto IL_000e_1;
			}
		}
		{
			// }
			goto IL_0072;
		}
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&SocketException_t6D10102A62EA871BD31748E026A372DB6804083B_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0061;
		}
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ObjectDisposedException_tC5FB29E8E980E2010A2F6A5B9B791089419F89EB_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_006d;
		}
		throw e;
	}

CATCH_0061:
	{// begin catch(System.Net.Sockets.SocketException)
		// catch (SocketException ex)
		V_3 = ((SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*)IL2CPP_GET_ACTIVE_EXCEPTION(SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*));
		// return ProcessError(ex, bufferEndPoint);
		SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_20 = V_3;
		EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* L_21 = ___bufferEndPoint1;
		bool L_22;
		L_22 = NetSocket_ProcessError_mF5A149E092372829D95D5A0C22A4602B2A8A4720(__this, L_20, L_21, NULL);
		V_1 = L_22;
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_0074;
	}// end catch (depth: 1)

CATCH_006d:
	{// begin catch(System.ObjectDisposedException)
		// catch (ObjectDisposedException)
		// return true;
		V_1 = (bool)1;
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_0074;
	}// end catch (depth: 1)

IL_0072:
	{
		// return false;
		return (bool)0;
	}

IL_0074:
	{
		// }
		bool L_23 = V_1;
		return L_23;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetSocket::ReceiveLogic(System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSocket_ReceiveLogic_mB9B9845B26858ABC03AA0407E0CB399E68F3B9C7 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, RuntimeObject* ___state0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* V_0 = NULL;
	EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* V_1 = NULL;
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* V_2 = NULL;
	SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* V_3 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* G_B3_0 = NULL;
	{
		// Socket socket = (Socket)state;
		RuntimeObject* L_0 = ___state0;
		V_0 = ((Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)CastclassClass((RuntimeObject*)L_0, Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E_il2cpp_TypeInfo_var));
		// EndPoint bufferEndPoint = new IPEndPoint(socket.AddressFamily == AddressFamily.InterNetwork ? IPAddress.Any : IPAddress.IPv6Any, 0);
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_1 = V_0;
		NullCheck(L_1);
		int32_t L_2;
		L_2 = Socket_get_AddressFamily_m42C390D31345314080EC35356ACFBBFF7E1123E5_inline(L_1, NULL);
		if ((((int32_t)L_2) == ((int32_t)2)))
		{
			goto IL_0017;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_3 = ((IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_StaticFields*)il2cpp_codegen_static_fields_for(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var))->___IPv6Any_5;
		G_B3_0 = L_3;
		goto IL_001c;
	}

IL_0017:
	{
		il2cpp_codegen_runtime_class_init_inline(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_4 = ((IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_StaticFields*)il2cpp_codegen_static_fields_for(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var))->___Any_0;
		G_B3_0 = L_4;
	}

IL_001c:
	{
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_5 = (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)il2cpp_codegen_object_new(IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		NullCheck(L_5);
		IPEndPoint__ctor_m902C98F9E3F36B20B3C2E030AA91B62E2BC7A85A(L_5, G_B3_0, 0, NULL);
		V_1 = L_5;
		goto IL_0096;
	}

IL_0025:
	{
	}
	try
	{// begin try (depth: 1)
		{
			// if (socket.Available == 0 && !socket.Poll(ReceivePollingTime, SelectMode.SelectRead))
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_6 = V_0;
			NullCheck(L_6);
			int32_t L_7;
			L_7 = Socket_get_Available_mDF4623F5A739F3F642D25A8905E0AF35BD7D7757(L_6, NULL);
			if (L_7)
			{
				goto IL_003e_1;
			}
		}
		{
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_8 = V_0;
			NullCheck(L_8);
			bool L_9;
			L_9 = Socket_Poll_m65D8E383FBE5A1D4A115942182620422B6646B98(L_8, ((int32_t)500000), 0, NULL);
			if (L_9)
			{
				goto IL_003e_1;
			}
		}
		{
			// continue;
			goto IL_0096;
		}

IL_003e_1:
		{
			// packet = _listener.NetPacketPool.GetPacket(NetConstants.MaxPacketSize);
			NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_10 = __this->____listener_7;
			NullCheck(L_10);
			NetPacketPool_tECE1CA68CDADE3C4E45A5FBCA8B25CC30F62DBF3* L_11 = L_10->___NetPacketPool_22;
			il2cpp_codegen_runtime_class_init_inline(NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_il2cpp_TypeInfo_var);
			int32_t L_12 = ((NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_StaticFields*)il2cpp_codegen_static_fields_for(NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_il2cpp_TypeInfo_var))->___MaxPacketSize_12;
			NullCheck(L_11);
			NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_13;
			L_13 = NetPacketPool_GetPacket_mBB645C34FDEC48B469212DF385ABAA48456F942C(L_11, L_12, NULL);
			V_2 = L_13;
			// packet.Size = socket.ReceiveFrom(packet.RawData, 0, NetConstants.MaxPacketSize, SocketFlags.None,
			//     ref bufferEndPoint);
			NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_14 = V_2;
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_15 = V_0;
			NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_16 = V_2;
			NullCheck(L_16);
			ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_17 = L_16->___RawData_2;
			int32_t L_18 = ((NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_StaticFields*)il2cpp_codegen_static_fields_for(NetConstants_t1D9BBBF7445D99A12AF2471E7D6CF88EF3AC1779_il2cpp_TypeInfo_var))->___MaxPacketSize_12;
			NullCheck(L_15);
			int32_t L_19;
			L_19 = Socket_ReceiveFrom_m780282028E62CDD6021E3B8917656AC820878E6E(L_15, L_17, 0, L_18, 0, (&V_1), NULL);
			NullCheck(L_14);
			L_14->___Size_3 = L_19;
			// }
			goto IL_0083;
		}
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&SocketException_t6D10102A62EA871BD31748E026A372DB6804083B_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0071;
		}
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ObjectDisposedException_tC5FB29E8E980E2010A2F6A5B9B791089419F89EB_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0080;
		}
		throw e;
	}

CATCH_0071:
	{// begin catch(System.Net.Sockets.SocketException)
		{
			// catch (SocketException ex)
			V_3 = ((SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*)IL2CPP_GET_ACTIVE_EXCEPTION(SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*));
			// if (ProcessError(ex, bufferEndPoint))
			SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_20 = V_3;
			EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* L_21 = V_1;
			bool L_22;
			L_22 = NetSocket_ProcessError_mF5A149E092372829D95D5A0C22A4602B2A8A4720(__this, L_20, L_21, NULL);
			if (!L_22)
			{
				goto IL_007e;
			}
		}
		{
			// return;
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_009e;
		}

IL_007e:
		{
			// continue;
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_0096;
		}
	}// end catch (depth: 1)

CATCH_0080:
	{// begin catch(System.ObjectDisposedException)
		// catch (ObjectDisposedException)
		// return;
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_009e;
	}// end catch (depth: 1)

IL_0083:
	{
		// _listener.OnMessageReceived(packet, 0, (IPEndPoint)bufferEndPoint);
		NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_23 = __this->____listener_7;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_24 = V_2;
		EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* L_25 = V_1;
		NullCheck(L_23);
		NetManager_OnMessageReceived_m7A0F0633BF526D18C57AE9EE0AA5AD12CB1AC5CF(L_23, L_24, 0, ((IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)CastclassClass((RuntimeObject*)L_25, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var)), NULL);
	}

IL_0096:
	{
		// while (IsActive())
		bool L_26;
		L_26 = NetSocket_IsActive_m898D8B9D8568756AFCEF631AD2EAA82B813BA65F(__this, NULL);
		if (L_26)
		{
			goto IL_0025;
		}
	}

IL_009e:
	{
		// }
		return;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.NetSocket::Bind(System.Net.IPAddress,System.Net.IPAddress,System.Int32,System.Boolean,FlyingWormConsole3.LiteNetLib.IPv6Mode,System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetSocket_Bind_m89D98D7F39D8BC5194F0B76D78436004F45D2450 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ___addressIPv40, IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* ___addressIPv61, int32_t ___port2, bool ___reuseAddress3, int32_t ___ipv6Mode4, bool ___manualMode5, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetSocket_ReceiveLogic_mB9B9845B26858ABC03AA0407E0CB399E68F3B9C7_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral7DD59D78C0272A304AE65AAD0A7F0C9312EFBB7F);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralAA624EFEF42571531D3DE3085352235F0E96D583);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralB3F14BF976EFD974E34846B742502C802FABAE9D);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	int32_t V_1 = 0;
	int32_t G_B5_0 = 0;
	NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* G_B7_0 = NULL;
	NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* G_B6_0 = NULL;
	int32_t G_B8_0 = 0;
	NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* G_B8_1 = NULL;
	Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* G_B10_0 = NULL;
	NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* G_B10_1 = NULL;
	Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* G_B9_0 = NULL;
	NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* G_B9_1 = NULL;
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* G_B11_0 = NULL;
	Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* G_B11_1 = NULL;
	NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* G_B11_2 = NULL;
	{
		// if (IsActive())
		bool L_0;
		L_0 = NetSocket_IsActive_m898D8B9D8568756AFCEF631AD2EAA82B813BA65F(__this, NULL);
		if (!L_0)
		{
			goto IL_000a;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_000a:
	{
		// bool dualMode = ipv6Mode == IPv6Mode.DualMode && IPv6Support;
		int32_t L_1 = ___ipv6Mode4;
		if ((!(((uint32_t)L_1) == ((uint32_t)2))))
		{
			goto IL_0016;
		}
	}
	{
		il2cpp_codegen_runtime_class_init_inline(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var);
		bool L_2 = ((NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_StaticFields*)il2cpp_codegen_static_fields_for(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var))->___IPv6Support_10;
		G_B5_0 = ((int32_t)(L_2));
		goto IL_0017;
	}

IL_0016:
	{
		G_B5_0 = 0;
	}

IL_0017:
	{
		V_0 = (bool)G_B5_0;
		// _udpSocketv4 = new Socket(
		//     dualMode ? AddressFamily.InterNetworkV6 : AddressFamily.InterNetwork,
		//     SocketType.Dgram,
		//     ProtocolType.Udp);
		bool L_3 = V_0;
		G_B6_0 = __this;
		if (L_3)
		{
			G_B7_0 = __this;
			goto IL_001f;
		}
	}
	{
		G_B8_0 = 2;
		G_B8_1 = G_B6_0;
		goto IL_0021;
	}

IL_001f:
	{
		G_B8_0 = ((int32_t)23);
		G_B8_1 = G_B7_0;
	}

IL_0021:
	{
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_4 = (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)il2cpp_codegen_object_new(Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E_il2cpp_TypeInfo_var);
		NullCheck(L_4);
		Socket__ctor_m35F1F4B4872E251867DA16460F06E903A30E4595(L_4, G_B8_0, 2, ((int32_t)17), NULL);
		NullCheck(G_B8_1);
		G_B8_1->____udpSocketv4_1 = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&G_B8_1->____udpSocketv4_1), (void*)L_4);
		// if (!BindSocket(_udpSocketv4, new IPEndPoint(dualMode ? addressIPv6 : addressIPv4, port), reuseAddress, ipv6Mode))
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_5 = __this->____udpSocketv4_1;
		bool L_6 = V_0;
		G_B9_0 = L_5;
		G_B9_1 = __this;
		if (L_6)
		{
			G_B10_0 = L_5;
			G_B10_1 = __this;
			goto IL_003b;
		}
	}
	{
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_7 = ___addressIPv40;
		G_B11_0 = L_7;
		G_B11_1 = G_B9_0;
		G_B11_2 = G_B9_1;
		goto IL_003c;
	}

IL_003b:
	{
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_8 = ___addressIPv61;
		G_B11_0 = L_8;
		G_B11_1 = G_B10_0;
		G_B11_2 = G_B10_1;
	}

IL_003c:
	{
		int32_t L_9 = ___port2;
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_10 = (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)il2cpp_codegen_object_new(IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		NullCheck(L_10);
		IPEndPoint__ctor_m902C98F9E3F36B20B3C2E030AA91B62E2BC7A85A(L_10, G_B11_0, L_9, NULL);
		bool L_11 = ___reuseAddress3;
		int32_t L_12 = ___ipv6Mode4;
		NullCheck(G_B11_2);
		bool L_13;
		L_13 = NetSocket_BindSocket_mBA79B7AC17A4E04F397AA744126B2015F991570F(G_B11_2, G_B11_1, L_10, L_11, L_12, NULL);
		if (L_13)
		{
			goto IL_004f;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_004f:
	{
		// LocalPort = ((IPEndPoint) _udpSocketv4.LocalEndPoint).Port;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_14 = __this->____udpSocketv4_1;
		NullCheck(L_14);
		EndPoint_t6233F4E2EB9F0F2D36E187F12BE050E6D8B73564* L_15;
		L_15 = Socket_get_LocalEndPoint_m3A2B4E60F0096E2DB31F7C28EF3CDE148D256E26(L_14, NULL);
		NullCheck(((IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)CastclassClass((RuntimeObject*)L_15, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var)));
		int32_t L_16;
		L_16 = IPEndPoint_get_Port_mFBE1AF1C9CC7E68A46BF46AD3869CC9DC01CF429_inline(((IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)CastclassClass((RuntimeObject*)L_15, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var)), NULL);
		NetSocket_set_LocalPort_m5131B89E161C3020415092F25760AB4038583ED9_inline(__this, L_16, NULL);
		// if (dualMode)
		bool L_17 = V_0;
		if (!L_17)
		{
			goto IL_0079;
		}
	}
	{
		// _udpSocketv6 = _udpSocketv4;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_18 = __this->____udpSocketv4_1;
		__this->____udpSocketv6_2 = L_18;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____udpSocketv6_2), (void*)L_18);
	}

IL_0079:
	{
		// IsRunning = true;
		il2cpp_codegen_memory_barrier();
		__this->___IsRunning_12 = (bool)1;
		// if (!manualMode)
		bool L_19 = ___manualMode5;
		if (L_19)
		{
			goto IL_00da;
		}
	}
	{
		// _threadv4 = new Thread(ReceiveLogic)
		// {
		//     Name = "SocketThreadv4(" + LocalPort + ")",
		//     IsBackground = true
		// };
		ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9* L_20 = (ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9*)il2cpp_codegen_object_new(ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9_il2cpp_TypeInfo_var);
		NullCheck(L_20);
		ParameterizedThreadStart__ctor_m31EA734851CB478E822BAB7E1B479CA4FDBF2718(L_20, __this, (intptr_t)((void*)NetSocket_ReceiveLogic_mB9B9845B26858ABC03AA0407E0CB399E68F3B9C7_RuntimeMethod_var), NULL);
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_21 = (Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F*)il2cpp_codegen_object_new(Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F_il2cpp_TypeInfo_var);
		NullCheck(L_21);
		Thread__ctor_m7319B115C7E11770EEEC7F1D4A01A50E29550700(L_21, L_20, NULL);
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_22 = L_21;
		int32_t L_23;
		L_23 = NetSocket_get_LocalPort_mD789615311CD7E8F790B46A9D99C72CCAF3D78E3_inline(__this, NULL);
		V_1 = L_23;
		String_t* L_24;
		L_24 = Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5((&V_1), NULL);
		String_t* L_25;
		L_25 = String_Concat_m9B13B47FCB3DF61144D9647DDA05F527377251B0(_stringLiteralAA624EFEF42571531D3DE3085352235F0E96D583, L_24, _stringLiteralB3F14BF976EFD974E34846B742502C802FABAE9D, NULL);
		NullCheck(L_22);
		Thread_set_Name_m53E2BA6E84C04A6393EA5E470E516703CB892E4A(L_22, L_25, NULL);
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_26 = L_22;
		NullCheck(L_26);
		Thread_set_IsBackground_m45F00BD4C46F9B8A7C46A20A170B22BABB8FBA30(L_26, (bool)1, NULL);
		__this->____threadv4_3 = L_26;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____threadv4_3), (void*)L_26);
		// _threadv4.Start(_udpSocketv4);
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_27 = __this->____threadv4_3;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_28 = __this->____udpSocketv4_1;
		NullCheck(L_27);
		Thread_Start_m64E3F27883C3CCCE7209F5D2BD268A33D4C71566(L_27, L_28, NULL);
		goto IL_00eb;
	}

IL_00da:
	{
		// _bufferEndPointv4 = new IPEndPoint(IPAddress.Any, 0);
		il2cpp_codegen_runtime_class_init_inline(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_29 = ((IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_StaticFields*)il2cpp_codegen_static_fields_for(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var))->___Any_0;
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_30 = (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)il2cpp_codegen_object_new(IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		NullCheck(L_30);
		IPEndPoint__ctor_m902C98F9E3F36B20B3C2E030AA91B62E2BC7A85A(L_30, L_29, 0, NULL);
		__this->____bufferEndPointv4_5 = L_30;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____bufferEndPointv4_5), (void*)L_30);
	}

IL_00eb:
	{
		// if (!IPv6Support || ipv6Mode != IPv6Mode.SeparateSocket)
		il2cpp_codegen_runtime_class_init_inline(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var);
		bool L_31 = ((NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_StaticFields*)il2cpp_codegen_static_fields_for(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var))->___IPv6Support_10;
		if (!L_31)
		{
			goto IL_00f7;
		}
	}
	{
		int32_t L_32 = ___ipv6Mode4;
		if ((((int32_t)L_32) == ((int32_t)1)))
		{
			goto IL_00f9;
		}
	}

IL_00f7:
	{
		// return true;
		return (bool)1;
	}

IL_00f9:
	{
		// _udpSocketv6 = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_33 = (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)il2cpp_codegen_object_new(Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E_il2cpp_TypeInfo_var);
		NullCheck(L_33);
		Socket__ctor_m35F1F4B4872E251867DA16460F06E903A30E4595(L_33, ((int32_t)23), 2, ((int32_t)17), NULL);
		__this->____udpSocketv6_2 = L_33;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____udpSocketv6_2), (void*)L_33);
		// if (BindSocket(_udpSocketv6, new IPEndPoint(addressIPv6, LocalPort), reuseAddress, ipv6Mode))
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_34 = __this->____udpSocketv6_2;
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_35 = ___addressIPv61;
		int32_t L_36;
		L_36 = NetSocket_get_LocalPort_mD789615311CD7E8F790B46A9D99C72CCAF3D78E3_inline(__this, NULL);
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_37 = (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)il2cpp_codegen_object_new(IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		NullCheck(L_37);
		IPEndPoint__ctor_m902C98F9E3F36B20B3C2E030AA91B62E2BC7A85A(L_37, L_35, L_36, NULL);
		bool L_38 = ___reuseAddress3;
		int32_t L_39 = ___ipv6Mode4;
		bool L_40;
		L_40 = NetSocket_BindSocket_mBA79B7AC17A4E04F397AA744126B2015F991570F(__this, L_34, L_37, L_38, L_39, NULL);
		if (!L_40)
		{
			goto IL_0190;
		}
	}
	{
		// if (manualMode)
		bool L_41 = ___manualMode5;
		if (!L_41)
		{
			goto IL_013e;
		}
	}
	{
		// _bufferEndPointv6 = new IPEndPoint(IPAddress.IPv6Any, 0);
		il2cpp_codegen_runtime_class_init_inline(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_42 = ((IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_StaticFields*)il2cpp_codegen_static_fields_for(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var))->___IPv6Any_5;
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_43 = (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)il2cpp_codegen_object_new(IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		NullCheck(L_43);
		IPEndPoint__ctor_m902C98F9E3F36B20B3C2E030AA91B62E2BC7A85A(L_43, L_42, 0, NULL);
		__this->____bufferEndPointv6_6 = L_43;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____bufferEndPointv6_6), (void*)L_43);
		goto IL_0190;
	}

IL_013e:
	{
		// _threadv6 = new Thread(ReceiveLogic)
		// {
		//     Name = "SocketThreadv6(" + LocalPort + ")",
		//     IsBackground = true
		// };
		ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9* L_44 = (ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9*)il2cpp_codegen_object_new(ParameterizedThreadStart_tAA8FDC4E868056A7CB7CB2C4AB4986039B1D91E9_il2cpp_TypeInfo_var);
		NullCheck(L_44);
		ParameterizedThreadStart__ctor_m31EA734851CB478E822BAB7E1B479CA4FDBF2718(L_44, __this, (intptr_t)((void*)NetSocket_ReceiveLogic_mB9B9845B26858ABC03AA0407E0CB399E68F3B9C7_RuntimeMethod_var), NULL);
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_45 = (Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F*)il2cpp_codegen_object_new(Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F_il2cpp_TypeInfo_var);
		NullCheck(L_45);
		Thread__ctor_m7319B115C7E11770EEEC7F1D4A01A50E29550700(L_45, L_44, NULL);
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_46 = L_45;
		int32_t L_47;
		L_47 = NetSocket_get_LocalPort_mD789615311CD7E8F790B46A9D99C72CCAF3D78E3_inline(__this, NULL);
		V_1 = L_47;
		String_t* L_48;
		L_48 = Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5((&V_1), NULL);
		String_t* L_49;
		L_49 = String_Concat_m9B13B47FCB3DF61144D9647DDA05F527377251B0(_stringLiteral7DD59D78C0272A304AE65AAD0A7F0C9312EFBB7F, L_48, _stringLiteralB3F14BF976EFD974E34846B742502C802FABAE9D, NULL);
		NullCheck(L_46);
		Thread_set_Name_m53E2BA6E84C04A6393EA5E470E516703CB892E4A(L_46, L_49, NULL);
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_50 = L_46;
		NullCheck(L_50);
		Thread_set_IsBackground_m45F00BD4C46F9B8A7C46A20A170B22BABB8FBA30(L_50, (bool)1, NULL);
		__this->____threadv6_4 = L_50;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____threadv6_4), (void*)L_50);
		// _threadv6.Start(_udpSocketv6);
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_51 = __this->____threadv6_4;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_52 = __this->____udpSocketv6_2;
		NullCheck(L_51);
		Thread_Start_m64E3F27883C3CCCE7209F5D2BD268A33D4C71566(L_51, L_52, NULL);
	}

IL_0190:
	{
		// return true;
		return (bool)1;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.NetSocket::BindSocket(System.Net.Sockets.Socket,System.Net.IPEndPoint,System.Boolean,FlyingWormConsole3.LiteNetLib.IPv6Mode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetSocket_BindSocket_mBA79B7AC17A4E04F397AA744126B2015F991570F (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* ___socket0, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___ep1, bool ___reuseAddress2, int32_t ___ipv6Mode3, const RuntimeMethod* method) 
{
	SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* V_0 = NULL;
	SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* V_1 = NULL;
	Exception_t* V_2 = NULL;
	SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* V_3 = NULL;
	int32_t V_4 = 0;
	SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* V_5 = NULL;
	bool V_6 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 2> __active_exceptions;
	{
		// socket.ReceiveTimeout = 500;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_0 = ___socket0;
		NullCheck(L_0);
		Socket_set_ReceiveTimeout_m64104AED8D1B18294EB55BDA58DC291A4BEEAD9B(L_0, ((int32_t)500), NULL);
		// socket.SendTimeout = 500;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_1 = ___socket0;
		NullCheck(L_1);
		Socket_set_SendTimeout_m3C8E026F2961EBB32E1EA7B66657DE53E8A60679(L_1, ((int32_t)500), NULL);
		// socket.ReceiveBufferSize = NetConstants.SocketBufferSize;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_2 = ___socket0;
		NullCheck(L_2);
		Socket_set_ReceiveBufferSize_mFCBD973C71C5E4883D3E3C6E822652373ED9CCD6(L_2, ((int32_t)1048576), NULL);
		// socket.SendBufferSize = NetConstants.SocketBufferSize;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_3 = ___socket0;
		NullCheck(L_3);
		Socket_set_SendBufferSize_mBFC47E7A4581A220FBFE8B113CE828EFD7F4EF33(L_3, ((int32_t)1048576), NULL);
	}
	try
	{// begin try (depth: 1)
		// socket.ExclusiveAddressUse = !reuseAddress;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_4 = ___socket0;
		bool L_5 = ___reuseAddress2;
		NullCheck(L_4);
		Socket_set_ExclusiveAddressUse_m3F9A655F123086A025AD1736933B0754A5A6DF7F(L_4, (bool)((((int32_t)L_5) == ((int32_t)0))? 1 : 0), NULL);
		// socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, reuseAddress);
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_6 = ___socket0;
		bool L_7 = ___reuseAddress2;
		NullCheck(L_6);
		Socket_SetSocketOption_mE47F5DEEA190E45317AEEE6F1506940CB8E943A1(L_6, ((int32_t)65535), 4, L_7, NULL);
		// }
		goto IL_0048;
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&RuntimeObject_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0045;
		}
		throw e;
	}

CATCH_0045:
	{// begin catch(System.Object)
		// catch
		// }
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_0048;
	}// end catch (depth: 1)

IL_0048:
	{
		// if (socket.AddressFamily == AddressFamily.InterNetwork)
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_8 = ___socket0;
		NullCheck(L_8);
		int32_t L_9;
		L_9 = Socket_get_AddressFamily_m42C390D31345314080EC35356ACFBBFF7E1123E5_inline(L_8, NULL);
		if ((!(((uint32_t)L_9) == ((uint32_t)2))))
		{
			goto IL_00b1;
		}
	}
	{
		// Ttl = NetConstants.SocketTTL;
		NetSocket_set_Ttl_mBA8E187DB9240FD9DDE34664E679C9AFD1975117(__this, (int16_t)((int32_t)255), NULL);
	}
	try
	{// begin try (depth: 1)
		// try { socket.DontFragment = true; }
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_10 = ___socket0;
		NullCheck(L_10);
		Socket_set_DontFragment_mCF6F7D2735A7FD4E327617826C62ED015001DFF6(L_10, (bool)1, NULL);
		// try { socket.DontFragment = true; }
		goto IL_0086;
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&SocketException_t6D10102A62EA871BD31748E026A372DB6804083B_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0065;
		}
		throw e;
	}

CATCH_0065:
	{// begin catch(System.Net.Sockets.SocketException)
		// catch (SocketException e)
		V_0 = ((SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*)IL2CPP_GET_ACTIVE_EXCEPTION(SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*));
		// NetDebug.WriteError("[B]DontFragment error: {0}", e.SocketErrorCode);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_11 = (ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)(ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)SZArrayNew(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var)), (uint32_t)1);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_12 = L_11;
		SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_13 = V_0;
		NullCheck(L_13);
		int32_t L_14;
		L_14 = SocketException_get_SocketErrorCode_m84FB2D308F046A24A1355975F3BF689C988224C6(L_13, NULL);
		int32_t L_15 = L_14;
		RuntimeObject* L_16 = Box(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&SocketError_t4AD3BECF393E3FD8C5238C4AE47B768B3ABC07B8_il2cpp_TypeInfo_var)), &L_15);
		NullCheck(L_12);
		ArrayElementTypeCheck (L_12, L_16);
		(L_12)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject*)L_16);
		il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var)));
		NetDebug_WriteError_m950356DF95AA0DB66BD907F841C4C9BBDCFF25E3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralE246E702789502BB6581EC616DB67856E46BFF26)), L_12, NULL);
		// }
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_0086;
	}// end catch (depth: 1)

IL_0086:
	{
	}
	try
	{// begin try (depth: 1)
		// try { socket.EnableBroadcast = true; }
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_17 = ___socket0;
		NullCheck(L_17);
		Socket_set_EnableBroadcast_m8C25D9941F2D9BD40277F8D3395400993F4CF1CF(L_17, (bool)1, NULL);
		// try { socket.EnableBroadcast = true; }
		goto IL_00df;
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&SocketException_t6D10102A62EA871BD31748E026A372DB6804083B_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0090;
		}
		throw e;
	}

CATCH_0090:
	{// begin catch(System.Net.Sockets.SocketException)
		// catch (SocketException e)
		V_1 = ((SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*)IL2CPP_GET_ACTIVE_EXCEPTION(SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*));
		// NetDebug.WriteError("[B]Broadcast error: {0}", e.SocketErrorCode);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_18 = (ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)(ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)SZArrayNew(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var)), (uint32_t)1);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_19 = L_18;
		SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_20 = V_1;
		NullCheck(L_20);
		int32_t L_21;
		L_21 = SocketException_get_SocketErrorCode_m84FB2D308F046A24A1355975F3BF689C988224C6(L_20, NULL);
		int32_t L_22 = L_21;
		RuntimeObject* L_23 = Box(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&SocketError_t4AD3BECF393E3FD8C5238C4AE47B768B3ABC07B8_il2cpp_TypeInfo_var)), &L_22);
		NullCheck(L_19);
		ArrayElementTypeCheck (L_19, L_23);
		(L_19)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject*)L_23);
		il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var)));
		NetDebug_WriteError_m950356DF95AA0DB66BD907F841C4C9BBDCFF25E3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral19CFC720389256CE284BB852E13BDB48224B840F)), L_19, NULL);
		// }
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_00df;
	}// end catch (depth: 1)

IL_00b1:
	{
		// if (ipv6Mode == IPv6Mode.DualMode)
		int32_t L_24 = ___ipv6Mode3;
		if ((!(((uint32_t)L_24) == ((uint32_t)2))))
		{
			goto IL_00df;
		}
	}
	try
	{// begin try (depth: 1)
		// socket.SetSocketOption(SocketOptionLevel.IPv6, (SocketOptionName)27, false);
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_25 = ___socket0;
		NullCheck(L_25);
		Socket_SetSocketOption_mE47F5DEEA190E45317AEEE6F1506940CB8E943A1(L_25, ((int32_t)41), ((int32_t)27), (bool)0, NULL);
		// }
		goto IL_00df;
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_00c3;
		}
		throw e;
	}

CATCH_00c3:
	{// begin catch(System.Exception)
		// catch(Exception e)
		V_2 = ((Exception_t*)IL2CPP_GET_ACTIVE_EXCEPTION(Exception_t*));
		// NetDebug.WriteError("[B]Bind exception (dualmode setting): {0}", e.ToString());
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_26 = (ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)(ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)SZArrayNew(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var)), (uint32_t)1);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_27 = L_26;
		Exception_t* L_28 = V_2;
		NullCheck(L_28);
		String_t* L_29;
		L_29 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_28);
		NullCheck(L_27);
		ArrayElementTypeCheck (L_27, L_29);
		(L_27)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject*)L_29);
		il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var)));
		NetDebug_WriteError_m950356DF95AA0DB66BD907F841C4C9BBDCFF25E3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral12F50ECCACB6B631723240678DADBCDA9DE90533)), L_27, NULL);
		// }
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_00df;
	}// end catch (depth: 1)

IL_00df:
	{
	}
	try
	{// begin try (depth: 1)
		// socket.Bind(ep);
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_30 = ___socket0;
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_31 = ___ep1;
		NullCheck(L_30);
		Socket_Bind_m137559EBA78A72ED4ADF8B56F5C535CE638165AA(L_30, L_31, NULL);
		// if (socket.AddressFamily == AddressFamily.InterNetworkV6)
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_32 = ___socket0;
		NullCheck(L_32);
		int32_t L_33;
		L_33 = Socket_get_AddressFamily_m42C390D31345314080EC35356ACFBBFF7E1123E5_inline(L_32, NULL);
		// }
		goto IL_019a;
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&SocketException_t6D10102A62EA871BD31748E026A372DB6804083B_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_00f6;
		}
		throw e;
	}

CATCH_00f6:
	{// begin catch(System.Net.Sockets.SocketException)
		{
			// catch (SocketException bindException)
			V_3 = ((SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*)IL2CPP_GET_ACTIVE_EXCEPTION(SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*));
			// switch (bindException.SocketErrorCode)
			SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_34 = V_3;
			NullCheck(L_34);
			int32_t L_35;
			L_35 = SocketException_get_SocketErrorCode_m84FB2D308F046A24A1355975F3BF689C988224C6(L_34, NULL);
			V_4 = L_35;
			int32_t L_36 = V_4;
			if ((((int32_t)L_36) == ((int32_t)((int32_t)10047))))
			{
				goto IL_0169;
			}
		}
		{
			int32_t L_37 = V_4;
			if ((!(((uint32_t)L_37) == ((uint32_t)((int32_t)10048)))))
			{
				goto IL_016e;
			}
		}
		{
			// if (socket.AddressFamily == AddressFamily.InterNetworkV6 && ipv6Mode != IPv6Mode.DualMode)
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_38 = ___socket0;
			NullCheck(L_38);
			int32_t L_39;
			L_39 = Socket_get_AddressFamily_m42C390D31345314080EC35356ACFBBFF7E1123E5_inline(L_38, NULL);
			if ((!(((uint32_t)L_39) == ((uint32_t)((int32_t)23)))))
			{
				goto IL_016e;
			}
		}
		{
			int32_t L_40 = ___ipv6Mode3;
			if ((((int32_t)L_40) == ((int32_t)2)))
			{
				goto IL_016e;
			}
		}
		try
		{// begin try (depth: 2)
			// socket.SetSocketOption(SocketOptionLevel.IPv6, (SocketOptionName)27, true);
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_41 = ___socket0;
			NullCheck(L_41);
			Socket_SetSocketOption_mE47F5DEEA190E45317AEEE6F1506940CB8E943A1(L_41, ((int32_t)41), ((int32_t)27), (bool)1, NULL);
			// socket.Bind(ep);
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_42 = ___socket0;
			IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_43 = ___ep1;
			NullCheck(L_42);
			Socket_Bind_m137559EBA78A72ED4ADF8B56F5C535CE638165AA(L_42, L_43, NULL);
			// }
			goto IL_0164;
		}// end try (depth: 2)
		catch(Il2CppExceptionWrapper& e)
		{
			if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&SocketException_t6D10102A62EA871BD31748E026A372DB6804083B_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
			{
				IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
				goto CATCH_0134;
			}
			throw e;
		}

CATCH_0134:
		{// begin catch(System.Net.Sockets.SocketException)
			// catch (SocketException ex)
			V_5 = ((SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*)IL2CPP_GET_ACTIVE_EXCEPTION(SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*));
			// NetDebug.WriteError("[B]Bind exception: {0}, errorCode: {1}", ex.ToString(), ex.SocketErrorCode);
			ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_44 = (ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)(ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)SZArrayNew(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var)), (uint32_t)2);
			ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_45 = L_44;
			SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_46 = V_5;
			NullCheck(L_46);
			String_t* L_47;
			L_47 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_46);
			NullCheck(L_45);
			ArrayElementTypeCheck (L_45, L_47);
			(L_45)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject*)L_47);
			ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_48 = L_45;
			SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_49 = V_5;
			NullCheck(L_49);
			int32_t L_50;
			L_50 = SocketException_get_SocketErrorCode_m84FB2D308F046A24A1355975F3BF689C988224C6(L_49, NULL);
			int32_t L_51 = L_50;
			RuntimeObject* L_52 = Box(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&SocketError_t4AD3BECF393E3FD8C5238C4AE47B768B3ABC07B8_il2cpp_TypeInfo_var)), &L_51);
			NullCheck(L_48);
			ArrayElementTypeCheck (L_48, L_52);
			(L_48)->SetAt(static_cast<il2cpp_array_size_t>(1), (RuntimeObject*)L_52);
			il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var)));
			NetDebug_WriteError_m950356DF95AA0DB66BD907F841C4C9BBDCFF25E3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral017221BEF045A541084C808DB03B1A82115AE841)), L_48, NULL);
			// return false;
			V_6 = (bool)0;
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_019c;
		}// end catch (depth: 2)

IL_0164:
		{
			// return true;
			V_6 = (bool)1;
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_019c;
		}

IL_0169:
		{
			// return true;
			V_6 = (bool)1;
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_019c;
		}

IL_016e:
		{
			// NetDebug.WriteError("[B]Bind exception: {0}, errorCode: {1}", bindException.ToString(), bindException.SocketErrorCode);
			ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_53 = (ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)(ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)SZArrayNew(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var)), (uint32_t)2);
			ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_54 = L_53;
			SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_55 = V_3;
			NullCheck(L_55);
			String_t* L_56;
			L_56 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_55);
			NullCheck(L_54);
			ArrayElementTypeCheck (L_54, L_56);
			(L_54)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject*)L_56);
			ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_57 = L_54;
			SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_58 = V_3;
			NullCheck(L_58);
			int32_t L_59;
			L_59 = SocketException_get_SocketErrorCode_m84FB2D308F046A24A1355975F3BF689C988224C6(L_58, NULL);
			int32_t L_60 = L_59;
			RuntimeObject* L_61 = Box(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&SocketError_t4AD3BECF393E3FD8C5238C4AE47B768B3ABC07B8_il2cpp_TypeInfo_var)), &L_60);
			NullCheck(L_57);
			ArrayElementTypeCheck (L_57, L_61);
			(L_57)->SetAt(static_cast<il2cpp_array_size_t>(1), (RuntimeObject*)L_61);
			il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var)));
			NetDebug_WriteError_m950356DF95AA0DB66BD907F841C4C9BBDCFF25E3(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral017221BEF045A541084C808DB03B1A82115AE841)), L_57, NULL);
			// return false;
			V_6 = (bool)0;
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_019c;
		}
	}// end catch (depth: 1)

IL_019a:
	{
		// return true;
		return (bool)1;
	}

IL_019c:
	{
		// }
		bool L_62 = V_6;
		return L_62;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.NetSocket::SendBroadcast(System.Byte[],System.Int32,System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetSocket_SendBroadcast_m86214E1A1235F7CF27C30C2D0DB71038E58D132D (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___data0, int32_t ___offset1, int32_t ___size2, int32_t ___port3, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	Exception_t* V_2 = NULL;
	bool V_3 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	Exception_t* G_B8_0 = NULL;
	String_t* G_B8_1 = NULL;
	Exception_t* G_B7_0 = NULL;
	String_t* G_B7_1 = NULL;
	String_t* G_B9_0 = NULL;
	String_t* G_B9_1 = NULL;
	{
		// if (!IsActive())
		bool L_0;
		L_0 = NetSocket_IsActive_m898D8B9D8568756AFCEF631AD2EAA82B813BA65F(__this, NULL);
		if (L_0)
		{
			goto IL_000a;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_000a:
	{
		// bool broadcastSuccess = false;
		V_0 = (bool)0;
		// bool multicastSuccess = false;
		V_1 = (bool)0;
	}
	try
	{// begin try (depth: 1)
		{
			// broadcastSuccess = _udpSocketv4.SendTo(
			//              data,
			//              offset,
			//              size,
			//              SocketFlags.None,
			//              new IPEndPoint(IPAddress.Broadcast, port)) > 0;
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_1 = __this->____udpSocketv4_1;
			ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___data0;
			int32_t L_3 = ___offset1;
			int32_t L_4 = ___size2;
			il2cpp_codegen_runtime_class_init_inline(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
			IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_5 = ((IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_StaticFields*)il2cpp_codegen_static_fields_for(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var))->___Broadcast_2;
			int32_t L_6 = ___port3;
			IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_7 = (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)il2cpp_codegen_object_new(IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
			NullCheck(L_7);
			IPEndPoint__ctor_m902C98F9E3F36B20B3C2E030AA91B62E2BC7A85A(L_7, L_5, L_6, NULL);
			NullCheck(L_1);
			int32_t L_8;
			L_8 = Socket_SendTo_m07A6D82F7ABD61B6B9C87931035FCF793AA3D6F6(L_1, L_2, L_3, L_4, 0, L_7, NULL);
			V_0 = (bool)((((int32_t)L_8) > ((int32_t)0))? 1 : 0);
			// if (_udpSocketv6 != null)
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_9 = __this->____udpSocketv6_2;
			if (!L_9)
			{
				goto IL_0054_1;
			}
		}
		{
			// multicastSuccess = _udpSocketv6.SendTo(
			//                             data,
			//                             offset,
			//                             size,
			//                             SocketFlags.None,
			//                             new IPEndPoint(MulticastAddressV6, port)) > 0;
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_10 = __this->____udpSocketv6_2;
			ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = ___data0;
			int32_t L_12 = ___offset1;
			int32_t L_13 = ___size2;
			il2cpp_codegen_runtime_class_init_inline(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var);
			IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_14 = ((NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_StaticFields*)il2cpp_codegen_static_fields_for(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var))->___MulticastAddressV6_9;
			int32_t L_15 = ___port3;
			IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_16 = (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)il2cpp_codegen_object_new(IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
			NullCheck(L_16);
			IPEndPoint__ctor_m902C98F9E3F36B20B3C2E030AA91B62E2BC7A85A(L_16, L_14, L_15, NULL);
			NullCheck(L_10);
			int32_t L_17;
			L_17 = Socket_SendTo_m07A6D82F7ABD61B6B9C87931035FCF793AA3D6F6(L_10, L_11, L_12, L_13, 0, L_16, NULL);
			V_1 = (bool)((((int32_t)L_17) > ((int32_t)0))? 1 : 0);
		}

IL_0054_1:
		{
			// }
			goto IL_007c;
		}
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0056;
		}
		throw e;
	}

CATCH_0056:
	{// begin catch(System.Exception)
		{
			// catch (Exception ex)
			V_2 = ((Exception_t*)IL2CPP_GET_ACTIVE_EXCEPTION(Exception_t*));
			// NetDebug.WriteError("[S][MCAST]" + ex);
			Exception_t* L_18 = V_2;
			Exception_t* L_19 = L_18;
			G_B7_0 = L_19;
			G_B7_1 = ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral9C6758427B6A2155E30FAC90008DE4117AAEB0DA));
			if (L_19)
			{
				G_B8_0 = L_19;
				G_B8_1 = ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral9C6758427B6A2155E30FAC90008DE4117AAEB0DA));
				goto IL_0064;
			}
		}
		{
			G_B9_0 = ((String_t*)(NULL));
			G_B9_1 = G_B7_1;
			goto IL_0069;
		}

IL_0064:
		{
			NullCheck(G_B8_0);
			String_t* L_20;
			L_20 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, G_B8_0);
			G_B9_0 = L_20;
			G_B9_1 = G_B8_1;
		}

IL_0069:
		{
			String_t* L_21;
			L_21 = String_Concat_mAF2CE02CC0CB7460753D0A1A91CCF2B1E9804C5D(G_B9_1, G_B9_0, NULL);
			ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_22;
			L_22 = Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_inline(((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_RuntimeMethod_var)));
			il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var)));
			NetDebug_WriteError_m950356DF95AA0DB66BD907F841C4C9BBDCFF25E3(L_21, L_22, NULL);
			// return broadcastSuccess;
			bool L_23 = V_0;
			V_3 = L_23;
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_0080;
		}
	}// end catch (depth: 1)

IL_007c:
	{
		// return broadcastSuccess || multicastSuccess;
		bool L_24 = V_0;
		bool L_25 = V_1;
		return (bool)((int32_t)((int32_t)L_24|(int32_t)L_25));
	}

IL_0080:
	{
		// }
		bool L_26 = V_3;
		return L_26;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.NetSocket::SendTo(System.Byte[],System.Int32,System.Int32,System.Net.IPEndPoint,System.Net.Sockets.SocketError&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetSocket_SendTo_mEBB7CBE898383F3C5E94F453005B7F3A68C1D469 (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___data0, int32_t ___offset1, int32_t ___size2, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___remoteEndPoint3, int32_t* ___errorCode4, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* V_0 = NULL;
	int32_t V_1 = 0;
	SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* V_2 = NULL;
	int32_t V_3 = 0;
	Exception_t* V_4 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* G_B13_0 = NULL;
	String_t* G_B13_1 = NULL;
	SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* G_B12_0 = NULL;
	String_t* G_B12_1 = NULL;
	String_t* G_B14_0 = NULL;
	String_t* G_B14_1 = NULL;
	Exception_t* G_B18_0 = NULL;
	String_t* G_B18_1 = NULL;
	Exception_t* G_B17_0 = NULL;
	String_t* G_B17_1 = NULL;
	String_t* G_B19_0 = NULL;
	String_t* G_B19_1 = NULL;
	{
		// if (!IsActive())
		bool L_0;
		L_0 = NetSocket_IsActive_m898D8B9D8568756AFCEF631AD2EAA82B813BA65F(__this, NULL);
		if (L_0)
		{
			goto IL_000a;
		}
	}
	{
		// return 0;
		return 0;
	}

IL_000a:
	{
	}
	try
	{// begin try (depth: 1)
		{
			// var socket = _udpSocketv4;
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_1 = __this->____udpSocketv4_1;
			V_0 = L_1;
			// if (remoteEndPoint.AddressFamily == AddressFamily.InterNetworkV6 && IPv6Support)
			IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_2 = ___remoteEndPoint3;
			NullCheck(L_2);
			int32_t L_3;
			L_3 = VirtualFuncInvoker0< int32_t >::Invoke(4 /* System.Net.Sockets.AddressFamily System.Net.EndPoint::get_AddressFamily() */, L_2);
			if ((!(((uint32_t)L_3) == ((uint32_t)((int32_t)23)))))
			{
				goto IL_002b_1;
			}
		}
		{
			il2cpp_codegen_runtime_class_init_inline(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var);
			bool L_4 = ((NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_StaticFields*)il2cpp_codegen_static_fields_for(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var))->___IPv6Support_10;
			if (!L_4)
			{
				goto IL_002b_1;
			}
		}
		{
			// socket = _udpSocketv6;
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_5 = __this->____udpSocketv6_2;
			V_0 = L_5;
		}

IL_002b_1:
		{
			// int result = socket.SendTo(data, offset, size, SocketFlags.None, remoteEndPoint);
			Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_6 = V_0;
			ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = ___data0;
			int32_t L_8 = ___offset1;
			int32_t L_9 = ___size2;
			IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_10 = ___remoteEndPoint3;
			NullCheck(L_6);
			int32_t L_11;
			L_11 = Socket_SendTo_m07A6D82F7ABD61B6B9C87931035FCF793AA3D6F6(L_6, L_7, L_8, L_9, 0, L_10, NULL);
			// return result;
			V_1 = L_11;
			goto IL_00b4;
		}
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&SocketException_t6D10102A62EA871BD31748E026A372DB6804083B_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_003a;
		}
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_008c;
		}
		throw e;
	}

CATCH_003a:
	{// begin catch(System.Net.Sockets.SocketException)
		{
			// catch (SocketException ex)
			V_2 = ((SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*)IL2CPP_GET_ACTIVE_EXCEPTION(SocketException_t6D10102A62EA871BD31748E026A372DB6804083B*));
			// switch (ex.SocketErrorCode)
			SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_12 = V_2;
			NullCheck(L_12);
			int32_t L_13;
			L_13 = SocketException_get_SocketErrorCode_m84FB2D308F046A24A1355975F3BF689C988224C6(L_12, NULL);
			V_3 = L_13;
			int32_t L_14 = V_3;
			if ((((int32_t)L_14) == ((int32_t)((int32_t)10004))))
			{
				goto IL_005a;
			}
		}
		{
			int32_t L_15 = V_3;
			if ((((int32_t)L_15) == ((int32_t)((int32_t)10040))))
			{
				goto IL_007f;
			}
		}
		{
			int32_t L_16 = V_3;
			if ((!(((uint32_t)L_16) == ((uint32_t)((int32_t)10055)))))
			{
				goto IL_005e;
			}
		}

IL_005a:
		{
			// return 0;
			V_1 = 0;
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_00b4;
		}

IL_005e:
		{
			// NetDebug.WriteError("[S]" + ex);
			SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_17 = V_2;
			SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_18 = L_17;
			G_B12_0 = L_18;
			G_B12_1 = ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralF9B144615946F6A86FEB5C383BF883FFC8AC62F8));
			if (L_18)
			{
				G_B13_0 = L_18;
				G_B13_1 = ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralF9B144615946F6A86FEB5C383BF883FFC8AC62F8));
				goto IL_006b;
			}
		}
		{
			G_B14_0 = ((String_t*)(NULL));
			G_B14_1 = G_B12_1;
			goto IL_0070;
		}

IL_006b:
		{
			NullCheck(G_B13_0);
			String_t* L_19;
			L_19 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, G_B13_0);
			G_B14_0 = L_19;
			G_B14_1 = G_B13_1;
		}

IL_0070:
		{
			String_t* L_20;
			L_20 = String_Concat_mAF2CE02CC0CB7460753D0A1A91CCF2B1E9804C5D(G_B14_1, G_B14_0, NULL);
			ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_21;
			L_21 = Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_inline(((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_RuntimeMethod_var)));
			il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var)));
			NetDebug_WriteError_m950356DF95AA0DB66BD907F841C4C9BBDCFF25E3(L_20, L_21, NULL);
		}

IL_007f:
		{
			// errorCode = ex.SocketErrorCode;
			int32_t* L_22 = ___errorCode4;
			SocketException_t6D10102A62EA871BD31748E026A372DB6804083B* L_23 = V_2;
			NullCheck(L_23);
			int32_t L_24;
			L_24 = SocketException_get_SocketErrorCode_m84FB2D308F046A24A1355975F3BF689C988224C6(L_23, NULL);
			*((int32_t*)L_22) = (int32_t)L_24;
			// return -1;
			V_1 = (-1);
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_00b4;
		}
	}// end catch (depth: 1)

CATCH_008c:
	{// begin catch(System.Exception)
		{
			// catch (Exception ex)
			V_4 = ((Exception_t*)IL2CPP_GET_ACTIVE_EXCEPTION(Exception_t*));
			// NetDebug.WriteError("[S]" + ex);
			Exception_t* L_25 = V_4;
			Exception_t* L_26 = L_25;
			G_B17_0 = L_26;
			G_B17_1 = ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralF9B144615946F6A86FEB5C383BF883FFC8AC62F8));
			if (L_26)
			{
				G_B18_0 = L_26;
				G_B18_1 = ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralF9B144615946F6A86FEB5C383BF883FFC8AC62F8));
				goto IL_009c;
			}
		}
		{
			G_B19_0 = ((String_t*)(NULL));
			G_B19_1 = G_B17_1;
			goto IL_00a1;
		}

IL_009c:
		{
			NullCheck(G_B18_0);
			String_t* L_27;
			L_27 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, G_B18_0);
			G_B19_0 = L_27;
			G_B19_1 = G_B18_1;
		}

IL_00a1:
		{
			String_t* L_28;
			L_28 = String_Concat_mAF2CE02CC0CB7460753D0A1A91CCF2B1E9804C5D(G_B19_1, G_B19_0, NULL);
			ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_29;
			L_29 = Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_inline(((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_RuntimeMethod_var)));
			il2cpp_codegen_runtime_class_init_inline(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var)));
			NetDebug_WriteError_m950356DF95AA0DB66BD907F841C4C9BBDCFF25E3(L_28, L_29, NULL);
			// return -1;
			V_1 = (-1);
			IL2CPP_POP_ACTIVE_EXCEPTION();
			goto IL_00b4;
		}
	}// end catch (depth: 1)

IL_00b4:
	{
		// }
		int32_t L_30 = V_1;
		return L_30;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetSocket::Close(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSocket_Close_m461EC8DFFE48BBA3F18C6D495B1FB92C316D478A (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, bool ___suspend0, const RuntimeMethod* method) 
{
	{
		// if (!suspend)
		bool L_0 = ___suspend0;
		if (L_0)
		{
			goto IL_000c;
		}
	}
	{
		// IsRunning = false;
		il2cpp_codegen_memory_barrier();
		__this->___IsRunning_12 = (bool)0;
	}

IL_000c:
	{
		// if (_udpSocketv4 == _udpSocketv6)
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_1 = __this->____udpSocketv4_1;
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_2 = __this->____udpSocketv6_2;
		if ((!(((RuntimeObject*)(Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)L_1) == ((RuntimeObject*)(Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)L_2))))
		{
			goto IL_0021;
		}
	}
	{
		// _udpSocketv6 = null;
		__this->____udpSocketv6_2 = (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____udpSocketv6_2), (void*)(Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)NULL);
	}

IL_0021:
	{
		// if (_udpSocketv4 != null)
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_3 = __this->____udpSocketv4_1;
		if (!L_3)
		{
			goto IL_0034;
		}
	}
	{
		// _udpSocketv4.Close();
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_4 = __this->____udpSocketv4_1;
		NullCheck(L_4);
		Socket_Close_m5EBF3D8BE2C42EF8037BC9372CE7760B1717EEE4(L_4, NULL);
	}

IL_0034:
	{
		// if (_udpSocketv6 != null)
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_5 = __this->____udpSocketv6_2;
		if (!L_5)
		{
			goto IL_0047;
		}
	}
	{
		// _udpSocketv6.Close();
		Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* L_6 = __this->____udpSocketv6_2;
		NullCheck(L_6);
		Socket_Close_m5EBF3D8BE2C42EF8037BC9372CE7760B1717EEE4(L_6, NULL);
	}

IL_0047:
	{
		// _udpSocketv4 = null;
		__this->____udpSocketv4_1 = (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____udpSocketv4_1), (void*)(Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)NULL);
		// _udpSocketv6 = null;
		__this->____udpSocketv6_2 = (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____udpSocketv6_2), (void*)(Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E*)NULL);
		// if (_threadv4 != null && _threadv4 != Thread.CurrentThread)
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_7 = __this->____threadv4_3;
		if (!L_7)
		{
			goto IL_0075;
		}
	}
	{
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_8 = __this->____threadv4_3;
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_9;
		L_9 = Thread_get_CurrentThread_m835AD1DF1C0D10BABE1A5427CC4B357C991B25AB(NULL);
		if ((((RuntimeObject*)(Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F*)L_8) == ((RuntimeObject*)(Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F*)L_9)))
		{
			goto IL_0075;
		}
	}
	{
		// _threadv4.Join();
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_10 = __this->____threadv4_3;
		NullCheck(L_10);
		Thread_Join_mB756581AAF5EB028081256E0517892BC8867779F(L_10, NULL);
	}

IL_0075:
	{
		// if (_threadv6 != null && _threadv6 != Thread.CurrentThread)
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_11 = __this->____threadv6_4;
		if (!L_11)
		{
			goto IL_0095;
		}
	}
	{
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_12 = __this->____threadv6_4;
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_13;
		L_13 = Thread_get_CurrentThread_m835AD1DF1C0D10BABE1A5427CC4B357C991B25AB(NULL);
		if ((((RuntimeObject*)(Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F*)L_12) == ((RuntimeObject*)(Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F*)L_13)))
		{
			goto IL_0095;
		}
	}
	{
		// _threadv6.Join();
		Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F* L_14 = __this->____threadv6_4;
		NullCheck(L_14);
		Thread_Join_mB756581AAF5EB028081256E0517892BC8867779F(L_14, NULL);
	}

IL_0095:
	{
		// _threadv4 = null;
		__this->____threadv4_3 = (Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____threadv4_3), (void*)(Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F*)NULL);
		// _threadv6 = null;
		__this->____threadv6_4 = (Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____threadv6_4), (void*)(Thread_t0A773B9DE873D2DCAA7D229EAB36757B500E207F*)NULL);
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_PacketsSent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_PacketsSent_mA577EC1A59E042EE9EAFC04C4E2CC88466524477 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	{
		// get { return Interlocked.Read(ref _packetsSent); }
		int64_t* L_0 = (&__this->____packetsSent_0);
		int64_t L_1;
		L_1 = Interlocked_Read_m646D69AAE03D57B78525D89642A5F951BA21CD28(L_0, NULL);
		return L_1;
	}
}
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_PacketsReceived()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_PacketsReceived_m0D9F0A427B092313E684596E5AF41ED2D2AACB43 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	{
		// get { return Interlocked.Read(ref _packetsReceived); }
		int64_t* L_0 = (&__this->____packetsReceived_1);
		int64_t L_1;
		L_1 = Interlocked_Read_m646D69AAE03D57B78525D89642A5F951BA21CD28(L_0, NULL);
		return L_1;
	}
}
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_BytesSent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_BytesSent_mE84550EBF4569895FB32065400D2CA913BA2A3AF (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	{
		// get { return Interlocked.Read(ref _bytesSent); }
		int64_t* L_0 = (&__this->____bytesSent_2);
		int64_t L_1;
		L_1 = Interlocked_Read_m646D69AAE03D57B78525D89642A5F951BA21CD28(L_0, NULL);
		return L_1;
	}
}
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_BytesReceived()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_BytesReceived_m72AADEF43817A82E30A24817B6D099EA1245C5BD (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	{
		// get { return Interlocked.Read(ref _bytesReceived); }
		int64_t* L_0 = (&__this->____bytesReceived_3);
		int64_t L_1;
		L_1 = Interlocked_Read_m646D69AAE03D57B78525D89642A5F951BA21CD28(L_0, NULL);
		return L_1;
	}
}
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_PacketLoss()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_PacketLoss_m162D4310CEE65B5C9A3E9FC84DD123A0CE172C03 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	{
		// get { return Interlocked.Read(ref _packetLoss); }
		int64_t* L_0 = (&__this->____packetLoss_4);
		int64_t L_1;
		L_1 = Interlocked_Read_m646D69AAE03D57B78525D89642A5F951BA21CD28(L_0, NULL);
		return L_1;
	}
}
// System.Int64 FlyingWormConsole3.LiteNetLib.NetStatistics::get_PacketLossPercent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetStatistics_get_PacketLossPercent_mBF57554E91B93658BA228F681EAC813F85319A88 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	int64_t V_0 = 0;
	int64_t V_1 = 0;
	{
		// long sent = PacketsSent, loss = PacketLoss;
		int64_t L_0;
		L_0 = NetStatistics_get_PacketsSent_mA577EC1A59E042EE9EAFC04C4E2CC88466524477(__this, NULL);
		V_0 = L_0;
		// long sent = PacketsSent, loss = PacketLoss;
		int64_t L_1;
		L_1 = NetStatistics_get_PacketLoss_m162D4310CEE65B5C9A3E9FC84DD123A0CE172C03(__this, NULL);
		V_1 = L_1;
		// return sent == 0 ? 0 : loss * 100 / sent;
		int64_t L_2 = V_0;
		if (!L_2)
		{
			goto IL_0019;
		}
	}
	{
		int64_t L_3 = V_1;
		int64_t L_4 = V_0;
		return ((int64_t)(((int64_t)il2cpp_codegen_multiply(L_3, ((int64_t)((int32_t)100))))/L_4));
	}

IL_0019:
	{
		return ((int64_t)0);
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetStatistics::Reset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetStatistics_Reset_m60C269FA19CD6075CAF26EDEE7CC69E56E34D12D (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	{
		// Interlocked.Exchange(ref _packetsSent, 0);
		int64_t* L_0 = (&__this->____packetsSent_0);
		int64_t L_1;
		L_1 = Interlocked_Exchange_mBBDC634C2A0C3F3226B1CA1F0773DDEAA8B2A227(L_0, ((int64_t)0), NULL);
		// Interlocked.Exchange(ref _packetsReceived, 0);
		int64_t* L_2 = (&__this->____packetsReceived_1);
		int64_t L_3;
		L_3 = Interlocked_Exchange_mBBDC634C2A0C3F3226B1CA1F0773DDEAA8B2A227(L_2, ((int64_t)0), NULL);
		// Interlocked.Exchange(ref _bytesSent, 0);
		int64_t* L_4 = (&__this->____bytesSent_2);
		int64_t L_5;
		L_5 = Interlocked_Exchange_mBBDC634C2A0C3F3226B1CA1F0773DDEAA8B2A227(L_4, ((int64_t)0), NULL);
		// Interlocked.Exchange(ref _bytesReceived, 0);
		int64_t* L_6 = (&__this->____bytesReceived_3);
		int64_t L_7;
		L_7 = Interlocked_Exchange_mBBDC634C2A0C3F3226B1CA1F0773DDEAA8B2A227(L_6, ((int64_t)0), NULL);
		// Interlocked.Exchange(ref _packetLoss, 0);
		int64_t* L_8 = (&__this->____packetLoss_4);
		int64_t L_9;
		L_9 = Interlocked_Exchange_mBBDC634C2A0C3F3226B1CA1F0773DDEAA8B2A227(L_8, ((int64_t)0), NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetStatistics::IncrementPacketsSent()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetStatistics_IncrementPacketsSent_m94C65788C350024E73FF7238C83C2146AD5FC12A (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	{
		// Interlocked.Increment(ref _packetsSent);
		int64_t* L_0 = (&__this->____packetsSent_0);
		int64_t L_1;
		L_1 = Interlocked_Increment_m92616415B56E5497A3D07233BB7C2D263AB3D5A0(L_0, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetStatistics::IncrementPacketsReceived()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetStatistics_IncrementPacketsReceived_m8DD29C0DE6568117D550ADAD4C371F2ABD4C778A (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	{
		// Interlocked.Increment(ref _packetsReceived);
		int64_t* L_0 = (&__this->____packetsReceived_1);
		int64_t L_1;
		L_1 = Interlocked_Increment_m92616415B56E5497A3D07233BB7C2D263AB3D5A0(L_0, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetStatistics::AddBytesSent(System.Int64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetStatistics_AddBytesSent_m029087FDE6D5FA8E8E1BE442BDE6FF2276972922 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, int64_t ___bytesSent0, const RuntimeMethod* method) 
{
	{
		// Interlocked.Add(ref _bytesSent, bytesSent);
		int64_t* L_0 = (&__this->____bytesSent_2);
		int64_t L_1 = ___bytesSent0;
		int64_t L_2;
		L_2 = Interlocked_Add_mBF0FD78E930DEDDA2EEB0E9884FA2D8198D0EEC8(L_0, L_1, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetStatistics::AddBytesReceived(System.Int64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetStatistics_AddBytesReceived_mCA6B8D1DB7AC8AAF436B6AEF9274E6473D59E1C9 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, int64_t ___bytesReceived0, const RuntimeMethod* method) 
{
	{
		// Interlocked.Add(ref _bytesReceived, bytesReceived);
		int64_t* L_0 = (&__this->____bytesReceived_3);
		int64_t L_1 = ___bytesReceived0;
		int64_t L_2;
		L_2 = Interlocked_Add_mBF0FD78E930DEDDA2EEB0E9884FA2D8198D0EEC8(L_0, L_1, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetStatistics::IncrementPacketLoss()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetStatistics_IncrementPacketLoss_m6AF8CA81D7D3064EB05121D8D499BCF5C72763BC (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	{
		// Interlocked.Increment(ref _packetLoss);
		int64_t* L_0 = (&__this->____packetLoss_4);
		int64_t L_1;
		L_1 = Interlocked_Increment_m92616415B56E5497A3D07233BB7C2D263AB3D5A0(L_0, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetStatistics::AddPacketLoss(System.Int64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetStatistics_AddPacketLoss_mAA70198C7E49704F5821DE577543473AD6327039 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, int64_t ___packetLoss0, const RuntimeMethod* method) 
{
	{
		// Interlocked.Add(ref _packetLoss, packetLoss);
		int64_t* L_0 = (&__this->____packetLoss_4);
		int64_t L_1 = ___packetLoss0;
		int64_t L_2;
		L_2 = Interlocked_Add_mBF0FD78E930DEDDA2EEB0E9884FA2D8198D0EEC8(L_0, L_1, NULL);
		// }
		return;
	}
}
// System.String FlyingWormConsole3.LiteNetLib.NetStatistics::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NetStatistics_ToString_m3D9FDAD5F66070CB85B248558F7FF3950D45A887 (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral1DA333AC28D289B0B3DAAF2AF1E2CD4188F6ACF2);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return
		//     string.Format(
		//         "BytesReceived: {0}\nPacketsReceived: {1}\nBytesSent: {2}\nPacketsSent: {3}\nPacketLoss: {4}\nPacketLossPercent: {5}\n",
		//         BytesReceived,
		//         PacketsReceived,
		//         BytesSent,
		//         PacketsSent,
		//         PacketLoss,
		//         PacketLossPercent);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_0 = (ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)(ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)SZArrayNew(ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918_il2cpp_TypeInfo_var, (uint32_t)6);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_1 = L_0;
		int64_t L_2;
		L_2 = NetStatistics_get_BytesReceived_m72AADEF43817A82E30A24817B6D099EA1245C5BD(__this, NULL);
		int64_t L_3 = L_2;
		RuntimeObject* L_4 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_3);
		NullCheck(L_1);
		ArrayElementTypeCheck (L_1, L_4);
		(L_1)->SetAt(static_cast<il2cpp_array_size_t>(0), (RuntimeObject*)L_4);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_5 = L_1;
		int64_t L_6;
		L_6 = NetStatistics_get_PacketsReceived_m0D9F0A427B092313E684596E5AF41ED2D2AACB43(__this, NULL);
		int64_t L_7 = L_6;
		RuntimeObject* L_8 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_7);
		NullCheck(L_5);
		ArrayElementTypeCheck (L_5, L_8);
		(L_5)->SetAt(static_cast<il2cpp_array_size_t>(1), (RuntimeObject*)L_8);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_9 = L_5;
		int64_t L_10;
		L_10 = NetStatistics_get_BytesSent_mE84550EBF4569895FB32065400D2CA913BA2A3AF(__this, NULL);
		int64_t L_11 = L_10;
		RuntimeObject* L_12 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_11);
		NullCheck(L_9);
		ArrayElementTypeCheck (L_9, L_12);
		(L_9)->SetAt(static_cast<il2cpp_array_size_t>(2), (RuntimeObject*)L_12);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_13 = L_9;
		int64_t L_14;
		L_14 = NetStatistics_get_PacketsSent_mA577EC1A59E042EE9EAFC04C4E2CC88466524477(__this, NULL);
		int64_t L_15 = L_14;
		RuntimeObject* L_16 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_15);
		NullCheck(L_13);
		ArrayElementTypeCheck (L_13, L_16);
		(L_13)->SetAt(static_cast<il2cpp_array_size_t>(3), (RuntimeObject*)L_16);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_17 = L_13;
		int64_t L_18;
		L_18 = NetStatistics_get_PacketLoss_m162D4310CEE65B5C9A3E9FC84DD123A0CE172C03(__this, NULL);
		int64_t L_19 = L_18;
		RuntimeObject* L_20 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_19);
		NullCheck(L_17);
		ArrayElementTypeCheck (L_17, L_20);
		(L_17)->SetAt(static_cast<il2cpp_array_size_t>(4), (RuntimeObject*)L_20);
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_21 = L_17;
		int64_t L_22;
		L_22 = NetStatistics_get_PacketLossPercent_mBF57554E91B93658BA228F681EAC813F85319A88(__this, NULL);
		int64_t L_23 = L_22;
		RuntimeObject* L_24 = Box(Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_il2cpp_TypeInfo_var, &L_23);
		NullCheck(L_21);
		ArrayElementTypeCheck (L_21, L_24);
		(L_21)->SetAt(static_cast<il2cpp_array_size_t>(5), (RuntimeObject*)L_24);
		String_t* L_25;
		L_25 = String_Format_m74FC0A1259DFA02F3DF6538FC7F3ACF3E1AF0C55(_stringLiteral1DA333AC28D289B0B3DAAF2AF1E2CD4188F6ACF2, L_21, NULL);
		return L_25;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetStatistics::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetStatistics__ctor_mFD9D2985B571A492CAB4D6CB78192E5D4E66B1AB (NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Net.IPEndPoint FlyingWormConsole3.LiteNetLib.NetUtils::MakeEndPoint(System.String,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* NetUtils_MakeEndPoint_mF3EC8D450B5146C27AEF82F7962734F09ACBB1A1 (String_t* ___hostStr0, int32_t ___port1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return new IPEndPoint(ResolveAddress(hostStr), port);
		String_t* L_0 = ___hostStr0;
		il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_1;
		L_1 = NetUtils_ResolveAddress_mAAAD87D508A5A6ABBEECA1A855A71EA4EC446BB4(L_0, NULL);
		int32_t L_2 = ___port1;
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_3 = (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB*)il2cpp_codegen_object_new(IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB_il2cpp_TypeInfo_var);
		NullCheck(L_3);
		IPEndPoint__ctor_m902C98F9E3F36B20B3C2E030AA91B62E2BC7A85A(L_3, L_1, L_2, NULL);
		return L_3;
	}
}
// System.Net.IPAddress FlyingWormConsole3.LiteNetLib.NetUtils::ResolveAddress(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* NetUtils_ResolveAddress_mAAAD87D508A5A6ABBEECA1A855A71EA4EC446BB4 (String_t* ___hostStr0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral5FC154761871B7293BA5D77E57A16A71359FE4E5);
		s_Il2CppMethodInitialized = true;
	}
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* V_0 = NULL;
	{
		// if(hostStr == "localhost")
		String_t* L_0 = ___hostStr0;
		bool L_1;
		L_1 = String_op_Equality_m0D685A924E5CD78078F248ED1726DA5A9D7D6AC0(L_0, _stringLiteral5FC154761871B7293BA5D77E57A16A71359FE4E5, NULL);
		if (!L_1)
		{
			goto IL_0013;
		}
	}
	{
		// return IPAddress.Loopback;
		il2cpp_codegen_runtime_class_init_inline(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_2 = ((IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_StaticFields*)il2cpp_codegen_static_fields_for(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var))->___Loopback_1;
		return L_2;
	}

IL_0013:
	{
		// if (!IPAddress.TryParse(hostStr, out ipAddress))
		String_t* L_3 = ___hostStr0;
		il2cpp_codegen_runtime_class_init_inline(IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484_il2cpp_TypeInfo_var);
		bool L_4;
		L_4 = IPAddress_TryParse_mB8DC9EE090ED3BE8F8C9D419759AA9FF4A498D3B(L_3, (&V_0), NULL);
		if (L_4)
		{
			goto IL_0038;
		}
	}
	{
		// if (NetSocket.IPv6Support)
		il2cpp_codegen_runtime_class_init_inline(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var);
		bool L_5 = ((NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_StaticFields*)il2cpp_codegen_static_fields_for(NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4_il2cpp_TypeInfo_var))->___IPv6Support_10;
		if (!L_5)
		{
			goto IL_002d;
		}
	}
	{
		// ipAddress = ResolveAddress(hostStr, AddressFamily.InterNetworkV6);
		String_t* L_6 = ___hostStr0;
		il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_7;
		L_7 = NetUtils_ResolveAddress_mEB46B825C1F872874194C85D34A0846A614DB5BF(L_6, ((int32_t)23), NULL);
		V_0 = L_7;
	}

IL_002d:
	{
		// if (ipAddress == null)
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_8 = V_0;
		if (L_8)
		{
			goto IL_0038;
		}
	}
	{
		// ipAddress = ResolveAddress(hostStr, AddressFamily.InterNetwork);
		String_t* L_9 = ___hostStr0;
		il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_10;
		L_10 = NetUtils_ResolveAddress_mEB46B825C1F872874194C85D34A0846A614DB5BF(L_9, 2, NULL);
		V_0 = L_10;
	}

IL_0038:
	{
		// if (ipAddress == null)
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_11 = V_0;
		if (L_11)
		{
			goto IL_004c;
		}
	}
	{
		// throw new ArgumentException("Invalid address: " + hostStr);
		String_t* L_12 = ___hostStr0;
		String_t* L_13;
		L_13 = String_Concat_mAF2CE02CC0CB7460753D0A1A91CCF2B1E9804C5D(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralCDCAEAC0EC16DAB2B94EB8085B3301CCA8654423)), L_12, NULL);
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_14 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_14);
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(L_14, L_13, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_14, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NetUtils_ResolveAddress_mAAAD87D508A5A6ABBEECA1A855A71EA4EC446BB4_RuntimeMethod_var)));
	}

IL_004c:
	{
		// return ipAddress;
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_15 = V_0;
		return L_15;
	}
}
// System.Net.IPAddress FlyingWormConsole3.LiteNetLib.NetUtils::ResolveAddress(System.String,System.Net.Sockets.AddressFamily)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* NetUtils_ResolveAddress_mEB46B825C1F872874194C85D34A0846A614DB5BF (String_t* ___hostStr0, int32_t ___addressFamily1, const RuntimeMethod* method) 
{
	IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* V_0 = NULL;
	int32_t V_1 = 0;
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* V_2 = NULL;
	{
		// IPAddress[] addresses = Dns.GetHostEntry(hostStr).AddressList;
		String_t* L_0 = ___hostStr0;
		IPHostEntry_tAAAEB0F40DB9F28BE601B5FE7DA1D76191C94490* L_1;
		L_1 = Dns_GetHostEntry_m01156278E5CDAE38B7E1B2EC617F505A4B836D02(L_0, NULL);
		NullCheck(L_1);
		IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* L_2;
		L_2 = IPHostEntry_get_AddressList_m9D14D52EFB41C53C9C4A36D438E1333A99B7AA71_inline(L_1, NULL);
		// foreach (IPAddress ip in addresses)
		V_0 = L_2;
		V_1 = 0;
		goto IL_0023;
	}

IL_0010:
	{
		// foreach (IPAddress ip in addresses)
		IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* L_3 = V_0;
		int32_t L_4 = V_1;
		NullCheck(L_3);
		int32_t L_5 = L_4;
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_6 = (L_3)->GetAt(static_cast<il2cpp_array_size_t>(L_5));
		V_2 = L_6;
		// if (ip.AddressFamily == addressFamily)
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_7 = V_2;
		NullCheck(L_7);
		int32_t L_8;
		L_8 = IPAddress_get_AddressFamily_m1CE4BCCE499BD70B22F9E37B3F266F9306A98C21(L_7, NULL);
		int32_t L_9 = ___addressFamily1;
		if ((!(((uint32_t)L_8) == ((uint32_t)L_9))))
		{
			goto IL_001f;
		}
	}
	{
		// return ip;
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_10 = V_2;
		return L_10;
	}

IL_001f:
	{
		int32_t L_11 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_11, 1));
	}

IL_0023:
	{
		// foreach (IPAddress ip in addresses)
		int32_t L_12 = V_1;
		IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* L_13 = V_0;
		NullCheck(L_13);
		if ((((int32_t)L_12) < ((int32_t)((int32_t)(((RuntimeArray*)L_13)->max_length)))))
		{
			goto IL_0010;
		}
	}
	{
		// return null;
		return (IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484*)NULL;
	}
}
// System.Collections.Generic.List`1<System.String> FlyingWormConsole3.LiteNetLib.NetUtils::GetLocalIpList(FlyingWormConsole3.LiteNetLib.LocalAddrType)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* NetUtils_GetLocalIpList_m96A3EB16675E40F6B53ABACA5BFEEE7BE26E6DA0 (int32_t ___addrType0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// List<string> targetList = new List<string>();
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_0 = (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*)il2cpp_codegen_object_new(List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E(L_0, List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var);
		// GetLocalIpList(targetList, addrType);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_1 = L_0;
		int32_t L_2 = ___addrType0;
		il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		NetUtils_GetLocalIpList_m6DF77B2F0E1C6B7E39B1C5BF1938B741742C11F1(L_1, L_2, NULL);
		// return targetList;
		return L_1;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetUtils::GetLocalIpList(System.Collections.Generic.IList`1<System.String>,FlyingWormConsole3.LiteNetLib.LocalAddrType)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetUtils_GetLocalIpList_m6DF77B2F0E1C6B7E39B1C5BF1938B741742C11F1 (RuntimeObject* ___targetList0, int32_t ___addrType1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICollection_1_t5C03FBFD5ECBDE4EAB8C4ED582DDFCF702EB5DC7_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IDisposable_t030E0496B4E0E4E4F086825007979AF51F7248C5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerator_1_tA218C3658C89562941B7435E73E48E2EDC26D9BD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral6474EBE79D288AAD27635D1581EA921D28D400BC);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral76C3D4024DE9EE847070E35CC5A197DC21F66FEE);
		s_Il2CppMethodInitialized = true;
	}
	bool V_0 = false;
	bool V_1 = false;
	NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080* V_2 = NULL;
	int32_t V_3 = 0;
	NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A* V_4 = NULL;
	IPInterfaceProperties_t60A00D504E4F72CAFE4C0AE4DA6A062B44D1512F* V_5 = NULL;
	RuntimeObject* V_6 = NULL;
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* V_7 = NULL;
	IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* V_8 = NULL;
	IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* V_9 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		// bool ipv4 = (addrType & LocalAddrType.IPv4) == LocalAddrType.IPv4;
		int32_t L_0 = ___addrType1;
		V_0 = (bool)((((int32_t)((int32_t)((int32_t)L_0&1))) == ((int32_t)1))? 1 : 0);
		// bool ipv6 = (addrType & LocalAddrType.IPv6) == LocalAddrType.IPv6;
		int32_t L_1 = ___addrType1;
		V_1 = (bool)((((int32_t)((int32_t)((int32_t)L_1&2))) == ((int32_t)2))? 1 : 0);
	}
	try
	{// begin try (depth: 1)
		{
			// foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
			NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080* L_2;
			L_2 = NetworkInterface_GetAllNetworkInterfaces_mD3638D31C8C05E882CE28542D17821C95FCABE9D(NULL);
			V_2 = L_2;
			V_3 = 0;
			goto IL_00ad_1;
		}

IL_001b_1:
		{
			// foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
			NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080* L_3 = V_2;
			int32_t L_4 = V_3;
			NullCheck(L_3);
			int32_t L_5 = L_4;
			NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A* L_6 = (L_3)->GetAt(static_cast<il2cpp_array_size_t>(L_5));
			V_4 = L_6;
			// if (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback ||
			//     ni.OperationalStatus != OperationalStatus.Up)
			NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A* L_7 = V_4;
			NullCheck(L_7);
			int32_t L_8;
			L_8 = VirtualFuncInvoker0< int32_t >::Invoke(7 /* System.Net.NetworkInformation.NetworkInterfaceType System.Net.NetworkInformation.NetworkInterface::get_NetworkInterfaceType() */, L_7);
			if ((((int32_t)L_8) == ((int32_t)((int32_t)24))))
			{
				goto IL_00a9_1;
			}
		}
		{
			NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A* L_9 = V_4;
			NullCheck(L_9);
			int32_t L_10;
			L_10 = VirtualFuncInvoker0< int32_t >::Invoke(6 /* System.Net.NetworkInformation.OperationalStatus System.Net.NetworkInformation.NetworkInterface::get_OperationalStatus() */, L_9);
			if ((!(((uint32_t)L_10) == ((uint32_t)1))))
			{
				goto IL_00a9_1;
			}
		}
		{
			// var ipProps = ni.GetIPProperties();
			NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A* L_11 = V_4;
			NullCheck(L_11);
			IPInterfaceProperties_t60A00D504E4F72CAFE4C0AE4DA6A062B44D1512F* L_12;
			L_12 = VirtualFuncInvoker0< IPInterfaceProperties_t60A00D504E4F72CAFE4C0AE4DA6A062B44D1512F* >::Invoke(5 /* System.Net.NetworkInformation.IPInterfaceProperties System.Net.NetworkInformation.NetworkInterface::GetIPProperties() */, L_11);
			V_5 = L_12;
			// if (ipProps.GatewayAddresses.Count == 0)
			IPInterfaceProperties_t60A00D504E4F72CAFE4C0AE4DA6A062B44D1512F* L_13 = V_5;
			NullCheck(L_13);
			GatewayIPAddressInformationCollection_t4D24D7B02E632A5F8DBE65DBFB751C2EC925E817* L_14;
			L_14 = VirtualFuncInvoker0< GatewayIPAddressInformationCollection_t4D24D7B02E632A5F8DBE65DBFB751C2EC925E817* >::Invoke(5 /* System.Net.NetworkInformation.GatewayIPAddressInformationCollection System.Net.NetworkInformation.IPInterfaceProperties::get_GatewayAddresses() */, L_13);
			NullCheck(L_14);
			int32_t L_15;
			L_15 = VirtualFuncInvoker0< int32_t >::Invoke(14 /* System.Int32 System.Net.NetworkInformation.GatewayIPAddressInformationCollection::get_Count() */, L_14);
			if (!L_15)
			{
				goto IL_00a9_1;
			}
		}
		{
			// foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
			IPInterfaceProperties_t60A00D504E4F72CAFE4C0AE4DA6A062B44D1512F* L_16 = V_5;
			NullCheck(L_16);
			UnicastIPAddressInformationCollection_tB4D61C9127DFB4168CA3855020CCEB59B75C6EDA* L_17;
			L_17 = VirtualFuncInvoker0< UnicastIPAddressInformationCollection_tB4D61C9127DFB4168CA3855020CCEB59B75C6EDA* >::Invoke(4 /* System.Net.NetworkInformation.UnicastIPAddressInformationCollection System.Net.NetworkInformation.IPInterfaceProperties::get_UnicastAddresses() */, L_16);
			NullCheck(L_17);
			RuntimeObject* L_18;
			L_18 = VirtualFuncInvoker0< RuntimeObject* >::Invoke(18 /* System.Collections.Generic.IEnumerator`1<System.Net.NetworkInformation.UnicastIPAddressInformation> System.Net.NetworkInformation.UnicastIPAddressInformationCollection::GetEnumerator() */, L_17);
			V_6 = L_18;
		}
		{
			auto __finallyBlock = il2cpp::utils::Finally([&]
			{

FINALLY_009d_1:
				{// begin finally (depth: 2)
					{
						RuntimeObject* L_19 = V_6;
						if (!L_19)
						{
							goto IL_00a8_1;
						}
					}
					{
						RuntimeObject* L_20 = V_6;
						NullCheck(L_20);
						InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t030E0496B4E0E4E4F086825007979AF51F7248C5_il2cpp_TypeInfo_var, L_20);
					}

IL_00a8_1:
					{
						return;
					}
				}// end finally (depth: 2)
			});
			try
			{// begin try (depth: 2)
				{
					goto IL_0092_2;
				}

IL_005c_2:
				{
					// foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
					RuntimeObject* L_21 = V_6;
					NullCheck(L_21);
					UnicastIPAddressInformation_t4ACCADE9FBC1F8243A602439C94301E2C30295F3* L_22;
					L_22 = InterfaceFuncInvoker0< UnicastIPAddressInformation_t4ACCADE9FBC1F8243A602439C94301E2C30295F3* >::Invoke(0 /* T System.Collections.Generic.IEnumerator`1<System.Net.NetworkInformation.UnicastIPAddressInformation>::get_Current() */, IEnumerator_1_tA218C3658C89562941B7435E73E48E2EDC26D9BD_il2cpp_TypeInfo_var, L_21);
					// var address = ip.Address;
					NullCheck(L_22);
					IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_23;
					L_23 = VirtualFuncInvoker0< IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* >::Invoke(4 /* System.Net.IPAddress System.Net.NetworkInformation.IPAddressInformation::get_Address() */, L_22);
					V_7 = L_23;
					// if ((ipv4 && address.AddressFamily == AddressFamily.InterNetwork) ||
					//     (ipv6 && address.AddressFamily == AddressFamily.InterNetworkV6))
					bool L_24 = V_0;
					if (!L_24)
					{
						goto IL_0077_2;
					}
				}
				{
					IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_25 = V_7;
					NullCheck(L_25);
					int32_t L_26;
					L_26 = IPAddress_get_AddressFamily_m1CE4BCCE499BD70B22F9E37B3F266F9306A98C21(L_25, NULL);
					if ((((int32_t)L_26) == ((int32_t)2)))
					{
						goto IL_0085_2;
					}
				}

IL_0077_2:
				{
					bool L_27 = V_1;
					if (!L_27)
					{
						goto IL_0092_2;
					}
				}
				{
					IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_28 = V_7;
					NullCheck(L_28);
					int32_t L_29;
					L_29 = IPAddress_get_AddressFamily_m1CE4BCCE499BD70B22F9E37B3F266F9306A98C21(L_28, NULL);
					if ((!(((uint32_t)L_29) == ((uint32_t)((int32_t)23)))))
					{
						goto IL_0092_2;
					}
				}

IL_0085_2:
				{
					// targetList.Add(address.ToString());
					RuntimeObject* L_30 = ___targetList0;
					IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_31 = V_7;
					NullCheck(L_31);
					String_t* L_32;
					L_32 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_31);
					NullCheck(L_30);
					InterfaceActionInvoker1< String_t* >::Invoke(2 /* System.Void System.Collections.Generic.ICollection`1<System.String>::Add(T) */, ICollection_1_t5C03FBFD5ECBDE4EAB8C4ED582DDFCF702EB5DC7_il2cpp_TypeInfo_var, L_30, L_32);
				}

IL_0092_2:
				{
					// foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
					RuntimeObject* L_33 = V_6;
					NullCheck(L_33);
					bool L_34;
					L_34 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA_il2cpp_TypeInfo_var, L_33);
					if (L_34)
					{
						goto IL_005c_2;
					}
				}
				{
					goto IL_00a9_1;
				}
			}// end try (depth: 2)
			catch(Il2CppExceptionWrapper& e)
			{
				__finallyBlock.StoreException(e.ex);
			}
		}

IL_00a9_1:
		{
			int32_t L_35 = V_3;
			V_3 = ((int32_t)il2cpp_codegen_add(L_35, 1));
		}

IL_00ad_1:
		{
			// foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
			int32_t L_36 = V_3;
			NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080* L_37 = V_2;
			NullCheck(L_37);
			if ((((int32_t)L_36) < ((int32_t)((int32_t)(((RuntimeArray*)L_37)->max_length)))))
			{
				goto IL_001b_1;
			}
		}
		{
			// }
			goto IL_00bb;
		}
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&RuntimeObject_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_00b8;
		}
		throw e;
	}

CATCH_00b8:
	{// begin catch(System.Object)
		// catch
		// }
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_00bb;
	}// end catch (depth: 1)

IL_00bb:
	{
		// if (targetList.Count == 0)
		RuntimeObject* L_38 = ___targetList0;
		NullCheck(L_38);
		int32_t L_39;
		L_39 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.ICollection`1<System.String>::get_Count() */, ICollection_1_t5C03FBFD5ECBDE4EAB8C4ED582DDFCF702EB5DC7_il2cpp_TypeInfo_var, L_38);
		if (L_39)
		{
			goto IL_0111;
		}
	}
	{
		// IPAddress[] addresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		String_t* L_40;
		L_40 = Dns_GetHostName_mF728787FF8A38620054B934FD08E021460A7C14D(NULL);
		IPHostEntry_tAAAEB0F40DB9F28BE601B5FE7DA1D76191C94490* L_41;
		L_41 = Dns_GetHostEntry_m01156278E5CDAE38B7E1B2EC617F505A4B836D02(L_40, NULL);
		NullCheck(L_41);
		IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* L_42;
		L_42 = IPHostEntry_get_AddressList_m9D14D52EFB41C53C9C4A36D438E1333A99B7AA71_inline(L_41, NULL);
		// foreach (IPAddress ip in addresses)
		V_8 = L_42;
		V_3 = 0;
		goto IL_010a;
	}

IL_00d8:
	{
		// foreach (IPAddress ip in addresses)
		IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* L_43 = V_8;
		int32_t L_44 = V_3;
		NullCheck(L_43);
		int32_t L_45 = L_44;
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_46 = (L_43)->GetAt(static_cast<il2cpp_array_size_t>(L_45));
		V_9 = L_46;
		// if((ipv4 && ip.AddressFamily == AddressFamily.InterNetwork) ||
		//    (ipv6 && ip.AddressFamily == AddressFamily.InterNetworkV6))
		bool L_47 = V_0;
		if (!L_47)
		{
			goto IL_00eb;
		}
	}
	{
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_48 = V_9;
		NullCheck(L_48);
		int32_t L_49;
		L_49 = IPAddress_get_AddressFamily_m1CE4BCCE499BD70B22F9E37B3F266F9306A98C21(L_48, NULL);
		if ((((int32_t)L_49) == ((int32_t)2)))
		{
			goto IL_00f9;
		}
	}

IL_00eb:
	{
		bool L_50 = V_1;
		if (!L_50)
		{
			goto IL_0106;
		}
	}
	{
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_51 = V_9;
		NullCheck(L_51);
		int32_t L_52;
		L_52 = IPAddress_get_AddressFamily_m1CE4BCCE499BD70B22F9E37B3F266F9306A98C21(L_51, NULL);
		if ((!(((uint32_t)L_52) == ((uint32_t)((int32_t)23)))))
		{
			goto IL_0106;
		}
	}

IL_00f9:
	{
		// targetList.Add(ip.ToString());
		RuntimeObject* L_53 = ___targetList0;
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_54 = V_9;
		NullCheck(L_54);
		String_t* L_55;
		L_55 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_54);
		NullCheck(L_53);
		InterfaceActionInvoker1< String_t* >::Invoke(2 /* System.Void System.Collections.Generic.ICollection`1<System.String>::Add(T) */, ICollection_1_t5C03FBFD5ECBDE4EAB8C4ED582DDFCF702EB5DC7_il2cpp_TypeInfo_var, L_53, L_55);
	}

IL_0106:
	{
		int32_t L_56 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_56, 1));
	}

IL_010a:
	{
		// foreach (IPAddress ip in addresses)
		int32_t L_57 = V_3;
		IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* L_58 = V_8;
		NullCheck(L_58);
		if ((((int32_t)L_57) < ((int32_t)((int32_t)(((RuntimeArray*)L_58)->max_length)))))
		{
			goto IL_00d8;
		}
	}

IL_0111:
	{
		// if (targetList.Count == 0)
		RuntimeObject* L_59 = ___targetList0;
		NullCheck(L_59);
		int32_t L_60;
		L_60 = InterfaceFuncInvoker0< int32_t >::Invoke(0 /* System.Int32 System.Collections.Generic.ICollection`1<System.String>::get_Count() */, ICollection_1_t5C03FBFD5ECBDE4EAB8C4ED582DDFCF702EB5DC7_il2cpp_TypeInfo_var, L_59);
		if (L_60)
		{
			goto IL_0135;
		}
	}
	{
		// if(ipv4)
		bool L_61 = V_0;
		if (!L_61)
		{
			goto IL_0127;
		}
	}
	{
		// targetList.Add("127.0.0.1");
		RuntimeObject* L_62 = ___targetList0;
		NullCheck(L_62);
		InterfaceActionInvoker1< String_t* >::Invoke(2 /* System.Void System.Collections.Generic.ICollection`1<System.String>::Add(T) */, ICollection_1_t5C03FBFD5ECBDE4EAB8C4ED582DDFCF702EB5DC7_il2cpp_TypeInfo_var, L_62, _stringLiteral76C3D4024DE9EE847070E35CC5A197DC21F66FEE);
	}

IL_0127:
	{
		// if(ipv6)
		bool L_63 = V_1;
		if (!L_63)
		{
			goto IL_0135;
		}
	}
	{
		// targetList.Add("::1");
		RuntimeObject* L_64 = ___targetList0;
		NullCheck(L_64);
		InterfaceActionInvoker1< String_t* >::Invoke(2 /* System.Void System.Collections.Generic.ICollection`1<System.String>::Add(T) */, ICollection_1_t5C03FBFD5ECBDE4EAB8C4ED582DDFCF702EB5DC7_il2cpp_TypeInfo_var, L_64, _stringLiteral6474EBE79D288AAD27635D1581EA921D28D400BC);
	}

IL_0135:
	{
		// }
		return;
	}
}
// System.String FlyingWormConsole3.LiteNetLib.NetUtils::GetLocalIp(FlyingWormConsole3.LiteNetLib.LocalAddrType)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NetUtils_GetLocalIp_mA725FD03F87AA36F26AD6280D6EC4067C13146F1 (int32_t ___addrType0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_Clear_mC6C7AEBB0F980A717A87C0D12377984A464F0934_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&String_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* V_0 = NULL;
	bool V_1 = false;
	String_t* V_2 = NULL;
	String_t* G_B4_0 = NULL;
	{
		// lock (IpList)
		il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_0 = ((NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_StaticFields*)il2cpp_codegen_static_fields_for(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var))->___IpList_0;
		V_0 = L_0;
		V_1 = (bool)0;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_0046:
			{// begin finally (depth: 1)
				{
					bool L_1 = V_1;
					if (!L_1)
					{
						goto IL_004f;
					}
				}
				{
					List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_2 = V_0;
					Monitor_Exit_m25A154960F91391E10E4CDA245ECDF4BA94D56A9(L_2, NULL);
				}

IL_004f:
				{
					return;
				}
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			{
				List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_3 = V_0;
				Monitor_Enter_m00506757392936AA62DBE2C5FFBEE69EE920C4D4(L_3, (&V_1), NULL);
				// IpList.Clear();
				il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
				List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_4 = ((NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_StaticFields*)il2cpp_codegen_static_fields_for(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var))->___IpList_0;
				NullCheck(L_4);
				List_1_Clear_mC6C7AEBB0F980A717A87C0D12377984A464F0934_inline(L_4, List_1_Clear_mC6C7AEBB0F980A717A87C0D12377984A464F0934_RuntimeMethod_var);
				// GetLocalIpList(IpList, addrType);
				List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_5 = ((NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_StaticFields*)il2cpp_codegen_static_fields_for(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var))->___IpList_0;
				int32_t L_6 = ___addrType0;
				NetUtils_GetLocalIpList_m6DF77B2F0E1C6B7E39B1C5BF1938B741742C11F1(L_5, L_6, NULL);
				// return IpList.Count == 0 ? string.Empty : IpList[0];
				List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_7 = ((NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_StaticFields*)il2cpp_codegen_static_fields_for(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var))->___IpList_0;
				NullCheck(L_7);
				int32_t L_8;
				L_8 = List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_inline(L_7, List_1_get_Count_mB63183A9151F4345A9DD444A7CBE0D6E03F77C7C_RuntimeMethod_var);
				if (!L_8)
				{
					goto IL_003e_1;
				}
			}
			{
				il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
				List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_9 = ((NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_StaticFields*)il2cpp_codegen_static_fields_for(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var))->___IpList_0;
				NullCheck(L_9);
				String_t* L_10;
				L_10 = List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8(L_9, 0, List_1_get_Item_m21AEC50E791371101DC22ABCF96A2E46800811F8_RuntimeMethod_var);
				G_B4_0 = L_10;
				goto IL_0043_1;
			}

IL_003e_1:
			{
				String_t* L_11 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->___Empty_6;
				G_B4_0 = L_11;
			}

IL_0043_1:
			{
				V_2 = G_B4_0;
				goto IL_0050;
			}
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_0050:
	{
		// }
		String_t* L_12 = V_2;
		return L_12;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetUtils::PrintInterfaceInfos()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetUtils_PrintInterfaceInfos_m44B40D989561A1698AF1B810BF9DB1F1C15CEAF4 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IDisposable_t030E0496B4E0E4E4F086825007979AF51F7248C5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerator_1_tA218C3658C89562941B7435E73E48E2EDC26D9BD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080* V_0 = NULL;
	int32_t V_1 = 0;
	RuntimeObject* V_2 = NULL;
	UnicastIPAddressInformation_t4ACCADE9FBC1F8243A602439C94301E2C30295F3* V_3 = NULL;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	try
	{// begin try (depth: 1)
		{
			// foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
			NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080* L_0;
			L_0 = NetworkInterface_GetAllNetworkInterfaces_mD3638D31C8C05E882CE28542D17821C95FCABE9D(NULL);
			V_0 = L_0;
			V_1 = 0;
			goto IL_005b_1;
		}

IL_000a_1:
		{
			// foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
			NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080* L_1 = V_0;
			int32_t L_2 = V_1;
			NullCheck(L_1);
			int32_t L_3 = L_2;
			NetworkInterface_t3E7DDFADB8912D0F9D001D1195EBD0FB08B7F47A* L_4 = (L_1)->GetAt(static_cast<il2cpp_array_size_t>(L_3));
			// foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
			NullCheck(L_4);
			IPInterfaceProperties_t60A00D504E4F72CAFE4C0AE4DA6A062B44D1512F* L_5;
			L_5 = VirtualFuncInvoker0< IPInterfaceProperties_t60A00D504E4F72CAFE4C0AE4DA6A062B44D1512F* >::Invoke(5 /* System.Net.NetworkInformation.IPInterfaceProperties System.Net.NetworkInformation.NetworkInterface::GetIPProperties() */, L_4);
			NullCheck(L_5);
			UnicastIPAddressInformationCollection_tB4D61C9127DFB4168CA3855020CCEB59B75C6EDA* L_6;
			L_6 = VirtualFuncInvoker0< UnicastIPAddressInformationCollection_tB4D61C9127DFB4168CA3855020CCEB59B75C6EDA* >::Invoke(4 /* System.Net.NetworkInformation.UnicastIPAddressInformationCollection System.Net.NetworkInformation.IPInterfaceProperties::get_UnicastAddresses() */, L_5);
			NullCheck(L_6);
			RuntimeObject* L_7;
			L_7 = VirtualFuncInvoker0< RuntimeObject* >::Invoke(18 /* System.Collections.Generic.IEnumerator`1<System.Net.NetworkInformation.UnicastIPAddressInformation> System.Net.NetworkInformation.UnicastIPAddressInformationCollection::GetEnumerator() */, L_6);
			V_2 = L_7;
		}
		{
			auto __finallyBlock = il2cpp::utils::Finally([&]
			{

FINALLY_004d_1:
				{// begin finally (depth: 2)
					{
						RuntimeObject* L_8 = V_2;
						if (!L_8)
						{
							goto IL_0056_1;
						}
					}
					{
						RuntimeObject* L_9 = V_2;
						NullCheck(L_9);
						InterfaceActionInvoker0::Invoke(0 /* System.Void System.IDisposable::Dispose() */, IDisposable_t030E0496B4E0E4E4F086825007979AF51F7248C5_il2cpp_TypeInfo_var, L_9);
					}

IL_0056_1:
					{
						return;
					}
				}// end finally (depth: 2)
			});
			try
			{// begin try (depth: 2)
				{
					goto IL_0043_2;
				}

IL_001f_2:
				{
					// foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
					RuntimeObject* L_10 = V_2;
					NullCheck(L_10);
					UnicastIPAddressInformation_t4ACCADE9FBC1F8243A602439C94301E2C30295F3* L_11;
					L_11 = InterfaceFuncInvoker0< UnicastIPAddressInformation_t4ACCADE9FBC1F8243A602439C94301E2C30295F3* >::Invoke(0 /* T System.Collections.Generic.IEnumerator`1<System.Net.NetworkInformation.UnicastIPAddressInformation>::get_Current() */, IEnumerator_1_tA218C3658C89562941B7435E73E48E2EDC26D9BD_il2cpp_TypeInfo_var, L_10);
					V_3 = L_11;
					// if (ip.Address.AddressFamily == AddressFamily.InterNetwork ||
					//     ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
					UnicastIPAddressInformation_t4ACCADE9FBC1F8243A602439C94301E2C30295F3* L_12 = V_3;
					NullCheck(L_12);
					IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_13;
					L_13 = VirtualFuncInvoker0< IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* >::Invoke(4 /* System.Net.IPAddress System.Net.NetworkInformation.IPAddressInformation::get_Address() */, L_12);
					NullCheck(L_13);
					int32_t L_14;
					L_14 = IPAddress_get_AddressFamily_m1CE4BCCE499BD70B22F9E37B3F266F9306A98C21(L_13, NULL);
					if ((((int32_t)L_14) == ((int32_t)2)))
					{
						goto IL_0043_2;
					}
				}
				{
					UnicastIPAddressInformation_t4ACCADE9FBC1F8243A602439C94301E2C30295F3* L_15 = V_3;
					NullCheck(L_15);
					IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_16;
					L_16 = VirtualFuncInvoker0< IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* >::Invoke(4 /* System.Net.IPAddress System.Net.NetworkInformation.IPAddressInformation::get_Address() */, L_15);
					NullCheck(L_16);
					int32_t L_17;
					L_17 = IPAddress_get_AddressFamily_m1CE4BCCE499BD70B22F9E37B3F266F9306A98C21(L_16, NULL);
				}

IL_0043_2:
				{
					// foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
					RuntimeObject* L_18 = V_2;
					NullCheck(L_18);
					bool L_19;
					L_19 = InterfaceFuncInvoker0< bool >::Invoke(0 /* System.Boolean System.Collections.IEnumerator::MoveNext() */, IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA_il2cpp_TypeInfo_var, L_18);
					if (L_19)
					{
						goto IL_001f_2;
					}
				}
				{
					goto IL_0057_1;
				}
			}// end try (depth: 2)
			catch(Il2CppExceptionWrapper& e)
			{
				__finallyBlock.StoreException(e.ex);
			}
		}

IL_0057_1:
		{
			int32_t L_20 = V_1;
			V_1 = ((int32_t)il2cpp_codegen_add(L_20, 1));
		}

IL_005b_1:
		{
			// foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
			int32_t L_21 = V_1;
			NetworkInterfaceU5BU5D_t62783E27F1C4A989B118CDBBE2FCBE65EE5CA080* L_22 = V_0;
			NullCheck(L_22);
			if ((((int32_t)L_21) < ((int32_t)((int32_t)(((RuntimeArray*)L_22)->max_length)))))
			{
				goto IL_000a_1;
			}
		}
		{
			// }
			goto IL_0066;
		}
	}// end try (depth: 1)
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0063;
		}
		throw e;
	}

CATCH_0063:
	{// begin catch(System.Exception)
		// catch (Exception e)
		// }
		IL2CPP_POP_ACTIVE_EXCEPTION();
		goto IL_0066;
	}// end catch (depth: 1)

IL_0066:
	{
		// }
		return;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.NetUtils::RelativeSequenceNumber(System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetUtils_RelativeSequenceNumber_mCA9FAA443395636279506E0E0F9C8D6905935D49 (int32_t ___number0, int32_t ___expected1, const RuntimeMethod* method) 
{
	{
		// return (number - expected + NetConstants.MaxSequence + NetConstants.HalfMaxSequence) % NetConstants.MaxSequence - NetConstants.HalfMaxSequence;
		int32_t L_0 = ___number0;
		int32_t L_1 = ___expected1;
		return ((int32_t)il2cpp_codegen_subtract(((int32_t)(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(L_0, L_1)), ((int32_t)32768))), ((int32_t)16384)))%((int32_t)32768))), ((int32_t)16384)));
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.NetUtils::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetUtils__cctor_mECC3032331452042610C6E7F01ACE1D4928BD1EC (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// private static readonly List<string> IpList = new List<string>();
		List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD* L_0 = (List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD*)il2cpp_codegen_object_new(List_1_tF470A3BE5C1B5B68E1325EF3F109D172E60BD7CD_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E(L_0, List_1__ctor_mCA8DD57EAC70C2B5923DBB9D5A77CEAC22E7068E_RuntimeMethod_var);
		((NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_StaticFields*)il2cpp_codegen_static_fields_for(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var))->___IpList_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_StaticFields*)il2cpp_codegen_static_fields_for(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var))->___IpList_0), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.ReliableChannel::.ctor(FlyingWormConsole3.LiteNetLib.NetPeer,System.Boolean,System.Byte)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ReliableChannel__ctor_mC26296E02FB9BB5A52DEE9471C00181191757998 (ReliableChannel_tCF02F710AA06E981A959C4528BD13D2ED96B4014* __this, NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___peer0, bool ___ordered1, uint8_t ___id2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// public ReliableChannel(NetPeer peer, bool ordered, byte id) : base(peer)
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_0 = ___peer0;
		BaseChannel__ctor_m6EC2E55242CB43181FED32EF1A74C51ACAFACAD6(__this, L_0, NULL);
		// _id = id;
		uint8_t L_1 = ___id2;
		__this->____id_16 = L_1;
		// _windowSize = NetConstants.DefaultWindowSize;
		__this->____windowSize_14 = ((int32_t)64);
		// _ordered = ordered;
		bool L_2 = ___ordered1;
		__this->____ordered_13 = L_2;
		// _pendingPackets = new PendingPacket[_windowSize];
		int32_t L_3 = __this->____windowSize_14;
		PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_4 = (PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003*)(PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003*)SZArrayNew(PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003_il2cpp_TypeInfo_var, (uint32_t)L_3);
		__this->____pendingPackets_4 = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____pendingPackets_4), (void*)L_4);
		// for (int i = 0; i < _pendingPackets.Length; i++)
		V_0 = 0;
		goto IL_0048;
	}

IL_0032:
	{
		// _pendingPackets[i] = new PendingPacket();
		PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_5 = __this->____pendingPackets_4;
		int32_t L_6 = V_0;
		NullCheck(L_5);
		il2cpp_codegen_initobj(((L_5)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_6))), sizeof(PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6));
		// for (int i = 0; i < _pendingPackets.Length; i++)
		int32_t L_7 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_7, 1));
	}

IL_0048:
	{
		// for (int i = 0; i < _pendingPackets.Length; i++)
		int32_t L_8 = V_0;
		PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_9 = __this->____pendingPackets_4;
		NullCheck(L_9);
		if ((((int32_t)L_8) < ((int32_t)((int32_t)(((RuntimeArray*)L_9)->max_length)))))
		{
			goto IL_0032;
		}
	}
	{
		// if (_ordered)
		bool L_10 = __this->____ordered_13;
		if (!L_10)
		{
			goto IL_0075;
		}
	}
	{
		// _deliveryMethod = DeliveryMethod.ReliableOrdered;
		__this->____deliveryMethod_12 = 2;
		// _receivedPackets = new NetPacket[_windowSize];
		int32_t L_11 = __this->____windowSize_14;
		NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F* L_12 = (NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F*)(NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F*)SZArrayNew(NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F_il2cpp_TypeInfo_var, (uint32_t)L_11);
		__this->____receivedPackets_5 = L_12;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____receivedPackets_5), (void*)L_12);
		goto IL_008d;
	}

IL_0075:
	{
		// _deliveryMethod = DeliveryMethod.ReliableUnordered;
		__this->____deliveryMethod_12 = 0;
		// _earlyReceived = new bool[_windowSize];
		int32_t L_13 = __this->____windowSize_14;
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_14 = (BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*)(BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*)SZArrayNew(BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4_il2cpp_TypeInfo_var, (uint32_t)L_13);
		__this->____earlyReceived_6 = L_14;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____earlyReceived_6), (void*)L_14);
	}

IL_008d:
	{
		// _localWindowStart = 0;
		__this->____localWindowStart_9 = 0;
		// _localSeqence = 0;
		__this->____localSeqence_7 = 0;
		// _remoteSequence = 0;
		__this->____remoteSequence_8 = 0;
		// _remoteWindowStart = 0;
		__this->____remoteWindowStart_10 = 0;
		// _outgoingAcks = new NetPacket(PacketProperty.Ack, (_windowSize - 1) / BitsInByte + 2) {ChannelId = id};
		int32_t L_15 = __this->____windowSize_14;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_16 = (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED*)il2cpp_codegen_object_new(NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED_il2cpp_TypeInfo_var);
		NullCheck(L_16);
		NetPacket__ctor_m64EDA1B3C197027137887A26852E9E5490DEA8C8(L_16, 2, ((int32_t)il2cpp_codegen_add(((int32_t)(((int32_t)il2cpp_codegen_subtract(L_15, 1))/8)), 2)), NULL);
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_17 = L_16;
		uint8_t L_18 = ___id2;
		NullCheck(L_17);
		NetPacket_set_ChannelId_mF020D3EEF06D9CE0344D731F2E13CE41DA4395CB(L_17, L_18, NULL);
		__this->____outgoingAcks_3 = L_17;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____outgoingAcks_3), (void*)L_17);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.ReliableChannel::ProcessAck(FlyingWormConsole3.LiteNetLib.NetPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ReliableChannel_ProcessAck_m7C2322827BF50314E9D02C719195990347900E21 (ReliableChannel_tCF02F710AA06E981A959C4528BD13D2ED96B4014* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	int32_t V_1 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_2 = NULL;
	PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* V_3 = NULL;
	bool V_4 = false;
	int32_t V_5 = 0;
	int32_t V_6 = 0;
	int32_t V_7 = 0;
	int32_t V_8 = 0;
	{
		// if (packet.Size != _outgoingAcks.Size)
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_0 = ___packet0;
		NullCheck(L_0);
		int32_t L_1 = L_0->___Size_3;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_2 = __this->____outgoingAcks_3;
		NullCheck(L_2);
		int32_t L_3 = L_2->___Size_3;
		if ((((int32_t)L_1) == ((int32_t)L_3)))
		{
			goto IL_0014;
		}
	}
	{
		// return;
		return;
	}

IL_0014:
	{
		// ushort ackWindowStart = packet.Sequence;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_4 = ___packet0;
		NullCheck(L_4);
		uint16_t L_5;
		L_5 = NetPacket_get_Sequence_m2388D004EF4D404ED0C3FB4DA95CA2E56C80E4F9(L_4, NULL);
		V_0 = L_5;
		// int windowRel = NetUtils.RelativeSequenceNumber(_localWindowStart, ackWindowStart);
		int32_t L_6 = __this->____localWindowStart_9;
		uint16_t L_7 = V_0;
		il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		int32_t L_8;
		L_8 = NetUtils_RelativeSequenceNumber_mCA9FAA443395636279506E0E0F9C8D6905935D49(L_6, L_7, NULL);
		V_1 = L_8;
		// if (ackWindowStart >= NetConstants.MaxSequence || windowRel < 0)
		uint16_t L_9 = V_0;
		if ((((int32_t)L_9) >= ((int32_t)((int32_t)32768))))
		{
			goto IL_0034;
		}
	}
	{
		int32_t L_10 = V_1;
		if ((((int32_t)L_10) >= ((int32_t)0)))
		{
			goto IL_0035;
		}
	}

IL_0034:
	{
		// return;
		return;
	}

IL_0035:
	{
		// if (windowRel >= _windowSize)
		int32_t L_11 = V_1;
		int32_t L_12 = __this->____windowSize_14;
		if ((((int32_t)L_11) < ((int32_t)L_12)))
		{
			goto IL_003f;
		}
	}
	{
		// return;
		return;
	}

IL_003f:
	{
		// byte[] acksData = packet.RawData;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_13 = ___packet0;
		NullCheck(L_13);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_14 = L_13->___RawData_2;
		V_2 = L_14;
		// lock (_pendingPackets)
		PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_15 = __this->____pendingPackets_4;
		V_3 = L_15;
		V_4 = (bool)0;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_012c:
			{// begin finally (depth: 1)
				{
					bool L_16 = V_4;
					if (!L_16)
					{
						goto IL_0136;
					}
				}
				{
					PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_17 = V_3;
					Monitor_Exit_m25A154960F91391E10E4CDA245ECDF4BA94D56A9((RuntimeObject*)L_17, NULL);
				}

IL_0136:
				{
					return;
				}
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			{
				PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_18 = V_3;
				Monitor_Enter_m00506757392936AA62DBE2C5FFBEE69EE920C4D4((RuntimeObject*)L_18, (&V_4), NULL);
				// for (int pendingSeq = _localWindowStart;
				int32_t L_19 = __this->____localWindowStart_9;
				V_5 = L_19;
				goto IL_011d_1;
			}

IL_0065_1:
			{
				// int rel = NetUtils.RelativeSequenceNumber(pendingSeq, ackWindowStart);
				int32_t L_20 = V_5;
				uint16_t L_21 = V_0;
				il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
				int32_t L_22;
				L_22 = NetUtils_RelativeSequenceNumber_mCA9FAA443395636279506E0E0F9C8D6905935D49(L_20, L_21, NULL);
				// if (rel >= _windowSize)
				int32_t L_23 = __this->____windowSize_14;
				if ((((int32_t)L_22) < ((int32_t)L_23)))
				{
					goto IL_007a_1;
				}
			}
			{
				// break;
				goto IL_0137;
			}

IL_007a_1:
			{
				// int pendingIdx = pendingSeq % _windowSize;
				int32_t L_24 = V_5;
				int32_t L_25 = __this->____windowSize_14;
				V_6 = ((int32_t)(L_24%L_25));
				// int currentByte = NetConstants.ChanneledHeaderSize + pendingIdx / BitsInByte;
				int32_t L_26 = V_6;
				V_7 = ((int32_t)il2cpp_codegen_add(4, ((int32_t)(L_26/8))));
				// int currentBit = pendingIdx % BitsInByte;
				int32_t L_27 = V_6;
				V_8 = ((int32_t)(L_27%8));
				// if ((acksData[currentByte] & (1 << currentBit)) == 0)
				ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_28 = V_2;
				int32_t L_29 = V_7;
				NullCheck(L_28);
				int32_t L_30 = L_29;
				uint8_t L_31 = (L_28)->GetAt(static_cast<il2cpp_array_size_t>(L_30));
				int32_t L_32 = V_8;
				if (((int32_t)((int32_t)L_31&((int32_t)(1<<((int32_t)(L_32&((int32_t)31))))))))
				{
					goto IL_00da_1;
				}
			}
			{
				// if (Peer.NetManager.EnableStatistics)
				NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_33 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
				NullCheck(L_33);
				NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_34 = L_33->___NetManager_43;
				NullCheck(L_34);
				bool L_35 = L_34->___EnableStatistics_41;
				if (!L_35)
				{
					goto IL_0111_1;
				}
			}
			{
				// Peer.Statistics.IncrementPacketLoss();
				NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_36 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
				NullCheck(L_36);
				NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* L_37 = L_36->___Statistics_46;
				NullCheck(L_37);
				NetStatistics_IncrementPacketLoss_m6AF8CA81D7D3064EB05121D8D499BCF5C72763BC(L_37, NULL);
				// Peer.NetManager.Statistics.IncrementPacketLoss();
				NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_38 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
				NullCheck(L_38);
				NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_39 = L_38->___NetManager_43;
				NullCheck(L_39);
				NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* L_40 = L_39->___Statistics_40;
				NullCheck(L_40);
				NetStatistics_IncrementPacketLoss_m6AF8CA81D7D3064EB05121D8D499BCF5C72763BC(L_40, NULL);
				// continue;
				goto IL_0111_1;
			}

IL_00da_1:
			{
				// if (pendingSeq == _localWindowStart)
				int32_t L_41 = V_5;
				int32_t L_42 = __this->____localWindowStart_9;
				if ((!(((uint32_t)L_41) == ((uint32_t)L_42))))
				{
					goto IL_00f8_1;
				}
			}
			{
				// _localWindowStart = (_localWindowStart + 1) % NetConstants.MaxSequence;
				int32_t L_43 = __this->____localWindowStart_9;
				__this->____localWindowStart_9 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_43, 1))%((int32_t)32768)));
			}

IL_00f8_1:
			{
				// if (_pendingPackets[pendingIdx].Clear(Peer))
				PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_44 = __this->____pendingPackets_4;
				int32_t L_45 = V_6;
				NullCheck(L_44);
				NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_46 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
				bool L_47;
				L_47 = PendingPacket_Clear_m6C98ACC437234C8DC24341538EE5505B6824E87A(((L_44)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_45))), L_46, NULL);
			}

IL_0111_1:
			{
				// pendingSeq = (pendingSeq + 1) % NetConstants.MaxSequence)
				int32_t L_48 = V_5;
				V_5 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_48, 1))%((int32_t)32768)));
			}

IL_011d_1:
			{
				// pendingSeq != _localSeqence;
				int32_t L_49 = V_5;
				int32_t L_50 = __this->____localSeqence_7;
				if ((!(((uint32_t)L_49) == ((uint32_t)L_50))))
				{
					goto IL_0065_1;
				}
			}
			{
				// }
				goto IL_0137;
			}
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_0137:
	{
		// }
		return;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.ReliableChannel::SendNextPackets()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ReliableChannel_SendNextPackets_m59825F4C62AABBE027B8C2903C13BF104A9CC9ED (ReliableChannel_tCF02F710AA06E981A959C4528BD13D2ED96B4014* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Queue_1_Dequeue_m7A34883DDDA022398188F8BC0D48204E767A9230_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	int64_t V_0 = 0;
	bool V_1 = false;
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* V_2 = NULL;
	bool V_3 = false;
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D V_4;
	memset((&V_4), 0, sizeof(V_4));
	PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* V_5 = NULL;
	Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* V_6 = NULL;
	bool V_7 = false;
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* V_8 = NULL;
	int32_t V_9 = 0;
	bool V_10 = false;
	{
		// if (_mustSendAcks)
		bool L_0 = __this->____mustSendAcks_11;
		if (!L_0)
		{
			goto IL_003d;
		}
	}
	{
		// _mustSendAcks = false;
		__this->____mustSendAcks_11 = (bool)0;
		// lock(_outgoingAcks)
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_1 = __this->____outgoingAcks_3;
		V_2 = L_1;
		V_3 = (bool)0;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_0033:
			{// begin finally (depth: 1)
				{
					bool L_2 = V_3;
					if (!L_2)
					{
						goto IL_003c;
					}
				}
				{
					NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_3 = V_2;
					Monitor_Exit_m25A154960F91391E10E4CDA245ECDF4BA94D56A9(L_3, NULL);
				}

IL_003c:
				{
					return;
				}
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_4 = V_2;
			Monitor_Enter_m00506757392936AA62DBE2C5FFBEE69EE920C4D4(L_4, (&V_3), NULL);
			// Peer.SendUserData(_outgoingAcks);
			NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_5 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
			NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_6 = __this->____outgoingAcks_3;
			NullCheck(L_5);
			NetPeer_SendUserData_mDD3D17B669432BDAE9F54A7A7959A369943D4951(L_5, L_6, NULL);
			goto IL_003d;
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_003d:
	{
		// long currentTime = DateTime.UtcNow.Ticks;
		il2cpp_codegen_runtime_class_init_inline(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_7;
		L_7 = DateTime_get_UtcNow_m5D776FFEBC81592B361E4C7AF373297C5DFB46FD(NULL);
		V_4 = L_7;
		int64_t L_8;
		L_8 = DateTime_get_Ticks_mC2CF04ED0EAB425C72C2532FFC5743777F3C93A6((&V_4), NULL);
		V_0 = L_8;
		// bool hasPendingPackets = false;
		V_1 = (bool)0;
		// lock (_pendingPackets)
		PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_9 = __this->____pendingPackets_4;
		V_5 = L_9;
		V_3 = (bool)0;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_0156:
			{// begin finally (depth: 1)
				{
					bool L_10 = V_3;
					if (!L_10)
					{
						goto IL_0160;
					}
				}
				{
					PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_11 = V_5;
					Monitor_Exit_m25A154960F91391E10E4CDA245ECDF4BA94D56A9((RuntimeObject*)L_11, NULL);
				}

IL_0160:
				{
					return;
				}
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			{
				PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_12 = V_5;
				Monitor_Enter_m00506757392936AA62DBE2C5FFBEE69EE920C4D4((RuntimeObject*)L_12, (&V_3), NULL);
				// lock (OutgoingQueue)
				Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_13 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___OutgoingQueue_1;
				V_6 = L_13;
				V_7 = (bool)0;
			}
			{
				auto __finallyBlock = il2cpp::utils::Finally([&]
				{

FINALLY_0100_1:
					{// begin finally (depth: 2)
						{
							bool L_14 = V_7;
							if (!L_14)
							{
								goto IL_010b_1;
							}
						}
						{
							Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_15 = V_6;
							Monitor_Exit_m25A154960F91391E10E4CDA245ECDF4BA94D56A9(L_15, NULL);
						}

IL_010b_1:
						{
							return;
						}
					}// end finally (depth: 2)
				});
				try
				{// begin try (depth: 2)
					{
						Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_16 = V_6;
						Monitor_Enter_m00506757392936AA62DBE2C5FFBEE69EE920C4D4(L_16, (&V_7), NULL);
						goto IL_00ed_2;
					}

IL_0077_2:
					{
						// int relate = NetUtils.RelativeSequenceNumber(_localSeqence, _localWindowStart);
						int32_t L_17 = __this->____localSeqence_7;
						int32_t L_18 = __this->____localWindowStart_9;
						il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
						int32_t L_19;
						L_19 = NetUtils_RelativeSequenceNumber_mCA9FAA443395636279506E0E0F9C8D6905935D49(L_17, L_18, NULL);
						// if (relate >= _windowSize)
						int32_t L_20 = __this->____windowSize_14;
						if ((((int32_t)L_19) < ((int32_t)L_20)))
						{
							goto IL_0092_2;
						}
					}
					{
						// break;
						goto IL_010c_1;
					}

IL_0092_2:
					{
						// var netPacket = OutgoingQueue.Dequeue();
						Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_21 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___OutgoingQueue_1;
						NullCheck(L_21);
						NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_22;
						L_22 = Queue_1_Dequeue_m7A34883DDDA022398188F8BC0D48204E767A9230(L_21, Queue_1_Dequeue_m7A34883DDDA022398188F8BC0D48204E767A9230_RuntimeMethod_var);
						V_8 = L_22;
						// netPacket.Sequence = (ushort) _localSeqence;
						NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_23 = V_8;
						int32_t L_24 = __this->____localSeqence_7;
						NullCheck(L_23);
						NetPacket_set_Sequence_m5849CD30F14F09CBB8541CF80CF6091F6409D9CB(L_23, (uint16_t)((int32_t)(uint16_t)L_24), NULL);
						// netPacket.ChannelId = _id;
						NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_25 = V_8;
						uint8_t L_26 = __this->____id_16;
						NullCheck(L_25);
						NetPacket_set_ChannelId_mF020D3EEF06D9CE0344D731F2E13CE41DA4395CB(L_25, L_26, NULL);
						// _pendingPackets[_localSeqence % _windowSize].Init(netPacket);
						PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_27 = __this->____pendingPackets_4;
						int32_t L_28 = __this->____localSeqence_7;
						int32_t L_29 = __this->____windowSize_14;
						NullCheck(L_27);
						NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_30 = V_8;
						PendingPacket_Init_m81B1EEE319B344975B7C1CD2AF155266ABAAD762(((L_27)->GetAddressAt(static_cast<il2cpp_array_size_t>(((int32_t)(L_28%L_29))))), L_30, NULL);
						// _localSeqence = (_localSeqence + 1) % NetConstants.MaxSequence;
						int32_t L_31 = __this->____localSeqence_7;
						__this->____localSeqence_7 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_31, 1))%((int32_t)32768)));
					}

IL_00ed_2:
					{
						// while (OutgoingQueue.Count > 0)
						Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_32 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___OutgoingQueue_1;
						NullCheck(L_32);
						int32_t L_33;
						L_33 = Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_inline(L_32, Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_RuntimeMethod_var);
						if ((((int32_t)L_33) > ((int32_t)0)))
						{
							goto IL_0077_2;
						}
					}
					{
						// }
						goto IL_010c_1;
					}
				}// end try (depth: 2)
				catch(Il2CppExceptionWrapper& e)
				{
					__finallyBlock.StoreException(e.ex);
				}
			}

IL_010c_1:
			{
				// for (int pendingSeq = _localWindowStart; pendingSeq != _localSeqence; pendingSeq = (pendingSeq + 1) % NetConstants.MaxSequence)
				int32_t L_34 = __this->____localWindowStart_9;
				V_9 = L_34;
				goto IL_014a_1;
			}

IL_0116_1:
			{
				// _pendingPackets[pendingSeq % _windowSize].TrySend(currentTime, Peer, out hasPacket);
				PendingPacketU5BU5D_t0F0D1AFCA3AEB2BDE171FBF8CA303FA77ACCE003* L_35 = __this->____pendingPackets_4;
				int32_t L_36 = V_9;
				int32_t L_37 = __this->____windowSize_14;
				NullCheck(L_35);
				int64_t L_38 = V_0;
				NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_39 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
				PendingPacket_TrySend_mA021BAF5368005E4EF0491B65374BF73A9BF81A6(((L_35)->GetAddressAt(static_cast<il2cpp_array_size_t>(((int32_t)(L_36%L_37))))), L_38, L_39, (&V_10), NULL);
				// if (hasPacket)
				bool L_40 = V_10;
				if (!L_40)
				{
					goto IL_013e_1;
				}
			}
			{
				// hasPendingPackets = true;
				V_1 = (bool)1;
			}

IL_013e_1:
			{
				// for (int pendingSeq = _localWindowStart; pendingSeq != _localSeqence; pendingSeq = (pendingSeq + 1) % NetConstants.MaxSequence)
				int32_t L_41 = V_9;
				V_9 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_41, 1))%((int32_t)32768)));
			}

IL_014a_1:
			{
				// for (int pendingSeq = _localWindowStart; pendingSeq != _localSeqence; pendingSeq = (pendingSeq + 1) % NetConstants.MaxSequence)
				int32_t L_42 = V_9;
				int32_t L_43 = __this->____localSeqence_7;
				if ((!(((uint32_t)L_42) == ((uint32_t)L_43))))
				{
					goto IL_0116_1;
				}
			}
			{
				// }
				goto IL_0161;
			}
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_0161:
	{
		// return hasPendingPackets || _mustSendAcks || OutgoingQueue.Count > 0;
		bool L_44 = V_1;
		if (L_44)
		{
			goto IL_017b;
		}
	}
	{
		bool L_45 = __this->____mustSendAcks_11;
		if (L_45)
		{
			goto IL_017b;
		}
	}
	{
		Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_46 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___OutgoingQueue_1;
		NullCheck(L_46);
		int32_t L_47;
		L_47 = Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_inline(L_46, Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_RuntimeMethod_var);
		return (bool)((((int32_t)L_47) > ((int32_t)0))? 1 : 0);
	}

IL_017b:
	{
		return (bool)1;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.ReliableChannel::ProcessPacket(FlyingWormConsole3.LiteNetLib.NetPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ReliableChannel_ProcessPacket_mCB0DC24D2DCDA7C3044BCC5FD36128657FA63FAC (ReliableChannel_tCF02F710AA06E981A959C4528BD13D2ED96B4014* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	int32_t V_4 = 0;
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* V_5 = NULL;
	bool V_6 = false;
	int32_t V_7 = 0;
	bool V_8 = false;
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* V_9 = NULL;
	{
		// if (packet.Property == PacketProperty.Ack)
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_0 = ___packet0;
		NullCheck(L_0);
		uint8_t L_1;
		L_1 = NetPacket_get_Property_m7C25C6BE2668D9B1B39F462ACDEBA56ADD8D7252(L_0, NULL);
		if ((!(((uint32_t)L_1) == ((uint32_t)2))))
		{
			goto IL_0012;
		}
	}
	{
		// ProcessAck(packet);
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_2 = ___packet0;
		ReliableChannel_ProcessAck_m7C2322827BF50314E9D02C719195990347900E21(__this, L_2, NULL);
		// return false;
		return (bool)0;
	}

IL_0012:
	{
		// int seq = packet.Sequence;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_3 = ___packet0;
		NullCheck(L_3);
		uint16_t L_4;
		L_4 = NetPacket_get_Sequence_m2388D004EF4D404ED0C3FB4DA95CA2E56C80E4F9(L_3, NULL);
		V_0 = L_4;
		// if (seq >= NetConstants.MaxSequence)
		int32_t L_5 = V_0;
		if ((((int32_t)L_5) < ((int32_t)((int32_t)32768))))
		{
			goto IL_0023;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_0023:
	{
		// int relate = NetUtils.RelativeSequenceNumber(seq, _remoteWindowStart);
		int32_t L_6 = V_0;
		int32_t L_7 = __this->____remoteWindowStart_10;
		il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		int32_t L_8;
		L_8 = NetUtils_RelativeSequenceNumber_mCA9FAA443395636279506E0E0F9C8D6905935D49(L_6, L_7, NULL);
		V_1 = L_8;
		// int relateSeq = NetUtils.RelativeSequenceNumber(seq, _remoteSequence);
		int32_t L_9 = V_0;
		int32_t L_10 = __this->____remoteSequence_8;
		int32_t L_11;
		L_11 = NetUtils_RelativeSequenceNumber_mCA9FAA443395636279506E0E0F9C8D6905935D49(L_9, L_10, NULL);
		// if (relateSeq > _windowSize)
		int32_t L_12 = __this->____windowSize_14;
		if ((((int32_t)L_11) <= ((int32_t)L_12)))
		{
			goto IL_0046;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_0046:
	{
		// if (relate < 0)
		int32_t L_13 = V_1;
		if ((((int32_t)L_13) >= ((int32_t)0)))
		{
			goto IL_004c;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_004c:
	{
		// if (relate >= _windowSize * 2)
		int32_t L_14 = V_1;
		int32_t L_15 = __this->____windowSize_14;
		if ((((int32_t)L_14) < ((int32_t)((int32_t)il2cpp_codegen_multiply(L_15, 2)))))
		{
			goto IL_0059;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_0059:
	{
		// lock (_outgoingAcks)
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_16 = __this->____outgoingAcks_3;
		V_5 = L_16;
		V_6 = (bool)0;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_014f:
			{// begin finally (depth: 1)
				{
					bool L_17 = V_6;
					if (!L_17)
					{
						goto IL_015a;
					}
				}
				{
					NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_18 = V_5;
					Monitor_Exit_m25A154960F91391E10E4CDA245ECDF4BA94D56A9(L_18, NULL);
				}

IL_015a:
				{
					return;
				}
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			{
				NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_19 = V_5;
				Monitor_Enter_m00506757392936AA62DBE2C5FFBEE69EE920C4D4(L_19, (&V_6), NULL);
				// if (relate >= _windowSize)
				int32_t L_20 = V_1;
				int32_t L_21 = __this->____windowSize_14;
				if ((((int32_t)L_20) < ((int32_t)L_21)))
				{
					goto IL_00f5_1;
				}
			}
			{
				// int newWindowStart = (_remoteWindowStart + relate - _windowSize + 1) % NetConstants.MaxSequence;
				int32_t L_22 = __this->____remoteWindowStart_10;
				int32_t L_23 = V_1;
				int32_t L_24 = __this->____windowSize_14;
				V_7 = ((int32_t)(((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_subtract(((int32_t)il2cpp_codegen_add(L_22, L_23)), L_24)), 1))%((int32_t)32768)));
				// _outgoingAcks.Sequence = (ushort) newWindowStart;
				NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_25 = __this->____outgoingAcks_3;
				int32_t L_26 = V_7;
				NullCheck(L_25);
				NetPacket_set_Sequence_m5849CD30F14F09CBB8541CF80CF6091F6409D9CB(L_25, (uint16_t)((int32_t)(uint16_t)L_26), NULL);
				goto IL_00eb_1;
			}

IL_009f_1:
			{
				// ackIdx = _remoteWindowStart % _windowSize;
				int32_t L_27 = __this->____remoteWindowStart_10;
				int32_t L_28 = __this->____windowSize_14;
				V_2 = ((int32_t)(L_27%L_28));
				// ackByte = NetConstants.ChanneledHeaderSize + ackIdx / BitsInByte;
				int32_t L_29 = V_2;
				V_3 = ((int32_t)il2cpp_codegen_add(4, ((int32_t)(L_29/8))));
				// ackBit = ackIdx % BitsInByte;
				int32_t L_30 = V_2;
				V_4 = ((int32_t)(L_30%8));
				// _outgoingAcks.RawData[ackByte] &= (byte) ~(1 << ackBit);
				NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_31 = __this->____outgoingAcks_3;
				NullCheck(L_31);
				ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_32 = L_31->___RawData_2;
				int32_t L_33 = V_3;
				NullCheck(L_32);
				uint8_t* L_34 = ((L_32)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_33)));
				int32_t L_35 = *((uint8_t*)L_34);
				int32_t L_36 = V_4;
				*((int8_t*)L_34) = (int8_t)((int32_t)(uint8_t)((int32_t)(L_35&((int32_t)(uint8_t)((~((int32_t)(1<<((int32_t)(L_36&((int32_t)31)))))))))));
				// _remoteWindowStart = (_remoteWindowStart + 1) % NetConstants.MaxSequence;
				int32_t L_37 = __this->____remoteWindowStart_10;
				__this->____remoteWindowStart_10 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_37, 1))%((int32_t)32768)));
			}

IL_00eb_1:
			{
				// while (_remoteWindowStart != newWindowStart)
				int32_t L_38 = __this->____remoteWindowStart_10;
				int32_t L_39 = V_7;
				if ((!(((uint32_t)L_38) == ((uint32_t)L_39))))
				{
					goto IL_009f_1;
				}
			}

IL_00f5_1:
			{
				// _mustSendAcks = true;
				__this->____mustSendAcks_11 = (bool)1;
				// ackIdx = seq % _windowSize;
				int32_t L_40 = V_0;
				int32_t L_41 = __this->____windowSize_14;
				V_2 = ((int32_t)(L_40%L_41));
				// ackByte = NetConstants.ChanneledHeaderSize + ackIdx / BitsInByte;
				int32_t L_42 = V_2;
				V_3 = ((int32_t)il2cpp_codegen_add(4, ((int32_t)(L_42/8))));
				// ackBit = ackIdx % BitsInByte;
				int32_t L_43 = V_2;
				V_4 = ((int32_t)(L_43%8));
				// if ((_outgoingAcks.RawData[ackByte] & (1 << ackBit)) != 0)
				NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_44 = __this->____outgoingAcks_3;
				NullCheck(L_44);
				ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_45 = L_44->___RawData_2;
				int32_t L_46 = V_3;
				NullCheck(L_45);
				int32_t L_47 = L_46;
				uint8_t L_48 = (L_45)->GetAt(static_cast<il2cpp_array_size_t>(L_47));
				int32_t L_49 = V_4;
				if (!((int32_t)((int32_t)L_48&((int32_t)(1<<((int32_t)(L_49&((int32_t)31))))))))
				{
					goto IL_012f_1;
				}
			}
			{
				// return false;
				V_8 = (bool)0;
				goto IL_0268;
			}

IL_012f_1:
			{
				// _outgoingAcks.RawData[ackByte] |= (byte) (1 << ackBit);
				NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_50 = __this->____outgoingAcks_3;
				NullCheck(L_50);
				ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_51 = L_50->___RawData_2;
				int32_t L_52 = V_3;
				NullCheck(L_51);
				uint8_t* L_53 = ((L_51)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_52)));
				int32_t L_54 = *((uint8_t*)L_53);
				int32_t L_55 = V_4;
				*((int8_t*)L_53) = (int8_t)((int32_t)(uint8_t)((int32_t)(L_54|((int32_t)(uint8_t)((int32_t)(1<<((int32_t)(L_55&((int32_t)31)))))))));
				// }
				goto IL_015b;
			}
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_015b:
	{
		// AddToPeerChannelSendQueue();
		BaseChannel_AddToPeerChannelSendQueue_mB2D37C382AD242C4D11C3A82C6ECF316B55BE28F(__this, NULL);
		// if (seq == _remoteSequence)
		int32_t L_56 = V_0;
		int32_t L_57 = __this->____remoteSequence_8;
		if ((!(((uint32_t)L_56) == ((uint32_t)L_57))))
		{
			goto IL_0238;
		}
	}
	{
		// Peer.AddReliablePacket(_deliveryMethod, packet);
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_58 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
		uint8_t L_59 = __this->____deliveryMethod_12;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_60 = ___packet0;
		NullCheck(L_58);
		NetPeer_AddReliablePacket_m2DBE9508AE12C58F5559AB9D55B31E62A5AA85FE(L_58, L_59, L_60, NULL);
		// _remoteSequence = (_remoteSequence + 1) % NetConstants.MaxSequence;
		int32_t L_61 = __this->____remoteSequence_8;
		__this->____remoteSequence_8 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_61, 1))%((int32_t)32768)));
		// if (_ordered)
		bool L_62 = __this->____ordered_13;
		if (!L_62)
		{
			goto IL_0220;
		}
	}
	{
		goto IL_01dc;
	}

IL_01a0:
	{
		// _receivedPackets[_remoteSequence % _windowSize] = null;
		NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F* L_63 = __this->____receivedPackets_5;
		int32_t L_64 = __this->____remoteSequence_8;
		int32_t L_65 = __this->____windowSize_14;
		NullCheck(L_63);
		ArrayElementTypeCheck (L_63, NULL);
		(L_63)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)(L_64%L_65))), (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED*)NULL);
		// Peer.AddReliablePacket(_deliveryMethod, p);
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_66 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
		uint8_t L_67 = __this->____deliveryMethod_12;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_68 = V_9;
		NullCheck(L_66);
		NetPeer_AddReliablePacket_m2DBE9508AE12C58F5559AB9D55B31E62A5AA85FE(L_66, L_67, L_68, NULL);
		// _remoteSequence = (_remoteSequence + 1) % NetConstants.MaxSequence;
		int32_t L_69 = __this->____remoteSequence_8;
		__this->____remoteSequence_8 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_69, 1))%((int32_t)32768)));
	}

IL_01dc:
	{
		// while ((p = _receivedPackets[_remoteSequence % _windowSize]) != null)
		NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F* L_70 = __this->____receivedPackets_5;
		int32_t L_71 = __this->____remoteSequence_8;
		int32_t L_72 = __this->____windowSize_14;
		NullCheck(L_70);
		int32_t L_73 = ((int32_t)(L_71%L_72));
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_74 = (L_70)->GetAt(static_cast<il2cpp_array_size_t>(L_73));
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_75 = L_74;
		V_9 = L_75;
		if (L_75)
		{
			goto IL_01a0;
		}
	}
	{
		goto IL_0236;
	}

IL_01f7:
	{
		// _earlyReceived[_remoteSequence % _windowSize] = false;
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_76 = __this->____earlyReceived_6;
		int32_t L_77 = __this->____remoteSequence_8;
		int32_t L_78 = __this->____windowSize_14;
		NullCheck(L_76);
		(L_76)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)(L_77%L_78))), (bool)0);
		// _remoteSequence = (_remoteSequence + 1) % NetConstants.MaxSequence;
		int32_t L_79 = __this->____remoteSequence_8;
		__this->____remoteSequence_8 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_79, 1))%((int32_t)32768)));
	}

IL_0220:
	{
		// while (_earlyReceived[_remoteSequence % _windowSize])
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_80 = __this->____earlyReceived_6;
		int32_t L_81 = __this->____remoteSequence_8;
		int32_t L_82 = __this->____windowSize_14;
		NullCheck(L_80);
		int32_t L_83 = ((int32_t)(L_81%L_82));
		uint8_t L_84 = (uint8_t)(L_80)->GetAt(static_cast<il2cpp_array_size_t>(L_83));
		if (L_84)
		{
			goto IL_01f7;
		}
	}

IL_0236:
	{
		// return true;
		return (bool)1;
	}

IL_0238:
	{
		// if (_ordered)
		bool L_85 = __this->____ordered_13;
		if (!L_85)
		{
			goto IL_024b;
		}
	}
	{
		// _receivedPackets[ackIdx] = packet;
		NetPacketU5BU5D_t2EC3901D949F32C8D448B989F50F8A6ACA408B6F* L_86 = __this->____receivedPackets_5;
		int32_t L_87 = V_2;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_88 = ___packet0;
		NullCheck(L_86);
		ArrayElementTypeCheck (L_86, L_88);
		(L_86)->SetAt(static_cast<il2cpp_array_size_t>(L_87), (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED*)L_88);
		goto IL_0266;
	}

IL_024b:
	{
		// _earlyReceived[ackIdx] = true;
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_89 = __this->____earlyReceived_6;
		int32_t L_90 = V_2;
		NullCheck(L_89);
		(L_89)->SetAt(static_cast<il2cpp_array_size_t>(L_90), (bool)1);
		// Peer.AddReliablePacket(_deliveryMethod, packet);
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_91 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
		uint8_t L_92 = __this->____deliveryMethod_12;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_93 = ___packet0;
		NullCheck(L_91);
		NetPeer_AddReliablePacket_m2DBE9508AE12C58F5559AB9D55B31E62A5AA85FE(L_91, L_92, L_93, NULL);
	}

IL_0266:
	{
		// return true;
		return (bool)1;
	}

IL_0268:
	{
		// }
		bool L_94 = V_8;
		return L_94;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Conversion methods for marshalling of: FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket
IL2CPP_EXTERN_C void PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshal_pinvoke(const PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6& unmarshaled, PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshaled_pinvoke& marshaled)
{
	Exception_t* ____packet_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '_packet' of type 'PendingPacket': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(____packet_0Exception, NULL);
}
IL2CPP_EXTERN_C void PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshal_pinvoke_back(const PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshaled_pinvoke& marshaled, PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6& unmarshaled)
{
	Exception_t* ____packet_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '_packet' of type 'PendingPacket': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(____packet_0Exception, NULL);
}
// Conversion method for clean up from marshalling of: FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket
IL2CPP_EXTERN_C void PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshal_pinvoke_cleanup(PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshaled_pinvoke& marshaled)
{
}
// Conversion methods for marshalling of: FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket
IL2CPP_EXTERN_C void PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshal_com(const PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6& unmarshaled, PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshaled_com& marshaled)
{
	Exception_t* ____packet_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '_packet' of type 'PendingPacket': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(____packet_0Exception, NULL);
}
IL2CPP_EXTERN_C void PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshal_com_back(const PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshaled_com& marshaled, PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6& unmarshaled)
{
	Exception_t* ____packet_0Exception = il2cpp_codegen_get_marshal_directive_exception("Cannot marshal field '_packet' of type 'PendingPacket': Reference type field marshaling is not supported.");
	IL2CPP_RAISE_MANAGED_EXCEPTION(____packet_0Exception, NULL);
}
// Conversion method for clean up from marshalling of: FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket
IL2CPP_EXTERN_C void PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshal_com_cleanup(PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6_marshaled_com& marshaled)
{
}
// System.String FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket::ToString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* PendingPacket_ToString_mBD46DB34274B209C3C3E26B4EF268425C023B179 (PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral32189949CB1CA4A6EBB1A643EBE2DB69713D5407);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	{
		// return _packet == null ? "Empty" : _packet.Sequence.ToString();
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_0 = __this->____packet_0;
		if (!L_0)
		{
			goto IL_001c;
		}
	}
	{
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_1 = __this->____packet_0;
		NullCheck(L_1);
		uint16_t L_2;
		L_2 = NetPacket_get_Sequence_m2388D004EF4D404ED0C3FB4DA95CA2E56C80E4F9(L_1, NULL);
		V_0 = L_2;
		String_t* L_3;
		L_3 = UInt16_ToString_m57629B7E74D92A54414073D5C27D6827C93A4DD5((&V_0), NULL);
		return L_3;
	}

IL_001c:
	{
		return _stringLiteral32189949CB1CA4A6EBB1A643EBE2DB69713D5407;
	}
}
IL2CPP_EXTERN_C  String_t* PendingPacket_ToString_mBD46DB34274B209C3C3E26B4EF268425C023B179_AdjustorThunk (RuntimeObject* __this, const RuntimeMethod* method)
{
	PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6*>(__this + _offset);
	String_t* _returnValue;
	_returnValue = PendingPacket_ToString_mBD46DB34274B209C3C3E26B4EF268425C023B179(_thisAdjusted, method);
	return _returnValue;
}
// System.Void FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket::Init(FlyingWormConsole3.LiteNetLib.NetPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PendingPacket_Init_m81B1EEE319B344975B7C1CD2AF155266ABAAD762 (PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, const RuntimeMethod* method) 
{
	{
		// _packet = packet;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_0 = ___packet0;
		__this->____packet_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____packet_0), (void*)L_0);
		// _isSent = false;
		__this->____isSent_2 = (bool)0;
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void PendingPacket_Init_m81B1EEE319B344975B7C1CD2AF155266ABAAD762_AdjustorThunk (RuntimeObject* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, const RuntimeMethod* method)
{
	PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6*>(__this + _offset);
	PendingPacket_Init_m81B1EEE319B344975B7C1CD2AF155266ABAAD762(_thisAdjusted, ___packet0, method);
}
// System.Void FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket::TrySend(System.Int64,FlyingWormConsole3.LiteNetLib.NetPeer,System.Boolean&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PendingPacket_TrySend_mA021BAF5368005E4EF0491B65374BF73A9BF81A6 (PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* __this, int64_t ___currentTime0, NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___peer1, bool* ___hasPacket2, const RuntimeMethod* method) 
{
	double V_0 = 0.0;
	{
		// if (_packet == null)
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_0 = __this->____packet_0;
		if (L_0)
		{
			goto IL_000c;
		}
	}
	{
		// hasPacket = false;
		bool* L_1 = ___hasPacket2;
		*((int8_t*)L_1) = (int8_t)0;
		// return;
		return;
	}

IL_000c:
	{
		// hasPacket = true;
		bool* L_2 = ___hasPacket2;
		*((int8_t*)L_2) = (int8_t)1;
		// if (_isSent) //check send time
		bool L_3 = __this->____isSent_2;
		if (!L_3)
		{
			goto IL_0035;
		}
	}
	{
		// double resendDelay = peer.ResendDelay * TimeSpan.TicksPerMillisecond;
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_4 = ___peer1;
		NullCheck(L_4);
		double L_5;
		L_5 = NetPeer_get_ResendDelay_m6D44FEF7BA647CA1047274DB58A7B9A2FDC64A12_inline(L_4, NULL);
		V_0 = ((double)il2cpp_codegen_multiply(L_5, (10000.0)));
		// double packetHoldTime = currentTime - _timeStamp;
		int64_t L_6 = ___currentTime0;
		int64_t L_7 = __this->____timeStamp_1;
		// if (packetHoldTime < resendDelay)
		double L_8 = V_0;
		if ((!(((double)((double)((int64_t)il2cpp_codegen_subtract(L_6, L_7)))) < ((double)L_8))))
		{
			goto IL_0035;
		}
	}
	{
		// return;
		return;
	}

IL_0035:
	{
		// _timeStamp = currentTime;
		int64_t L_9 = ___currentTime0;
		__this->____timeStamp_1 = L_9;
		// _isSent = true;
		__this->____isSent_2 = (bool)1;
		// peer.SendUserData(_packet);
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_10 = ___peer1;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_11 = __this->____packet_0;
		NullCheck(L_10);
		NetPeer_SendUserData_mDD3D17B669432BDAE9F54A7A7959A369943D4951(L_10, L_11, NULL);
		// }
		return;
	}
}
IL2CPP_EXTERN_C  void PendingPacket_TrySend_mA021BAF5368005E4EF0491B65374BF73A9BF81A6_AdjustorThunk (RuntimeObject* __this, int64_t ___currentTime0, NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___peer1, bool* ___hasPacket2, const RuntimeMethod* method)
{
	PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6*>(__this + _offset);
	PendingPacket_TrySend_mA021BAF5368005E4EF0491B65374BF73A9BF81A6(_thisAdjusted, ___currentTime0, ___peer1, ___hasPacket2, method);
}
// System.Boolean FlyingWormConsole3.LiteNetLib.ReliableChannel/PendingPacket::Clear(FlyingWormConsole3.LiteNetLib.NetPeer)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PendingPacket_Clear_m6C98ACC437234C8DC24341538EE5505B6824E87A (PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* __this, NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___peer0, const RuntimeMethod* method) 
{
	{
		// if (_packet != null)
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_0 = __this->____packet_0;
		if (!L_0)
		{
			goto IL_001d;
		}
	}
	{
		// peer.RecycleAndDeliver(_packet);
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_1 = ___peer0;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_2 = __this->____packet_0;
		NullCheck(L_1);
		NetPeer_RecycleAndDeliver_m15E0F1F670435B7AFBE8BFC2203C1B383454A28E(L_1, L_2, NULL);
		// _packet = null;
		__this->____packet_0 = (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____packet_0), (void*)(NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED*)NULL);
		// return true;
		return (bool)1;
	}

IL_001d:
	{
		// return false;
		return (bool)0;
	}
}
IL2CPP_EXTERN_C  bool PendingPacket_Clear_m6C98ACC437234C8DC24341538EE5505B6824E87A_AdjustorThunk (RuntimeObject* __this, NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___peer0, const RuntimeMethod* method)
{
	PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6* _thisAdjusted;
	int32_t _offset = 1;
	_thisAdjusted = reinterpret_cast<PendingPacket_t47AAA567F64D34C8849BA885D90093FE2C91DBB6*>(__this + _offset);
	bool _returnValue;
	_returnValue = PendingPacket_Clear_m6C98ACC437234C8DC24341538EE5505B6824E87A(_thisAdjusted, ___peer0, method);
	return _returnValue;
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.SequencedChannel::.ctor(FlyingWormConsole3.LiteNetLib.NetPeer,System.Boolean,System.Byte)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SequencedChannel__ctor_m08C9B01DFD86DCE437D8CB232C94EDBD53176DF5 (SequencedChannel_t33A970479102C6CA1094ABFF02F6ACB1E1DC3ED1* __this, NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* ___peer0, bool ___reliable1, uint8_t ___id2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public SequencedChannel(NetPeer peer, bool reliable, byte id) : base(peer)
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_0 = ___peer0;
		BaseChannel__ctor_m6EC2E55242CB43181FED32EF1A74C51ACAFACAD6(__this, L_0, NULL);
		// _id = id;
		uint8_t L_1 = ___id2;
		__this->____id_9 = L_1;
		// _reliable = reliable;
		bool L_2 = ___reliable1;
		__this->____reliable_5 = L_2;
		// if (_reliable)
		bool L_3 = __this->____reliable_5;
		if (!L_3)
		{
			goto IL_0031;
		}
	}
	{
		// _ackPacket = new NetPacket(PacketProperty.Ack, 0) {ChannelId = id};
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_4 = (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED*)il2cpp_codegen_object_new(NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED_il2cpp_TypeInfo_var);
		NullCheck(L_4);
		NetPacket__ctor_m64EDA1B3C197027137887A26852E9E5490DEA8C8(L_4, 2, 0, NULL);
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_5 = L_4;
		uint8_t L_6 = ___id2;
		NullCheck(L_5);
		NetPacket_set_ChannelId_mF020D3EEF06D9CE0344D731F2E13CE41DA4395CB(L_5, L_6, NULL);
		__this->____ackPacket_7 = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____ackPacket_7), (void*)L_5);
	}

IL_0031:
	{
		// }
		return;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.SequencedChannel::SendNextPackets()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool SequencedChannel_SendNextPackets_m5BC141B30E71909EAC2E2545DB660729DE48DC4C (SequencedChannel_t33A970479102C6CA1094ABFF02F6ACB1E1DC3ED1* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Queue_1_Dequeue_m7A34883DDDA022398188F8BC0D48204E767A9230_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	int64_t V_0 = 0;
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D V_1;
	memset((&V_1), 0, sizeof(V_1));
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* V_2 = NULL;
	Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* V_3 = NULL;
	bool V_4 = false;
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* V_5 = NULL;
	{
		// if (_reliable && OutgoingQueue.Count == 0)
		bool L_0 = __this->____reliable_5;
		if (!L_0)
		{
			goto IL_006b;
		}
	}
	{
		Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_1 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___OutgoingQueue_1;
		NullCheck(L_1);
		int32_t L_2;
		L_2 = Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_inline(L_1, Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_RuntimeMethod_var);
		if (L_2)
		{
			goto IL_006b;
		}
	}
	{
		// long currentTime = DateTime.UtcNow.Ticks;
		il2cpp_codegen_runtime_class_init_inline(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_3;
		L_3 = DateTime_get_UtcNow_m5D776FFEBC81592B361E4C7AF373297C5DFB46FD(NULL);
		V_1 = L_3;
		int64_t L_4;
		L_4 = DateTime_get_Ticks_mC2CF04ED0EAB425C72C2532FFC5743777F3C93A6((&V_1), NULL);
		V_0 = L_4;
		// long packetHoldTime = currentTime - _lastPacketSendTime;
		int64_t L_5 = V_0;
		int64_t L_6 = __this->____lastPacketSendTime_10;
		// if (packetHoldTime >= Peer.ResendDelay * TimeSpan.TicksPerMillisecond)
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_7 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
		NullCheck(L_7);
		double L_8;
		L_8 = NetPeer_get_ResendDelay_m6D44FEF7BA647CA1047274DB58A7B9A2FDC64A12_inline(L_7, NULL);
		if ((!(((double)((double)((int64_t)il2cpp_codegen_subtract(L_5, L_6)))) >= ((double)((double)il2cpp_codegen_multiply(L_8, (10000.0)))))))
		{
			goto IL_0132;
		}
	}
	{
		// var packet = _lastPacket;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_9 = __this->____lastPacket_6;
		V_2 = L_9;
		// if (packet != null)
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_10 = V_2;
		if (!L_10)
		{
			goto IL_0132;
		}
	}
	{
		// _lastPacketSendTime = currentTime;
		int64_t L_11 = V_0;
		__this->____lastPacketSendTime_10 = L_11;
		// Peer.SendUserData(packet);
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_12 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_13 = V_2;
		NullCheck(L_12);
		NetPeer_SendUserData_mDD3D17B669432BDAE9F54A7A7959A369943D4951(L_12, L_13, NULL);
		goto IL_0132;
	}

IL_006b:
	{
		// lock (OutgoingQueue)
		Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_14 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___OutgoingQueue_1;
		V_3 = L_14;
		V_4 = (bool)0;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_0127:
			{// begin finally (depth: 1)
				{
					bool L_15 = V_4;
					if (!L_15)
					{
						goto IL_0131;
					}
				}
				{
					Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_16 = V_3;
					Monitor_Exit_m25A154960F91391E10E4CDA245ECDF4BA94D56A9(L_16, NULL);
				}

IL_0131:
				{
					return;
				}
			}// end finally (depth: 1)
		});
		try
		{// begin try (depth: 1)
			{
				Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_17 = V_3;
				Monitor_Enter_m00506757392936AA62DBE2C5FFBEE69EE920C4D4(L_17, (&V_4), NULL);
				goto IL_0114_1;
			}

IL_0082_1:
			{
				// NetPacket packet = OutgoingQueue.Dequeue();
				Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_18 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___OutgoingQueue_1;
				NullCheck(L_18);
				NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_19;
				L_19 = Queue_1_Dequeue_m7A34883DDDA022398188F8BC0D48204E767A9230(L_18, Queue_1_Dequeue_m7A34883DDDA022398188F8BC0D48204E767A9230_RuntimeMethod_var);
				V_5 = L_19;
				// _localSequence = (_localSequence + 1) % NetConstants.MaxSequence;
				int32_t L_20 = __this->____localSequence_3;
				__this->____localSequence_3 = ((int32_t)(((int32_t)il2cpp_codegen_add(L_20, 1))%((int32_t)32768)));
				// packet.Sequence = (ushort)_localSequence;
				NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_21 = V_5;
				int32_t L_22 = __this->____localSequence_3;
				NullCheck(L_21);
				NetPacket_set_Sequence_m5849CD30F14F09CBB8541CF80CF6091F6409D9CB(L_21, (uint16_t)((int32_t)(uint16_t)L_22), NULL);
				// packet.ChannelId = _id;
				NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_23 = V_5;
				uint8_t L_24 = __this->____id_9;
				NullCheck(L_23);
				NetPacket_set_ChannelId_mF020D3EEF06D9CE0344D731F2E13CE41DA4395CB(L_23, L_24, NULL);
				// Peer.SendUserData(packet);
				NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_25 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
				NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_26 = V_5;
				NullCheck(L_25);
				NetPeer_SendUserData_mDD3D17B669432BDAE9F54A7A7959A369943D4951(L_25, L_26, NULL);
				// if (_reliable && OutgoingQueue.Count == 0)
				bool L_27 = __this->____reliable_5;
				if (!L_27)
				{
					goto IL_00fd_1;
				}
			}
			{
				Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_28 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___OutgoingQueue_1;
				NullCheck(L_28);
				int32_t L_29;
				L_29 = Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_inline(L_28, Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_RuntimeMethod_var);
				if (L_29)
				{
					goto IL_00fd_1;
				}
			}
			{
				// _lastPacketSendTime = DateTime.UtcNow.Ticks;
				il2cpp_codegen_runtime_class_init_inline(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
				DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_30;
				L_30 = DateTime_get_UtcNow_m5D776FFEBC81592B361E4C7AF373297C5DFB46FD(NULL);
				V_1 = L_30;
				int64_t L_31;
				L_31 = DateTime_get_Ticks_mC2CF04ED0EAB425C72C2532FFC5743777F3C93A6((&V_1), NULL);
				__this->____lastPacketSendTime_10 = L_31;
				// _lastPacket = packet;
				NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_32 = V_5;
				__this->____lastPacket_6 = L_32;
				Il2CppCodeGenWriteBarrier((void**)(&__this->____lastPacket_6), (void*)L_32);
				goto IL_0114_1;
			}

IL_00fd_1:
			{
				// Peer.NetManager.NetPacketPool.Recycle(packet);
				NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_33 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
				NullCheck(L_33);
				NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_34 = L_33->___NetManager_43;
				NullCheck(L_34);
				NetPacketPool_tECE1CA68CDADE3C4E45A5FBCA8B25CC30F62DBF3* L_35 = L_34->___NetPacketPool_22;
				NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_36 = V_5;
				NullCheck(L_35);
				NetPacketPool_Recycle_m872D8D50F3E68B326EEEA6F15E9762DD15FD7431(L_35, L_36, NULL);
			}

IL_0114_1:
			{
				// while (OutgoingQueue.Count > 0)
				Queue_1_tD0FA89D0DB3E9BE61C6263EF164E1599985CA52C* L_37 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___OutgoingQueue_1;
				NullCheck(L_37);
				int32_t L_38;
				L_38 = Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_inline(L_37, Queue_1_get_Count_mDE69AE9C171045459EAA5580BA3208BC85B6D170_RuntimeMethod_var);
				if ((((int32_t)L_38) > ((int32_t)0)))
				{
					goto IL_0082_1;
				}
			}
			{
				// }
				goto IL_0132;
			}
		}// end try (depth: 1)
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_0132:
	{
		// if (_reliable && _mustSendAck)
		bool L_39 = __this->____reliable_5;
		if (!L_39)
		{
			goto IL_016b;
		}
	}
	{
		bool L_40 = __this->____mustSendAck_8;
		if (!L_40)
		{
			goto IL_016b;
		}
	}
	{
		// _mustSendAck = false;
		__this->____mustSendAck_8 = (bool)0;
		// _ackPacket.Sequence = _remoteSequence;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_41 = __this->____ackPacket_7;
		uint16_t L_42 = __this->____remoteSequence_4;
		NullCheck(L_41);
		NetPacket_set_Sequence_m5849CD30F14F09CBB8541CF80CF6091F6409D9CB(L_41, L_42, NULL);
		// Peer.SendUserData(_ackPacket);
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_43 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_44 = __this->____ackPacket_7;
		NullCheck(L_43);
		NetPeer_SendUserData_mDD3D17B669432BDAE9F54A7A7959A369943D4951(L_43, L_44, NULL);
	}

IL_016b:
	{
		// return _lastPacket != null;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_45 = __this->____lastPacket_6;
		return (bool)((!(((RuntimeObject*)(NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED*)L_45) <= ((RuntimeObject*)(RuntimeObject*)NULL)))? 1 : 0);
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.SequencedChannel::ProcessPacket(FlyingWormConsole3.LiteNetLib.NetPacket)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool SequencedChannel_ProcessPacket_mFF36BB35DAEC3CC9087D18F1EBB8C7532334DF9D (SequencedChannel_t33A970479102C6CA1094ABFF02F6ACB1E1DC3ED1* __this, NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* ___packet0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	bool V_1 = false;
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* G_B14_0 = NULL;
	NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* G_B14_1 = NULL;
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* G_B13_0 = NULL;
	NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* G_B13_1 = NULL;
	int32_t G_B15_0 = 0;
	NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* G_B15_1 = NULL;
	NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* G_B15_2 = NULL;
	{
		// if (packet.IsFragmented)
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_0 = ___packet0;
		NullCheck(L_0);
		bool L_1;
		L_1 = NetPacket_get_IsFragmented_mB4ABDC6D0BB76F3FAFF9932559F177CAE2BA7D79(L_0, NULL);
		if (!L_1)
		{
			goto IL_000a;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_000a:
	{
		// if (packet.Property == PacketProperty.Ack)
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_2 = ___packet0;
		NullCheck(L_2);
		uint8_t L_3;
		L_3 = NetPacket_get_Property_m7C25C6BE2668D9B1B39F462ACDEBA56ADD8D7252(L_2, NULL);
		if ((!(((uint32_t)L_3) == ((uint32_t)2))))
		{
			goto IL_003f;
		}
	}
	{
		// if (_reliable && _lastPacket != null && packet.Sequence == _lastPacket.Sequence)
		bool L_4 = __this->____reliable_5;
		if (!L_4)
		{
			goto IL_003d;
		}
	}
	{
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_5 = __this->____lastPacket_6;
		if (!L_5)
		{
			goto IL_003d;
		}
	}
	{
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_6 = ___packet0;
		NullCheck(L_6);
		uint16_t L_7;
		L_7 = NetPacket_get_Sequence_m2388D004EF4D404ED0C3FB4DA95CA2E56C80E4F9(L_6, NULL);
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_8 = __this->____lastPacket_6;
		NullCheck(L_8);
		uint16_t L_9;
		L_9 = NetPacket_get_Sequence_m2388D004EF4D404ED0C3FB4DA95CA2E56C80E4F9(L_8, NULL);
		if ((!(((uint32_t)L_7) == ((uint32_t)L_9))))
		{
			goto IL_003d;
		}
	}
	{
		// _lastPacket = null;
		__this->____lastPacket_6 = (NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____lastPacket_6), (void*)(NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED*)NULL);
	}

IL_003d:
	{
		// return false;
		return (bool)0;
	}

IL_003f:
	{
		// int relative = NetUtils.RelativeSequenceNumber(packet.Sequence, _remoteSequence);
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_10 = ___packet0;
		NullCheck(L_10);
		uint16_t L_11;
		L_11 = NetPacket_get_Sequence_m2388D004EF4D404ED0C3FB4DA95CA2E56C80E4F9(L_10, NULL);
		uint16_t L_12 = __this->____remoteSequence_4;
		il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		int32_t L_13;
		L_13 = NetUtils_RelativeSequenceNumber_mCA9FAA443395636279506E0E0F9C8D6905935D49(L_11, L_12, NULL);
		V_0 = L_13;
		// bool packetProcessed = false;
		V_1 = (bool)0;
		// if (packet.Sequence < NetConstants.MaxSequence && relative > 0)
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_14 = ___packet0;
		NullCheck(L_14);
		uint16_t L_15;
		L_15 = NetPacket_get_Sequence_m2388D004EF4D404ED0C3FB4DA95CA2E56C80E4F9(L_14, NULL);
		if ((((int32_t)L_15) >= ((int32_t)((int32_t)32768))))
		{
			goto IL_00d5;
		}
	}
	{
		int32_t L_16 = V_0;
		if ((((int32_t)L_16) <= ((int32_t)0)))
		{
			goto IL_00d5;
		}
	}
	{
		// if (Peer.NetManager.EnableStatistics)
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_17 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
		NullCheck(L_17);
		NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_18 = L_17->___NetManager_43;
		NullCheck(L_18);
		bool L_19 = L_18->___EnableStatistics_41;
		if (!L_19)
		{
			goto IL_00a3;
		}
	}
	{
		// Peer.Statistics.AddPacketLoss(relative - 1);
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_20 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
		NullCheck(L_20);
		NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* L_21 = L_20->___Statistics_46;
		int32_t L_22 = V_0;
		NullCheck(L_21);
		NetStatistics_AddPacketLoss_mAA70198C7E49704F5821DE577543473AD6327039(L_21, ((int64_t)((int32_t)il2cpp_codegen_subtract(L_22, 1))), NULL);
		// Peer.NetManager.Statistics.AddPacketLoss(relative - 1);
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_23 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
		NullCheck(L_23);
		NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_24 = L_23->___NetManager_43;
		NullCheck(L_24);
		NetStatistics_t0F89C54F82D1BC1E7ADEA0B18DA8713FC2619C20* L_25 = L_24->___Statistics_40;
		int32_t L_26 = V_0;
		NullCheck(L_25);
		NetStatistics_AddPacketLoss_mAA70198C7E49704F5821DE577543473AD6327039(L_25, ((int64_t)((int32_t)il2cpp_codegen_subtract(L_26, 1))), NULL);
	}

IL_00a3:
	{
		// _remoteSequence = packet.Sequence;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_27 = ___packet0;
		NullCheck(L_27);
		uint16_t L_28;
		L_28 = NetPacket_get_Sequence_m2388D004EF4D404ED0C3FB4DA95CA2E56C80E4F9(L_27, NULL);
		__this->____remoteSequence_4 = L_28;
		// Peer.NetManager.CreateReceiveEvent(
		//     packet,
		//     _reliable ? DeliveryMethod.ReliableSequenced : DeliveryMethod.Sequenced,
		//     NetConstants.ChanneledHeaderSize,
		//     Peer);
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_29 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
		NullCheck(L_29);
		NetManager_t8B66EC65CAFC8455974B02C8945955F328277191* L_30 = L_29->___NetManager_43;
		NetPacket_tDFE5179A8EACA0E2DADD10A8C2FCA32BA4AF25ED* L_31 = ___packet0;
		bool L_32 = __this->____reliable_5;
		G_B13_0 = L_31;
		G_B13_1 = L_30;
		if (L_32)
		{
			G_B14_0 = L_31;
			G_B14_1 = L_30;
			goto IL_00c6;
		}
	}
	{
		G_B15_0 = 1;
		G_B15_1 = G_B13_0;
		G_B15_2 = G_B13_1;
		goto IL_00c7;
	}

IL_00c6:
	{
		G_B15_0 = 3;
		G_B15_1 = G_B14_0;
		G_B15_2 = G_B14_1;
	}

IL_00c7:
	{
		NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* L_33 = ((BaseChannel_tBA960129C96C1363FE07E08E630F95C4DE594215*)__this)->___Peer_0;
		NullCheck(G_B15_2);
		NetManager_CreateReceiveEvent_m7CEE7A198F953707702446BCD45F2913E855D095(G_B15_2, G_B15_1, G_B15_0, 4, L_33, NULL);
		// packetProcessed = true;
		V_1 = (bool)1;
	}

IL_00d5:
	{
		// if (_reliable)
		bool L_34 = __this->____reliable_5;
		if (!L_34)
		{
			goto IL_00ea;
		}
	}
	{
		// _mustSendAck = true;
		__this->____mustSendAck_8 = (bool)1;
		// AddToPeerChannelSendQueue();
		BaseChannel_AddToPeerChannelSendQueue_mB2D37C382AD242C4D11C3A82C6ECF316B55BE28F(__this, NULL);
	}

IL_00ea:
	{
		// return packetProcessed;
		bool L_35 = V_1;
		return L_35;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.Utils.CRC32C::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CRC32C__cctor_mBA8BFE64B4AEE422BD3E1E73C9B4E6DB100EF79B (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CRC32C__cctor_mBA8BFE64B4AEE422BD3E1E73C9B4E6DB100EF79B_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint32_t V_0 = 0;
	uint32_t V_1 = 0;
	int32_t V_2 = 0;
	int32_t V_3 = 0;
	uint32_t G_B6_0 = 0;
	{
		// Table = new uint[16 * 256];
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_0 = (UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA*)(UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA*)SZArrayNew(UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA_il2cpp_TypeInfo_var, (uint32_t)((int32_t)4096));
		((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2), (void*)L_0);
		// for (uint i = 0; i < 256; i++)
		V_0 = 0;
		goto IL_005a;
	}

IL_0013:
	{
		// uint res = i;
		uint32_t L_1 = V_0;
		V_1 = L_1;
		// for (int t = 0; t < 16; t++)
		V_2 = 0;
		goto IL_0051;
	}

IL_0019:
	{
		// for (int k = 0; k < 8; k++)
		V_3 = 0;
		goto IL_0036;
	}

IL_001d:
	{
		// res = (res & 1) == 1 ? Poly ^ (res >> 1) : (res >> 1);
		uint32_t L_2 = V_1;
		if ((((int32_t)((int32_t)((int32_t)L_2&1))) == ((int32_t)1)))
		{
			goto IL_0028;
		}
	}
	{
		uint32_t L_3 = V_1;
		G_B6_0 = ((uint32_t)(((int32_t)((uint32_t)L_3>>1))));
		goto IL_0031;
	}

IL_0028:
	{
		uint32_t L_4 = V_1;
		G_B6_0 = ((uint32_t)(((int32_t)(((int32_t)-2097792136)^((int32_t)((uint32_t)L_4>>1))))));
	}

IL_0031:
	{
		V_1 = G_B6_0;
		// for (int k = 0; k < 8; k++)
		int32_t L_5 = V_3;
		V_3 = ((int32_t)il2cpp_codegen_add(L_5, 1));
	}

IL_0036:
	{
		// for (int k = 0; k < 8; k++)
		int32_t L_6 = V_3;
		if ((((int32_t)L_6) < ((int32_t)8)))
		{
			goto IL_001d;
		}
	}
	{
		// Table[t * 256 + i] = res;
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_7 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		int32_t L_8 = V_2;
		uint32_t L_9 = V_0;
		if ((int64_t)(((int64_t)il2cpp_codegen_add(((int64_t)((int32_t)il2cpp_codegen_multiply(L_8, ((int32_t)256)))), ((int64_t)(uint64_t)L_9)))) > INTPTR_MAX) IL2CPP_RAISE_MANAGED_EXCEPTION(il2cpp_codegen_get_overflow_exception(), CRC32C__cctor_mBA8BFE64B4AEE422BD3E1E73C9B4E6DB100EF79B_RuntimeMethod_var);
		uint32_t L_10 = V_1;
		NullCheck(L_7);
		(L_7)->SetAt(static_cast<il2cpp_array_size_t>(((intptr_t)((int64_t)il2cpp_codegen_add(((int64_t)((int32_t)il2cpp_codegen_multiply(L_8, ((int32_t)256)))), ((int64_t)(uint64_t)L_9))))), (uint32_t)L_10);
		// for (int t = 0; t < 16; t++)
		int32_t L_11 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_11, 1));
	}

IL_0051:
	{
		// for (int t = 0; t < 16; t++)
		int32_t L_12 = V_2;
		if ((((int32_t)L_12) < ((int32_t)((int32_t)16))))
		{
			goto IL_0019;
		}
	}
	{
		// for (uint i = 0; i < 256; i++)
		uint32_t L_13 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add((int32_t)L_13, 1));
	}

IL_005a:
	{
		// for (uint i = 0; i < 256; i++)
		uint32_t L_14 = V_0;
		if ((!(((uint32_t)L_14) >= ((uint32_t)((int32_t)256)))))
		{
			goto IL_0013;
		}
	}
	{
		// }
		return;
	}
}
// System.UInt32 FlyingWormConsole3.LiteNetLib.Utils.CRC32C::Compute(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t CRC32C_Compute_m6ABD4B61DCD74A62046F40911343ECD3F4C45E38 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___input0, int32_t ___offset1, int32_t ___length2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint32_t V_0 = 0;
	uint32_t V_1 = 0;
	uint32_t V_2 = 0;
	uint32_t V_3 = 0;
	{
		// uint crcLocal = uint.MaxValue;
		V_0 = (-1);
		goto IL_014b;
	}

IL_0007:
	{
		// var a = Table[(3 * 256) + input[offset + 12]]
		//         ^ Table[(2 * 256) + input[offset + 13]]
		//         ^ Table[(1 * 256) + input[offset + 14]]
		//         ^ Table[(0 * 256) + input[offset + 15]];
		il2cpp_codegen_runtime_class_init_inline(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var);
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_0 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___input0;
		int32_t L_2 = ___offset1;
		NullCheck(L_1);
		int32_t L_3 = ((int32_t)il2cpp_codegen_add(L_2, ((int32_t)12)));
		uint8_t L_4 = (L_1)->GetAt(static_cast<il2cpp_array_size_t>(L_3));
		NullCheck(L_0);
		int32_t L_5 = ((int32_t)il2cpp_codegen_add(((int32_t)768), (int32_t)L_4));
		uint32_t L_6 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_5));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_7 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___input0;
		int32_t L_9 = ___offset1;
		NullCheck(L_8);
		int32_t L_10 = ((int32_t)il2cpp_codegen_add(L_9, ((int32_t)13)));
		uint8_t L_11 = (L_8)->GetAt(static_cast<il2cpp_array_size_t>(L_10));
		NullCheck(L_7);
		int32_t L_12 = ((int32_t)il2cpp_codegen_add(((int32_t)512), (int32_t)L_11));
		uint32_t L_13 = (L_7)->GetAt(static_cast<il2cpp_array_size_t>(L_12));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_14 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_15 = ___input0;
		int32_t L_16 = ___offset1;
		NullCheck(L_15);
		int32_t L_17 = ((int32_t)il2cpp_codegen_add(L_16, ((int32_t)14)));
		uint8_t L_18 = (L_15)->GetAt(static_cast<il2cpp_array_size_t>(L_17));
		NullCheck(L_14);
		int32_t L_19 = ((int32_t)il2cpp_codegen_add(((int32_t)256), (int32_t)L_18));
		uint32_t L_20 = (L_14)->GetAt(static_cast<il2cpp_array_size_t>(L_19));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_21 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_22 = ___input0;
		int32_t L_23 = ___offset1;
		NullCheck(L_22);
		int32_t L_24 = ((int32_t)il2cpp_codegen_add(L_23, ((int32_t)15)));
		uint8_t L_25 = (L_22)->GetAt(static_cast<il2cpp_array_size_t>(L_24));
		NullCheck(L_21);
		uint8_t L_26 = L_25;
		uint32_t L_27 = (L_21)->GetAt(static_cast<il2cpp_array_size_t>(L_26));
		V_1 = ((int32_t)(((int32_t)(((int32_t)((int32_t)L_6^(int32_t)L_13))^(int32_t)L_20))^(int32_t)L_27));
		// var b = Table[(7 * 256) + input[offset + 8]]
		//         ^ Table[(6 * 256) + input[offset + 9]]
		//         ^ Table[(5 * 256) + input[offset + 10]]
		//         ^ Table[(4 * 256) + input[offset + 11]];
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_28 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_29 = ___input0;
		int32_t L_30 = ___offset1;
		NullCheck(L_29);
		int32_t L_31 = ((int32_t)il2cpp_codegen_add(L_30, 8));
		uint8_t L_32 = (L_29)->GetAt(static_cast<il2cpp_array_size_t>(L_31));
		NullCheck(L_28);
		int32_t L_33 = ((int32_t)il2cpp_codegen_add(((int32_t)1792), (int32_t)L_32));
		uint32_t L_34 = (L_28)->GetAt(static_cast<il2cpp_array_size_t>(L_33));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_35 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_36 = ___input0;
		int32_t L_37 = ___offset1;
		NullCheck(L_36);
		int32_t L_38 = ((int32_t)il2cpp_codegen_add(L_37, ((int32_t)9)));
		uint8_t L_39 = (L_36)->GetAt(static_cast<il2cpp_array_size_t>(L_38));
		NullCheck(L_35);
		int32_t L_40 = ((int32_t)il2cpp_codegen_add(((int32_t)1536), (int32_t)L_39));
		uint32_t L_41 = (L_35)->GetAt(static_cast<il2cpp_array_size_t>(L_40));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_42 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_43 = ___input0;
		int32_t L_44 = ___offset1;
		NullCheck(L_43);
		int32_t L_45 = ((int32_t)il2cpp_codegen_add(L_44, ((int32_t)10)));
		uint8_t L_46 = (L_43)->GetAt(static_cast<il2cpp_array_size_t>(L_45));
		NullCheck(L_42);
		int32_t L_47 = ((int32_t)il2cpp_codegen_add(((int32_t)1280), (int32_t)L_46));
		uint32_t L_48 = (L_42)->GetAt(static_cast<il2cpp_array_size_t>(L_47));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_49 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_50 = ___input0;
		int32_t L_51 = ___offset1;
		NullCheck(L_50);
		int32_t L_52 = ((int32_t)il2cpp_codegen_add(L_51, ((int32_t)11)));
		uint8_t L_53 = (L_50)->GetAt(static_cast<il2cpp_array_size_t>(L_52));
		NullCheck(L_49);
		int32_t L_54 = ((int32_t)il2cpp_codegen_add(((int32_t)1024), (int32_t)L_53));
		uint32_t L_55 = (L_49)->GetAt(static_cast<il2cpp_array_size_t>(L_54));
		V_2 = ((int32_t)(((int32_t)(((int32_t)((int32_t)L_34^(int32_t)L_41))^(int32_t)L_48))^(int32_t)L_55));
		// var c = Table[(11 * 256) + input[offset + 4]]
		//         ^ Table[(10 * 256) + input[offset + 5]]
		//         ^ Table[(9 * 256) + input[offset + 6]]
		//         ^ Table[(8 * 256) + input[offset + 7]];
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_56 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_57 = ___input0;
		int32_t L_58 = ___offset1;
		NullCheck(L_57);
		int32_t L_59 = ((int32_t)il2cpp_codegen_add(L_58, 4));
		uint8_t L_60 = (L_57)->GetAt(static_cast<il2cpp_array_size_t>(L_59));
		NullCheck(L_56);
		int32_t L_61 = ((int32_t)il2cpp_codegen_add(((int32_t)2816), (int32_t)L_60));
		uint32_t L_62 = (L_56)->GetAt(static_cast<il2cpp_array_size_t>(L_61));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_63 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_64 = ___input0;
		int32_t L_65 = ___offset1;
		NullCheck(L_64);
		int32_t L_66 = ((int32_t)il2cpp_codegen_add(L_65, 5));
		uint8_t L_67 = (L_64)->GetAt(static_cast<il2cpp_array_size_t>(L_66));
		NullCheck(L_63);
		int32_t L_68 = ((int32_t)il2cpp_codegen_add(((int32_t)2560), (int32_t)L_67));
		uint32_t L_69 = (L_63)->GetAt(static_cast<il2cpp_array_size_t>(L_68));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_70 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_71 = ___input0;
		int32_t L_72 = ___offset1;
		NullCheck(L_71);
		int32_t L_73 = ((int32_t)il2cpp_codegen_add(L_72, 6));
		uint8_t L_74 = (L_71)->GetAt(static_cast<il2cpp_array_size_t>(L_73));
		NullCheck(L_70);
		int32_t L_75 = ((int32_t)il2cpp_codegen_add(((int32_t)2304), (int32_t)L_74));
		uint32_t L_76 = (L_70)->GetAt(static_cast<il2cpp_array_size_t>(L_75));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_77 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_78 = ___input0;
		int32_t L_79 = ___offset1;
		NullCheck(L_78);
		int32_t L_80 = ((int32_t)il2cpp_codegen_add(L_79, 7));
		uint8_t L_81 = (L_78)->GetAt(static_cast<il2cpp_array_size_t>(L_80));
		NullCheck(L_77);
		int32_t L_82 = ((int32_t)il2cpp_codegen_add(((int32_t)2048), (int32_t)L_81));
		uint32_t L_83 = (L_77)->GetAt(static_cast<il2cpp_array_size_t>(L_82));
		V_3 = ((int32_t)(((int32_t)(((int32_t)((int32_t)L_62^(int32_t)L_69))^(int32_t)L_76))^(int32_t)L_83));
		// var d = Table[(15 * 256) + ((byte)crcLocal ^ input[offset])]
		//         ^ Table[(14 * 256) + ((byte)(crcLocal >> 8) ^ input[offset + 1])]
		//         ^ Table[(13 * 256) + ((byte)(crcLocal >> 16) ^ input[offset + 2])]
		//         ^ Table[(12 * 256) + ((crcLocal >> 24) ^ input[offset + 3])];
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_84 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		uint32_t L_85 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_86 = ___input0;
		int32_t L_87 = ___offset1;
		NullCheck(L_86);
		int32_t L_88 = L_87;
		uint8_t L_89 = (L_86)->GetAt(static_cast<il2cpp_array_size_t>(L_88));
		NullCheck(L_84);
		int32_t L_90 = ((int32_t)il2cpp_codegen_add(((int32_t)3840), ((int32_t)(((int32_t)(uint8_t)L_85)^(int32_t)L_89))));
		uint32_t L_91 = (L_84)->GetAt(static_cast<il2cpp_array_size_t>(L_90));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_92 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		uint32_t L_93 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_94 = ___input0;
		int32_t L_95 = ___offset1;
		NullCheck(L_94);
		int32_t L_96 = ((int32_t)il2cpp_codegen_add(L_95, 1));
		uint8_t L_97 = (L_94)->GetAt(static_cast<il2cpp_array_size_t>(L_96));
		NullCheck(L_92);
		int32_t L_98 = ((int32_t)il2cpp_codegen_add(((int32_t)3584), ((int32_t)(((int32_t)(uint8_t)((int32_t)((uint32_t)L_93>>8)))^(int32_t)L_97))));
		uint32_t L_99 = (L_92)->GetAt(static_cast<il2cpp_array_size_t>(L_98));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_100 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		uint32_t L_101 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_102 = ___input0;
		int32_t L_103 = ___offset1;
		NullCheck(L_102);
		int32_t L_104 = ((int32_t)il2cpp_codegen_add(L_103, 2));
		uint8_t L_105 = (L_102)->GetAt(static_cast<il2cpp_array_size_t>(L_104));
		NullCheck(L_100);
		int32_t L_106 = ((int32_t)il2cpp_codegen_add(((int32_t)3328), ((int32_t)(((int32_t)(uint8_t)((int32_t)((uint32_t)L_101>>((int32_t)16))))^(int32_t)L_105))));
		uint32_t L_107 = (L_100)->GetAt(static_cast<il2cpp_array_size_t>(L_106));
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_108 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		uint32_t L_109 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_110 = ___input0;
		int32_t L_111 = ___offset1;
		NullCheck(L_110);
		int32_t L_112 = ((int32_t)il2cpp_codegen_add(L_111, 3));
		uint8_t L_113 = (L_110)->GetAt(static_cast<il2cpp_array_size_t>(L_112));
		NullCheck(L_108);
		int32_t L_114 = ((int32_t)il2cpp_codegen_add(((int32_t)3072), ((int32_t)(((int32_t)((uint32_t)L_109>>((int32_t)24)))^(int32_t)L_113))));
		uint32_t L_115 = (L_108)->GetAt(static_cast<il2cpp_array_size_t>(L_114));
		// crcLocal = d ^ c ^ b ^ a;
		uint32_t L_116 = V_3;
		uint32_t L_117 = V_2;
		uint32_t L_118 = V_1;
		V_0 = ((int32_t)(((int32_t)(((int32_t)(((int32_t)(((int32_t)(((int32_t)((int32_t)L_91^(int32_t)L_99))^(int32_t)L_107))^(int32_t)L_115))^(int32_t)L_116))^(int32_t)L_117))^(int32_t)L_118));
		// offset += 16;
		int32_t L_119 = ___offset1;
		___offset1 = ((int32_t)il2cpp_codegen_add(L_119, ((int32_t)16)));
		// length -= 16;
		int32_t L_120 = ___length2;
		___length2 = ((int32_t)il2cpp_codegen_subtract(L_120, ((int32_t)16)));
	}

IL_014b:
	{
		// while (length >= 16)
		int32_t L_121 = ___length2;
		if ((((int32_t)L_121) >= ((int32_t)((int32_t)16))))
		{
			goto IL_0007;
		}
	}
	{
		goto IL_016b;
	}

IL_0155:
	{
		// crcLocal = Table[(byte)(crcLocal ^ input[offset++])] ^ crcLocal >> 8;
		il2cpp_codegen_runtime_class_init_inline(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var);
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_122 = ((CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_StaticFields*)il2cpp_codegen_static_fields_for(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var))->___Table_2;
		uint32_t L_123 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_124 = ___input0;
		int32_t L_125 = ___offset1;
		int32_t L_126 = L_125;
		___offset1 = ((int32_t)il2cpp_codegen_add(L_126, 1));
		NullCheck(L_124);
		int32_t L_127 = L_126;
		uint8_t L_128 = (L_124)->GetAt(static_cast<il2cpp_array_size_t>(L_127));
		NullCheck(L_122);
		int32_t L_129 = ((int32_t)(uint8_t)((int32_t)((int32_t)L_123^(int32_t)L_128)));
		uint32_t L_130 = (L_122)->GetAt(static_cast<il2cpp_array_size_t>(L_129));
		uint32_t L_131 = V_0;
		V_0 = ((int32_t)((int32_t)L_130^((int32_t)((uint32_t)L_131>>8))));
	}

IL_016b:
	{
		// while (--length >= 0)
		int32_t L_132 = ___length2;
		int32_t L_133 = ((int32_t)il2cpp_codegen_subtract(L_132, 1));
		___length2 = L_133;
		if ((((int32_t)L_133) >= ((int32_t)0)))
		{
			goto IL_0155;
		}
	}
	{
		// return crcLocal ^ uint.MaxValue;
		uint32_t L_134 = V_0;
		return ((int32_t)((int32_t)L_134^(-1)));
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::WriteLittleEndian(System.Byte[],System.Int32,System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_WriteLittleEndian_m381E59B59A43CB94E0B537FB44F0C0B4E1BEA561 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___buffer0, int32_t ___offset1, uint64_t ___data2, const RuntimeMethod* method) 
{
	{
		// buffer[offset] = (byte)(data);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___buffer0;
		int32_t L_1 = ___offset1;
		uint64_t L_2 = ___data2;
		NullCheck(L_0);
		(L_0)->SetAt(static_cast<il2cpp_array_size_t>(L_1), (uint8_t)((int32_t)(uint8_t)L_2));
		// buffer[offset + 1] = (byte)(data >> 8);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___buffer0;
		int32_t L_4 = ___offset1;
		uint64_t L_5 = ___data2;
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_4, 1))), (uint8_t)((int32_t)(uint8_t)((int64_t)((uint64_t)L_5>>8))));
		// buffer[offset + 2] = (byte)(data >> 16);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___buffer0;
		int32_t L_7 = ___offset1;
		uint64_t L_8 = ___data2;
		NullCheck(L_6);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_7, 2))), (uint8_t)((int32_t)(uint8_t)((int64_t)((uint64_t)L_8>>((int32_t)16)))));
		// buffer[offset + 3] = (byte)(data >> 24);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = ___buffer0;
		int32_t L_10 = ___offset1;
		uint64_t L_11 = ___data2;
		NullCheck(L_9);
		(L_9)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_10, 3))), (uint8_t)((int32_t)(uint8_t)((int64_t)((uint64_t)L_11>>((int32_t)24)))));
		// buffer[offset + 4] = (byte)(data >> 32);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_12 = ___buffer0;
		int32_t L_13 = ___offset1;
		uint64_t L_14 = ___data2;
		NullCheck(L_12);
		(L_12)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_13, 4))), (uint8_t)((int32_t)(uint8_t)((int64_t)((uint64_t)L_14>>((int32_t)32)))));
		// buffer[offset + 5] = (byte)(data >> 40);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_15 = ___buffer0;
		int32_t L_16 = ___offset1;
		uint64_t L_17 = ___data2;
		NullCheck(L_15);
		(L_15)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_16, 5))), (uint8_t)((int32_t)(uint8_t)((int64_t)((uint64_t)L_17>>((int32_t)40)))));
		// buffer[offset + 6] = (byte)(data >> 48);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = ___buffer0;
		int32_t L_19 = ___offset1;
		uint64_t L_20 = ___data2;
		NullCheck(L_18);
		(L_18)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_19, 6))), (uint8_t)((int32_t)(uint8_t)((int64_t)((uint64_t)L_20>>((int32_t)48)))));
		// buffer[offset + 7] = (byte)(data >> 56);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_21 = ___buffer0;
		int32_t L_22 = ___offset1;
		uint64_t L_23 = ___data2;
		NullCheck(L_21);
		(L_21)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_22, 7))), (uint8_t)((int32_t)(uint8_t)((int64_t)((uint64_t)L_23>>((int32_t)56)))));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::WriteLittleEndian(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_WriteLittleEndian_m74DABA75442771598F637407CEBFD9E66DF60DB7 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___buffer0, int32_t ___offset1, int32_t ___data2, const RuntimeMethod* method) 
{
	{
		// buffer[offset] = (byte)(data);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___buffer0;
		int32_t L_1 = ___offset1;
		int32_t L_2 = ___data2;
		NullCheck(L_0);
		(L_0)->SetAt(static_cast<il2cpp_array_size_t>(L_1), (uint8_t)((int32_t)(uint8_t)L_2));
		// buffer[offset + 1] = (byte)(data >> 8);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___buffer0;
		int32_t L_4 = ___offset1;
		int32_t L_5 = ___data2;
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_4, 1))), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_5>>8))));
		// buffer[offset + 2] = (byte)(data >> 16);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___buffer0;
		int32_t L_7 = ___offset1;
		int32_t L_8 = ___data2;
		NullCheck(L_6);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_7, 2))), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_8>>((int32_t)16)))));
		// buffer[offset + 3] = (byte)(data >> 24);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = ___buffer0;
		int32_t L_10 = ___offset1;
		int32_t L_11 = ___data2;
		NullCheck(L_9);
		(L_9)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_10, 3))), (uint8_t)((int32_t)(uint8_t)((int32_t)(L_11>>((int32_t)24)))));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::WriteLittleEndian(System.Byte[],System.Int32,System.Int16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_WriteLittleEndian_m1E1C0AE20BD2FCB97F656DE97253FD064ED9BB38 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___buffer0, int32_t ___offset1, int16_t ___data2, const RuntimeMethod* method) 
{
	{
		// buffer[offset] = (byte)(data);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___buffer0;
		int32_t L_1 = ___offset1;
		int16_t L_2 = ___data2;
		NullCheck(L_0);
		(L_0)->SetAt(static_cast<il2cpp_array_size_t>(L_1), (uint8_t)((int32_t)(uint8_t)L_2));
		// buffer[offset + 1] = (byte)(data >> 8);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___buffer0;
		int32_t L_4 = ___offset1;
		int16_t L_5 = ___data2;
		NullCheck(L_3);
		(L_3)->SetAt(static_cast<il2cpp_array_size_t>(((int32_t)il2cpp_codegen_add(L_4, 1))), (uint8_t)((int32_t)(uint8_t)((int32_t)((int32_t)L_5>>8))));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_mBF60A9EB8FD38FFFE8EA1B8B1B5407C4499DD063 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, double ___value2, const RuntimeMethod* method) 
{
	ConverterHelperDouble_t96DC6EE768B7969E3AEA90AE956FA9641E1CF49D V_0;
	memset((&V_0), 0, sizeof(V_0));
	ConverterHelperDouble_t96DC6EE768B7969E3AEA90AE956FA9641E1CF49D V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		// ConverterHelperDouble ch = new ConverterHelperDouble { Adouble = value };
		il2cpp_codegen_initobj((&V_1), sizeof(ConverterHelperDouble_t96DC6EE768B7969E3AEA90AE956FA9641E1CF49D));
		double L_0 = ___value2;
		(&V_1)->___Adouble_1 = L_0;
		ConverterHelperDouble_t96DC6EE768B7969E3AEA90AE956FA9641E1CF49D L_1 = V_1;
		V_0 = L_1;
		// WriteLittleEndian(bytes, startIndex, ch.Along);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___bytes0;
		int32_t L_3 = ___startIndex1;
		ConverterHelperDouble_t96DC6EE768B7969E3AEA90AE956FA9641E1CF49D L_4 = V_0;
		uint64_t L_5 = L_4.___Along_0;
		FastBitConverter_WriteLittleEndian_m381E59B59A43CB94E0B537FB44F0C0B4E1BEA561(L_2, L_3, L_5, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_m6B2778DF75A49DC012513A1C0AEC198F165E761C (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, float ___value2, const RuntimeMethod* method) 
{
	ConverterHelperFloat_t32B37DDAF4EAE04DD7637BDA96DA12255B6D974C V_0;
	memset((&V_0), 0, sizeof(V_0));
	ConverterHelperFloat_t32B37DDAF4EAE04DD7637BDA96DA12255B6D974C V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		// ConverterHelperFloat ch = new ConverterHelperFloat { Afloat = value };
		il2cpp_codegen_initobj((&V_1), sizeof(ConverterHelperFloat_t32B37DDAF4EAE04DD7637BDA96DA12255B6D974C));
		float L_0 = ___value2;
		(&V_1)->___Afloat_1 = L_0;
		ConverterHelperFloat_t32B37DDAF4EAE04DD7637BDA96DA12255B6D974C L_1 = V_1;
		V_0 = L_1;
		// WriteLittleEndian(bytes, startIndex, ch.Aint);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___bytes0;
		int32_t L_3 = ___startIndex1;
		ConverterHelperFloat_t32B37DDAF4EAE04DD7637BDA96DA12255B6D974C L_4 = V_0;
		int32_t L_5 = L_4.___Aint_0;
		FastBitConverter_WriteLittleEndian_m74DABA75442771598F637407CEBFD9E66DF60DB7(L_2, L_3, L_5, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.Int16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_mF3C15486890268B6B1334D47252E3011CEFB2039 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, int16_t ___value2, const RuntimeMethod* method) 
{
	{
		// WriteLittleEndian(bytes, startIndex, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___bytes0;
		int32_t L_1 = ___startIndex1;
		int16_t L_2 = ___value2;
		FastBitConverter_WriteLittleEndian_m1E1C0AE20BD2FCB97F656DE97253FD064ED9BB38(L_0, L_1, L_2, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.UInt16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_mC6C3C3E1FA097BB0C9E04A5032DBFC51E46FEC79 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, uint16_t ___value2, const RuntimeMethod* method) 
{
	{
		// WriteLittleEndian(bytes, startIndex, (short)value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___bytes0;
		int32_t L_1 = ___startIndex1;
		uint16_t L_2 = ___value2;
		FastBitConverter_WriteLittleEndian_m1E1C0AE20BD2FCB97F656DE97253FD064ED9BB38(L_0, L_1, ((int16_t)L_2), NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_mD6649FCFC54EBFAC500F6647222F8A40B37DF0FD (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, int32_t ___value2, const RuntimeMethod* method) 
{
	{
		// WriteLittleEndian(bytes, startIndex, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___bytes0;
		int32_t L_1 = ___startIndex1;
		int32_t L_2 = ___value2;
		FastBitConverter_WriteLittleEndian_m74DABA75442771598F637407CEBFD9E66DF60DB7(L_0, L_1, L_2, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_mE205091FC74A54D5580EF718A92652CCCF3FC942 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, uint32_t ___value2, const RuntimeMethod* method) 
{
	{
		// WriteLittleEndian(bytes, startIndex, (int)value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___bytes0;
		int32_t L_1 = ___startIndex1;
		uint32_t L_2 = ___value2;
		FastBitConverter_WriteLittleEndian_m74DABA75442771598F637407CEBFD9E66DF60DB7(L_0, L_1, L_2, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.Int64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_m3217BA7AFFB8FC748D049D69CC84FC905D049AA0 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, int64_t ___value2, const RuntimeMethod* method) 
{
	{
		// WriteLittleEndian(bytes, startIndex, (ulong)value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___bytes0;
		int32_t L_1 = ___startIndex1;
		int64_t L_2 = ___value2;
		FastBitConverter_WriteLittleEndian_m381E59B59A43CB94E0B537FB44F0C0B4E1BEA561(L_0, L_1, L_2, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.FastBitConverter::GetBytes(System.Byte[],System.Int32,System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FastBitConverter_GetBytes_m9D1EC7459D20F918B45C5ED54DAC7B95CA35F064 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___startIndex1, uint64_t ___value2, const RuntimeMethod* method) 
{
	{
		// WriteLittleEndian(bytes, startIndex, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___bytes0;
		int32_t L_1 = ___startIndex1;
		uint64_t L_2 = ___value2;
		FastBitConverter_WriteLittleEndian_m381E59B59A43CB94E0B537FB44F0C0B4E1BEA561(L_0, L_1, L_2, NULL);
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::get_RawData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* NetDataReader_get_RawData_mFCC7E43438E4F27D39F13AC46C02BE2AE425FDAE (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// get { return _data; }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		return L_0;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::get_RawDataSize()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataReader_get_RawDataSize_m728651CF1102C180A126D99D000183887DED139E (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// get { return _dataSize; }
		int32_t L_0 = __this->____dataSize_2;
		return L_0;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::get_UserDataOffset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataReader_get_UserDataOffset_m2F61D071F72CDAB002C687C1E1A0C68D1E1503C3 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// get { return _offset; }
		int32_t L_0 = __this->____offset_3;
		return L_0;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::get_UserDataSize()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataReader_get_UserDataSize_m18C161D9128CE869A3A5B3C69BF2F022BC80D713 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// get { return _dataSize - _offset; }
		int32_t L_0 = __this->____dataSize_2;
		int32_t L_1 = __this->____offset_3;
		return ((int32_t)il2cpp_codegen_subtract(L_0, L_1));
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::get_IsNull()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_get_IsNull_m517ED57B80A4962D1895821C8E4D594E6EC824BB (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// get { return _data == null; }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		return (bool)((((RuntimeObject*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)L_0) == ((RuntimeObject*)(RuntimeObject*)NULL))? 1 : 0);
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::get_Position()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataReader_get_Position_mB70C27C6303CE017D5212C0860B255CFAB581BEB (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// get { return _position; }
		int32_t L_0 = __this->____position_1;
		return L_0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::get_EndOfData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_get_EndOfData_m323973957764E0A87772EA0E727BA9E9CCDF6432 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// get { return _position == _dataSize; }
		int32_t L_0 = __this->____position_1;
		int32_t L_1 = __this->____dataSize_2;
		return (bool)((((int32_t)L_0) == ((int32_t)L_1))? 1 : 0);
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::get_AvailableBytes()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// get { return _dataSize - _position; }
		int32_t L_0 = __this->____dataSize_2;
		int32_t L_1 = __this->____position_1;
		return ((int32_t)il2cpp_codegen_subtract(L_0, L_1));
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::SkipBytes(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_SkipBytes_m7259816B798B8C967B0C6F7F7691CF1E688C102A (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, int32_t ___count0, const RuntimeMethod* method) 
{
	{
		// _position += count;
		int32_t L_0 = __this->____position_1;
		int32_t L_1 = ___count0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_0, L_1));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::SetSource(FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_SetSource_mBB8783DD38E3E8036B963E9DB1E9938BEB3016DB (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* ___dataWriter0, const RuntimeMethod* method) 
{
	{
		// _data = dataWriter.Data;
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_0 = ___dataWriter0;
		NullCheck(L_0);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1;
		L_1 = NetDataWriter_get_Data_m57195A7D8184C5AFAE3D3DEF4069D8AD9A7390AD_inline(L_0, NULL);
		__this->____data_0 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____data_0), (void*)L_1);
		// _position = 0;
		__this->____position_1 = 0;
		// _offset = 0;
		__this->____offset_3 = 0;
		// _dataSize = dataWriter.Length;
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_2 = ___dataWriter0;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = NetDataWriter_get_Length_m7947782000AC2E7C7B6152A12F4FCA2064948AEC_inline(L_2, NULL);
		__this->____dataSize_2 = L_3;
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::SetSource(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_SetSource_mF38EADB55AB83471FB3659699E2D72CB729F6EB2 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___source0, const RuntimeMethod* method) 
{
	{
		// _data = source;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___source0;
		__this->____data_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____data_0), (void*)L_0);
		// _position = 0;
		__this->____position_1 = 0;
		// _offset = 0;
		__this->____offset_3 = 0;
		// _dataSize = source.Length;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___source0;
		NullCheck(L_1);
		__this->____dataSize_2 = ((int32_t)(((RuntimeArray*)L_1)->max_length));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::SetSource(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_SetSource_mAE98AD0CF76E7AD14F84DBD771B680A060C27361 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___source0, int32_t ___offset1, const RuntimeMethod* method) 
{
	{
		// _data = source;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___source0;
		__this->____data_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____data_0), (void*)L_0);
		// _position = offset;
		int32_t L_1 = ___offset1;
		__this->____position_1 = L_1;
		// _offset = offset;
		int32_t L_2 = ___offset1;
		__this->____offset_3 = L_2;
		// _dataSize = source.Length;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___source0;
		NullCheck(L_3);
		__this->____dataSize_2 = ((int32_t)(((RuntimeArray*)L_3)->max_length));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::SetSource(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_SetSource_m001BD5F3E22403AF65DD828572FC45C5D1AE0410 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___source0, int32_t ___offset1, int32_t ___maxSize2, const RuntimeMethod* method) 
{
	{
		// _data = source;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___source0;
		__this->____data_0 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____data_0), (void*)L_0);
		// _position = offset;
		int32_t L_1 = ___offset1;
		__this->____position_1 = L_1;
		// _offset = offset;
		int32_t L_2 = ___offset1;
		__this->____offset_3 = L_2;
		// _dataSize = maxSize;
		int32_t L_3 = ___maxSize2;
		__this->____dataSize_2 = L_3;
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader__ctor_mC18C3570B76F344A79A2CAF499A4596EC2DEDDC4 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// public NetDataReader()
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::.ctor(FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader__ctor_m8117F7BAD8EDFD07314F8F7A87E93CC7ED182A6F (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* ___writer0, const RuntimeMethod* method) 
{
	{
		// public NetDataReader(NetDataWriter writer)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// SetSource(writer);
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_0 = ___writer0;
		NetDataReader_SetSource_mBB8783DD38E3E8036B963E9DB1E9938BEB3016DB(__this, L_0, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::.ctor(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader__ctor_mFFF7A6517EC47CFE745479E10B4EF77FC00306E0 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___source0, const RuntimeMethod* method) 
{
	{
		// public NetDataReader(byte[] source)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// SetSource(source);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___source0;
		NetDataReader_SetSource_mF38EADB55AB83471FB3659699E2D72CB729F6EB2(__this, L_0, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::.ctor(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader__ctor_mC2DED90CF11DE4518BB8A5506027478E0A06262C (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___source0, int32_t ___offset1, const RuntimeMethod* method) 
{
	{
		// public NetDataReader(byte[] source, int offset)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// SetSource(source, offset);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___source0;
		int32_t L_1 = ___offset1;
		NetDataReader_SetSource_mAE98AD0CF76E7AD14F84DBD771B680A060C27361(__this, L_0, L_1, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::.ctor(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader__ctor_m1AF4A3028552C2D5CDC0B3F904A2243543027E0E (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___source0, int32_t ___offset1, int32_t ___maxSize2, const RuntimeMethod* method) 
{
	{
		// public NetDataReader(byte[] source, int offset, int maxSize)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// SetSource(source, offset, maxSize);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___source0;
		int32_t L_1 = ___offset1;
		int32_t L_2 = ___maxSize2;
		NetDataReader_SetSource_m001BD5F3E22403AF65DD828572FC45C5D1AE0410(__this, L_0, L_1, L_2, NULL);
		// }
		return;
	}
}
// System.Net.IPEndPoint FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetNetEndPoint()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* NetDataReader_GetNetEndPoint_m0DA1B4D9613C68CC247343D0F49987323F2100E6 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// string host = GetString(1000);
		String_t* L_0;
		L_0 = NetDataReader_GetString_m19541292BC49A3CE2F5A6EEE17B474171A6C63D5(__this, ((int32_t)1000), NULL);
		// int port = GetInt();
		int32_t L_1;
		L_1 = NetDataReader_GetInt_m92B368B698EC12119AC71237D7ADC180941F471A(__this, NULL);
		V_0 = L_1;
		// return NetUtils.MakeEndPoint(host, port);
		int32_t L_2 = V_0;
		il2cpp_codegen_runtime_class_init_inline(NetUtils_tD42EC79AFBE1C8BD1B0E41B25106D1FB1433BDDF_il2cpp_TypeInfo_var);
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_3;
		L_3 = NetUtils_MakeEndPoint_mF3EC8D450B5146C27AEF82F7962734F09ACBB1A1(L_0, L_2, NULL);
		return L_3;
	}
}
// System.Byte FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetByte()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t NetDataReader_GetByte_m06FB4658EC622986718080254ECFD259DD406BF6 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// byte res = _data[_position];
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		// _position += 1;
		int32_t L_4 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_4, 1));
		// return res;
		return L_3;
	}
}
// System.SByte FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetSByte()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int8_t NetDataReader_GetSByte_m06DBC7E501228FAD46AD4547131711438B10D650 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// var b = (sbyte)_data[_position];
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		// _position++;
		int32_t L_4 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_4, 1));
		// return b;
		return ((int8_t)L_3);
	}
}
// System.Boolean[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetBoolArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* NetDataReader_GetBoolArray_m5D63E1C16153C7B111D7333929416DDA1D3C3CF1 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* V_1 = NULL;
	{
		// ushort size = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		V_0 = L_2;
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// var arr = new bool[size];
		uint16_t L_4 = V_0;
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_5 = (BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*)(BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4*)SZArrayNew(BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		// Buffer.BlockCopy(_data, _position, arr, 0, size);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		int32_t L_7 = __this->____position_1;
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_8 = V_1;
		uint16_t L_9 = V_0;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, L_7, (RuntimeArray*)L_8, 0, L_9, NULL);
		// _position += size;
		int32_t L_10 = __this->____position_1;
		uint16_t L_11 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_10, (int32_t)L_11));
		// return arr;
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_12 = V_1;
		return L_12;
	}
}
// System.UInt16[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetUShortArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* NetDataReader_GetUShortArray_m8F8A9423DCED64763AD8CA5D6BFC4E455F896D35 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* V_1 = NULL;
	{
		// ushort size = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		V_0 = L_2;
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// var arr = new ushort[size];
		uint16_t L_4 = V_0;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_5 = (UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83*)(UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83*)SZArrayNew(UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		// Buffer.BlockCopy(_data, _position, arr, 0, size * 2);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		int32_t L_7 = __this->____position_1;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_8 = V_1;
		uint16_t L_9 = V_0;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, L_7, (RuntimeArray*)L_8, 0, ((int32_t)il2cpp_codegen_multiply((int32_t)L_9, 2)), NULL);
		// _position += size * 2;
		int32_t L_10 = __this->____position_1;
		uint16_t L_11 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_10, ((int32_t)il2cpp_codegen_multiply((int32_t)L_11, 2))));
		// return arr;
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_12 = V_1;
		return L_12;
	}
}
// System.Int16[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetShortArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB* NetDataReader_GetShortArray_m142ADA2043A302BC6B0CA3F1838939DFEE5467A8 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB* V_1 = NULL;
	{
		// ushort size = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		V_0 = L_2;
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// var arr = new short[size];
		uint16_t L_4 = V_0;
		Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB* L_5 = (Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB*)(Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB*)SZArrayNew(Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		// Buffer.BlockCopy(_data, _position, arr, 0, size * 2);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		int32_t L_7 = __this->____position_1;
		Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB* L_8 = V_1;
		uint16_t L_9 = V_0;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, L_7, (RuntimeArray*)L_8, 0, ((int32_t)il2cpp_codegen_multiply((int32_t)L_9, 2)), NULL);
		// _position += size * 2;
		int32_t L_10 = __this->____position_1;
		uint16_t L_11 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_10, ((int32_t)il2cpp_codegen_multiply((int32_t)L_11, 2))));
		// return arr;
		Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB* L_12 = V_1;
		return L_12;
	}
}
// System.Int64[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetLongArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D* NetDataReader_GetLongArray_mA78C6F80AD823687EB8265390D0C8C8826A7189D (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D* V_1 = NULL;
	{
		// ushort size = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		V_0 = L_2;
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// var arr = new long[size];
		uint16_t L_4 = V_0;
		Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D* L_5 = (Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D*)(Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D*)SZArrayNew(Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		// Buffer.BlockCopy(_data, _position, arr, 0, size * 8);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		int32_t L_7 = __this->____position_1;
		Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D* L_8 = V_1;
		uint16_t L_9 = V_0;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, L_7, (RuntimeArray*)L_8, 0, ((int32_t)il2cpp_codegen_multiply((int32_t)L_9, 8)), NULL);
		// _position += size * 8;
		int32_t L_10 = __this->____position_1;
		uint16_t L_11 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_10, ((int32_t)il2cpp_codegen_multiply((int32_t)L_11, 8))));
		// return arr;
		Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D* L_12 = V_1;
		return L_12;
	}
}
// System.UInt64[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetULongArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299* NetDataReader_GetULongArray_mDAAE54AB0DC6308F3CBBB1D6E85C830A71F1B5C2 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299* V_1 = NULL;
	{
		// ushort size = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		V_0 = L_2;
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// var arr = new ulong[size];
		uint16_t L_4 = V_0;
		UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299* L_5 = (UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299*)(UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299*)SZArrayNew(UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		// Buffer.BlockCopy(_data, _position, arr, 0, size * 8);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		int32_t L_7 = __this->____position_1;
		UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299* L_8 = V_1;
		uint16_t L_9 = V_0;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, L_7, (RuntimeArray*)L_8, 0, ((int32_t)il2cpp_codegen_multiply((int32_t)L_9, 8)), NULL);
		// _position += size * 8;
		int32_t L_10 = __this->____position_1;
		uint16_t L_11 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_10, ((int32_t)il2cpp_codegen_multiply((int32_t)L_11, 8))));
		// return arr;
		UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299* L_12 = V_1;
		return L_12;
	}
}
// System.Int32[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetIntArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* NetDataReader_GetIntArray_m886CE6ED6B4384BDC2A54E6D4626D19116AF3DE5 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* V_1 = NULL;
	{
		// ushort size = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		V_0 = L_2;
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// var arr = new int[size];
		uint16_t L_4 = V_0;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_5 = (Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C*)SZArrayNew(Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		// Buffer.BlockCopy(_data, _position, arr, 0, size * 4);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		int32_t L_7 = __this->____position_1;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_8 = V_1;
		uint16_t L_9 = V_0;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, L_7, (RuntimeArray*)L_8, 0, ((int32_t)il2cpp_codegen_multiply((int32_t)L_9, 4)), NULL);
		// _position += size * 4;
		int32_t L_10 = __this->____position_1;
		uint16_t L_11 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_10, ((int32_t)il2cpp_codegen_multiply((int32_t)L_11, 4))));
		// return arr;
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_12 = V_1;
		return L_12;
	}
}
// System.UInt32[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetUIntArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* NetDataReader_GetUIntArray_m491D896EA35FA673C7F3D463A86B6B6380E66179 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* V_1 = NULL;
	{
		// ushort size = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		V_0 = L_2;
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// var arr = new uint[size];
		uint16_t L_4 = V_0;
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_5 = (UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA*)(UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA*)SZArrayNew(UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		// Buffer.BlockCopy(_data, _position, arr, 0, size * 4);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		int32_t L_7 = __this->____position_1;
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_8 = V_1;
		uint16_t L_9 = V_0;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, L_7, (RuntimeArray*)L_8, 0, ((int32_t)il2cpp_codegen_multiply((int32_t)L_9, 4)), NULL);
		// _position += size * 4;
		int32_t L_10 = __this->____position_1;
		uint16_t L_11 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_10, ((int32_t)il2cpp_codegen_multiply((int32_t)L_11, 4))));
		// return arr;
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_12 = V_1;
		return L_12;
	}
}
// System.Single[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetFloatArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* NetDataReader_GetFloatArray_mAA70D51F37419419A22CC6B47D95E1DA501725AA (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* V_1 = NULL;
	{
		// ushort size = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		V_0 = L_2;
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// var arr = new float[size];
		uint16_t L_4 = V_0;
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_5 = (SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C*)(SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C*)SZArrayNew(SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		// Buffer.BlockCopy(_data, _position, arr, 0, size * 4);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		int32_t L_7 = __this->____position_1;
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_8 = V_1;
		uint16_t L_9 = V_0;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, L_7, (RuntimeArray*)L_8, 0, ((int32_t)il2cpp_codegen_multiply((int32_t)L_9, 4)), NULL);
		// _position += size * 4;
		int32_t L_10 = __this->____position_1;
		uint16_t L_11 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_10, ((int32_t)il2cpp_codegen_multiply((int32_t)L_11, 4))));
		// return arr;
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_12 = V_1;
		return L_12;
	}
}
// System.Double[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetDoubleArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE* NetDataReader_GetDoubleArray_mDC51865C0B49AE6CD01E2EED4CBA72ADCA2DE578 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE* V_1 = NULL;
	{
		// ushort size = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		V_0 = L_2;
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// var arr = new double[size];
		uint16_t L_4 = V_0;
		DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE* L_5 = (DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE*)(DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE*)SZArrayNew(DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		// Buffer.BlockCopy(_data, _position, arr, 0, size * 8);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		int32_t L_7 = __this->____position_1;
		DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE* L_8 = V_1;
		uint16_t L_9 = V_0;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, L_7, (RuntimeArray*)L_8, 0, ((int32_t)il2cpp_codegen_multiply((int32_t)L_9, 8)), NULL);
		// _position += size * 8;
		int32_t L_10 = __this->____position_1;
		uint16_t L_11 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_10, ((int32_t)il2cpp_codegen_multiply((int32_t)L_11, 8))));
		// return arr;
		DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE* L_12 = V_1;
		return L_12;
	}
}
// System.String[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetStringArray()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* NetDataReader_GetStringArray_m11566DEBE91FF12AB1058AE08D8010990AEC7E17 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* V_1 = NULL;
	int32_t V_2 = 0;
	{
		// ushort size = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		V_0 = L_2;
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// var arr = new string[size];
		uint16_t L_4 = V_0;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_5 = (StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)SZArrayNew(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		// for (int i = 0; i < size; i++)
		V_2 = 0;
		goto IL_0038;
	}

IL_002b:
	{
		// arr[i] = GetString();
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_6 = V_1;
		int32_t L_7 = V_2;
		String_t* L_8;
		L_8 = NetDataReader_GetString_mE8A0E283EB6059B7D6449F895FB6AACF7A0C795C(__this, NULL);
		NullCheck(L_6);
		ArrayElementTypeCheck (L_6, L_8);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(L_7), (String_t*)L_8);
		// for (int i = 0; i < size; i++)
		int32_t L_9 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_9, 1));
	}

IL_0038:
	{
		// for (int i = 0; i < size; i++)
		int32_t L_10 = V_2;
		uint16_t L_11 = V_0;
		if ((((int32_t)L_10) < ((int32_t)L_11)))
		{
			goto IL_002b;
		}
	}
	{
		// return arr;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_12 = V_1;
		return L_12;
	}
}
// System.String[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetStringArray(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* NetDataReader_GetStringArray_m443502EEC3059A7F76C6ED860D325AC44525A225 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, int32_t ___maxStringLength0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* V_1 = NULL;
	int32_t V_2 = 0;
	{
		// ushort size = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		V_0 = L_2;
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// var arr = new string[size];
		uint16_t L_4 = V_0;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_5 = (StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)SZArrayNew(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var, (uint32_t)L_4);
		V_1 = L_5;
		// for (int i = 0; i < size; i++)
		V_2 = 0;
		goto IL_0039;
	}

IL_002b:
	{
		// arr[i] = GetString(maxStringLength);
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_6 = V_1;
		int32_t L_7 = V_2;
		int32_t L_8 = ___maxStringLength0;
		String_t* L_9;
		L_9 = NetDataReader_GetString_m19541292BC49A3CE2F5A6EEE17B474171A6C63D5(__this, L_8, NULL);
		NullCheck(L_6);
		ArrayElementTypeCheck (L_6, L_9);
		(L_6)->SetAt(static_cast<il2cpp_array_size_t>(L_7), (String_t*)L_9);
		// for (int i = 0; i < size; i++)
		int32_t L_10 = V_2;
		V_2 = ((int32_t)il2cpp_codegen_add(L_10, 1));
	}

IL_0039:
	{
		// for (int i = 0; i < size; i++)
		int32_t L_11 = V_2;
		uint16_t L_12 = V_0;
		if ((((int32_t)L_11) < ((int32_t)L_12)))
		{
			goto IL_002b;
		}
	}
	{
		// return arr;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_13 = V_1;
		return L_13;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetBool()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_GetBool_m0A6A345E1F2AC6472D3A454AEF7F9C87241C5F4C (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// bool res = _data[_position] > 0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		// _position += 1;
		int32_t L_4 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_4, 1));
		// return res;
		return (bool)((((int32_t)L_3) > ((int32_t)0))? 1 : 0);
	}
}
// System.Char FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetChar()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar NetDataReader_GetChar_mA1AAFAF04C9ACCF416B0EE481F6D7C6284DA2E03 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// char result = BitConverter.ToChar(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		Il2CppChar L_2;
		L_2 = BitConverter_ToChar_mC94CFD2ABBB997AD4101A7EADA468FFD47F52EA0(L_0, L_1, NULL);
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// return result;
		return L_2;
	}
}
// System.UInt16 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetUShort()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint16_t NetDataReader_GetUShort_m01E2634AB533AC3ED170991D133981BB0D000DC4 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// ushort result = BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// return result;
		return L_2;
	}
}
// System.Int16 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetShort()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int16_t NetDataReader_GetShort_mE2FEF7B9AFA93170712E89277FE1C61C5D0FCAE8 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// short result = BitConverter.ToInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int16_t L_2;
		L_2 = BitConverter_ToInt16_mC4F4FF7F02DC025F64047372BD5B25540F3EFC62(L_0, L_1, NULL);
		// _position += 2;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 2));
		// return result;
		return L_2;
	}
}
// System.Int64 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetLong()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetDataReader_GetLong_m1B2BE011BE6E224D9FAE094DC1EECE9C3B473259 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// long result = BitConverter.ToInt64(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int64_t L_2;
		L_2 = BitConverter_ToInt64_m1CDA079BFD3222894DB58B69449E0110ED37AB1C(L_0, L_1, NULL);
		// _position += 8;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 8));
		// return result;
		return L_2;
	}
}
// System.UInt64 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetULong()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t NetDataReader_GetULong_mEDAAFDA63ECC73E4FFFD0557116F0C80DE08C8A2 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// ulong result = BitConverter.ToUInt64(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint64_t L_2;
		L_2 = BitConverter_ToUInt64_mD74DF4F6535FC635EB8697FC5175A7D99E3C62BF(L_0, L_1, NULL);
		// _position += 8;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 8));
		// return result;
		return L_2;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetInt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataReader_GetInt_m92B368B698EC12119AC71237D7ADC180941F471A (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// int result = BitConverter.ToInt32(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int32_t L_2;
		L_2 = BitConverter_ToInt32_m745DF4DCC23461AB3035A92BC0C4D59AE12E6880(L_0, L_1, NULL);
		// _position += 4;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 4));
		// return result;
		return L_2;
	}
}
// System.UInt32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetUInt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t NetDataReader_GetUInt_mDE5E7DFB66C920FA43257752522AD792CA8AA1E2 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// uint result = BitConverter.ToUInt32(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint32_t L_2;
		L_2 = BitConverter_ToUInt32_m7EFCF9D77ACD0F2DA29F69587DDF6130391E6164(L_0, L_1, NULL);
		// _position += 4;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 4));
		// return result;
		return L_2;
	}
}
// System.Single FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetFloat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float NetDataReader_GetFloat_m44A56D47D422411B6ED9B633BFA5A64AC3AFE570 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// float result = BitConverter.ToSingle(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		float L_2;
		L_2 = BitConverter_ToSingle_m385AA8335F6A788C1AD54295BA8352FFADD91F36(L_0, L_1, NULL);
		// _position += 4;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 4));
		// return result;
		return L_2;
	}
}
// System.Double FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetDouble()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double NetDataReader_GetDouble_m7F09CDB38083D759FF6E9EA5C572553FFE9B0055 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// double result = BitConverter.ToDouble(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		double L_2;
		L_2 = BitConverter_ToDouble_mEE089DB60AD05ED4B0F2670D8313E17668ECC289(L_0, L_1, NULL);
		// _position += 8;
		int32_t L_3 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_3, 8));
		// return result;
		return L_2;
	}
}
// System.String FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetString(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NetDataReader_GetString_m19541292BC49A3CE2F5A6EEE17B474171A6C63D5 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, int32_t ___maxLength0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&String_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// int bytesCount = GetInt();
		int32_t L_0;
		L_0 = NetDataReader_GetInt_m92B368B698EC12119AC71237D7ADC180941F471A(__this, NULL);
		V_0 = L_0;
		// if (bytesCount <= 0 || bytesCount > maxLength*2)
		int32_t L_1 = V_0;
		if ((((int32_t)L_1) <= ((int32_t)0)))
		{
			goto IL_0011;
		}
	}
	{
		int32_t L_2 = V_0;
		int32_t L_3 = ___maxLength0;
		if ((((int32_t)L_2) <= ((int32_t)((int32_t)il2cpp_codegen_multiply(L_3, 2)))))
		{
			goto IL_0017;
		}
	}

IL_0011:
	{
		// return string.Empty;
		String_t* L_4 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->___Empty_6;
		return L_4;
	}

IL_0017:
	{
		// int charCount = Encoding.UTF8.GetCharCount(_data, _position, bytesCount);
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_5;
		L_5 = Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		int32_t L_7 = __this->____position_1;
		int32_t L_8 = V_0;
		NullCheck(L_5);
		int32_t L_9;
		L_9 = VirtualFuncInvoker3< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(21 /* System.Int32 System.Text.Encoding::GetCharCount(System.Byte[],System.Int32,System.Int32) */, L_5, L_6, L_7, L_8);
		// if (charCount > maxLength)
		int32_t L_10 = ___maxLength0;
		if ((((int32_t)L_9) <= ((int32_t)L_10)))
		{
			goto IL_0037;
		}
	}
	{
		// return string.Empty;
		String_t* L_11 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->___Empty_6;
		return L_11;
	}

IL_0037:
	{
		// string result = Encoding.UTF8.GetString(_data, _position, bytesCount);
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_12;
		L_12 = Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = __this->____data_0;
		int32_t L_14 = __this->____position_1;
		int32_t L_15 = V_0;
		NullCheck(L_12);
		String_t* L_16;
		L_16 = VirtualFuncInvoker3< String_t*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(35 /* System.String System.Text.Encoding::GetString(System.Byte[],System.Int32,System.Int32) */, L_12, L_13, L_14, L_15);
		// _position += bytesCount;
		int32_t L_17 = __this->____position_1;
		int32_t L_18 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_17, L_18));
		// return result;
		return L_16;
	}
}
// System.String FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NetDataReader_GetString_mE8A0E283EB6059B7D6449F895FB6AACF7A0C795C (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&String_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// int bytesCount = GetInt();
		int32_t L_0;
		L_0 = NetDataReader_GetInt_m92B368B698EC12119AC71237D7ADC180941F471A(__this, NULL);
		V_0 = L_0;
		// if (bytesCount <= 0)
		int32_t L_1 = V_0;
		if ((((int32_t)L_1) > ((int32_t)0)))
		{
			goto IL_0011;
		}
	}
	{
		// return string.Empty;
		String_t* L_2 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->___Empty_6;
		return L_2;
	}

IL_0011:
	{
		// string result = Encoding.UTF8.GetString(_data, _position, bytesCount);
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_3;
		L_3 = Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = __this->____data_0;
		int32_t L_5 = __this->____position_1;
		int32_t L_6 = V_0;
		NullCheck(L_3);
		String_t* L_7;
		L_7 = VirtualFuncInvoker3< String_t*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(35 /* System.String System.Text.Encoding::GetString(System.Byte[],System.Int32,System.Int32) */, L_3, L_4, L_5, L_6);
		// _position += bytesCount;
		int32_t L_8 = __this->____position_1;
		int32_t L_9 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_8, L_9));
		// return result;
		return L_7;
	}
}
// System.ArraySegment`1<System.Byte> FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetRemainingBytesSegment()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ArraySegment_1_t3DC888623B720A071D69279F1FCB95A109195093 NetDataReader_GetRemainingBytesSegment_mA290387648946F3B8A8C3F8E61D0AF44BD74BDB2 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ArraySegment_1__ctor_m664EA6AD314FAA6BCA4F6D0586AEF01559537F20_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// ArraySegment<byte> segment = new ArraySegment<byte>(_data, _position, AvailableBytes);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		int32_t L_2;
		L_2 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		ArraySegment_1_t3DC888623B720A071D69279F1FCB95A109195093 L_3;
		memset((&L_3), 0, sizeof(L_3));
		ArraySegment_1__ctor_m664EA6AD314FAA6BCA4F6D0586AEF01559537F20((&L_3), L_0, L_1, L_2, /*hidden argument*/ArraySegment_1__ctor_m664EA6AD314FAA6BCA4F6D0586AEF01559537F20_RuntimeMethod_var);
		// _position = _data.Length;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = __this->____data_0;
		NullCheck(L_4);
		__this->____position_1 = ((int32_t)(((RuntimeArray*)L_4)->max_length));
		// return segment;
		return L_3;
	}
}
// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetRemainingBytes()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* NetDataReader_GetRemainingBytes_m63080D2F8E6F8DDA65850045309E95F0D2A81A39 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	{
		// byte[] outgoingData = new byte[AvailableBytes];
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_0);
		V_0 = L_1;
		// Buffer.BlockCopy(_data, _position, outgoingData, 0, AvailableBytes);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = V_0;
		int32_t L_5;
		L_5 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_2, L_3, (RuntimeArray*)L_4, 0, L_5, NULL);
		// _position = _data.Length;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		NullCheck(L_6);
		__this->____position_1 = ((int32_t)(((RuntimeArray*)L_6)->max_length));
		// return outgoingData;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = V_0;
		return L_7;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetBytes(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_GetBytes_m772AAA86FA31E467C5F6089D68D5722AAB003F95 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___destination0, int32_t ___start1, int32_t ___count2, const RuntimeMethod* method) 
{
	{
		// Buffer.BlockCopy(_data, _position, destination, start, count);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___destination0;
		int32_t L_3 = ___start1;
		int32_t L_4 = ___count2;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_0, L_1, (RuntimeArray*)L_2, L_3, L_4, NULL);
		// _position += count;
		int32_t L_5 = __this->____position_1;
		int32_t L_6 = ___count2;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, L_6));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetBytes(System.Byte[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_GetBytes_mFE126307DEA5B8702FA50EB872E267A2AE28F6A7 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___destination0, int32_t ___count1, const RuntimeMethod* method) 
{
	{
		// Buffer.BlockCopy(_data, _position, destination, 0, count);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___destination0;
		int32_t L_3 = ___count1;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_0, L_1, (RuntimeArray*)L_2, 0, L_3, NULL);
		// _position += count;
		int32_t L_4 = __this->____position_1;
		int32_t L_5 = ___count1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_4, L_5));
		// }
		return;
	}
}
// System.SByte[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetSBytesWithLength()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* NetDataReader_GetSBytesWithLength_mA2AE6EC54D99D8A3B6F5B98462B0402AF24F6E8C (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* V_1 = NULL;
	{
		// int length = GetInt();
		int32_t L_0;
		L_0 = NetDataReader_GetInt_m92B368B698EC12119AC71237D7ADC180941F471A(__this, NULL);
		V_0 = L_0;
		// sbyte[] outgoingData = new sbyte[length];
		int32_t L_1 = V_0;
		SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* L_2 = (SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913*)(SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913*)SZArrayNew(SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913_il2cpp_TypeInfo_var, (uint32_t)L_1);
		V_1 = L_2;
		// Buffer.BlockCopy(_data, _position, outgoingData, 0, length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = __this->____data_0;
		int32_t L_4 = __this->____position_1;
		SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* L_5 = V_1;
		int32_t L_6 = V_0;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_3, L_4, (RuntimeArray*)L_5, 0, L_6, NULL);
		// _position += length;
		int32_t L_7 = __this->____position_1;
		int32_t L_8 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_7, L_8));
		// return outgoingData;
		SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* L_9 = V_1;
		return L_9;
	}
}
// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::GetBytesWithLength()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* NetDataReader_GetBytesWithLength_m4B076429B78EDBEFB110F065B7024A4C147EB075 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_1 = NULL;
	{
		// int length = GetInt();
		int32_t L_0;
		L_0 = NetDataReader_GetInt_m92B368B698EC12119AC71237D7ADC180941F471A(__this, NULL);
		V_0 = L_0;
		// byte[] outgoingData = new byte[length];
		int32_t L_1 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_1);
		V_1 = L_2;
		// Buffer.BlockCopy(_data, _position, outgoingData, 0, length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = __this->____data_0;
		int32_t L_4 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = V_1;
		int32_t L_6 = V_0;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_3, L_4, (RuntimeArray*)L_5, 0, L_6, NULL);
		// _position += length;
		int32_t L_7 = __this->____position_1;
		int32_t L_8 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_7, L_8));
		// return outgoingData;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = V_1;
		return L_9;
	}
}
// System.Byte FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekByte()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint8_t NetDataReader_PeekByte_m39F9AE86F18E463265455B985CB5D2B4372C2798 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// return _data[_position];
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		return L_3;
	}
}
// System.SByte FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekSByte()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int8_t NetDataReader_PeekSByte_mC017D7C50F1AFC9B6737294182EF64C1966695EA (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// return (sbyte)_data[_position];
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		return ((int8_t)L_3);
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekBool()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_PeekBool_m085B3F33F20971F064B41D45666D1A56A8BBDB6F (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// return _data[_position] > 0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		NullCheck(L_0);
		int32_t L_2 = L_1;
		uint8_t L_3 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		return (bool)((((int32_t)L_3) > ((int32_t)0))? 1 : 0);
	}
}
// System.Char FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekChar()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar NetDataReader_PeekChar_m67F83E25FF22E5EBFC41F9F84F85223C1C5F3D92 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return BitConverter.ToChar(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		Il2CppChar L_2;
		L_2 = BitConverter_ToChar_mC94CFD2ABBB997AD4101A7EADA468FFD47F52EA0(L_0, L_1, NULL);
		return L_2;
	}
}
// System.UInt16 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekUShort()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint16_t NetDataReader_PeekUShort_m9CEFE3BA45F909836556A50A1DFFCA5883915089 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return BitConverter.ToUInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint16_t L_2;
		L_2 = BitConverter_ToUInt16_m133E286BF0B721DD973FD966F61CB171F70F3E32(L_0, L_1, NULL);
		return L_2;
	}
}
// System.Int16 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekShort()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int16_t NetDataReader_PeekShort_m33D468D061BA6E27D1EE0416E7CAC91EB7C964A6 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return BitConverter.ToInt16(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int16_t L_2;
		L_2 = BitConverter_ToInt16_mC4F4FF7F02DC025F64047372BD5B25540F3EFC62(L_0, L_1, NULL);
		return L_2;
	}
}
// System.Int64 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekLong()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int64_t NetDataReader_PeekLong_m0FA8048A1EC852A431F94F1E3B0C0933169AD941 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return BitConverter.ToInt64(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int64_t L_2;
		L_2 = BitConverter_ToInt64_m1CDA079BFD3222894DB58B69449E0110ED37AB1C(L_0, L_1, NULL);
		return L_2;
	}
}
// System.UInt64 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekULong()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t NetDataReader_PeekULong_m318A757B809660F1A2D7CCCA352498C6AFF6102C (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return BitConverter.ToUInt64(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint64_t L_2;
		L_2 = BitConverter_ToUInt64_mD74DF4F6535FC635EB8697FC5175A7D99E3C62BF(L_0, L_1, NULL);
		return L_2;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekInt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataReader_PeekInt_m55892788150A79450F06BCF4B1D0C5182444AD51 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return BitConverter.ToInt32(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int32_t L_2;
		L_2 = BitConverter_ToInt32_m745DF4DCC23461AB3035A92BC0C4D59AE12E6880(L_0, L_1, NULL);
		return L_2;
	}
}
// System.UInt32 FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekUInt()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t NetDataReader_PeekUInt_m696B0CAD1C471715698AE543609456FD210FBA53 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return BitConverter.ToUInt32(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint32_t L_2;
		L_2 = BitConverter_ToUInt32_m7EFCF9D77ACD0F2DA29F69587DDF6130391E6164(L_0, L_1, NULL);
		return L_2;
	}
}
// System.Single FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekFloat()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR float NetDataReader_PeekFloat_m1BE3A8482ECA0D534ACEAA46377786CD2E6A7E51 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return BitConverter.ToSingle(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		float L_2;
		L_2 = BitConverter_ToSingle_m385AA8335F6A788C1AD54295BA8352FFADD91F36(L_0, L_1, NULL);
		return L_2;
	}
}
// System.Double FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekDouble()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR double NetDataReader_PeekDouble_m3A6016CBEB7E5AF7C7D00646EA76185C410959B2 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return BitConverter.ToDouble(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		double L_2;
		L_2 = BitConverter_ToDouble_mEE089DB60AD05ED4B0F2670D8313E17668ECC289(L_0, L_1, NULL);
		return L_2;
	}
}
// System.String FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekString(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NetDataReader_PeekString_m6A4A2B2F712A071B0871811F1BB383812056631C (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, int32_t ___maxLength0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&String_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// int bytesCount = BitConverter.ToInt32(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int32_t L_2;
		L_2 = BitConverter_ToInt32_m745DF4DCC23461AB3035A92BC0C4D59AE12E6880(L_0, L_1, NULL);
		V_0 = L_2;
		// if (bytesCount <= 0 || bytesCount > maxLength * 2)
		int32_t L_3 = V_0;
		if ((((int32_t)L_3) <= ((int32_t)0)))
		{
			goto IL_001c;
		}
	}
	{
		int32_t L_4 = V_0;
		int32_t L_5 = ___maxLength0;
		if ((((int32_t)L_4) <= ((int32_t)((int32_t)il2cpp_codegen_multiply(L_5, 2)))))
		{
			goto IL_0022;
		}
	}

IL_001c:
	{
		// return string.Empty;
		String_t* L_6 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->___Empty_6;
		return L_6;
	}

IL_0022:
	{
		// int charCount = Encoding.UTF8.GetCharCount(_data, _position + 4, bytesCount);
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_7;
		L_7 = Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = __this->____data_0;
		int32_t L_9 = __this->____position_1;
		int32_t L_10 = V_0;
		NullCheck(L_7);
		int32_t L_11;
		L_11 = VirtualFuncInvoker3< int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(21 /* System.Int32 System.Text.Encoding::GetCharCount(System.Byte[],System.Int32,System.Int32) */, L_7, L_8, ((int32_t)il2cpp_codegen_add(L_9, 4)), L_10);
		// if (charCount > maxLength)
		int32_t L_12 = ___maxLength0;
		if ((((int32_t)L_11) <= ((int32_t)L_12)))
		{
			goto IL_0044;
		}
	}
	{
		// return string.Empty;
		String_t* L_13 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->___Empty_6;
		return L_13;
	}

IL_0044:
	{
		// string result = Encoding.UTF8.GetString(_data, _position + 4, bytesCount);
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_14;
		L_14 = Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_15 = __this->____data_0;
		int32_t L_16 = __this->____position_1;
		int32_t L_17 = V_0;
		NullCheck(L_14);
		String_t* L_18;
		L_18 = VirtualFuncInvoker3< String_t*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(35 /* System.String System.Text.Encoding::GetString(System.Byte[],System.Int32,System.Int32) */, L_14, L_15, ((int32_t)il2cpp_codegen_add(L_16, 4)), L_17);
		// return result;
		return L_18;
	}
}
// System.String FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::PeekString()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* NetDataReader_PeekString_m323E1AF0864CD0DB6F8997DFEAB82416A60DA0B1 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&String_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// int bytesCount = BitConverter.ToInt32(_data, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		int32_t L_1 = __this->____position_1;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		int32_t L_2;
		L_2 = BitConverter_ToInt32_m745DF4DCC23461AB3035A92BC0C4D59AE12E6880(L_0, L_1, NULL);
		V_0 = L_2;
		// if (bytesCount <= 0)
		int32_t L_3 = V_0;
		if ((((int32_t)L_3) > ((int32_t)0)))
		{
			goto IL_001c;
		}
	}
	{
		// return string.Empty;
		String_t* L_4 = ((String_t_StaticFields*)il2cpp_codegen_static_fields_for(String_t_il2cpp_TypeInfo_var))->___Empty_6;
		return L_4;
	}

IL_001c:
	{
		// string result = Encoding.UTF8.GetString(_data, _position + 4, bytesCount);
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_5;
		L_5 = Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336(NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____data_0;
		int32_t L_7 = __this->____position_1;
		int32_t L_8 = V_0;
		NullCheck(L_5);
		String_t* L_9;
		L_9 = VirtualFuncInvoker3< String_t*, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t, int32_t >::Invoke(35 /* System.String System.Text.Encoding::GetString(System.Byte[],System.Int32,System.Int32) */, L_5, L_6, ((int32_t)il2cpp_codegen_add(L_7, 4)), L_8);
		// return result;
		return L_9;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetByte(System.Byte&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetByte_m4FBA7C7EC51A11D1C6A49D4325543FBC2BCE99C7 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, uint8_t* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 1)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)1)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetByte();
		uint8_t* L_1 = ___result0;
		uint8_t L_2;
		L_2 = NetDataReader_GetByte_m06FB4658EC622986718080254ECFD259DD406BF6(__this, NULL);
		*((int8_t*)L_1) = (int8_t)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = 0;
		uint8_t* L_3 = ___result0;
		*((int8_t*)L_3) = (int8_t)0;
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetSByte(System.SByte&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetSByte_m7F0D8794955535086C9591EAFC625F6896B849B1 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, int8_t* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 1)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)1)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetSByte();
		int8_t* L_1 = ___result0;
		int8_t L_2;
		L_2 = NetDataReader_GetSByte_m06DBC7E501228FAD46AD4547131711438B10D650(__this, NULL);
		*((int8_t*)L_1) = (int8_t)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = 0;
		int8_t* L_3 = ___result0;
		*((int8_t*)L_3) = (int8_t)0;
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetBool(System.Boolean&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetBool_m10FD2921CED664DE167E38CD1A47CCDEBB24F584 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, bool* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 1)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)1)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetBool();
		bool* L_1 = ___result0;
		bool L_2;
		L_2 = NetDataReader_GetBool_m0A6A345E1F2AC6472D3A454AEF7F9C87241C5F4C(__this, NULL);
		*((int8_t*)L_1) = (int8_t)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = false;
		bool* L_3 = ___result0;
		*((int8_t*)L_3) = (int8_t)0;
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetChar(System.Char&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetChar_mE9D6909ED4DF517DAAB793786D6EDA8492CB5567 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, Il2CppChar* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 2)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)2)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetChar();
		Il2CppChar* L_1 = ___result0;
		Il2CppChar L_2;
		L_2 = NetDataReader_GetChar_mA1AAFAF04C9ACCF416B0EE481F6D7C6284DA2E03(__this, NULL);
		*((int16_t*)L_1) = (int16_t)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = '\0';
		Il2CppChar* L_3 = ___result0;
		*((int16_t*)L_3) = (int16_t)0;
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetShort(System.Int16&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetShort_m8738B9CEFEFBAF2701681B34C3B58946D25EF4D6 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, int16_t* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 2)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)2)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetShort();
		int16_t* L_1 = ___result0;
		int16_t L_2;
		L_2 = NetDataReader_GetShort_mE2FEF7B9AFA93170712E89277FE1C61C5D0FCAE8(__this, NULL);
		*((int16_t*)L_1) = (int16_t)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = 0;
		int16_t* L_3 = ___result0;
		*((int16_t*)L_3) = (int16_t)0;
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetUShort(System.UInt16&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetUShort_m45ED0659977BEA633E6E00C3CDCA9F74ECF92B53 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, uint16_t* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 2)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)2)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetUShort();
		uint16_t* L_1 = ___result0;
		uint16_t L_2;
		L_2 = NetDataReader_GetUShort_m01E2634AB533AC3ED170991D133981BB0D000DC4(__this, NULL);
		*((int16_t*)L_1) = (int16_t)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = 0;
		uint16_t* L_3 = ___result0;
		*((int16_t*)L_3) = (int16_t)0;
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetInt(System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetInt_m936AFD7080C992EF857D8A225133E88DE25305C8 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, int32_t* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 4)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)4)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetInt();
		int32_t* L_1 = ___result0;
		int32_t L_2;
		L_2 = NetDataReader_GetInt_m92B368B698EC12119AC71237D7ADC180941F471A(__this, NULL);
		*((int32_t*)L_1) = (int32_t)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = 0;
		int32_t* L_3 = ___result0;
		*((int32_t*)L_3) = (int32_t)0;
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetUInt(System.UInt32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetUInt_m1FEAE461137E72D14D34E13C500E1D34EAADBD00 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, uint32_t* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 4)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)4)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetUInt();
		uint32_t* L_1 = ___result0;
		uint32_t L_2;
		L_2 = NetDataReader_GetUInt_mDE5E7DFB66C920FA43257752522AD792CA8AA1E2(__this, NULL);
		*((int32_t*)L_1) = (int32_t)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = 0;
		uint32_t* L_3 = ___result0;
		*((int32_t*)L_3) = (int32_t)0;
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetLong(System.Int64&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetLong_m8242FE142740363F0022C2F7AEEE5AFC4F16A169 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, int64_t* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 8)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)8)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetLong();
		int64_t* L_1 = ___result0;
		int64_t L_2;
		L_2 = NetDataReader_GetLong_m1B2BE011BE6E224D9FAE094DC1EECE9C3B473259(__this, NULL);
		*((int64_t*)L_1) = (int64_t)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = 0;
		int64_t* L_3 = ___result0;
		*((int64_t*)L_3) = (int64_t)((int64_t)0);
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetULong(System.UInt64&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetULong_mA1D3E2C607CE45C543653F52C6376A021AF17616 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, uint64_t* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 8)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)8)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetULong();
		uint64_t* L_1 = ___result0;
		uint64_t L_2;
		L_2 = NetDataReader_GetULong_mEDAAFDA63ECC73E4FFFD0557116F0C80DE08C8A2(__this, NULL);
		*((int64_t*)L_1) = (int64_t)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = 0;
		uint64_t* L_3 = ___result0;
		*((int64_t*)L_3) = (int64_t)((int64_t)0);
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetFloat(System.Single&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetFloat_m4FA9FFE94224703E10C124A3B8643DADAFD68186 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, float* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 4)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)4)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetFloat();
		float* L_1 = ___result0;
		float L_2;
		L_2 = NetDataReader_GetFloat_m44A56D47D422411B6ED9B633BFA5A64AC3AFE570(__this, NULL);
		*((float*)L_1) = (float)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = 0;
		float* L_3 = ___result0;
		*((float*)L_3) = (float)(0.0f);
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetDouble(System.Double&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetDouble_m3053A50734B00F3AF8CD420820DB130CD1BB822C (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, double* ___result0, const RuntimeMethod* method) 
{
	{
		// if (AvailableBytes >= 8)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)8)))
		{
			goto IL_0013;
		}
	}
	{
		// result = GetDouble();
		double* L_1 = ___result0;
		double L_2;
		L_2 = NetDataReader_GetDouble_m7F09CDB38083D759FF6E9EA5C572553FFE9B0055(__this, NULL);
		*((double*)L_1) = (double)L_2;
		// return true;
		return (bool)1;
	}

IL_0013:
	{
		// result = 0;
		double* L_3 = ___result0;
		*((double*)L_3) = (double)(0.0);
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetString(System.String&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetString_m7BB02F8DD26F7D8F32FCBD644B5DCE1C9CB557F1 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, String_t** ___result0, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		// if (AvailableBytes >= 4)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)4)))
		{
			goto IL_0025;
		}
	}
	{
		// var bytesCount = PeekInt();
		int32_t L_1;
		L_1 = NetDataReader_PeekInt_m55892788150A79450F06BCF4B1D0C5182444AD51(__this, NULL);
		V_0 = L_1;
		// if (AvailableBytes >= bytesCount + 4)
		int32_t L_2;
		L_2 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		int32_t L_3 = V_0;
		if ((((int32_t)L_2) < ((int32_t)((int32_t)il2cpp_codegen_add(L_3, 4)))))
		{
			goto IL_0025;
		}
	}
	{
		// result = GetString();
		String_t** L_4 = ___result0;
		String_t* L_5;
		L_5 = NetDataReader_GetString_mE8A0E283EB6059B7D6449F895FB6AACF7A0C795C(__this, NULL);
		*((RuntimeObject**)L_4) = (RuntimeObject*)L_5;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)L_4, (void*)(RuntimeObject*)L_5);
		// return true;
		return (bool)1;
	}

IL_0025:
	{
		// result = null;
		String_t** L_6 = ___result0;
		*((RuntimeObject**)L_6) = (RuntimeObject*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)L_6, (void*)(RuntimeObject*)NULL);
		// return false;
		return (bool)0;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetStringArray(System.String[]&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetStringArray_m5C4300A39FD28E623AA3D3F215B808EDC927621A (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248** ___result0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	uint16_t V_0 = 0;
	int32_t V_1 = 0;
	{
		// if (!TryGetUShort(out size))
		bool L_0;
		L_0 = NetDataReader_TryGetUShort_m45ED0659977BEA633E6E00C3CDCA9F74ECF92B53(__this, (&V_0), NULL);
		if (L_0)
		{
			goto IL_000f;
		}
	}
	{
		// result = null;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248** L_1 = ___result0;
		*((RuntimeObject**)L_1) = (RuntimeObject*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)L_1, (void*)(RuntimeObject*)NULL);
		// return false;
		return (bool)0;
	}

IL_000f:
	{
		// result = new string[size];
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248** L_2 = ___result0;
		uint16_t L_3 = V_0;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_4 = (StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248*)SZArrayNew(StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248_il2cpp_TypeInfo_var, (uint32_t)L_3);
		*((RuntimeObject**)L_2) = (RuntimeObject*)L_4;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)L_2, (void*)(RuntimeObject*)L_4);
		// for (int i = 0; i < size; i++)
		V_1 = 0;
		goto IL_0034;
	}

IL_001b:
	{
		// if (!TryGetString(out result[i]))
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248** L_5 = ___result0;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_6 = *((StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248**)L_5);
		int32_t L_7 = V_1;
		NullCheck(L_6);
		bool L_8;
		L_8 = NetDataReader_TryGetString_m7BB02F8DD26F7D8F32FCBD644B5DCE1C9CB557F1(__this, ((L_6)->GetAddressAt(static_cast<il2cpp_array_size_t>(L_7))), NULL);
		if (L_8)
		{
			goto IL_0030;
		}
	}
	{
		// result = null;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248** L_9 = ___result0;
		*((RuntimeObject**)L_9) = (RuntimeObject*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)L_9, (void*)(RuntimeObject*)NULL);
		// return false;
		return (bool)0;
	}

IL_0030:
	{
		// for (int i = 0; i < size; i++)
		int32_t L_10 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_10, 1));
	}

IL_0034:
	{
		// for (int i = 0; i < size; i++)
		int32_t L_11 = V_1;
		uint16_t L_12 = V_0;
		if ((((int32_t)L_11) < ((int32_t)L_12)))
		{
			goto IL_001b;
		}
	}
	{
		// return true;
		return (bool)1;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::TryGetBytesWithLength(System.Byte[]&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NetDataReader_TryGetBytesWithLength_m4559B25C4CA80ED02AAEE765F8DABBCC30CECD27 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** ___result0, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		// if (AvailableBytes >= 4)
		int32_t L_0;
		L_0 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		if ((((int32_t)L_0) < ((int32_t)4)))
		{
			goto IL_0029;
		}
	}
	{
		// var length = PeekInt();
		int32_t L_1;
		L_1 = NetDataReader_PeekInt_m55892788150A79450F06BCF4B1D0C5182444AD51(__this, NULL);
		V_0 = L_1;
		// if (length >= 0 && AvailableBytes >= length + 4)
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) < ((int32_t)0)))
		{
			goto IL_0029;
		}
	}
	{
		int32_t L_3;
		L_3 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(__this, NULL);
		int32_t L_4 = V_0;
		if ((((int32_t)L_3) < ((int32_t)((int32_t)il2cpp_codegen_add(L_4, 4)))))
		{
			goto IL_0029;
		}
	}
	{
		// result = GetBytesWithLength();
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_5 = ___result0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6;
		L_6 = NetDataReader_GetBytesWithLength_m4B076429B78EDBEFB110F065B7024A4C147EB075(__this, NULL);
		*((RuntimeObject**)L_5) = (RuntimeObject*)L_6;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)L_5, (void*)(RuntimeObject*)L_6);
		// return true;
		return (bool)1;
	}

IL_0029:
	{
		// result = null;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_7 = ___result0;
		*((RuntimeObject**)L_7) = (RuntimeObject*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(RuntimeObject**)L_7, (void*)(RuntimeObject*)NULL);
		// return false;
		return (bool)0;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataReader::Clear()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataReader_Clear_mD4D12B8F7FD6D59D8E38C748FC4D6855A25512C3 (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* __this, const RuntimeMethod* method) 
{
	{
		// _position = 0;
		__this->____position_1 = 0;
		// _dataSize = 0;
		__this->____dataSize_2 = 0;
		// _data = null;
		__this->____data_0 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)NULL;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____data_0), (void*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)NULL);
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::get_Capacity()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataWriter_get_Capacity_m86DDB76FC043CF64BF06D9D413F2A12B0A5D83AB (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, const RuntimeMethod* method) 
{
	{
		// get { return _data.Length; }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		NullCheck(L_0);
		return ((int32_t)(((RuntimeArray*)L_0)->max_length));
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter__ctor_m146E2C307B585380552FB2583AC8FFCE97CD9B71 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, const RuntimeMethod* method) 
{
	{
		// public NetDataWriter() : this(true, InitialSize)
		NetDataWriter__ctor_m4693B3955597A9E39B4BE364F76A0499DDEAED24(__this, (bool)1, ((int32_t)64), NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::.ctor(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter__ctor_m40FACC9C433123C2F55D55F113C3E111B3496B78 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, bool ___autoResize0, const RuntimeMethod* method) 
{
	{
		// public NetDataWriter(bool autoResize) : this(autoResize, InitialSize)
		bool L_0 = ___autoResize0;
		NetDataWriter__ctor_m4693B3955597A9E39B4BE364F76A0499DDEAED24(__this, L_0, ((int32_t)64), NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::.ctor(System.Boolean,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter__ctor_m4693B3955597A9E39B4BE364F76A0499DDEAED24 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, bool ___autoResize0, int32_t ___initialSize1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public NetDataWriter(bool autoResize, int initialSize)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// _data = new byte[initialSize];
		int32_t L_0 = ___initialSize1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_0);
		__this->____data_0 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____data_0), (void*)L_1);
		// _autoResize = autoResize;
		bool L_2 = ___autoResize0;
		__this->____autoResize_3 = L_2;
		// }
		return;
	}
}
// FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::FromBytes(System.Byte[],System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* NetDataWriter_FromBytes_mE1B9EF5FE96ED356185B03E66E2C6C31917B5DE8 (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, bool ___copy1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (copy)
		bool L_0 = ___copy1;
		if (!L_0)
		{
			goto IL_0014;
		}
	}
	{
		// var netDataWriter = new NetDataWriter(true, bytes.Length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = ___bytes0;
		NullCheck(L_1);
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_2 = (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA*)il2cpp_codegen_object_new(NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var);
		NullCheck(L_2);
		NetDataWriter__ctor_m4693B3955597A9E39B4BE364F76A0499DDEAED24(L_2, (bool)1, ((int32_t)(((RuntimeArray*)L_1)->max_length)), NULL);
		// netDataWriter.Put(bytes);
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_3 = L_2;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = ___bytes0;
		NullCheck(L_3);
		NetDataWriter_Put_m3D5E4569AAE00E996F2C31B62D003DE00D942184(L_3, L_4, NULL);
		// return netDataWriter;
		return L_3;
	}

IL_0014:
	{
		// return new NetDataWriter(true, 0) {_data = bytes, _position = bytes.Length};
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_5 = (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA*)il2cpp_codegen_object_new(NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var);
		NullCheck(L_5);
		NetDataWriter__ctor_m4693B3955597A9E39B4BE364F76A0499DDEAED24(L_5, (bool)1, 0, NULL);
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_6 = L_5;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = ___bytes0;
		NullCheck(L_6);
		L_6->____data_0 = L_7;
		Il2CppCodeGenWriteBarrier((void**)(&L_6->____data_0), (void*)L_7);
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_8 = L_6;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = ___bytes0;
		NullCheck(L_9);
		NullCheck(L_8);
		L_8->____position_1 = ((int32_t)(((RuntimeArray*)L_9)->max_length));
		return L_8;
	}
}
// FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::FromBytes(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* NetDataWriter_FromBytes_m5AAA1A13ECA81441ABD972AA9CC07432127136AF (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, int32_t ___offset1, int32_t ___length2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// var netDataWriter = new NetDataWriter(true, bytes.Length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___bytes0;
		NullCheck(L_0);
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_1 = (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA*)il2cpp_codegen_object_new(NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var);
		NullCheck(L_1);
		NetDataWriter__ctor_m4693B3955597A9E39B4BE364F76A0499DDEAED24(L_1, (bool)1, ((int32_t)(((RuntimeArray*)L_0)->max_length)), NULL);
		// netDataWriter.Put(bytes, offset, length);
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_2 = L_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___bytes0;
		int32_t L_4 = ___offset1;
		int32_t L_5 = ___length2;
		NullCheck(L_2);
		NetDataWriter_Put_mE912955AE675D8A7F03FEACAAA4F2E467DE3BED5(L_2, L_3, L_4, L_5, NULL);
		// return netDataWriter;
		return L_2;
	}
}
// FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::FromString(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* NetDataWriter_FromString_mCDDBF50534E6292FF9901ED4D33BF389EA0AF2A2 (String_t* ___value0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// var netDataWriter = new NetDataWriter();
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_0 = (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA*)il2cpp_codegen_object_new(NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		NetDataWriter__ctor_m146E2C307B585380552FB2583AC8FFCE97CD9B71(L_0, NULL);
		// netDataWriter.Put(value);
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_1 = L_0;
		String_t* L_2 = ___value0;
		NullCheck(L_1);
		NetDataWriter_Put_mCB88FC274D037CA1454EC1B65FA7E4DC05EA24B2(L_1, L_2, NULL);
		// return netDataWriter;
		return L_1;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::ResizeIfNeed(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, int32_t ___newSize0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Array_Resize_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m82FEC5823560947D2B12C8D675AED2C190DF4F3F_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// int len = _data.Length;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		NullCheck(L_0);
		V_0 = ((int32_t)(((RuntimeArray*)L_0)->max_length));
		// if (len < newSize)
		int32_t L_1 = V_0;
		int32_t L_2 = ___newSize0;
		if ((((int32_t)L_1) >= ((int32_t)L_2)))
		{
			goto IL_0023;
		}
	}
	{
		goto IL_0013;
	}

IL_000f:
	{
		// len *= 2;
		int32_t L_3 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_multiply(L_3, 2));
	}

IL_0013:
	{
		// while (len < newSize)
		int32_t L_4 = V_0;
		int32_t L_5 = ___newSize0;
		if ((((int32_t)L_4) < ((int32_t)L_5)))
		{
			goto IL_000f;
		}
	}
	{
		// Array.Resize(ref _data, len);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_6 = (&__this->____data_0);
		int32_t L_7 = V_0;
		Array_Resize_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m82FEC5823560947D2B12C8D675AED2C190DF4F3F(L_6, L_7, Array_Resize_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m82FEC5823560947D2B12C8D675AED2C190DF4F3F_RuntimeMethod_var);
	}

IL_0023:
	{
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Reset(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Reset_m938B4ED7D460121D58BC7F19262C16E8DE7419CD (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, int32_t ___size0, const RuntimeMethod* method) 
{
	{
		// ResizeIfNeed(size);
		int32_t L_0 = ___size0;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, L_0, NULL);
		// _position = 0;
		__this->____position_1 = 0;
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Reset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Reset_m69EA7248D68C44F08DDBE5FAAE5F87A369923C36 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, const RuntimeMethod* method) 
{
	{
		// _position = 0;
		__this->____position_1 = 0;
		// }
		return;
	}
}
// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::CopyData()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* NetDataWriter_CopyData_m77CE8981C270E0C07B88A13E717DB34BC1FBB8F2 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* V_0 = NULL;
	{
		// byte[] resultData = new byte[_position];
		int32_t L_0 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)L_0);
		V_0 = L_1;
		// Buffer.BlockCopy(_data, 0, resultData, 0, _position);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = V_0;
		int32_t L_4 = __this->____position_1;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_2, 0, (RuntimeArray*)L_3, 0, L_4, NULL);
		// return resultData;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = V_0;
		return L_5;
	}
}
// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::get_Data()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* NetDataWriter_get_Data_m57195A7D8184C5AFAE3D3DEF4069D8AD9A7390AD (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, const RuntimeMethod* method) 
{
	{
		// get { return _data; }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		return L_0;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::get_Length()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataWriter_get_Length_m7947782000AC2E7C7B6152A12F4FCA2064948AEC (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, const RuntimeMethod* method) 
{
	{
		// get { return _position; }
		int32_t L_0 = __this->____position_1;
		return L_0;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::SetPosition(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NetDataWriter_SetPosition_m7542764C9E5AAE8BA3566CE2C4AF8653EE75E247 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, int32_t ___position0, const RuntimeMethod* method) 
{
	{
		// int prevPosition = _position;
		int32_t L_0 = __this->____position_1;
		// _position = position;
		int32_t L_1 = ___position0;
		__this->____position_1 = L_1;
		// return prevPosition;
		return L_0;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Single)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_mC931B541169C156FDB3A27F61F9C0BA067346BDC (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, float ___value0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 4);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 4)), NULL);
	}

IL_0016:
	{
		// FastBitConverter.GetBytes(_data, _position, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		float L_4 = ___value0;
		FastBitConverter_GetBytes_m6B2778DF75A49DC012513A1C0AEC198F165E761C(L_2, L_3, L_4, NULL);
		// _position += 4;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 4));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Double)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_mB4C6F3D165CB5BAFA9BD933217652F5FCA89BBF6 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, double ___value0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 8);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 8)), NULL);
	}

IL_0016:
	{
		// FastBitConverter.GetBytes(_data, _position, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		double L_4 = ___value0;
		FastBitConverter_GetBytes_mBF60A9EB8FD38FFFE8EA1B8B1B5407C4499DD063(L_2, L_3, L_4, NULL);
		// _position += 8;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 8));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Int64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_mE720A5F532ABBD0999BC34E28D8422DA6CEDF630 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, int64_t ___value0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 8);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 8)), NULL);
	}

IL_0016:
	{
		// FastBitConverter.GetBytes(_data, _position, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		int64_t L_4 = ___value0;
		FastBitConverter_GetBytes_m3217BA7AFFB8FC748D049D69CC84FC905D049AA0(L_2, L_3, L_4, NULL);
		// _position += 8;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 8));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m24A30EF5965AF5AD9A5D03733606467660ACAC1B (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, uint64_t ___value0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 8);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 8)), NULL);
	}

IL_0016:
	{
		// FastBitConverter.GetBytes(_data, _position, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		uint64_t L_4 = ___value0;
		FastBitConverter_GetBytes_m9D1EC7459D20F918B45C5ED54DAC7B95CA35F064(L_2, L_3, L_4, NULL);
		// _position += 8;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 8));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m8E5EC9D4DC507B28075C5BCCD2C6E182761BD008 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 4);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 4)), NULL);
	}

IL_0016:
	{
		// FastBitConverter.GetBytes(_data, _position, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		int32_t L_4 = ___value0;
		FastBitConverter_GetBytes_mD6649FCFC54EBFAC500F6647222F8A40B37DF0FD(L_2, L_3, L_4, NULL);
		// _position += 4;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 4));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_mD2E88613FB5DE7AA25A9EF7B3F5ABC07A56032EE (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, uint32_t ___value0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 4);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 4)), NULL);
	}

IL_0016:
	{
		// FastBitConverter.GetBytes(_data, _position, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		uint32_t L_4 = ___value0;
		FastBitConverter_GetBytes_mE205091FC74A54D5580EF718A92652CCCF3FC942(L_2, L_3, L_4, NULL);
		// _position += 4;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 4));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Char)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m6C6521251F58F8AD04437F9E4452B45ACA9B5F7A (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, Il2CppChar ___value0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 2);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 2)), NULL);
	}

IL_0016:
	{
		// FastBitConverter.GetBytes(_data, _position, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		Il2CppChar L_4 = ___value0;
		FastBitConverter_GetBytes_mC6C3C3E1FA097BB0C9E04A5032DBFC51E46FEC79(L_2, L_3, L_4, NULL);
		// _position += 2;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 2));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.UInt16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m0363C535F50B54ADE25B798FE915DD5F44C3E67E (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, uint16_t ___value0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 2);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 2)), NULL);
	}

IL_0016:
	{
		// FastBitConverter.GetBytes(_data, _position, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		uint16_t L_4 = ___value0;
		FastBitConverter_GetBytes_mC6C3C3E1FA097BB0C9E04A5032DBFC51E46FEC79(L_2, L_3, L_4, NULL);
		// _position += 2;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 2));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Int16)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_mE287F34D5347D70F4056DE096641AB9FA559F059 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, int16_t ___value0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 2);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 2)), NULL);
	}

IL_0016:
	{
		// FastBitConverter.GetBytes(_data, _position, value);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		int16_t L_4 = ___value0;
		FastBitConverter_GetBytes_mF3C15486890268B6B1334D47252E3011CEFB2039(L_2, L_3, L_4, NULL);
		// _position += 2;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 2));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.SByte)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m5CDEB2E053C7F06868CDDA4057010515B769AE52 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, int8_t ___value0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 1);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 1)), NULL);
	}

IL_0016:
	{
		// _data[_position] = (byte)value;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		int8_t L_4 = ___value0;
		NullCheck(L_2);
		(L_2)->SetAt(static_cast<il2cpp_array_size_t>(L_3), (uint8_t)((int32_t)(uint8_t)L_4));
		// _position++;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 1));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Byte)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m5FACE51BA7FB5127D677EC985ADAB8F96EA7AF28 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, uint8_t ___value0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 1);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 1)), NULL);
	}

IL_0016:
	{
		// _data[_position] = value;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		uint8_t L_4 = ___value0;
		NullCheck(L_2);
		(L_2)->SetAt(static_cast<il2cpp_array_size_t>(L_3), (uint8_t)L_4);
		// _position++;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 1));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_mE912955AE675D8A7F03FEACAAA4F2E467DE3BED5 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___data0, int32_t ___offset1, int32_t ___length2, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + length);
		int32_t L_1 = __this->____position_1;
		int32_t L_2 = ___length2;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, L_2)), NULL);
	}

IL_0016:
	{
		// Buffer.BlockCopy(data, offset, _data, _position, length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___data0;
		int32_t L_4 = ___offset1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = __this->____data_0;
		int32_t L_6 = __this->____position_1;
		int32_t L_7 = ___length2;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_3, L_4, (RuntimeArray*)L_5, L_6, L_7, NULL);
		// _position += length;
		int32_t L_8 = __this->____position_1;
		int32_t L_9 = ___length2;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_8, L_9));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m3D5E4569AAE00E996F2C31B62D003DE00D942184 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___data0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0018;
		}
	}
	{
		// ResizeIfNeed(_position + data.Length);
		int32_t L_1 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___data0;
		NullCheck(L_2);
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, ((int32_t)(((RuntimeArray*)L_2)->max_length)))), NULL);
	}

IL_0018:
	{
		// Buffer.BlockCopy(data, 0, _data, _position, data.Length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___data0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = __this->____data_0;
		int32_t L_5 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___data0;
		NullCheck(L_6);
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_3, 0, (RuntimeArray*)L_4, L_5, ((int32_t)(((RuntimeArray*)L_6)->max_length)), NULL);
		// _position += data.Length;
		int32_t L_7 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = ___data0;
		NullCheck(L_8);
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_7, ((int32_t)(((RuntimeArray*)L_8)->max_length))));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutSBytesWithLength(System.SByte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutSBytesWithLength_m0A97B2590F3B9EDD8A610F0161A474391952435F (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* ___data0, int32_t ___offset1, int32_t ___length2, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0018;
		}
	}
	{
		// ResizeIfNeed(_position + length + 4);
		int32_t L_1 = __this->____position_1;
		int32_t L_2 = ___length2;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_1, L_2)), 4)), NULL);
	}

IL_0018:
	{
		// FastBitConverter.GetBytes(_data, _position, length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = __this->____data_0;
		int32_t L_4 = __this->____position_1;
		int32_t L_5 = ___length2;
		FastBitConverter_GetBytes_mD6649FCFC54EBFAC500F6647222F8A40B37DF0FD(L_3, L_4, L_5, NULL);
		// Buffer.BlockCopy(data, offset, _data, _position + 4, length);
		SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* L_6 = ___data0;
		int32_t L_7 = ___offset1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = __this->____data_0;
		int32_t L_9 = __this->____position_1;
		int32_t L_10 = ___length2;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, L_7, (RuntimeArray*)L_8, ((int32_t)il2cpp_codegen_add(L_9, 4)), L_10, NULL);
		// _position += length + 4;
		int32_t L_11 = __this->____position_1;
		int32_t L_12 = ___length2;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_11, ((int32_t)il2cpp_codegen_add(L_12, 4))));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutSBytesWithLength(System.SByte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutSBytesWithLength_m9363A1C76EC7AEE397F394B2FF1BA201F212F918 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* ___data0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_001a;
		}
	}
	{
		// ResizeIfNeed(_position + data.Length + 4);
		int32_t L_1 = __this->____position_1;
		SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* L_2 = ___data0;
		NullCheck(L_2);
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_1, ((int32_t)(((RuntimeArray*)L_2)->max_length)))), 4)), NULL);
	}

IL_001a:
	{
		// FastBitConverter.GetBytes(_data, _position, data.Length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = __this->____data_0;
		int32_t L_4 = __this->____position_1;
		SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* L_5 = ___data0;
		NullCheck(L_5);
		FastBitConverter_GetBytes_mD6649FCFC54EBFAC500F6647222F8A40B37DF0FD(L_3, L_4, ((int32_t)(((RuntimeArray*)L_5)->max_length)), NULL);
		// Buffer.BlockCopy(data, 0, _data, _position + 4, data.Length);
		SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* L_6 = ___data0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = __this->____data_0;
		int32_t L_8 = __this->____position_1;
		SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* L_9 = ___data0;
		NullCheck(L_9);
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, 0, (RuntimeArray*)L_7, ((int32_t)il2cpp_codegen_add(L_8, 4)), ((int32_t)(((RuntimeArray*)L_9)->max_length)), NULL);
		// _position += data.Length + 4;
		int32_t L_10 = __this->____position_1;
		SByteU5BU5D_t88116DA68378C3333DB73E7D36C1A06AFAA91913* L_11 = ___data0;
		NullCheck(L_11);
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_10, ((int32_t)il2cpp_codegen_add(((int32_t)(((RuntimeArray*)L_11)->max_length)), 4))));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutBytesWithLength(System.Byte[],System.Int32,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutBytesWithLength_m5A8C52CF6AD80BBEE97B890B01F87726DC2C5F54 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___data0, int32_t ___offset1, int32_t ___length2, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0018;
		}
	}
	{
		// ResizeIfNeed(_position + length + 4);
		int32_t L_1 = __this->____position_1;
		int32_t L_2 = ___length2;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_1, L_2)), 4)), NULL);
	}

IL_0018:
	{
		// FastBitConverter.GetBytes(_data, _position, length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = __this->____data_0;
		int32_t L_4 = __this->____position_1;
		int32_t L_5 = ___length2;
		FastBitConverter_GetBytes_mD6649FCFC54EBFAC500F6647222F8A40B37DF0FD(L_3, L_4, L_5, NULL);
		// Buffer.BlockCopy(data, offset, _data, _position + 4, length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___data0;
		int32_t L_7 = ___offset1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = __this->____data_0;
		int32_t L_9 = __this->____position_1;
		int32_t L_10 = ___length2;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, L_7, (RuntimeArray*)L_8, ((int32_t)il2cpp_codegen_add(L_9, 4)), L_10, NULL);
		// _position += length + 4;
		int32_t L_11 = __this->____position_1;
		int32_t L_12 = ___length2;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_11, ((int32_t)il2cpp_codegen_add(L_12, 4))));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutBytesWithLength(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutBytesWithLength_m86C50373E6DD7EAA604BB28AB8720B818EF5350E (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___data0, const RuntimeMethod* method) 
{
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_001a;
		}
	}
	{
		// ResizeIfNeed(_position + data.Length + 4);
		int32_t L_1 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___data0;
		NullCheck(L_2);
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_1, ((int32_t)(((RuntimeArray*)L_2)->max_length)))), 4)), NULL);
	}

IL_001a:
	{
		// FastBitConverter.GetBytes(_data, _position, data.Length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = __this->____data_0;
		int32_t L_4 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = ___data0;
		NullCheck(L_5);
		FastBitConverter_GetBytes_mD6649FCFC54EBFAC500F6647222F8A40B37DF0FD(L_3, L_4, ((int32_t)(((RuntimeArray*)L_5)->max_length)), NULL);
		// Buffer.BlockCopy(data, 0, _data, _position + 4, data.Length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = ___data0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = __this->____data_0;
		int32_t L_8 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_9 = ___data0;
		NullCheck(L_9);
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_6, 0, (RuntimeArray*)L_7, ((int32_t)il2cpp_codegen_add(L_8, 4)), ((int32_t)(((RuntimeArray*)L_9)->max_length)), NULL);
		// _position += data.Length + 4;
		int32_t L_10 = __this->____position_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = ___data0;
		NullCheck(L_11);
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_10, ((int32_t)il2cpp_codegen_add(((int32_t)(((RuntimeArray*)L_11)->max_length)), 4))));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m8894FF29DBD7FC3952A0D82437C4C701D9F66C16 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, bool ___value0, const RuntimeMethod* method) 
{
	int32_t G_B4_0 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* G_B4_1 = NULL;
	int32_t G_B3_0 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* G_B3_1 = NULL;
	int32_t G_B5_0 = 0;
	int32_t G_B5_1 = 0;
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* G_B5_2 = NULL;
	{
		// if (_autoResize)
		bool L_0 = __this->____autoResize_3;
		if (!L_0)
		{
			goto IL_0016;
		}
	}
	{
		// ResizeIfNeed(_position + 1);
		int32_t L_1 = __this->____position_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(L_1, 1)), NULL);
	}

IL_0016:
	{
		// _data[_position] = (byte)(value ? 1 : 0);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = __this->____data_0;
		int32_t L_3 = __this->____position_1;
		bool L_4 = ___value0;
		G_B3_0 = L_3;
		G_B3_1 = L_2;
		if (L_4)
		{
			G_B4_0 = L_3;
			G_B4_1 = L_2;
			goto IL_0028;
		}
	}
	{
		G_B5_0 = 0;
		G_B5_1 = G_B3_0;
		G_B5_2 = G_B3_1;
		goto IL_0029;
	}

IL_0028:
	{
		G_B5_0 = 1;
		G_B5_1 = G_B4_0;
		G_B5_2 = G_B4_1;
	}

IL_0029:
	{
		NullCheck(G_B5_2);
		(G_B5_2)->SetAt(static_cast<il2cpp_array_size_t>(G_B5_1), (uint8_t)((int32_t)(uint8_t)G_B5_0));
		// _position++;
		int32_t L_5 = __this->____position_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_5, 1));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.Array,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_m48347B1BD5A82113D78A2F53F26B14D533DBCC4C (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, RuntimeArray* ___arr0, int32_t ___sz1, const RuntimeMethod* method) 
{
	uint16_t V_0 = 0;
	int32_t G_B3_0 = 0;
	{
		// ushort length = arr == null ? (ushort) 0 : (ushort)arr.Length;
		RuntimeArray* L_0 = ___arr0;
		if (!L_0)
		{
			goto IL_000c;
		}
	}
	{
		RuntimeArray* L_1 = ___arr0;
		NullCheck(L_1);
		int32_t L_2;
		L_2 = Array_get_Length_m361285FB7CF44045DC369834D1CD01F72F94EF57(L_1, NULL);
		G_B3_0 = ((int32_t)(uint16_t)L_2);
		goto IL_000d;
	}

IL_000c:
	{
		G_B3_0 = 0;
	}

IL_000d:
	{
		V_0 = (uint16_t)G_B3_0;
		// sz *= length;
		int32_t L_3 = ___sz1;
		uint16_t L_4 = V_0;
		___sz1 = ((int32_t)il2cpp_codegen_multiply(L_3, (int32_t)L_4));
		// if (_autoResize)
		bool L_5 = __this->____autoResize_3;
		if (!L_5)
		{
			goto IL_002b;
		}
	}
	{
		// ResizeIfNeed(_position + sz + 2);
		int32_t L_6 = __this->____position_1;
		int32_t L_7 = ___sz1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_6, L_7)), 2)), NULL);
	}

IL_002b:
	{
		// FastBitConverter.GetBytes(_data, _position, length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8 = __this->____data_0;
		int32_t L_9 = __this->____position_1;
		uint16_t L_10 = V_0;
		FastBitConverter_GetBytes_mC6C3C3E1FA097BB0C9E04A5032DBFC51E46FEC79(L_8, L_9, L_10, NULL);
		// if (arr != null)
		RuntimeArray* L_11 = ___arr0;
		if (!L_11)
		{
			goto IL_0056;
		}
	}
	{
		// Buffer.BlockCopy(arr, 0, _data, _position + 2, sz);
		RuntimeArray* L_12 = ___arr0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = __this->____data_0;
		int32_t L_14 = __this->____position_1;
		int32_t L_15 = ___sz1;
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9(L_12, 0, (RuntimeArray*)L_13, ((int32_t)il2cpp_codegen_add(L_14, 2)), L_15, NULL);
	}

IL_0056:
	{
		// _position += sz + 2;
		int32_t L_16 = __this->____position_1;
		int32_t L_17 = ___sz1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_16, ((int32_t)il2cpp_codegen_add(L_17, 2))));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.Single[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_mFA146DC79274C928663816F1815AB1A829743338 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* ___value0, const RuntimeMethod* method) 
{
	{
		// PutArray(value, 4);
		SingleU5BU5D_t89DEFE97BCEDB5857010E79ECE0F52CF6E93B87C* L_0 = ___value0;
		NetDataWriter_PutArray_m48347B1BD5A82113D78A2F53F26B14D533DBCC4C(__this, (RuntimeArray*)L_0, 4, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.Double[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_m91953037F031D128B93BC7D510B1137CC84F9575 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE* ___value0, const RuntimeMethod* method) 
{
	{
		// PutArray(value, 8);
		DoubleU5BU5D_tCC308475BD3B8229DB2582938669EF2F9ECC1FEE* L_0 = ___value0;
		NetDataWriter_PutArray_m48347B1BD5A82113D78A2F53F26B14D533DBCC4C(__this, (RuntimeArray*)L_0, 8, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.Int64[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_mDD88A14061674394B97D0789BB4AF69407700568 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D* ___value0, const RuntimeMethod* method) 
{
	{
		// PutArray(value, 8);
		Int64U5BU5D_tAEDFCBDB5414E2A140A6F34C0538BF97FCF67A1D* L_0 = ___value0;
		NetDataWriter_PutArray_m48347B1BD5A82113D78A2F53F26B14D533DBCC4C(__this, (RuntimeArray*)L_0, 8, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.UInt64[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_m11AE1967E091E2BFD027B0F3C8AD167861ECA1C4 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299* ___value0, const RuntimeMethod* method) 
{
	{
		// PutArray(value, 8);
		UInt64U5BU5D_tAB1A62450AC0899188486EDB9FC066B8BEED9299* L_0 = ___value0;
		NetDataWriter_PutArray_m48347B1BD5A82113D78A2F53F26B14D533DBCC4C(__this, (RuntimeArray*)L_0, 8, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.Int32[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_mD0AEC64ED0D3596F065CBAA668DEF2C024B8B6BA (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___value0, const RuntimeMethod* method) 
{
	{
		// PutArray(value, 4);
		Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* L_0 = ___value0;
		NetDataWriter_PutArray_m48347B1BD5A82113D78A2F53F26B14D533DBCC4C(__this, (RuntimeArray*)L_0, 4, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.UInt32[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_m1BF7F1BEA8D99EC75DC773CDC8432E1744186E90 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* ___value0, const RuntimeMethod* method) 
{
	{
		// PutArray(value, 4);
		UInt32U5BU5D_t02FBD658AD156A17574ECE6106CF1FBFCC9807FA* L_0 = ___value0;
		NetDataWriter_PutArray_m48347B1BD5A82113D78A2F53F26B14D533DBCC4C(__this, (RuntimeArray*)L_0, 4, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.UInt16[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_mC52D2476414A01E71239B205F41686EF63DA09A5 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* ___value0, const RuntimeMethod* method) 
{
	{
		// PutArray(value, 2);
		UInt16U5BU5D_tEB7C42D811D999D2AA815BADC3FCCDD9C67B3F83* L_0 = ___value0;
		NetDataWriter_PutArray_m48347B1BD5A82113D78A2F53F26B14D533DBCC4C(__this, (RuntimeArray*)L_0, 2, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.Int16[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_m15BF14BE1DF89D62B34A238AB64CD48972438289 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB* ___value0, const RuntimeMethod* method) 
{
	{
		// PutArray(value, 2);
		Int16U5BU5D_t8175CE8DD9C9F9FB0CF4F58E45BC570575B43CFB* L_0 = ___value0;
		NetDataWriter_PutArray_m48347B1BD5A82113D78A2F53F26B14D533DBCC4C(__this, (RuntimeArray*)L_0, 2, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.Boolean[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_m5125ECBD28AB78315EC12615315DBBFD3257AFD4 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* ___value0, const RuntimeMethod* method) 
{
	{
		// PutArray(value, 1);
		BooleanU5BU5D_tD317D27C31DB892BE79FAE3AEBC0B3FFB73DE9B4* L_0 = ___value0;
		NetDataWriter_PutArray_m48347B1BD5A82113D78A2F53F26B14D533DBCC4C(__this, (RuntimeArray*)L_0, 1, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.String[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_m2E6E707D514F6B051E9EC14B3B44C5FF6524524F (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___value0, const RuntimeMethod* method) 
{
	uint16_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t G_B3_0 = 0;
	{
		// ushort len = value == null ? (ushort)0 : (ushort)value.Length;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = ___value0;
		if (!L_0)
		{
			goto IL_0009;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = ___value0;
		NullCheck(L_1);
		G_B3_0 = ((int32_t)(uint16_t)((int32_t)(((RuntimeArray*)L_1)->max_length)));
		goto IL_000a;
	}

IL_0009:
	{
		G_B3_0 = 0;
	}

IL_000a:
	{
		V_0 = (uint16_t)G_B3_0;
		// Put(len);
		uint16_t L_2 = V_0;
		NetDataWriter_Put_m0363C535F50B54ADE25B798FE915DD5F44C3E67E(__this, L_2, NULL);
		// for (int i = 0; i < len; i++)
		V_1 = 0;
		goto IL_0023;
	}

IL_0016:
	{
		// Put(value[i]);
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_3 = ___value0;
		int32_t L_4 = V_1;
		NullCheck(L_3);
		int32_t L_5 = L_4;
		String_t* L_6 = (L_3)->GetAt(static_cast<il2cpp_array_size_t>(L_5));
		NetDataWriter_Put_mCB88FC274D037CA1454EC1B65FA7E4DC05EA24B2(__this, L_6, NULL);
		// for (int i = 0; i < len; i++)
		int32_t L_7 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_7, 1));
	}

IL_0023:
	{
		// for (int i = 0; i < len; i++)
		int32_t L_8 = V_1;
		uint16_t L_9 = V_0;
		if ((((int32_t)L_8) < ((int32_t)L_9)))
		{
			goto IL_0016;
		}
	}
	{
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::PutArray(System.String[],System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_PutArray_mD42EE0E16121942D9C21EDCA451FE09BEB124169 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___value0, int32_t ___maxLength1, const RuntimeMethod* method) 
{
	uint16_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t G_B3_0 = 0;
	{
		// ushort len = value == null ? (ushort)0 : (ushort)value.Length;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = ___value0;
		if (!L_0)
		{
			goto IL_0009;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = ___value0;
		NullCheck(L_1);
		G_B3_0 = ((int32_t)(uint16_t)((int32_t)(((RuntimeArray*)L_1)->max_length)));
		goto IL_000a;
	}

IL_0009:
	{
		G_B3_0 = 0;
	}

IL_000a:
	{
		V_0 = (uint16_t)G_B3_0;
		// Put(len);
		uint16_t L_2 = V_0;
		NetDataWriter_Put_m0363C535F50B54ADE25B798FE915DD5F44C3E67E(__this, L_2, NULL);
		// for (int i = 0; i < len; i++)
		V_1 = 0;
		goto IL_0024;
	}

IL_0016:
	{
		// Put(value[i], maxLength);
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_3 = ___value0;
		int32_t L_4 = V_1;
		NullCheck(L_3);
		int32_t L_5 = L_4;
		String_t* L_6 = (L_3)->GetAt(static_cast<il2cpp_array_size_t>(L_5));
		int32_t L_7 = ___maxLength1;
		NetDataWriter_Put_m0D6FB9A38A8E3695AB15F993E07B15B059DCF1C4(__this, L_6, L_7, NULL);
		// for (int i = 0; i < len; i++)
		int32_t L_8 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_8, 1));
	}

IL_0024:
	{
		// for (int i = 0; i < len; i++)
		int32_t L_9 = V_1;
		uint16_t L_10 = V_0;
		if ((((int32_t)L_9) < ((int32_t)L_10)))
		{
			goto IL_0016;
		}
	}
	{
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.Net.IPEndPoint)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m75186052A5590B811EEA68219743DEF8F8C8DA4B (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___endPoint0, const RuntimeMethod* method) 
{
	{
		// Put(endPoint.Address.ToString());
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_0 = ___endPoint0;
		NullCheck(L_0);
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_1;
		L_1 = IPEndPoint_get_Address_m72F783CB76E10E9DBDF680CCC1DAAED201BABB1C_inline(L_0, NULL);
		NullCheck(L_1);
		String_t* L_2;
		L_2 = VirtualFuncInvoker0< String_t* >::Invoke(3 /* System.String System.Object::ToString() */, L_1);
		NetDataWriter_Put_mCB88FC274D037CA1454EC1B65FA7E4DC05EA24B2(__this, L_2, NULL);
		// Put(endPoint.Port);
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_3 = ___endPoint0;
		NullCheck(L_3);
		int32_t L_4;
		L_4 = IPEndPoint_get_Port_mFBE1AF1C9CC7E68A46BF46AD3869CC9DC01CF429_inline(L_3, NULL);
		NetDataWriter_Put_m8E5EC9D4DC507B28075C5BCCD2C6E182761BD008(__this, L_4, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_mCB88FC274D037CA1454EC1B65FA7E4DC05EA24B2 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, String_t* ___value0, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		// if (string.IsNullOrEmpty(value))
		String_t* L_0 = ___value0;
		bool L_1;
		L_1 = String_IsNullOrEmpty_m54CF0907E7C4F3AFB2E796A13DC751ECBB8DB64A(L_0, NULL);
		if (!L_1)
		{
			goto IL_0010;
		}
	}
	{
		// Put(0);
		NetDataWriter_Put_m8E5EC9D4DC507B28075C5BCCD2C6E182761BD008(__this, 0, NULL);
		// return;
		return;
	}

IL_0010:
	{
		// int bytesCount = Encoding.UTF8.GetByteCount(value);
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_2;
		L_2 = Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336(NULL);
		String_t* L_3 = ___value0;
		NullCheck(L_2);
		int32_t L_4;
		L_4 = VirtualFuncInvoker1< int32_t, String_t* >::Invoke(11 /* System.Int32 System.Text.Encoding::GetByteCount(System.String) */, L_2, L_3);
		V_0 = L_4;
		// if (_autoResize)
		bool L_5 = __this->____autoResize_3;
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		// ResizeIfNeed(_position + bytesCount + 4);
		int32_t L_6 = __this->____position_1;
		int32_t L_7 = V_0;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_6, L_7)), 4)), NULL);
	}

IL_0034:
	{
		// Put(bytesCount);
		int32_t L_8 = V_0;
		NetDataWriter_Put_m8E5EC9D4DC507B28075C5BCCD2C6E182761BD008(__this, L_8, NULL);
		// Encoding.UTF8.GetBytes(value, 0, value.Length, _data, _position);
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_9;
		L_9 = Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336(NULL);
		String_t* L_10 = ___value0;
		String_t* L_11 = ___value0;
		NullCheck(L_11);
		int32_t L_12;
		L_12 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_11, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = __this->____data_0;
		int32_t L_14 = __this->____position_1;
		NullCheck(L_9);
		int32_t L_15;
		L_15 = VirtualFuncInvoker5< int32_t, String_t*, int32_t, int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t >::Invoke(18 /* System.Int32 System.Text.Encoding::GetBytes(System.String,System.Int32,System.Int32,System.Byte[],System.Int32) */, L_9, L_10, 0, L_12, L_13, L_14);
		// _position += bytesCount;
		int32_t L_16 = __this->____position_1;
		int32_t L_17 = V_0;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_16, L_17));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetDataWriter::Put(System.String,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetDataWriter_Put_m0D6FB9A38A8E3695AB15F993E07B15B059DCF1C4 (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, String_t* ___value0, int32_t ___maxLength1, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	int32_t G_B5_0 = 0;
	{
		// if (string.IsNullOrEmpty(value))
		String_t* L_0 = ___value0;
		bool L_1;
		L_1 = String_IsNullOrEmpty_m54CF0907E7C4F3AFB2E796A13DC751ECBB8DB64A(L_0, NULL);
		if (!L_1)
		{
			goto IL_0010;
		}
	}
	{
		// Put(0);
		NetDataWriter_Put_m8E5EC9D4DC507B28075C5BCCD2C6E182761BD008(__this, 0, NULL);
		// return;
		return;
	}

IL_0010:
	{
		// int length = value.Length > maxLength ? maxLength : value.Length;
		String_t* L_2 = ___value0;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_2, NULL);
		int32_t L_4 = ___maxLength1;
		if ((((int32_t)L_3) > ((int32_t)L_4)))
		{
			goto IL_0021;
		}
	}
	{
		String_t* L_5 = ___value0;
		NullCheck(L_5);
		int32_t L_6;
		L_6 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_5, NULL);
		G_B5_0 = L_6;
		goto IL_0022;
	}

IL_0021:
	{
		int32_t L_7 = ___maxLength1;
		G_B5_0 = L_7;
	}

IL_0022:
	{
		V_0 = G_B5_0;
		// int bytesCount = Encoding.UTF8.GetByteCount(value);
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_8;
		L_8 = Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336(NULL);
		String_t* L_9 = ___value0;
		NullCheck(L_8);
		int32_t L_10;
		L_10 = VirtualFuncInvoker1< int32_t, String_t* >::Invoke(11 /* System.Int32 System.Text.Encoding::GetByteCount(System.String) */, L_8, L_9);
		V_1 = L_10;
		// if (_autoResize)
		bool L_11 = __this->____autoResize_3;
		if (!L_11)
		{
			goto IL_0047;
		}
	}
	{
		// ResizeIfNeed(_position + bytesCount + 4);
		int32_t L_12 = __this->____position_1;
		int32_t L_13 = V_1;
		NetDataWriter_ResizeIfNeed_m96E42C2BACA605D53DBE8296693F137276E920FC(__this, ((int32_t)il2cpp_codegen_add(((int32_t)il2cpp_codegen_add(L_12, L_13)), 4)), NULL);
	}

IL_0047:
	{
		// Put(bytesCount);
		int32_t L_14 = V_1;
		NetDataWriter_Put_m8E5EC9D4DC507B28075C5BCCD2C6E182761BD008(__this, L_14, NULL);
		// Encoding.UTF8.GetBytes(value, 0, length, _data, _position);
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_15;
		L_15 = Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336(NULL);
		String_t* L_16 = ___value0;
		int32_t L_17 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_18 = __this->____data_0;
		int32_t L_19 = __this->____position_1;
		NullCheck(L_15);
		int32_t L_20;
		L_20 = VirtualFuncInvoker5< int32_t, String_t*, int32_t, int32_t, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, int32_t >::Invoke(18 /* System.Int32 System.Text.Encoding::GetBytes(System.String,System.Int32,System.Int32,System.Byte[],System.Int32) */, L_15, L_16, 0, L_17, L_18, L_19);
		// _position += bytesCount;
		int32_t L_21 = __this->____position_1;
		int32_t L_22 = V_1;
		__this->____position_1 = ((int32_t)il2cpp_codegen_add(L_21, L_22));
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacketProcessor__ctor_m113956990D1B8056DCD1473668423D843058F103 (NetPacketProcessor_tC008551263AC0F46812FF0AE3127ABF0D975E873* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2__ctor_m8EB72C4EC23EFF571DFEDF3AA392DF7D38CB64B4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// private readonly Dictionary<ulong, SubscribeDelegate> _callbacks = new Dictionary<ulong, SubscribeDelegate>();
		Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951* L_0 = (Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951*)il2cpp_codegen_object_new(Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Dictionary_2__ctor_m8EB72C4EC23EFF571DFEDF3AA392DF7D38CB64B4(L_0, Dictionary_2__ctor_m8EB72C4EC23EFF571DFEDF3AA392DF7D38CB64B4_RuntimeMethod_var);
		__this->____callbacks_1 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____callbacks_1), (void*)L_0);
		// private readonly NetDataWriter _netDataWriter = new NetDataWriter();
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_1 = (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA*)il2cpp_codegen_object_new(NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var);
		NullCheck(L_1);
		NetDataWriter__ctor_m146E2C307B585380552FB2583AC8FFCE97CD9B71(L_1, NULL);
		__this->____netDataWriter_2 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____netDataWriter_2), (void*)L_1);
		// public NetPacketProcessor()
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// _netSerializer = new NetSerializer();
		NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9* L_2 = (NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9*)il2cpp_codegen_object_new(NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9_il2cpp_TypeInfo_var);
		NullCheck(L_2);
		NetSerializer__ctor_mAA76478A51CF1FB20AC3BACE500372304165E227(L_2, NULL);
		__this->____netSerializer_0 = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____netSerializer_0), (void*)L_2);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacketProcessor__ctor_m16CD843F8B8DF5401B56F1A99A911247EEFDE241 (NetPacketProcessor_tC008551263AC0F46812FF0AE3127ABF0D975E873* __this, int32_t ___maxStringLength0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2__ctor_m8EB72C4EC23EFF571DFEDF3AA392DF7D38CB64B4_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// private readonly Dictionary<ulong, SubscribeDelegate> _callbacks = new Dictionary<ulong, SubscribeDelegate>();
		Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951* L_0 = (Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951*)il2cpp_codegen_object_new(Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Dictionary_2__ctor_m8EB72C4EC23EFF571DFEDF3AA392DF7D38CB64B4(L_0, Dictionary_2__ctor_m8EB72C4EC23EFF571DFEDF3AA392DF7D38CB64B4_RuntimeMethod_var);
		__this->____callbacks_1 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____callbacks_1), (void*)L_0);
		// private readonly NetDataWriter _netDataWriter = new NetDataWriter();
		NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* L_1 = (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA*)il2cpp_codegen_object_new(NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA_il2cpp_TypeInfo_var);
		NullCheck(L_1);
		NetDataWriter__ctor_m146E2C307B585380552FB2583AC8FFCE97CD9B71(L_1, NULL);
		__this->____netDataWriter_2 = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____netDataWriter_2), (void*)L_1);
		// public NetPacketProcessor(int maxStringLength)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// _netSerializer = new NetSerializer(maxStringLength);
		int32_t L_2 = ___maxStringLength0;
		NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9* L_3 = (NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9*)il2cpp_codegen_object_new(NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9_il2cpp_TypeInfo_var);
		NullCheck(L_3);
		NetSerializer__ctor_mAF76FAA200E47115DA26D4557E06B4D886ED8439(L_3, L_2, NULL);
		__this->____netSerializer_0 = L_3;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____netSerializer_0), (void*)L_3);
		// }
		return;
	}
}
// FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::GetCallbackFromData(FlyingWormConsole3.LiteNetLib.Utils.NetDataReader)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* NetPacketProcessor_GetCallbackFromData_m4CA0F0219BE90B2EEBCED623E0B4F4A3066E8F8B (NetPacketProcessor_tC008551263AC0F46812FF0AE3127ABF0D975E873* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_TryGetValue_mB702FBA6DE5A2796549B6AB3BAB29390901942C2_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	uint64_t V_0 = 0;
	SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* V_1 = NULL;
	{
		// var hash = reader.GetULong();
		NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* L_0 = ___reader0;
		NullCheck(L_0);
		uint64_t L_1;
		L_1 = NetDataReader_GetULong_mEDAAFDA63ECC73E4FFFD0557116F0C80DE08C8A2(L_0, NULL);
		V_0 = L_1;
		// if (!_callbacks.TryGetValue(hash, out action))
		Dictionary_2_t6807DB8035F7D75619945D5CF2CA9EB20F27B951* L_2 = __this->____callbacks_1;
		uint64_t L_3 = V_0;
		NullCheck(L_2);
		bool L_4;
		L_4 = Dictionary_2_TryGetValue_mB702FBA6DE5A2796549B6AB3BAB29390901942C2(L_2, L_3, (&V_1), Dictionary_2_TryGetValue_mB702FBA6DE5A2796549B6AB3BAB29390901942C2_RuntimeMethod_var);
		if (L_4)
		{
			goto IL_0022;
		}
	}
	{
		// throw new ParseException("Undefined packet in NetDataReader");
		ParseException_tE9D15FFE30722D3687DD4C6333903C530E2D0261* L_5 = (ParseException_tE9D15FFE30722D3687DD4C6333903C530E2D0261*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ParseException_tE9D15FFE30722D3687DD4C6333903C530E2D0261_il2cpp_TypeInfo_var)));
		NullCheck(L_5);
		ParseException__ctor_m8ED6DE7E0C569D47FFBCC0CEFB36054B89887A89(L_5, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral54CC87BDCC203DBF3D08732C8F6B081BD50E7D62)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NetPacketProcessor_GetCallbackFromData_m4CA0F0219BE90B2EEBCED623E0B4F4A3066E8F8B_RuntimeMethod_var)));
	}

IL_0022:
	{
		// return action;
		SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* L_6 = V_1;
		return L_6;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::ReadAllPackets(FlyingWormConsole3.LiteNetLib.Utils.NetDataReader)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacketProcessor_ReadAllPackets_m6A24CA979A47DDF737D3220340C32F7677C2E852 (NetPacketProcessor_tC008551263AC0F46812FF0AE3127ABF0D975E873* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, const RuntimeMethod* method) 
{
	{
		goto IL_0009;
	}

IL_0002:
	{
		// ReadPacket(reader);
		NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* L_0 = ___reader0;
		NetPacketProcessor_ReadPacket_m206C9605EF5B79980E88806C62B9EC7D5615F283(__this, L_0, NULL);
	}

IL_0009:
	{
		// while (reader.AvailableBytes > 0)
		NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* L_1 = ___reader0;
		NullCheck(L_1);
		int32_t L_2;
		L_2 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(L_1, NULL);
		if ((((int32_t)L_2) > ((int32_t)0)))
		{
			goto IL_0002;
		}
	}
	{
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::ReadAllPackets(FlyingWormConsole3.LiteNetLib.Utils.NetDataReader,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacketProcessor_ReadAllPackets_m1E94D90E81D38972B4370BBC4A166F53247C7A54 (NetPacketProcessor_tC008551263AC0F46812FF0AE3127ABF0D975E873* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method) 
{
	{
		goto IL_000a;
	}

IL_0002:
	{
		// ReadPacket(reader, userData);
		NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* L_0 = ___reader0;
		RuntimeObject* L_1 = ___userData1;
		NetPacketProcessor_ReadPacket_m2B71725B7C1227473CF780FD9A915A2244FBC4CD(__this, L_0, L_1, NULL);
	}

IL_000a:
	{
		// while (reader.AvailableBytes > 0)
		NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* L_2 = ___reader0;
		NullCheck(L_2);
		int32_t L_3;
		L_3 = NetDataReader_get_AvailableBytes_mEAD8A8298CE466798B70127938933B28C2613A9D(L_2, NULL);
		if ((((int32_t)L_3) > ((int32_t)0)))
		{
			goto IL_0002;
		}
	}
	{
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::ReadPacket(FlyingWormConsole3.LiteNetLib.Utils.NetDataReader)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacketProcessor_ReadPacket_m206C9605EF5B79980E88806C62B9EC7D5615F283 (NetPacketProcessor_tC008551263AC0F46812FF0AE3127ABF0D975E873* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, const RuntimeMethod* method) 
{
	{
		// ReadPacket(reader, null);
		NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* L_0 = ___reader0;
		NetPacketProcessor_ReadPacket_m2B71725B7C1227473CF780FD9A915A2244FBC4CD(__this, L_0, NULL, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::ReadPacket(FlyingWormConsole3.LiteNetLib.Utils.NetDataReader,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetPacketProcessor_ReadPacket_m2B71725B7C1227473CF780FD9A915A2244FBC4CD (NetPacketProcessor_tC008551263AC0F46812FF0AE3127ABF0D975E873* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method) 
{
	{
		// GetCallbackFromData(reader)(reader, userData);
		NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* L_0 = ___reader0;
		SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* L_1;
		L_1 = VirtualFuncInvoker1< SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5*, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* >::Invoke(5 /* FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor::GetCallbackFromData(FlyingWormConsole3.LiteNetLib.Utils.NetDataReader) */, __this, L_0);
		NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* L_2 = ___reader0;
		RuntimeObject* L_3 = ___userData1;
		NullCheck(L_1);
		SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_inline(L_1, L_2, L_3, NULL);
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_Multicast(SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates_13->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates_13->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* currentDelegate = reinterpret_cast<SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54*, RuntimeObject*, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl_1)((Il2CppObject*)currentDelegate->___method_code_6, ___reader0, ___userData1, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method_3));
	}
}
void SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_Open(SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54*, RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr_0)(___reader0, ___userData1, method);
}
void SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_OpenStaticInvoker(SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method)
{
	InvokerActionInvoker2< NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54*, RuntimeObject* >::Invoke(__this->___method_ptr_0, method, NULL, ___reader0, ___userData1);
}
void SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_ClosedStaticInvoker(SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method)
{
	InvokerActionInvoker3< RuntimeObject*, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54*, RuntimeObject* >::Invoke(__this->___method_ptr_0, method, NULL, __this->___m_target_2, ___reader0, ___userData1);
}
void SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_OpenVirtual(SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method)
{
	VirtualActionInvoker1< RuntimeObject* >::Invoke(il2cpp_codegen_method_get_slot(method), ___reader0, ___userData1);
}
void SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_OpenInterface(SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method)
{
	InterfaceActionInvoker1< RuntimeObject* >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___reader0, ___userData1);
}
void SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_OpenGenericVirtual(SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method)
{
	GenericVirtualActionInvoker1< RuntimeObject* >::Invoke(method, ___reader0, ___userData1);
}
void SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_OpenGenericInterface(SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method)
{
	GenericInterfaceActionInvoker1< RuntimeObject* >::Invoke(method, ___reader0, ___userData1);
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate::.ctor(System.Object,System.IntPtr)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SubscribeDelegate__ctor_mB394EE9493ADC094238BB62095FD734D396046E6 (SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, RuntimeObject* ___object0, intptr_t ___method1, const RuntimeMethod* method) 
{
	__this->___method_ptr_0 = il2cpp_codegen_get_virtual_call_method_pointer((RuntimeMethod*)___method1);
	__this->___method_3 = ___method1;
	__this->___m_target_2 = ___object0;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target_2), (void*)___object0);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___method1);
	__this->___method_code_6 = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___method1))
	{
		bool isOpen = parameterCount == 2;
		if (il2cpp_codegen_call_method_via_invoker((RuntimeMethod*)___method1))
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_OpenStaticInvoker;
			else
				__this->___invoke_impl_1 = (intptr_t)&SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_ClosedStaticInvoker;
		else
			if (isOpen)
				__this->___invoke_impl_1 = (intptr_t)&SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_Open;
			else
				{
					__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
					__this->___method_code_6 = (intptr_t)__this->___m_target_2;
				}
	}
	else
	{
		bool isOpen = parameterCount == 1;
		if (isOpen)
		{
			if (__this->___method_is_virtual_12)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___method1))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_OpenGenericInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___method1))
						__this->___invoke_impl_1 = (intptr_t)&SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_OpenInterface;
					else
						__this->___invoke_impl_1 = (intptr_t)&SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl_1 = (intptr_t)&SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_Open;
			}
		}
		else
		{
			__this->___invoke_impl_1 = (intptr_t)__this->___method_ptr_0;
			__this->___method_code_6 = (intptr_t)__this->___m_target_2;
		}
	}
	__this->___extra_arg_5 = (intptr_t)&SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_Multicast;
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate::Invoke(FlyingWormConsole3.LiteNetLib.Utils.NetDataReader,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1 (SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54*, RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___reader0, ___userData1, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
// System.IAsyncResult FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate::BeginInvoke(FlyingWormConsole3.LiteNetLib.Utils.NetDataReader,System.Object,System.AsyncCallback,System.Object)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* SubscribeDelegate_BeginInvoke_m0C85520AA276CC7C68D6E45EF7609882772D92DF (SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, AsyncCallback_t7FEF460CBDCFB9C5FA2EF776984778B9A4145F4C* ___callback2, RuntimeObject* ___object3, const RuntimeMethod* method) 
{
	void *__d_args[3] = {0};
	__d_args[0] = ___reader0;
	__d_args[1] = ___userData1;
	return (RuntimeObject*)il2cpp_codegen_delegate_begin_invoke((RuntimeDelegate*)__this, __d_args, (RuntimeDelegate*)___callback2, (RuntimeObject*)___object3);
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetPacketProcessor/SubscribeDelegate::EndInvoke(System.IAsyncResult)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SubscribeDelegate_EndInvoke_m05546105A4D521DA0FD773C281126284A36B89D9 (SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, RuntimeObject* ___result0, const RuntimeMethod* method) 
{
	il2cpp_codegen_delegate_end_invoke((Il2CppAsyncResult*) ___result0, 0);
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.Utils.InvalidTypeException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void InvalidTypeException__ctor_m42C7AA991086D3DBE7EB38972E7141F55C4F10DA (InvalidTypeException_t79DD32863BA9B2D1CE6C8E068D8E97ADABA8C741* __this, String_t* ___message0, const RuntimeMethod* method) 
{
	{
		// public InvalidTypeException(string message) : base(message) { }
		String_t* L_0 = ___message0;
		ArgumentException__ctor_m026938A67AF9D36BB7ED27F80425D7194B514465(__this, L_0, NULL);
		// public InvalidTypeException(string message) : base(message) { }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.Utils.ParseException::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ParseException__ctor_m8ED6DE7E0C569D47FFBCC0CEFB36054B89887A89 (ParseException_tE9D15FFE30722D3687DD4C6333903C530E2D0261* __this, String_t* ___message0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Exception_t_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public ParseException(string message) : base(message) { }
		String_t* L_0 = ___message0;
		il2cpp_codegen_runtime_class_init_inline(Exception_t_il2cpp_TypeInfo_var);
		Exception__ctor_m9B2BD92CD68916245A75109105D9071C9D430E7F(__this, L_0, NULL);
		// public ParseException(string message) : base(message) { }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetSerializer::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSerializer__ctor_mAA76478A51CF1FB20AC3BACE500372304165E227 (NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9* __this, const RuntimeMethod* method) 
{
	{
		// public NetSerializer() : this(0)
		NetSerializer__ctor_mAF76FAA200E47115DA26D4557E06B4D886ED8439(__this, 0, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetSerializer::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NetSerializer__ctor_mAF76FAA200E47115DA26D4557E06B4D886ED8439 (NetSerializer_t2896D72EDD6FC4CDBA25C7662518425CA25035F9* __this, int32_t ___maxStringLength0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2__ctor_m18669342C6857F217E5625EA0AD8ED2DD525FBB5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_t5EE36A10F9DEF39A9016F3998D768275F9B3C326_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// private readonly Dictionary<Type, CustomType> _registeredTypes = new Dictionary<Type, CustomType>();
		Dictionary_2_t5EE36A10F9DEF39A9016F3998D768275F9B3C326* L_0 = (Dictionary_2_t5EE36A10F9DEF39A9016F3998D768275F9B3C326*)il2cpp_codegen_object_new(Dictionary_2_t5EE36A10F9DEF39A9016F3998D768275F9B3C326_il2cpp_TypeInfo_var);
		NullCheck(L_0);
		Dictionary_2__ctor_m18669342C6857F217E5625EA0AD8ED2DD525FBB5(L_0, Dictionary_2__ctor_m18669342C6857F217E5625EA0AD8ED2DD525FBB5_RuntimeMethod_var);
		__this->____registeredTypes_2 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____registeredTypes_2), (void*)L_0);
		// public NetSerializer(int maxStringLength)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// _maxStringLength = maxStringLength;
		int32_t L_1 = ___maxStringLength0;
		__this->____maxStringLength_1 = L_1;
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NetSerializer/CustomType::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void CustomType__ctor_mE990ECEC41503B4B32919261DCDEBA2EF042635C (CustomType_t4542089B28CECEEA8A877EDA8CE931EFE7ADB166* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Byte[] FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_Bytes()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public byte[] Bytes { get; private set; }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->___U3CBytesU3Ek__BackingField_1;
		return L_0;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::set_Bytes(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_set_Bytes_m5DB6D8A635A7BEBA520F0509B46508BB6C42BF37 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, const RuntimeMethod* method) 
{
	{
		// public byte[] Bytes { get; private set; }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___value0;
		__this->___U3CBytesU3Ek__BackingField_1 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CBytesU3Ek__BackingField_1), (void*)L_0);
		return;
	}
}
// FlyingWormConsole3.LiteNetLib.Utils.NtpLeapIndicator FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_LeapIndicator()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_get_LeapIndicator_mE780E5229CFAF4136F83BB6FE32C44F468F52F74 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// get { return (NtpLeapIndicator)((Bytes[0] & 0xC0) >> 6); }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0;
		L_0 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		NullCheck(L_0);
		int32_t L_1 = 0;
		uint8_t L_2 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_1));
		return (int32_t)(((int32_t)(((int32_t)((int32_t)L_2&((int32_t)192)))>>6)));
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_VersionNumber()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_get_VersionNumber_m347EE1EAF30F02BDEA43D5F8FBFEE852154894F8 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// get { return (Bytes[0] & 0x38) >> 3; }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0;
		L_0 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		NullCheck(L_0);
		int32_t L_1 = 0;
		uint8_t L_2 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_1));
		return ((int32_t)(((int32_t)((int32_t)L_2&((int32_t)56)))>>3));
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::set_VersionNumber(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_set_VersionNumber_mCD751D64904F8310FA57DF1CA1FADB5459803694 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		// private set { Bytes[0] = (byte)((Bytes[0] & ~0x38) | value << 3); }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0;
		L_0 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1;
		L_1 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		NullCheck(L_1);
		int32_t L_2 = 0;
		uint8_t L_3 = (L_1)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		int32_t L_4 = ___value0;
		NullCheck(L_0);
		(L_0)->SetAt(static_cast<il2cpp_array_size_t>(0), (uint8_t)((int32_t)(uint8_t)((int32_t)(((int32_t)((int32_t)L_3&((int32_t)-57)))|((int32_t)(L_4<<3))))));
		// private set { Bytes[0] = (byte)((Bytes[0] & ~0x38) | value << 3); }
		return;
	}
}
// FlyingWormConsole3.LiteNetLib.Utils.NtpMode FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_Mode()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_get_Mode_m87035DFF507EDCB50A20ACBED4E96C6B81685A82 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// get { return (NtpMode)(Bytes[0] & 0x07); }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0;
		L_0 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		NullCheck(L_0);
		int32_t L_1 = 0;
		uint8_t L_2 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_1));
		return (int32_t)(((int32_t)((int32_t)L_2&7)));
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::set_Mode(FlyingWormConsole3.LiteNetLib.Utils.NtpMode)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_set_Mode_m1B6AB1ECACD207C0CB5D7EF156D4A8C812C6461A (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		// private set { Bytes[0] = (byte)((Bytes[0] & ~0x07) | (int)value); }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0;
		L_0 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1;
		L_1 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		NullCheck(L_1);
		int32_t L_2 = 0;
		uint8_t L_3 = (L_1)->GetAt(static_cast<il2cpp_array_size_t>(L_2));
		int32_t L_4 = ___value0;
		NullCheck(L_0);
		(L_0)->SetAt(static_cast<il2cpp_array_size_t>(0), (uint8_t)((int32_t)(uint8_t)((int32_t)(((int32_t)((int32_t)L_3&((int32_t)-8)))|(int32_t)L_4))));
		// private set { Bytes[0] = (byte)((Bytes[0] & ~0x07) | (int)value); }
		return;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_Stratum()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_get_Stratum_mC9D6B92A3A8F7C614C6F516917C7465C962E2D57 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public int Stratum { get { return Bytes[1]; } }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0;
		L_0 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		NullCheck(L_0);
		int32_t L_1 = 1;
		uint8_t L_2 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_1));
		return L_2;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_Poll()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_get_Poll_m49BBA6896D3252B38DCA3F01CD37B36BDCFEF586 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public int Poll { get { return Bytes[2]; } }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0;
		L_0 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		NullCheck(L_0);
		int32_t L_1 = 2;
		uint8_t L_2 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_1));
		return L_2;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_Precision()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_get_Precision_m9C4DF408DECF06DD0655C4DA2FA7AE0B60A54913 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public int Precision { get { return (sbyte)Bytes[3]; } }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0;
		L_0 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		NullCheck(L_0);
		int32_t L_1 = 3;
		uint8_t L_2 = (L_0)->GetAt(static_cast<il2cpp_array_size_t>(L_1));
		return ((int8_t)L_2);
	}
}
// System.TimeSpan FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_RootDelay()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A NtpPacket_get_RootDelay_m76DB4CCC656A3A1251ED2F73F6A3A174F5FE9374 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public TimeSpan RootDelay { get { return GetTimeSpan32(4); } }
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_0;
		L_0 = NtpPacket_GetTimeSpan32_mB1470558FF64457DC2A58DEFA8316D51F191C7A2(__this, 4, NULL);
		return L_0;
	}
}
// System.TimeSpan FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_RootDispersion()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A NtpPacket_get_RootDispersion_m9D5701246E59CB86C0618224C0856C3413400B27 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public TimeSpan RootDispersion { get { return GetTimeSpan32(8); } }
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_0;
		L_0 = NtpPacket_GetTimeSpan32_mB1470558FF64457DC2A58DEFA8316D51F191C7A2(__this, 8, NULL);
		return L_0;
	}
}
// System.UInt32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_ReferenceId()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t NtpPacket_get_ReferenceId_mB909F1CBCCFB444CE0A51409253BA41B220EF087 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public uint ReferenceId { get { return GetUInt32BE(12); } }
		uint32_t L_0;
		L_0 = NtpPacket_GetUInt32BE_m46AA79D2DE54C64DE667B3CF89F5E6E4595B4780(__this, ((int32_t)12), NULL);
		return L_0;
	}
}
// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_ReferenceTimestamp()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_get_ReferenceTimestamp_m8FE7074B76FE59BA6BD430D2E0DDFCBEF3F06682 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public DateTime? ReferenceTimestamp { get { return GetDateTime64(16); } }
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0;
		L_0 = NtpPacket_GetDateTime64_m0C883DDC0D399BA2A28321B6FF4B1490EF94C214(__this, ((int32_t)16), NULL);
		return L_0;
	}
}
// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_OriginTimestamp()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_get_OriginTimestamp_m197B753E1FB93333A8C71E80FB00F5956A831934 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public DateTime? OriginTimestamp { get { return GetDateTime64(24); } }
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0;
		L_0 = NtpPacket_GetDateTime64_m0C883DDC0D399BA2A28321B6FF4B1490EF94C214(__this, ((int32_t)24), NULL);
		return L_0;
	}
}
// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_ReceiveTimestamp()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_get_ReceiveTimestamp_m28518CC74140DFEDBA65A56700161E922AFF68B1 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public DateTime? ReceiveTimestamp { get { return GetDateTime64(32); } }
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0;
		L_0 = NtpPacket_GetDateTime64_m0C883DDC0D399BA2A28321B6FF4B1490EF94C214(__this, ((int32_t)32), NULL);
		return L_0;
	}
}
// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_TransmitTimestamp()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_get_TransmitTimestamp_m44347BB393BE6B6E0562BC198C467E2BBD1F458B (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public DateTime? TransmitTimestamp { get { return GetDateTime64(40); } private set { SetDateTime64(40, value); } }
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0;
		L_0 = NtpPacket_GetDateTime64_m0C883DDC0D399BA2A28321B6FF4B1490EF94C214(__this, ((int32_t)40), NULL);
		return L_0;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::set_TransmitTimestamp(System.Nullable`1<System.DateTime>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_set_TransmitTimestamp_mAC3742940FC5B29A1890993B55B14A934774A70E (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC ___value0, const RuntimeMethod* method) 
{
	{
		// public DateTime? TransmitTimestamp { get { return GetDateTime64(40); } private set { SetDateTime64(40, value); } }
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0 = ___value0;
		NtpPacket_SetDateTime64_m7BE5278F49B27CC52BDBB252ED4E24640A3BBB17(__this, ((int32_t)40), L_0, NULL);
		// public DateTime? TransmitTimestamp { get { return GetDateTime64(40); } private set { SetDateTime64(40, value); } }
		return;
	}
}
// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_DestinationTimestamp()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_get_DestinationTimestamp_mE42F8228932E2256F3F9FF2181059183172B2A9F (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public DateTime? DestinationTimestamp { get; private set; }
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0 = __this->___U3CDestinationTimestampU3Ek__BackingField_2;
		return L_0;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::set_DestinationTimestamp(System.Nullable`1<System.DateTime>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_set_DestinationTimestamp_mAA50539DD3E9E8D85DEE9E64F3D153570F065FB1 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC ___value0, const RuntimeMethod* method) 
{
	{
		// public DateTime? DestinationTimestamp { get; private set; }
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0 = ___value0;
		__this->___U3CDestinationTimestampU3Ek__BackingField_2 = L_0;
		return;
	}
}
// System.TimeSpan FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_RoundTripTime()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A NtpPacket_get_RoundTripTime_mE164C1B4D76144D37802CD43AB2A5001624D08E7 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// CheckTimestamps();
		NtpPacket_CheckTimestamps_m3CCEBF5C7B0D0BCA9F164E284A27360D31FAF2A4(__this, NULL);
		// return (ReceiveTimestamp.Value - OriginTimestamp.Value) + (DestinationTimestamp.Value - TransmitTimestamp.Value);
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0;
		L_0 = NtpPacket_get_ReceiveTimestamp_m28518CC74140DFEDBA65A56700161E922AFF68B1(__this, NULL);
		V_0 = L_0;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_1;
		L_1 = Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991((&V_0), Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_2;
		L_2 = NtpPacket_get_OriginTimestamp_m197B753E1FB93333A8C71E80FB00F5956A831934(__this, NULL);
		V_0 = L_2;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_3;
		L_3 = Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991((&V_0), Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		il2cpp_codegen_runtime_class_init_inline(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_4;
		L_4 = DateTime_op_Subtraction_m41335EF0E6DCD52B23C64916CB973A0B4A9E0387(L_1, L_3, NULL);
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_5;
		L_5 = NtpPacket_get_DestinationTimestamp_mE42F8228932E2256F3F9FF2181059183172B2A9F_inline(__this, NULL);
		V_0 = L_5;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_6;
		L_6 = Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991((&V_0), Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_7;
		L_7 = NtpPacket_get_TransmitTimestamp_m44347BB393BE6B6E0562BC198C467E2BBD1F458B(__this, NULL);
		V_0 = L_7;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_8;
		L_8 = Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991((&V_0), Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_9;
		L_9 = DateTime_op_Subtraction_m41335EF0E6DCD52B23C64916CB973A0B4A9E0387(L_6, L_8, NULL);
		il2cpp_codegen_runtime_class_init_inline(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_10;
		L_10 = TimeSpan_op_Addition_m4CA781FA121EB39944AE59C6BDD9304C42E74DFB(L_4, L_9, NULL);
		return L_10;
	}
}
// System.TimeSpan FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::get_CorrectionOffset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A NtpPacket_get_CorrectionOffset_mB935614AA9CFA7665C1C20C98E94CADC5005B0C0 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC V_0;
	memset((&V_0), 0, sizeof(V_0));
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A V_1;
	memset((&V_1), 0, sizeof(V_1));
	{
		// CheckTimestamps();
		NtpPacket_CheckTimestamps_m3CCEBF5C7B0D0BCA9F164E284A27360D31FAF2A4(__this, NULL);
		// return TimeSpan.FromTicks(((ReceiveTimestamp.Value - OriginTimestamp.Value) - (DestinationTimestamp.Value - TransmitTimestamp.Value)).Ticks / 2);
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0;
		L_0 = NtpPacket_get_ReceiveTimestamp_m28518CC74140DFEDBA65A56700161E922AFF68B1(__this, NULL);
		V_0 = L_0;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_1;
		L_1 = Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991((&V_0), Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_2;
		L_2 = NtpPacket_get_OriginTimestamp_m197B753E1FB93333A8C71E80FB00F5956A831934(__this, NULL);
		V_0 = L_2;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_3;
		L_3 = Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991((&V_0), Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		il2cpp_codegen_runtime_class_init_inline(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_4;
		L_4 = DateTime_op_Subtraction_m41335EF0E6DCD52B23C64916CB973A0B4A9E0387(L_1, L_3, NULL);
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_5;
		L_5 = NtpPacket_get_DestinationTimestamp_mE42F8228932E2256F3F9FF2181059183172B2A9F_inline(__this, NULL);
		V_0 = L_5;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_6;
		L_6 = Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991((&V_0), Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_7;
		L_7 = NtpPacket_get_TransmitTimestamp_m44347BB393BE6B6E0562BC198C467E2BBD1F458B(__this, NULL);
		V_0 = L_7;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_8;
		L_8 = Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991((&V_0), Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_9;
		L_9 = DateTime_op_Subtraction_m41335EF0E6DCD52B23C64916CB973A0B4A9E0387(L_6, L_8, NULL);
		il2cpp_codegen_runtime_class_init_inline(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_10;
		L_10 = TimeSpan_op_Subtraction_mFFB8933364C5E1E2187CA0605445893F2872FBB8(L_4, L_9, NULL);
		V_1 = L_10;
		int64_t L_11;
		L_11 = TimeSpan_get_Ticks_mC50131E57621F29FACC53B3241432ABB874FA1B5_inline((&V_1), NULL);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_12;
		L_12 = TimeSpan_FromTicks_mFA529928E79B4BF5EC0265418844B196D8979A73(((int64_t)(L_11/((int64_t)2))), NULL);
		return L_12;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket__ctor_m443C2A6A5BA9A9172E59F1BC1B9C5DE485E5B2E7 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// public NtpPacket() : this(new byte[48])
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)48));
		NtpPacket__ctor_m960562C86ECE0569F0E3D017222FD6E8DC9AAD31(__this, L_0, NULL);
		// Mode = NtpMode.Client;
		NtpPacket_set_Mode_m1B6AB1ECACD207C0CB5D7EF156D4A8C812C6461A(__this, 3, NULL);
		// VersionNumber = 4;
		NtpPacket_set_VersionNumber_mCD751D64904F8310FA57DF1CA1FADB5459803694(__this, 4, NULL);
		// TransmitTimestamp = DateTime.UtcNow;
		il2cpp_codegen_runtime_class_init_inline(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_il2cpp_TypeInfo_var);
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_1;
		L_1 = DateTime_get_UtcNow_m5D776FFEBC81592B361E4C7AF373297C5DFB46FD(NULL);
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_2;
		memset((&L_2), 0, sizeof(L_2));
		Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF((&L_2), L_1, /*hidden argument*/Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF_RuntimeMethod_var);
		NtpPacket_set_TransmitTimestamp_mAC3742940FC5B29A1890993B55B14A934774A70E(__this, L_2, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::.ctor(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket__ctor_m960562C86ECE0569F0E3D017222FD6E8DC9AAD31 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, const RuntimeMethod* method) 
{
	{
		// internal NtpPacket(byte[] bytes)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// if (bytes.Length < 48)
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___bytes0;
		NullCheck(L_0);
		if ((((int32_t)((int32_t)(((RuntimeArray*)L_0)->max_length))) >= ((int32_t)((int32_t)48))))
		{
			goto IL_001d;
		}
	}
	{
		// throw new ArgumentException("SNTP reply packet must be at least 48 bytes long.", "bytes");
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_1 = (ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)));
		NullCheck(L_1);
		ArgumentException__ctor_m8F9D40CE19D19B698A70F9A258640EB52DB39B62(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral6A616A2BD726354344808434F427B73FA98BDD24)), ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral77B615B8ED1ABB8FC1395D85A5AE524A9789D947)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket__ctor_m960562C86ECE0569F0E3D017222FD6E8DC9AAD31_RuntimeMethod_var)));
	}

IL_001d:
	{
		// Bytes = bytes;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___bytes0;
		NtpPacket_set_Bytes_m5DB6D8A635A7BEBA520F0509B46508BB6C42BF37_inline(__this, L_2, NULL);
		// }
		return;
	}
}
// FlyingWormConsole3.LiteNetLib.Utils.NtpPacket FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::FromServerResponse(System.Byte[],System.DateTime)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* NtpPacket_FromServerResponse_m4CB7A1AF3F76DE3F1C27F55BCE5944FD3530F44B (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___bytes0, DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___destinationTimestamp1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return new NtpPacket(bytes) { DestinationTimestamp = destinationTimestamp };
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___bytes0;
		NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* L_1 = (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA*)il2cpp_codegen_object_new(NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		NullCheck(L_1);
		NtpPacket__ctor_m960562C86ECE0569F0E3D017222FD6E8DC9AAD31(L_1, L_0, NULL);
		NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* L_2 = L_1;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_3 = ___destinationTimestamp1;
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_4;
		memset((&L_4), 0, sizeof(L_4));
		Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF((&L_4), L_3, /*hidden argument*/Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF_RuntimeMethod_var);
		NullCheck(L_2);
		NtpPacket_set_DestinationTimestamp_mAA50539DD3E9E8D85DEE9E64F3D153570F065FB1_inline(L_2, L_4, NULL);
		return L_2;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::ValidateRequest()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_ValidateRequest_m6071DCC338700F7187D68393D565E6F73C366E2F (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// if (Mode != NtpMode.Client)
		int32_t L_0;
		L_0 = NtpPacket_get_Mode_m87035DFF507EDCB50A20ACBED4E96C6B81685A82(__this, NULL);
		if ((((int32_t)L_0) == ((int32_t)3)))
		{
			goto IL_0014;
		}
	}
	{
		// throw new InvalidOperationException("This is not a request SNTP packet.");
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_1 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_1);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralA9FFA609F3AF81CBA0BEF31B92E98F7C0B64DA06)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket_ValidateRequest_m6071DCC338700F7187D68393D565E6F73C366E2F_RuntimeMethod_var)));
	}

IL_0014:
	{
		// if (VersionNumber == 0)
		int32_t L_2;
		L_2 = NtpPacket_get_VersionNumber_m347EE1EAF30F02BDEA43D5F8FBFEE852154894F8(__this, NULL);
		if (L_2)
		{
			goto IL_0027;
		}
	}
	{
		// throw new InvalidOperationException("Protocol version of the request is not specified.");
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_3 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_3);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_3, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral868EE9733DC26168EACBAC88A44D9E3DE178486F)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_3, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket_ValidateRequest_m6071DCC338700F7187D68393D565E6F73C366E2F_RuntimeMethod_var)));
	}

IL_0027:
	{
		// if (TransmitTimestamp == null)
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_4;
		L_4 = NtpPacket_get_TransmitTimestamp_m44347BB393BE6B6E0562BC198C467E2BBD1F458B(__this, NULL);
		V_0 = L_4;
		bool L_5;
		L_5 = Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_inline((&V_0), Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_RuntimeMethod_var);
		if (L_5)
		{
			goto IL_0042;
		}
	}
	{
		// throw new InvalidOperationException("TransmitTimestamp must be set in request packet.");
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_6 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_6);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_6, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralC90CADE37127E5B15A609569628F61937A864B5A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_6, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket_ValidateRequest_m6071DCC338700F7187D68393D565E6F73C366E2F_RuntimeMethod_var)));
	}

IL_0042:
	{
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::ValidateReply()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_ValidateReply_m15201D6A185C7D3C87594B52A742209DDA5D6366 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// if (Mode != NtpMode.Server)
		int32_t L_0;
		L_0 = NtpPacket_get_Mode_m87035DFF507EDCB50A20ACBED4E96C6B81685A82(__this, NULL);
		if ((((int32_t)L_0) == ((int32_t)4)))
		{
			goto IL_0014;
		}
	}
	{
		// throw new InvalidOperationException("This is not a reply SNTP packet.");
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_1 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_1);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral06C05B24B8AC51D50C3AA294D70C5E1E28E9A0E3)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket_ValidateReply_m15201D6A185C7D3C87594B52A742209DDA5D6366_RuntimeMethod_var)));
	}

IL_0014:
	{
		// if (VersionNumber == 0)
		int32_t L_2;
		L_2 = NtpPacket_get_VersionNumber_m347EE1EAF30F02BDEA43D5F8FBFEE852154894F8(__this, NULL);
		if (L_2)
		{
			goto IL_0027;
		}
	}
	{
		// throw new InvalidOperationException("Protocol version of the reply is not specified.");
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_3 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_3);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_3, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral88F1D02FAC5553C102E3A23C9A363D07A9C89238)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_3, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket_ValidateReply_m15201D6A185C7D3C87594B52A742209DDA5D6366_RuntimeMethod_var)));
	}

IL_0027:
	{
		// if (Stratum == 0)
		int32_t L_4;
		L_4 = NtpPacket_get_Stratum_mC9D6B92A3A8F7C614C6F516917C7465C962E2D57(__this, NULL);
		if (L_4)
		{
			goto IL_004a;
		}
	}
	{
		// throw new InvalidOperationException(string.Format("Received Kiss-o'-Death SNTP packet with code 0x{0:x}.", ReferenceId));
		uint32_t L_5;
		L_5 = NtpPacket_get_ReferenceId_mB909F1CBCCFB444CE0A51409253BA41B220EF087(__this, NULL);
		uint32_t L_6 = L_5;
		RuntimeObject* L_7 = Box(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_il2cpp_TypeInfo_var)), &L_6);
		String_t* L_8;
		L_8 = String_Format_m8C122B26BC5AA10E2550AECA16E57DAE10F07E30(((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral10F509F15EC5C6178F7787F554341A601F904E65)), L_7, NULL);
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_9 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_9);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_9, L_8, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_9, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket_ValidateReply_m15201D6A185C7D3C87594B52A742209DDA5D6366_RuntimeMethod_var)));
	}

IL_004a:
	{
		// if (LeapIndicator == NtpLeapIndicator.AlarmCondition)
		int32_t L_10;
		L_10 = NtpPacket_get_LeapIndicator_mE780E5229CFAF4136F83BB6FE32C44F468F52F74(__this, NULL);
		if ((!(((uint32_t)L_10) == ((uint32_t)3))))
		{
			goto IL_005e;
		}
	}
	{
		// throw new InvalidOperationException("SNTP server has unsynchronized clock.");
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_11 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_11);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_11, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralCB77237BCD39404C795BCB8688C2D3153355EBA0)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_11, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket_ValidateReply_m15201D6A185C7D3C87594B52A742209DDA5D6366_RuntimeMethod_var)));
	}

IL_005e:
	{
		// CheckTimestamps();
		NtpPacket_CheckTimestamps_m3CCEBF5C7B0D0BCA9F164E284A27360D31FAF2A4(__this, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::CheckTimestamps()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_CheckTimestamps_m3CCEBF5C7B0D0BCA9F164E284A27360D31FAF2A4 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// if (OriginTimestamp == null)
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0;
		L_0 = NtpPacket_get_OriginTimestamp_m197B753E1FB93333A8C71E80FB00F5956A831934(__this, NULL);
		V_0 = L_0;
		bool L_1;
		L_1 = Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_inline((&V_0), Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_RuntimeMethod_var);
		if (L_1)
		{
			goto IL_001b;
		}
	}
	{
		// throw new InvalidOperationException("Origin timestamp is missing.");
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_2 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_2);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_2, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralF39AFC06F0127ED41BF2DBB29047355062D8065C)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_2, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket_CheckTimestamps_m3CCEBF5C7B0D0BCA9F164E284A27360D31FAF2A4_RuntimeMethod_var)));
	}

IL_001b:
	{
		// if (ReceiveTimestamp == null)
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_3;
		L_3 = NtpPacket_get_ReceiveTimestamp_m28518CC74140DFEDBA65A56700161E922AFF68B1(__this, NULL);
		V_0 = L_3;
		bool L_4;
		L_4 = Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_inline((&V_0), Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_RuntimeMethod_var);
		if (L_4)
		{
			goto IL_0036;
		}
	}
	{
		// throw new InvalidOperationException("Receive timestamp is missing.");
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_5 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_5);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_5, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralF62357F27A8ABD4B2897C89CFE2ABB3A9468CB41)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_5, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket_CheckTimestamps_m3CCEBF5C7B0D0BCA9F164E284A27360D31FAF2A4_RuntimeMethod_var)));
	}

IL_0036:
	{
		// if (TransmitTimestamp == null)
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_6;
		L_6 = NtpPacket_get_TransmitTimestamp_m44347BB393BE6B6E0562BC198C467E2BBD1F458B(__this, NULL);
		V_0 = L_6;
		bool L_7;
		L_7 = Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_inline((&V_0), Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_RuntimeMethod_var);
		if (L_7)
		{
			goto IL_0051;
		}
	}
	{
		// throw new InvalidOperationException("Transmit timestamp is missing.");
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_8 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_8);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_8, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral49BEFE76EF933CC018C51D77F66B724C36F2CE09)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_8, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket_CheckTimestamps_m3CCEBF5C7B0D0BCA9F164E284A27360D31FAF2A4_RuntimeMethod_var)));
	}

IL_0051:
	{
		// if (DestinationTimestamp == null)
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_9;
		L_9 = NtpPacket_get_DestinationTimestamp_mE42F8228932E2256F3F9FF2181059183172B2A9F_inline(__this, NULL);
		V_0 = L_9;
		bool L_10;
		L_10 = Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_inline((&V_0), Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_RuntimeMethod_var);
		if (L_10)
		{
			goto IL_006c;
		}
	}
	{
		// throw new InvalidOperationException("Destination timestamp is missing.");
		InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB* L_11 = (InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&InvalidOperationException_t5DDE4D49B7405FAAB1E4576F4715A42A3FAD4BAB_il2cpp_TypeInfo_var)));
		NullCheck(L_11);
		InvalidOperationException__ctor_mE4CB6F4712AB6D99A2358FBAE2E052B3EE976162(L_11, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral3B19916E896E08666992C24EA969EE6DE3B95722)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_11, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NtpPacket_CheckTimestamps_m3CCEBF5C7B0D0BCA9F164E284A27360D31FAF2A4_RuntimeMethod_var)));
	}

IL_006c:
	{
		// }
		return;
	}
}
// System.Nullable`1<System.DateTime> FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::GetDateTime64(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_GetDateTime64_m0C883DDC0D399BA2A28321B6FF4B1490EF94C214 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Convert_t7097FF336D592F7C06D88A98349A44646F91EFFC_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	uint64_t V_0 = 0;
	Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC V_1;
	memset((&V_1), 0, sizeof(V_1));
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D V_2;
	memset((&V_2), 0, sizeof(V_2));
	{
		// var field = GetUInt64BE(offset);
		int32_t L_0 = ___offset0;
		uint64_t L_1;
		L_1 = NtpPacket_GetUInt64BE_m00F31C44FC7380393A61453B6B70FD7D3F387D42(__this, L_0, NULL);
		V_0 = L_1;
		// if (field == 0)
		uint64_t L_2 = V_0;
		if (L_2)
		{
			goto IL_0015;
		}
	}
	{
		// return null;
		il2cpp_codegen_initobj((&V_1), sizeof(Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC));
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_3 = V_1;
		return L_3;
	}

IL_0015:
	{
		// return new DateTime(Epoch.Ticks + Convert.ToInt64(field * (1.0 / (1L << 32) * 10000000.0)));
		il2cpp_codegen_runtime_class_init_inline(NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_4 = ((NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_StaticFields*)il2cpp_codegen_static_fields_for(NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var))->___Epoch_0;
		V_2 = L_4;
		int64_t L_5;
		L_5 = DateTime_get_Ticks_mC2CF04ED0EAB425C72C2532FFC5743777F3C93A6((&V_2), NULL);
		uint64_t L_6 = V_0;
		il2cpp_codegen_runtime_class_init_inline(Convert_t7097FF336D592F7C06D88A98349A44646F91EFFC_il2cpp_TypeInfo_var);
		int64_t L_7;
		L_7 = Convert_ToInt64_m5B707D520332D512D2B81C10D2F4044FA468C3A4(((double)il2cpp_codegen_multiply(((double)((double)(uint64_t)L_6)), (0.0023283064365386963))), NULL);
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_8;
		memset((&L_8), 0, sizeof(L_8));
		DateTime__ctor_m64AFCE84ABB24698256EB9F635EFD0A221823441((&L_8), ((int64_t)il2cpp_codegen_add(L_5, L_7)), /*hidden argument*/NULL);
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_9;
		memset((&L_9), 0, sizeof(L_9));
		Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF((&L_9), L_8, /*hidden argument*/Nullable_1__ctor_mB17304720EA19F5469A4883827F53A75FEB492CF_RuntimeMethod_var);
		return L_9;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::SetDateTime64(System.Int32,System.Nullable`1<System.DateTime>)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_SetDateTime64_m7BE5278F49B27CC52BDBB252ED4E24640A3BBB17 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC ___value1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Convert_t7097FF336D592F7C06D88A98349A44646F91EFFC_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D V_0;
	memset((&V_0), 0, sizeof(V_0));
	int32_t G_B2_0 = 0;
	NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* G_B2_1 = NULL;
	int32_t G_B1_0 = 0;
	NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* G_B1_1 = NULL;
	uint64_t G_B3_0 = 0;
	int32_t G_B3_1 = 0;
	NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* G_B3_2 = NULL;
	{
		// SetUInt64BE(offset, value == null ? 0 : Convert.ToUInt64((value.Value.Ticks - Epoch.Ticks) * (0.0000001 * (1L << 32))));
		int32_t L_0 = ___offset0;
		bool L_1;
		L_1 = Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_inline((&___value1), Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_RuntimeMethod_var);
		G_B1_0 = L_0;
		G_B1_1 = __this;
		if (!L_1)
		{
			G_B2_0 = L_0;
			G_B2_1 = __this;
			goto IL_003a;
		}
	}
	{
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_2;
		L_2 = Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991((&___value1), Nullable_1_get_Value_m5A868F663848BC21C18F056731D3AC404CE59991_RuntimeMethod_var);
		V_0 = L_2;
		int64_t L_3;
		L_3 = DateTime_get_Ticks_mC2CF04ED0EAB425C72C2532FFC5743777F3C93A6((&V_0), NULL);
		il2cpp_codegen_runtime_class_init_inline(NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_4 = ((NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_StaticFields*)il2cpp_codegen_static_fields_for(NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var))->___Epoch_0;
		V_0 = L_4;
		int64_t L_5;
		L_5 = DateTime_get_Ticks_mC2CF04ED0EAB425C72C2532FFC5743777F3C93A6((&V_0), NULL);
		il2cpp_codegen_runtime_class_init_inline(Convert_t7097FF336D592F7C06D88A98349A44646F91EFFC_il2cpp_TypeInfo_var);
		uint64_t L_6;
		L_6 = Convert_ToUInt64_m4990F2CE28C4CE3079D458BA578EFBA46D875B3E(((double)il2cpp_codegen_multiply(((double)((int64_t)il2cpp_codegen_subtract(L_3, L_5))), (429.49672959999998))), NULL);
		G_B3_0 = L_6;
		G_B3_1 = G_B1_0;
		G_B3_2 = G_B1_1;
		goto IL_003c;
	}

IL_003a:
	{
		G_B3_0 = ((uint64_t)(((int64_t)0)));
		G_B3_1 = G_B2_0;
		G_B3_2 = G_B2_1;
	}

IL_003c:
	{
		NullCheck(G_B3_2);
		NtpPacket_SetUInt64BE_m455597219DFE9922931AF25FC972D7B59767BCAE(G_B3_2, G_B3_1, G_B3_0, NULL);
		// }
		return;
	}
}
// System.TimeSpan FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::GetTimeSpan32(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A NtpPacket_GetTimeSpan32_mB1470558FF64457DC2A58DEFA8316D51F191C7A2 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return TimeSpan.FromSeconds(GetInt32BE(offset) / (double)(1 << 16));
		int32_t L_0 = ___offset0;
		int32_t L_1;
		L_1 = NtpPacket_GetInt32BE_m01746D745E6D9E3B705A31519FF451CFD10C09AD(__this, L_0, NULL);
		il2cpp_codegen_runtime_class_init_inline(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_il2cpp_TypeInfo_var);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_2;
		L_2 = TimeSpan_FromSeconds_mE585CC8180040ED064DC8B6546E6C94A129BFFC5(((double)(((double)L_1)/(65536.0))), NULL);
		return L_2;
	}
}
// System.UInt64 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::GetUInt64BE(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t NtpPacket_GetUInt64BE_m00F31C44FC7380393A61453B6B70FD7D3F387D42 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return SwapEndianness(BitConverter.ToUInt64(Bytes, offset));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0;
		L_0 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		int32_t L_1 = ___offset0;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint64_t L_2;
		L_2 = BitConverter_ToUInt64_mD74DF4F6535FC635EB8697FC5175A7D99E3C62BF(L_0, L_1, NULL);
		il2cpp_codegen_runtime_class_init_inline(NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		uint64_t L_3;
		L_3 = NtpPacket_SwapEndianness_m4177304D7E853C3D8FF98217ADC9F0A7C7442332(L_2, NULL);
		return L_3;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::SetUInt64BE(System.Int32,System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket_SetUInt64BE_m455597219DFE9922931AF25FC972D7B59767BCAE (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, uint64_t ___value1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// FastBitConverter.GetBytes(Bytes, offset, SwapEndianness(value));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0;
		L_0 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		int32_t L_1 = ___offset0;
		uint64_t L_2 = ___value1;
		il2cpp_codegen_runtime_class_init_inline(NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		uint64_t L_3;
		L_3 = NtpPacket_SwapEndianness_m4177304D7E853C3D8FF98217ADC9F0A7C7442332(L_2, NULL);
		FastBitConverter_GetBytes_m9D1EC7459D20F918B45C5ED54DAC7B95CA35F064(L_0, L_1, L_3, NULL);
		// }
		return;
	}
}
// System.Int32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::GetInt32BE(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t NtpPacket_GetInt32BE_m01746D745E6D9E3B705A31519FF451CFD10C09AD (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, const RuntimeMethod* method) 
{
	{
		// return (int)GetUInt32BE(offset);
		int32_t L_0 = ___offset0;
		uint32_t L_1;
		L_1 = NtpPacket_GetUInt32BE_m46AA79D2DE54C64DE667B3CF89F5E6E4595B4780(__this, L_0, NULL);
		return L_1;
	}
}
// System.UInt32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::GetUInt32BE(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t NtpPacket_GetUInt32BE_m46AA79D2DE54C64DE667B3CF89F5E6E4595B4780 (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, int32_t ___offset0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return SwapEndianness(BitConverter.ToUInt32(Bytes, offset));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0;
		L_0 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(__this, NULL);
		int32_t L_1 = ___offset0;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint32_t L_2;
		L_2 = BitConverter_ToUInt32_m7EFCF9D77ACD0F2DA29F69587DDF6130391E6164(L_0, L_1, NULL);
		il2cpp_codegen_runtime_class_init_inline(NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		uint32_t L_3;
		L_3 = NtpPacket_SwapEndianness_m2C5DA2CC50F40E084890E6F948E42E6B8207F3B4(L_2, NULL);
		return L_3;
	}
}
// System.UInt32 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::SwapEndianness(System.UInt32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t NtpPacket_SwapEndianness_m2C5DA2CC50F40E084890E6F948E42E6B8207F3B4 (uint32_t ___x0, const RuntimeMethod* method) 
{
	{
		// return ((x & 0xff) << 24) | ((x & 0xff00) << 8) | ((x & 0xff0000) >> 8) | ((x & 0xff000000) >> 24);
		uint32_t L_0 = ___x0;
		uint32_t L_1 = ___x0;
		uint32_t L_2 = ___x0;
		uint32_t L_3 = ___x0;
		return ((int32_t)(((int32_t)(((int32_t)(((int32_t)(((int32_t)((int32_t)L_0&((int32_t)255)))<<((int32_t)24)))|((int32_t)(((int32_t)((int32_t)L_1&((int32_t)65280)))<<8))))|((int32_t)((uint32_t)((int32_t)((int32_t)L_2&((int32_t)16711680)))>>8))))|((int32_t)((uint32_t)((int32_t)((int32_t)L_3&((int32_t)-16777216)))>>((int32_t)24)))));
	}
}
// System.UInt64 FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::SwapEndianness(System.UInt64)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint64_t NtpPacket_SwapEndianness_m4177304D7E853C3D8FF98217ADC9F0A7C7442332 (uint64_t ___x0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return ((ulong)SwapEndianness((uint)x) << 32) | SwapEndianness((uint)(x >> 32));
		uint64_t L_0 = ___x0;
		il2cpp_codegen_runtime_class_init_inline(NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		uint32_t L_1;
		L_1 = NtpPacket_SwapEndianness_m2C5DA2CC50F40E084890E6F948E42E6B8207F3B4(((int32_t)(uint32_t)L_0), NULL);
		uint64_t L_2 = ___x0;
		uint32_t L_3;
		L_3 = NtpPacket_SwapEndianness_m2C5DA2CC50F40E084890E6F948E42E6B8207F3B4(((int32_t)(uint32_t)((int64_t)((uint64_t)L_2>>((int32_t)32)))), NULL);
		return ((int64_t)(((int64_t)(((int64_t)(uint64_t)L_1)<<((int32_t)32)))|((int64_t)(uint64_t)L_3)));
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpPacket::.cctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpPacket__cctor_m78EBD3EA8B8E3EE18413107E2080B420560174F1 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// private static readonly DateTime Epoch = new DateTime(1900, 1, 1);
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D L_0;
		memset((&L_0), 0, sizeof(L_0));
		DateTime__ctor_mA3BF7CE28807F0A02634FD43913FAAFD989CEE88((&L_0), ((int32_t)1900), 1, 1, /*hidden argument*/NULL);
		((NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_StaticFields*)il2cpp_codegen_static_fields_for(NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var))->___Epoch_0 = L_0;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.Utils.NtpRequest::.ctor(System.Net.IPEndPoint)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NtpRequest__ctor_mB15493F1A541CE4A7752FB5706C5D89269BFDD58 (NtpRequest_tFFBFC24434D3C3F9B5A288721A636B37D4382399* __this, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___endPoint0, const RuntimeMethod* method) 
{
	{
		// private int _resendTime = ResendTimer;
		__this->____resendTime_4 = ((int32_t)1000);
		// public NtpRequest(IPEndPoint endPoint)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// _ntpEndPoint = endPoint;
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_0 = ___endPoint0;
		__this->____ntpEndPoint_3 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____ntpEndPoint_3), (void*)L_0);
		// }
		return;
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NtpRequest::get_NeedToKill()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NtpRequest_get_NeedToKill_m5D8DEDA5B5BC948A0640F68433A1B5DE549DBA29 (NtpRequest_tFFBFC24434D3C3F9B5A288721A636B37D4382399* __this, const RuntimeMethod* method) 
{
	{
		// get { return _killTime >= KillTimer; }
		int32_t L_0 = __this->____killTime_5;
		return (bool)((((int32_t)((((int32_t)L_0) < ((int32_t)((int32_t)10000)))? 1 : 0)) == ((int32_t)0))? 1 : 0);
	}
}
// System.Boolean FlyingWormConsole3.LiteNetLib.Utils.NtpRequest::Send(FlyingWormConsole3.LiteNetLib.NetSocket,System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool NtpRequest_Send_mAFBE58FA7A595A6578DE92C7F81B666951187189 (NtpRequest_tFFBFC24434D3C3F9B5A288721A636B37D4382399* __this, NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* ___socket0, int32_t ___time1, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* V_1 = NULL;
	int32_t V_2 = 0;
	{
		// _resendTime += time;
		int32_t L_0 = __this->____resendTime_4;
		int32_t L_1 = ___time1;
		__this->____resendTime_4 = ((int32_t)il2cpp_codegen_add(L_0, L_1));
		// _killTime += time;
		int32_t L_2 = __this->____killTime_5;
		int32_t L_3 = ___time1;
		__this->____killTime_5 = ((int32_t)il2cpp_codegen_add(L_2, L_3));
		// if (_resendTime < ResendTimer)
		int32_t L_4 = __this->____resendTime_4;
		if ((((int32_t)L_4) >= ((int32_t)((int32_t)1000))))
		{
			goto IL_002b;
		}
	}
	{
		// return false;
		return (bool)0;
	}

IL_002b:
	{
		// SocketError errorCode = 0;
		V_0 = 0;
		// var packet = new NtpPacket();
		NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* L_5 = (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA*)il2cpp_codegen_object_new(NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA_il2cpp_TypeInfo_var);
		NullCheck(L_5);
		NtpPacket__ctor_m443C2A6A5BA9A9172E59F1BC1B9C5DE485E5B2E7(L_5, NULL);
		V_1 = L_5;
		// var sendCount = socket.SendTo(packet.Bytes, 0, packet.Bytes.Length, _ntpEndPoint, ref errorCode);
		NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* L_6 = ___socket0;
		NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* L_7 = V_1;
		NullCheck(L_7);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_8;
		L_8 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(L_7, NULL);
		NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* L_9 = V_1;
		NullCheck(L_9);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_10;
		L_10 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(L_9, NULL);
		NullCheck(L_10);
		IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* L_11 = __this->____ntpEndPoint_3;
		NullCheck(L_6);
		int32_t L_12;
		L_12 = NetSocket_SendTo_mEBB7CBE898383F3C5E94F453005B7F3A68C1D469(L_6, L_8, 0, ((int32_t)(((RuntimeArray*)L_10)->max_length)), L_11, (&V_0), NULL);
		V_2 = L_12;
		// return errorCode == 0 && sendCount == packet.Bytes.Length;
		int32_t L_13 = V_0;
		if (L_13)
		{
			goto IL_0060;
		}
	}
	{
		int32_t L_14 = V_2;
		NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* L_15 = V_1;
		NullCheck(L_15);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_16;
		L_16 = NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline(L_15, NULL);
		NullCheck(L_16);
		return (bool)((((int32_t)L_14) == ((int32_t)((int32_t)(((RuntimeArray*)L_16)->max_length))))? 1 : 0);
	}

IL_0060:
	{
		return (bool)0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.Layers.Crc32cLayer::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Crc32cLayer__ctor_m7083C80273D3BB9FAD87662B6594A663488DBF67 (Crc32cLayer_t799B2010955281BD2F31EBA62AF0091A14642304* __this, const RuntimeMethod* method) 
{
	{
		// public Crc32cLayer() : base(CRC32C.ChecksumSize)
		PacketLayerBase__ctor_m8F0B3F00218E79F387DFD9B589BE5AE6FE460593(__this, 4, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Layers.Crc32cLayer::ProcessInboundPacket(System.Net.IPEndPoint,System.Byte[]&,System.Int32&,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Crc32cLayer_ProcessInboundPacket_m8DD247F8B76BF7CA1CDB5A968B70B988DD9D4DBB (Crc32cLayer_t799B2010955281BD2F31EBA62AF0091A14642304* __this, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___endPoint0, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** ___data1, int32_t* ___offset2, int32_t* ___length3, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral20578EED957D25675AEB69A727D4556E455C76A9);
		s_Il2CppMethodInitialized = true;
	}
	int32_t V_0 = 0;
	{
		// if (length < NetConstants.HeaderSize + CRC32C.ChecksumSize)
		int32_t* L_0 = ___length3;
		int32_t L_1 = *((int32_t*)L_0);
		if ((((int32_t)L_1) >= ((int32_t)5)))
		{
			goto IL_001a;
		}
	}
	{
		// NetDebug.WriteError("[NM] DataReceived size: bad!");
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_2;
		L_2 = Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_inline(Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_RuntimeMethod_var);
		il2cpp_codegen_runtime_class_init_inline(NetDebug_t09498527952058773C46B5C4FD82F348EC77F7BB_il2cpp_TypeInfo_var);
		NetDebug_WriteError_m950356DF95AA0DB66BD907F841C4C9BBDCFF25E3(_stringLiteral20578EED957D25675AEB69A727D4556E455C76A9, L_2, NULL);
		// length = 0;
		int32_t* L_3 = ___length3;
		*((int32_t*)L_3) = (int32_t)0;
		// return;
		return;
	}

IL_001a:
	{
		// int checksumPoint = length - CRC32C.ChecksumSize;
		int32_t* L_4 = ___length3;
		int32_t L_5 = *((int32_t*)L_4);
		V_0 = ((int32_t)il2cpp_codegen_subtract(L_5, 4));
		// if (CRC32C.Compute(data, offset, checksumPoint) != BitConverter.ToUInt32(data, checksumPoint))
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_6 = ___data1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = *((ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**)L_6);
		int32_t* L_8 = ___offset2;
		int32_t L_9 = *((int32_t*)L_8);
		int32_t L_10 = V_0;
		il2cpp_codegen_runtime_class_init_inline(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var);
		uint32_t L_11;
		L_11 = CRC32C_Compute_m6ABD4B61DCD74A62046F40911343ECD3F4C45E38(L_7, L_9, L_10, NULL);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_12 = ___data1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = *((ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**)L_12);
		int32_t L_14 = V_0;
		il2cpp_codegen_runtime_class_init_inline(BitConverter_t6E99605185963BC12B3D369E13F2B88997E64A27_il2cpp_TypeInfo_var);
		uint32_t L_15;
		L_15 = BitConverter_ToUInt32_m7EFCF9D77ACD0F2DA29F69587DDF6130391E6164(L_13, L_14, NULL);
		if ((((int32_t)L_11) == ((int32_t)L_15)))
		{
			goto IL_0039;
		}
	}
	{
		// length = 0;
		int32_t* L_16 = ___length3;
		*((int32_t*)L_16) = (int32_t)0;
		// return;
		return;
	}

IL_0039:
	{
		// length -= CRC32C.ChecksumSize;
		int32_t* L_17 = ___length3;
		int32_t* L_18 = ___length3;
		int32_t L_19 = *((int32_t*)L_18);
		*((int32_t*)L_17) = (int32_t)((int32_t)il2cpp_codegen_subtract(L_19, 4));
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Layers.Crc32cLayer::ProcessOutBoundPacket(System.Net.IPEndPoint,System.Byte[]&,System.Int32&,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Crc32cLayer_ProcessOutBoundPacket_m91764D9F1F3237B1648CB78CAA4FF71E5B219CE9 (Crc32cLayer_t799B2010955281BD2F31EBA62AF0091A14642304* __this, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___endPoint0, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** ___data1, int32_t* ___offset2, int32_t* ___length3, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// FastBitConverter.GetBytes(data, length, CRC32C.Compute(data, offset, length));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_0 = ___data1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = *((ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**)L_0);
		int32_t* L_2 = ___length3;
		int32_t L_3 = *((int32_t*)L_2);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_4 = ___data1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = *((ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**)L_4);
		int32_t* L_6 = ___offset2;
		int32_t L_7 = *((int32_t*)L_6);
		int32_t* L_8 = ___length3;
		int32_t L_9 = *((int32_t*)L_8);
		il2cpp_codegen_runtime_class_init_inline(CRC32C_t2921A96AC4574713CE8C171FFC535DD602FDB34A_il2cpp_TypeInfo_var);
		uint32_t L_10;
		L_10 = CRC32C_Compute_m6ABD4B61DCD74A62046F40911343ECD3F4C45E38(L_5, L_7, L_9, NULL);
		FastBitConverter_GetBytes_mE205091FC74A54D5580EF718A92652CCCF3FC942(L_1, L_3, L_10, NULL);
		// length += CRC32C.ChecksumSize;
		int32_t* L_11 = ___length3;
		int32_t* L_12 = ___length3;
		int32_t L_13 = *((int32_t*)L_12);
		*((int32_t*)L_11) = (int32_t)((int32_t)il2cpp_codegen_add(L_13, 4));
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.Layers.PacketLayerBase::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PacketLayerBase__ctor_m8F0B3F00218E79F387DFD9B589BE5AE6FE460593 (PacketLayerBase_t45CF70BC52F3CBAE7EC7F885A16F3FB7753C23C6* __this, int32_t ___extraPacketSizeForLayer0, const RuntimeMethod* method) 
{
	{
		// protected PacketLayerBase(int extraPacketSizeForLayer)
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		// ExtraPacketSizeForLayer = extraPacketSizeForLayer;
		int32_t L_0 = ___extraPacketSizeForLayer0;
		__this->___ExtraPacketSizeForLayer_0 = L_0;
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XorEncryptLayer__ctor_m0DD3A792F23BE3D9F27897069BAB87EE13C744A0 (XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198* __this, const RuntimeMethod* method) 
{
	{
		// public XorEncryptLayer() : base(0)
		PacketLayerBase__ctor_m8F0B3F00218E79F387DFD9B589BE5AE6FE460593(__this, 0, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer::.ctor(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XorEncryptLayer__ctor_mCFE1DB9683F4A679572507AE6A79D99AF1906014 (XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___key0, const RuntimeMethod* method) 
{
	{
		// public XorEncryptLayer(byte[] key) : this()
		XorEncryptLayer__ctor_m0DD3A792F23BE3D9F27897069BAB87EE13C744A0(__this, NULL);
		// SetKey(key);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___key0;
		XorEncryptLayer_SetKey_mC28876F5A98E49511AD705C719910983A1FE748A(__this, L_0, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer::.ctor(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XorEncryptLayer__ctor_m8D3622D26AA83F7E5D31A71ADC27AB9853147C29 (XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198* __this, String_t* ___key0, const RuntimeMethod* method) 
{
	{
		// public XorEncryptLayer(string key) : this()
		XorEncryptLayer__ctor_m0DD3A792F23BE3D9F27897069BAB87EE13C744A0(__this, NULL);
		// SetKey(key);
		String_t* L_0 = ___key0;
		XorEncryptLayer_SetKey_m9DB3995363BB05B8A35B07BF208AD2F4A856E270(__this, L_0, NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer::SetKey(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XorEncryptLayer_SetKey_m9DB3995363BB05B8A35B07BF208AD2F4A856E270 (XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198* __this, String_t* ___key0, const RuntimeMethod* method) 
{
	{
		// _byteKey = Encoding.UTF8.GetBytes(key);
		Encoding_t65CDEF28CF20A7B8C92E85A4E808920C2465F095* L_0;
		L_0 = Encoding_get_UTF8_m9700ADA8E0F244002B2A89B483F1B2133B8FE336(NULL);
		String_t* L_1 = ___key0;
		NullCheck(L_0);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2;
		L_2 = VirtualFuncInvoker1< ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*, String_t* >::Invoke(17 /* System.Byte[] System.Text.Encoding::GetBytes(System.String) */, L_0, L_1);
		__this->____byteKey_1 = L_2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____byteKey_1), (void*)L_2);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer::SetKey(System.Byte[])
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XorEncryptLayer_SetKey_mC28876F5A98E49511AD705C719910983A1FE748A (XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___key0, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		// if (_byteKey == null || _byteKey.Length != key.Length)
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____byteKey_1;
		if (!L_0)
		{
			goto IL_0015;
		}
	}
	{
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_1 = __this->____byteKey_1;
		NullCheck(L_1);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_2 = ___key0;
		NullCheck(L_2);
		if ((((int32_t)((int32_t)(((RuntimeArray*)L_1)->max_length))) == ((int32_t)((int32_t)(((RuntimeArray*)L_2)->max_length)))))
		{
			goto IL_0023;
		}
	}

IL_0015:
	{
		// _byteKey = new byte[key.Length];
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_3 = ___key0;
		NullCheck(L_3);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = (ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031*)SZArrayNew(ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031_il2cpp_TypeInfo_var, (uint32_t)((int32_t)(((RuntimeArray*)L_3)->max_length)));
		__this->____byteKey_1 = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&__this->____byteKey_1), (void*)L_4);
	}

IL_0023:
	{
		// Buffer.BlockCopy(key, 0, _byteKey, 0, key.Length);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_5 = ___key0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_6 = __this->____byteKey_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = ___key0;
		NullCheck(L_7);
		Buffer_BlockCopy_mD8CF7EC96ADA7A542CCA3F3C73510624E10197A9((RuntimeArray*)L_5, 0, (RuntimeArray*)L_6, 0, ((int32_t)(((RuntimeArray*)L_7)->max_length)), NULL);
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer::ProcessInboundPacket(System.Net.IPEndPoint,System.Byte[]&,System.Int32&,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XorEncryptLayer_ProcessInboundPacket_m3B18AEE11E0405495BA8C04CB44E4B62216CA396 (XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198* __this, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___endPoint0, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** ___data1, int32_t* ___offset2, int32_t* ___length3, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		// if (_byteKey == null)
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____byteKey_1;
		if (L_0)
		{
			goto IL_0009;
		}
	}
	{
		// return;
		return;
	}

IL_0009:
	{
		// var cur = offset;
		int32_t* L_1 = ___offset2;
		int32_t L_2 = *((int32_t*)L_1);
		V_0 = L_2;
		// for (var i = 0; i < length; i++, cur++)
		V_1 = 0;
		goto IL_0033;
	}

IL_0010:
	{
		// data[cur] = (byte)(data[cur] ^ _byteKey[i % _byteKey.Length]);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_3 = ___data1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = *((ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**)L_3);
		int32_t L_5 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_6 = ___data1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = *((ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**)L_6);
		int32_t L_8 = V_0;
		NullCheck(L_7);
		int32_t L_9 = L_8;
		uint8_t L_10 = (L_7)->GetAt(static_cast<il2cpp_array_size_t>(L_9));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = __this->____byteKey_1;
		int32_t L_12 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = __this->____byteKey_1;
		NullCheck(L_13);
		NullCheck(L_11);
		int32_t L_14 = ((int32_t)(L_12%((int32_t)(((RuntimeArray*)L_13)->max_length))));
		uint8_t L_15 = (L_11)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
		NullCheck(L_4);
		(L_4)->SetAt(static_cast<il2cpp_array_size_t>(L_5), (uint8_t)((int32_t)(uint8_t)((int32_t)((int32_t)L_10^(int32_t)L_15))));
		// for (var i = 0; i < length; i++, cur++)
		int32_t L_16 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_16, 1));
		// for (var i = 0; i < length; i++, cur++)
		int32_t L_17 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_17, 1));
	}

IL_0033:
	{
		// for (var i = 0; i < length; i++, cur++)
		int32_t L_18 = V_1;
		int32_t* L_19 = ___length3;
		int32_t L_20 = *((int32_t*)L_19);
		if ((((int32_t)L_18) < ((int32_t)L_20)))
		{
			goto IL_0010;
		}
	}
	{
		// }
		return;
	}
}
// System.Void FlyingWormConsole3.LiteNetLib.Layers.XorEncryptLayer::ProcessOutBoundPacket(System.Net.IPEndPoint,System.Byte[]&,System.Int32&,System.Int32&)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XorEncryptLayer_ProcessOutBoundPacket_m927330C7BD6705CC171FA7F435CC910865403B7C (XorEncryptLayer_tD15F54FF937FBF86B6715067B7E19F9C42E2C198* __this, IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* ___endPoint0, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** ___data1, int32_t* ___offset2, int32_t* ___length3, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		// if (_byteKey == null)
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____byteKey_1;
		if (L_0)
		{
			goto IL_0009;
		}
	}
	{
		// return;
		return;
	}

IL_0009:
	{
		// var cur = offset;
		int32_t* L_1 = ___offset2;
		int32_t L_2 = *((int32_t*)L_1);
		V_0 = L_2;
		// for (var i = 0; i < length; i++, cur++)
		V_1 = 0;
		goto IL_0033;
	}

IL_0010:
	{
		// data[cur] = (byte)(data[cur] ^ _byteKey[i % _byteKey.Length]);
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_3 = ___data1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_4 = *((ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**)L_3);
		int32_t L_5 = V_0;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031** L_6 = ___data1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_7 = *((ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031**)L_6);
		int32_t L_8 = V_0;
		NullCheck(L_7);
		int32_t L_9 = L_8;
		uint8_t L_10 = (L_7)->GetAt(static_cast<il2cpp_array_size_t>(L_9));
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_11 = __this->____byteKey_1;
		int32_t L_12 = V_1;
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_13 = __this->____byteKey_1;
		NullCheck(L_13);
		NullCheck(L_11);
		int32_t L_14 = ((int32_t)(L_12%((int32_t)(((RuntimeArray*)L_13)->max_length))));
		uint8_t L_15 = (L_11)->GetAt(static_cast<il2cpp_array_size_t>(L_14));
		NullCheck(L_4);
		(L_4)->SetAt(static_cast<il2cpp_array_size_t>(L_5), (uint8_t)((int32_t)(uint8_t)((int32_t)((int32_t)L_10^(int32_t)L_15))));
		// for (var i = 0; i < length; i++, cur++)
		int32_t L_16 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_16, 1));
		// for (var i = 0; i < length; i++, cur++)
		int32_t L_17 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_add(L_17, 1));
	}

IL_0033:
	{
		// for (var i = 0; i < length; i++, cur++)
		int32_t L_18 = V_1;
		int32_t* L_19 = ___length3;
		int32_t L_20 = *((int32_t*)L_19);
		if ((((int32_t)L_18) < ((int32_t)L_20)))
		{
			goto IL_0010;
		}
	}
	{
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.UInt32 <PrivateImplementationDetails>::ComputeStringHash(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t U3CPrivateImplementationDetailsU3E_ComputeStringHash_m9E43873DE0DF480D27EC1C2AA3C09E74EA77F75D (String_t* ___s0, const RuntimeMethod* method) 
{
	uint32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		String_t* L_0 = ___s0;
		if (!L_0)
		{
			goto IL_002a;
		}
	}
	{
		V_0 = ((int32_t)-2128831035);
		V_1 = 0;
		goto IL_0021;
	}

IL_000d:
	{
		String_t* L_1 = ___s0;
		int32_t L_2 = V_1;
		NullCheck(L_1);
		Il2CppChar L_3;
		L_3 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_1, L_2, NULL);
		uint32_t L_4 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_multiply(((int32_t)((int32_t)L_3^(int32_t)L_4)), ((int32_t)16777619)));
		int32_t L_5 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_5, 1));
	}

IL_0021:
	{
		int32_t L_6 = V_1;
		String_t* L_7 = ___s0;
		NullCheck(L_7);
		int32_t L_8;
		L_8 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_7, NULL);
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_000d;
		}
	}

IL_002a:
	{
		uint32_t L_9 = V_0;
		return L_9;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Socket_get_AddressFamily_m42C390D31345314080EC35356ACFBBFF7E1123E5_inline (Socket_t1F49472CDA22B581C29A258225ABF3ADA9DED67E* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___addressFamily_16;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t IPEndPoint_get_Port_mFBE1AF1C9CC7E68A46BF46AD3869CC9DC01CF429_inline (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____port_1;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void NetSocket_set_LocalPort_m5131B89E161C3020415092F25760AB4038583ED9_inline (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, int32_t ___value0, const RuntimeMethod* method) 
{
	{
		// public int LocalPort { get; private set; }
		int32_t L_0 = ___value0;
		__this->___U3CLocalPortU3Ek__BackingField_11 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t NetSocket_get_LocalPort_mD789615311CD7E8F790B46A9D99C72CCAF3D78E3_inline (NetSocket_t6D6CAA3836008BA017A8BE4CF4F8FBBAAB4EA4F4* __this, const RuntimeMethod* method) 
{
	{
		// public int LocalPort { get; private set; }
		int32_t L_0 = __this->___U3CLocalPortU3Ek__BackingField_11;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* IPHostEntry_get_AddressList_m9D14D52EFB41C53C9C4A36D438E1333A99B7AA71_inline (IPHostEntry_tAAAEB0F40DB9F28BE601B5FE7DA1D76191C94490* __this, const RuntimeMethod* method) 
{
	{
		IPAddressU5BU5D_t3AEDF3B94746C9023A4549F878AA47F702C9CD0D* L_0 = __this->___addressList_2;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR double NetPeer_get_ResendDelay_m6D44FEF7BA647CA1047274DB58A7B9A2FDC64A12_inline (NetPeer_t882A117D59790FE03D2D349C441B30690D04637B* __this, const RuntimeMethod* method) 
{
	{
		// internal double ResendDelay { get { return _resendDelay; } }
		double L_0 = __this->____resendDelay_3;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* NetDataWriter_get_Data_m57195A7D8184C5AFAE3D3DEF4069D8AD9A7390AD_inline (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, const RuntimeMethod* method) 
{
	{
		// get { return _data; }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->____data_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t NetDataWriter_get_Length_m7947782000AC2E7C7B6152A12F4FCA2064948AEC_inline (NetDataWriter_tAC29FAA7BF8D757166CC36FC9F132B0DFFBFEEAA* __this, const RuntimeMethod* method) 
{
	{
		// get { return _position; }
		int32_t L_0 = __this->____position_1;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* IPEndPoint_get_Address_m72F783CB76E10E9DBDF680CCC1DAAED201BABB1C_inline (IPEndPoint_t2F09CBA7A808B67724B4E2954EEDC46D910F4ECB* __this, const RuntimeMethod* method) 
{
	{
		IPAddress_t2F4486449B0D73FF2D3B36A9FE5E9C3F63116484* L_0 = __this->____address_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____stringLength_4;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void SubscribeDelegate_Invoke_m2FA1DF158E1771AC7DCF970AF088A3666D99D3A1_inline (SubscribeDelegate_tA247CCC4CFF4353915E48E5EF727059782DC83B5* __this, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54* ___reader0, RuntimeObject* ___userData1, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, NetDataReader_tC211E72AE62D3365739E7A7E2C748C86E5485C54*, RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl_1)((Il2CppObject*)__this->___method_code_6, ___reader0, ___userData1, reinterpret_cast<RuntimeMethod*>(__this->___method_3));
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* NtpPacket_get_Bytes_m0ED5F79E0F0B39182A9632A055BC1C2C0ACC4E24_inline (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public byte[] Bytes { get; private set; }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = __this->___U3CBytesU3Ek__BackingField_1;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC NtpPacket_get_DestinationTimestamp_mE42F8228932E2256F3F9FF2181059183172B2A9F_inline (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, const RuntimeMethod* method) 
{
	{
		// public DateTime? DestinationTimestamp { get; private set; }
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0 = __this->___U3CDestinationTimestampU3Ek__BackingField_2;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int64_t TimeSpan_get_Ticks_mC50131E57621F29FACC53B3241432ABB874FA1B5_inline (TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* __this, const RuntimeMethod* method) 
{
	{
		int64_t L_0 = __this->____ticks_22;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void NtpPacket_set_Bytes_m5DB6D8A635A7BEBA520F0509B46508BB6C42BF37_inline (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___value0, const RuntimeMethod* method) 
{
	{
		// public byte[] Bytes { get; private set; }
		ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* L_0 = ___value0;
		__this->___U3CBytesU3Ek__BackingField_1 = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CBytesU3Ek__BackingField_1), (void*)L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void NtpPacket_set_DestinationTimestamp_mAA50539DD3E9E8D85DEE9E64F3D153570F065FB1_inline (NtpPacket_t22F9C624C19080E02CEA6536ACA65F9E2069FBDA* __this, Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC ___value0, const RuntimeMethod* method) 
{
	{
		// public DateTime? DestinationTimestamp { get; private set; }
		Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC L_0 = ___value0;
		__this->___U3CDestinationTimestampU3Ek__BackingField_2 = L_0;
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* Array_Empty_TisRuntimeObject_m55011E8360A8199FB239A5787BA8631CDD6116FC_gshared_inline (const RuntimeMethod* method) 
{
	{
		il2cpp_codegen_runtime_class_init_inline(il2cpp_rgctx_data(method->rgctx_data, 0));
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_0 = ((EmptyArray_1_tDF0DD7256B115243AA6BD5558417387A734240EE_StaticFields*)il2cpp_codegen_static_fields_for(il2cpp_rgctx_data(method->rgctx_data, 0)))->___Value_0;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void List_1_Clear_m16C1F2C61FED5955F10EB36BC1CB2DF34B128994_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = (int32_t)__this->____version_3;
		__this->____version_3 = ((int32_t)il2cpp_codegen_add(L_0, 1));
		if (!true)
		{
			goto IL_0035;
		}
	}
	{
		int32_t L_1 = (int32_t)__this->____size_2;
		V_0 = L_1;
		__this->____size_2 = 0;
		int32_t L_2 = V_0;
		if ((((int32_t)L_2) <= ((int32_t)0)))
		{
			goto IL_003c;
		}
	}
	{
		ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918* L_3 = (ObjectU5BU5D_t8061030B0A12A55D5AD8652A20C922FE99450918*)__this->____items_1;
		int32_t L_4 = V_0;
		Array_Clear_m48B57EC27CADC3463CA98A33373D557DA587FF1B((RuntimeArray*)L_3, 0, L_4, NULL);
		return;
	}

IL_0035:
	{
		__this->____size_2 = 0;
	}

IL_003c:
	{
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t List_1_get_Count_m4407E4C389F22B8CEC282C15D56516658746C383_gshared_inline (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = (int32_t)__this->____size_2;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t Queue_1_get_Count_m1768ADA9855B7CDA14C9C42E098A287F1A39C3A2_gshared_inline (Queue_1_tE9EF546915795972C3BFD68FBB8FA859D3BAF3B5* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = (int32_t)__this->____size_3;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Nullable_1_get_HasValue_m092C73DCE052BFB5C60A39EF9F4E3401AA95221C_gshared_inline (Nullable_1_tEADC262F7F8B8BC4CC0A003DBDD3CA7C1B63F9AC* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = (bool)__this->___hasValue_0;
		return L_0;
	}
}
