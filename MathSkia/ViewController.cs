using System;
using System.Threading;
using System.Threading.Tasks;
using AppKit;
using Foundation;
using MathSkia.Classes;

namespace MathSkia
{
    public partial class ViewController : NSViewController
    {
        private float _time = 0f;
        private ProjectilePhysics _physics;
        
        public ViewController(IntPtr handle) : base(handle)
        {
        }
        
        private void setImageFromView()
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _physics = new ProjectilePhysics(100f,1,30);
            this.RefreshView();
        }
        
        private async Task RefreshView()
        {
            await Task.Delay(1);
            _time += 0.016f;
            if (this.ImageView != null)
            {
                var handler = new DrawHandler();
                try
                {
                    this.ImageView.Image = handler.GenerateImage(_physics.Position(_time));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            await RefreshView();
        }
        
        public override NSObject RepresentedObject
        {
            get { return base.RepresentedObject; }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}