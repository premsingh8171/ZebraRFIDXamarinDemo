﻿using System;
using System.Collections.Generic;
using System.Text;
using Com.Zebra.Rfid.Api3;
using Xamarin.Forms;
using ZebraRFIDXamarinDemo.Models;

namespace ZebraRFIDXamarinDemo.ViewModels
{
	public class LocateViewModel : BaseViewModel
	{
		private string _TagPattern;
		private string _RelativeDistance;
		private Rectangle _distanceBox;

		public LocateViewModel()
		{
			RelativeDistance = "0";
			TagPattern = InventoryListModel.SelectedItem?.ToString() ?? "";
		}

		public override void HHTriggerEvent(bool pressed)
		{
			// TagMask is optional
			//string TagMask = "00000000FFFFFFFF";
			//rfidModel.Locate(pressed, TagPattern, TagMask);
			if(TagPattern != null && TagPattern != "")
				rfidModel.Locate(pressed, TagPattern, null);
		}

		public override void TagReadEvent(TagData[] tags)
		{
			if (tags != null)
			{
				for (int index = 0; index < tags.Length; index++)
				{
					if (tags[index].LocationInfo != null)
					{
						RelativeDistance = tags[index].LocationInfo.RelativeDistance.ToString();
						UpdateFillView(tags[index].LocationInfo.RelativeDistance);
					}
				}
			}
		}

		private void UpdateFillView(short relativeDistance)
		{
			DistanceBox = new Rectangle(0, .05, 50, relativeDistance * 3);
		}

		public string TagPattern
		{
			get { return _TagPattern; }
			set { _TagPattern = value; OnPropertyChanged(); }
		}

		public string RelativeDistance
		{
			get { return _RelativeDistance; }
			set { _RelativeDistance = value; OnPropertyChanged(); }
		}

		public Rectangle DistanceBox
		{
			get { return _distanceBox; }
			set { _distanceBox = value; OnPropertyChanged(); }
		}


	}
}
