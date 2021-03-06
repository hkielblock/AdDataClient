﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdDataService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Ad", Namespace="http://schemas.datacontract.org/2004/07/AdDataService")]
    public partial class Ad : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int AdIdField;
        
        private AdDataService.Brand BrandField;
        
        private decimal NumPagesField;
        
        private string PositionField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AdId
        {
            get
            {
                return this.AdIdField;
            }
            set
            {
                this.AdIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public AdDataService.Brand Brand
        {
            get
            {
                return this.BrandField;
            }
            set
            {
                this.BrandField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal NumPages
        {
            get
            {
                return this.NumPagesField;
            }
            set
            {
                this.NumPagesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Position
        {
            get
            {
                return this.PositionField;
            }
            set
            {
                this.PositionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Brand", Namespace="http://schemas.datacontract.org/2004/07/AdDataService")]
    public partial class Brand : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int BrandIdField;
        
        private string BrandNameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BrandId
        {
            get
            {
                return this.BrandIdField;
            }
            set
            {
                this.BrandIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BrandName
        {
            get
            {
                return this.BrandNameField;
            }
            set
            {
                this.BrandNameField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IAdDataService")]
public interface IAdDataService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdDataService/GetAdDataByDateRange", ReplyAction="http://tempuri.org/IAdDataService/GetAdDataByDateRangeResponse")]
    AdDataService.Ad[] GetAdDataByDateRange(System.DateTime startDate, System.DateTime endDate);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAdDataService/GetAdDataByDateRange", ReplyAction="http://tempuri.org/IAdDataService/GetAdDataByDateRangeResponse")]
    System.Threading.Tasks.Task<AdDataService.Ad[]> GetAdDataByDateRangeAsync(System.DateTime startDate, System.DateTime endDate);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IAdDataServiceChannel : IAdDataService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class AdDataServiceClient : System.ServiceModel.ClientBase<IAdDataService>, IAdDataService
{
    
    public AdDataServiceClient()
    {
    }
    
    public AdDataServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public AdDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public AdDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public AdDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public AdDataService.Ad[] GetAdDataByDateRange(System.DateTime startDate, System.DateTime endDate)
    {
        return base.Channel.GetAdDataByDateRange(startDate, endDate);
    }
    
    public System.Threading.Tasks.Task<AdDataService.Ad[]> GetAdDataByDateRangeAsync(System.DateTime startDate, System.DateTime endDate)
    {
        return base.Channel.GetAdDataByDateRangeAsync(startDate, endDate);
    }
}
