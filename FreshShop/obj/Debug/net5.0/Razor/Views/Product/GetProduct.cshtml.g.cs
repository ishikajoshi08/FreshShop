#pragma checksum "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9730c8ae39ad80d210a91e8f8403e8c47b49b4ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_GetProduct), @"mvc.1.0.view", @"/Views/Product/GetProduct.cshtml")]
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
#line 1 "G:\FreshShop\FreshShop\FreshShop\Views\_ViewImports.cshtml"
using FreshShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\FreshShop\FreshShop\FreshShop\Views\_ViewImports.cshtml"
using FreshShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9730c8ae39ad80d210a91e8f8403e8c47b49b4ce", @"/Views/Product/GetProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56b4e94e6d14acd9ec2c82476f9c946b1e7738b2", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_GetProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary p-3 m-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size:15px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetAllProducts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
  
    ViewData["Title"] = "Product" + Model.ProductName;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <h3 class=""display-4"">Product details</h3>
    <div class=""row"">
        <div class=""col-md-6"">
            <div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
                <ol class=""carousel"">
");
#nullable restore
#line 12 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                     for (int i = 0; i < Model.Gallery.Count(); i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li data-target=\"#carouselExampleIndicators\" data-slide-to=\"");
#nullable restore
#line 14 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                                                                               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("class", " class=\"", 527, "\"", 558, 2);
#nullable restore
#line 14 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
WriteAttributeValue("", 535, i==0 ? "active": "", 535, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 557, "", 558, 1, true);
            EndWriteAttribute();
            WriteLiteral("></li>\r\n");
#nullable restore
#line 15 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ol>\r\n                <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 19 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                     for (int i = 0; i < Model.Gallery.Count(); i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div");
            BeginWriteAttribute("class", " class=\"", 782, "\"", 839, 1);
#nullable restore
#line 21 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
WriteAttributeValue("", 790, i==0 ? "carousel-item active": "carousel-item", 790, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 897, "\"", 924, 1);
#nullable restore
#line 22 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
WriteAttributeValue("", 903, Model.Gallery[i].URL, 903, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 925, "\"", 953, 1);
#nullable restore
#line 22 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
WriteAttributeValue("", 931, Model.Gallery[i].Name, 931, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </div>\r\n");
#nullable restore
#line 24 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                </div>
                <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
                    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Previous</span>
                </a>
                <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
                    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Next</span>
                </a>
            </div>
        </div>
        <div class=""col-md-6"">
            <div class=""form-group row"">
                <div class=""col-12"">
                    <span class=""label"" style=""color:black;font-size:20px;"">Product Name:</span>
                    <span class=""label"" style=""color: green;font-size: 20px;"">");
#nullable restore
#line 43 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                                                                         Write(Model.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </div>
            </div>

            <div class=""form-group row"">
                <div class=""col-md-12"">
                    <span class=""label"" style=""color:black;font-size:20px;"">Price:</span>
                    <span class=""label"" style=""color: green;font-size: 20px;"">");
#nullable restore
#line 50 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                                                                         Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </div>
            </div>

            <div class=""form-group row"">
                <div class=""col-md-12"">
                    <span class=""label"" style=""color:black;font-size:20px;"">Description:</span>
                    <span class=""label"" style=""color: green;font-size: 20px;"">");
#nullable restore
#line 57 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                                                                         Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </div>
            </div>

            <div class=""form-group row"">
                <div class=""col-md-12"">
                    <span class=""label"" style=""color:black;font-size:20px;"">Category:</span>
                    <span class=""label"" style=""color: green;font-size: 20px;"">");
#nullable restore
#line 64 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                                                                         Write(Model.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </div>
            </div>

            <div class=""form-group row"">
                <div class=""col-md-12"">
                    <span class=""label"" style=""color:black;font-size:20px;"">Available:</span>
                    <span class=""label"" style=""color: green;font-size: 20px;"">");
#nullable restore
#line 71 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                                                                         Write(Model.IsAvailable);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                </div>
            </div>


            <div>
                <div class=""col-md-4"">
                    <button class=""btn btn-success p-3 m-3"" style=""font-size:15px;"">
                        Add to Cart
                    </button>
                </div>
                <div class=""col-md-4"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9730c8ae39ad80d210a91e8f8403e8c47b49b4ce11834", async() => {
                WriteLiteral("\r\n                        Back to List\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-md-4\">\r\n");
#nullable restore
#line 88 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                     if (Model.IsAvailable)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h3>Available</h3>\r\n");
#nullable restore
#line 91 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h3>Not Available</h3>\r\n");
#nullable restore
#line 95 "G:\FreshShop\FreshShop\FreshShop\Views\Product\GetProduct.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
