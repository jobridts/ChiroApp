using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telephony;


namespace ChiroAppDev

{

	[BroadcastReceiver()]
	[IntentFilter(new[] {"android.intent.action.PHONE_STATE"})]
	public class IncomingCallReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			//make sure there is info
			if (intent.Extras != null) {
				// get the call state
				string state = intent.GetStringExtra (TelephonyManager.ExtraState);
				if (state == TelephonyManager.ExtraStateRinging) {
					Console.WriteLine ("RINGING");
					//Toast.MakeText (context, "RINGING", ToastLength.Long);
				} else if (state == TelephonyManager.ExtraStateOffhook) {
					Console.WriteLine ("OFF HOOK");
					Toast.MakeText (context, "OFFHOOK", ToastLength.Long);

				} else if (state == TelephonyManager.ExtraStateIdle) {
					Console.WriteLine ("IDLE");
					//context.StartActivity (new Intent(context, typeof(Tabactivity)));
					call (context);
				}
			}
		}
		public void call(Context context)
		{

			Globals.CALLED = true;
			var intent = new Intent (context, typeof (AfterCallActivity));
			intent.AddFlags (ActivityFlags.NewTask);
			context.StartActivity (intent);



		}
	
	}

}



