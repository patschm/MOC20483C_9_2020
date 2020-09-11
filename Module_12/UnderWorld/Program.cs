using System;
using System.Reflection;

namespace UnderWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p = new Person { Age = 20, Name = "Joanne" };
            //p.Introduce();

            Assembly asm = Assembly.LoadFrom(@"E:\SomeLib.dll");
            Console.WriteLine(asm.FullName);

            //CheckItOut(asm);
            MoreDarkMatter(asm);
        }

        private static void MoreDarkMatter(Assembly asm)
        {
            Type type = asm.GetType("SomeLib.Person");
            PropertyInfo pAge = type.GetProperty("Age");
            PropertyInfo pName = type.GetProperty("Name");
            MethodInfo pIntro = type.GetMethod("Introduce");
            FieldInfo age = type.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);

            object p1 = Activator.CreateInstance(type);
            pAge.SetValue(p1, -42);
            pName.SetValue(p1, "Kees");
            age.SetValue(p1, -200);
            pIntro.Invoke(p1, null);

            // dynamic Module 11
            dynamic p2 = Activator.CreateInstance(type);
            p2.Name = "Marieke";
            p2.Age = 29;
            p2.Introduce();

        }

        private static void CheckItOut(Assembly asm)
        {
            var types = asm.GetTypes();
            foreach(Type type in types)
            {
                Console.WriteLine(type.FullName);
                foreach(var member in type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    Console.WriteLine(member.Name);
                }
            }
        }
    }
}
