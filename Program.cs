using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EventHandlingSpeedTest.Events;

namespace EventHandlingSpeedTest
{
	internal class Program
	{
		private static List<object> events = new List<object> {};

		private static void Main(string[] args)
		{
			BuildEvents();

			MeasurePerformance((@event) => HandleEvents.Handles((dynamic)@event), "HandlesDynamic");
			MeasurePerformance(HandleEvents.InvokeCaseWhenHandles, "HandlesCaseWhen");
			MeasurePerformance(HandleEventsReflection.InvokeHandle, "HandleEventsReflection");
			MeasurePerformance(HandleEventsReflectionDelegate.InvokeHandle, "HandleEventsReflectionDelegate");
			MeasurePerformance(HandleEventsReflectionFastInvoke.InvokeHandle, "HandleEventsReflectionFastInvoke");
			
			Console.WriteLine(events.Count);
			Console.ReadKey();
		}

		private static void MeasurePerformance(Action<object> action, string name)
		{
			for (var i = 0; i <= 1; i++)
			{
				var sw = Stopwatch.StartNew();
				foreach (var @event in events)
				{
					action.Invoke(@event);
				}
				sw.Stop();
				Console.WriteLine("Result for '{0}': {1}", name, sw.ElapsedMilliseconds);
			}
		}

		private static void BuildEvents()
		{
			Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "EventHandlingSpeedTest.Events").Where(t=>!t.IsInterface).ToArray();
			foreach (Type t in typelist)
			{
				events.Add(Activator.CreateInstance(t));
			}

			for(int i = 0; i < 15; i++)
				events.AddRange(events.ToArray());

			events = events.Take(1000000).ToList();

			Console.WriteLine(events.Count);
		}

		private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
		{
			return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
		}
	}
}

