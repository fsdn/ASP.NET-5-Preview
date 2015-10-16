using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebMvcState.FGHelper;
using WebMvcState.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMvcState.Controllers
{
    public class FANGController : Controller
    {
        // GET: /<controller>/

        /// <summary>
        /// 所有页面的索引
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            FANGIndexOutModel model = new FANGIndexOutModel();

            #region data

            List<MvcControllerActionInControllerItem> pControllerList = new List<MvcControllerActionInControllerItem>();

            // FANGController
            pControllerList.Add(new MvcControllerActionInControllerItem
            {
                ControllerPath = "/Controllers/FANGController.cs"
            });

            // WeiXinController
            pControllerList.Add(new MvcControllerActionInControllerItem
            {
                ControllerPath = "/Controllers/WeiXinController.cs"
            });

            // 取出索引
            model.MvcIndex = FGHelper.PBHelper.GetMvcControllerActionList(pControllerList);

            #endregion

            return this.View(model);
        }

        /// <summary>
        /// 获取浏览器页面信息
        /// </summary>
        /// <returns></returns>
        public IActionResult BrowserInfomation()
        {
            FANGBrowserInfomationOutModel model = new FANGBrowserInfomationOutModel();

            #region data

            #endregion

            return this.View(model);
        }

        /// <summary>
        /// 测量页面尺寸（单位px）
        /// </summary>
        /// <returns></returns>
        public IActionResult ScreenSize()
        {
            FANGScreenSizeOutModel model = new FANGScreenSizeOutModel();

            #region data

            #endregion

            return this.View(model);
        }

        /// <summary>
        /// Agile Lite 所使用的字体
        /// </summary>
        /// <returns></returns>
        public IActionResult AgileFont()
        {
            FANGAgileFontOutModel model = new FANGAgileFontOutModel();

            #region data

            List<MvcIconFontInCssItem> pCssList = new List<MvcIconFontInCssItem>();

            // iconline
            pCssList.Add(new MvcIconFontInCssItem
            {
                FontFamily = "iconline",
                FontPrefix = "iconline",
                CssPath = "/lib/agile-lite/dist/agile/css/flat/iconline.css"
            });

            // iconform
            pCssList.Add(new MvcIconFontInCssItem
            {
                FontFamily = "iconform",
                FontPrefix = "iconform",
                CssPath = "/lib/agile-lite/dist/agile/css/flat/iconform.css"
            });

            // iconweather
            pCssList.Add(new MvcIconFontInCssItem
            {
                FontFamily = "iconweather",
                FontPrefix = "iconweather",
                CssPath = "/lib/agile-lite/dist/agile/css/flat/iconweather.css"
            });

            // iconlogo
            pCssList.Add(new MvcIconFontInCssItem
            {
                FontFamily = "iconlogo",
                FontPrefix = "iconlogo",
                CssPath = "/lib/agile-lite/dist/agile/css/flat/iconlogo.css"
            });

            // 取出数据
            model.IconFont = FGHelper.PBHelper.GetMvcIconFontList(pCssList);

            #endregion

            return this.View(model);
        }

        /// <summary>
        /// Glyphicons Halflings字体，Bootstrap 样式集成
        /// </summary>
        /// <returns></returns>
        public IActionResult GlyphiconsHalflings()
        {
            FANGGlyphiconsHalflingsOutModel model = new FANGGlyphiconsHalflingsOutModel();

            #region data

            List<MvcIconFontInCssItem> pCssList = new List<MvcIconFontInCssItem>();

            // iconline
            pCssList.Add(new MvcIconFontInCssItem
            {
                FontFamily = "Glyphicons Halflings",
                FontPrefix = "glyphicon",
                CssPath = "/lib/bootstrap/dist/css/bootstrap.css"
            });

            // 取出数据
            model.IconFont = FGHelper.PBHelper.GetMvcIconFontList(pCssList);

            #endregion

            return this.View(model);
        }

        /// <summary>
        /// Font-Awesome字体， https://github.com/FortAwesome/Font-Awesome
        /// </summary>
        /// <returns></returns>
        public IActionResult FontAwesome()
        {
            FANGFontAwesomeOutModel model = new FANGFontAwesomeOutModel();

            #region data

            List<MvcIconFontInCssItem> pCssList = new List<MvcIconFontInCssItem>();

            // iconline
            pCssList.Add(new MvcIconFontInCssItem
            {
                FontFamily = "FontAwesome",
                FontPrefix = "fa",
                CssPath = "/lib/font-awesome/css/font-awesome.css"
            });

            // 取出数据
            model.IconFont = FGHelper.PBHelper.GetMvcIconFontList(pCssList);

            #endregion

            return this.View(model);
        }
    }
}
