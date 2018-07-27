function pageModel() {
    this.currentPageIndex = 1;
    this.MaxPageIndex = 1;
    this.loadData = function () { };
    this.pagesize = 10;
    this.eleid = "";
}

function koViewModel() {
    var self = this;
    self.Data = [];
}
function renderPage(options) {
    var currentPageIndex = options.pageindex;
    var MaxPageIndex = options.MaxPageIndex;
    var loadData = options.loadData;
    var $this = $("#" + options.eleid).parent();
    var ul = $("<ul></ul>").addClass("pagination");
    var prev = $("<li></li>").append($("<a></a>").append($("<i class='icon-double-angle-left'></i>"))).addClass("prev");
    if (currentPageIndex == 1) {
        prev.addClass("disabled");
    }

    var next = $("<li></li>").append($("<a></a>").append($("<i class='icon-double-angle-right'></i>"))).addClass("next");
    if (MaxPageIndex <= 1 || currentPageIndex == MaxPageIndex) {
        next.addClass("disabled");
    }
    var minIndex = currentPageIndex - 5;
    var plus = 0;
    if (minIndex <= 0) {
        plus = 0 - minIndex;
        minIndex = 1;
    }
    var maxIndex = currentPageIndex + 5 + plus;
    if (maxIndex > MaxPageIndex) {
        maxIndex = MaxPageIndex;
    }
    ul.append(prev);
    for (var i = minIndex; i <= maxIndex; i++) {
        var li_html = $("<li></li>");
        if (currentPageIndex == i)
            li_html.addClass("active disabled");
        var item = li_html.append($("<a></a>").html(i));
        ul.append(item);
    }
    ul.append(next);
    ul.children("li").click(function () {
        if (!$(this).is(".disabled")) {
            var index = $(this).text();
            if (index.length == 0) {
                index = ul.find(".active").text();
                if ($(this).is(".prev") && index > 1) {
                    index--;
                } else if ($(this).is(".next") && index < MaxPageIndex) {
                    index++;
                }
            }
            var arg = $.extend({ "pageindex": parseInt(index) }, options);
            arg.pageindex = parseInt(index);
            loadData(arg);
        }
    });
    if ($this.parent().find(".dataTables_paginate").length > 0) {
        $this.parent().find(".dataTables_paginate").empty().append(ul);
    } else {
        var div_pagination = $("<div class=\"dataTables_paginate paging_bootstrap\"></div>");
        div_pagination.append(ul);
        $this.after(div_pagination);//.empty().append(ul);
    }
}
function renderLoading(eleid) {
    var loadname = eleid + "-loading-" + new Date().valueOf();
    var $this = $("#" + eleid);
    $this.attr("data-loading-id", loadname);
    var count = $("#" + eleid).find("tr").eq(0).find("td").length;
    $this.find("tbody").empty();
    var tr = $("<tr></tr>");
    var td = $("<td></td>").attr("colspan", count);
    var wrap = $("<div></div>").addClass("data-loading-wrap text-center");
    var span = $("<span></span>").css({ "border": "1px solid #aaa", "padding": "5px 10px", "line-height": "16px" });
    var img = $("<img />").attr("src", "/assets/images/loading.gif").addClass("icon");
    var tips = $("<span></span>").html("正在加载数据...");
    span.append(img);
    span.append(tips);
    wrap.append(span);
    td.append(wrap);
    tr.append(td);
    if ($this.get(0).tagName != "TABLE") {
        var table = $("<table></table>").attr("id", loadname);
        table.append(tr);
        $this.append(table);
    } else {
        tr.attr("id", loadname);
        $this.append(tr);
    }
}
function renderWhenNoData(eleid) {
    var loadname = eleid + "-no-data-" + new Date().valueOf();
    var $this = $("#" + eleid);
    $this.attr("data-nodata-id", loadname);
    var count = $("#" + eleid).find("tr").eq(0).find("td").length;
    $this.find("tbody").empty();
    var tr = $("<tr></tr>");
    var td = $("<td></td>").attr("colspan", count);
    var wrap = $("<div></div>").addClass("data-loading-wrap text-center");
    var span = $("<span></span>").css({ "border": "1px solid #aaa", "padding": "5px 10px", "line-height": "16px" });
    //var img = $("<img />").attr("src", "/asserts/images/loading.gif").addClass("icon");
    var tips = $("<span></span>").html("暂无数据");
    //span.append(img);
    span.append(tips);
    wrap.append(span);
    td.append(wrap);
    tr.append(td);
    if ($this.get(0).tagName != "TABLE") {
        var table = $("<table style='width:100%;'></table>").attr("id", loadname).addClass("ajax-nodata");
        table.append(tr);
        $this.append(table);
    } else {
        tr.addClass("ajax-nodata").attr("id", loadname);
        $this.append(tr);
    }
}
(function ($) {
    $.extend({
        DT: {
            init: function (opt) {
                if (!opt.pageindex) {
                    opt.pageindex = 1;
                }
                if (!opt.pagesize) {
                    opt.pagesize = 10;
                }
                opt.success = opt.success || function () { };
                this.loadData(opt);
            },

            loadData: function (opt) {
                var pageindex = opt.pageindex || 1;
                var pagesize = opt.pagesize || 10;
                var url = opt.url || "";
                var query = opt.query || {};
                var errorfunc = opt.errorfunc || alert;
                var enablePaginate = opt.enablePaginate;
                var searchData = query;
                if (enablePaginate) {
                    searchData = $.extend(query, { "pageindex": pageindex, "pagesize": pagesize });
                }
                //renderLoading(opt.eleid);
                var pModel = $.extend(opt, { loadData: this.loadData, MaxPageIndex: 1 });
                $.ajax({
                    "url": url,
                    "data": searchData,
                    "type": "POST",
                    "success": function (resp) {
                        var viewModel = new koViewModel();
                        if (resp.total && resp.total > 0) {
                            var loadingid = $("#" + opt.eleid).attr("data-loading-id");
                            $("#" + loadingid).remove();
                            if (resp.rows && resp.rows.length > 0) {
                                viewModel.Data = resp.rows;
                                ko.applyBindings(viewModel, document.getElementById(opt.eleid));
                            } else {
                                $(".ajax-nodata").remove();
                                renderWhenNoData(opt.eleid);
                            }
                            if (enablePaginate) {
                                var maxPageIndex = parseInt(resp.total / pagesize);
                                if (resp.total % pagesize) {
                                    maxPageIndex++;
                                }
                                pModel.MaxPageIndex = maxPageIndex;
                                renderPage(pModel);
                            }
                        } else {
                            var loadingid = $("#" + opt.eleid).attr("data-loading-id");
                            $("#" + loadingid).remove();
                            errorfunc("暂无数据");
                        }
                        opt.success.apply(viewModel,[resp])
                    },
                    "error": function () {
                        var loadingid = $("#" + opt.eleid).attr("data-loading-id");
                        $("#" + loadingid).remove();
                        errorfunc("连接服务器失败");
                    }
                })
            }
        }
    });
})(jQuery);