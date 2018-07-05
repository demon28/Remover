(function ($) {
    'use strict';

    $.jqPaginator = function (el, options) {
        if (!(this instanceof $.jqPaginator)) {
            return new $.jqPaginator(el, options);
        }

        var self = this;

        self.viewModel;

        self.$container = $(el);

        self.$container.data('jqPaginator', self);

        self.init = function () {
            if (options.first || options.prev || options.next || options.last || options.page) {
                options = $.extend({}, {
                    first: '',
                    prev: '',
                    next: '',
                    last: '',
                    page: ''
                }, options);
            }

            self.options = $.extend({}, $.jqPaginator.defaultOptions, options);


            //ko模板绑定
            if (self.viewModel == null) {
                self.viewModel = new koViewModel([]);
                if (self.options.eleid == "") {
                    ko.applyBindings(self.viewModel);
                } else {
                    ko.cleanNode(document.getElementById(self.options.eleid));
                    ko.applyBindings(self.viewModel, document.getElementById(self.options.eleid));
                }
            }

            self.verify();

            self.extendJquery();

            self.render();

            self.fireEvent(this.options.currentPage, 'init');


        };

        self.verify = function () {
            var opts = self.options;

            if (!self.isNumber(opts.totalPages)) {
                throw new Error('[jqPaginator] type error: totalPages');
            }

            if (!self.isNumber(opts.totalCounts)) {
                throw new Error('[jqPaginator] type error: totalCounts');
            }

            if (!self.isNumber(opts.pageSize)) {
                throw new Error('[jqPaginator] type error: pageSize');
            }

            if (!self.isNumber(opts.currentPage)) {
                throw new Error('[jqPaginator] type error: currentPage');
            }

            if (!self.isNumber(opts.visiblePages)) {
                throw new Error('[jqPaginator] type error: visiblePages');
            }

            if (!opts.totalPages && !opts.totalCounts) {
                throw new Error('[jqPaginator] totalCounts or totalPages is required');
            }

            if (!opts.totalPages && !opts.totalCounts) {
                throw new Error('[jqPaginator] totalCounts or totalPages is required');
            }

            if (!opts.totalPages && opts.totalCounts && !opts.pageSize) {
                throw new Error('[jqPaginator] pageSize is required');
            }

            if (opts.totalCounts && opts.pageSize) {
                opts.totalPages = Math.ceil(opts.totalCounts / opts.pageSize);
            }

            if (opts.currentPage < 1 || opts.currentPage > opts.totalPages) {
                throw new Error('[jqPaginator] currentPage is incorrect');
            }

            if (opts.totalPages < 1) {
                throw new Error('[jqPaginator] totalPages cannot be less currentPage');
            }
        };

        self.extendJquery = function () {
            $.fn.jqPaginatorHTML = function (s) {
                return s ? this.before(s).remove() : $('<p>').append(this.eq(0).clone()).html();
            };
        };

        self.render = function () {
            self.renderHtml();
            self.setStatus();
            self.bindEvents();
        };

        self.renderHtml = function () {
            var html = [];

            var pages = self.getPages();
            for (var i = 0, j = pages.length; i < j; i++) {
                html.push(self.buildItem('page', pages[i]));
            }

            self.isEnable('prev') && html.unshift(self.buildItem('prev', self.options.currentPage - 1));
            self.isEnable('first') && html.unshift(self.buildItem('first', 1));
            self.isEnable('statistics') && html.unshift(self.buildItem('statistics'));
            self.isEnable('next') && html.push(self.buildItem('next', self.options.currentPage + 1));
            self.isEnable('last') && html.push(self.buildItem('last', self.options.totalPages));
            self.isEnable('totalPagesText') && html.push(self.buildItem('totalPagesText', self.options.totalPages));
            self.isEnable('totalCountsText') && html.push(self.buildItem('totalCountsText', self.options.totalCounts));
            if (self.options.wrapper) {
                self.$container.html($(self.options.wrapper).html(html.join('')).jqPaginatorHTML());
            } else {
                self.$container.html(html.join(''));
            }
        };

        self.buildItem = function (type, pageData) {
            var html = self.options[type]
                .replace(/{{page}}/g, pageData)
                .replace(/{{totalPages}}/g, self.options.totalPages)
                .replace(/{{totalCounts}}/g, self.options.totalCounts);

            return $(html).attr({
                'jp-role': type,
                'jp-data': pageData
            }).jqPaginatorHTML();
        };

        self.setStatus = function () {
            var options = self.options;

            if (!self.isEnable('first') || options.currentPage === 1) {
                $('[jp-role=first]', self.$container).addClass(options.disableClass);
            }
            if (!self.isEnable('prev') || options.currentPage === 1) {
                $('[jp-role=prev]', self.$container).addClass(options.disableClass);
            }
            if (!self.isEnable('next') || options.currentPage >= options.totalPages) {
                $('[jp-role=next]', self.$container).addClass(options.disableClass);
            }
            if (!self.isEnable('last') || options.currentPage >= options.totalPages) {
                $('[jp-role=last]', self.$container).addClass(options.disableClass);
            }

            $('[jp-role=page]', self.$container).removeClass(options.activeClass);
            $('[jp-role=page][jp-data=' + options.currentPage + ']', self.$container).addClass(options.activeClass);
        };

        self.getPages = function () {
            var pages = [],
                visiblePages = self.options.visiblePages,
                currentPage = self.options.currentPage,
                totalPages = self.options.totalPages;

            if (visiblePages > totalPages) {
                visiblePages = totalPages;
            }

            var half = Math.floor(visiblePages / 2);
            var start = currentPage - half + 1 - visiblePages % 2;
            var end = currentPage + half;

            if (start < 1) {
                start = 1;
                end = visiblePages;
            }
            if (end > totalPages) {
                end = totalPages;
                start = 1 + totalPages - visiblePages;
            }

            var itPage = start;
            while (itPage <= end) {
                pages.push(itPage);
                itPage++;
            }

            return pages;
        };

        self.isNumber = function (value) {
            var type = typeof value;
            return type === 'number' || type === 'undefined';
        };

        self.isEnable = function (type) {
            return self.options[type] && typeof self.options[type] === 'string';
        };

        self.switchPage = function (pageIndex) {
            self.options.currentPage = pageIndex;
            self.render();
        };

        self.fireEvent = function (pageIndex, type) {
            self.ajax(pageIndex);
            return true;
            //return (typeof self.options.onPageChange !== 'function') || (self.options.onPageChange(pageIndex, type) !== false);
        };

        self.callMethod = function (method, options) {
            switch (method) {
                case 'option':
                    self.options = $.extend({}, self.options, options);
                    self.verify();
                    self.render();
                    break;
                case 'destroy':
                    self.$container.empty();
                    self.$container.removeData('jqPaginator');
                    break;
                case 'refresh':
                    {
                        self.fireEvent(self.options.currentPage, 'init');
                        break;
                    }
                case 'reload':
                    {
                        self.options.currentPage = 1;
                        self.fireEvent(self.options.currentPage, 'init');
                        break;
                    }
                default:
                    throw new Error('[jqPaginator] method "' + method + '" does not exist');
            }

            return self.$container;
        };

        self.bindEvents = function () {
            var opts = self.options;

            self.$container.off();
            self.$container.on('click', '[jp-role]', function () {
                var $el = $(this);
                if ($el.hasClass(opts.disableClass) || $el.hasClass(opts.activeClass)) {
                    return;
                }

                var pageIndex = +$el.attr('jp-data');
                if (self.fireEvent(pageIndex, 'change')) {
                    self.switchPage(pageIndex);
                }
            });
        };

        self.ajax = function (pageIndex) {
            //查询条件
            var para = {
                pageSize: self.options.pageSize,
                pageIndex: pageIndex
            };
            //外面条件
            if (self.options.getData != undefined) {
                var temp = self.options.getData();
                para = $.extend(para, temp);
            }


            $.ajax({
                "url": self.options.url,
                "data": para,
                "type": self.options.ajaxType,
                dataType: "json",
                "success": function (result) {
                    if (!result.Success) {
                        alert(result.Message);
                        return false;
                    }
                    self.viewModel.Data(result.Content.Data);
                    if (result.Content.Data.length <= 0) {
                        $(self.options.tip).show();
                    } else {
                        $(self.options.tip).hide();
                    }

                    //提示消息
                    self.showTip(result.Content.Data.length <= 0, "没有找到相关数据，请检查是否条件输入有误！");

                    self.$container.jqPaginator('option', {
                        currentPage: result.Content.PageIndex,
                        totalCounts: result.Content.Count
                    });
                },
                "error": function (error) {
                    alert("请求数据出现系统繁忙，请稍后再试！{代码：" + error.status + "  消息：" + error.statusText + "}");
                }
            });
        };
        self.showTip = function (show, msg) {
            if (show) {
                $(self.options.tip).html('<strong>系统提示!</strong>' + msg + '').show();
            } else {
                $(self.options.tip).hide();
            }
        }
        self.init();

        return self.$container;
    };

    $.jqPaginator.defaultOptions = {
        url: "",
        ajaxType: "POST",
        wrapper: '',
        first: '<li class="first"><a href="javascript:;">首页</a></li>',
        prev: '<li class="prev"><a href="javascript:;">上一页</a></li>',
        next: '<li class="next"><a href="javascript:;">下一页</a></li>',
        last: '<li class="last"><a href="javascript:;">尾页</a></li>',
        page: '<li class="page"><a href="javascript:;">{{page}}</a></li>',
        totalPagesText: '<li class="disabled"><a href="javascript:;">共{{totalPages}}页</a></li>',
        totalCountsText: '<li class="disabled"><a href="javascript:;">共{{totalCounts}}条</a></li>',
        tip: 'view-tip',
        totalPages: 0,
        totalCounts: 0,
        pageSize: 0,
        currentPage: 1,
        visiblePages: 7,
        disableClass: 'disabled',
        activeClass: 'active',
        eleid: "",
        onPageChange: null,
        getData: null
    };

    $.fn.jqPaginator = function () {
        var self = this,
            args = Array.prototype.slice.call(arguments);

        if (typeof args[0] === 'string') {
            var $instance = $(self).data('jqPaginator');
            if (!$instance) {
                throw new Error('[jqPaginator] the element is not instantiated');
            } else {
                return $instance.callMethod(args[0], args[1]);
            }
        } else {
            return new $.jqPaginator(this, args[0]);
        }
    };

})(jQuery);

function koViewModel(data) {
    var self = this;
    self.Data = ko.observableArray(data);
}