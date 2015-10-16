using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcState.Models
{
    public class FGHelperModels
    {
    }

    #region MvcControllerAction Model

    public class MvcControllerActionInModel
    {

    }

    public class MvcControllerActionInControllerItem
    {
        public string ControllerPath = string.Empty;
    }

    public class MvcControllerActionOutModel
    {
        public List<MvcControllerActionOutControllerItem> ControllerList = new List<MvcControllerActionOutControllerItem>();
    }

    public class MvcControllerActionOutControllerItem
    {
        public string ControllerName = string.Empty;

        public List<MvcControllerActionOutActionItem> ActionList = new List<MvcControllerActionOutActionItem>();
    }

    public class MvcControllerActionOutActionItem
    {
        public string ActionName = string.Empty;

        public string ActionDescription = string.Empty;

        public string ActionHyperLink = string.Empty;
    }

    #endregion

    #region MvcIconFont Model

    public class MvcIconFontInModel
    {
    }

    public class MvcIconFontInCssItem
    {
        public string FontFamily = string.Empty;

        public string FontPrefix = string.Empty;

        public string CssPath = string.Empty;
    }

    public class MvcIconFontOutModel
    {
        public List<MvcIconFontOutIconFontItem> IconFontList = new List<MvcIconFontOutIconFontItem>();
    }

    public class MvcIconFontOutIconFontItem
    {
        public string FontFamily = string.Empty;

        public List<MvcIconFontOutIconClassItem> IconClassList = new List<MvcIconFontOutIconClassItem>();
    }

    public class MvcIconFontOutIconClassItem
    {
        public string ClassName = string.Empty;
    }

    #endregion
}
