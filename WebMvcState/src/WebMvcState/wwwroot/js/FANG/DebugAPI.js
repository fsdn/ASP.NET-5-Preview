
$(document).ready(function () {
    afterDocumetReadyEvent();
});

/*
 * document ready run
 */
function afterDocumetReadyEvent() {


    $(".ajax_debug").click(function () {
        var self = $(this);
        var selfEnable = $.trim($(self).attr("data-enable"));
        if (selfEnable == "1") {
            $(self).attr({ "data-enable": "0" });

            var ajax_type = $.trim($(".ajax_type").val());
            var ajax_contentType = $.trim($(".ajax_contentType").val());
            var ajax_dataType = $.trim($(".ajax_dataType").val());
            var ajax_data = $.trim($(".ajax_data").val());
            var ajax_url = $.trim($(".ajax_url").val());
            $.ajax({
                type: (ajax_type.toLowerCase() == "get" ? "GET" : "POST"),
                url: ajax_url + "&tsp=" + (new Date()).getTime(),
                data: (ajax_data == "" ? {} : ajax_data), // {},
                dataType: ajax_dataType,
                contentType: ajax_contentType,
                cache: false,
                success: function (data) {
                    window.console.log("----- success -----------------------------------------");
                    window.console.log(data);

                    $(".ajax_data").val(data);
                },
                error: function (xhr, type) {
                    window.console.log("----- error -----------------------------------------");
                    window.console.log(xhr);
                    // window.console.log(type);  // -- error

                    alert("请求出错了！！！");
                    $(".ajax_error").val("错误代码：" + xhr.status + "\n" + "错误描述：" + xhr.statusText);
                },
                complete: function (xhr, ts) {
                    window.console.log("----- complete -----------------------------------------");
                    window.console.log(xhr);
                    //window.console.log(ts);  // -- error

                    $(self).attr({ "data-enable": "1" });
                    $(".ajax_complete").val("返回代码：" + xhr.status + "\n" + "返回描述：" + xhr.statusText);
                }
            });
        }
    });
}