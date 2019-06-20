// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in the XCode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MathSkia
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField AngleBox { get; set; }

		[Outlet]
		AppKit.NSImageView ImageView { get; set; }

		[Outlet]
		AppKit.NSButton Submit { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ImageView != null) {
				ImageView.Dispose ();
				ImageView = null;
			}

			if (Submit != null) {
				Submit.Dispose ();
				Submit = null;
			}

			if (AngleBox != null) {
				AngleBox.Dispose ();
				AngleBox = null;
			}

		}
	}
}
