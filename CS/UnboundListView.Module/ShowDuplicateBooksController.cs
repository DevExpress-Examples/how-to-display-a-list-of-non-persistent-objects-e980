using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace UnboundListView.Module {
    public partial class ShowDuplicateBooksController : ViewController {
        public ShowDuplicateBooksController() {
            PopupWindowShowAction showDuplicatesAction = new PopupWindowShowAction(this, "Show Duplicate Books", "View");
            showDuplicatesAction.CustomizePopupWindowParams += new CustomizePopupWindowParamsEventHandler(showDuplicatesAction_CustomizePopupWindowParams);
            TargetViewType = ViewType.ListView;
            TargetObjectType = typeof(Book);
        }

        void showDuplicatesAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e) {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach(Book book in ((ListView)View).CollectionSource.List) {
                if(!string.IsNullOrEmpty(book.Title)) {
                    if(dictionary.ContainsKey(book.Title)) {
                        dictionary[book.Title]++;
                    }
                    else dictionary.Add(book.Title, 1);
                }
            }
            ObjectSpace objectSpace = Application.CreateObjectSpace();
            CollectionSource collectionSource = new CollectionSource(objectSpace, typeof(Duplicate));
            if((collectionSource.Collection as XPBaseCollection) != null) {
                ((XPBaseCollection)collectionSource.Collection).LoadingEnabled = false;
            }
            foreach(KeyValuePair<string, int> duplicateRecord in dictionary) {
                if(duplicateRecord.Value > 1) {
                    Duplicate duplicate = new Duplicate(objectSpace.Session);
                    duplicate.Title = duplicateRecord.Key;
                    duplicate.Count = duplicateRecord.Value;
                    collectionSource.List.Add(duplicate);
                }
            }
            ListView view = Application.CreateListView(Application.GetListViewId(typeof(Duplicate)), collectionSource, false);
            view.Editor.AllowEdit = false;
            e.View = view;
            e.DialogController.SaveOnAccept = false;
        }
    }
}
