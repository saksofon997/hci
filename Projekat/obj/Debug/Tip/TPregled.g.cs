﻿#pragma checksum "..\..\..\Tip\TPregled.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FB7CC1577F68F079F8B84C6982FB7EE1E70DA99D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekat.Tip;
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


namespace Projekat.Tip {
    
    
    /// <summary>
    /// TPregled
    /// </summary>
    public partial class TPregled : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Tip\TPregled.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PregledG;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Tip\TPregled.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Izmeni;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Tip\TPregled.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Obrisi;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Tip\TPregled.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Dodaj;
        
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
            System.Uri resourceLocater = new System.Uri("/Projekat;component/tip/tpregled.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Tip\TPregled.xaml"
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
            
            #line 9 "..\..\..\Tip\TPregled.xaml"
            ((Projekat.Tip.TPregled)(target)).FocusableChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Window_FocusableChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 12 "..\..\..\Tip\TPregled.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PregledG = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.Izmeni = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Tip\TPregled.xaml"
            this.Izmeni.Click += new System.Windows.RoutedEventHandler(this.Izmeni_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Obrisi = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Tip\TPregled.xaml"
            this.Obrisi.Click += new System.Windows.RoutedEventHandler(this.Obrisi_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Dodaj = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\Tip\TPregled.xaml"
            this.Dodaj.Click += new System.Windows.RoutedEventHandler(this.Dodaj_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

