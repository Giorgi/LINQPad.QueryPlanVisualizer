﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExecutionPlanVisualizer {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SqlServerResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlServerResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ExecutionPlanVisualizer.SqlServerResources", typeof(SqlServerResources).Assembly);
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
        ///   Looks up a localized string similar to div.qp-node {
        ///    background-color: #FFFFCC;
        ///    margin: 2px;
        ///    padding: 2px;
        ///    border: 1px solid black;
        ///}
        ///
        ///div.qp-node,
        ///div.qp-tt {
        ///    font-size: 11px;
        ///    line-height: normal;
        ///}
        ///
        ///.qp-statement-header {
        ///    display: none;
        ///    border-color: black;
        ///    border-style: solid;
        ///    border-width: 1px 0px 1px 0px;
        ///    padding: 0.3em;
        ///}
        ///
        ///.qp-statement-header-row {
        ///    width: 100%;
        ///    height: 15.6px;
        ///}
        ///
        ///.qp-statement-header-row &gt; div {
        ///    width: 100%;
        ///    position: absolute;
        ///    ov [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string qp_css {
            get {
                return ResourceManager.GetString("qp-css", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap qp_icons {
            get {
                object obj = ResourceManager.GetObject("qp_icons", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to !function(t,e){&quot;object&quot;==typeof exports&amp;&amp;&quot;object&quot;==typeof module?module.exports=e():&quot;function&quot;==typeof define&amp;&amp;define.amd?define([],e):&quot;object&quot;==typeof exports?exports.QP=e():t.QP=e()}(window,function(){return function(t){var e={};function n(i){if(e[i])return e[i].exports;var s=e[i]={i:i,l:!1,exports:{}};return t[i].call(s.exports,s,s.exports,n),s.l=!0,s.exports}return n.m=t,n.c=e,n.d=function(t,e,i){n.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:i})},n.r=function(t){&quot;undefined&quot;!=typeof Symbol&amp;&amp;Symb [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string qp_min_js {
            get {
                return ResourceManager.GetString("qp-min-js", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!DOCTYPE HTML&gt;
        ///&lt;html&gt;
        ///&lt;head&gt;
        ///    &lt;meta charset=&quot;UTF-8&quot;&gt;
        ///    &lt;meta http-equiv=&quot;Content-Type&quot; content=&quot;text/html;charset=utf-8&quot; /&gt;
        ///    &lt;meta http-equiv=&quot;X-UA-Compatible&quot; content=&quot;IE=edge&quot; /&gt;
        ///    &lt;link type=&quot;text/css&quot; media=&quot;all&quot; rel=&quot;stylesheet&quot; href=&quot;qp.css&quot; /&gt;
        ///    &lt;script type=&quot;text/javascript&quot; src=&quot;qp.js&quot;&gt;&lt;/script&gt;
        ///&lt;/head&gt;
        ///  &lt;body&gt;
        ///      &lt;div id=&quot;container&quot;&gt;
        ///          
        ///      &lt;/div&gt;
        ///      &lt;script&gt;
        ///          QP.showPlan(document.getElementById(&quot;container&quot;), &apos;{0}&apos;);
        ///      &lt;/script&gt;
        ///  &lt;/body&gt;        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string template {
            get {
                return ResourceManager.GetString("template", resourceCulture);
            }
        }
    }
}
