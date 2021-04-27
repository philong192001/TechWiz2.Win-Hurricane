#pragma checksum "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b5884e5b65b57c4db44a465710e670f084123c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Accounts_Views_Admin_Index), @"mvc.1.0.view", @"/Areas/Accounts/Views/Admin/Index.cshtml")]
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
#line 1 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\_ViewImports.cshtml"
using WebApplication.Areas.Accounts.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b5884e5b65b57c4db44a465710e670f084123c2", @"/Areas/Accounts/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dfeb44a01d13b5f62d092e059673a1421fe3c11", @"/Areas/Accounts/Views/_ViewImports.cshtml")]
    public class Areas_Accounts_Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
  
    Layout = "~/Areas/Accounts/Views/Shared/_LayoutAdmin.cshtml";
    var count = 1;
    var data = ViewBag.ListBooking;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Main content -->
<section class=""content"">
    <div class=""container-fluid"">
        <!-- Small boxes (Stat box) -->
        <div class=""row"">
            <div class=""col-lg-3 col-6"">
                <!-- small box -->
                <div class=""small-box bg-info"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 16 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(ViewBag.CountUserBooking);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                        <p>Total Booking</p>
                    </div>
                    <div class=""icon"">
                        <i class=""ion ion-bag""></i>
                    </div>
                    <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-6"">
                <!-- small box -->
                <div class=""small-box bg-success"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 31 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(ViewBag.CountSameFrom);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<sup style=""font-size: 20px""></sup></h3>

                        <p>Same From Trip</p>
                    </div>
                    <div class=""icon"">
                        <i class=""ion ion-stats-bars""></i>
                    </div>
                    <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-6"">
                <!-- small box -->
                <div class=""small-box bg-warning"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 46 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(ViewBag.CountUser);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                        <p>User Registrations</p>
                    </div>
                    <div class=""icon"">
                        <i class=""ion ion-person-add""></i>
                    </div>
                    <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class=""col-lg-3 col-6"">
                <!-- small box -->
                <div class=""small-box bg-danger"">
                    <div class=""inner"">
                        <h3>");
#nullable restore
#line 61 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(ViewBag.CountDriver);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

                        <p>Driver </p>
                    </div>
                    <div class=""icon"">
                        <i class=""ion ion-pie-graph""></i>
                    </div>
                    <a href=""#"" class=""small-box-footer"">More info <i class=""fas fa-arrow-circle-right""></i></a>
                </div>
            </div>
            <!-- ./col -->
        </div>
        <!-- /.row -->
        <!-- Main row -->
        <div class=""container col-md-12 col-lg-12 col-12 col-sm-12 col-md-12"">
            <button class=""btn btn-success"" type=""button"" onclick=""MatchBooking()"">Match</button>
            <table id=""myTable"" class=""table table-bordered display"">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>User</th>
                        <th>Drive</th>
                        <th>To</th>
                        <th>From</th>
                        <th>Date</th>
                        <th>Distanc");
            WriteLiteral(@"e</th>
                        <th>Amount</th>
                        <th>Status</th>
                        <th>Member</th>
                        
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                   
");
#nullable restore
#line 96 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                         for (int i = 0; i < data.Count; i++)

                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                         <tr>\r\n                          <td>\r\n                             ");
#nullable restore
#line 101 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                        Write(data[i].Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                          </td>\r\n                        <td>");
#nullable restore
#line 103 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(data[i].NameUser);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 104 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(data[i].IdDriver);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 105 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(data[i].StartTo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 106 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(data[i].EndFrom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 107 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(data[i].Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 108 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(data[i].Distance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 109 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(data[i].Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                      \r\n                        <td><button class=\"btn btn-warning\">Wait</button></td>\r\n                       \r\n                       \r\n                        <td>");
#nullable restore
#line 114 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                       Write(data[i].Member);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        \r\n                        <td><input type=\"checkbox\" name=\"Checkbook\"");
            BeginWriteAttribute("id", " id=\"", 4592, "\"", 4608, 1);
#nullable restore
#line 116 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
WriteAttributeValue("", 4597, data[i].Id, 4597, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></td>\r\n                    </tr>\r\n");
#nullable restore
#line 118 "E:\TechWiz2.Win-Hurricane\WebApplication\WebApplication\Areas\Accounts\Views\Admin\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n        <!-- /.row (main row) -->\r\n    </div><!-- /.container-fluid -->\r\n</section>\r\n<!-- /.content -->\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
