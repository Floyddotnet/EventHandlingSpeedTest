using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventHandlingSpeedTest.Events;

namespace EventHandlingSpeedTest
{
	public class HandleEvents
	{

		public static void InvokeCaseWhenHandles(object Event)
		{
			switch (Event.GetType().ToString())
			{
				case "Event1": Handles((Event1)Event); break;
				case "Event2": Handles((Event2)Event); break;
				case "Event3": Handles((Event3)Event); break;
				case "Event4": Handles((Event4)Event); break;
				case "Event5": Handles((Event5)Event); break;
				case "Event6": Handles((Event6)Event); break;
				case "Event7": Handles((Event7)Event); break;
				case "Event8": Handles((Event8)Event); break;
				case "Event9": Handles((Event9)Event); break;
				case "Event10": Handles((Event10)Event); break;
				case "Event11": Handles((Event11)Event); break;
				case "Event12": Handles((Event12)Event); break;
				case "Event13": Handles((Event13)Event); break;
				case "Event14": Handles((Event14)Event); break;
				case "Event15": Handles((Event15)Event); break;
				case "Event16": Handles((Event16)Event); break;
				case "Event17": Handles((Event17)Event); break;
				case "Event18": Handles((Event18)Event); break;
				case "Event19": Handles((Event19)Event); break;
				case "Event20": Handles((Event20)Event); break;
				case "Event21": Handles((Event21)Event); break;
				case "Event22": Handles((Event22)Event); break;
				case "Event23": Handles((Event23)Event); break;
				case "Event24": Handles((Event24)Event); break;
				case "Event25": Handles((Event25)Event); break;
				case "Event26": Handles((Event26)Event); break;
				case "Event27": Handles((Event27)Event); break;
				case "Event28": Handles((Event28)Event); break;
				case "Event29": Handles((Event29)Event); break;
				case "Event30": Handles((Event30)Event); break;
				case "Event31": Handles((Event31)Event); break;
				case "Event32": Handles((Event32)Event); break;
				case "Event33": Handles((Event33)Event); break;
				case "Event34": Handles((Event34)Event); break;
				case "Event35": Handles((Event35)Event); break;
				case "Event36": Handles((Event36)Event); break;
				case "Event37": Handles((Event37)Event); break;
				case "Event38": Handles((Event38)Event); break;
				case "Event39": Handles((Event39)Event); break;
				case "Event40": Handles((Event40)Event); break;
				case "Event41": Handles((Event41)Event); break;
				case "Event42": Handles((Event42)Event); break;
				case "Event43": Handles((Event43)Event); break;
				case "Event44": Handles((Event44)Event); break;
				case "Event45": Handles((Event45)Event); break;
				case "Event46": Handles((Event46)Event); break;
				case "Event47": Handles((Event47)Event); break;
				case "Event48": Handles((Event48)Event); break;
				case "Event49": Handles((Event49)Event); break;
				case "Event50": Handles((Event50)Event); break;
				case "Event51": Handles((Event51)Event); break;
				case "Event52": Handles((Event52)Event); break;
				case "Event53": Handles((Event53)Event); break;
				case "Event54": Handles((Event54)Event); break;
				case "Event55": Handles((Event55)Event); break;
				case "Event56": Handles((Event56)Event); break;
				case "Event57": Handles((Event57)Event); break;
				case "Event58": Handles((Event58)Event); break;
				case "Event59": Handles((Event59)Event); break;
				case "Event60": Handles((Event60)Event); break;
				case "Event61": Handles((Event61)Event); break;
				case "Event62": Handles((Event62)Event); break;
				case "Event63": Handles((Event63)Event); break;
				case "Event64": Handles((Event64)Event); break;
				case "Event65": Handles((Event65)Event); break;
				case "Event66": Handles((Event66)Event); break;
				case "Event67": Handles((Event67)Event); break;
				case "Event68": Handles((Event68)Event); break;
				case "Event69": Handles((Event69)Event); break;
				case "Event70": Handles((Event70)Event); break;
				case "Event71": Handles((Event71)Event); break;
				case "Event72": Handles((Event72)Event); break;
				case "Event73": Handles((Event73)Event); break;
				case "Event74": Handles((Event74)Event); break;
				case "Event75": Handles((Event75)Event); break;
				case "Event76": Handles((Event76)Event); break;
				case "Event77": Handles((Event77)Event); break;
				case "Event78": Handles((Event78)Event); break;
				case "Event79": Handles((Event79)Event); break;
				case "Event80": Handles((Event80)Event); break;
				case "Event81": Handles((Event81)Event); break;
				case "Event82": Handles((Event82)Event); break;
				case "Event83": Handles((Event83)Event); break;
				case "Event84": Handles((Event84)Event); break;
				case "Event85": Handles((Event85)Event); break;
				case "Event86": Handles((Event86)Event); break;
				case "Event87": Handles((Event87)Event); break;
				case "Event88": Handles((Event88)Event); break;
				case "Event89": Handles((Event89)Event); break;
				case "Event90": Handles((Event90)Event); break;
				case "Event91": Handles((Event91)Event); break;
				case "Event92": Handles((Event92)Event); break;
				case "Event93": Handles((Event93)Event); break;
				case "Event94": Handles((Event94)Event); break;
				case "Event95": Handles((Event95)Event); break;
				case "Event96": Handles((Event96)Event); break;
				case "Event97": Handles((Event97)Event); break;
				case "Event98": Handles((Event98)Event); break;
				case "Event99": Handles((Event99)Event); break;
				case "Event100": Handles((Event100)Event); break;
			}
		}

		public static void Handles(Event1 Event) {  }
		public static void Handles(Event2 Event) {  }
		public static void Handles(Event3 Event) {  }
		public static void Handles(Event4 Event) {  }
		public static void Handles(Event5 Event) {  }
		public static void Handles(Event6 Event) {  }
		public static void Handles(Event7 Event) {  }
		public static void Handles(Event8 Event) {  }
		public static void Handles(Event9 Event) {  }
		public static void Handles(Event10 Event) {  }
		public static void Handles(Event11 Event) {  }
		public static void Handles(Event12 Event) {  }
		public static void Handles(Event13 Event) {  }
		public static void Handles(Event14 Event) {  }
		public static void Handles(Event15 Event) {  }
		public static void Handles(Event16 Event) {  }
		public static void Handles(Event17 Event) {  }
		public static void Handles(Event18 Event) {  }
		public static void Handles(Event19 Event) {  }
		public static void Handles(Event20 Event) {  }
		public static void Handles(Event21 Event) {  }
		public static void Handles(Event22 Event) {  }
		public static void Handles(Event23 Event) {  }
		public static void Handles(Event24 Event) {  }
		public static void Handles(Event25 Event) {  }
		public static void Handles(Event26 Event) {  }
		public static void Handles(Event27 Event) {  }
		public static void Handles(Event28 Event) {  }
		public static void Handles(Event29 Event) {  }
		public static void Handles(Event30 Event) {  }
		public static void Handles(Event31 Event) {  }
		public static void Handles(Event32 Event) {  }
		public static void Handles(Event33 Event) {  }
		public static void Handles(Event34 Event) {  }
		public static void Handles(Event35 Event) {  }
		public static void Handles(Event36 Event) {  }
		public static void Handles(Event37 Event) {  }
		public static void Handles(Event38 Event) {  }
		public static void Handles(Event39 Event) {  }
		public static void Handles(Event40 Event) {  }
		public static void Handles(Event41 Event) {  }
		public static void Handles(Event42 Event) {  }
		public static void Handles(Event43 Event) {  }
		public static void Handles(Event44 Event) {  }
		public static void Handles(Event45 Event) {  }
		public static void Handles(Event46 Event) {  }
		public static void Handles(Event47 Event) {  }
		public static void Handles(Event48 Event) {  }
		public static void Handles(Event49 Event) {  }
		public static void Handles(Event50 Event) {  }
		public static void Handles(Event51 Event) {  }
		public static void Handles(Event52 Event) {  }
		public static void Handles(Event53 Event) {  }
		public static void Handles(Event54 Event) {  }
		public static void Handles(Event55 Event) {  }
		public static void Handles(Event56 Event) {  }
		public static void Handles(Event57 Event) {  }
		public static void Handles(Event58 Event) {  }
		public static void Handles(Event59 Event) {  }
		public static void Handles(Event60 Event) {  }
		public static void Handles(Event61 Event) {  }
		public static void Handles(Event62 Event) {  }
		public static void Handles(Event63 Event) {  }
		public static void Handles(Event64 Event) {  }
		public static void Handles(Event65 Event) {  }
		public static void Handles(Event66 Event) {  }
		public static void Handles(Event67 Event) {  }
		public static void Handles(Event68 Event) {  }
		public static void Handles(Event69 Event) {  }
		public static void Handles(Event70 Event) {  }
		public static void Handles(Event71 Event) {  }
		public static void Handles(Event72 Event) {  }
		public static void Handles(Event73 Event) {  }
		public static void Handles(Event74 Event) {  }
		public static void Handles(Event75 Event) {  }
		public static void Handles(Event76 Event) {  }
		public static void Handles(Event77 Event) {  }
		public static void Handles(Event78 Event) {  }
		public static void Handles(Event79 Event) {  }
		public static void Handles(Event80 Event) {  }
		public static void Handles(Event81 Event) {  }
		public static void Handles(Event82 Event) {  }
		public static void Handles(Event83 Event) {  }
		public static void Handles(Event84 Event) {  }
		public static void Handles(Event85 Event) {  }
		public static void Handles(Event86 Event) {  }
		public static void Handles(Event87 Event) {  }
		public static void Handles(Event88 Event) {  }
		public static void Handles(Event89 Event) {  }
		public static void Handles(Event90 Event) {  }
		public static void Handles(Event91 Event) {  }
		public static void Handles(Event92 Event) {  }
		public static void Handles(Event93 Event) {  }
		public static void Handles(Event94 Event) {  }
		public static void Handles(Event95 Event) {  }
		public static void Handles(Event96 Event) {  }
		public static void Handles(Event97 Event) {  }
		public static void Handles(Event98 Event) {  }
		public static void Handles(Event99 Event) {  }
		public static void Handles(Event100 Event) {  }
	}
}
