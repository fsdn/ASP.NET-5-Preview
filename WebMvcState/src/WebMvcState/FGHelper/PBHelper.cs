using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Runtime;
using WebMvcState.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace WebMvcState.FGHelper
{
    public class PBHelper
    {
        #region helper class



        #endregion

        #region static variable

        private static string appRootPath = string.Empty;

        /// <summary>
        /// 项目app的根路径，初值赋值后不能修改
        /// </summary>
        public static string AppRootPath
        {
            get
            {
                return appRootPath;
            }

            set
            {
                if (string.IsNullOrEmpty(appRootPath))
                {
                    appRootPath = value;
                }
            }
        }

        private static string webRootPath = string.Empty;

        /// <summary>
        /// 项目web的根路径，初值赋值后不能修改
        /// </summary>
        public static string WebRootPath
        {
            get
            {
                return webRootPath;
            }

            set
            {
                if (string.IsNullOrEmpty(webRootPath))
                {
                    webRootPath = value;
                }
            }
        }

        #endregion

        #region static class

        /// <summary>
        /// 获取指定Controller内的所有Action
        /// </summary>
        /// <param name="pControllerList"></param>
        /// <returns></returns>
        public static MvcControllerActionOutModel GetMvcControllerActionList(List<MvcControllerActionInControllerItem> pControllerList)
        {
            MvcControllerActionOutModel model = new MvcControllerActionOutModel();
            model.ControllerList = new List<MvcControllerActionOutControllerItem>();

            Regex regexControllerRule = new Regex("(?<=public\\sclass\\s).*?(?=\\s:\\scontroller)", RegexOptions.IgnoreCase); // 控制器全称
            Regex regexControllerShortRule = new Regex("^[\\S]*?(?=controller)", RegexOptions.IgnoreCase); // 控制的名称
            Regex regexActionRule = new Regex("(?<=public\\siactionresult\\s).*?(?=\\(\\))", RegexOptions.IgnoreCase); // 页面
            Regex regexSummaryStartRule = new Regex("///\\s<summary>", RegexOptions.IgnoreCase); // 注释结尾
            Regex regexSummaryEndRule = new Regex("///\\s</summary>", RegexOptions.IgnoreCase); // 注释开始 
            Regex regexSummaryTextRule = new Regex("((?<=///\\s).*)", RegexOptions.IgnoreCase); // 注释起始 --> ///
            Regex regexBlackLineRule = new Regex("\n[\\s|]*", RegexOptions.IgnoreCase); // 空行
            Regex regexRightBracketRule = new Regex("}$", RegexOptions.IgnoreCase); // --> }
            foreach (var item in pControllerList)
            {
                string rootPath = PBHelper.appRootPath;
                string partPath = item.ControllerPath;
                string fullPath = string.Format("{0}{1}", rootPath.Replace("\\", "/"), partPath);
                string[] fileLines = File.ReadAllLines(fullPath);
                MvcControllerActionOutControllerItem controllerItem = new MvcControllerActionOutControllerItem();
                controllerItem.ActionList = new List<MvcControllerActionOutActionItem>();

                for (int i = 0; i < fileLines.Length; i++)
                {
                    string lineText = fileLines[i];

                    #region Controller

                    MatchCollection controllerMatchs = regexControllerRule.Matches(lineText);
                    foreach (Match match in controllerMatchs)
                    {
                        GroupCollection groupCollection = match.Groups;
                        foreach (Group group in groupCollection)
                        {
                            Match groupMatch = regexControllerShortRule.Match(group.Value);
                            controllerItem.ControllerName = groupMatch.Value;
                        }
                    }

                    #endregion

                    #region Action

                    MatchCollection actionMatchs = regexActionRule.Matches(lineText);
                    if (actionMatchs.Count > 0)
                    {
                        MvcControllerActionOutActionItem actionItem = new MvcControllerActionOutActionItem();

                        foreach (Match match in actionMatchs)
                        {
                            GroupCollection groupCollection = match.Groups;
                            Group group0 = groupCollection[0];
                            actionItem.ActionName = group0.Value;
                            actionItem.ActionHyperLink = string.Format("/{0}/{1}", controllerItem.ControllerName, actionItem.ActionName);

                            // action description
                            StringBuilder actionDescription = new StringBuilder();
                            // action description flag, tip: 是否开始记录描述
                            bool actionDescriptionFlag = false;
                            // i --> index--
                            for (int n = i; n > 0; n--)
                            {
                                string nLineText = fileLines[n];

                                // regex --> /// <summary>
                                MatchCollection summaryStartMatchs = regexSummaryStartRule.Matches(nLineText);
                                if (summaryStartMatchs.Count > 0)
                                {
                                    actionDescriptionFlag = false;
                                    break; // 跳出循环
                                }

                                if (actionDescriptionFlag)
                                {
                                    MatchCollection summaryTextMatchs = regexSummaryTextRule.Matches(nLineText);
                                    foreach (Match summaryTextMatch in summaryTextMatchs)
                                    {
                                        actionDescription.Append(summaryTextMatch.Value);
                                    }
                                }

                                // regex --> /// </summary>
                                MatchCollection summaryEndMatchs = regexSummaryEndRule.Matches(nLineText);
                                if (summaryEndMatchs.Count > 0)
                                {
                                    actionDescriptionFlag = true;
                                }
                            }

                            actionItem.ActionDescription = Convert.ToString(actionDescription);
                        }

                        controllerItem.ActionList.Add(actionItem);
                    }

                    #endregion

                }

                model.ControllerList.Add(controllerItem);
            }

            return model;
        }

        /// <summary>
        /// 获取指定Css内的所有ClassName
        /// </summary>
        /// <param name="pCssList"></param>
        /// <returns></returns>
        public static MvcIconFontOutModel GetMvcIconFontList(List<MvcIconFontInCssItem> pCssList)
        {
            MvcIconFontOutModel model = new MvcIconFontOutModel();
            model.IconFontList = new List<MvcIconFontOutIconFontItem>();

            foreach (var item in pCssList)
            {
                string rootPath = PBHelper.webRootPath;
                string partPath = item.CssPath;
                string fontFamily = item.FontFamily;
                string fontPrefix = item.FontPrefix;
                string fullPath = string.Format("{0}{1}", rootPath.Replace("\\", "/"), partPath);
                string[] fileLines = File.ReadAllLines(fullPath);
                MvcIconFontOutIconFontItem iconFontItem = new MvcIconFontOutIconFontItem();
                iconFontItem.IconClassList = new List<MvcIconFontOutIconClassItem>();
                iconFontItem.FontFamily = fontFamily;

                Regex regexIconClassRule = new Regex(string.Format("(?<=.){0}.*?(?=\\:before)", fontPrefix), RegexOptions.IgnoreCase); // 字体类的名称
                for (int i = 0; i < fileLines.Length; i++)
                {
                    string lineText = fileLines[i];

                    #region Controller

                    MatchCollection matchs = regexIconClassRule.Matches(lineText);
                    if (matchs.Count > 0)
                    {
                        MvcIconFontOutIconClassItem iconClassItem = new MvcIconFontOutIconClassItem();

                        foreach (Match match in matchs)
                        {
                            iconClassItem.ClassName = match.Value;
                        }

                        iconFontItem.IconClassList.Add(iconClassItem);
                    }

                    #endregion
                }

                model.IconFontList.Add(iconFontItem);
            }

            return model;
        }

        #endregion
    }
}
