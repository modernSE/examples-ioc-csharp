using System;
using System.Configuration;

namespace InterfaceInjection
{
    public class DependentClass1 : IDependentClass
    {
        public void DoSomethingInDependentClass()
        {
            Console.WriteLine("Hello from DependentClass1: I can be injected into MainClass");
        }
    }

    public class DependentClass2 : IDependentClass
    {
        public void DoSomethingInDependentClass()
        {
            Console.WriteLine("Hello from DependentClass2: I can be injected as well, just change App.Config");
        }
    }

    public interface IDependentClass
    {
        void DoSomethingInDependentClass();
    }

    public interface IInjectDependent
    {
        void InjectDependent(IDependentClass dependentClass);
    }

    public class MainClass : IInjectDependent
    {
        private IDependentClass dependentClass;

        public void DoSomething()
        {
            dependentClass.DoSomethingInDependentClass();
        }

        #region IInjectDependent Members

        public void InjectDependent(IDependentClass dependentClass)
        {
            this.dependentClass = dependentClass;
        }

        #endregion
    }

    class Program
    {
        private static void Main(string[] args)
        {
            // Get the correct dependency based on configuration file
            IDependentClass dependency = GetCorrectDependency();

            // Create our main class and inject the dependency
            var mainClass = new MainClass();
            ((IInjectDependent) mainClass).InjectDependent(dependency);

            // Use the main class, the method references the dependency
            // so behaviour depends on the configuration file
            mainClass.DoSomething();

            Console.ReadLine();
        }

        /// <summary>
        ///     Instantiate and return a class conforming to the IDependentClass interface:
        ///     which class gets instantiated depends on the ClassName setting in
        ///     the configuration file
        /// </summary>
        /// <returns>Class conforming to the IDependentClass interface</returns>
        private static IDependentClass GetCorrectDependency()
        {
            string classToCreate = ConfigurationManager.AppSettings["ClassName"];
            Type type = Type.GetType(classToCreate);
            var dependency = (IDependentClass) Activator.CreateInstance(type);
            return dependency;
        }
    }
}