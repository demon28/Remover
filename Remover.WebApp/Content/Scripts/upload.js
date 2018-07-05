(function ($) {
    'use strict';

    $.uploadFile = function (el, options) {
        if (!(this instanceof $.uploadFile)) {
            return new $.uploadFile(el, options);
        }

        var self = this;

        self.$container = $(el);
        self.$container.data('uploadFile', self);

        self.init = function () {
            //参数
            self.options = $.extend({}, $.uploadFile.defaultOptions, options);

            self.bindEvent();
        };

        self.bindEvent = function () {
            $(el.selector).click(function () {
                self.showWin();
            });
        }

        self.showWin = function () {
            var thumbnailValue = "";
            for (var i = 0; i < self.options.thumbnail.length; i++) {
                var item = self.options.thumbnail[i];
                if (i == 0) {
                    thumbnailValue = item.width + "x" + item.height;
                } else {
                    thumbnailValue += "-" + item.width + "x" + item.height;
                }
            }
            var model = {
                Width: self.options.imgWidth,
                Height: self.options.imgHeight,
                ThumbnailValue: thumbnailValue,
                FileUsePlace: self.options.fileUsePlace,
            };
            wui.win.show({
                url: "/upload/image?" + $.param(model),
                title: "上传图片",
                width: 700,
                height: 500,
                icoClass: "glyphicon glyphicon-open",
                callback: function (result) {
                    options.callback(result);
                }
            });
        }

        self.callMethod = function (method, options) {
            switch (method) {
                case 'option':
                    self.options = $.extend({}, self.options, options);
                    self.verify();
                    self.render();
                    break;
                default:
                    throw new Error('[uploadFile] 没有 "' + method + '" 方法');
            }

            return self.$container;
        };

        self.init();

        return self.$container;
    };

    $.uploadFile.defaultOptions = {
        imgWidth: 300,
        imgHeight: 400,
        fileUsePlace:0,
        thumbnail: [{ width: 220, height: 220 }],
        callback: function () { }
    };

    $.fn.uploadFile = function () {
        var self = this,
            args = Array.prototype.slice.call(arguments);

        if (typeof args[0] === 'string') {
            var $instance = $(self).data('uploadFile');
            if (!$instance) {
                throw new Error('[uploadFile] 未实例化');
            } else {
                return $instance.callMethod(args[0], args[1]);
            }
        } else {
            return new $.uploadFile(this, args[0]);
        }
    };

})(jQuery);