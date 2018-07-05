; (function ($) {
    $.fn.extend({
        spin: function (opt) {
            if ($(this).get(0).tagName != 'BUTTON') {
                return;
            }
            var text = $(this).text();
            var htm_i = $(this).find("i");
            if (htm_i && htm_i.length > 0) {
                var backup = htm_i.get(0).className;
                if (backup != "icon icon-spinner icon-spin") {
                    $(this).attr("data-backup", backup);
                    console.log(backup);
                }
            }
            var spinner = "<i class='icon icon-spinner icon-spin'></i> " + text;
            if (opt) {
                if (typeof (opt) == "string") {
                    if (opt == "clear" || opt == "hide") {
                        var bak = $(this).attr("data-backup");
                        if (bak && bak.length > 0) {
                            text = "<i class='" + bak + "'></i> " + text;
                        }
                        $(this).removeAttr("disabled");
                        $(this).html(text);
                    } else {
                        $(this).attr("disabled", "disabled");
                        $(this).html(spinner);
                    }
                } else {
                    var show = opt.show || true;
                    if (show === true) {
                        $(this).attr("disabled", "disabled");
                    } else {
                        $(this).removeAttr("disabled");
                    }
                    $(this).html(show ? spinner : text);
                }
            } else {
                $(this).attr("disabled", "disabled");
                $(this).html(spinner);
            }

        },
    });
})(jQuery);