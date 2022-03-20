using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.CM.Common.Grpc.Interceptors
{
    public class ServerLoggerInterceptor:Interceptor
    {
        private readonly ILogger<ServerLoggerInterceptor> _logger;
        public ServerLoggerInterceptor(ILogger<ServerLoggerInterceptor> logger)
        {
            _logger = logger;
        }

        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request
            , ServerCallContext context
            , UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                LogCall<TRequest, TResponse>(MethodType.Unary, context);
                return continuation(request, context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public override Task<TResponse> ClientStreamingServerHandler<TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream, ServerCallContext context, ClientStreamingServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                LogCall<TRequest, TResponse>(MethodType.ClientStreaming, context);
                return base.ClientStreamingServerHandler(requestStream, context, continuation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }



        public override Task ServerStreamingServerHandler<TRequest, TResponse>(TRequest request, IServerStreamWriter<TResponse> responseStream, ServerCallContext context, ServerStreamingServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                LogCall<TRequest, TResponse>(MethodType.ServerStreaming, context);
                return base.ServerStreamingServerHandler(request, responseStream, context, continuation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public override Task DuplexStreamingServerHandler<TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream, IServerStreamWriter<TResponse> responseStream, ServerCallContext context, DuplexStreamingServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                LogCall<TRequest, TResponse>(MethodType.DuplexStreaming, context);
                return base.DuplexStreamingServerHandler(requestStream, responseStream, context, continuation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        private void LogCall<TRequest, TResponse>(MethodType methodType, ServerCallContext context) 
            where TRequest : class
            where TResponse: class
        {
            _logger.LogDebug($"Starting call. Type : {methodType}. Request: {typeof(TRequest)}. Response: {typeof(TResponse)}");

            WriteMetadata(context.RequestHeaders, "called-user");
            WriteMetadata(context.RequestHeaders, "called-machine");
            WriteMetadata(context.RequestHeaders, "called-os");
            void WriteMetadata(Metadata headers, string key)
            {
                var headerValue = headers.SingleOrDefault(h => h.Key == key)?.Value;
                _logger.LogDebug($"{key}: {headerValue ?? "(unknown)"}");
            }
        }

    }
}
