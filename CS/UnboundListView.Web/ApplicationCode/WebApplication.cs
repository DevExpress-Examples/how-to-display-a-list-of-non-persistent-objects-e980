﻿// Developer Express Code Central Example:
// How to: Invoke a List View for a Non-Persistent Class
// 
// This example demonstrates how to display a List View for non-persistent data.
// The complete description is available in the How to: Invoke a List View for a
// Non-Persistent Class (ms-help://DevExpress.Xaf/CustomDocument3167.htm) help
// topic.
// 
// See
// Also:
// http://www.devexpress.com/scid=E921
// http://www.devexpress.com/scid=K18117
// http://www.devexpress.com/scid=K18083
// http://www.devexpress.com/scid=E911
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E980

using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Web;

namespace UnboundListView.Web {
    public partial class UnboundListViewAspNetApplication : WebApplication {
        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
        private UnboundListView.Module.UnboundListViewModule module3;        
        private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
        private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule module6;
        private DevExpress.ExpressApp.Validation.ValidationModule module5;

        public UnboundListViewAspNetApplication() {
            InitializeComponent();
        }

        private void UnboundListViewAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }

        private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
            this.module3 = new UnboundListView.Module.UnboundListViewModule();            
            this.module5 = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.module6 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // module5
            // 
            this.module5.AllowValidationDetailsAccess = true;
            // 
            // UnboundListViewAspNetApplication
            // 
            this.ApplicationName = "UnboundListView";
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.module6);
            this.Modules.Add(this.module3);            
            this.Modules.Add(this.module5);
            this.Modules.Add(this.securityModule1);
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.UnboundListViewAspNetApplication_DatabaseVersionMismatch);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
