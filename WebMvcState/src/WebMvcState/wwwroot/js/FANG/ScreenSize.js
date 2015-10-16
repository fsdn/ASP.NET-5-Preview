
$(document).ready(function () {
    afterDocumetReadyEvent();
});

/*
 * document ready run
 */
function afterDocumetReadyEvent() {
    setTimeout(function () {
        var browser_info = browserInfo_2();
        var window_width = $(window).width();
        var window_height = $(window).height();
        var window_client_width_avail = window.screen.availWidth;
        var window_client_height_avail = window.screen.availHeight;
        var window_client_width = window.screen.width;
        var window_client_height = window.screen.height;

        var iHtml_list = ''
        + '<div><h3>浏览器</h3></div>'
        + '<div>名称：' + browser_info.appname + '</div>'
        + '<div>版本：' + browser_info.version + '</div>'
        + '<div>宽度：' + window_width + '</div>'
        + '<div>高度：' + window_height + '</div>'
        + '<div><h3>显示器分辨率</h3></div>'
        + '<div>screen.width：' + window_width + '</div>'
        + '<div>screen.height：' + window_client_height + '</div>'
        + '<div>screen.availwidth：' + window_client_width_avail + '</div>'
        + '<div>screen.availheight：' + window_client_height_avail + '</div>'
        + '<div></div>';

        $(".browser_info").html(iHtml_list);
    }, 10);

    var browserInfo_1 = function browserInfo() {
        var browser = { appname: 'unknown', version: 0 },
            userAgent = window.navigator.userAgent.toLowerCase();
        //IE,firefox,opera,chrome,netscape  
        if (/(msie|firefox|opera|chrome|netscape)\D+(\d[\d.]*)/.test(userAgent)) {
            browser.appname = RegExp.$1;
            browser.version = RegExp.$2;
        } else if (/version\D+(\d[\d.]*).*safari/.test(userAgent)) { // safari  
            browser.appname = 'safari';
            browser.version = RegExp.$2;
        }
        return browser;
    }

    var browserInfo_2 = function browserInfo() {
        var browser = { appname: 'unknown', version: 0 },
            userAgent = window.navigator.userAgent.toLowerCase();

        var regexStr_IE = /msie [\d.]+;/gi;
        var regexStr_IE_11 = /rv\:[\d.]+/gi;
        var regexStr_MicrosoftEdge = /edge\/[\d.]+/gi;
        var regexStr_FireFox = /firefox\/[\d.]+/gi;
        var regexStr_Chrome = /chrome\/[\d.]+/gi;
        var regexStr_Safari = /safari\/[\d.]+/gi;
        var regexStr_appname = /[a-z]+/gi;
        var regexStr_version = /[\d.]+/gi;

        var _info = "undefined",
            _appname = "unknown",
            _version = 0;

        if (userAgent.indexOf("msie") > 0) { // IE
            _info = userAgent.match(regexStr_IE);
        }
        else if (userAgent.indexOf("rv") > 0) { // IE 11
            _info = userAgent.match(regexStr_IE_11);
        }
        else if (userAgent.indexOf("edge") > 0) { // ME(Microsoft Edge) --> window 10
            _info = userAgent.match(regexStr_MicrosoftEdge);
        }
        else if (userAgent.indexOf("firefox") > 0) { // Firefox
            _info = userAgent.match(regexStr_FireFox);
        }
        else if (userAgent.indexOf("chrome") > 0) { // Chrome
            _info = userAgent.match(regexStr_Chrome);
        }
        else if (userAgent.indexOf("safari") > 0 && userAgent.indexOf("chrome") < 0) { // Safari
            _info = userAgent.match(regexStr_Safari);
        }

        _info = _info.toString();
        _appname = _info.match(regexStr_appname);
        _version = _info.match(regexStr_version);

        browser.appname = _appname.length > 0 ? _appname[0] : _appname;
        browser.version = _version.length > 0 ? _version[0] : _version;
        return browser;
    }
}

