﻿#pragma checksum "..\..\..\..\Views\GameWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62F2836CDC9B88000F16D3E7447A7A78CB517EEB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseProject.Views;
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


namespace CourseProject.Views {
    
    
    /// <summary>
    /// GameWindow
    /// </summary>
    public partial class GameWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 63 "..\..\..\..\Views\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridBoard;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\Views\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel Letters;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\Views\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Message;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\Views\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Word;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\Views\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox EasyCheckBox;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\..\Views\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox MidCheckBox;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\..\Views\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox HardCheckBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CourseProject;component/views/gamewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\GameWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.gridBoard = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Letters = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 3:
            this.Message = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Word = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 139 "..\..\..\..\Views\GameWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CheckWord);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 145 "..\..\..\..\Views\GameWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShuffleLetters);
            
            #line default
            #line hidden
            return;
            case 7:
            this.EasyCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 157 "..\..\..\..\Views\GameWindow.xaml"
            this.EasyCheckBox.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MidCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 160 "..\..\..\..\Views\GameWindow.xaml"
            this.MidCheckBox.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.HardCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 163 "..\..\..\..\Views\GameWindow.xaml"
            this.HardCheckBox.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 176 "..\..\..\..\Views\GameWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GenerateButton);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 246 "..\..\..\..\Views\GameWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Hint);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 251 "..\..\..\..\Views\GameWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowWords);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
