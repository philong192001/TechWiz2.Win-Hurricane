#pragma checksum "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Views\Shared\Components\ListCarComponent\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd5cc1b329a2e68ebf2111b74ce22cc87ff72a82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ListCarComponent_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ListCarComponent/Default.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models.Publish;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd5cc1b329a2e68ebf2111b74ce22cc87ff72a82", @"/Views/Shared/Components/ListCarComponent/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d35878c29254fab90008847fdbca88747cf18a30", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ListCarComponent_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Car>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"swiper swiper--offers-economic\">\r\n    <div class=\"swiper-container\">\r\n\r\n        <div class=\"swiper-wrapper\">\r\n            <!-- Slides -->\r\n");
#nullable restore
#line 7 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Views\Shared\Components\ListCarComponent\Default.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"swiper-slide\">\r\n                    <div class=\"thumbnail no-border no-padding thumbnail-car-card\">\r\n                        <div class=\"media\">\r\n                            <a class=\"media-link\" data-gal=\"prettyPhoto\"");
            BeginWriteAttribute("href", " href=\"", 479, "\"", 521, 2);
            WriteAttributeValue("", 486, "assets/img/preview/cars/", 486, 24, true);
#nullable restore
#line 12 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Views\Shared\Components\ListCarComponent\Default.cshtml"
WriteAttributeValue("", 510, item.Image, 510, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <img src=\"assets/img/preview/cars/car-370x220x1.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 609, "\"", 615, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                <span class=""icon-view""><strong><i class=""fa fa-eye""></i></strong></span>
                            </a>
                        </div>
                        <div class=""caption text-center"">
                            <h4 class=""caption-title""><a href=""#"">");
#nullable restore
#line 18 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Views\Shared\Components\ListCarComponent\Default.cshtml"
                                                             Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h4>\r\n                            <div class=\"caption-text\">");
#nullable restore
#line 19 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Views\Shared\Components\ListCarComponent\Default.cshtml"
                                                 Write(item.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            <div class=""buttons"">
                                <a class=""btn btn-theme ripple-effect"" href=""#"">View</a>
                            </div>

                        </div>
                    </div>
                </div>
");
#nullable restore
#line 27 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Views\Shared\Components\ListCarComponent\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n    <!-- If we need navigation buttons -->\r\n    <div class=\"swiper-button-next\"><i class=\"fa fa-angle-right\"></i></div>\r\n    <div class=\"swiper-button-prev\"><i class=\"fa fa-angle-left\"></i></div>\r\n\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Car>> Html { get; private set; }
    }
}
#pragma warning restore 1591