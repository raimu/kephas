﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kephas.Resources {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Kephas.Resources.Strings", typeof(Strings).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot get the implementation type for the provided abstract type info &apos;{0}&apos;..
        /// </summary>
        internal static string ActivatorBase_CannotGetImplementationType_Exception {
            get {
                return ResourceManager.GetString("ActivatorBase_CannotGetImplementationType_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot instantiate the implementation type &apos;{0}&apos; because it is not resolved to an {1} instance. The provided type info was &apos;{2}&apos;..
        /// </summary>
        internal static string ActivatorBase_CannotInstantiateAbstractTypeInfo_Exception {
            get {
                return ResourceManager.GetString("ActivatorBase_CannotInstantiateAbstractTypeInfo_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple application services registered for the contract {0} and the override priority does not allow a proper service resolution. The service {1} will be used. Identified eligible parts: {2}..
        /// </summary>
        internal static string AmbiguousOverrideForAppServiceContract {
            get {
                return ResourceManager.GetString("AmbiguousOverrideForAppServiceContract", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The application start procedure was canceled, at {0:s}..
        /// </summary>
        internal static string Application_StartCanceled_Exception {
            get {
                return ResourceManager.GetString("Application_StartCanceled_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The application encountered an exception while starting, at {0:s}..
        /// </summary>
        internal static string Application_StartFaulted_Exception {
            get {
                return ResourceManager.GetString("Application_StartFaulted_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided &apos;{0}&apos; assembly is missing the AppManifestAttribute..
        /// </summary>
        internal static string AppManifestBase_MissingAppManifestAttribute_Exception {
            get {
                return ResourceManager.GetString("AppManifestBase_MissingAppManifestAttribute_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified contract type &apos;{0}&apos; is not assignable from the service contract &apos;{1}&apos;..
        /// </summary>
        internal static string AppServiceCompositionContractTypeDoesNotMatchServiceContract {
            get {
                return ResourceManager.GetString("AppServiceCompositionContractTypeDoesNotMatchServiceContract", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are no constructors marked with {0} for service {1}..
        /// </summary>
        internal static string AppServiceMissingCompositionConstructor {
            get {
                return ResourceManager.GetString("AppServiceMissingCompositionConstructor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple constructors marked with {0} are declared for service {1}..
        /// </summary>
        internal static string AppServiceMultipleCompositionConstructors {
            get {
                return ResourceManager.GetString("AppServiceMultipleCompositionConstructors", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The required service of type &apos;{0}&apos; was not provided..
        /// </summary>
        internal static string CompositionContainerBuilderBase_RequiredServiceMissing_Exception {
            get {
                return ResourceManager.GetString("CompositionContainerBuilderBase_RequiredServiceMissing_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please set the composition assemblies before calling the container synchronously. To load all the application assemblies for composition, please call the CreateContainerAsync method instead..
        /// </summary>
        internal static string CreateContainerRequiresCompositionAssembliesSet {
            get {
                return ResourceManager.GetString("CreateContainerRequiresCompositionAssembliesSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The boostrapper start procedure was canceled, at {0:s}..
        /// </summary>
        internal static string DefaultAppBootstrapper_StartCanceled_Exception {
            get {
                return ResourceManager.GetString("DefaultAppBootstrapper_StartCanceled_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The boostrapper encountered an exception while starting, at {0:s}..
        /// </summary>
        internal static string DefaultAppBootstrapper_StartFaulted_Exception {
            get {
                return ResourceManager.GetString("DefaultAppBootstrapper_StartFaulted_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A serializer for the format type &apos;{0}&apos; was not found..
        /// </summary>
        internal static string DefaultSerializationService_SerializerNotFound_Exception {
            get {
                return ResourceManager.GetString("DefaultSerializationService_SerializerNotFound_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple nodes found for value &apos;{0}&apos;..
        /// </summary>
        internal static string GraphBaseOfTNodeValue_AmbiguousMatchForValue_Exception {
            get {
                return ResourceManager.GetString("GraphBaseOfTNodeValue_AmbiguousMatchForValue_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} is intended to be replaced by a proper implementation..
        /// </summary>
        internal static string NullServiceExceptionMessage {
            get {
                return ResourceManager.GetString("NullServiceExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} of &apos;{1}&apos; is not completed..
        /// </summary>
        internal static string TransitionMonitor_AssertIsCompleted_Exception {
            get {
                return ResourceManager.GetString("TransitionMonitor_AssertIsCompleted_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} of &apos;{1}&apos; is not completed successfully..
        /// </summary>
        internal static string TransitionMonitor_AssertIsCompletedSuccessfully_Exception {
            get {
                return ResourceManager.GetString("TransitionMonitor_AssertIsCompletedSuccessfully_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} of &apos;{1}&apos; is not in progress..
        /// </summary>
        internal static string TransitionMonitor_AssertIsInProgress_Exception {
            get {
                return ResourceManager.GetString("TransitionMonitor_AssertIsInProgress_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} of &apos;{1}&apos; is already started..
        /// </summary>
        internal static string TransitionMonitor_AssertIsNotStarted_Exception {
            get {
                return ResourceManager.GetString("TransitionMonitor_AssertIsNotStarted_Exception", resourceCulture);
            }
        }
    }
}
