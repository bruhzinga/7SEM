﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinFormApp.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="A", Namespace="http://zda/")]
    [System.SerializableAttribute()]
    public partial class A : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string sField;
        
        private int kField;
        
        private float fField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string s {
            get {
                return this.sField;
            }
            set {
                if ((object.ReferenceEquals(this.sField, value) != true)) {
                    this.sField = value;
                    this.RaisePropertyChanged("s");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public int k {
            get {
                return this.kField;
            }
            set {
                if ((this.kField.Equals(value) != true)) {
                    this.kField = value;
                    this.RaisePropertyChanged("k");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public float f {
            get {
                return this.fField;
            }
            set {
                if ((this.fField.Equals(value) != true)) {
                    this.fField = value;
                    this.RaisePropertyChanged("f");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://zda/", ConfigurationName="ServiceReference1.SimplexSoap")]
    public interface SimplexSoap {
        
        // CODEGEN: Контракт генерации сообщений с именем упаковщика (add) сообщения add не соответствует значению по умолчанию (Add).
        [System.ServiceModel.OperationContractAttribute(Action="http://zda/add", ReplyAction="*")]
        WinFormApp.ServiceReference1.add1 Add(WinFormApp.ServiceReference1.add request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://zda/add", ReplyAction="*")]
        System.Threading.Tasks.Task<WinFormApp.ServiceReference1.add1> AddAsync(WinFormApp.ServiceReference1.add request);
        
        // CODEGEN: Контракт генерации сообщений с именем упаковщика (concat) сообщения concat не соответствует значению по умолчанию (Concat).
        [System.ServiceModel.OperationContractAttribute(Action="http://zda/concat", ReplyAction="*")]
        WinFormApp.ServiceReference1.concat1 Concat(WinFormApp.ServiceReference1.concat request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://zda/concat", ReplyAction="*")]
        System.Threading.Tasks.Task<WinFormApp.ServiceReference1.concat1> ConcatAsync(WinFormApp.ServiceReference1.concat request);
        
        // CODEGEN: Контракт генерации сообщений с именем упаковщика (sum) сообщения sum не соответствует значению по умолчанию (Sum).
        [System.ServiceModel.OperationContractAttribute(Action="http://zda/sum", ReplyAction="*")]
        WinFormApp.ServiceReference1.sum1 Sum(WinFormApp.ServiceReference1.sum request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://zda/sum", ReplyAction="*")]
        System.Threading.Tasks.Task<WinFormApp.ServiceReference1.sum1> SumAsync(WinFormApp.ServiceReference1.sum request);
        
        // CODEGEN: Контракт генерации сообщений с именем упаковщика (addS) сообщения addS не соответствует значению по умолчанию (AddS).
        [System.ServiceModel.OperationContractAttribute(Action="http://zda/addS", ReplyAction="*")]
        WinFormApp.ServiceReference1.addS1 AddS(WinFormApp.ServiceReference1.addS request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://zda/addS", ReplyAction="*")]
        System.Threading.Tasks.Task<WinFormApp.ServiceReference1.addS1> AddSAsync(WinFormApp.ServiceReference1.addS request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="add", WrapperNamespace="http://zda/", IsWrapped=true)]
    public partial class add {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=0)]
        public int x;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=1)]
        public int y;
        
        public add() {
        }
        
        public add(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="addResponse", WrapperNamespace="http://zda/", IsWrapped=true)]
    public partial class add1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=0)]
        public int addResult;
        
        public add1() {
        }
        
        public add1(int addResult) {
            this.addResult = addResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="concat", WrapperNamespace="http://zda/", IsWrapped=true)]
    public partial class concat {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=0)]
        public string s;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=1)]
        public double d;
        
        public concat() {
        }
        
        public concat(string s, double d) {
            this.s = s;
            this.d = d;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="concatResponse", WrapperNamespace="http://zda/", IsWrapped=true)]
    public partial class concat1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=0)]
        public string concatResult;
        
        public concat1() {
        }
        
        public concat1(string concatResult) {
            this.concatResult = concatResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sum", WrapperNamespace="http://zda/", IsWrapped=true)]
    public partial class sum {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=0)]
        public WinFormApp.ServiceReference1.A a1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=1)]
        public WinFormApp.ServiceReference1.A a2;
        
        public sum() {
        }
        
        public sum(WinFormApp.ServiceReference1.A a1, WinFormApp.ServiceReference1.A a2) {
            this.a1 = a1;
            this.a2 = a2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sumResponse", WrapperNamespace="http://zda/", IsWrapped=true)]
    public partial class sum1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=0)]
        public WinFormApp.ServiceReference1.A sumResult;
        
        public sum1() {
        }
        
        public sum1(WinFormApp.ServiceReference1.A sumResult) {
            this.sumResult = sumResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="addS", WrapperNamespace="http://zda/", IsWrapped=true)]
    public partial class addS {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=0)]
        public int x;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=1)]
        public int y;
        
        public addS() {
        }
        
        public addS(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="addSResponse", WrapperNamespace="http://zda/", IsWrapped=true)]
    public partial class addS1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://zda/", Order=0)]
        public string addSResult;
        
        public addS1() {
        }
        
        public addS1(string addSResult) {
            this.addSResult = addSResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SimplexSoapChannel : WinFormApp.ServiceReference1.SimplexSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SimplexSoapClient : System.ServiceModel.ClientBase<WinFormApp.ServiceReference1.SimplexSoap>, WinFormApp.ServiceReference1.SimplexSoap {
        
        public SimplexSoapClient() {
        }
        
        public SimplexSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SimplexSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimplexSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimplexSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WinFormApp.ServiceReference1.add1 WinFormApp.ServiceReference1.SimplexSoap.Add(WinFormApp.ServiceReference1.add request) {
            return base.Channel.Add(request);
        }
        
        public int Add(int x, int y) {
            WinFormApp.ServiceReference1.add inValue = new WinFormApp.ServiceReference1.add();
            inValue.x = x;
            inValue.y = y;
            WinFormApp.ServiceReference1.add1 retVal = ((WinFormApp.ServiceReference1.SimplexSoap)(this)).Add(inValue);
            return retVal.addResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WinFormApp.ServiceReference1.add1> WinFormApp.ServiceReference1.SimplexSoap.AddAsync(WinFormApp.ServiceReference1.add request) {
            return base.Channel.AddAsync(request);
        }
        
        public System.Threading.Tasks.Task<WinFormApp.ServiceReference1.add1> AddAsync(int x, int y) {
            WinFormApp.ServiceReference1.add inValue = new WinFormApp.ServiceReference1.add();
            inValue.x = x;
            inValue.y = y;
            return ((WinFormApp.ServiceReference1.SimplexSoap)(this)).AddAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WinFormApp.ServiceReference1.concat1 WinFormApp.ServiceReference1.SimplexSoap.Concat(WinFormApp.ServiceReference1.concat request) {
            return base.Channel.Concat(request);
        }
        
        public string Concat(string s, double d) {
            WinFormApp.ServiceReference1.concat inValue = new WinFormApp.ServiceReference1.concat();
            inValue.s = s;
            inValue.d = d;
            WinFormApp.ServiceReference1.concat1 retVal = ((WinFormApp.ServiceReference1.SimplexSoap)(this)).Concat(inValue);
            return retVal.concatResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WinFormApp.ServiceReference1.concat1> WinFormApp.ServiceReference1.SimplexSoap.ConcatAsync(WinFormApp.ServiceReference1.concat request) {
            return base.Channel.ConcatAsync(request);
        }
        
        public System.Threading.Tasks.Task<WinFormApp.ServiceReference1.concat1> ConcatAsync(string s, double d) {
            WinFormApp.ServiceReference1.concat inValue = new WinFormApp.ServiceReference1.concat();
            inValue.s = s;
            inValue.d = d;
            return ((WinFormApp.ServiceReference1.SimplexSoap)(this)).ConcatAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WinFormApp.ServiceReference1.sum1 WinFormApp.ServiceReference1.SimplexSoap.Sum(WinFormApp.ServiceReference1.sum request) {
            return base.Channel.Sum(request);
        }
        
        public WinFormApp.ServiceReference1.A Sum(WinFormApp.ServiceReference1.A a1, WinFormApp.ServiceReference1.A a2) {
            WinFormApp.ServiceReference1.sum inValue = new WinFormApp.ServiceReference1.sum();
            inValue.a1 = a1;
            inValue.a2 = a2;
            WinFormApp.ServiceReference1.sum1 retVal = ((WinFormApp.ServiceReference1.SimplexSoap)(this)).Sum(inValue);
            return retVal.sumResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WinFormApp.ServiceReference1.sum1> WinFormApp.ServiceReference1.SimplexSoap.SumAsync(WinFormApp.ServiceReference1.sum request) {
            return base.Channel.SumAsync(request);
        }
        
        public System.Threading.Tasks.Task<WinFormApp.ServiceReference1.sum1> SumAsync(WinFormApp.ServiceReference1.A a1, WinFormApp.ServiceReference1.A a2) {
            WinFormApp.ServiceReference1.sum inValue = new WinFormApp.ServiceReference1.sum();
            inValue.a1 = a1;
            inValue.a2 = a2;
            return ((WinFormApp.ServiceReference1.SimplexSoap)(this)).SumAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WinFormApp.ServiceReference1.addS1 WinFormApp.ServiceReference1.SimplexSoap.AddS(WinFormApp.ServiceReference1.addS request) {
            return base.Channel.AddS(request);
        }
        
        public string AddS(int x, int y) {
            WinFormApp.ServiceReference1.addS inValue = new WinFormApp.ServiceReference1.addS();
            inValue.x = x;
            inValue.y = y;
            WinFormApp.ServiceReference1.addS1 retVal = ((WinFormApp.ServiceReference1.SimplexSoap)(this)).AddS(inValue);
            return retVal.addSResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WinFormApp.ServiceReference1.addS1> WinFormApp.ServiceReference1.SimplexSoap.AddSAsync(WinFormApp.ServiceReference1.addS request) {
            return base.Channel.AddSAsync(request);
        }
        
        public System.Threading.Tasks.Task<WinFormApp.ServiceReference1.addS1> AddSAsync(int x, int y) {
            WinFormApp.ServiceReference1.addS inValue = new WinFormApp.ServiceReference1.addS();
            inValue.x = x;
            inValue.y = y;
            return ((WinFormApp.ServiceReference1.SimplexSoap)(this)).AddSAsync(inValue);
        }
    }
}
