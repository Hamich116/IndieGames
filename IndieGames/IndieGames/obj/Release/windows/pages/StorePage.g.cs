﻿#pragma checksum "..\..\..\..\windows\pages\StorePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1FAEC4D2DFE0209137ED10E56576DA07CC00445787F6F40AAAB0BAFB0A0898D0"
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
    /// StorePage
    /// </summary>
    public partial class StorePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 10 "..\..\..\..\windows\pages\StorePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal IndieGames.StorePage Store;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\windows\pages\StorePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image SearchPicture;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\windows\pages\StorePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox search;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\windows\pages\StorePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListGames;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\windows\pages\StorePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CostButton;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\windows\pages\StorePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock cost;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\windows\pages\StorePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border costContent;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\..\windows\pages\StorePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button categoriesButton;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\..\windows\pages\StorePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock categories;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\..\windows\pages\StorePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border categoriesContent;
        
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
            System.Uri resourceLocater = new System.Uri("/IndieGames;component/windows/pages/storepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\windows\pages\StorePage.xaml"
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
            this.Store = ((IndieGames.StorePage)(target));
            
            #line 11 "..\..\..\..\windows\pages\StorePage.xaml"
            this.Store.Loaded += new System.Windows.RoutedEventHandler(this.Store_Loaded);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SearchPicture = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.search = ((System.Windows.Controls.TextBox)(target));
            
            #line 88 "..\..\..\..\windows\pages\StorePage.xaml"
            this.search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchGame);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ListGames = ((System.Windows.Controls.ListView)(target));
            
            #line 98 "..\..\..\..\windows\pages\StorePage.xaml"
            this.ListGames.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.EnterToGamePage);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CostButton = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\..\windows\pages\StorePage.xaml"
            this.CostButton.Click += new System.Windows.RoutedEventHandler(this.CostButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cost = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.costContent = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            
            #line 146 "..\..\..\..\windows\pages\StorePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.chooseCost);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 151 "..\..\..\..\windows\pages\StorePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.chooseCost);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 156 "..\..\..\..\windows\pages\StorePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.chooseCost);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 161 "..\..\..\..\windows\pages\StorePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.chooseCost);
            
            #line default
            #line hidden
            return;
            case 14:
            this.categoriesButton = ((System.Windows.Controls.Button)(target));
            
            #line 170 "..\..\..\..\windows\pages\StorePage.xaml"
            this.categoriesButton.Click += new System.Windows.RoutedEventHandler(this.categoriesButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.categories = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 16:
            this.categoriesContent = ((System.Windows.Controls.Border)(target));
            return;
            case 17:
            
            #line 209 "..\..\..\..\windows\pages\StorePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.chooseCategories);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 214 "..\..\..\..\windows\pages\StorePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.chooseCategories);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 219 "..\..\..\..\windows\pages\StorePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.chooseCategories);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 224 "..\..\..\..\windows\pages\StorePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.chooseCategories);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 229 "..\..\..\..\windows\pages\StorePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.chooseCategories);
            
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
            switch (connectionId)
            {
            case 2:
            
            #line 29 "..\..\..\..\windows\pages\StorePage.xaml"
            ((System.Windows.Controls.Grid)(target)).PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Grid_PreviewMouseMove);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 37 "..\..\..\..\windows\pages\StorePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BuyGame);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

