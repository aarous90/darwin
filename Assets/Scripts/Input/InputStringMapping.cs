using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class InputStringMapping
{
    public static class AirInputMapping
    {

    }

    public static class GroundInputMapping
    {

    }

    public static class WaterInputMapping
    {

    }

    public static class GUIInputMapping
    {
        public static string NavigateHorizontal = "Horizontal";
        public static string NavigateVertical = "Vertical";

        public static string Select = "Select";
        public static string Cancel = "Cancel";
        public static string Back = "Back";
        public static string Pause = "Pause";

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
