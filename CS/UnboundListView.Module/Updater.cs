using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace UnboundListView.Module {
    public class Updater : ModuleUpdater {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();

            Book bookOne = new Book(Session);
            bookOne.Title = "A Visitor For Bear";
            bookOne.Save();

            Book bookTwo = new Book(Session);
            bookTwo.Title = "Dirt on My Shirt";
            bookTwo.Save();

            Book bookThree = new Book(Session);
            bookThree.Title = "Bats at the Library";
            bookThree.Save();

            Book bookFour = new Book(Session);
            bookFour.Title = "Fancy Nancy at the Museum";
            bookFour.Save();

            Book bookFive = new Book(Session);
            bookFive.Title = "Fancy Nancy at the Museum";
            bookFive.Save();

            Book bookSix = new Book(Session);
            bookSix.Title = "Bats at the Library";
            bookSix.Save();

            Book bookSeven = new Book(Session);
            bookSeven.Title = "Bats at the Library";
            bookSeven.Save();            
        }
    }
}
