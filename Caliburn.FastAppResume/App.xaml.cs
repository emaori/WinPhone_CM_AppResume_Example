﻿using System;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Caliburn.FastAppResume.Resources;

namespace Caliburn.FastAppResume
{
    public partial class App : Application
    {
        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Standard XAML initialization
            InitializeComponent();
        }
    }
}