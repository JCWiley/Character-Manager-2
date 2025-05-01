using CM4_UI.ViewModels;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI_UnitTest.Utilities
{
    public class PropertyChangedObserver
    {
        private bool propertyChanged;

        public PropertyChangedObserver()
        {
            propertyChanged = false;
        }
        public void AttachProperty(ViewModelBase target, string propName)
        {
            propertyChanged = false;
            target.PropertyChanged += delegate (object? sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == propName)
                {
                    propertyChanged = true;
                }
            };
        }

        public void Reset()
        {
            propertyChanged = false;
        }

        public bool Fired()
        {
            return propertyChanged;
        }
    }
}
