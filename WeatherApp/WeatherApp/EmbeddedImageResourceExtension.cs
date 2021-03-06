﻿using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace WeatherApp
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            // Do your translation lookup here, using whatever method you require
            ImageSource imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }
}
