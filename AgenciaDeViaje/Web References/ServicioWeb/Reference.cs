﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.544
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.544.
// 
#pragma warning disable 1591

namespace AgenciaDeViaje.ServicioWeb {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServicioDeComunicacionSoap", Namespace="http://localhost/servicioCom")]
    public partial class ServicioDeComunicacion : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback VuelosDisponiblesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServicioDeComunicacion() {
            this.Url = global::AgenciaDeViaje.Properties.Settings.Default.AgenciaDeViaje_ServicioWeb_ServicioDeComunicacion;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event VuelosDisponiblesCompletedEventHandler VuelosDisponiblesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://localhost/servicioCom/VuelosDisponibles", RequestNamespace="http://localhost/servicioCom", ResponseNamespace="http://localhost/servicioCom", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable VuelosDisponibles(string procedencia, string destino, System.DateTime fecha) {
            object[] results = this.Invoke("VuelosDisponibles", new object[] {
                        procedencia,
                        destino,
                        fecha});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void VuelosDisponiblesAsync(string procedencia, string destino, System.DateTime fecha) {
            this.VuelosDisponiblesAsync(procedencia, destino, fecha, null);
        }
        
        /// <remarks/>
        public void VuelosDisponiblesAsync(string procedencia, string destino, System.DateTime fecha, object userState) {
            if ((this.VuelosDisponiblesOperationCompleted == null)) {
                this.VuelosDisponiblesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnVuelosDisponiblesOperationCompleted);
            }
            this.InvokeAsync("VuelosDisponibles", new object[] {
                        procedencia,
                        destino,
                        fecha}, this.VuelosDisponiblesOperationCompleted, userState);
        }
        
        private void OnVuelosDisponiblesOperationCompleted(object arg) {
            if ((this.VuelosDisponiblesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.VuelosDisponiblesCompleted(this, new VuelosDisponiblesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void VuelosDisponiblesCompletedEventHandler(object sender, VuelosDisponiblesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VuelosDisponiblesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal VuelosDisponiblesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591