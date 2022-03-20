using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MyProj.CM.Apps.Common.Grpc
{
    public class RPCRetryInterceptor:Interceptor
    {
        private int retryCount = 3;
        private readonly TimeSpan _delay = TimeSpan.FromSeconds(1);
        private readonly ILogger<RPCRetryInterceptor> _logger;
        public RPCRetryInterceptor()
        {

        }

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            var currentRetry = 0;
            while(true) {
                try
                {
                    var response = continuation(request, context);
                    var response1 = response.ResponseAsync.Result;
                    return response;
                }
                catch(Exception ex)
                {
                    currentRetry++;
                    if(currentRetry > this.retryCount || !IsTransient(ex))
                    {
                        throw;
                    }
                }
                Task.Delay(_delay);
            }
        }

        private bool IsTransient(Exception ex)
        {
            var exceptionToEvaluate = ex;
            if(exceptionToEvaluate is AggregateException)
            {
                exceptionToEvaluate = ex.InnerException;
            }
            var rpcException = exceptionToEvaluate as RpcException;
            if(rpcException != null)
            {
                return new[] { StatusCode.Unavailable, StatusCode.ResourceExhausted }.Contains(rpcException.StatusCode);
            }
            return false;
        }
    }
}
