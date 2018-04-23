using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp;

namespace UnboundListView.Win {
    public partial class UnboundListViewWindowsFormsApplication : WinApplication {
        public UnboundListViewWindowsFormsApplication() {
            InitializeComponent();
        }

        private void UnboundListViewWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
        }
    }
}
