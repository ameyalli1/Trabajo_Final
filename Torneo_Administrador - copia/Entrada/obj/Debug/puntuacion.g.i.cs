﻿#pragma checksum "..\..\puntuacion.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C01DD07918EC6854964C4FEE68FBFF198D7C3FA6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Entrada;
using OxyPlot.Wpf;
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


namespace Entrada {
    
    
    /// <summary>
    /// puntuacion
    /// </summary>
    public partial class puntuacion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\puntuacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVerEstadisticos;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\puntuacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker clcFechaPuntosEquipos;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\puntuacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbEstadisticosEquipos;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\puntuacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgTablaEstadisticos;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\puntuacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal OxyPlot.Wpf.PlotView Grafica;
        
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
            System.Uri resourceLocater = new System.Uri("/Entrada;component/puntuacion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\puntuacion.xaml"
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
            this.btnVerEstadisticos = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\puntuacion.xaml"
            this.btnVerEstadisticos.Click += new System.Windows.RoutedEventHandler(this.btnVerEstadisticos_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.clcFechaPuntosEquipos = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.cmbEstadisticosEquipos = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.dtgTablaEstadisticos = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.Grafica = ((OxyPlot.Wpf.PlotView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
