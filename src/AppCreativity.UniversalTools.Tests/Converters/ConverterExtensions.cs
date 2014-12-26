// ****************************************************************************
// <copyright company="AppCreativity"
//            file="ConverterExtensions.cs">
// Copyright © AppCreativity 2014
// </copyright>
// ****************************************************************************
// <project>AppCreativity.UniversalTools.Tests</project>
// <url>https://github.com/AppCreativity/UniversalTools</url>
// <license>
// See LICENSE in this solution or at 
// https://github.com/AppCreativity/UniversalTools/blob/master/LICENSE
// </license>
// ****************************************************************************

using Windows.UI.Xaml;
using AppCreativity.UniversalTools.Converters;

namespace AppCreativity.UniversalTools.Tests.Converters
{
    /// <summary>
    /// Extension methods for IValueConverter converters to ease testability.
    /// </summary>
    public static class ConverterExtensions
    {
        /// <summary>
        /// <see cref="VisibilityConverter"/> Convert method.
        /// </summary>
        /// <param name="converter">VisibilityConverter instance</param>
        /// <param name="value">value to convert</param>
        /// <returns>Visibility.Visible or Visibility.Collapsed</returns>
        public static Visibility Convert(this VisibilityConverter converter, object value)
        {
            return (Visibility)converter.Convert(value, typeof (Visibility), null, string.Empty);
        }
    }
}
