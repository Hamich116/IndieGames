﻿#pragma checksum "..\..\..\..\windows\pages\GamePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "81754C5A69D214B8A9F82DA872D4A6D20C237433FE5F9AC9AB22DCBC751E6BFD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using IndieGames;
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


namespace IndieGames {
    
    
    /// <summary>
    /// GamePage
    /// </summary>
    public partial class GamePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\windows\pages\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ControlContainer;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\windows\pages\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock pause;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\windows\pages\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label back;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\windows\pages\GamePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buyButton;
        
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
            System.Uri resourceLocater = new System.Uri("/IndieGames;component/windows/pages/gamepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\windows\pages\GamePage.xaml"
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
            
            #line 11 "..\..\..\..\windows\pages\GamePage.xaml"
            ((IndieGames.GamePage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\windows\pages\GamePage.xaml"
            ((IndieGames.GamePage)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Page_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ControlContainer = ((System.Windows.Controls.ContentControl)(target));
            
            #line 41 "..\..\..\..\windows\pages\GamePage.xaml"
            this.ControlContainer.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Pause_MouseClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 44 "..\..\..\..\windows\pages\GamePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnStopButtonClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pause = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 47 "..\..\..\..\windows\pages\GamePage.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ResetVideo);
            
            #line default
            #line hidden
            return;
            case 6:
            this.back = ((System.Windows.Controls.Label)(target));
            
            #line 61 "..\..\..\..\windows\pages\GamePage.xaml"
            this.back.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Back_MouseEnter);
            
            #line default
            #line hidden
            
            #line 62 "..\..\..\..\windows\pages\GamePage.xaml"
            this.back.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Back_MouseLeave);
            
            #line default
            #line hidden
            
            #line 63 "..\..\..\..\windows\pages\GamePage.xaml"
            this.back.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Back_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buyButton = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\..\windows\pages\GamePage.xaml"
            this.buyButton.Click += new System.Windows.RoutedEventHandler(this.Buy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
