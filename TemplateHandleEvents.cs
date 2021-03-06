﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using EventHandlingSpeedTest.Events;
using Microsoft.CSharp;

namespace EventHandlingSpeedTest
{
	public abstract class HandleEventsReflection<T>
	{
		private static Dictionary<Type, MethodInfo> HandleEventsMethods = new Dictionary<Type, MethodInfo>();

		static HandleEventsReflection()
		{
			BuildHandleEventsCache();
		}

		public static void InvokeHandle(object @event)
		{
			HandleEventsMethods[@event.GetType()].Invoke(null, new[] {@event});
		}

		private static void BuildHandleEventsCache()
		{
			var listOfHandleEventsMethods = typeof(T).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == "Handles");

			foreach (var methodInfo in listOfHandleEventsMethods)
			{
				HandleEventsMethods.Add(methodInfo.GetParameters()[0].ParameterType, methodInfo);
			}
			//Delegate.CreateDelegate(typeof(T), methodInfo).DynamicInvoke()
		}
	}

	public abstract class HandleEventsReflectionDelegate<T>
	{
		private static Dictionary<Type, Delegate> HandleEventsMethods = new Dictionary<Type, Delegate>();

		static HandleEventsReflectionDelegate()
		{
			BuildHandleEventsCache();
		}

		public static void InvokeHandle(object @event)
		{
			HandleEventsMethods[@event.GetType()].DynamicInvoke(@event);
		}

		private static void BuildHandleEventsCache()
		{
			var listOfHandleEventsMethods = typeof(T).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == "Handles");

			foreach (var methodInfo in listOfHandleEventsMethods)
			{
				var t = Expression.Parameter(methodInfo.GetParameters()[0].ParameterType, "Event");
				var t_ = Expression.Convert(t, methodInfo.GetParameters()[0].ParameterType);
				var m = Expression.Call(methodInfo, t_);
				var x = Expression.Lambda(m, t);
				
				HandleEventsMethods.Add(methodInfo.GetParameters()[0].ParameterType, x.Compile());
			}
		}
	}


	public abstract class HandleEventsReflectionCodeDom<T>
	{
		private static MethodInfo switchMethod;

		static HandleEventsReflectionCodeDom()
		{
			BuildHandleEventsCache();
		}

		public static void InvokeHandle(object @event)
		{
			switchMethod.Invoke(null, new[] { @event });
		}

		private static void BuildHandleEventsCache()
		{
			var listOfHandleEventsMethods = typeof(T).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == "Handles");

			var sbSwitch = new StringBuilder();
			foreach (var methodInfo in listOfHandleEventsMethods)
			{
				sbSwitch.AppendLine(string.Format("case \"{0}\": {1}.Handles(({0})Event); break;", methodInfo.GetParameters()[0].ParameterType.Name, typeof(T).Name));
			}

			string source = string.Format(@"
				using EventHandlingSpeedTest.Events;
				using EventHandlingSpeedTest;

        public static class HandleHelper
        {{
            public static void Handle(object Event)
            {{
            	switch (Event.GetType().ToString())
							{{
								{0}
							}}
            }}
        }}
			", sbSwitch);

			CSharpCodeProvider provider = new CSharpCodeProvider();
			CompilerParameters parameters = new CompilerParameters {GenerateInMemory = true, GenerateExecutable = false};

			foreach (Assembly _assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				try
				{
					string location = _assembly.Location;
					if (!String.IsNullOrEmpty(location))
					{
						parameters.ReferencedAssemblies.Add(location);
					}
				}
				catch (NotSupportedException)
				{
					// this happens for dynamic assemblies, so just ignore it. 
				}
			} 

			CompilerResults results = provider.CompileAssemblyFromSource(parameters, source);

			if (results.Errors.HasErrors)
			{
				StringBuilder sb = new StringBuilder();

				foreach (CompilerError error in results.Errors)
				{
					sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
				}

				throw new InvalidOperationException(sb.ToString());
			}

			Assembly assembly = results.CompiledAssembly;
			Type program = assembly.GetType("HandleHelper");
			switchMethod = program.GetMethod("Handle");
		}
	}

	public abstract class HandleEventsReflectionFastInvoke<T>
	{
		public delegate object FastInvokeHandler(object target, object[] paramters);

		private static Dictionary<Type, FastInvokeHandler> HandleEventsMethods = new Dictionary<Type, FastInvokeHandler>();

		static HandleEventsReflectionFastInvoke()
		{
			BuildHandleEventsCache();
		}

		public static void InvokeHandle(object @event)
		{
			HandleEventsMethods[@event.GetType()].DynamicInvoke(null, new[]{ @event });
		}

		private static void BuildHandleEventsCache()
		{
			var listOfHandleEventsMethods = typeof(T).GetMethods(BindingFlags.Static | BindingFlags.Public).Where(m => m.Name == "Handles");

			foreach (var methodInfo in listOfHandleEventsMethods)
			{
				HandleEventsMethods.Add(methodInfo.GetParameters()[0].ParameterType, GetMethodInvoker(methodInfo));
			}
		}

		//Source: http://www.codeproject.com/Articles/14593/A-General-Fast-Method-Invoker
		private static FastInvokeHandler GetMethodInvoker(MethodInfo methodInfo)
		{
			DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(object), new Type[] { typeof(object), typeof(object[]) }, methodInfo.DeclaringType.Module);
			ILGenerator il = dynamicMethod.GetILGenerator();
			ParameterInfo[] ps = methodInfo.GetParameters();
			Type[] paramTypes = new Type[ps.Length];
			for (int i = 0; i < paramTypes.Length; i++)
			{
				if (ps[i].ParameterType.IsByRef)
					paramTypes[i] = ps[i].ParameterType.GetElementType();
				else
					paramTypes[i] = ps[i].ParameterType;
			}
			LocalBuilder[] locals = new LocalBuilder[paramTypes.Length];

			for (int i = 0; i < paramTypes.Length; i++)
			{
				locals[i] = il.DeclareLocal(paramTypes[i], true);
			}
			for (int i = 0; i < paramTypes.Length; i++)
			{
				il.Emit(OpCodes.Ldarg_1);
				EmitFastInt(il, i);
				il.Emit(OpCodes.Ldelem_Ref);
				EmitCastToReference(il, paramTypes[i]);
				il.Emit(OpCodes.Stloc, locals[i]);
			}
			if (!methodInfo.IsStatic)
			{
				il.Emit(OpCodes.Ldarg_0);
			}
			for (int i = 0; i < paramTypes.Length; i++)
			{
				if (ps[i].ParameterType.IsByRef)
					il.Emit(OpCodes.Ldloca_S, locals[i]);
				else
					il.Emit(OpCodes.Ldloc, locals[i]);
			}
			if (methodInfo.IsStatic)
				il.EmitCall(OpCodes.Call, methodInfo, null);
			else
				il.EmitCall(OpCodes.Callvirt, methodInfo, null);
			if (methodInfo.ReturnType == typeof(void))
				il.Emit(OpCodes.Ldnull);
			else
				EmitBoxIfNeeded(il, methodInfo.ReturnType);

			for (int i = 0; i < paramTypes.Length; i++)
			{
				if (ps[i].ParameterType.IsByRef)
				{
					il.Emit(OpCodes.Ldarg_1);
					EmitFastInt(il, i);
					il.Emit(OpCodes.Ldloc, locals[i]);
					if (locals[i].LocalType.IsValueType)
						il.Emit(OpCodes.Box, locals[i].LocalType);
					il.Emit(OpCodes.Stelem_Ref);
				}
			}

			il.Emit(OpCodes.Ret);
			FastInvokeHandler invoder = (FastInvokeHandler)dynamicMethod.CreateDelegate(typeof(FastInvokeHandler));
			return invoder;
		}

		private static void EmitCastToReference(ILGenerator il, System.Type type)
		{
			if (type.IsValueType)
			{
				il.Emit(OpCodes.Unbox_Any, type);
			}
			else
			{
				il.Emit(OpCodes.Castclass, type);
			}
		}

		private static void EmitBoxIfNeeded(ILGenerator il, System.Type type)
		{
			if (type.IsValueType)
			{
				il.Emit(OpCodes.Box, type);
			}
		}

		private static void EmitFastInt(ILGenerator il, int value)
		{
			switch (value)
			{
				case -1:
					il.Emit(OpCodes.Ldc_I4_M1);
					return;
				case 0:
					il.Emit(OpCodes.Ldc_I4_0);
					return;
				case 1:
					il.Emit(OpCodes.Ldc_I4_1);
					return;
				case 2:
					il.Emit(OpCodes.Ldc_I4_2);
					return;
				case 3:
					il.Emit(OpCodes.Ldc_I4_3);
					return;
				case 4:
					il.Emit(OpCodes.Ldc_I4_4);
					return;
				case 5:
					il.Emit(OpCodes.Ldc_I4_5);
					return;
				case 6:
					il.Emit(OpCodes.Ldc_I4_6);
					return;
				case 7:
					il.Emit(OpCodes.Ldc_I4_7);
					return;
				case 8:
					il.Emit(OpCodes.Ldc_I4_8);
					return;
			}

			if (value > -129 && value < 128)
			{
				il.Emit(OpCodes.Ldc_I4_S, (SByte)value);
			}
			else
			{
				il.Emit(OpCodes.Ldc_I4, value);
			}
		}


	}
}
