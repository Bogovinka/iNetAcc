﻿#pragma checksum "..\..\..\View\EditConection.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F8295AF8AA927AF6FE81A4A91590FC918AF14FCC215536563E624B25307067FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Equipment_Accounting;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Equipment_Accounting {
    
    
    /// <summary>
    /// EditConection
    /// </summary>
    public partial class EditConection : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\View\EditConection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serverT;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\View\EditConection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox dbT;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\View\EditConection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginT;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\View\EditConection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordT;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\View\EditConection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label name_note;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\View\EditConection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\EditConection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button localB;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\View\EditConection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createB;
        
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
            System.Uri resourceLocater = new System.Uri("/Equipment_Accounting;component/view/editconection.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\EditConection.xaml"
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
            this.serverT = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.dbT = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.loginT = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.passwordT = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.name_note = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\View\EditConection.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.back_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.localB = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\View\EditConection.xaml"
            this.localB.Click += new System.Windows.RoutedEventHandler(this.localB_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.createB = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\View\EditConection.xaml"
            this.createB.Click += new System.Windows.RoutedEventHandler(this.createB_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

