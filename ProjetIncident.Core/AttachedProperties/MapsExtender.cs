using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ProjetIncident.Core.AttachedProperties
{
    public static class MapsExtender
    {

        //----------------------------------------------------------------------------------------------------------------------------------------------------
        // Bindable VisibleRegion property
        //----------------------------------------------------------------------------------------------------------------------------------------------------

        public static readonly BindableProperty VisibleRegionProperty = BindableProperty.CreateAttached("VisibleRegion", 
                                                                                                        typeof(MapSpan),
                                                                                                        typeof(MapsExtender),
                                                                                                        null, BindingMode.OneWay,
                                                                                                        propertyChanged: OnVisibleRegionPropertyChanged);
        public static MapSpan GetVisibleRegion(BindableObject view)
        {
            return (MapSpan)view.GetValue(VisibleRegionProperty);
        }
        public static void SetVisibleRegion(BindableObject view, MapSpan value)
        {
            view.SetValue(VisibleRegionProperty, value);
        }

        public static void OnVisibleRegionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var map = bindable as Map;
            map?.MoveToRegion((MapSpan)newValue);
        }



        //----------------------------------------------------------------------------------------------------------------------------------------------------
        // Bindable Pins property
        //----------------------------------------------------------------------------------------------------------------------------------------------------

        public static readonly BindableProperty PinsProperty = BindableProperty.CreateAttached("Pins",
                                                                                               typeof(ObservableCollection<Pin>),
                                                                                               typeof(MapsExtender),
                                                                                               null,
                                                                                               propertyChanged: OnPinsPropertyChanged);
        public static ObservableCollection<Pin> GetPins(BindableObject view)
        {
            return (ObservableCollection<Pin>)view.GetValue(PinsProperty);
        }
        public static void SetPins(BindableObject view, ObservableCollection<Pin> value)
        {
            view.SetValue(PinsProperty, value);
        }

        private static NotifyCollectionChangedEventHandler OnPinsCollectionChangedHandler = null;
        public static void OnPinsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var map = bindable as Map;
            if (map != null)
            {
                if (OnPinsCollectionChangedHandler == null)
                    OnPinsCollectionChangedHandler = new NotifyCollectionChangedEventHandler((sender, e) =>
                    {
                        OnPinsCollectionChanged(map, e);
                    });

                if (oldValue != null)
                    ((ObservableCollection<Pin>)oldValue).CollectionChanged -= OnPinsCollectionChangedHandler;
                if (newValue != null)
                {
                    ((ObservableCollection<Pin>)newValue).CollectionChanged += OnPinsCollectionChangedHandler;
                    OnPinsCollectionChanged(map, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                    OnPinsCollectionChanged(map, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, (ObservableCollection<Pin>)newValue));
                }
            }
        }

        private static void OnPinsCollectionChanged(Map map, NotifyCollectionChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                    case NotifyCollectionChangedAction.Replace:
                    case NotifyCollectionChangedAction.Remove:
                        if (e.OldItems != null)
                            foreach (var item in e.OldItems)
                                map.Pins.Remove((Pin)item);
                        if (e.NewItems != null)
                            foreach (var item in e.NewItems)
                                map.Pins.Add((Pin)item);
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        map.Pins.Clear();
                        break;
                }
            });
        }
    }
}
