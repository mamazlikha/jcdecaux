//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoutingWithBikes.ProxyCache {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProxyCache.IServiceProxy")]
    public interface IServiceProxy {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProxy/GetSomething", ReplyAction="http://tempuri.org/IServiceProxy/GetSomethingResponse")]
        string GetSomething();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProxy/GetSomething", ReplyAction="http://tempuri.org/IServiceProxy/GetSomethingResponse")]
        System.Threading.Tasks.Task<string> GetSomethingAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProxy/getInfoOfStaition", ReplyAction="http://tempuri.org/IServiceProxy/getInfoOfStaitionResponse")]
        string getInfoOfStaition(int id, string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceProxy/getInfoOfStaition", ReplyAction="http://tempuri.org/IServiceProxy/getInfoOfStaitionResponse")]
        System.Threading.Tasks.Task<string> getInfoOfStaitionAsync(int id, string city);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceProxyChannel : RoutingWithBikes.ProxyCache.IServiceProxy, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceProxyClient : System.ServiceModel.ClientBase<RoutingWithBikes.ProxyCache.IServiceProxy>, RoutingWithBikes.ProxyCache.IServiceProxy {
        
        public ServiceProxyClient() {
        }
        
        public ServiceProxyClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceProxyClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceProxyClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceProxyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetSomething() {
            return base.Channel.GetSomething();
        }
        
        public System.Threading.Tasks.Task<string> GetSomethingAsync() {
            return base.Channel.GetSomethingAsync();
        }
        
        public string getInfoOfStaition(int id, string city) {
            return base.Channel.getInfoOfStaition(id, city);
        }
        
        public System.Threading.Tasks.Task<string> getInfoOfStaitionAsync(int id, string city) {
            return base.Channel.getInfoOfStaitionAsync(id, city);
        }
    }
}
