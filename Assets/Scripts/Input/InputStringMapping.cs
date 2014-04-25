using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class InputStringMapping
{
	public static class GUIInputMapping
    {
		public static string NavigateHorizontal = "L_XAxis_0";
		public static string NavigateVertical = "L_YAxis_0";

        public static string Select = "A_0";
        public static string Cancel = "B_0";
        public static string Back = "Back_0";
        public static string Pause = "Start_0";

        public static List<string> GetButtons()
        {
            List<string> mappingStrings = new List<string>();

            mappingStrings.Add(Select);
            mappingStrings.Add(Cancel);
            mappingStrings.Add(Back);
            mappingStrings.Add(Pause);

            return mappingStrings;
        }


		public static List<string> GetMovements()
		{
			List<string> mappingStrings = new List<string>();
			return mappingStrings;
		}


		public static List<string> GetAxis()
		{
			List<string> mappingStrings = new List<string>();

			mappingStrings.Add(NavigateHorizontal);
			mappingStrings.Add(NavigateVertical);

			return mappingStrings;
		}
    }
}
