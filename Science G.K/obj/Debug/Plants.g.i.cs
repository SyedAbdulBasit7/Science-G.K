﻿#pragma checksum "..\..\Plants.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C7D23F7759B50C15F03746C05F757E6742AEDD8F494FEE4682F4587F08AAA356"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Science_G.K;
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


namespace Science_G.K {
    
    
    /// <summary>
    /// Plants
    /// </summary>
    public partial class Plants : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\Plants.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem plantTable;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Plants.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PlantList;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Plants.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image plantImage;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\Plants.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock conversationStatus;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\Plants.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Kingdom;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\Plants.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Classification;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\Plants.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Order;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\Plants.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Family;
        
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
            System.Uri resourceLocater = new System.Uri("/Science G.K;component/plants.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Plants.xaml"
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
            this.plantTable = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\Plants.xaml"
            this.plantTable.Click += new System.Windows.RoutedEventHandler(this.plantTable_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PlantList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\Plants.xaml"
            this.PlantList.IsMouseCapturedChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.PlantList_IsMouseCapturedChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.plantImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.conversationStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Kingdom = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Classification = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Order = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.Family = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
