﻿#pragma checksum "..\..\..\..\Forme\frmSastojakProizvod.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B66BFE9A579C9C137DDF00DAED87859BF82E3769"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Apoteka.Forme;
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


namespace Apoteka.Forme {
    
    
    /// <summary>
    /// frmSastojakProizvod
    /// </summary>
    public partial class frmSastojakProizvod : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Forme\frmSastojakProizvod.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSastojak;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Forme\frmSastojakProizvod.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodajSastojak;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Forme\frmSastojakProizvod.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbProizvod;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Forme\frmSastojakProizvod.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodajProizvod;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Forme\frmSastojakProizvod.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Forme\frmSastojakProizvod.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Apoteka;component/forme/frmsastojakproizvod.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forme\frmSastojakProizvod.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbSastojak = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.btnDodajSastojak = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Forme\frmSastojakProizvod.xaml"
            this.btnDodajSastojak.Click += new System.Windows.RoutedEventHandler(this.btnDodajSastojak_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbProizvod = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.btnDodajProizvod = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Forme\frmSastojakProizvod.xaml"
            this.btnDodajProizvod.Click += new System.Windows.RoutedEventHandler(this.btnDodajProizvod_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Forme\frmSastojakProizvod.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\Forme\frmSastojakProizvod.xaml"
            this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.btnOtkazi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

