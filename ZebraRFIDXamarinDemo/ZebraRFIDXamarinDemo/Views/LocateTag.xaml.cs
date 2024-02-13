﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZebraRFIDXamarinDemo.ViewModels;

namespace ZebraRFIDXamarinDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocateTag : ContentPage
	{
		private LocateViewModel viewmodel;

		public LocateTag()
		{
			InitializeComponent();
			Title = "Item search";
			BindingContext = viewmodel = new LocateViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewmodel.UpdateIn();
		}
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			viewmodel.UpdateOut();
		}

	}
}