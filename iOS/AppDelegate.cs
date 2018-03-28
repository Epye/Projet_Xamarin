using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace ProjetIncident.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_sqlite3());

            LoadApplication(new Core.App());

            return base.FinishedLaunching(app, options);
        }
    }
}
