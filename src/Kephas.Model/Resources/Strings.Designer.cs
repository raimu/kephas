﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kephas.Model.Resources {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Kephas.Model.Resources.Strings", typeof(Strings).GetTypeInfo().Assembly);
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
        ///   Looks up a localized string similar to Cannot provide an element information for the runtime element &apos;{0}&apos;..
        /// </summary>
        internal static string CannotProvideElementInfoForRuntimeElement {
            get {
                return ResourceManager.GetString("CannotProvideElementInfoForRuntimeElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A generic classifier with more than one part is not supported. Check the {0} classifier with parts: {1}..
        /// </summary>
        internal static string ClassifierBase_MultipleGenericPartsNotSupported_Exception {
            get {
                return ResourceManager.GetString("ClassifierBase_MultipleGenericPartsNotSupported_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The element &apos;{0}&apos; is not a member of &apos;{1}&apos;..
        /// </summary>
        internal static string ElementNotFoundInMembers {
            get {
                return ResourceManager.GetString("ElementNotFoundInMembers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The model space is not set in the construction context..
        /// </summary>
        internal static string NamedElementBase_MissingModelSpaceInConstructionContext_Exception {
            get {
                return ResourceManager.GetString("NamedElementBase_MissingModelSpaceInConstructionContext_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property &apos;{0}&apos; in &apos;{1}&apos; does not have any parts to be able to compute the property type..
        /// </summary>
        internal static string Property_MissingPartsToComputePropertyType_Exception {
            get {
                return ResourceManager.GetString("Property_MissingPartsToComputePropertyType_Exception", resourceCulture);
            }
        }
    }
}
