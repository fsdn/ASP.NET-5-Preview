using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcState.Models
{
    public class FANGModels
    {
    }

    #region Index

    public class FANGIndexInModel
    {
    }

    public class FANGIndexOutModel
    {
        public MvcControllerActionOutModel MvcIndex = new MvcControllerActionOutModel();
    }

    #endregion

    #region BrowserInfomation

    public class FANGBrowserInfomationInModel
    {
    }

    public class FANGBrowserInfomationOutModel
    {
    }

    #endregion

    #region ScreenSize

    public class FANGScreenSizeInModel
    {
    }

    public class FANGScreenSizeOutModel
    {
    }

    #endregion

    #region DebugAPI

    public class FANGDebugAPIInModel
    {
    }

    public class FANGDebugAPIOutModel
    {
    }

    #endregion

    #region AgileFont

    public class FANGAgileFontInModel
    {
    }

    public class FANGAgileFontOutModel
    {
        public MvcIconFontOutModel IconFont = new MvcIconFontOutModel();
    }

    #endregion

    #region GlyphiconsHalflings

    public class FANGGlyphiconsHalflingsInModel
    {
    }

    public class FANGGlyphiconsHalflingsOutModel
    {
        public MvcIconFontOutModel IconFont = new MvcIconFontOutModel();
    }

    #endregion

    #region FontAwesome

    public class FANGFontAwesomeInModel
    {
    }

    public class FANGFontAwesomeOutModel
    {
        public MvcIconFontOutModel IconFont = new MvcIconFontOutModel();
    }

    #endregion
}
