// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/customer.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace XmlData.GrpcServices {
  public static partial class CustomerData
  {
    static readonly string __ServiceName = "CustomerData";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.CustomersRequest> __Marshaller_CustomersRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.CustomersRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.CustomersResponse> __Marshaller_CustomersResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.CustomersResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.GetCustomerByIdRequest> __Marshaller_GetCustomerByIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.GetCustomerByIdRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.GetCustomerByIdResponse> __Marshaller_GetCustomerByIdResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.GetCustomerByIdResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.CreateCustomerRequest> __Marshaller_CreateCustomerRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.CreateCustomerRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.CreateCustomerResponse> __Marshaller_CreateCustomerResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.CreateCustomerResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.PutCustomerRequest> __Marshaller_PutCustomerRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.PutCustomerRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.PutCustomerResponse> __Marshaller_PutCustomerResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.PutCustomerResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.DeleteCustomerRequest> __Marshaller_DeleteCustomerRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.DeleteCustomerRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.DeleteCustomerResponse> __Marshaller_DeleteCustomerResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.DeleteCustomerResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.SaveCustomerRequest> __Marshaller_SaveCustomerRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.SaveCustomerRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.SaveCustomerResponse> __Marshaller_SaveCustomerResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.SaveCustomerResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.UploadXmlRequest> __Marshaller_UploadXmlRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.UploadXmlRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::XmlData.GrpcServices.UploadXmlResponse> __Marshaller_UploadXmlResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::XmlData.GrpcServices.UploadXmlResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::XmlData.GrpcServices.CustomersRequest, global::XmlData.GrpcServices.CustomersResponse> __Method_GetCustomers = new grpc::Method<global::XmlData.GrpcServices.CustomersRequest, global::XmlData.GrpcServices.CustomersResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCustomers",
        __Marshaller_CustomersRequest,
        __Marshaller_CustomersResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::XmlData.GrpcServices.GetCustomerByIdRequest, global::XmlData.GrpcServices.GetCustomerByIdResponse> __Method_GetCustomerById = new grpc::Method<global::XmlData.GrpcServices.GetCustomerByIdRequest, global::XmlData.GrpcServices.GetCustomerByIdResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCustomerById",
        __Marshaller_GetCustomerByIdRequest,
        __Marshaller_GetCustomerByIdResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::XmlData.GrpcServices.CreateCustomerRequest, global::XmlData.GrpcServices.CreateCustomerResponse> __Method_CreateNew = new grpc::Method<global::XmlData.GrpcServices.CreateCustomerRequest, global::XmlData.GrpcServices.CreateCustomerResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateNew",
        __Marshaller_CreateCustomerRequest,
        __Marshaller_CreateCustomerResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::XmlData.GrpcServices.PutCustomerRequest, global::XmlData.GrpcServices.PutCustomerResponse> __Method_PutCustomer = new grpc::Method<global::XmlData.GrpcServices.PutCustomerRequest, global::XmlData.GrpcServices.PutCustomerResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "PutCustomer",
        __Marshaller_PutCustomerRequest,
        __Marshaller_PutCustomerResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::XmlData.GrpcServices.DeleteCustomerRequest, global::XmlData.GrpcServices.DeleteCustomerResponse> __Method_DeleteCustomer = new grpc::Method<global::XmlData.GrpcServices.DeleteCustomerRequest, global::XmlData.GrpcServices.DeleteCustomerResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteCustomer",
        __Marshaller_DeleteCustomerRequest,
        __Marshaller_DeleteCustomerResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::XmlData.GrpcServices.SaveCustomerRequest, global::XmlData.GrpcServices.SaveCustomerResponse> __Method_SaveCustomer = new grpc::Method<global::XmlData.GrpcServices.SaveCustomerRequest, global::XmlData.GrpcServices.SaveCustomerResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SaveCustomer",
        __Marshaller_SaveCustomerRequest,
        __Marshaller_SaveCustomerResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::XmlData.GrpcServices.UploadXmlRequest, global::XmlData.GrpcServices.UploadXmlResponse> __Method_UploadXml = new grpc::Method<global::XmlData.GrpcServices.UploadXmlRequest, global::XmlData.GrpcServices.UploadXmlResponse>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "UploadXml",
        __Marshaller_UploadXmlRequest,
        __Marshaller_UploadXmlResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::XmlData.GrpcServices.CustomerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CustomerData</summary>
    [grpc::BindServiceMethod(typeof(CustomerData), "BindService")]
    public abstract partial class CustomerDataBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::XmlData.GrpcServices.CustomersResponse> GetCustomers(global::XmlData.GrpcServices.CustomersRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::XmlData.GrpcServices.GetCustomerByIdResponse> GetCustomerById(global::XmlData.GrpcServices.GetCustomerByIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::XmlData.GrpcServices.CreateCustomerResponse> CreateNew(global::XmlData.GrpcServices.CreateCustomerRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::XmlData.GrpcServices.PutCustomerResponse> PutCustomer(global::XmlData.GrpcServices.PutCustomerRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::XmlData.GrpcServices.DeleteCustomerResponse> DeleteCustomer(global::XmlData.GrpcServices.DeleteCustomerRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::XmlData.GrpcServices.SaveCustomerResponse> SaveCustomer(global::XmlData.GrpcServices.SaveCustomerRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      ///rpc UploadXml (UploadXmlRequest) returns (UploadXmlResponse);
      /// </summary>
      /// <param name="requestStream">Used for reading requests from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::XmlData.GrpcServices.UploadXmlResponse> UploadXml(grpc::IAsyncStreamReader<global::XmlData.GrpcServices.UploadXmlRequest> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(CustomerDataBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetCustomers, serviceImpl.GetCustomers)
          .AddMethod(__Method_GetCustomerById, serviceImpl.GetCustomerById)
          .AddMethod(__Method_CreateNew, serviceImpl.CreateNew)
          .AddMethod(__Method_PutCustomer, serviceImpl.PutCustomer)
          .AddMethod(__Method_DeleteCustomer, serviceImpl.DeleteCustomer)
          .AddMethod(__Method_SaveCustomer, serviceImpl.SaveCustomer)
          .AddMethod(__Method_UploadXml, serviceImpl.UploadXml).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CustomerDataBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetCustomers, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::XmlData.GrpcServices.CustomersRequest, global::XmlData.GrpcServices.CustomersResponse>(serviceImpl.GetCustomers));
      serviceBinder.AddMethod(__Method_GetCustomerById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::XmlData.GrpcServices.GetCustomerByIdRequest, global::XmlData.GrpcServices.GetCustomerByIdResponse>(serviceImpl.GetCustomerById));
      serviceBinder.AddMethod(__Method_CreateNew, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::XmlData.GrpcServices.CreateCustomerRequest, global::XmlData.GrpcServices.CreateCustomerResponse>(serviceImpl.CreateNew));
      serviceBinder.AddMethod(__Method_PutCustomer, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::XmlData.GrpcServices.PutCustomerRequest, global::XmlData.GrpcServices.PutCustomerResponse>(serviceImpl.PutCustomer));
      serviceBinder.AddMethod(__Method_DeleteCustomer, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::XmlData.GrpcServices.DeleteCustomerRequest, global::XmlData.GrpcServices.DeleteCustomerResponse>(serviceImpl.DeleteCustomer));
      serviceBinder.AddMethod(__Method_SaveCustomer, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::XmlData.GrpcServices.SaveCustomerRequest, global::XmlData.GrpcServices.SaveCustomerResponse>(serviceImpl.SaveCustomer));
      serviceBinder.AddMethod(__Method_UploadXml, serviceImpl == null ? null : new grpc::ClientStreamingServerMethod<global::XmlData.GrpcServices.UploadXmlRequest, global::XmlData.GrpcServices.UploadXmlResponse>(serviceImpl.UploadXml));
    }

  }
}
#endregion
