using System;
using Xamarin.Forms;

namespace CollegePortalApplication.Controls
{
    public class VideoPlayer : View
    {
        public static readonly BindableProperty SourceProperty =
                BindableProperty.Create(nameof(Source), typeof(string), typeof(VideoPlayer), null);

        public string Source
        {
            set { SetValue(SourceProperty, value); }
            get { return (string)GetValue(SourceProperty); }
        }
    }
}
