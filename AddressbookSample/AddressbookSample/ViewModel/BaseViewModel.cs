namespace AddressbookSample.ViewModel
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The base view model.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The change and notify.
        /// </summary>
        /// <param name="property"> The property. </param>
        /// <param name="value"> The value. </param>
        /// <param name="propertyName"> The property name. </param>
        /// <typeparam name="T"> Type of T </typeparam>
        /// <returns> The <see cref="bool"/>. </returns>
        protected bool ChangeAndNotify<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(property, value))
            {
                property = value;
                this.NotifyPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// The notify property changed.
        /// </summary>
        /// <param name="propertyName">  The property name. </param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
