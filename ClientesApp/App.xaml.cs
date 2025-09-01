#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android; 
#endif

#if IOS || MACCATALYST
using UIKit;
#endif
using ClientesApp.Handlers;


namespace ClientesApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            #region Handlers

            //Borderless entry
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
#elif __IOS__ || __MACCATALYST__
                    handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                    handler.PlatformView.Layer.BorderWidth = 0;
                    handler.PlatformView.Layer.BorderColor = UIColor.White.CGColor;
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif __WINDOWS__
                handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
                handler.PlatformView.BorderThickness = new Windows.UI.Xaml.Thickness(0);
                handler.PlatformView.UnderlineThickness = new Windows.UI.Xaml.Thickness(0);
#endif
                }
            });
            #endregion

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}