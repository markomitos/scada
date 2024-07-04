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
        void AddAnalogInputTag(Scada.models.AnalogInputTag analogInputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddAnalogInputTag", ReplyAction="http://tempuri.org/ITagService/AddAnalogInputTagResponse")]
        System.Threading.Tasks.Task AddAnalogInputTagAsync(Scada.models.AnalogInputTag analogInputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateAnalogInputTag", ReplyAction="http://tempuri.org/ITagService/UpdateAnalogInputTagResponse")]
        Scada.models.AnalogInputTag UpdateAnalogInputTag(Scada.models.AnalogInputTag analogInput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateAnalogInputTag", ReplyAction="http://tempuri.org/ITagService/UpdateAnalogInputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.AnalogInputTag> UpdateAnalogInputTagAsync(Scada.models.AnalogInputTag analogInput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllAnalogOutputTags", ReplyAction="http://tempuri.org/ITagService/GetAllAnalogOutputTagsResponse")]
        Scada.models.AnalogOutputTag[] GetAllAnalogOutputTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllAnalogOutputTags", ReplyAction="http://tempuri.org/ITagService/GetAllAnalogOutputTagsResponse")]
        System.Threading.Tasks.Task<Scada.models.AnalogOutputTag[]> GetAllAnalogOutputTagsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/GetAnalogOutputTagResponse")]
        Scada.models.AnalogOutputTag GetAnalogOutputTag(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/GetAnalogOutputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.AnalogOutputTag> GetAnalogOutputTagAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/AddAnalogOutputTagResponse")]
        void AddAnalogOutputTag(Scada.models.AnalogOutputTag analogOutputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/AddAnalogOutputTagResponse")]
        System.Threading.Tasks.Task AddAnalogOutputTagAsync(Scada.models.AnalogOutputTag analogOutputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/UpdateAnalogOutputTagResponse")]
        Scada.models.AnalogOutputTag UpdateAnalogOutputTag(Scada.models.AnalogOutputTag analogOutput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateAnalogOutputTag", ReplyAction="http://tempuri.org/ITagService/UpdateAnalogOutputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.AnalogOutputTag> UpdateAnalogOutputTagAsync(Scada.models.AnalogOutputTag analogOutput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllDigitalInputTags", ReplyAction="http://tempuri.org/ITagService/GetAllDigitalInputTagsResponse")]
        Scada.models.DigitalInputTag[] GetAllDigitalInputTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllDigitalInputTags", ReplyAction="http://tempuri.org/ITagService/GetAllDigitalInputTagsResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalInputTag[]> GetAllDigitalInputTagsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/GetDigitalInputTagResponse")]
        Scada.models.DigitalInputTag GetDigitalInputTag(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/GetDigitalInputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalInputTag> GetDigitalInputTagAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/AddDigitalInputTagResponse")]
        void AddDigitalInputTag(Scada.models.DigitalInputTag digitalInputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/AddDigitalInputTagResponse")]
        System.Threading.Tasks.Task AddDigitalInputTagAsync(Scada.models.DigitalInputTag digitalInputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/UpdateDigitalInputTagResponse")]
        Scada.models.DigitalInputTag UpdateDigitalInputTag(Scada.models.DigitalInputTag digitalInput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateDigitalInputTag", ReplyAction="http://tempuri.org/ITagService/UpdateDigitalInputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalInputTag> UpdateDigitalInputTagAsync(Scada.models.DigitalInputTag digitalInput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllDigitalOutputTags", ReplyAction="http://tempuri.org/ITagService/GetAllDigitalOutputTagsResponse")]
        Scada.models.DigitalOutputTag[] GetAllDigitalOutputTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllDigitalOutputTags", ReplyAction="http://tempuri.org/ITagService/GetAllDigitalOutputTagsResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalOutputTag[]> GetAllDigitalOutputTagsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/GetDigitalOutputTagResponse")]
        Scada.models.DigitalOutputTag GetDigitalOutputTag(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/GetDigitalOutputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalOutputTag> GetDigitalOutputTagAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/AddDigitalOutputTagResponse")]
        void AddDigitalOutputTag(Scada.models.DigitalOutputTag digitalOutputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/AddDigitalOutputTagResponse")]
        System.Threading.Tasks.Task AddDigitalOutputTagAsync(Scada.models.DigitalOutputTag digitalOutputTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/UpdateDigitalOutputTagResponse")]
        Scada.models.DigitalOutputTag UpdateDigitalOutputTag(Scada.models.DigitalOutputTag digitalOutput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateDigitalOutputTag", ReplyAction="http://tempuri.org/ITagService/UpdateDigitalOutputTagResponse")]
        System.Threading.Tasks.Task<Scada.models.DigitalOutputTag> UpdateDigitalOutputTagAsync(Scada.models.DigitalOutputTag digitalOutput);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/RemoveTag", ReplyAction="http://tempuri.org/ITagService/RemoveTagResponse")]
        bool RemoveTag(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/RemoveTag", ReplyAction="http://tempuri.org/ITagService/RemoveTagResponse")]
        System.Threading.Tasks.Task<bool> RemoveTagAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/IsTagNameUnique", ReplyAction="http://tempuri.org/ITagService/IsTagNameUniqueResponse")]
        bool IsTagNameUnique(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/IsTagNameUnique", ReplyAction="http://tempuri.org/ITagService/IsTagNameUniqueResponse")]
        System.Threading.Tasks.Task<bool> IsTagNameUniqueAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddTagValue", ReplyAction="http://tempuri.org/ITagService/AddTagValueResponse")]
        void AddTagValue(Scada.models.TagValue tagValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/AddTagValue", ReplyAction="http://tempuri.org/ITagService/AddTagValueResponse")]
        System.Threading.Tasks.Task AddTagValueAsync(Scada.models.TagValue tagValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/RemoveTagValue", ReplyAction="http://tempuri.org/ITagService/RemoveTagValueResponse")]
        void RemoveTagValue(string tagValueId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/RemoveTagValue", ReplyAction="http://tempuri.org/ITagService/RemoveTagValueResponse")]
        System.Threading.Tasks.Task RemoveTagValueAsync(string tagValueId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateTagValue", ReplyAction="http://tempuri.org/ITagService/UpdateTagValueResponse")]
        void UpdateTagValue(Scada.models.TagValue tagValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/UpdateTagValue", ReplyAction="http://tempuri.org/ITagService/UpdateTagValueResponse")]
        System.Threading.Tasks.Task UpdateTagValueAsync(Scada.models.TagValue tagValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetTagValue", ReplyAction="http://tempuri.org/ITagService/GetTagValueResponse")]
        Scada.models.TagValue GetTagValue(string tagValueId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetTagValue", ReplyAction="http://tempuri.org/ITagService/GetTagValueResponse")]
        System.Threading.Tasks.Task<Scada.models.TagValue> GetTagValueAsync(string tagValueId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllTagValues", ReplyAction="http://tempuri.org/ITagService/GetAllTagValuesResponse")]
        Scada.models.TagValue[] GetAllTagValues();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetAllTagValues", ReplyAction="http://tempuri.org/ITagService/GetAllTagValuesResponse")]
        System.Threading.Tasks.Task<Scada.models.TagValue[]> GetAllTagValuesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetLastTagValue", ReplyAction="http://tempuri.org/ITagService/GetLastTagValueResponse")]
        Scada.models.TagValue GetLastTagValue(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/GetLastTagValue", ReplyAction="http://tempuri.org/ITagService/GetLastTagValueResponse")]
        System.Threading.Tasks.Task<Scada.models.TagValue> GetLastTagValueAsync(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/getRTUValue", ReplyAction="http://tempuri.org/ITagService/getRTUValueResponse")]
        double getRTUValue(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/getRTUValue", ReplyAction="http://tempuri.org/ITagService/getRTUValueResponse")]
        System.Threading.Tasks.Task<double> getRTUValueAsync(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/setRTUValue", ReplyAction="http://tempuri.org/ITagService/setRTUValueResponse")]
        void setRTUValue(string address, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagService/setRTUValue", ReplyAction="http://tempuri.org/ITagService/setRTUValueResponse")]
        System.Threading.Tasks.Task setRTUValueAsync(string address, double value);
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
        
        public void AddAnalogInputTag(Scada.models.AnalogInputTag analogInputTag) {
            base.Channel.AddAnalogInputTag(analogInputTag);
        }
        
        public System.Threading.Tasks.Task AddAnalogInputTagAsync(Scada.models.AnalogInputTag analogInputTag) {
            return base.Channel.AddAnalogInputTagAsync(analogInputTag);
        }
        
        public Scada.models.AnalogInputTag UpdateAnalogInputTag(Scada.models.AnalogInputTag analogInput) {
            return base.Channel.UpdateAnalogInputTag(analogInput);
        }
        
        public System.Threading.Tasks.Task<Scada.models.AnalogInputTag> UpdateAnalogInputTagAsync(Scada.models.AnalogInputTag analogInput) {
            return base.Channel.UpdateAnalogInputTagAsync(analogInput);
        }
        
        public Scada.models.AnalogOutputTag[] GetAllAnalogOutputTags() {
            return base.Channel.GetAllAnalogOutputTags();
        }
        
        public System.Threading.Tasks.Task<Scada.models.AnalogOutputTag[]> GetAllAnalogOutputTagsAsync() {
            return base.Channel.GetAllAnalogOutputTagsAsync();
        }
        
        public Scada.models.AnalogOutputTag GetAnalogOutputTag(string name) {
            return base.Channel.GetAnalogOutputTag(name);
        }
        
        public System.Threading.Tasks.Task<Scada.models.AnalogOutputTag> GetAnalogOutputTagAsync(string name) {
            return base.Channel.GetAnalogOutputTagAsync(name);
        }
        
        public void AddAnalogOutputTag(Scada.models.AnalogOutputTag analogOutputTag) {
            base.Channel.AddAnalogOutputTag(analogOutputTag);
        }
        
        public System.Threading.Tasks.Task AddAnalogOutputTagAsync(Scada.models.AnalogOutputTag analogOutputTag) {
            return base.Channel.AddAnalogOutputTagAsync(analogOutputTag);
        }
        
        public Scada.models.AnalogOutputTag UpdateAnalogOutputTag(Scada.models.AnalogOutputTag analogOutput) {
            return base.Channel.UpdateAnalogOutputTag(analogOutput);
        }
        
        public System.Threading.Tasks.Task<Scada.models.AnalogOutputTag> UpdateAnalogOutputTagAsync(Scada.models.AnalogOutputTag analogOutput) {
            return base.Channel.UpdateAnalogOutputTagAsync(analogOutput);
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
        
        public void AddDigitalInputTag(Scada.models.DigitalInputTag digitalInputTag) {
            base.Channel.AddDigitalInputTag(digitalInputTag);
        }
        
        public System.Threading.Tasks.Task AddDigitalInputTagAsync(Scada.models.DigitalInputTag digitalInputTag) {
            return base.Channel.AddDigitalInputTagAsync(digitalInputTag);
        }
        
        public Scada.models.DigitalInputTag UpdateDigitalInputTag(Scada.models.DigitalInputTag digitalInput) {
            return base.Channel.UpdateDigitalInputTag(digitalInput);
        }
        
        public System.Threading.Tasks.Task<Scada.models.DigitalInputTag> UpdateDigitalInputTagAsync(Scada.models.DigitalInputTag digitalInput) {
            return base.Channel.UpdateDigitalInputTagAsync(digitalInput);
        }
        
        public Scada.models.DigitalOutputTag[] GetAllDigitalOutputTags() {
            return base.Channel.GetAllDigitalOutputTags();
        }
        
        public System.Threading.Tasks.Task<Scada.models.DigitalOutputTag[]> GetAllDigitalOutputTagsAsync() {
            return base.Channel.GetAllDigitalOutputTagsAsync();
        }
        
        public Scada.models.DigitalOutputTag GetDigitalOutputTag(string name) {
            return base.Channel.GetDigitalOutputTag(name);
        }
        
        public System.Threading.Tasks.Task<Scada.models.DigitalOutputTag> GetDigitalOutputTagAsync(string name) {
            return base.Channel.GetDigitalOutputTagAsync(name);
        }
        
        public void AddDigitalOutputTag(Scada.models.DigitalOutputTag digitalOutputTag) {
            base.Channel.AddDigitalOutputTag(digitalOutputTag);
        }
        
        public System.Threading.Tasks.Task AddDigitalOutputTagAsync(Scada.models.DigitalOutputTag digitalOutputTag) {
            return base.Channel.AddDigitalOutputTagAsync(digitalOutputTag);
        }
        
        public Scada.models.DigitalOutputTag UpdateDigitalOutputTag(Scada.models.DigitalOutputTag digitalOutput) {
            return base.Channel.UpdateDigitalOutputTag(digitalOutput);
        }
        
        public System.Threading.Tasks.Task<Scada.models.DigitalOutputTag> UpdateDigitalOutputTagAsync(Scada.models.DigitalOutputTag digitalOutput) {
            return base.Channel.UpdateDigitalOutputTagAsync(digitalOutput);
        }
        
        public bool RemoveTag(string name) {
            return base.Channel.RemoveTag(name);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveTagAsync(string name) {
            return base.Channel.RemoveTagAsync(name);
        }
        
        public bool IsTagNameUnique(string name) {
            return base.Channel.IsTagNameUnique(name);
        }
        
        public System.Threading.Tasks.Task<bool> IsTagNameUniqueAsync(string name) {
            return base.Channel.IsTagNameUniqueAsync(name);
        }
        
        public void AddTagValue(Scada.models.TagValue tagValue) {
            base.Channel.AddTagValue(tagValue);
        }
        
        public System.Threading.Tasks.Task AddTagValueAsync(Scada.models.TagValue tagValue) {
            return base.Channel.AddTagValueAsync(tagValue);
        }
        
        public void RemoveTagValue(string tagValueId) {
            base.Channel.RemoveTagValue(tagValueId);
        }
        
        public System.Threading.Tasks.Task RemoveTagValueAsync(string tagValueId) {
            return base.Channel.RemoveTagValueAsync(tagValueId);
        }
        
        public void UpdateTagValue(Scada.models.TagValue tagValue) {
            base.Channel.UpdateTagValue(tagValue);
        }
        
        public System.Threading.Tasks.Task UpdateTagValueAsync(Scada.models.TagValue tagValue) {
            return base.Channel.UpdateTagValueAsync(tagValue);
        }
        
        public Scada.models.TagValue GetTagValue(string tagValueId) {
            return base.Channel.GetTagValue(tagValueId);
        }
        
        public System.Threading.Tasks.Task<Scada.models.TagValue> GetTagValueAsync(string tagValueId) {
            return base.Channel.GetTagValueAsync(tagValueId);
        }
        
        public Scada.models.TagValue[] GetAllTagValues() {
            return base.Channel.GetAllTagValues();
        }
        
        public System.Threading.Tasks.Task<Scada.models.TagValue[]> GetAllTagValuesAsync() {
            return base.Channel.GetAllTagValuesAsync();
        }
        
        public Scada.models.TagValue GetLastTagValue(string tagName) {
            return base.Channel.GetLastTagValue(tagName);
        }
        
        public System.Threading.Tasks.Task<Scada.models.TagValue> GetLastTagValueAsync(string tagName) {
            return base.Channel.GetLastTagValueAsync(tagName);
        }
        
        public double getRTUValue(string address) {
            return base.Channel.getRTUValue(address);
        }
        
        public System.Threading.Tasks.Task<double> getRTUValueAsync(string address) {
            return base.Channel.getRTUValueAsync(address);
        }
        
        public void setRTUValue(string address, double value) {
            base.Channel.setRTUValue(address, value);
        }
        
        public System.Threading.Tasks.Task setRTUValueAsync(string address, double value) {
            return base.Channel.setRTUValueAsync(address, value);
        }
    }
}
