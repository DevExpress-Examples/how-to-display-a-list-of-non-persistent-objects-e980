using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace UnboundListView.Module {
    [NonPersistent]
    public class Duplicate : XPObject {
        private static int myOid = 0;

        public Duplicate(Session session)
            : base(session) {
            myOid++;
            Oid = myOid;
        }
        public string Title {
            get { return GetPropertyValue<string>("Title"); }
            set { SetPropertyValue<string>("Title", value); }
        }
        public int Count {
            get { return GetPropertyValue<int>("Count"); }
            set { SetPropertyValue<int>("Count", value); }
        }
    }
}
