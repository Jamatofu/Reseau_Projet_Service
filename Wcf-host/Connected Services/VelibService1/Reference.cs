﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wcf_host.VelibService1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VelibService1.IVelibService", CallbackContract=typeof(Wcf_host.VelibService1.IVelibServiceCallback))]
    public interface IVelibService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetStations", ReplyAction="http://tempuri.org/IVelibService/GetStationsResponse")]
        Wcf_Service.Station[] GetStations(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetStations", ReplyAction="http://tempuri.org/IVelibService/GetStationsResponse")]
        System.Threading.Tasks.Task<Wcf_Service.Station[]> GetStationsAsync(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetNumberAvailableBike", ReplyAction="http://tempuri.org/IVelibService/GetNumberAvailableBikeResponse")]
        int GetNumberAvailableBike(string city, string station);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/GetNumberAvailableBike", ReplyAction="http://tempuri.org/IVelibService/GetNumberAvailableBikeResponse")]
        System.Threading.Tasks.Task<int> GetNumberAvailableBikeAsync(string city, string station);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/SubscribeToAvailableBikesChanged", ReplyAction="http://tempuri.org/IVelibService/SubscribeToAvailableBikesChangedResponse")]
        void SubscribeToAvailableBikesChanged(string city, string station, int timeForResponce);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibService/SubscribeToAvailableBikesChanged", ReplyAction="http://tempuri.org/IVelibService/SubscribeToAvailableBikesChangedResponse")]
        System.Threading.Tasks.Task SubscribeToAvailableBikesChangedAsync(string city, string station, int timeForResponce);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVelibServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IVelibService/NumberOfBikesChanged")]
        void NumberOfBikesChanged(string city, string station, int nb);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVelibServiceChannel : Wcf_host.VelibService1.IVelibService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VelibServiceClient : System.ServiceModel.DuplexClientBase<Wcf_host.VelibService1.IVelibService>, Wcf_host.VelibService1.IVelibService {
        
        public VelibServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public VelibServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public VelibServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public VelibServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public VelibServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public Wcf_Service.Station[] GetStations(string city) {
            return base.Channel.GetStations(city);
        }
        
        public System.Threading.Tasks.Task<Wcf_Service.Station[]> GetStationsAsync(string city) {
            return base.Channel.GetStationsAsync(city);
        }
        
        public int GetNumberAvailableBike(string city, string station) {
            return base.Channel.GetNumberAvailableBike(city, station);
        }
        
        public System.Threading.Tasks.Task<int> GetNumberAvailableBikeAsync(string city, string station) {
            return base.Channel.GetNumberAvailableBikeAsync(city, station);
        }
        
        public void SubscribeToAvailableBikesChanged(string city, string station, int timeForResponce) {
            base.Channel.SubscribeToAvailableBikesChanged(city, station, timeForResponce);
        }
        
        public System.Threading.Tasks.Task SubscribeToAvailableBikesChangedAsync(string city, string station, int timeForResponce) {
            return base.Channel.SubscribeToAvailableBikesChangedAsync(city, station, timeForResponce);
        }
    }
}