﻿#pragma checksum "..\..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FC64939F0C5492CB6AECDE6EED54324AADC62766"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Grafika_Komputerowa_Projekt;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Grafika_Komputerowa_Projekt {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 130 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider opacitySlider;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas paintSurface;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel layersPanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Grafika Komputerowa Projekt;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 44 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.onPenButtonPressed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 53 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onRectangleButtonPressed);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 54 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onTriangleButtonPressed);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 55 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onCircleButtonPressed);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 56 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onPolygonButtonPressed);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 65 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onAddLineButtonPressed);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 66 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onEditLineButtonPressed);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 75 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.onPathButtonPressed);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 84 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.onColorButtonPressed);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 93 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onShowImageButtonPressed);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 94 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onShowImageWithFilter1ButtonPressed);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 95 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onShowImageWithFilter2ButtonPressed);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 104 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onThickness2ButtonPressed);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 105 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onThickness4ButtonPressed);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 106 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onThickness8ButtonPressed);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 107 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onThickness16ButtonPressed);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 108 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.onThickness32ButtonPressed);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 117 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.onUndoButtonPressed);
            
            #line default
            #line hidden
            return;
            case 19:
            this.opacitySlider = ((System.Windows.Controls.Slider)(target));
            
            #line 136 "..\..\..\..\MainWindow.xaml"
            this.opacitySlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.onOpacitySliderChanged);
            
            #line default
            #line hidden
            return;
            case 20:
            this.paintSurface = ((System.Windows.Controls.Canvas)(target));
            
            #line 152 "..\..\..\..\MainWindow.xaml"
            this.paintSurface.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_MouseDown_1);
            
            #line default
            #line hidden
            
            #line 153 "..\..\..\..\MainWindow.xaml"
            this.paintSurface.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_MouseUp_1);
            
            #line default
            #line hidden
            
            #line 154 "..\..\..\..\MainWindow.xaml"
            this.paintSurface.MouseMove += new System.Windows.Input.MouseEventHandler(this.Canvas_MouseMove_1);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 181 "..\..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.onAddLayerButtonPressed);
            
            #line default
            #line hidden
            return;
            case 22:
            this.layersPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
