﻿#pragma checksum "..\..\Registration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D3237491D39ED955EEB51349832CF15F67643D3398141CD741EC8772E3C3A6D6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Paintball_club;
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


namespace Paintball_club {
    
    
    /// <summary>
    /// Registration
    /// </summary>
    public partial class Registration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit_btn;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstName_TextBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastName_TextBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Gender_ComboBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DataBorn_DatePicker;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email_TextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox Password_PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordRepeat_PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Captcha_CheckBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Registration_btn;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Back_auth;
        
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
            System.Uri resourceLocater = new System.Uri("/Paintball_club;component/registration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Registration.xaml"
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
            this.Exit_btn = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Registration.xaml"
            this.Exit_btn.Click += new System.Windows.RoutedEventHandler(this.Exit_btn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FirstName_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.LastName_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Gender_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.DataBorn_DatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.Email_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Password_PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.PasswordRepeat_PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.Captcha_CheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            this.Registration_btn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\Registration.xaml"
            this.Registration_btn.Click += new System.Windows.RoutedEventHandler(this.Registration_btn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Back_auth = ((System.Windows.Controls.TextBlock)(target));
            
            #line 46 "..\..\Registration.xaml"
            this.Back_auth.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Back_auth_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

