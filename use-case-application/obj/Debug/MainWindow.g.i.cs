﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5FD0F1AE4A73F953D3428D40FB0E93BC82C245D7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using UseCaseApplication;


namespace UseCaseApplication {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonBrush;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonRectangle;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCircle;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonLine;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.canvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 10 "..\..\MainWindow.xaml"
            this.canvas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 10 "..\..\MainWindow.xaml"
            this.canvas.MouseMove += new System.Windows.Input.MouseEventHandler(this.Canvas_MouseMove);
            
            #line default
            #line hidden
            
            #line 10 "..\..\MainWindow.xaml"
            this.canvas.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.canvas_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonBrush = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\MainWindow.xaml"
            this.buttonBrush.Click += new System.Windows.RoutedEventHandler(this.buttonBrush_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonRectangle = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\MainWindow.xaml"
            this.buttonRectangle.Click += new System.Windows.RoutedEventHandler(this.buttonRectangle_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonCircle = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\MainWindow.xaml"
            this.buttonCircle.Click += new System.Windows.RoutedEventHandler(this.buttonCircle_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonLine = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\MainWindow.xaml"
            this.buttonLine.Click += new System.Windows.RoutedEventHandler(this.buttonLine_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

