﻿#pragma checksum "..\..\..\..\..\..\MVVM\View\Recommendations\GetPlaylistLink.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1603DACF18591A34415FBEC572774D05D6BFBA3C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GetPlaylistInfo.MVVM.View.Recommendations;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace GetPlaylistInfo.MVVM.View.Recommendations {
    
    
    /// <summary>
    /// GetPlaylistLink
    /// </summary>
    public partial class GetPlaylistLink : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\..\..\MVVM\View\Recommendations\GetPlaylistLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPlaylistLink;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\..\MVVM\View\Recommendations\GetPlaylistLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnUrlHelp;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\..\MVVM\View\Recommendations\GetPlaylistLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGetRecos;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\..\MVVM\View\Recommendations\GetPlaylistLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PlaylistHelp;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\..\MVVM\View\Recommendations\GetPlaylistLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Hide;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GetPlaylistInfo;component/mvvm/view/recommendations/getplaylistlink.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\MVVM\View\Recommendations\GetPlaylistLink.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtPlaylistLink = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BtnUrlHelp = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\..\..\MVVM\View\Recommendations\GetPlaylistLink.xaml"
            this.BtnUrlHelp.Click += new System.Windows.RoutedEventHandler(this.BtnUrlHelp_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnGetRecos = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\..\..\MVVM\View\Recommendations\GetPlaylistLink.xaml"
            this.BtnGetRecos.Click += new System.Windows.RoutedEventHandler(this.BtnGetRecos_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PlaylistHelp = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.Hide = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\..\..\MVVM\View\Recommendations\GetPlaylistLink.xaml"
            this.Hide.Click += new System.Windows.RoutedEventHandler(this.Hide_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
