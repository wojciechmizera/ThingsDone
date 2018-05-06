﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ThingsDone
{
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        public static Parent Instance { get; private set; } = new Parent();

        public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.Register("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), 
                new PropertyMetadata( new PropertyChangedCallback(OnValuePropertyChanged)));

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(d, e);

            Instance.ValueChanged(d, e);
        }

        public virtual void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { }



        
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value); 
    }
}