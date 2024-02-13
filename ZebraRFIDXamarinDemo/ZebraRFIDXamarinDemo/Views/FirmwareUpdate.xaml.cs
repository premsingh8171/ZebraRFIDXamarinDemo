﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZebraRFIDXamarinDemo.ViewModels;

namespace ZebraRFIDXamarinDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirmwareUpdate : ContentPage
    {
        private FirmwareUpdateViewModel viewmodel;
        public FirmwareUpdate()
        {
            InitializeComponent();
            BindingContext = viewmodel = new FirmwareUpdateViewModel();
            Title = "Firmware Update";
        }

        private void ButtonFirmwareClicked(object sender, EventArgs e)
        {
            viewmodel.SelectUpdateFirmware();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewmodel.UpdateScannerIn();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewmodel.UpdateScannerOut();
        }
    }
}