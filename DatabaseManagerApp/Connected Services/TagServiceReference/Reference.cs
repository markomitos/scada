﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseManagerApp.TagServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TagServiceReference.ITagService")]
    public interface ITagService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/Hello", ReplyAction="http://tempuri.org/ITagService/HelloResponse")]
        void Hello();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/Hello", ReplyAction="http://tempuri.org/ITagService/HelloResponse")]
        System.Threading.Tasks.Task HelloAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllAnalogInputTags", ReplyAction="http://tempuri.org/ITagService/GetAllAnalogInputTagsResponse")]
        Scada.models.AnalogInputTag[] GetAllAnalogInputTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllAnalogInputTags", ReplyAction="http://tempuri.org/ITagService/GetAllAnalogInputTagsResponse")]
        System.Threading.Tasks.Task<Scada.models.AnalogInputTag[]> GetAllAnalogInputTagsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAnalogInputTag", ReplyAction="http://tempuri.org/ITagService/GetAnalogInputTagResponse")]
        Scada.models.AnalogInputTag GetAnalogInputTag(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAnalogInputTag", ReplyAction="http://tempuri.org/ITagService/GetAnalogInputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.AnalogInputTag> GetAnalogInputTagAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddAnalogInputTag", ReplyAction="http://tempuri.org/ITagService/AddAnalogInputTagResponse")]
        void AddAnalogInputTag(string token, Scada.models.AnalogInputTag analogInputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddAnalogInputTag", ReplyAction="http://tempuri.org/ITagService/AddAnalogInputTagResponse")]
        System.Threading.Tasks.Task AddAnalogInputTagAsync(string token, Scada.models.AnalogInputTag analogInputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateAnalogInputTag", ReplyAction="http://tempuri.org/ITagService/UpdateAnalogInputTagResponse")]
        Scada.models.AnalogInputTag UpdateAnalogInputTag(string token, Scada.models.AnalogInputTag analogInput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateAnalogInputTag", ReplyAction="http://tempuri.org/ITagService/UpdateAnalogInputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.AnalogInputTag> UpdateAnalogInputTagAsync(string token, Scada.models.AnalogInputTag analogInput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllAnalogOutputTags", ReplyAction="http://tempuri.org/ITagService/GetAllAnalogOutputTagsResponse")]
        Scada.models.AnalogOutputTag[] GetAllAnalogOutputTags(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllAnalogOutputTags", ReplyAction="http://tempuri.org/ITagService/GetAllAnalogOutputTagsResponse")]
        System.Threading.Tasks.Task<Scada.models.AnalogOutputTag[]> GetAllAnalogOutputTagsAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/GetAnalogOutputTagResponse")]
        Scada.models.AnalogOutputTag GetAnalogOutputTag(string token, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/GetAnalogOutputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.AnalogOutputTag> GetAnalogOutputTagAsync(string token, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/AddAnalogOutputTagResponse")]
        void AddAnalogOutputTag(string token, Scada.models.AnalogOutputTag analogOutputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/AddAnalogOutputTagResponse")]
        System.Threading.Tasks.Task AddAnalogOutputTagAsync(string token, Scada.models.AnalogOutputTag analogOutputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/UpdateAnalogOutputTagResponse")]
        Scada.models.AnalogOutputTag UpdateAnalogOutputTag(string token, Scada.models.AnalogOutputTag analogOutput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/UpdateAnalogOutputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.AnalogOutputTag> UpdateAnalogOutputTagAsync(string token, Scada.models.AnalogOutputTag analogOutput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllDigitalInputTags", ReplyAction="http://tempuri.org/ITagService/GetAllDigitalInputTagsResponse")]
        Scada.models.DigitalInputTag[] GetAllDigitalInputTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllDigitalInputTags", ReplyAction="http://tempuri.org/ITagService/GetAllDigitalInputTagsResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalInputTag[]> GetAllDigitalInputTagsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/GetDigitalInputTagResponse")]
        Scada.models.DigitalInputTag GetDigitalInputTag(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/GetDigitalInputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalInputTag> GetDigitalInputTagAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/AddDigitalInputTagResponse")]
        void AddDigitalInputTag(string token, Scada.models.DigitalInputTag digitalInputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/AddDigitalInputTagResponse")]
        System.Threading.Tasks.Task AddDigitalInputTagAsync(string token, Scada.models.DigitalInputTag digitalInputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/UpdateDigitalInputTagResponse")]
        Scada.models.DigitalInputTag UpdateDigitalInputTag(string token, Scada.models.DigitalInputTag digitalInput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/UpdateDigitalInputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalInputTag> UpdateDigitalInputTagAsync(string token, Scada.models.DigitalInputTag digitalInput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllDigitalOutputTags", ReplyAction="http://tempuri.org/ITagService/GetAllDigitalOutputTagsResponse")]
        Scada.models.DigitalOutputTag[] GetAllDigitalOutputTags(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllDigitalOutputTags", ReplyAction="http://tempuri.org/ITagService/GetAllDigitalOutputTagsResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalOutputTag[]> GetAllDigitalOutputTagsAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/GetDigitalOutputTagResponse")]
        Scada.models.DigitalOutputTag GetDigitalOutputTag(string token, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/GetDigitalOutputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalOutputTag> GetDigitalOutputTagAsync(string token, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/AddDigitalOutputTagResponse")]
        void AddDigitalOutputTag(string token, Scada.models.DigitalOutputTag digitalOutputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/AddDigitalOutputTagResponse")]
        System.Threading.Tasks.Task AddDigitalOutputTagAsync(string token, Scada.models.DigitalOutputTag digitalOutputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/UpdateDigitalOutputTagResponse")]
        Scada.models.DigitalOutputTag UpdateDigitalOutputTag(string token, Scada.models.DigitalOutputTag digitalOutput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/UpdateDigitalOutputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalOutputTag> UpdateDigitalOutputTagAsync(string token, Scada.models.DigitalOutputTag digitalOutput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/RemoveTag", ReplyAction="http://tempuri.org/ITagService/RemoveTagResponse")]
        bool RemoveTag(string token, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/RemoveTag", ReplyAction="http://tempuri.org/ITagService/RemoveTagResponse")]
        System.Threading.Tasks.Task<bool> RemoveTagAsync(string token, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/IsTagNameUnique", ReplyAction="http://tempuri.org/ITagService/IsTagNameUniqueResponse")]
        bool IsTagNameUnique(string token, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/IsTagNameUnique", ReplyAction="http://tempuri.org/ITagService/IsTagNameUniqueResponse")]
        System.Threading.Tasks.Task<bool> IsTagNameUniqueAsync(string token, string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddTagValue", ReplyAction="http://tempuri.org/ITagService/AddTagValueResponse")]
        void AddTagValue(Scada.models.TagValue tagValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddTagValue", ReplyAction="http://tempuri.org/ITagService/AddTagValueResponse")]
        System.Threading.Tasks.Task AddTagValueAsync(Scada.models.TagValue tagValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/RemoveTagValue", ReplyAction="http://tempuri.org/ITagService/RemoveTagValueResponse")]
        void RemoveTagValue(string token, string tagValueId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/RemoveTagValue", ReplyAction="http://tempuri.org/ITagService/RemoveTagValueResponse")]
        System.Threading.Tasks.Task RemoveTagValueAsync(string token, string tagValueId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateTagValue", ReplyAction="http://tempuri.org/ITagService/UpdateTagValueResponse")]
        void UpdateTagValue(string token, Scada.models.TagValue tagValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateTagValue", ReplyAction="http://tempuri.org/ITagService/UpdateTagValueResponse")]
        System.Threading.Tasks.Task UpdateTagValueAsync(string token, Scada.models.TagValue tagValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetTagValue", ReplyAction="http://tempuri.org/ITagService/GetTagValueResponse")]
        Scada.models.TagValue GetTagValue(string token, string tagValueId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetTagValue", ReplyAction="http://tempuri.org/ITagService/GetTagValueResponse")]
        System.Threading.Tasks.Task<Scada.models.TagValue> GetTagValueAsync(string token, string tagValueId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllTagValues", ReplyAction="http://tempuri.org/ITagService/GetAllTagValuesResponse")]
        Scada.models.TagValue[] GetAllTagValues(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllTagValues", ReplyAction="http://tempuri.org/ITagService/GetAllTagValuesResponse")]
        System.Threading.Tasks.Task<Scada.models.TagValue[]> GetAllTagValuesAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetLastTagValue", ReplyAction="http://tempuri.org/ITagService/GetLastTagValueResponse")]
        Scada.models.TagValue GetLastTagValue(string token, string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetLastTagValue", ReplyAction="http://tempuri.org/ITagService/GetLastTagValueResponse")]
        System.Threading.Tasks.Task<Scada.models.TagValue> GetLastTagValueAsync(string token, string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/getRTUValue", ReplyAction="http://tempuri.org/ITagService/getRTUValueResponse")]
        double getRTUValue(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/getRTUValue", ReplyAction="http://tempuri.org/ITagService/getRTUValueResponse")]
        System.Threading.Tasks.Task<double> getRTUValueAsync(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/setRTUValue", ReplyAction="http://tempuri.org/ITagService/setRTUValueResponse")]
        void setRTUValue(string address, double value, string signatureBase64, string hashValueBase64);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/setRTUValue", ReplyAction="http://tempuri.org/ITagService/setRTUValueResponse")]
        System.Threading.Tasks.Task setRTUValueAsync(string address, double value, string signatureBase64, string hashValueBase64);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITagServiceChannel : DatabaseManagerApp.TagServiceReference.ITagService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TagServiceClient : System.ServiceModel.ClientBase<DatabaseManagerApp.TagServiceReference.ITagService>, DatabaseManagerApp.TagServiceReference.ITagService {
        
        public TagServiceClient() {
        }
        
        public TagServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TagServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TagServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TagServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Hello() {
            base.Channel.Hello();
        }
        
        public System.Threading.Tasks.Task HelloAsync() {
            return base.Channel.HelloAsync();
        }
        
        public Scada.models.AnalogInputTag[] GetAllAnalogInputTags() {
            return base.Channel.GetAllAnalogInputTags();
        }
        
        public System.Threading.Tasks.Task<Scada.models.AnalogInputTag[]> GetAllAnalogInputTagsAsync() {
            return base.Channel.GetAllAnalogInputTagsAsync();
        }
        
        public Scada.models.AnalogInputTag GetAnalogInputTag(string name) {
            return base.Channel.GetAnalogInputTag(name);
        }
        
        public System.Threading.Tasks.Task<Scada.models.AnalogInputTag> GetAnalogInputTagAsync(string name) {
            return base.Channel.GetAnalogInputTagAsync(name);
        }
        
        public void AddAnalogInputTag(string token, Scada.models.AnalogInputTag analogInputTag) {
            base.Channel.AddAnalogInputTag(token, analogInputTag);
        }
        
        public System.Threading.Tasks.Task AddAnalogInputTagAsync(string token, Scada.models.AnalogInputTag analogInputTag) {
            return base.Channel.AddAnalogInputTagAsync(token, analogInputTag);
        }
        
        public Scada.models.AnalogInputTag UpdateAnalogInputTag(string token, Scada.models.AnalogInputTag analogInput) {
            return base.Channel.UpdateAnalogInputTag(token, analogInput);
        }
        
        public System.Threading.Tasks.Task<Scada.models.AnalogInputTag> UpdateAnalogInputTagAsync(string token, Scada.models.AnalogInputTag analogInput) {
            return base.Channel.UpdateAnalogInputTagAsync(token, analogInput);
        }
        
        public Scada.models.AnalogOutputTag[] GetAllAnalogOutputTags(string token) {
            return base.Channel.GetAllAnalogOutputTags(token);
        }
        
        public System.Threading.Tasks.Task<Scada.models.AnalogOutputTag[]> GetAllAnalogOutputTagsAsync(string token) {
            return base.Channel.GetAllAnalogOutputTagsAsync(token);
        }
        
        public Scada.models.AnalogOutputTag GetAnalogOutputTag(string token, string name) {
            return base.Channel.GetAnalogOutputTag(token, name);
        }
        
        public System.Threading.Tasks.Task<Scada.models.AnalogOutputTag> GetAnalogOutputTagAsync(string token, string name) {
            return base.Channel.GetAnalogOutputTagAsync(token, name);
        }
        
        public void AddAnalogOutputTag(string token, Scada.models.AnalogOutputTag analogOutputTag) {
            base.Channel.AddAnalogOutputTag(token, analogOutputTag);
        }
        
        public System.Threading.Tasks.Task AddAnalogOutputTagAsync(string token, Scada.models.AnalogOutputTag analogOutputTag) {
            return base.Channel.AddAnalogOutputTagAsync(token, analogOutputTag);
        }
        
        public Scada.models.AnalogOutputTag UpdateAnalogOutputTag(string token, Scada.models.AnalogOutputTag analogOutput) {
            return base.Channel.UpdateAnalogOutputTag(token, analogOutput);
        }
        
        public System.Threading.Tasks.Task<Scada.models.AnalogOutputTag> UpdateAnalogOutputTagAsync(string token, Scada.models.AnalogOutputTag analogOutput) {
            return base.Channel.UpdateAnalogOutputTagAsync(token, analogOutput);
        }
        
        public Scada.models.DigitalInputTag[] GetAllDigitalInputTags() {
            return base.Channel.GetAllDigitalInputTags();
        }
        
        public System.Threading.Tasks.Task<Scada.models.DigitalInputTag[]> GetAllDigitalInputTagsAsync() {
            return base.Channel.GetAllDigitalInputTagsAsync();
        }
        
        public Scada.models.DigitalInputTag GetDigitalInputTag(string name) {
            return base.Channel.GetDigitalInputTag(name);
        }
        
        public System.Threading.Tasks.Task<Scada.models.DigitalInputTag> GetDigitalInputTagAsync(string name) {
            return base.Channel.GetDigitalInputTagAsync(name);
        }
        
        public void AddDigitalInputTag(string token, Scada.models.DigitalInputTag digitalInputTag) {
            base.Channel.AddDigitalInputTag(token, digitalInputTag);
        }
        
        public System.Threading.Tasks.Task AddDigitalInputTagAsync(string token, Scada.models.DigitalInputTag digitalInputTag) {
            return base.Channel.AddDigitalInputTagAsync(token, digitalInputTag);
        }
        
        public Scada.models.DigitalInputTag UpdateDigitalInputTag(string token, Scada.models.DigitalInputTag digitalInput) {
            return base.Channel.UpdateDigitalInputTag(token, digitalInput);
        }
        
        public System.Threading.Tasks.Task<Scada.models.DigitalInputTag> UpdateDigitalInputTagAsync(string token, Scada.models.DigitalInputTag digitalInput) {
            return base.Channel.UpdateDigitalInputTagAsync(token, digitalInput);
        }
        
        public Scada.models.DigitalOutputTag[] GetAllDigitalOutputTags(string token) {
            return base.Channel.GetAllDigitalOutputTags(token);
        }
        
        public System.Threading.Tasks.Task<Scada.models.DigitalOutputTag[]> GetAllDigitalOutputTagsAsync(string token) {
            return base.Channel.GetAllDigitalOutputTagsAsync(token);
        }
        
        public Scada.models.DigitalOutputTag GetDigitalOutputTag(string token, string name) {
            return base.Channel.GetDigitalOutputTag(token, name);
        }
        
        public System.Threading.Tasks.Task<Scada.models.DigitalOutputTag> GetDigitalOutputTagAsync(string token, string name) {
            return base.Channel.GetDigitalOutputTagAsync(token, name);
        }
        
        public void AddDigitalOutputTag(string token, Scada.models.DigitalOutputTag digitalOutputTag) {
            base.Channel.AddDigitalOutputTag(token, digitalOutputTag);
        }
        
        public System.Threading.Tasks.Task AddDigitalOutputTagAsync(string token, Scada.models.DigitalOutputTag digitalOutputTag) {
            return base.Channel.AddDigitalOutputTagAsync(token, digitalOutputTag);
        }
        
        public Scada.models.DigitalOutputTag UpdateDigitalOutputTag(string token, Scada.models.DigitalOutputTag digitalOutput) {
            return base.Channel.UpdateDigitalOutputTag(token, digitalOutput);
        }
        
        public System.Threading.Tasks.Task<Scada.models.DigitalOutputTag> UpdateDigitalOutputTagAsync(string token, Scada.models.DigitalOutputTag digitalOutput) {
            return base.Channel.UpdateDigitalOutputTagAsync(token, digitalOutput);
        }
        
        public bool RemoveTag(string token, string name) {
            return base.Channel.RemoveTag(token, name);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveTagAsync(string token, string name) {
            return base.Channel.RemoveTagAsync(token, name);
        }
        
        public bool IsTagNameUnique(string token, string name) {
            return base.Channel.IsTagNameUnique(token, name);
        }
        
        public System.Threading.Tasks.Task<bool> IsTagNameUniqueAsync(string token, string name) {
            return base.Channel.IsTagNameUniqueAsync(token, name);
        }
        
        public void AddTagValue(Scada.models.TagValue tagValue) {
            base.Channel.AddTagValue(tagValue);
        }
        
        public System.Threading.Tasks.Task AddTagValueAsync(Scada.models.TagValue tagValue) {
            return base.Channel.AddTagValueAsync(tagValue);
        }
        
        public void RemoveTagValue(string token, string tagValueId) {
            base.Channel.RemoveTagValue(token, tagValueId);
        }
        
        public System.Threading.Tasks.Task RemoveTagValueAsync(string token, string tagValueId) {
            return base.Channel.RemoveTagValueAsync(token, tagValueId);
        }
        
        public void UpdateTagValue(string token, Scada.models.TagValue tagValue) {
            base.Channel.UpdateTagValue(token, tagValue);
        }
        
        public System.Threading.Tasks.Task UpdateTagValueAsync(string token, Scada.models.TagValue tagValue) {
            return base.Channel.UpdateTagValueAsync(token, tagValue);
        }
        
        public Scada.models.TagValue GetTagValue(string token, string tagValueId) {
            return base.Channel.GetTagValue(token, tagValueId);
        }
        
        public System.Threading.Tasks.Task<Scada.models.TagValue> GetTagValueAsync(string token, string tagValueId) {
            return base.Channel.GetTagValueAsync(token, tagValueId);
        }
        
        public Scada.models.TagValue[] GetAllTagValues(string token) {
            return base.Channel.GetAllTagValues(token);
        }
        
        public System.Threading.Tasks.Task<Scada.models.TagValue[]> GetAllTagValuesAsync(string token) {
            return base.Channel.GetAllTagValuesAsync(token);
        }
        
        public Scada.models.TagValue GetLastTagValue(string token, string tagName) {
            return base.Channel.GetLastTagValue(token, tagName);
        }
        
        public System.Threading.Tasks.Task<Scada.models.TagValue> GetLastTagValueAsync(string token, string tagName) {
            return base.Channel.GetLastTagValueAsync(token, tagName);
        }
        
        public double getRTUValue(string address) {
            return base.Channel.getRTUValue(address);
        }
        
        public System.Threading.Tasks.Task<double> getRTUValueAsync(string address) {
            return base.Channel.getRTUValueAsync(address);
        }
        
        public void setRTUValue(string address, double value, string signatureBase64, string hashValueBase64) {
            base.Channel.setRTUValue(address, value, signatureBase64, hashValueBase64);
        }
        
        public System.Threading.Tasks.Task setRTUValueAsync(string address, double value, string signatureBase64, string hashValueBase64) {
            return base.Channel.setRTUValueAsync(address, value, signatureBase64, hashValueBase64);
        }
    }
}
