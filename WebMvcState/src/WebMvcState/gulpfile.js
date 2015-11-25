/// <binding Clean='clean' />

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"), // 合并代码
    cssmin = require("gulp-cssmin"), // 压缩css
    uglify = require("gulp-uglify"), // 压缩js
    rev = require("gulp-rev"), // MD5后缀
    clean = require("gulp-clean"), // 清空文件夹
    project = require("./project.json");

var paths = {
    webroot: "./" + project.webroot + "/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

//gulp.task("clean:js", function (cb) {
//    //rimraf(paths.concatJsDest, cb);
//});

//gulp.task("clean:css", function (cb) {
//    //rimraf(paths.concatCssDest, cb);
//});

//gulp.task("clean", ["clean:js", "clean:css"]);

//gulp.task("min:js", function () {
//    //gulp.src([paths.js, "!" + paths.minJs], { base: "." })
//    //    .pipe(concat(paths.concatJsDest))
//    //    .pipe(uglify())
//    //    .pipe(gulp.dest("."));
//});

//gulp.task("min:css", function () {
//    //gulp.src([paths.css, "!" + paths.minCss])
//    //    .pipe(concat(paths.concatCssDest))
//    //    .pipe(cssmin())
//    //    .pipe(gulp.dest("."));
//});

//gulp.task("min", ["min:js", "min:css"]);

//#region FANG gulp

mfun_gulp(); // 调用

/*
 * FANG gulp
 */
function mfun_gulp() {

    var project_path = "./wwwroot/";
    var project_path_lib = project_path + "lib/";
    var project_path_min_js = "./wwwroot/js/MIN/";
    var project_path_min_css = "./wwwroot/css/MIN/";

    var array_list_gulp = new Array();

    // jquery
    array_list_gulp.push({
        value: "jquery",
        array_js: ["./wwwroot/lib/jquery/dist/jquery.js"],
        array_css: ["./wwwroot/lib/jquery/dist/jquery.css"]
    });

    // All
    array_list_gulp.push({
        value: "All",
        array_js: ["./wwwroot/js/ALL/All.js"],
        array_css: ["./wwwroot/css/ALL/All.css"]
    });

    //// agile-lite // 文字字体库，压缩后不能修改路径
    //array_list_gulp.push({
    //    value: "agile-lite",
    //    array_js: [
    //        "./wwwroot/lib/agile-lite/dist/third/jquery/jquery-2.1.3.min.js",
    //        "./wwwroot/lib/agile-lite/dist/third/jquery/jquery.mobile.custom.min.js",
    //        "./wwwroot/lib/agile-lite/dist/third/iscroll/iscroll-probe.js",
    //        "./wwwroot/lib/agile-lite/dist/third/arttemplate/template-native.js",
    //        "./wwwroot/lib/agile-lite/dist/agile/js/agile.js",
    //        "./wwwroot/lib/agile-lite/dist/bridge/exmobi.js",
    //        "./wwwroot/lib/agile-lite/dist/bridge/agile.exmobi.js",
    //        "./wwwroot/lib/agile-lite/dist/component/exlist/agile.exlist.js"
    //    ],
    //    array_css: [
    //        "./wwwroot/lib/agile-lite/dist/agile/css/agile.layout.css",
    //        "./wwwroot/lib/agile-lite/dist/agile/css/flat/flat.component.css",
    //        "./wwwroot/lib/agile-lite/dist/agile/css/flat/flat.color.css",
    //        "./wwwroot/lib/agile-lite/dist/agile/css/flat/iconline.css",
    //        "./wwwroot/lib/agile-lite/dist/agile/css/flat/iconlogo.css",
    //        "./wwwroot/lib/agile-lite/dist/agile/css/flat/iconform.css",
    //        "./wwwroot/lib/agile-lite/dist/component/exlist/exlist.css"
    //    ]
    //});

    //// bootstrap // 文字字体库，压缩后不能修改路径
    //array_list_gulp.push({
    //    value: "bootstrap",
    //    array_js: ["./wwwroot/lib/bootstrap/dist/js/bootstrap.js"],
    //    array_css: ["./wwwroot/lib/bootstrap/dist/css/bootstrap.css"]
    //});

    // ViewFANG
    array_list_gulp.push({
        value: "ViewFANG",
        array_js: [
            "./wwwroot/js/ALL/All.js",
            "./wwwroot/js/ALL/ViewFANG.js"
        ],
        array_css: [
            "./wwwroot/css/ALL/All.css",
            "./wwwroot/css/ALL/ViewFANG.css"
        ]
    });

    // Index_FANG
    array_list_gulp.push({
        value: "Index_FANG",
        array_js: [
            "./wwwroot/js/FANG/Index.js"
        ],
        array_css: [
            "./wwwroot/css/FANG/Index.css"
        ]
    });

    // BrowserInfomation
    array_list_gulp.push({
        value: "BrowserInfomation",
        array_js: [
            "./wwwroot/js/FANG/BrowserInfomation.js"
        ],
        array_css: [
            "./wwwroot/css/FANG/BrowserInfomation.css"
        ]
    });

    // ScreenSize
    array_list_gulp.push({
        value: "ScreenSize",
        array_js: [
            "./wwwroot/js/FANG/ScreenSize.js"
        ],
        array_css: [
            "./wwwroot/css/FANG/ScreenSize.css"
        ]
    });

    // DebugAPI
    array_list_gulp.push({
        value: "DebugAPI",
        array_js: [
            "./wwwroot/js/FANG/DebugAPI.js"
        ],
        array_css: [
            "./wwwroot/css/FANG/DebugAPI.css"
        ]
    });

    // AgileFont
    array_list_gulp.push({
        value: "AgileFont",
        array_js: [
            "./wwwroot/js/FANG/AgileFont.js"
        ],
        array_css: [
            "./wwwroot/css/FANG/AgileFont.css"
        ]
    });

    // GlyphiconsHalflings
    array_list_gulp.push({
        value: "GlyphiconsHalflings",
        array_js: [
            "./wwwroot/js/FANG/GlyphiconsHalflings.js"
        ],
        array_css: [
            "./wwwroot/css/FANG/GlyphiconsHalflings.css"
        ]
    });

    // FontAwesome
    array_list_gulp.push({
        value: "FontAwesome",
        array_js: [
            "./wwwroot/js/FANG/FontAwesome.js"
        ],
        array_css: [
            "./wwwroot/css/FANG/FontAwesome.css"
        ]
    });

    // ViewWeiXin
    array_list_gulp.push({
        value: "ViewWeiXin",
        array_js: [
            "./wwwroot/js/ALL/All.js",
            "./wwwroot/js/ALL/ViewWeiXin.js"
        ],
        array_css: [
            "./wwwroot/css/ALL/All.css",
            "./wwwroot/css/ALL/ViewWeiXin.css"
        ]
    });

    // Index_WeiXin
    array_list_gulp.push({
        value: "Index_WeiXin",
        array_js: [
            "./wwwroot/js/WeiXin/Index.js"
        ],
        array_css: [
            "./wwwroot/css/WeiXin/Index.css"
        ]
    });

    // #region mfun_gulp_task

    /*
     *  mfun_gulp_task
     */
    var list = array_list_gulp;
    var list_path_min_js = project_path_min_js;
    var list_path_min_css = project_path_min_css;

    // js
    gulp.task("clean:clean_js", function (cb) {
        gulp.src(["./wwwroot/js/MIN/*.js"], { read: false })
            .pipe(clean({ force: true }));
    });

    // css
    gulp.task("clean:clean_css", function (cb) {
        gulp.src(["./wwwroot/css/MIN/*.css"], { read: false })
            .pipe(clean({ force: true }));
    });

    // clean
    gulp.task("clean", ["clean:clean_js", "clean:clean_css"]);

    // js
    gulp.task("min:min_js", function () {
        var list = array_list_gulp;

        for (var i = 0; i < list.length; i++) {
            var item = list[i];
            var item_value = item.value;
            var item_path_min_js = list_path_min_js + item_value + ".min.js";
            var item_path_min_css = list_path_min_css + item_value + ".min.css";
            var item_array_js = item.array_js;
            var item_array_css = item.array_css;

            gulp.src(item_array_js, { base: "." })
                .pipe(concat(item_path_min_js))
                .pipe(uglify())
                //.pipe(rev()) 
                .pipe(gulp.dest("."));
        }
    });

    // css
    gulp.task("min:min_css", function () {
        var list = array_list_gulp;

        for (var i = 0; i < list.length; i++) {
            var item = list[i];
            var item_value = item.value;
            var item_path_min_js = list_path_min_js + item_value + ".min.js";
            var item_path_min_css = list_path_min_css + item_value + ".min.css";
            var item_array_js = item.array_js;
            var item_array_css = item.array_css;

            gulp.src(item_array_css)
                .pipe(concat(item_path_min_css))
                .pipe(cssmin())
                //.pipe(rev())
                .pipe(gulp.dest("."));
        }
    });

    // min
    gulp.task("min", ["min:min_js", "min:min_css"]);

    // #endregion

}

//#endregion