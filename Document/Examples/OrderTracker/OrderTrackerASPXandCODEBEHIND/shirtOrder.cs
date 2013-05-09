using System;

namespace OrderTrackerv2
{
	/// <summary>
	/// Summary description for anOrder.
	/// </summary>
	public class shirtOrder
	{
		public string manufacturer;
		public string color;
		public string num24;
		public string num68;
		public string num1012;
		public string num1416;
		public string numS;
		public string numM;
		public string numL;
		public string numXL;
		public string numXXL;
		public string numXXXL;
		public string numXXXXL;
		public string numOther;
		public string unitPrice;
		public string styleNum;
		public string description;
		public string type;				//tshirt sweatshirt polo cap
		public string sleeveorpocket;	//ss ls pocket tee

		public shirtOrder()
		{
			manufacturer = null;
			color = null;
			num24 = null;
			num68 = null;
			num1012 = null;
			num1416 = null;
			numS = null;
			numM = null;
			numL = null;
			numXL = null;
			numXXL = null;
			numXXXL = null;
			numXXXXL = null;
			numOther = null;
			unitPrice = null;
			styleNum = null;
			description = null;
			type = null;
			sleeveorpocket = null;
		}
	}
}
