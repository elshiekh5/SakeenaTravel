//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Calendar {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Calendar() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Calendar", global::System.Reflection.Assembly.Load("App_GlobalResources"));
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
        ///   Looks up a localized string similar to المكان.
        /// </summary>
        internal static string Address {
            get {
                return ResourceManager.GetString("Address", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to اسم المختص.
        /// </summary>
        internal static string AuthorName {
            get {
                return ResourceManager.GetString("AuthorName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to منظم بواسطة.
        /// </summary>
        internal static string ExtraText_1 {
            get {
                return ResourceManager.GetString("ExtraText_1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاريخ البدء.
        /// </summary>
        internal static string ItemDate {
            get {
                return ResourceManager.GetString("ItemDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاريخ الإنتهاء.
        /// </summary>
        internal static string ItemEndDate {
            get {
                return ResourceManager.GetString("ItemEndDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to وقت البدء.
        /// </summary>
        internal static string MailBox {
            get {
                return ResourceManager.GetString("MailBox", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to وقت الإنتهاء.
        /// </summary>
        internal static string ZipCode {
            get {
                return ResourceManager.GetString("ZipCode", resourceCulture);
            }
        }
    }
}
