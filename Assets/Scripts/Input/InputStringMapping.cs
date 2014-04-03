using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class InputStringMapping
{
////////////////////AIR////////////////////////////////////
    
	public static class AirInputMapping
    {
		//Player 1
		public static string P1_NavigateHorizontal = "L_XAxis_1";
		public static string P1_NavigateVertical = "L_YAxis_1";
		public static string P1_L_Step = "L_Trigger_1";
		public static string P1_R_Step = "R_Trigger_1";
		
		public static string P1_RangedSkill = "X_1";
		public static string P1_MeleeSkill = "A_1";
		public static string P1_SpecialSkill = "B_1";
		
		public static string Pause = "Start_1";
		
		//Player 2
		public static string P2_NavigateHorizontal = "L_XAxis_2";
		public static string P2_NavigateVertical = "L_YAxis_2";
		public static string P2_L_Step = "L_Trigger_2";
		public static string P2_R_Step = "R_Trigger_2";
		
		public static string P2_RangedSkill = "X_2";
		public static string P2_MeleeSkill = "A_2";
		public static string P2_SpecialSkill = "B_2";

		public static List<string> GetButtons()
		{
			List<string> mappingStrings = new List<string>();
		
			//Player 1
			mappingStrings.Add(P1_RangedSkill);
			mappingStrings.Add(P1_MeleeSkill);
			mappingStrings.Add(P1_SpecialSkill);
			mappingStrings.Add(Pause);
			
			//Player 2
			mappingStrings.Add(P2_RangedSkill);
			mappingStrings.Add(P2_MeleeSkill);
			mappingStrings.Add(P2_SpecialSkill);
		
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

			//Player 1
			mappingStrings.Add(P1_NavigateHorizontal);
			mappingStrings.Add(P1_NavigateVertical);
			mappingStrings.Add(P1_L_Step);
			mappingStrings.Add(P1_R_Step);
			
			//Player 2
			mappingStrings.Add(P2_NavigateHorizontal);
			mappingStrings.Add(P2_NavigateVertical);
			mappingStrings.Add(P2_L_Step);
			mappingStrings.Add(P2_R_Step);

			return mappingStrings;
		}
    }
/////////////////////GROUND///////////////////////////////////
    
	public static class GroundInputMapping
    {
		//Player 1
		public static string P1_NavigateHorizontal = "L_XAxis_1";
		public static string P1_NavigateVertical = "L_YAxis_1";
		public static string P1_L_Step = "L_Trigger_1";
		public static string P1_R_Step = "R_Trigger_1";

		public static string P1_RangedSkill = "X_1";
		public static string P1_MeleeSkill = "A_1";
		public static string P1_SpecialSkill = "B_1";

		public static string Pause = "Start_1";

		//Player 2
		public static string P2_NavigateHorizontal = "L_XAxis_2";
		public static string P2_NavigateVertical = "L_YAxis_2";
		public static string P2_L_Step = "L_Trigger_2";
		public static string P2_R_Step = "R_Trigger_2";
		
		public static string P2_RangedSkill = "X_2";
		public static string P2_MeleeSkill = "A_2";
		public static string P2_SpecialSkill = "B_2";


		public static List<string> GetButtons()
		{
			List<string> mappingStrings = new List<string>();
		
			//Player 1
			mappingStrings.Add(P1_RangedSkill);
			mappingStrings.Add(P1_MeleeSkill);
			mappingStrings.Add(P1_SpecialSkill);
			mappingStrings.Add(Pause);

			//Player 2
			mappingStrings.Add(P2_RangedSkill);
			mappingStrings.Add(P2_MeleeSkill);
			mappingStrings.Add(P2_SpecialSkill);

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

			//Player 1
			mappingStrings.Add(P1_NavigateHorizontal);
			mappingStrings.Add(P1_NavigateVertical);
			mappingStrings.Add(P1_L_Step);
			mappingStrings.Add(P1_R_Step);

			//Player 2
			mappingStrings.Add(P2_NavigateHorizontal);
			mappingStrings.Add(P2_NavigateVertical);
			mappingStrings.Add(P2_L_Step);
			mappingStrings.Add(P2_R_Step);

			return mappingStrings;
		}

    }
/////////////////////WATER///////////////////////////////////
    
	public static class WaterInputMapping
    {
		//Player 1
		public static string P1_NavigateHorizontal_1 = "L_XAxis_1";
		public static string P1_NavigateVertical_1 = "L_YAxis_1";
		public static string P1_NavigateHorizontal_2 = "R_XAxis_1";
		public static string P1_NavigateVertical_2 = "R_YAxis_1";
		
		public static string P1_RangedSkill = "R_Trigger_1";
		public static string P1_MeleeSkill = "RB_1";
		public static string P1_SpecialSkill_1 = "L_Trigger_1";
		public static string P1_SpecialSkill_2 = "LB_1";

		
		public static string Pause = "Start_1";
		
		//Player 2
		public static string P2_NavigateHorizontal_1 = "L_XAxis_2";
		public static string P2_NavigateVertical_1 = "L_YAxis_2";
		public static string P2_NavigateHorizontal_2 = "R_XAxis_2";
		public static string P2_NavigateVertical_2 = "R_YAxis_2";
		
		public static string P2_RangedSkill = "R_Trigger_2";
		public static string P2_MeleeSkill = "RB_2";
		public static string P2_SpecialSkill_1 = "L_Trigger_2";
		public static string P2_SpecialSkill_2 = "LB_2";

		public static List<string> GetButtons()
		{
			List<string> mappingStrings = new List<string>();

			//Player 1
			mappingStrings.Add(P1_RangedSkill);
			mappingStrings.Add(P1_MeleeSkill);
			mappingStrings.Add(Pause);
			
			//Player 2
			mappingStrings.Add(P2_RangedSkill);
			mappingStrings.Add(P2_MeleeSkill);


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

			//Player 1
			mappingStrings.Add(P1_NavigateHorizontal_1);
			mappingStrings.Add(P1_NavigateVertical_1);
			mappingStrings.Add(P1_NavigateHorizontal_2);
			mappingStrings.Add(P1_NavigateVertical_2);
			mappingStrings.Add(P1_RangedSkill);
			mappingStrings.Add(P1_SpecialSkill_1);
			
			//Player 2
			mappingStrings.Add(P2_NavigateHorizontal_1);
			mappingStrings.Add(P2_NavigateVertical_1);
			mappingStrings.Add(P2_NavigateHorizontal_2);
			mappingStrings.Add(P2_NavigateVertical_2);
			mappingStrings.Add(P2_RangedSkill);
			mappingStrings.Add(P2_SpecialSkill_1);

			return mappingStrings;
		}
    }
//////////////////////GUI//////////////////////////////////
   
	public static class GUIInputMapping
    {
		public static string NavigateHorizontal = "L_XAxis_1";
		public static string NavigateVertical = "L_YAxis_1";

        public static string Select = "A_1";
        public static string Cancel = "B_1";
        public static string Back = "Back_1";
        public static string Pause = "Start_1";

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
