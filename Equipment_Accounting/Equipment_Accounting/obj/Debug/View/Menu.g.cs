﻿#pragma checksum "..\..\..\View\Menu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "39FBB9D0AD58312EC130B851BB59901BC865A17777037F4DBD86E7B9FD33930B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Equipment_Accounting.View;
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


namespace Equipment_Accounting.View {
    
    
    /// <summary>
    /// Menu
    /// </summary>
    public partial class Menu : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 17 "..\..\..\View\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem warehouse;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\View\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem clients;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem tree;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\View\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem users;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\View\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label loginName;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\View\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exit;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\View\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid contractsDG;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\View\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addContract;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\View\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editContract;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\View\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delContract;
        
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
            System.Uri resourceLocater = new System.Uri("/Equipment_Accounting;component/view/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Menu.xaml"
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
            this.warehouse = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\..\View\Menu.xaml"
            this.warehouse.Click += new System.Windows.RoutedEventHandler(this.warehouse_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.clients = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\..\View\Menu.xaml"
            this.clients.Click += new System.Windows.RoutedEventHandler(this.clients_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tree = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\View\Menu.xaml"
            this.tree.Click += new System.Windows.RoutedEventHandler(this.tree_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.users = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\View\Menu.xaml"
            this.users.Click += new System.Windows.RoutedEventHandler(this.users_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.loginName = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.exit = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\View\Menu.xaml"
            this.exit.Click += new System.Windows.RoutedEventHandler(this.exit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.contractsDG = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.addContract = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\View\Menu.xaml"
            this.addContract.Click += new System.Windows.RoutedEventHandler(this.addContract_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.editContract = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\View\Menu.xaml"
            this.editContract.Click += new System.Windows.RoutedEventHandler(this.editContract_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.delContract = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\View\Menu.xaml"
            this.delContract.Click += new System.Windows.RoutedEventHandler(this.delContract_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 8:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 29 "..\..\..\View\Menu.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.contractsDG_MouseDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

