(
    function(a) {
    
        function d(e) {
            var c = a.data(e, "accordion").options,
            d = a.data(e, "accordion").panels,
            b = a(e);

            if (c.fit == true) {
                var j = b.parent();
                c.width = j.width();
                c.height = j.height()
            }

            c.width > 0 && b.width(a.boxModel == true ? c.width - (b.outerWidth() - b.width()) : c.width);

            var k = "auto";

            if (c.height > 0) {
                b.height(a.boxModel == true ? c.height - (b.outerHeight() - b.height()) : c.height);
                var f = d[0].panel("header").css("height", null).outerHeight(),
                k = b.height() - (d.length - 1) * f
            }

            for (var h = 0; h < d.length; h++) {
                var i = d[h],
                 g = i.panel("header");

                g.height(a.boxModel == true ? f - (g.outerHeight() - g.height()) : f);

                i.panel("resize", {
                // width: b.width(), height: k
                    width: b.width(), height: "auto"
                })

            }

        }


        function b(e) {
            for (var c = a.data(e, "accordion").panels, b = 0; b < c.length; b++) {
                var d = c[b];
                if (d.panel("options").collapsed == false) return d
            }

            return null
        }

        function e(e) {
            var c = a(e);
            c.addClass("accordion");
            if (c.attr("border") == "false") {
                c.addClass("accordion-noborder");
            }
            else {
                c.removeClass("accordion-noborder");
            }

            var f = [];
            c.find(">div[selected=true]").length == 0 && c.find(">div:first").attr("selected", "true");
            c.find(">div").each(
                                    function() {
                                                var c = a(this);
                                                f.push(c);
                                                c.panel(
                                                            {
                                                                collapsible: true,
                                                                minimizable: false,
                                                                maximizable: false,
                                                                closable: false,
                                                                doSize: false,
                                                                collapsed: c.attr("selected") != "true",
                                                                onBeforeExpand: function() {
                                                                                                var d = b(e);
                                                                                                if (d) {
                                                                                                        var f = a(d).panel("header");
                                                                                                        f.removeClass("accordion-header-selected");
                                                                                                        f.find(".panel-tool-collapse").triggerHandler("click")
                                                                                                       }
                                                                                                 c.panel("header").addClass("accordion-header-selected")
                                                                                            },
                                                               onExpand: function() {
                                                                                        a.parser && a.parser.parse(c.panel("body"));
                                                                                        c.panel("body").find(">div").triggerHandler("_resize")
                                                                                    },
                                                               onBeforeCollapse: function() {
                                                                                                c.panel("header").removeClass("accordion-header-selected")
                                                                                            }
                                                          }
                                                      );
                                                c.panel("body").addClass("accordion-body");
                                                c.panel("header").addClass("accordion-header").click(
                                                          function() {
                                                                           a(this).find(".panel-tool-collapse").triggerHandler("click");
                                                                           return false
                                                                      }
                                                            )
                                             }
                             );

            c.bind("_resize", function() {
                    var b = a.data(e, "accordion").options;
                    b.fit == true && d(e);
                    return false
                });

           return { accordion: c, panels: f }

       }


        function c(d, f) {
                          var g = a.data(d, "accordion").panels, c = b(d);
                          if (c && h(c) == f) return;

                          for (var e = 0; e < g.length; e++) {
                              var i = g[e];
                              if (h(i) == f) {
                                                a(i).panel("header").triggerHandler("click"); return
                                            }
                           }

                          c = b(d);
                          c.panel("header").addClass("accordion-header-selected");
                          function h(b) {
                                            return a(b).panel("options").title
                                        }
                      }

         a.fn.accordion = function(b, f) {
                                            if (typeof b == "string")
                                            switch (b) {
                                                case "select": return this.each(
                                                                                function() {
                                                                                                c(this, f)
                                                                                            }
                                                                               )
                                                        }
                                            b = b || {};

                                            return this.each(
                                                                function() {
                                                                            var h = a.data(this, "accordion"), g;
                                                                            if (h) {
                                                                                        g = a.extend(h.options, b); h.opts = g
                                                                                   }
                                                                              else {
                                                                                       var f = a(this);
                                                                                       g = a.extend(
                                                                                                       {},
                                                                                                       a.fn.accordion.defaults,
                                                                                                       {
                                                                                                           width: parseInt(f.css("width")) || undefined,
                                                                                                           height: parseInt(f.css("height")) || undefined,
                                                                                                           fit: f.attr("fit") ? f.attr("fit") == "true" : undefined,
                                                                                                           border: f.attr("border") ? f.attr("border") == "true" : undefined
                                                                                                       }, 
                                                                                                       b
                                                                                                    );

                                                                                       var i = e(this);
                                                                                       a.data(
                                                                                                this, 
                                                                                                "accordion",
                                                                                                {
                                                                                                    options: g,
                                                                                                    accordion: i.accordion,
                                                                                                    panels: i.panels
                                                                                                }
                                                                                              )
                                                                                  }
                                                                          d(this);
                                                                          c(this)
                                                                      }
                                                          )
                                             }; 
       a.fn.accordion.defaults = { width: "auto", height: "auto", fit: false, border: true }
   })(jQuery);


(
   function(a) {
                function c(e) {
                                var c = a.data(e, "calendar").options, 
                                b = a(e);
                                if (c.fit == true) {
                                    var g = b.parent();
                                    c.width = g.width();
                                    c.height = g.height()
                                }
                                var h = b.find(".calendar-header");
                                if (a.boxModel == true) {
                                    b.width(c.width - (b.outerWidth() - b.width()));
                                    b.height(c.height - (b.outerHeight() - b.height()))
                                }
                                else {
                                    b.width(c.width);
                                    b.height(c.height)
                                }

                                var d = b.find(".calendar-body"),
                                f = b.height() - h.outerHeight();
                                if (a.boxModel == true)
                                    d.height(f - (d.outerHeight() - d.height()));
                                else d.height(f)
                            }

              function f(b) {
                  a(b).addClass("calendar").wrapInner('<div class="calendar-header"><div class="calendar-prevmonth"></div><div class="calendar-nextmonth"></div><div class="calendar-prevyear"></div><div class="calendar-nextyear"></div><div class="calendar-title"><span>Aprial 2010</span></div></div><div class="calendar-body"><div class="calendar-menu"><div class="calendar-menu-year-inner"><span class="calendar-menu-prev"></span><span><input class="calendar-menu-year" type="text"></input></span><span class="calendar-menu-next"></span></div><div class="calendar-menu-month-inner"></div></div></div>');
                  a(b).find(".calendar-title span").hover(
                                                            function() {
                                                                            a(this).addClass("calendar-menu-hover")
                                                                        },
                                                            function() {
                                                                        a(this).removeClass("calendar-menu-hover")
                                                                    }
                                                          ).click(
                                                                    function() {
                                                                                    var c = a(b).find(".calendar-menu");
                                                                                    if (c.is(":visible")) c.hide(); else g(b)
                                                                                }
                                                          );
                 a(".calendar-prevmonth,.calendar-nextmonth,.calendar-prevyear,.calendar-nextyear", b).hover(
                        function() {
                                        a(this).addClass("calendar-nav-hover")
                                    },
                        function() {
                                       a(this).removeClass("calendar-nav-hover")
                                   }
                        );
                                   a(b).find(".calendar-nextmonth").click(function() { d(b, 1) }); a(b).find(".calendar-prevmonth").click(function() { d(b, -1) }); a(b).find(".calendar-nextyear").click(function() { e(b, 1) }); a(b).find(".calendar-prevyear").click(function() { e(b, -1) }); a(b).bind("_resize", function() { var d = a.data(b, "calendar").options; d.fit == true && c(b); return false })
                               }
                               function d(d, f) {
                                   var c = a.data(d, "calendar").options;
                                   c.month += f;
                                   if (c.month > 12) { c.year++; c.month = 1 }
                                   else if (c.month < 1) { c.year--; c.month = 12 } b(d);
                                   var e = a(d).find(".calendar-menu-month-inner");
                                   e.find("td.calendar-selected").removeClass("calendar-selected");
                                   e.find("td:eq(" + (c.month - 1) + ")").addClass("calendar-selected")
                               }
                               function e(c, e) {
                                   var d = a.data(c, "calendar").options;
                                   d.year += e;
                                   b(c);
                                   var f = a(c).find(".calendar-menu-year");
                                   f.val(d.year)
                               }
                               function g(c) {
                                   var f = a.data(c, "calendar").options;
                                   a(c).find(".calendar-menu").show();
                                   if (a(c).find(".calendar-menu-month-inner").is(":empty")) {
                                       a(c).find(".calendar-menu-month-inner").empty();
                                       for (var n = a("<table></table>").appendTo(a(c).find(".calendar-menu-month-inner")), i = 0, k = 0; k < 3; k++)
                                           for (var m = a("<tr></tr>").appendTo(n), l = 0; l < 4; l++)
                                               a('<td class="calendar-menu-month"></td>').html(f.months[i++]).attr("abbr", i).appendTo(m);
                                           a(c).find(".calendar-menu-prev,.calendar-menu-next").hover(function() { a(this).addClass("calendar-menu-hover") },
                                function() { a(this).removeClass("calendar-menu-hover") });
                                           a(c).find(".calendar-menu-next").click(function() {
                                               var b = a(c).find(".calendar-menu-year");
                                               !isNaN(b.val()) && b.val(parseInt(b.val()) + 1)
                                           });
                                           a(c).find(".calendar-menu-prev").click(function() {
                                           var b = a(c).find(".calendar-menu-year");
                                           !isNaN(b.val()) && b.val(parseInt(b.val() - 1))
                                       });
                                       a(c).find(".calendar-menu-year").keypress(function(a) { a.keyCode == 13 && j() });
                                       a(c).find(".calendar-menu-month").hover(function() { a(this).addClass("calendar-menu-hover") },
                                function() { a(this).removeClass("calendar-menu-hover") }).click(function() {
                                       var b = a(c).find(".calendar-menu");
                                       b.find(".calendar-selected").removeClass("calendar-selected");
                                       a(this).addClass("calendar-selected"); 
                                       j()
                                   })
                               }
                               function j() {
                                   var d = a(c).find(".calendar-menu"),
                                e = d.find(".calendar-menu-year").val(),
                                g = d.find(".calendar-selected").attr("abbr");
                                   if (!isNaN(e)) {
                                       f.year = parseInt(e);
                                       f.month = parseInt(g); b(c)
                                   } d.hide()
                               }
                               var g = a(c).find(".calendar-body"),
                                 d = a(c).find(".calendar-menu"),
                                 h = d.find(".calendar-menu-year-inner"),
                                  e = d.find(".calendar-menu-month-inner");
                               h.find("input").val(f.year).focus();
                               e.find("td.calendar-selected").removeClass("calendar-selected");
                               e.find("td:eq(" + (f.month - 1) + ")").addClass("calendar-selected");
                               if (a.boxModel == true) {
                                   d.width(g.outerWidth() - (d.outerWidth() - d.width()));
                                   d.height(g.outerHeight() - (d.outerHeight() - d.height()));
                                   e.height(d.height() - (e.outerHeight() - e.height()) - h.outerHeight())
                               }
                               else {
                                   d.width(g.outerWidth());
                                   d.height(g.outerHeight());
                                   e.height(d.height() - h.outerHeight())
                               } 
                           }
                           function h(j, k) {
                               for (var i = [], l = (new Date(j, k, 0)).getDate(),
                                    d = 1; d <= l; 
                                    d++) i.push([j, k, d]);
                                    var b = [],
                                    c = [];
                                while (i.length > 0) {
                                   var a = i.shift();
                                   c.push(a);
                                   if ((new Date(a[0], a[1] - 1, a[2])).getDay() == 6) {
                                       b.push(c); c = []
                                   } 
                               }
                               c.length && b.push(c);
                               var h = b[0];
                               if (h.length < 7) while (h.length < 7) {
                                   var e = h[0],
                                    a = new Date(e[0], e[1] - 1, e[2] - 1);
                                   h.unshift([a.getFullYear(), a.getMonth() + 1, a.getDate()])
                               }
                               else {
                                   for (var e = h[0], c = [], d = 1; d <= 7; d++) {
                                       var a = new Date(e[0], e[1] - 1, e[2] - d);
                                       c.unshift([a.getFullYear(), a.getMonth() + 1, a.getDate()])
                                   } b.unshift(c)
                               }
                               var f = b[b.length - 1]; while (f.length < 7) {
                                   var g = f[f.length - 1],
                                    a = new Date(g[0], g[1] - 1, g[2] + 1);
                                   f.push([a.getFullYear(), a.getMonth() + 1, a.getDate()])
                               }
                               if (b.length < 6) {
                                   for (var g = f[f.length - 1], c = [], d = 1; d <= 7; d++) {
                                       var a = new Date(g[0],
                                       g[1] - 1,
                                        g[2] + d);
                                       c.push([a.getFullYear(), a.getMonth() + 1, a.getDate()])
                                   } b.push(c)
                               } return b
                           } 
                                    function b(f) {
                                        var b = a.data(f, "calendar").options;
                                        a(f).find(".calendar-title span").html(b.months[b.month - 1] + " " + b.year);
                                        var j = a(f).find("div.calendar-body");
                                        j.find(">table").remove();
                                        for (var c = a('<table cellspacing="0" cellpadding="0" border="0"><thead></thead><tbody></tbody></table>').prependTo(j),
                                   m = a("<tr></tr>").appendTo(c.find("thead")), 
                                   d = 0; d < b.weeks.length; d++) m.append("<th>" + b.weeks[d] + "</th>");
                                        for (var k = h(b.year, b.month), d = 0; d < k.length; d++)
                                            for (var l = k[d], m = a("<tr></tr>").appendTo(c.find("tbody")),
                                i = 0; i < l.length; i++) {
                                                    var e = l[i];
                                                    a('<td class="calendar-day calendar-other-month"></td>').attr("abbr", e[0] + "," + e[1] + "," + e[2]).html(e[2]).appendTo(m)
                                                }
                                                c.find("td[abbr^=" + b.year + "," + b.month + "]").removeClass("calendar-other-month");
                                                var g = new Date, 
                                                n = g.getFullYear() + "," + (g.getMonth() + 1) + "," + g.getDate();
                                                c.find("td[abbr=" + n + "]").addClass("calendar-today");
                                                if (b.current) {
                                                    c.find(".calendar-selected").removeClass("calendar-selected");
                                                    var o = b.current.getFullYear() + "," + (b.current.getMonth() + 1) + "," + b.current.getDate();
                                                    c.find("td[abbr=" + o + "]").addClass("calendar-selected")
                                                }
                                                c.find("tr").find("td:first").addClass("calendar-sunday");
                                                c.find("tr").find("td:last").addClass("calendar-saturday");
                                                c.find("td").hover(function() { a(this).addClass("calendar-hover") },
                                  function() { a(this).removeClass("calendar-hover") }).click(function() {
                                                c.find(".calendar-selected").removeClass("calendar-selected");
                                                a(this).addClass("calendar-selected");
                                                var d = a(this).attr("abbr").split(",");
                                                b.current = new Date(d[0], parseInt(d[1]) - 1, d[2]);
                                                b.onSelect.call(f, b.current)
                                            })
                                        }
                                        a.fn.calendar = function(d) {
                                            d = d || {};
                                            return this.each(function() {
                                                var g = a.data(this, "calendar");
                                                if (g) a.extend(g.options, d);
                                                else {
                                                    var e = a(this);
                                                    g = a.data(this,
                                   "calendar",
                                   { options: a.extend({},
                                   a.fn.calendar.defaults, {
                                       width: parseInt(e.css("width")) || undefined,
                                       height: parseInt(e.css("height")) || undefined,
                                       fit: e.attr("fit") ? e.attr("fit") == "true" : undefined,
                                       border: e.attr("border") ? e.attr("border") == "true" : undefined
                                   }, d)
                               });
                               f(this)
                           }
                           g.options.border == false && a(this).addClass("calendar-noborder");
                           c(this);
                           b(this);
                           a(this).find("div.calendar-menu").hide()
                       })
                   };
                   a.fn.calendar.defaults = { width: 180, height: 180, fit: false, border: true,
                   weeks: ["S", "M", "T", "W", "T", "F", "S"],
                   months: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                   year: (new Date).getFullYear(),
                   month: (new Date).getMonth() + 1, 
                   current: new Date,
                   onSelect: function() { } 
               }
                            })(jQuery); (function(a) {
                            function j(e) { var b = a.data(e, "combobox").options, c = a.data(e, "combobox").combobox, d = a.data(e, "combobox").content; if (isNaN(b.width)) b.width = c.find("input.combobox-text").outerWidth(); var f = c.find(".combobox-arrow").outerWidth(), g = b.width - f - (c.outerWidth() - c.width()); c.find("input.combobox-text").width(g); if (b.listWidth) d.width(b.listWidth); else d.width(a.boxModel == true ? c.outerWidth() - (d.outerWidth() - d.width()) : c.outerWidth()); b.listHeight && d.height(b.listHeight) } function k(c) { a(c).hide(); var b = a('<span class="combobox"></span>').insertAfter(c); a('<input type="hidden" class="combobox-value"></input>').appendTo(b); var e = a('<input type="text" class="combobox-text"></input>').appendTo(b); a('<span><span class="combobox-arrow"></span></span>').appendTo(b); var f = a('<div class="combobox-content"></div>').appendTo("body"), d = a(c).attr("name"); if (d) { b.find("input.combobox-value").attr("name", d); a(c).removeAttr("name").attr("comboboxName", d) } e.attr("autocomplete", "off"); return { combobox: b, content: f} } function b(b) { var h = a.data(b, "combobox").options, f = a.data(b, "combobox").combobox, d = a.data(b, "combobox").content, e = f.find(".combobox-text"), g = f.find(".combobox-arrow"); a(document).unbind(".combobox"); d.unbind(".combobox"); e.unbind(".combobox"); g.unbind(".combobox"); if (!h.disabled) { a(document).bind("mousedown.combobox", function() { a(".combobox-content").hide() }); d.bind("mousedown.combobox", function() { return false }); e.bind("focus.combobox", function() { i(b, "") }).bind("keyup.combobox", function(h) { var e = d.find("div.combobox-item-selected"); switch (h.keyCode) { case 38: var f = e.prev(); if (f.length) { e.removeClass("combobox-item-selected"); f.addClass("combobox-item-selected") } break; case 40: var g = e.next(); if (g.length) { e.removeClass("combobox-item-selected"); g.addClass("combobox-item-selected") } break; case 13: c(b, e.attr("value")); d.hide(); break; case 27: d.hide(); break; default: i(b, a(this).val()) } return false }); g.bind("click.combobox", function() { e.focus() }).bind("mouseenter.combobox", function() { a(this).addClass("combobox-arrow-hover") }).bind("mouseleave.combobox", function() { a(this).removeClass("combobox-arrow-hover") }) } } function c(b, f) { var i = a.data(b, "combobox").data, c = a.data(b, "combobox").options, g = a.data(b, "combobox").combobox, j = a.data(b, "combobox").content; j.find("div.combobox-item-selected").removeClass("combobox-item-selected"); for (var h = 0; h < i.length; h++) { var e = i[h]; if (e[c.valueField] == f) { var k = g.find("input.combobox-value").val(); g.find("input.combobox-value").val(e[c.valueField]); g.find("input.combobox-text").val(e[c.textField]); j.find("div.combobox-item[value=" + f + "]").addClass("combobox-item-selected"); c.onSelect.call(b, e); k != f && c.onChange.call(b, f, k); d(b, true); return } } } function f(c, f) { var h = a.data(c, "combobox").combobox, e = a.data(c, "combobox").options, i = a.data(c, "combobox").data, b, j, k = h.find("input.combobox-value").val(); if (typeof f == "object") { b = f[e.valueField]; j = f[e.textField] } else { b = f; for (var g = 0; g < i.length; g++) if (i[g][e.valueField] == b) { j = i[g][e.textField]; break } } h.find("input.combobox-value").val(b); h.find("input.combobox-text").val(j); d(c, true); k != b && e.onChange.call(c, b, k) } function l(b) { var c = a.data(b, "combobox").combobox; return c.find("input.combobox-value").val() } function m(b) {
                                var c = a.data(b, "combobox").options, d = []; a(">option", b).each(function() {
                                    var b = {}; b[c.valueField] = a(this).attr("value") || a(this).html(); b[c.textField] = a(this).html(); 
                            b.selected = a(this).attr("selected"); d.push(b) }); return d } function g(e, b) { a.data(e, "combobox").data = b; var i = a.data(e, "combobox").options, g = a.data(e, "combobox").content, h = null; g.empty(); for (var d = 0; d < b.length; d++) { var j = a('<div class="combobox-item"></div>').appendTo(g); j.attr("value", b[d][i.valueField]); j.html(b[d][i.textField]); if (b[d].selected) h = b[d] } h && f(e, h); a(".combobox-item", g).hover(function() { a(this).addClass("combobox-item-hover") }, function() { a(this).removeClass("combobox-item-hover") }).click(function() { g.hide(); c(e, a(this).attr("value")) }) } function h(d, c) {
                                var b = a.data(d, "combobox").options; if (c) b.url = c; if (!b.url) return; a.ajax({ url: b.url, dataType: "json", success: function(a) { g(d, a); b.onLoadSuccess.apply(this, arguments) }, 
                                error: function() { b.onLoadError.apply(this, arguments) } }) } function i(e, d) { d = d || ""; var c = a.data(e, "combobox").combobox, b = a.data(e, "combobox").content, f = c.find("input.combobox-text").val(); b.find("div.combobox-item-selected").removeClass("combobox-item-selected"); b.find("div.combobox-item").each(function() { var b = a(this); if (b.text().indexOf(d) == 0) { b.show(); b.text() == f && b.addClass("combobox-item-selected") } else b.hide() }); b.css({ display: "block", left: c.offset().left, top: c.offset().top + c.outerHeight() }); a.fn.window && b.css("z-index", a.fn.window.defaults.zIndex++); b.find("div.combobox-item-selected").length == 0 && b.find("div.combobox-item:visible:first").addClass("combobox-item-selected") } function d(b, d) { if (a.fn.validatebox) { var e = a.data(b, "combobox").options, c = a.data(b, "combobox").combobox.find("input.combobox-text"); c.validatebox(e); d && c.validatebox("validate") } } function e(b, e) {
                                    var d = a.data(b, "combobox").options, c = a.data(b, "combobox").combobox;
                                    if (e) { d.disabled = true; a(b).attr("disabled", true); c.find(".combobox-value").attr("disabled", true); c.find(".combobox-text").attr("disabled", true) } else { d.disabled = false; a(b).removeAttr("disabled"); c.find(".combobox-value").removeAttr("disabled"); c.find(".combobox-text").removeAttr("disabled") } 
                                } a.fn.combobox = function(i, n) { if (typeof i == "string") switch (i) { case "select": return this.each(function() { c(this, n) }); case "setValue": return this.each(function() { f(this, n) }); case "getValue": return l(this[0]); case "reload": return this.each(function() { h(this, n) }); case "disable": return this.each(function() { e(this, true); b(this) }); case "enable": return this.each(function() { e(this, false); b(this) }) } i = i || {}; return this.each(function() { var f = a.data(this, "combobox"); if (f) a.extend(f.options, i); else { var l = k(this), c = a(this); f = a.data(this, "combobox", { options: a.extend({}, a.fn.combobox.defaults, { width: parseInt(c.css("width")) || undefined, listWidth: c.attr("listWidth"), listHeight: c.attr("listHeight"), valueField: c.attr("valueField"), textField: c.attr("textField"), editable: c.attr("editable") ? c.attr("editable") == "true" : undefined, disabled: c.attr("disabled") ? true : undefined, url: c.attr("url"), required: c.attr("required") ? c.attr("required") == "true" || c.attr("required") == true : undefined, missingMessage: c.attr("missingMessage") || undefined }, i), combobox: l.combobox, content: l.content }); c.removeAttr("disabled"); g(this, m(this)) } a("input.combobox-text", f.combobox).attr("readonly", !f.options.editable); h(this); e(this, f.options.disabled); b(this); j(this); d(this) }) }; a.fn.combobox.defaults = { width: "auto", listWidth: null, listHeight: null, valueField: "value", textField: "text", editable: true, disabled: false, url: null, required: false, missingMessage: "This field is required.", onLoadSuccess: function() { }, onLoadError: function() { }, onSelect: function() { }, onChange: function() { } }
                            })(jQuery); (function(a) {
                            function e(e) { var b = a.data(e, "combotree").options, c = a.data(e, "combotree").combotree, d = a.data(e, "combotree").content; if (isNaN(b.width)) b.width = c.find("input.combotree-text").outerWidth(); var f = c.find(".combotree-arrow").outerWidth(), g = b.width - f - (c.outerWidth() - c.width()); c.find("input.combotree-text").width(g); if (b.treeWidth) d.width(b.treeWidth); else d.width(a.boxModel == true ? c.outerWidth() - (d.outerWidth() - d.width()) : c.outerWidth()); b.treeHeight && d.height(b.treeHeight) } function f(c) { a(c).hide(); var b = a('<span class="combotree"></span>').insertAfter(c); a('<input type="hidden" class="combotree-value"></input>').appendTo(b); a('<input class="combotree-text" readonly="true"></input>').appendTo(b); a('<span><span class="combotree-arrow"></span></span>').appendTo(b); var e = a('<div class="combotree-content"><ul></ul></div>').appendTo("body"), d = a(c).attr("name"); if (d) { b.find("input.combotree-value").attr("name", d); a(c).removeAttr("name").attr("combotreeName", d) } return { combotree: b, content: e} } function b(d) { var f = a.data(d, "combotree").options, b = a.data(d, "combotree").combotree, c = a.data(d, "combotree").content, e = b.find(".combotree-arrow"); a(document).unbind(".combotree"); b.unbind(".combotree"); c.unbind(".combotree"); e.unbind(".combotree"); if (!f.disabled) { a(document).bind("mousedown.combotree", function() { a(".combotree-content").hide() }); c.bind("mousedown.combotree", function() { return false }); b.bind("click.combotree", function() { g(); return false }); e.bind("mouseenter.combotree", function() { a(this).addClass("combotree-arrow-hover") }).bind("mouseleave.combotree", function() { a(this).removeClass("combotree-arrow-hover") }) } function g() { c.css({ display: "block", left: b.offset().left, top: b.offset().top + b.outerHeight() }); a.fn.window && c.css("z-index", a.fn.window.defaults.zIndex++) } } function g(b) { var d = a.data(b, "combotree").options, e = a.data(b, "combotree").combotree, f = a.data(b, "combotree").content; f.find(">ul").tree({ url: d.url, onClick: function(a) { if (d.onBeforeSelect.call(b, a) == false) return; var g = e.find("input.combotree-value").val(); e.find("input.combotree-value").val(a.id); e.find("input.combotree-text").val(a.text); f.hide(); c(b, true); d.onSelect.call(b, a); g != a.id && d.onChange.call(b, a.id, g) } }) } function h(d, e) { var k = a.data(d, "combotree").options, f = a.data(d, "combotree").combotree, g = a.data(d, "combotree").content.find(">ul"), b, h, j = f.find("input.combotree-value").val(); if (typeof e == "object") { b = e.id; h = e.text } else b = e; var l = g.find("div.tree-node[node-id=" + b + "]")[0]; g.tree("select", l); var i = g.tree("getSelected"); if (i) { b = i.id; h = i.text } f.find("input.combotree-value").val(b); f.find("input.combotree-text").val(h); c(d, true); j != b && k.onChange.call(d, b, j) } function i(b) { var c = a.data(b, "combotree").combotree; return c.find("input.combotree-value").val() } function j(c, b) { var d = a.data(c, "combotree").options, e = a.data(c, "combotree").content; if (b) d.url = b; e.find(">ul").tree({ url: d.url }).tree("reload") } function c(b, d) { if (a.fn.validatebox) { var e = a.data(b, "combotree").options, c = a.data(b, "combotree").combotree.find("input.combotree-text"); c.validatebox(e); d && c.validatebox("validate") } } function k(b) { var c = a.data(b, "combotree").content; return c.find(">ul.tree") } function d(b, e) {
                                var d = a.data(b, "combotree").options, c = a.data(b, "combotree").combotree; 
                                if (e) { d.disabled = true; a(b).attr("disabled", true); c.find("input.combotree-value").attr("disabled", true); c.find("input.combotree-text").attr("disabled", true) } else { d.disabled = false; a(b).removeAttr("disabled"); c.find("input.combotree-value").removeAttr("disabled"); c.find("input.combotree-text").removeAttr("disabled") } } a.fn.combotree = function(l, m) {
                                    if (typeof l == "string") switch (l) { case "tree": return k(this[0]); case "setValue": return this.each(function() { h(this, m) }); case "getValue": return i(this[0]); case "reload": return this.each(function() { j(this, m) }); case "disable": return this.each(function() { d(this, true); b(this) }); case "enable": return this.each(function() { d(this, false); b(this) }) } l = l || {}; 
                           return this.each(function() { var i = a.data(this, "combotree"); if (i) a.extend(i.options, l); else { var j = f(this), h = a(this); i = a.data(this, "combotree", { options: a.extend({}, a.fn.combotree.defaults, { width: parseInt(h.css("width")) || undefined, treeWidth: h.attr("treeWidth"), treeHeight: h.attr("treeHeight"), url: h.attr("url"), disabled: h.attr("disabled") ? true : undefined, required: h.attr("required") ? h.attr("required") == "true" || h.attr("required") == true : undefined, missingMessage: h.attr("missingMessage") || undefined }, l), combotree: j.combotree, content: j.content }); h.removeAttr("disabled") } g(this); d(this, i.options.disabled); b(this); e(this); c(this) }) }; a.fn.combotree.defaults = { width: "auto", treeWidth: null, treeHeight: 200, url: null, disabled: false, required: false, missingMessage: "This field is required.", onBeforeSelect: function() { }, onSelect: function() { }, onChange: function() { } } })(jQuery); (function(a) {
                           function c(i) { var b = a.data(i, "datagrid").grid, c = a.data(i, "datagrid").options; if (c.fit == true) { var j = b.parent(); c.width = j.width(); c.height = j.height() } (c.rownumbers || c.frozenColumns && c.frozenColumns.length > 0) && a(".datagrid-body .datagrid-cell,.datagrid-body .datagrid-cell-rownumber", b).addClass("datagrid-cell-height"); var d = c.width; if (d == "auto") if (a.boxModel == true) d = b.width(); else d = b.outerWidth(); else if (a.boxModel == true) d -= b.outerWidth() - b.width(); b.width(d); var f = d; if (a.boxModel == false) f = d - b.outerWidth() + b.width(); a(".datagrid-wrap", b).width(f); a(".datagrid-view", b).width(f); a(".datagrid-view1", b).width(a(".datagrid-view1 table", b).width()); a(".datagrid-view2", b).width(f - a(".datagrid-view1", b).outerWidth()); a(".datagrid-view1 .datagrid-header", b).width(a(".datagrid-view1", b).width()); a(".datagrid-view1 .datagrid-body", b).width(a(".datagrid-view1", b).width()); a(".datagrid-view2 .datagrid-header", b).width(a(".datagrid-view2", b).width()); a(".datagrid-view2 .datagrid-body", b).width(a(".datagrid-view2", b).width()); var e, g = a(".datagrid-view1 .datagrid-header", b), h = a(".datagrid-view2 .datagrid-header", b); g.css("height", null); h.css("height", null); if (a.boxModel == true) e = Math.max(g.height(), h.height()); else e = Math.max(g.outerHeight(), h.outerHeight()); a(".datagrid-view1 .datagrid-header table", b).height(e); a(".datagrid-view2 .datagrid-header table", b).height(e); g.height(e); h.height(e); if (c.height == "auto") a(".datagrid-body", b).height(a(".datagrid-view2 .datagrid-body table", b).height()); else a(".datagrid-body", b).height(c.height - (b.outerHeight() - b.height()) - a(".datagrid-header", b).outerHeight(true) - a(".datagrid-title", b).outerHeight(true) - a(".datagrid-toolbar", b).outerHeight(true) - a(".datagrid-pager", b).outerHeight(true)); a(".datagrid-view", b).height(a(".datagrid-view2", b).height()); a(".datagrid-view1", b).height(a(".datagrid-view2", b).height()); a(".datagrid-view2", b).css("left", a(".datagrid-view1", b).outerWidth()) } function o(b) { var e = a(b).wrap('<div class="datagrid"></div>').parent(); e.append('<div class="datagrid-wrap"><div class="datagrid-view"><div class="datagrid-view1"><div class="datagrid-header"><div class="datagrid-header-inner"></div></div><div class="datagrid-body"><div class="datagrid-body-inner"><table border="0" cellspacing="0" cellpadding="0"></table></div></div></div><div class="datagrid-view2"><div class="datagrid-header"><div class="datagrid-header-inner"></div></div><div class="datagrid-body"></div></div><div class="datagrid-resize-proxy"></div></div></div>'); var k = h(a("thead[frozen=true]", b)); a("thead[frozen=true]", b).remove(); var i = h(a("thead", b)); a("thead", b).remove(); a(b).attr({ cellspacing: 0, cellpadding: 0, border: 0 }).removeAttr("width").removeAttr("height").appendTo(a(".datagrid-view2 .datagrid-body", e)); function h(c) { var b = []; a("tr", c).each(function() { var c = []; a("th", this).each(function() { var b = a(this), d = { title: b.html(), align: b.attr("align") || "left", sortable: b.attr("sortable") == "true" || false, checkbox: b.attr("checkbox") == "true" || false }; if (b.attr("field")) d.field = b.attr("field"); if (b.attr("formatter")) d.formatter = eval(b.attr("formatter")); if (b.attr("rowspan")) d.rowspan = parseInt(b.attr("rowspan")); if (b.attr("colspan")) d.colspan = parseInt(b.attr("colspan")); if (b.attr("width")) d.width = parseInt(b.attr("width")); c.push(d) }); b.push(c) }); return b } var f = { total: 0, rows: [] }, j = g(i); a(".datagrid-view2 .datagrid-body tr", e).each(function() { f.total++; for (var c = {}, b = 0; b < j.length; b++) c[j[b]] = a("td:eq(" + b + ")", this).html(); f.rows.push(c) }); e.bind("_resize", function() { var e = a.data(b, "datagrid").options; if (e.fit == true) { c(b); d(b) } return false }); return { grid: e, frozenColumns: k, columns: i, data: f} } function m(h) {
                               for (var i = a('<table border="0" cellspacing="0" cellpadding="0"><tbody></tbody></table>'), e = 0; e < h.length; e++) for (var j = a("<tr></tr>").appendTo(a("tbody", i)), g = h[e], f = 0; f < g.length; f++) {
                                   var b = g[f], d = ""; if (b.rowspan) d += 'rowspan="' + b.rowspan + '" '; if (b.colspan) d += 'colspan="' + b.colspan + '" '; var c = a("<td " + d + "></td>").appendTo(j);
                            if (b.checkbox) { c.attr("field", b.field); a('<div class="datagrid-header-check"></div>').html('<input type="checkbox"/>').appendTo(c) } else if (b.field) { c.attr("field", b.field); c.append('<div class="datagrid-cell"><span></span><span class="datagrid-sort-icon"></span></div>'); a("span", c).html(b.title); a("span.datagrid-sort-icon", c).html("&nbsp;"); a(".datagrid-cell", c).width(b.width); a(".datagrid-cell", c).css("text-align", b.align || "left") } else a('<div class="datagrid-cell-group"></div>').html(b.title).appendTo(c) } return i } function k(h) {
                               var g = a.data(h, "datagrid").grid, k = a.data(h, "datagrid").options, m = a.data(h, "datagrid").data; if (k.striped) { a(".datagrid-view1 .datagrid-body tr:odd", g).addClass("datagrid-row-alt"); a(".datagrid-view2 .datagrid-body tr:odd", g).addClass("datagrid-row-alt") } k.nowrap == false && a(".datagrid-body .datagrid-cell", g).css("white-space", "normal"); a(".datagrid-header th:has(.datagrid-cell)", g).hover(function() { a(this).addClass("datagrid-header-over") }, function() { a(this).removeClass("datagrid-header-over") }); a(".datagrid-body tr", g).unbind(".datagrid"); a(".datagrid-body tr", g).bind("mouseover.datagrid", function() { var b = a(this).attr("datagrid-row-index"); a(".datagrid-body tr[datagrid-row-index=" + b + "]", g).addClass("datagrid-row-over") }).bind("mouseout.datagrid", function() { var b = a(this).attr("datagrid-row-index"); a(".datagrid-body tr[datagrid-row-index=" + b + "]", g).removeClass("datagrid-row-over") }).bind("click.datagrid", function() { var c = a(this).attr("datagrid-row-index"); if (k.singleSelect == true) { i(h); b(h, c) } else if (a(this).hasClass("datagrid-row-selected")) j(h, c); else b(h, c); k.onClickRow && k.onClickRow.call(this, c, m.rows[c]) }).bind("dblclick.datagrid", function() { var b = a(this).attr("datagrid-row-index"); k.onDblClickRow && k.onDblClickRow.call(this, b, m.rows[b]) }); a(".datagrid-body tr td.datagrid-column-ck input[type=checkbox]", g).unbind(".datagrid").bind("click.datagrid", function(d) { var c = a(this).parent().parent().parent().attr("datagrid-row-index"); if (a(this).attr("checked")) b(h, c); else j(h, c); d.stopPropagation() });
                               function n() { var b = a(this).parent().attr("field"), d = f(h, b); if (!d.sortable) return; k.sortName = b; k.sortOrder = "asc"; var c = "datagrid-sort-asc"; if (a(this).hasClass("datagrid-sort-asc")) { c = "datagrid-sort-desc"; k.sortOrder = "desc" } a(".datagrid-header .datagrid-cell", g).removeClass("datagrid-sort-asc"); a(".datagrid-header .datagrid-cell", g).removeClass("datagrid-sort-desc"); a(this).addClass(c); k.onSortColumn && k.onSortColumn.call(this, k.sortName, k.sortOrder); e(h) } function o() { if (a(this).attr("checked")) a(".datagrid-body tr td.datagrid-column-ck input[type=checkbox]", g).each(function() { if (!a(this).attr("checked")) { var c = a(this).parent().parent().parent().attr("datagrid-row-index"); b(h, c) } }); else i(h) } a(".datagrid-header .datagrid-cell", g).unbind(".datagrid"); a(".datagrid-header .datagrid-cell", g).bind("click.datagrid", n); a(".datagrid-header .datagrid-header-check input[type=checkbox]", g).unbind(".datagrid"); a(".datagrid-header .datagrid-header-check input[type=checkbox]", g).bind("click.datagrid", o); a(".datagrid-header .datagrid-cell", g).resizable({ handles: "e", minWidth: 50, onStartResize: function(b) { a(".datagrid-resize-proxy", g).css({ left: b.pageX - a(g).offset().left - 1 }); a(".datagrid-resize-proxy", g).css("display", "block") }, onResize: function(b) { a(".datagrid-resize-proxy", g).css({ left: b.pageX - a(g).offset().left - 1 }); return false }, onStopResize: function() { d(h, this); a(".datagrid-view2 .datagrid-header", g).scrollLeft(a(".datagrid-view2 .datagrid-body", g).scrollLeft()); a(".datagrid-resize-proxy", g).css("display", "none") } }); a(".datagrid-view1 .datagrid-header .datagrid-cell", g).resizable({ onStopResize: function() { d(h, this); a(".datagrid-view2 .datagrid-header", g).scrollLeft(a(".datagrid-view2 .datagrid-body", g).scrollLeft()); a(".datagrid-resize-proxy", g).css("display", "none"); c(h) } }); var p = a(".datagrid-view1 .datagrid-body", g), l = a(".datagrid-view2 .datagrid-body", g), q = a(".datagrid-view2 .datagrid-header", g); l.scroll(function() { q.scrollLeft(l.scrollLeft()); p.scrollTop(l.scrollTop()) })
                           } function d(b, c) { var d = a.data(b, "datagrid").grid, g = a.data(b, "datagrid").options; if (c) e(c); else a(".datagrid-header .datagrid-cell", d).each(function() { e(this) }); function e(g) { var c = a(g); if (c.width() == 0) return; var e = c.parent().attr("field"); a(".datagrid-body td.datagrid-column-" + e + " .datagrid-cell", d).each(function() { var b = a(this); if (a.boxModel == true) b.width(c.outerWidth() - b.outerWidth() + b.width()); else b.width(c.outerWidth()) }); var h = f(b, e); h.width = a.boxModel == true ? c.width() : c.outerWidth() } } function f(h, g) { var b = a.data(h, "datagrid").options; if (b.columns) for (var c = 0; c < b.columns.length; c++) for (var e = b.columns[c], d = 0; d < e.length; d++) { var f = e[d]; if (f.field == g) return f } if (b.frozenColumns) for (var c = 0; c < b.frozenColumns.length; c++) for (var e = b.frozenColumns[c], d = 0; d < e.length; d++) { var f = e[d]; if (f.field == g) return f } return null } function g(a) {
                               if (a.length == 0) return []; function e(g, d, h) { var b = []; while (b.length < h) { var c = a[g][d]; if (c.colspan && parseInt(c.colspan) > 1) { var i = e(g + 1, f(g, d), parseInt(c.colspan)); b = b.concat(i) } else c.field && b.push(c.field); d++ } return b } 
                               function f(f, e) { for (var c = 0, b = 0; b < e; b++) { var d = parseInt(a[f][b].colspan || "1"); if (d > 1) c += d } return c } for (var c = [], d = 0; d < a[0].length; d++) { var b = a[0][d]; if (b.colspan && parseInt(b.colspan) > 1) { var g = e(1, f(0, d), parseInt(b.colspan)); c = c.concat(g) } else b.field && c.push(b.field) } return c } function h(d, h) {
                                   var b = a.data(d, "datagrid").options, e = a.data(d, "datagrid").grid, l = a.data(d, "datagrid").selectedRows, j = h.rows, o = function() { if (a.boxModel == false) return 0; var b = a(".datagrid-header .datagrid-cell:first"), f = b.outerWidth() - b.width(), d = a(".datagrid-body table", e); d.append(a('<tr><td><div class="datagrid-cell"></div></td></tr>')); var c = a(".datagrid-cell", d), g = c.outerWidth() - c.width(); return f - g }, p = o(), m = b.rownumbers || b.frozenColumns && b.frozenColumns.length > 0;
                                   function n(n, r) { function s(c) { if (!b.idField) return false; for (var a = 0; a < l.length; a++) if (l[a][b.idField] == c[b.idField]) return true; return false } for (var a = ["<tbody>"], e = 0; e < j.length; e++) { var h = j[e], o = s(h); if (e % 2 && b.striped) a.push('<tr datagrid-row-index="' + e + '" class="datagrid-row-alt'); else a.push('<tr datagrid-row-index="' + e + '" class="'); o == true && a.push(" datagrid-row-selected"); a.push('">'); if (r) { var i = e + 1; if (b.pagination) i += (b.pageNumber - 1) * b.pageSize; if (m) a.push('<td><div class="datagrid-cell-rownumber datagrid-cell-height">' + i + "</div></td>"); else a.push('<td><div class="datagrid-cell-rownumber">' + i + "</div></td>") } for (var k = 0; k < n.length; k++) { var g = n[k], c = f(d, g); if (c) { var q = "width:" + (c.width + p) + "px;"; q += "text-align:" + (c.align || "left"); a.push('<td class="datagrid-column-' + g + '">'); a.push('<div style="' + q + '" '); if (c.checkbox) a.push('class="datagrid-cell-check '); else a.push('class="datagrid-cell '); m && a.push("datagrid-cell-height "); a.push('">'); if (c.checkbox) if (o) a.push('<input type="checkbox" checked="checked"/>'); else a.push('<input type="checkbox"/>'); else if (c.formatter) a.push(c.formatter(h[g], h)); else a.push(h[g]); a.push("</div>"); a.push("</td>") } } a.push("</tr>") } a.push("</tbody>"); return a.join("") } a(".datagrid-body, .datagrid-header", e).scrollLeft(0).scrollTop(0); var q = g(b.columns); a(".datagrid-view2 .datagrid-body table", e).html(n(q)); if (b.rownumbers || b.frozenColumns && b.frozenColumns.length > 0) { var r = g(b.frozenColumns); a(".datagrid-view1 .datagrid-body table", e).html(n(r, b.rownumbers)) } a.data(d, "datagrid").data = h; var i = a(".datagrid-pager", e); if (i.length) i.pagination("options").total != h.total && i.pagination({ total: h.total }); c(d); k(d)
                               } function l(b) { var f = a.data(b, "datagrid").options, e = a.data(b, "datagrid").grid, c = a.data(b, "datagrid").data; if (f.idField) return a.data(b, "datagrid").selectedRows; var d = []; a(".datagrid-view2 .datagrid-body tr.datagrid-row-selected", e).each(function() { var b = parseInt(a(this).attr("datagrid-row-index")); c.rows[b] && d.push(c.rows[b]) }); return d } function i(c) { var b = a.data(c, "datagrid").grid; a(".datagrid-body tr.datagrid-row-selected", b).removeClass("datagrid-row-selected"); a(".datagrid-body .datagrid-cell-check input[type=checkbox]", b).attr("checked", false); var d = a.data(c, "datagrid").selectedRows; while (d.length > 0) d.pop() } function b(c, b) { var h = a.data(c, "datagrid").grid, d = a.data(c, "datagrid").options, e = a.data(c, "datagrid").data, f = a.data(c, "datagrid").selectedRows; if (b < 0 || b >= e.rows.length) return; var k = a(".datagrid-body tr[datagrid-row-index=" + b + "]", h), j = a(".datagrid-body tr[datagrid-row-index=" + b + "] .datagrid-cell-check input[type=checkbox]", h); k.addClass("datagrid-row-selected"); j.attr("checked", true); if (d.idField) { for (var i = e.rows[b], g = 0; g < f.length; g++) if (f[g][d.idField] == i[d.idField]) return; f.push(i) } d.onSelect.call(c, b, e.rows[b]) } function n(d, h) { var g = a.data(d, "datagrid").options, f = a.data(d, "datagrid").data; if (g.idField) { for (var e = -1, c = 0; c < f.rows.length; c++) if (f.rows[c][g.idField] == h) { e = c; break } e >= 0 && b(d, e) } } function j(d, b) { var e = a.data(d, "datagrid").options, i = a.data(d, "datagrid").grid, h = a.data(d, "datagrid").data, c = a.data(d, "datagrid").selectedRows; if (b < 0 || b >= h.rows.length) return; var m = a(".datagrid-body tr[datagrid-row-index=" + b + "]", i), l = a(".datagrid-body tr[datagrid-row-index=" + b + "] .datagrid-cell-check input[type=checkbox]", i); m.removeClass("datagrid-row-selected"); l.attr("checked", false); var j = h.rows[b]; if (e.idField) for (var f = 0; f < c.length; f++) { var k = c[f]; if (k[e.idField] == j[e.idField]) { for (var g = f + 1; g < c.length; g++) c[g - 1] = c[g]; c.pop(); break } } e.onUnselect.call(d, b, j) } function e(d, f) { var c = a.data(d, "datagrid").grid, b = a.data(d, "datagrid").options; if (f) b.queryParams = f; if (!b.url) return; var e = a.extend({}, b.queryParams); b.pagination && a.extend(e, { page: b.pageNumber, rows: b.pageSize }); b.sortName && a.extend(e, { sort: b.sortName, order: b.sortOrder }); i(); setTimeout(function() { j() }, 0); function j() { a.ajax({ type: b.method, url: b.url, data: e, dataType: "json", success: function(a) { g(); if (b.onBeforeLoad.apply(d, arguments) != false) { h(d, a); b.onLoadSuccess && b.onLoadSuccess.apply(d, arguments) } }, error: function() { g(); b.onLoadError && b.onLoadError.apply(d, arguments) } }) } function i() { a(".datagrid-pager", c).pagination("loading"); var d = a(".datagrid-wrap", c); a('<div class="datagrid-mask"></div>').css({ display: "block", width: d.width(), height: d.height() }).appendTo(d); a('<div class="datagrid-mask-msg"></div>').html(b.loadMsg).appendTo(d).css({ display: "block", left: (d.width() - a(".datagrid-mask-msg", c).outerWidth()) / 2, top: (d.height() - a(".datagrid-mask-msg", c).outerHeight()) / 2 }) } function g() { c.find(".datagrid-pager").pagination("loaded"); c.find(".datagrid-mask").remove(); c.find(".datagrid-mask-msg").remove() } } a.fn.datagrid = function(f, g) {
                                   if (typeof f == "string") switch (f) { case "options": return a.data(this[0], "datagrid").options; case "getPager": return a.data(this[0], "datagrid").grid.find(".datagrid-pager"); case "resize": return this.each(function() { c(this) }); case "reload": return this.each(function() { e(this, g) }); case "fixColumnSize": return this.each(function() { d(this) }); case "loadData": return this.each(function() { h(this, g) }); case "getSelected": var p = l(this[0]); return p.length > 0 ? p[0] : null; case "getSelections": return l(this[0]); case "clearSelections": return this.each(function() { i(this) }); case "selectRow": return this.each(function() { b(this, g) }); case "selectRecord": return this.each(function() { n(this, g) }); case "unselectRow": return this.each(function() { j(this, g) }) } f = f || {}; return this.each(function() {
                                       var n = a.data(this, "datagrid"), b; if (n) { b = a.extend(n.options, f); n.options = b } else {
                                           b = a.extend({}, a.fn.datagrid.defaults, { width: parseInt(a(this).css("width")) || undefined, height: parseInt(a(this).css("height")) || undefined, fit: a(this).attr("fit") ? a(this).attr("fit") == "true" : undefined }, f); a(this).css("width", null).css("height", null); var p = o(this, b.rownumbers); if (!b.columns) b.columns = p.columns; if (!b.frozenColumns) b.frozenColumns = p.frozenColumns; a.data(this, "datagrid", { options: b, grid: p.grid, selectedRows: [] }); 
                               h(this, p.data) } var i = this, g = a.data(this, "datagrid").grid; if (b.border == true) g.removeClass("datagrid-noborder"); else g.addClass("datagrid-noborder"); if (b.frozenColumns) { var l = m(b.frozenColumns); if (b.rownumbers) { var v = a('<td rowspan="' + b.frozenColumns.length + '"><div class="datagrid-header-rownumber"></div></td>'); if (a("tr", l).length == 0) v.wrap("<tr></tr>").parent().appendTo(a("tbody", l)); else v.prependTo(a("tr:first", l)) } a(".datagrid-view1 .datagrid-header-inner", g).html(l) } if (b.columns) { var l = m(b.columns); a(".datagrid-view2 .datagrid-header-inner", g).html(l) } a(".datagrid-title", g).remove(); if (b.title) { var q = a('<div class="datagrid-title"><span class="datagrid-title-text"></span></div>'); a(".datagrid-title-text", q).html(b.title); q.prependTo(g); if (b.iconCls) { a(".datagrid-title-text", q).addClass("datagrid-title-with-icon"); a('<div class="datagrid-title-icon"></div>').addClass(b.iconCls).appendTo(q) } } a(".datagrid-toolbar", g).remove(); if (b.toolbar) for (var u = a('<div class="datagrid-toolbar"></div>').prependTo(a(".datagrid-wrap", g)), r = 0; r < b.toolbar.length; r++) { var j = b.toolbar[r]; if (j == "-") a('<div class="datagrid-btn-separator"></div>').appendTo(u); else { var s = a('<a href="javascript:void(0)"></a>'); s[0].onclick = eval(j.handler || function() { }); s.css("float", "left").text(j.text).attr("icon", j.iconCls || "").appendTo(u).linkbutton({ plain: true, disabled: j.disabled || false }) } } a(".datagrid-pager", g).remove(); if (b.pagination) { var t = a('<div class="datagrid-pager"></div>').appendTo(a(".datagrid-wrap", g)); t.pagination({ pageNumber: b.pageNumber, pageSize: b.pageSize, pageList: b.pageList, onSelectPage: function(a, c) { b.pageNumber = a; b.pageSize = c; e(i) } }); b.pageSize = t.pagination("options").pageSize } !n && d(i); c(i); b.url && e(i); k(i) }) }; a.fn.datagrid.defaults = { title: null, iconCls: null, border: true, width: "auto", height: "auto", frozenColumns: null, columns: null, toolbar: null, striped: false, method: "post", nowrap: true, idField: null, url: null, loadMsg: "Processing, please wait ...", rownumbers: false, singleSelect: false, fit: false, pagination: false, pageNumber: 1, pageSize: 10, pageList: [10, 20, 30, 40, 50], queryParams: {}, sortName: null, sortOrder: "asc", onLoadSuccess: function() { }, onLoadError: function() { }, onBeforeLoad: function() { }, onClickRow: function() { }, onDblClickRow: function() { }, onSortColumn: function() { }, onSelect: function() { }, onUnselect: function() { } }
                           })(jQuery);
                           (function(a) {
                               function f(b) {
                                   var d = a(b),
                                   c = a('<div class="datebox-calendar"><div class="datebox-calendar-inner"><div></div></div><div class="datebox-button"></div></div>').appendTo("body");
                                   c.find("div.datebox-calendar-inner>div").calendar({
                                   fit: true,
                                   border: false,
                                   onSelect: function(d) {
                                   var e = a.data(b, "datebox").options,
                                   f = e.formatter(d);
                                   a(b).val(f);
                                   c.hide();
                                   e.onSelect.call(b, d)
                               } 
                           });
                           c.hide().mousedown(function() {
                           return false
                       });
                       return c
                   }
                   function b(b) {
                       var f = a.data(b, "datebox").options,
                                    c = a(b); a(document).unbind(".datebox");
                       c.unbind(".datebox");
                       if (!f.disabled) {
                           a(document).bind("mousedown.datebox",
                                    function() { e(b) });
                           c.bind("focus.datebox",
                                    function() { d(b) }).bind("click.datebox", function() { d(b) })
                       } 
                   }
                   function g(e) {
                       var d = a.data(e, "datebox").options,
                    c = a.data(e, "datebox").calendar,
                    b = c.find("div.datebox-button");
                       b.empty();
                       a('<a href="javascript:void(0)" class="datebox-current"></a>').html(d.currentText).appendTo(b);
                       a('<a href="javascript:void(0)" class="datebox-close"></a>').html(d.closeText).appendTo(b);
                       b.find(".datebox-current,.datebox-close").hover(function() {
                       a(this).addClass("datebox-button-hover")
                   },
                    function() { a(this).removeClass("datebox-button-hover") });
                   b.find(".datebox-current").click(function() {
                   c.find("div.datebox-calendar-inner>div").calendar({
                   year: (new Date).getFullYear(),
                   month: (new Date).getMonth() + 1,
                   current: new Date
               })
           });
           b.find(".datebox-close").click(function() { c.hide() })
       }
       function d(b) {
           var e = a.data(b, "datebox").options,
               c = a.data(b, "datebox").calendar;
           c.css({ 
           display: "block",
           left: a(b).offset().left, 
           top: a(b).offset().top + a(b).outerHeight() });
           var d = e.parser(a(b).val()); c.find("div.datebox-calendar-inner>div").calendar({ year: d.getFullYear(),
           month: d.getMonth() + 1, current: d
       });
       a.fn.window && c.css("z-index", a.fn.window.defaults.zIndex++)
   }
   function e(b) {
       var c = a.data(b, "datebox").calendar;
       c.hide()
   }
    function h(b) {
        if (a.fn.validatebox) { var c = a.data(b, "datebox").options; a(b).validatebox(c) } 
    }
    function c(b, d) {
        var c = a.data(b, "datebox").options; if (d) {
            c.disabled = true;
            a(b).attr("disabled", true)
        } else { c.disabled = false; a(b).removeAttr("disabled") } 
    }
    a.fn.datebox = function(d) {
    if (typeof d == "string") 
        switch (d) {
            case "disable": return this.each(function() { c(this, true); b(this) });
            case "enable": return this.each(function() { c(this, false); b(this) })
        } d = d || {};
        return this.each(function() {
            var i = a.data(this, "datebox");
            if (i) a.extend(i.options, d);
            else {
                var j = f(this), e = a(this);
                i = a.data(this, "datebox", { options: a.extend({}, 
                a.fn.datebox.defaults,
     { disabled: e.attr("disabled") ? true : undefined,
         required: e.attr("required") ? e.attr("required") == "true" || e.attr("required") == true : undefined,
         missingMessage: e.attr("missingMessage") || undefined
     }, d), calendar: j
 });
 e.removeAttr("disabled")
} g(this);
c(this, i.options.disabled);
b(this); 
h(this)
})
};
a.fn.datebox.defaults = { currentText: "Today",
closeText: "Close", 
disabled: false,
required: false,
missingMessage: "This field is required.",
formatter: function(a) {
    var d = a.getFullYear(),
        c = a.getMonth() + 1, 
        b = a.getDate();
    //return c + "/" + b + "/" + d
    return d + "/" + c + "/" + b
},
parser: function(b) {
    var a = Date.parse(b);
    return !isNaN(a) ? new Date(a) : new Date
},
onSelect: function() { } }
})(jQuery); 
  (function(a) {
                               function b(d) { var b = a(d); b.wrapInner('<div class="dialog-content"></div>'); var c = b.find(">div.dialog-content"); c.css("padding", b.css("padding")); b.css("padding", 0); c.panel({ border: false }); return c } function c(d) { var b = a.data(d, "dialog").options, i = a.data(d, "dialog").contentPanel; a(d).find("div.dialog-toolbar").remove(); a(d).find("div.dialog-button").remove(); if (b.toolbar) { for (var h = a('<div class="dialog-toolbar"></div>').prependTo(d), e = 0; e < b.toolbar.length; e++) { var c = b.toolbar[e]; if (c == "-") h.append('<div class="dialog-tool-separator"></div>'); else { var f = a('<a href="javascript:void(0)"></a>').appendTo(h); f.css("float", "left").text(c.text); c.iconCls && f.attr("icon", c.iconCls); if (c.handler) f[0].onclick = c.handler; f.linkbutton({ plain: true, disabled: c.disabled || false }) } } h.append('<div style="clear:both"></div>') } if (b.buttons) for (var j = a('<div class="dialog-button"></div>').appendTo(d), e = 0; e < b.buttons.length; e++) { var c = b.buttons[e], g = a('<a href="javascript:void(0)"></a>').appendTo(j); g.text(c.text); c.iconCls && g.attr("icon", c.iconCls); if (c.handler) g[0].onclick = c.handler; g.linkbutton() } if (b.href) { i.panel({ href: b.href, onLoad: b.onLoad }); b.href = null } a(d).window(a.extend({}, b, { onResize: function(f, e) { var c = a(d).panel("panel").find(">div.panel-body"); i.panel("resize", { width: c.width(), height: e == "auto" ? "auto" : c.height() - c.find(">div.dialog-toolbar").outerHeight() - c.find(">div.dialog-button").outerHeight() }); b.onResize && b.onResize.call(d, f, e) } })) } function d(b) { var c = a.data(b, "dialog").contentPanel; c.panel("refresh") } a.fn.dialog = function(e, f) {
                                   if (typeof e == "string") switch (e) { case "options": return a(this[0]).window("options"); case "dialog": return a(this[0]).window("window"); case "setTitle": return this.each(function() { a(this).window("setTitle", f) }); case "open": return this.each(function() { a(this).window("open", f) }); case "close": return this.each(function() { a(this).window("close", f) }); case "destroy": return this.each(function() { a(this).window("destroy", f) }); case "refresh": return this.each(function() { d(this) }); case "resize": return this.each(function() { a(this).window("resize", f) }); case "move": return this.each(function() { a(this).window("move", f) }) } e = e || {}; return this.each(function() {
                                       var f = a.data(this, "dialog"); 
                           if (f) a.extend(f.options, e); else { var d = a(this), g = a.extend({}, a.fn.dialog.defaults, { title: d.attr("title") ? d.attr("title") : undefined, href: d.attr("href"), collapsible: d.attr("collapsible") ? d.attr("collapsible") == "true" : undefined, minimizable: d.attr("minimizable") ? d.attr("minimizable") == "true" : undefined, maximizable: d.attr("maximizable") ? d.attr("maximizable") == "true" : undefined, resizable: d.attr("resizable") ? d.attr("resizable") == "true" : undefined }, e); a.data(this, "dialog", { options: g, contentPanel: b(this) }) } c(this) }) }; a.fn.dialog.defaults = { title: "New Dialog", href: null, collapsible: false, minimizable: false, maximizable: false, resizable: false, toolbar: null, buttons: null} })(jQuery); (function(a) {
                               function b(b) { var c = a.data(b.data.target, "draggable").options, d = b.data, e = d.startLeft + b.pageX - d.startX, f = d.startTop + b.pageY - d.startY; if (c.deltaX != null && c.deltaX != undefined) e = b.pageX + c.deltaX; if (c.deltaY != null && c.deltaY != undefined) f = b.pageY + c.deltaY; if (b.data.parnet != document.body) if (a.boxModel == true) { e += a(b.data.parent).scrollLeft(); f += a(b.data.parent).scrollTop() } if (c.axis == "h") d.left = e; else if (c.axis == "v") d.top = f; else { d.left = e; d.top = f } } function c(b) { var d = a.data(b.data.target, "draggable").options, c = a.data(b.data.target, "draggable").proxy; if (c) c.css("cursor", d.cursor); else { c = a(b.data.target); a.data(b.data.target, "draggable").handle.css("cursor", d.cursor) } c.css({ left: b.data.left, top: b.data.top }) } function e(d) { var f = a.data(d.data.target, "draggable").options, g = a(".droppable").filter(function() { return d.data.target != this }).filter(function() { var b = a.data(this, "droppable").options.accept; return b ? a(b).filter(function() { return this == d.data.target }).length > 0 : true }); a.data(d.data.target, "draggable").droppables = g; var e = a.data(d.data.target, "draggable").proxy; if (!e) if (f.proxy) { if (f.proxy == "clone") e = a(d.data.target).clone().insertAfter(d.data.target); else e = f.proxy.call(d.data.target, d.data.target); a.data(d.data.target, "draggable").proxy = e } else e = a(d.data.target); e.css("position", "absolute"); b(d); c(d); f.onStartDrag.call(d.data.target, d); return false } function f(d) { b(d); a.data(d.data.target, "draggable").options.onDrag.call(d.data.target, d) != false && c(d); var e = d.data.target; a.data(d.data.target, "draggable").droppables.each(function() { var c = a(this), b = a(this).offset(); if (d.pageX > b.left && d.pageX < b.left + c.outerWidth() && d.pageY > b.top && d.pageY < b.top + c.outerHeight()) { if (!this.entered) { a(this).trigger("_dragenter", [e]); this.entered = true } a(this).trigger("_dragover", [e]) } else if (this.entered) { a(this).trigger("_dragleave", [e]); this.entered = false } }); return false } function d(c) {
                                   b(c); var d = a.data(c.data.target, "draggable").proxy, e = a.data(c.data.target, "draggable").options; if (e.revert) if (g() == true) { f(); a(c.data.target).css({ position: c.data.startPosition, left: c.data.startLeft, top: c.data.startTop }) } else if (d) d.animate({ left: c.data.startLeft, top: c.data.startTop }, 
                           function() { f() }); else a(c.data.target).animate({ left: c.data.startLeft, top: c.data.startTop }, function() { a(c.data.target).css("position", c.data.startPosition) }); else { a(c.data.target).css({ position: "absolute", left: c.data.left, top: c.data.top }); f(); g() } e.onStopDrag.call(c.data.target, c); function f() { d && d.remove(); a.data(c.data.target, "draggable").proxy = null } function g() { var b = false; a.data(c.data.target, "draggable").droppables.each(function() { var f = a(this), d = a(this).offset(); if (c.pageX > d.left && c.pageX < d.left + f.outerWidth() && c.pageY > d.top && c.pageY < d.top + f.outerHeight()) { e.revert && a(c.data.target).css({ position: c.data.startPosition, left: c.data.startLeft, top: c.data.startTop }); a(this).trigger("_drop", [c.data.target]); b = true; this.entered = false } }); return b } a(document).unbind(".draggable"); return false } a.fn.draggable = function(b) { if (typeof b == "string") switch (b) { case "options": return a.data(this[0], "draggable").options; case "proxy": return a.data(this[0], "draggable").proxy; case "enable": return this.each(function() { a(this).draggable({ disabled: false }) }); case "disable": return this.each(function() { a(this).draggable({ disabled: true }) }) } return this.each(function() { var c, h = a.data(this, "draggable"); if (h) { h.handle.unbind(".draggable"); c = a.extend(h.options, b) } else c = a.extend({}, a.fn.draggable.defaults, b || {}); if (c.disabled == true) { a(this).css("cursor", "default"); return } var g = null; if (typeof c.handle == "undefined" || c.handle == null) g = a(this); else g = typeof c.handle == "string" ? a(c.handle, this) : g; a.data(this, "draggable", { options: c, handle: g }); g.bind("mousedown.draggable", { target: this }, j); g.bind("mousemove.draggable", { target: this }, k); function j(b) { if (i(b) == false) return; var c = a(b.data.target).position(), g = { startPosition: a(b.data.target).css("position"), startLeft: c.left, startTop: c.top, left: c.left, top: c.top, startX: b.pageX, startY: b.pageY, target: b.data.target, parent: a(b.data.target).parent()[0] }; a(document).bind("mousedown.draggable", g, e); a(document).bind("mousemove.draggable", g, f); a(document).bind("mouseup.draggable", g, d) } function k(b) { if (i(b)) a(this).css("cursor", c.cursor); else a(this).css("cursor", "default") } function i(d) { var b = a(g).offset(), e = a(g).outerWidth(), f = a(g).outerHeight(), k = d.pageY - b.top, j = b.left + e - d.pageX, h = b.top + f - d.pageY, i = d.pageX - b.left; return Math.min(k, j, h, i) > c.edge } }) }; a.fn.draggable.defaults = { proxy: null, revert: false, cursor: "move", deltaX: null, deltaY: null, handle: null, disabled: false, edge: 0, axis: null, onStartDrag: function() { }, onDrag: function() { }, onStopDrag: function() { } } })(jQuery); (function(a) {
                               function b(b) { a(b).addClass("droppable"); a(b).bind("_dragenter", function(d, c) { a.data(b, "droppable").options.onDragEnter.apply(b, [d, c]) }); a(b).bind("_dragleave", function(d, c) { a.data(b, "droppable").options.onDragLeave.apply(b, [d, c]) }); a(b).bind("_dragover", function(d, c) { a.data(b, "droppable").options.onDragOver.apply(b, [d, c]) }); a(b).bind("_drop", function(d, c) { a.data(b, "droppable").options.onDrop.apply(b, [d, c]) }) }
                               a.fn.droppable = function(c) { c = c || {}; return this.each(function() { var d = a.data(this, "droppable"); if (d) a.extend(d.options, c); else { b(this); a.data(this, "droppable", { options: a.extend({}, a.fn.droppable.defaults, c) }) } }) }; a.fn.droppable.defaults = { accept: null, onDragEnter: function() { }, onDragOver: function() { }, onDragLeave: function() { }, onDrop: function() { } }
                           })(jQuery); (function(a) { function b(f, c) { c = c || {}; if (c.onSubmit) if (c.onSubmit.call(f) == false) return; var b = a(f); c.url && b.attr("action", c.url); var e = "easyui_frame_" + (new Date).getTime(), d = a("<iframe id=" + e + " name=" + e + "></iframe>").attr("src", window.ActiveXObject ? "javascript:false" : "about:blank").css({ position: "absolute", top: -1e3, left: -1e3 }), h = b.attr("target"), j = b.attr("action"); b.attr("target", e); try { d.appendTo("body"); d.bind("load", g); b[0].submit() } finally { b.attr("action", j); h ? b.attr("target", h) : b.removeAttr("target") } var i = 10; function g() { d.unbind(); var f = a("#" + e).contents().find("body"), b = f.html(); if (b == "") { if (--i) { setTimeout(g, 100); return } return } var j = f.find(">textarea"); if (j.length) b = j.value(); else { var h = f.find(">pre"); if (h.length) b = h.html() } c.success && c.success(b); setTimeout(function() { d.unbind(); d.remove() }, 100) } } function c(d, b) { if (typeof b == "string") a.ajax({ url: b, dataType: "json", success: function(a) { c(a) } }); else c(b); function c(f) { var c = a(d); for (var b in f) { var e = f[b]; a("input[name=" + b + "]", c).val(e); a("textarea[name=" + b + "]", c).val(e); a("select[name=" + b + "]", c).val(e); a.fn.combobox && a("select[comboboxName=" + b + "]", c).combobox("setValue", e); a.fn.combotree && a("select[combotreeName=" + b + "]", c).combotree("setValue", e) } } } function d(b) { a("input,select,textarea", b).each(function() { var a = this.type, b = this.tagName.toLowerCase(); if (a == "text" || a == "password" || b == "textarea") this.value = ""; else if (a == "checkbox" || a == "radio") this.checked = false; else if (b == "select") this.selectedIndex = -1 }) } function e(c) { var e = a.data(c, "form").options, d = a(c); d.unbind(".form").bind("submit.form", function() { setTimeout(function() { b(c, e) }, 0); return false }) } function f(c) { if (a.fn.validatebox) { var b = a(".validatebox-text", c); if (b.length) { b.validatebox("validate"); b.trigger("blur"); var d = a(".validatebox-invalid:first", c).focus(); return d.length == 0 } } return true } a.fn.form = function(g, h) { if (typeof g == "string") switch (g) { case "submit": return this.each(function() { b(this, a.extend({}, a.fn.form.defaults, h || {})) }); case "load": return this.each(function() { c(this, h) }); case "clear": return this.each(function() { d(this) }); case "validate": return f(this[0]) } g = g || {}; return this.each(function() { !a.data(this, "form") && a.data(this, "form", { options: a.extend({}, a.fn.form.defaults, g) }); e(this) }) }; a.fn.form.defaults = { url: null, onSubmit: function() { }, success: function() { } } })(jQuery); (function(a) {
                           var d = false; function c(f) { var l = a.data(f, "layout").options, c = a.data(f, "layout").panels, e = a(f); if (l.fit == true) { var k = e.parent(); e.width(k.width()).height(k.height()) } var d = { top: 0, left: 0, width: e.width(), height: e.height() }; function g(a) { if (a.length == 0) return; a.panel("resize", { width: e.width(), height: a.panel("options").height, left: 0, top: 0 }); d.top += a.panel("options").height; d.height -= a.panel("options").height } if (b(c.expandNorth)) g(c.expandNorth); else g(c.north); function h(a) { if (a.length == 0) return; a.panel("resize", { width: e.width(), height: a.panel("options").height, left: 0, top: e.height() - a.panel("options").height }); d.height -= a.panel("options").height } if (b(c.expandSouth)) h(c.expandSouth); else h(c.south); function i(a) { if (a.length == 0) return; a.panel("resize", { width: a.panel("options").width, height: d.height, left: e.width() - a.panel("options").width, top: d.top }); d.width -= a.panel("options").width } if (b(c.expandEast)) i(c.expandEast); else i(c.east); function j(a) { if (a.length == 0) return; a.panel("resize", { width: a.panel("options").width, height: d.height, left: 0, top: d.top }); d.left += a.panel("options").width; d.width -= a.panel("options").width } if (b(c.expandWest)) j(c.expandWest); else j(c.west); c.center.panel("resize", d) } function g(b) {
                               var f = a(b); if (f[0].tagName == "BODY") { a("html").css({ height: "100%", overflow: "hidden" }); a("body").css({ height: "100%", overflow: "hidden", border: "none" }) } f.addClass("layout"); f.css({ margin: 0, padding: 0 }); function g(g) { var i = a(">div[region=" + g + "]", b).addClass("layout-body"), j = null; if (g == "north") j = "layout-button-up"; else if (g == "south") j = "layout-button-down"; else if (g == "east") j = "layout-button-right"; else if (g == "west") j = "layout-button-left"; var l = "layout-panel layout-panel-" + g; if (i.attr("split") == "true") l += " layout-split-" + g; i.panel({ cls: l, doSize: false, border: i.attr("border") == "false" ? false : true, tools: [{ iconCls: j, handler: function() { e(b, g) } }] }); if (i.attr("split") == "true") { var h = i.panel("panel"), k = ""; if (g == "north") k = "s"; if (g == "south") k = "n"; if (g == "east") k = "w"; if (g == "west") k = "e"; h.resizable({ handles: k, onStartResize: function() { d = true; if (g == "north" || g == "south") var e = a(">div.layout-split-proxy-v", b); else var e = a(">div.layout-split-proxy-h", b); var l = 0, i = 0, j = 0, k = 0, c = { display: "block" }; if (g == "north") { c.top = parseInt(h.css("top")) + h.outerHeight() - e.height(); c.left = parseInt(h.css("left")); c.width = h.outerWidth(); c.height = e.height() } else if (g == "south") { c.top = parseInt(h.css("top")); c.left = parseInt(h.css("left")); c.width = h.outerWidth(); c.height = e.height() } else if (g == "east") { c.top = parseInt(h.css("top")) || 0; c.left = parseInt(h.css("left")) || 0; c.width = e.width(); c.height = h.outerHeight() } else if (g == "west") { c.top = parseInt(h.css("top")) || 0; c.left = h.outerWidth() - e.width(); c.width = e.width(); c.height = h.outerHeight() } e.css(c); a('<div class="layout-mask"></div>').css({ left: 0, top: 0, width: f.width(), height: f.height() }).appendTo(f) }, onResize: function(d) { if (g == "north" || g == "south") { var c = a(">div.layout-split-proxy-v", b); c.css("top", d.pageY - a(b).offset().top - c.height() / 2) } else { var c = a(">div.layout-split-proxy-h", b); c.css("left", d.pageX - a(b).offset().left - c.width() / 2) } return false }, onStopResize: function() { a(">div.layout-split-proxy-v", b).css("display", "none"); a(">div.layout-split-proxy-h", b).css("display", "none"); var e = i.panel("options"); e.width = h.outerWidth(); e.height = h.outerHeight(); e.left = h.css("left"); e.top = h.css("top"); i.panel("resize"); c(b); d = false; f.find(">div.layout-mask").remove() } }) } return i } a('<div class="layout-split-proxy-h"></div>').appendTo(f); a('<div class="layout-split-proxy-v"></div>').appendTo(f); 
                           var h = { center: g("center") }; h.north = g("north"); h.south = g("south"); h.east = g("east"); h.west = g("west"); a(b).bind("_resize", function() { var d = a.data(b, "layout").options; d.fit == true && c(b); return false }); a(window).resize(function() { c(b) }); return h } function e(i, g) {
                               var c = a.data(i, "layout").panels, e = a(i); function h(c) { var b; if (c == "east") b = "layout-button-left"; else if (c == "west") b = "layout-button-right"; else if (c == "north") b = "layout-button-down"; else if (c == "south") b = "layout-button-up"; var d = a("<div></div>").appendTo(e).panel({ cls: "layout-expand", title: "&nbsp;", closed: true, doSize: false, tools: [{ iconCls: b, handler: function() { f(i, g) } }] }); d.panel("panel").hover(function() { a(this).addClass("layout-expand-over") }, function() { a(this).removeClass("layout-expand-over") }); return d } if (g == "east") { if (c.east.panel("options").onBeforeCollapse.call(c.east) == false) return; c.center.panel("resize", { width: c.center.panel("options").width + c.east.panel("options").width - 28 }); c.east.panel("panel").animate({ left: e.width() }, function() { c.east.panel("close"); c.expandEast.panel("open").panel("resize", { top: c.east.panel("options").top, left: e.width() - 28, width: 28, height: c.east.panel("options").height }); c.east.panel("options").onCollapse.call(c.east) }); if (!c.expandEast) { c.expandEast = h("east"); c.expandEast.panel("panel").click(function() { c.east.panel("open").panel("resize", { left: e.width() }); c.east.panel("panel").animate({ left: e.width() - c.east.panel("options").width }); return false }) } } else if (g == "west") {
                                   if (c.west.panel("options").onBeforeCollapse.call(c.west) == false) return; c.center.panel("resize", { width: c.center.panel("options").width + c.west.panel("options").width - 32, left: 32 }); c.west.panel("panel").animate({ left: -c.west.panel("options").width }, function() { c.west.panel("close"); c.expandWest.panel("open").panel("resize", { top: c.west.panel("options").top, left: 0, width: 28, height: c.west.panel("options").height }); c.west.panel("options").onCollapse.call(c.west) }); 
                               if (!c.expandWest) { c.expandWest = h("west"); c.expandWest.panel("panel").click(function() { c.west.panel("open").panel("resize", { left: -c.west.panel("options").width }); c.west.panel("panel").animate({ left: 0 }); return false }) } } else if (g == "north") { if (c.north.panel("options").onBeforeCollapse.call(c.north) == false) return; var d = e.height() - 28; if (b(c.expandSouth)) d -= c.expandSouth.panel("options").height; else if (b(c.south)) d -= c.south.panel("options").height; c.center.panel("resize", { top: 28, height: d }); c.east.panel("resize", { top: 28, height: d }); c.west.panel("resize", { top: 28, height: d }); b(c.expandEast) && c.expandEast.panel("resize", { top: 28, height: d }); b(c.expandWest) && c.expandWest.panel("resize", { top: 28, height: d }); c.north.panel("panel").animate({ top: -c.north.panel("options").height }, function() { c.north.panel("close"); c.expandNorth.panel("open").panel("resize", { top: 0, left: 0, width: e.width(), height: 28 }); c.north.panel("options").onCollapse.call(c.north) }); if (!c.expandNorth) { c.expandNorth = h("north"); c.expandNorth.panel("panel").click(function() { c.north.panel("open").panel("resize", { top: -c.north.panel("options").height }); c.north.panel("panel").animate({ top: 0 }); return false }) } } else if (g == "south") { if (c.south.panel("options").onBeforeCollapse.call(c.south) == false) return; var d = e.height() - 28; if (b(c.expandNorth)) d -= c.expandNorth.panel("options").height; else if (b(c.north)) d -= c.north.panel("options").height; c.center.panel("resize", { height: d }); c.east.panel("resize", { height: d }); c.west.panel("resize", { height: d }); b(c.expandEast) && c.expandEast.panel("resize", { height: d }); b(c.expandWest) && c.expandWest.panel("resize", { height: d }); c.south.panel("panel").animate({ top: e.height() }, function() { c.south.panel("close"); c.expandSouth.panel("open").panel("resize", { top: e.height() - 28, left: 0, width: e.width(), height: 28 }); c.south.panel("options").onCollapse.call(c.south) }); if (!c.expandSouth) { c.expandSouth = h("south"); c.expandSouth.panel("panel").click(function() { c.south.panel("open").panel("resize", { top: e.height() }); c.south.panel("panel").animate({ top: e.height() - c.south.panel("options").height }); return false }) } } } function f(d, e) {
                                   var b = a.data(d, "layout").panels, f = a(d); if (e == "east" && b.expandEast) { if (b.east.panel("options").onBeforeExpand.call(b.east) == false) return; b.expandEast.panel("close"); b.east.panel("panel").stop(true, true); b.east.panel("open").panel("resize", { left: f.width() }); b.east.panel("panel").animate({ left: f.width() - b.east.panel("options").width }, function() { c(d); b.east.panel("options").onExpand.call(b.east) }) } else if (e == "west" && b.expandWest) { if (b.west.panel("options").onBeforeExpand.call(b.west) == false) return; b.expandWest.panel("close"); b.west.panel("panel").stop(true, true); b.west.panel("open").panel("resize", { left: -b.west.panel("options").width }); b.west.panel("panel").animate({ left: 0 }, function() { c(d); b.west.panel("options").onExpand.call(b.west) }) } else if (e == "north" && b.expandNorth) {
                                       if (b.north.panel("options").onBeforeExpand.call(b.north) == false) return; b.expandNorth.panel("close"); b.north.panel("panel").stop(true, true); b.north.panel("open").panel("resize", { top: -b.north.panel("options").height });
                                       b.north.panel("panel").animate({ top: 0 }, function() { c(d); b.north.panel("options").onExpand.call(b.north) })
                                   } else if (e == "south" && b.expandSouth) { if (b.south.panel("options").onBeforeExpand.call(b.south) == false) return; b.expandSouth.panel("close"); b.south.panel("panel").stop(true, true); b.south.panel("open").panel("resize", { top: f.height() }); b.south.panel("panel").animate({ top: f.height() - b.south.panel("options").height }, function() { c(d); b.south.panel("options").onExpand.call(b.south) }) } 
                               } function h(f) { var c = a.data(f, "layout").panels, g = a(f); c.east.length && c.east.panel("panel").bind("mouseover", "east", e); c.west.length && c.west.panel("panel").bind("mouseover", "west", e); c.north.length && c.north.panel("panel").bind("mouseover", "north", e); c.south.length && c.south.panel("panel").bind("mouseover", "south", e); c.center.panel("panel").bind("mouseover", "center", e); function e(a) { if (d == true) return; a.data != "east" && b(c.east) && b(c.expandEast) && c.east.panel("panel").animate({ left: g.width() }, function() { c.east.panel("close") }); a.data != "west" && b(c.west) && b(c.expandWest) && c.west.panel("panel").animate({ left: -c.west.panel("options").width }, function() { c.west.panel("close") }); a.data != "north" && b(c.north) && b(c.expandNorth) && c.north.panel("panel").animate({ top: -c.north.panel("options").height }, function() { c.north.panel("close") }); a.data != "south" && b(c.south) && b(c.expandSouth) && c.south.panel("panel").animate({ top: g.height() }, function() { c.south.panel("close") }); return false } } function b(a) { return !a ? false : a.length ? a.panel("panel").is(":visible") : false } a.fn.layout = function(d, b) { if (typeof d == "string") switch (d) { case "panel": return a.data(this[0], "layout").panels[b]; case "collapse": return this.each(function() { e(this, b) }); case "expand": return this.each(function() { f(this, b) }) } return this.each(function() { var d = a.data(this, "layout"); if (!d) { var b = a.extend({}, { fit: a(this).attr("fit") == "true" }); a.data(this, "layout", { options: b, panels: g(this) }); h(this) } c(this) }) } 
                           })(jQuery); (function(a) { function c(c) { var d = a.data(c, "linkbutton").options; a(c).empty(); a(c).addClass("l-btn"); if (d.plain) a(c).addClass("l-btn-plain"); else a(c).removeClass("l-btn-plain"); if (d.text) { a(c).html(d.text).wrapInner('<span class="l-btn-left"><span class="l-btn-text"></span></span>'); d.iconCls && a(c).find(".l-btn-text").addClass(d.iconCls).css("padding-left", "20px") } else { a(c).html("&nbsp;").wrapInner('<span class="l-btn-left"><span class="l-btn-text"><span class="l-btn-empty"></span></span></span>'); d.iconCls && a(c).find(".l-btn-empty").addClass(d.iconCls) } b(c, d.disabled) } function b(b, f) { var c = a.data(b, "linkbutton"); if (f) { c.options.disabled = true; var d = a(b).attr("href"); if (d) { c.href = d; a(b).attr("href", "javascript:void(0)") } var e = a(b).attr("onclick"); if (e) { c.onclick = e; a(b).attr("onclick", null) } a(b).addClass("l-btn-disabled") } else { c.href && a(b).attr("href", c.href); if (c.onclick) b.onclick = c.onclick; a(b).removeClass("l-btn-disabled") } } a.fn.linkbutton = function(d) { if (typeof d == "string") switch (d) { case "options": return a.data(this[0], "linkbutton").options; case "enable": return this.each(function() { b(this, false) }); case "disable": return this.each(function() { b(this, true) }) } d = d || {}; return this.each(function() { var e = a.data(this, "linkbutton"); if (e) a.extend(e.options, d); else { var b = a(this); a.data(this, "linkbutton", { options: a.extend({}, a.fn.linkbutton.defaults, { disabled: b.attr("disabled") ? true : undefined, plain: b.attr("plain") ? b.attr("plain") == "true" : undefined, text: a.trim(b.html()), iconCls: b.attr("icon") }, d) }); b.removeAttr("disabled") } c(this) }) }; a.fn.linkbutton.defaults = { disabled: false, plain: false, text: "", iconCls: null} })(jQuery); (function(a) {
                               function e(e) { a(e).appendTo("body"); a(e).addClass("menu-top"); var h = []; j(a(e)); for (var g = null, i = 0; i < h.length; i++) { var f = h[i]; k(f); f.find(">div.menu-item").each(function() { l(a(this)) }); f.find("div.menu-item").click(function() { if (!this.submenu) { b(e); var c = a(this).attr("href"); if (c) location.href = c } }); f.bind("mouseenter", function() { if (g) { clearTimeout(g); g = null } }).bind("mouseleave", function() { g = setTimeout(function() { b(e) }, 100) }) } function j(b) { h.push(b); b.find(">div").each(function() { var c = a(this), b = c.find(">div"); if (b.length) { b.insertAfter(e); c[0].submenu = b; j(b) } }) } function l(b) { b.hover(function() { b.siblings().each(function() { this.submenu && c(this.submenu); a(this).removeClass("menu-active") }); b.addClass("menu-active"); var e = b[0].submenu; if (e) { var f = b.offset().left + b.outerWidth() - 2; if (f + e.outerWidth() > a(window).width()) f = b.offset().left - e.outerWidth() + 2; d(e, { left: f, top: b.offset().top - 3 }) } }, function(d) { b.removeClass("menu-active"); var a = b[0].submenu; if (a) if (d.pageX >= parseInt(a.css("left"))) b.addClass("menu-active"); else c(a); else b.removeClass("menu-active") }); b.unbind(".menu").bind("mousedown.menu", function() { return false }) } function k(b) { b.addClass("menu").find(">div").each(function() { var b = a(this); if (b.hasClass("menu-sep")) b.html("&nbsp;"); else { var d = b.addClass("menu-item").html(); b.empty().append(a('<div class="menu-text"></div>').html(d)); var c = b.attr("icon"); c && a('<div class="menu-icon"></div>').addClass(c).appendTo(b); b[0].submenu && a('<div class="menu-rightarrow"></div>').appendTo(b); if (a.boxModel == true) { var e = b.height(); b.height(e - (b.outerHeight() - b.height())) } } }); b.hide() } } function b(b) { var d = a.data(b, "menu").options; c(a(b)); a(document).unbind(".menu"); d.onHide.call(b); return false } function f(e, f) { var c = a.data(e, "menu").options; if (f) { c.left = f.left; c.top = f.top } d(a(e), { left: c.left, top: c.top }, function() { a(document).unbind(".menu").bind("mousedown.menu", function() { b(e); a(document).unbind(".menu"); return false }); c.onShow.call(e) }) } 
                            function d(b, d, c) { if (!b) return; d && b.css(d); b.show(1, function() { if (!b[0].shadow) b[0].shadow = a('<div class="menu-shadow"></div>').insertAfter(b); b[0].shadow.css({ display: "block", zIndex: a.fn.menu.defaults.zIndex++, left: b.css("left"), top: b.css("top"), width: b.outerWidth(), height: b.outerHeight() }); b.css("z-index", a.fn.menu.defaults.zIndex++); c && c() }) } function c(b) { if (!b) return; d(b); b.find("div.menu-item").each(function() { this.submenu && c(this.submenu); a(this).removeClass("menu-active") }); function d(a) { a[0].shadow && a[0].shadow.hide(); a.hide() } } a.fn.menu = function(c, d) { if (typeof c == "string") switch (c) { case "show": return this.each(function() { f(this, d) }); case "hide": return this.each(function() { b(this) }) } c = c || {}; return this.each(function() { var b = a.data(this, "menu"); if (b) a.extend(b.options, c); else { b = a.data(this, "menu", { options: a.extend({}, a.fn.menu.defaults, c) }); e(this) } a(this).css({ left: b.options.left, top: b.options.top }) }) }; a.fn.menu.defaults = { zIndex: 1.1e5, left: 0, top: 0, onShow: function() { }, onHide: function() { } } })(jQuery); (function(a) { function b(e) { var b = a.data(e, "menubutton").options, c = a(e); c.removeClass("m-btn-active m-btn-plain-active"); c.linkbutton(b); b.menu && a(b.menu).menu({ onShow: function() { c.addClass(b.plain == true ? "m-btn-plain-active" : "m-btn-active") }, onHide: function() { c.removeClass(b.plain == true ? "m-btn-plain-active" : "m-btn-active") } }); c.unbind(".menubutton"); if (b.disabled == false && b.menu) { c.bind("click.menubutton", function() { f(); return false }); var d = null; c.bind("mouseenter.menubutton", function() { d = setTimeout(function() { f() }, b.duration); return false }).bind("mouseleave.menubutton", function() { d && clearTimeout(d) }) } function f() { var d = c.offset().left; if (d + a(b.menu).outerWidth() + 5 > a(window).width()) d = a(window).width() - a(b.menu).outerWidth() - 5; a(".menu-top").menu("hide"); a(b.menu).menu("show", { left: d, top: c.offset().top + c.outerHeight() }); c.blur() } } a.fn.menubutton = function(c) { c = c || {}; return this.each(function() { var e = a.data(this, "menubutton"); if (e) a.extend(e.options, c); else { var d = a(this); a.data(this, "menubutton", { options: a.extend({}, a.fn.menubutton.defaults, { disabled: d.attr("disabled") ? d.attr("disabled") == "true" : undefined, plain: d.attr("plain") ? d.attr("plain") == "true" : undefined, menu: d.attr("menu"), duration: d.attr("duration") }, c) }); a(this).removeAttr("disabled"); a(this).append('<span class="m-btn-downarrow">&nbsp;</span>') } b(this) }) }; a.fn.menubutton.defaults = { disabled: false, plain: true, menu: null, duration: 100} })(jQuery); (function(a) {
                               function d(h, g, d, e) { var c = a(h).window("window"); if (!c) return; switch (g) { case null: c.show(); break; case "slide": c.slideDown(d); break; case "fade": c.fadeIn(d); break; case "show": c.show(d) } var f = null; if (e > 0) f = setTimeout(function() { b(h, g, d) }, e); c.hover(function() { f && clearTimeout(f) }, function() { if (e > 0) f = setTimeout(function() { b(h, g, d) }, e) }) } function b(d, e, c) { if (d.locked == true) return; d.locked = true; var b = a(d).window("window"); if (!b) return; switch (e) { case null: b.hide(); break; case "slide": b.slideUp(c); break; case "fade": b.fadeOut(c); break; case "show": b.hide(c) } setTimeout(function() { a(d).window("destroy") }, c) } function c(e, f, c) { var b = a('<div class="messager-body"></div>').appendTo("body"); b.append(f); if (c) { var g = a('<div class="messager-button"></div>').appendTo(b); for (var d in c) a("<a></a>").attr("href", "javascript:void(0)").text(d).css("margin-left", 10).bind("click", eval(c[d])).appendTo(g).linkbutton() } b.window({ title: e, width: 300, height: "auto", modal: true, collapsible: false, minimizable: false, maximizable: false, resizable: false, onClose: function() { setTimeout(function() { b.window("destroy") }, 100) } }); return b } a.messager = { show: function(f) { var c = a.extend({ showType: "slide", showSpeed: 600, width: 250, height: 100, msg: "", title: "", timeout: 4e3 }, f || {}), e = a('<div class="messager-body"></div>').html(c.msg).appendTo("body"); e.window({ title: c.title, width: c.width, height: c.height, collapsible: false, minimizable: false, maximizable: false, shadow: false, draggable: false, resizable: false, closed: true, onBeforeOpen: function() { d(this, c.showType, c.showSpeed, c.timeout); return false }, onBeforeClose: function() { b(this, c.showType, c.showSpeed); return false } }); e.window("window").css({ left: null, top: null, right: 0, bottom: -document.body.scrollTop - document.documentElement.scrollTop }); e.window("open") }, alert: function(h, i, g, d) { var b = "<div>" + i + "</div>"; switch (g) { case "error": b = '<div class="messager-icon messager-error"></div>' + b; break; case "info": b = '<div class="messager-icon messager-info"></div>' + b; break; case "question": b = '<div class="messager-icon messager-question"></div>' + b; break; case "warning": b = '<div class="messager-icon messager-warning"></div>' + b } b += '<div style="clear:both;"/>'; var e = {}; e[a.messager.defaults.ok] = function() { f.dialog({ closed: true }); if (d) { d(); return false } }; e[a.messager.defaults.ok] = function() { f.window("close"); if (d) { d(); return false } }; var f = c(h, b, e) }, confirm: function(f, h, b) { var g = '<div class="messager-icon messager-question"></div><div>' + h + '</div><div style="clear:both;"/>', d = {}; d[a.messager.defaults.ok] = function() { e.window("close"); if (b) { b(true); return false } }; d[a.messager.defaults.cancel] = function() { e.window("close"); if (b) { b(false); return false } }; var e = c(f, g, d) }, prompt: function(f, h, b) {
                                   var g = '<div class="messager-icon messager-question"></div><div>' + h + '</div><br/><input class="messager-input" type="text"/><div style="clear:both;"/>', d = {}; d[a.messager.defaults.ok] = function() { e.window("close"); if (b) { b(a(".messager-input", e).val()); return false } };
                                   d[a.messager.defaults.cancel] = function() { e.window("close"); if (b) { b(); return false } }; var e = c(f, g, d)
                               } 
                           }; a.messager.defaults = { ok: "Ok", cancel: "Cancel"}
                       })(jQuery); (function(a) {
                           function c(c) { var b = a.data(c, "numberbox").options, d = parseFloat(a(c).val()).toFixed(b.precision); if (isNaN(d)) { a(c).val(""); return } if (b.min != null && b.min != undefined && d < b.min) a(c).val(b.min.toFixed(b.precision)); else if (b.max != null && b.max != undefined && d > b.max) a(c).val(b.max.toFixed(b.precision)); else a(c).val(d) } function d(b) { a(b).unbind(".numberbox"); a(b).bind("keypress.numberbox", function(a) { return a.which == 45 ? true : a.which == 46 ? true : a.which >= 48 && a.which <= 57 && a.ctrlKey == false && a.shiftKey == false || a.which == 0 || a.which == 8 ? true : a.ctrlKey == true && (a.which == 99 || a.which == 118) ? true : false }).bind("paste.numberbox", function() { if (window.clipboardData) { var a = clipboardData.getData("text"); return !/\D/.test(a) ? true : false } else return false }).bind("dragenter.numberbox", function() { return false }).bind("blur.numberbox", function() { c(b) }) } function e(b) { if (a.fn.validatebox) { var c = a.data(b, "numberbox").options; a(b).validatebox(c) } } function b(b, d) { var c = a.data(b, "numberbox").options; if (d) { c.disabled = true; a(b).attr("disabled", true) } else { c.disabled = false; a(b).removeAttr("disabled") } } a.fn.numberbox = function(c) { if (typeof c == "string") switch (c) { case "disable": return this.each(function() { b(this, true) }); case "enable": return this.each(function() { b(this, false) }) } c = c || {}; return this.each(function() { var g = a.data(this, "numberbox"); if (g) a.extend(g.options, c); else { var f = a(this); g = a.data(this, "numberbox", { options: a.extend({}, a.fn.numberbox.defaults, { disabled: f.attr("disabled") ? true : undefined, min: f.attr("min") == "0" ? 0 : parseFloat(f.attr("min")) || undefined, max: f.attr("max") == "0" ? 0 : parseFloat(f.attr("max")) || undefined, precision: parseInt(f.attr("precision")) || undefined }, c) }); f.removeAttr("disabled"); a(this).css({ imeMode: "disabled" }) } b(this, g.options.disabled); d(this); e(this) }) };
                        a.fn.numberbox.defaults = { disabled: false, min: null, max: null, precision: 0} })(jQuery); (function(a) {
                           function e(e) {
                               var c = a.data(e, "pagination").options, f = a(e).addClass("pagination").empty(), k = a('<table cellspacing="0" cellpadding="0" border="0"><tr></tr></table>').appendTo(f), d = a("tr", k); 
                       if (c.showPageList) { for (var i = a('<select class="pagination-page-list"></select>'), g = 0; g < c.pageList.length; g++) a("<option></option>").text(c.pageList[g]).attr("selected", c.pageList[g] == c.pageSize ? "selected" : "").appendTo(i); a("<td></td>").append(i).appendTo(d); c.pageSize = parseInt(i.val()); a('<td><div class="pagination-btn-separator"></div></td>').appendTo(d) } a('<td><a href="javascript:void(0)" icon="pagination-first"></a></td>').appendTo(d); a('<td><a href="javascript:void(0)" icon="pagination-prev"></a></td>').appendTo(d); a('<td><div class="pagination-btn-separator"></div></td>').appendTo(d); a('<span style="padding-left:6px;"></span>').html(c.beforePageText).wrap("<td></td>").parent().appendTo(d); a('<td><input class="pagination-num" type="text" value="1" size="2"></td>').appendTo(d); a('<span style="padding-right:6px;"></span>').wrap("<td></td>").parent().appendTo(d); a('<td><div class="pagination-btn-separator"></div></td>').appendTo(d); a('<td><a href="javascript:void(0)" icon="pagination-next"></a></td>').appendTo(d); a('<td><a href="javascript:void(0)" icon="pagination-last"></a></td>').appendTo(d); if (c.showRefresh) { a('<td><div class="pagination-btn-separator"></div></td>').appendTo(d); a('<td><a href="javascript:void(0)" icon="pagination-load"></a></td>').appendTo(d) } if (c.buttons) { a('<td><div class="pagination-btn-separator"></div></td>').appendTo(d); for (var g = 0; g < c.buttons.length; g++) { var h = c.buttons[g]; if (h == "-") a('<td><div class="pagination-btn-separator"></div></td>').appendTo(d); else { var j = a("<td></td>").appendTo(d); a('<a href="javascript:void(0)"></a>').addClass("l-btn").css("float", "left").text(h.text || "").attr("icon", h.iconCls || "").bind("click", eval(h.handler || function() { })).appendTo(j).linkbutton({ plain: true }) } } } a('<div class="pagination-info"></div>').appendTo(f); a('<div style="clear:both;"></div>').appendTo(f); a("a[icon^=pagination]", f).linkbutton({ plain: true }); f.find("a[icon=pagination-first]").unbind(".pagination").bind("click.pagination", function() { c.pageNumber > 1 && b(e, 1) }); f.find("a[icon=pagination-prev]").unbind(".pagination").bind("click.pagination", function() { c.pageNumber > 1 && b(e, c.pageNumber - 1) }); f.find("a[icon=pagination-next]").unbind(".pagination").bind("click.pagination", function() { var a = Math.ceil(c.total / c.pageSize); c.pageNumber < a && b(e, c.pageNumber + 1) }); f.find("a[icon=pagination-last]").unbind(".pagination").bind("click.pagination", function() { var a = Math.ceil(c.total / c.pageSize); c.pageNumber < a && b(e, a) }); f.find("a[icon=pagination-load]").unbind(".pagination").bind("click.pagination", function() { if (c.onBeforeRefresh.call(e, c.pageNumber, c.pageSize) != false) { b(e, c.pageNumber); c.onRefresh.call(e, c.pageNumber, c.pageSize) } }); f.find("input.pagination-num").unbind(".pagination").bind("keydown.pagination", function(d) { if (d.keyCode == 13) { var c = parseInt(a(this).val()) || 1; b(e, c) } }); f.find(".pagination-page-list").unbind(".pagination").bind("change.pagination", function() { c.pageSize = a(this).val(); c.onChangePageSize.call(e, c.pageSize); var d = Math.ceil(c.total / c.pageSize); b(e, c.pageNumber) }) } function b(f, e) { var b = a.data(f, "pagination").options, g = Math.ceil(b.total / b.pageSize), d = e; if (e < 1) d = 1; if (e > g) d = g; b.onSelectPage.call(f, d, b.pageSize); b.pageNumber = d; c(f) } function c(c) { var b = a.data(c, "pagination").options, e = Math.ceil(b.total / b.pageSize), f = a(c).find("input.pagination-num"); f.val(b.pageNumber); f.parent().next().find("span").html(b.afterPageText.replace(/{pages}/, e)); var d = b.displayMsg; d = d.replace(/{from}/, b.pageSize * (b.pageNumber - 1) + 1); d = d.replace(/{to}/, Math.min(b.pageSize * b.pageNumber, b.total)); d = d.replace(/{total}/, b.total); a(c).find(".pagination-info").html(d); a("a[icon=pagination-first],a[icon=pagination-prev]", c).linkbutton({ disabled: b.pageNumber == 1 }); a("a[icon=pagination-next],a[icon=pagination-last]", c).linkbutton({ disabled: b.pageNumber == e }); if (b.loading) a(c).find("a[icon=pagination-load]").find(".pagination-load").addClass("pagination-loading"); else a(c).find("a[icon=pagination-load]").find(".pagination-load").removeClass("pagination-loading") } function d(b, d) { var c = a.data(b, "pagination").options; c.loading = d; if (c.loading) a(b).find("a[icon=pagination-load]").find(".pagination-load").addClass("pagination-loading"); else a(b).find("a[icon=pagination-load]").find(".pagination-load").removeClass("pagination-loading") } a.fn.pagination = function(b) { if (typeof b == "string") switch (b) { case "options": return a.data(this[0], "pagination").options; case "loading": return this.each(function() { d(this, true) }); case "loaded": return this.each(function() { d(this, false) }) } b = b || {}; return this.each(function() { var d, f = a.data(this, "pagination"); if (f) d = a.extend(f.options, b); else { d = a.extend({}, a.fn.pagination.defaults, b); a.data(this, "pagination", { options: d }) } e(this); c(this) }) }; a.fn.pagination.defaults = { total: 1, pageSize: 10, pageNumber: 1, pageList: [10, 20, 30, 50], loading: false, buttons: null, showPageList: true, showRefresh: true, onSelectPage: function() { }, onBeforeRefresh: function() { }, onRefresh: function() { }, onChangePageSize: function() { }, beforePageText: "Page", afterPageText: "of {pages}", displayMsg: "Displaying {from} to {to} of {total} items"} })(jQuery); (function(a) {
                       function c(b) {
                           b.each(function() {
                               a(this).remove();
                               if (a.browser.msie) this.outerHTML = ""
                           })
                       }
                       function b(g, e) {
                           var c = a.data(g, "panel").options,
                           b = a.data(g, "panel").panel,
                           f = b.find(">div.panel-header"),
                           d = b.find(">div.panel-body");
                           if (e) {
                               if (e.width) c.width = e.width;
                               if (e.height) c.height = e.height;
                               if (e.left != null) c.left = e.left;
                               if (e.top != null) c.top = e.top
                           }
                           if (c.fit == true) {
                               var h = b.parent();
                               c.width = h.width(); 
                               c.height = h.height()
                           }
                           b.css({ left: c.left, top: c.top });
                           b.css(c.style);
                           b.addClass(c.cls);
                           f.addClass(c.headerCls);
                           d.addClass(c.bodyCls);
                           if (!isNaN(c.width)) 
                           if (a.boxModel == true) {
                               b.width(c.width - (b.outerWidth() - b.width()));
                               f.width(b.width() - (f.outerWidth() - f.width()));
                               d.width(b.width() - (d.outerWidth() - d.width()))
                           }
                           else {
                               b.width(c.width);
                               f.width(b.width());
                               d.width(b.width())
                           }
                           else {
                               b.width("auto");
                               d.width("auto")
                           }
                           if (!isNaN(c.height))
                               if (a.boxModel == true) {
                                   b.height(c.height - (b.outerHeight() - b.height()));
                                   d.height(b.height() - f.outerHeight() - (d.outerHeight() - d.height()))
                               }
                               else {
                                   b.height(c.height);
                                   d.height(b.height() - f.outerHeight())
                               }
                               else d.height("auto");
                               b.css("height", null);
                               c.onResize.apply(g, [c.width, c.height]);
                               b.find(">div.panel-body>div").triggerHandler("_resize")
                           }
                           function j(d, c) {
                               var b = a.data(d, "panel").options,
                           e = a.data(d, "panel").panel;
                               if (c) {
                                   if (c.left != null) b.left = c.left;
                                   if (c.top != null) b.top = c.top
                               } e.css({ left: b.left, top: b.top });
                               b.onMove.apply(d, [b.left, b.top])
                           }
                           function k(c) {
                               var d = a(c).addClass("panel-body").wrap('<div class="panel"></div>').parent();
                               d.bind("_resize", function() {
                               var d = a.data(c, "panel").options; d.fit == true && b(c); return false
                           });
                           return d
                       }
                       function l(e) {
                           var b = a.data(e, "panel").options,
                           k = a.data(e, "panel").panel; c(k.find(">div.panel-header"));
                           if (b.title) {
                               var l = a('<div class="panel-header"><div class="panel-title">' + b.title + "</div></div>").prependTo(k);
                               if (b.iconCls) {
                                   l.find(".panel-title").addClass("panel-with-icon");
                                   a('<div class="panel-icon"></div>').addClass(b.iconCls).appendTo(l)
                               }
                               var f = a('<div class="panel-tool"></div>').appendTo(l);
                               b.closable && a('<div class="panel-tool-close"></div>').appendTo(f).bind("click", m);
                               b.maximizable && a('<div class="panel-tool-max"></div>').appendTo(f).bind("click", p);
                               b.minimizable && a('<div class="panel-tool-min"></div>').appendTo(f).bind("click", q);
                               b.collapsible && a('<div class="panel-tool-collapse"></div>').appendTo(f).bind("click", r);
                               if (b.tools)
                                   for (var j = b.tools.length - 1; j >= 0; j--) {
                                       var s = a("<div></div>").addClass(b.tools[j].iconCls).appendTo(f);
                                       b.tools[j].handler && s.bind("click",
                            eval(b.tools[j].handler))
                                   } f.find("div").hover(function() { a(this).addClass("panel-tool-over") },
                            function() { a(this).removeClass("panel-tool-over") });
                                   k.find(">div.panel-body").removeClass("panel-body-noheader")
                               } else k.find(">div.panel-body").addClass("panel-body-noheader");
                               function r() {
                                   if (a(this).hasClass("panel-tool-expand")) n(e, true);
                                   else g(e, true); return false
                               }
                               function q() { i(e); return false }
                               function p() {
                                   if (a(this).hasClass("panel-tool-restore")) o(e); else h(e);
                                   return false
                               } function m() { d(e); return false } 
                           }
                           function e(d) {
                               var b = a.data(d, "panel");
                               if (b.options.href && !b.isLoaded) {
                                   b.isLoaded = false;
                                   var c = b.panel.find(">.panel-body");
                                   c.html(a('<div class="panel-loading"></div>').html(b.options.loadingMessage));
                                   c.load(b.options.href, null,
                              function() {
                                  a.parser && a.parser.parse(c);
                                  b.options.onLoad.apply(d, arguments); 
                                  b.isLoaded = true
                              })
                          } 
                              }
                           function f(b, d) {
                               var c = a.data(b, "panel").options,
                               e = a.data(b, "panel").panel;
                               if (d != true) if (c.onBeforeOpen.call(b) == false) return; 
                               e.show();
                               c.closed = false;
                               c.onOpen.call(b)
                           }
                           function d(b, d) {
                               var c = a.data(b, "panel").options,
                           e = a.data(b, "panel").panel;
                               if (
                               d != true) if (c.onBeforeClose.call(b) == false) return;
                               e.hide();
                               c.closed = true; c.onClose.call(b)
                           }
                           function m(b, e) {
                               var d = a.data(b, "panel").options,
                               f = a.data(b, "panel").panel;
                               if (e != true)
                                   if (d.onBeforeDestroy.call(b) == false) return;
                                   c(f);
                                   d.onDestroy.call(b)
                               }

                          function g(c, f) {
                              var b = a.data(c, "panel").options,
                           e = a.data(c, "panel").panel,
                           d = e.find(">div.panel-body");
                              d.stop(true, true);
                              if (b.onBeforeCollapse.call(c) == false) return;
                              e.find(">div.panel-header .panel-tool-collapse").addClass("panel-tool-expand");
                              if (f == true) d.slideUp("normal",
                           function() {
                               b.collapsed = true;
                               b.onCollapse.call(c)
                           });
                           else {
                               d.hide();
                               b.collapsed = true;
                               b.onCollapse.call(c)
                           } 
                       }
                       function n(c, f) {
                           var b = a.data(c, "panel").options,
                           e = a.data(c, "panel").panel,
                           d = e.find(">div.panel-body");
                           d.stop(true, true);
                           if (b.onBeforeExpand.call(c) == false) return;
                           e.find(">div.panel-header .panel-tool-collapse").removeClass("panel-tool-expand");
                           if (f == true) d.slideDown("normal",
                           function() { b.collapsed = false; b.onExpand.call(c) });
                           else { d.show(); b.collapsed = false; b.onExpand.call(c) } 
                       }
                       function h(d) {
                           var c = a.data(d, "panel").options,
                           e = a.data(d, "panel").panel;
                           e.find(">div.panel-header .panel-tool-max").addClass("panel-tool-restore");
                           a.data(d, "panel").original = { width: c.width, height: c.height, left: c.left, top: c.top, fit: c.fit };
                           c.left = 0;
                           c.top = 0;
                           c.fit = true;
                           b(d);
                           c.minimized = false;
                           c.maximized = true;
                           c.onMaximize.call(d)
                       }
                       function i(c) {
                           var b = a.data(c, "panel").options,
                        d = a.data(c, "panel").panel;
                           d.hide();
                           b.minimized = true;
                           b.maximized = false;
                           b.onMinimize.call(c)
                       }
                       function o(d) {
                           var c = a.data(d, "panel").options,
                        f = a.data(d, "panel").panel; f.show();
                           f.find(">div.panel-header .panel-tool-max").removeClass("panel-tool-restore");
                           var e = a.data(d, "panel").original;
                           c.width = e.width; c.height = e.height;
                           c.left = e.left; c.top = e.top;
                           c.fit = e.fit; 
                           b(d);
                           c.minimized = false;
                           c.maximized = false;
                           c.onRestore.call(d)
                       }
                       function p(c) {
                           var d = a.data(c, "panel").options,
                           b = a.data(c, "panel").panel;
                           if (d.border == true) {
                               b.find(">div.panel-header").removeClass("panel-header-noborder");
                               b.find(">div.panel-body").removeClass("panel-body-noborder")
                           }
                           else {
                               b.find(">div.panel-header").addClass("panel-header-noborder");
                               b.find(">div.panel-body").addClass("panel-body-noborder")
                           } 
                       }
                       function q(b, c) {
                           a.data(b, "panel").options.title = c;
                           a(b).panel("header").find("div.panel-title").html(c)
                       }
                       a.fn.panel = function(c, n) {
                           if (typeof c == "string") switch (c) {
                               case "options": return a.data(this[0], "panel").options;
                               case "panel": return a.data(this[0], "panel").panel;
                               case "header": return a.data(this[0], "panel").panel.find(">div.panel-header");
                               case "body": return a.data(this[0], "panel").panel.find(">div.panel-body");
                               case "setTitle": return this.each(function() { q(this, n) });
                               case "open": return this.each(function() { f(this, n) });
                               case "close": return this.each(function() { d(this, n) });
                               case "destroy": return this.each(function() { m(this, n) });
                               case "refresh": return this.each(function() {
                                   a.data(this, "panel").isLoaded = false;
                                   e(this)
                               });
                           case "resize": return this.each(function() { b(this, n) });
                           case "move": return this.each(function() { j(this, n) })
                       } c = c || {};
                       return this.each(function() {
                           var m = a.data(this, "panel"), j;
                           if (m) j = a.extend(m.options, c);
                           else {
                               var d = a(this);
                               j = a.extend({},
                         a.fn.panel.defaults, {
                               width: parseInt(d.css("width")) || undefined,
                               height: parseInt(d.css("height")) || undefined,
                               left: parseInt(d.css("left")) || undefined,
                               top: parseInt(d.css("top")) || undefined,
                               title: d.attr("title"), iconCls: d.attr("icon"),
                               cls: d.attr("cls"), headerCls: d.attr("headerCls"),
                               bodyCls: d.attr("bodyCls"), 
                               href: d.attr("href"),
                               fit: d.attr("fit") ? d.attr("fit") == "true" : undefined,
                               border: d.attr("border") ? d.attr("border") == "true" : undefined,
                               collapsible: d.attr("collapsible") ? d.attr("collapsible") == "true" : undefined,
                               minimizable: d.attr("minimizable") ? d.attr("minimizable") == "true" : undefined,
                               maximizable: d.attr("maximizable") ? d.attr("maximizable") == "true" : undefined,
                               closable: d.attr("closable") ? d.attr("closable") == "true" : undefined,
                               collapsed: d.attr("collapsed") ? d.attr("collapsed") == "true" : undefined,
                               minimized: d.attr("minimized") ? d.attr("minimized") == "true" : undefined,
                               maximized: d.attr("maximized") ? d.attr("maximized") == "true" : undefined,
                               closed: d.attr("closed") ? d.attr("closed") == "true" : undefined
                           }, c);
                           d.attr("title", "");
                           m = a.data(this, "panel", { options: j, panel: k(this), isLoaded: false })
                       }
                       l(this);
                       p(this);
                       e(this);
                       if (j.doSize == true) {
                           m.panel.css("display", "block");
                           b(this)
                       }
                       if (j.closed == true) m.panel.hide();
                       else {
                           f(this); j.maximized == true && h(this);
                           j.minimized == true && i(this); j.collapsed == true && g(this)
                       } 
                   })
               };
               a.fn.panel.defaults = {
               title: null,
               iconCls: null,
               width: "auto",
               height: "auto",
               left: null,
               top: null,
               cls: null,
               headerCls: null,
               bodyCls: null,
               style: {},
               fit: false,
               border: true,
               doSize: true,
               collapsible: false,
               minimizable: false,
               maximizable: false,
               closable: false,
               collapsed: false,
               minimized: false,
               maximized: false,
               closed: false,
               tools: [],
               href: null,
               loadingMessage: "Loading...",
               onLoad: function() { },
               onBeforeOpen: function() { },
               onOpen: function() { },
               onBeforeClose: function() { },
               onClose: function() { },
               onBeforeDestroy: function() { },
               onDestroy: function() { },
               onResize: function() { },
               onMove: function() { },
               onMaximize: function() { },
               onRestore: function() { },
               onMinimize: function() { },
               onBeforeCollapse: function() { },
               onBeforeExpand: function() { },
               onCollapse: function() { },
               onExpand: function() { }
           }

       })(jQuery);
       (function(a) {
           a.parser =
                   { auto: true,
                       plugins: ["linkbutton", "menu", "menubutton", "splitbutton", "layout", "panel", "tabs", "tree", "window", "dialog", "datagrid", "combobox", "combotree", "numberbox", "validatebox", "calendar", "datebox"],
                       parse: function(c) {
                       if (a.parser.auto)
                           for (var b = 0; b < a.parser.plugins.length; b++)
                               (function() {
                                   var d = a.parser.plugins[b], e = a(".easyui-" + d, c);
                                   if (e.length) if (e[d]) e[d]();
                                   else window.easyloader && easyloader.load(d,
                   function() { 
                   e[d]() })
                               })()
                           } 
                       };
                       a(function() { a.parser.parse() })
                   }
                   )(jQuery); 
        (function(a) {
                a.fn.resizable = function(b) {
                 function c(d) {
                     var b = d.data,
                     c = a.data(b.target, "resizable").options;
                     if (b.dir.indexOf("e") != -1) {
                         var e = b.startWidth + d.pageX - b.startX;
                         e = Math.min(Math.max(e, c.minWidth), c.maxWidth);
                         b.width = e
                     }
                     if (b.dir.indexOf("s") != -1) {
                         var f = b.startHeight + d.pageY - b.startY;
                         f = Math.min(Math.max(f, c.minHeight), c.maxHeight); 
                         b.height = f
                     }
                     if (b.dir.indexOf("w") != -1) {
                         b.width = b.startWidth - d.pageX + b.startX;
                         if (b.width >= c.minWidth && b.width <= c.maxWidth) b.left = b.startLeft + d.pageX - b.startX
                     }
                     if (b.dir.indexOf("n") != -1) {
                         b.height = b.startHeight - d.pageY + b.startY;
                         if (b.height >= c.minHeight && b.height <= c.maxHeight) b.top = b.startTop + d.pageY - b.startY
                     } 
                 }
                 function d(d) {
                     var b = d.data, c = b.target;
                     if (a.boxModel == true) a(c).css({ 
                     width: b.width - b.deltaWidth,
                     height: b.height - b.deltaHeight,
                     left: b.left, top: b.top
                 });
                 else a(c).css({
                 width: b.width,
                 height: b.height,
                 left: b.left,
                 top: b.top
             })
         }
         function f(b) {
             a.data(b.data.target, "resizable").options.onStartResize.call(b.data.target, b);
             return false
         }
         function g(b) {
             c(b);
             a.data(b.data.target, "resizable").options.onResize.call(b.data.target, b) != false && d(b);
             return false
         }
         function e(b) {
             c(b, true);
             d(b);
             a(document).unbind(".resizable");
             a.data(b.data.target, "resizable").options.onStopResize.call(b.data.target, b); return false
         } 
          return this.each(function() {
                                   var d = null, i = a.data(this, "resizable"); 
                                   if (i) { a(this).unbind(".resizable"); 
                                   d = a.extend(i.options, b || {}) } else d = a.extend({}, 
                                   a.fn.resizable.defaults, b || {}); 
                                   if (d.disabled == true) return; 
                                   a.data(this, "resizable", { options: d }); 
                                   var c = this; a(this).bind("mousemove.resizable", k).bind("mousedown.resizable", l);
                                   function k(d) {
                                       var b = j(d);
                                       if (b == "") a(c).css("cursor", "default");
                                       else a(c).css("cursor", b + "-resize")
                                   } 
                                    function l(d) {
                                       var i = j(d); if (i == "") return;
                                       var b = { target: this, dir: i, startLeft: h("left"),
                                       startTop:
                                       h("top"),
                                       left: h("left"),
                                       top: h("top"),
                                       startX: d.pageX,
                                       startY: d.pageY,
                                       startWidth: a(c).outerWidth(),
                                       startHeight: a(c).outerHeight(),
                                       width: a(c).outerWidth(),
                                       height: a(c).outerHeight(),
                                       deltaWidth: a(c).outerWidth() - a(c).width(),
                                       deltaHeight: a(c).outerHeight() - a(c).height()
                                   };
                                   a(document).bind("mousedown.resizable", b, f);
                                   a(document).bind("mousemove.resizable", b, g);
                                   a(document).bind("mouseup.resizable", b, e)
                               }
                               function j(e) {
                                   var f = "",
                          b = a(c).offset(),
                           i = a(c).outerWidth(),
                           j = a(c).outerHeight(),
                           g = d.edge;
                                   if (e.pageY > b.top && e.pageY < b.top + g) f += "n";
                                   else if (e.pageY < b.top + j && e.pageY > b.top + j - g) f += "s";
                                   if (e.pageX > b.left && e.pageX < b.left + g) f += "w";
                                   else if (e.pageX < b.left + i && e.pageX > b.left + i - g) f += "e";
                                   for (var k = d.handles.split(","), h = 0; h < k.length; h++) {
                                       var l = k[h].replace(/(^\s*)|(\s*$)/g, "");
                                       if (l == "all" || l == f) return f
                                   } return ""
                               }
                               function h(d) {
                                   var b = parseInt(a(c).css(d));
                                   return isNaN(b) ? 0 : b
                               }
                                
                           })
                       };
                       a.fn.resizable.defaults = { disabled: false,
                       handles: "n, e, s, w, ne, se, sw, nw, all", 
                       minWidth: 10, minHeight: 10,
                       maxWidth: 1e4, maxHeight: 1e4, edge: 5,
                       onStartResize: function() { }, onResize: function() { },
                       onStopResize: function() { } }
                   })(jQuery);
                   (function(a) {
                       function b(f) {
                           var b = a.data(f, "splitbutton").options;
                           b.menu && a(b.menu).menu({ 
                           onShow: function() { c.addClass(b.plain == true ? "s-btn-plain-active" : "s-btn-active") },
                           onHide: function() { c.removeClass(b.plain == true ? "s-btn-plain-active" : "s-btn-active") } 
                       });
                       var c = a(f);
                        c.removeClass("s-btn-active s-btn-plain-active");
                       c.linkbutton(b); 
                       var d = c.find(".s-btn-downarrow");
                       d.unbind(".splitbutton"); 
                       if (b.disabled == false && b.menu) {
                           d.bind("click.splitbutton", 
                           function() { g(); return false });
                           var e = null;
                           d.bind("mouseenter.splitbutton", function() {
                           e = setTimeout(function() { g() }, b.duration);
                           return false
                       }).bind("mouseleave.splitbutton", function() { e && clearTimeout(e) })
                   }
                   function g() {
                       var d = c.offset().left;
                       if (d + a(b.menu).outerWidth() + 5 > a(window).width()) d = a(window).width() - a(b.menu).outerWidth() - 5;
                       a(".menu-top").menu("hide");
                       a(b.menu).menu("show", { left: d, top: c.offset().top + c.outerHeight() });
                       c.blur()
                   } 
               }
               a.fn.splitbutton = function(c) {
                   c = c || {};
                   return this.each(function() {
                       var e = a.data(this, "splitbutton");
                       if (e) a.extend(e.options, c);
                       else {
                           var d = a(this);
                           a.data(this, "splitbutton", { options: a.extend({},
                     a.fn.splitbutton.defaults, { disabled: d.attr("disabled") ? d.attr("disabled") == "true" : undefined,
                           plain: d.attr("plain") ? d.attr("plain") == "true" : undefined, menu: d.attr("menu"),
                           duration: d.attr("duration")
                       }, c)
                   });
                   a(this).removeAttr("disabled");
                   a(this).append('<span class="s-btn-downarrow">&nbsp;</span>')
               } b(this)
           })
       };
       a.fn.splitbutton.defaults = { disabled: false, menu: null, plain: true, duration: 100}
   })(jQuery); 
                     (function(a) {
                             function h(d, e) {
                                 var c = 0,
                             b = true;
                                 a(">div.tabs-header ul.tabs li", d).each(function() {
                                     if (this == e) b = false;
                                     if (b == true) c += a(this).outerWidth(true)
                                 }
                                );

                                 return c
                             }
                             function c(d) {
                                 var b = a(">div.tabs-header", d),
                                c = 0;
                                 a("ul.tabs li", b).each(function() {
                                     c += a(this).outerWidth(true)
                                 });
                                 var e = a(".tabs-wrap", b).width(), f = parseInt(a(".tabs", b).css("padding-left"));
                                 return c - e + f
                             }
                             function i(d) {
                                 var b = a(">div.tabs-header", d),
                            c = 0;
                                 a("ul.tabs li", b).each(function() {
                                     c += a(this).outerWidth(true)
                                 }
                            );

                                 if (c > b.width()) {
                                     a(".tabs-scroller-left", b).css("display", "block");
                                     a(".tabs-scroller-right", b).css("display", "block");
                                     a(".tabs-wrap", b).addClass("tabs-scrolling");
                                     if (a.boxModel == true) a(".tabs-wrap", b).css("left", 2);
                                     else a(".tabs-wrap", b).css("left", 0);
                                     var e = b.width() - a(".tabs-scroller-left", b).outerWidth() - a(".tabs-scroller-right", b).outerWidth();
                                     a(".tabs-wrap", b).width(e)
                                 } else {
                                     a(".tabs-scroller-left", b).css("display", "none");
                                     a(".tabs-scroller-right", b).css("display", "none");
                                     a(".tabs-wrap", b).removeClass("tabs-scrolling").scrollLeft(0);
                                     a(".tabs-wrap", b).width(b.width());
                                     a(".tabs-wrap", b).css("left", 0)
                                 }
                             }

                             function b(d) {
                                 var c = a.data(d, "tabs").options, f = a(d);
                                 if (c.fit == true) {
                                     var k = f.parent();
                                     c.width = k.width();
                                     c.height = k.height()
                                 }
                                 f.width(c.width).height(c.height);
                                 var e = a(">div.tabs-header", d);

                                 if (a.boxModel == true) {
                                     var g = e.outerWidth() - e.width();
                                     e.width(f.width() - g)
                                 }
                                 else e.width(f.width()); i(d);

                                 var b = a(">div.tabs-panels", d),
                             h = c.height;
                                 if (!isNaN(h)) if (a.boxModel == true) {
                                     var g = b.outerHeight() - b.height();
                                     b.css("height", h - e.outerHeight() - g || "auto")
                                 }
                                 else b.css("height", h - e.outerHeight());

                                 else b.height("auto");
                                 var j = c.width;
                                 if (!isNaN(j)) if (a.boxModel == true) {
                                     var g = b.outerWidth() - b.width(); b.width(j - g)
                                 } else b.width(j);
                                 else b.width("auto"); a.parser && a.parser.parse(d)
                             }

                             function d(d) {
                                 var e = a(">div.tabs-header ul.tabs li.tabs-selected", d);
                                 if (e.length) {
                                     var f = a.data(e[0], "tabs.tab").id, b = a("#" + f),
                                c = a(">div.tabs-panels", d);
                                     if (c.css("height").toLowerCase() != "auto") if (a.boxModel == true) {
                                         b.height(c.height() - (b.outerHeight() - b.height())); b.width(c.width() - (b.outerWidth() - b.width()))
                                     }
                                     else {
                                         b.height(c.height());
                                         b.width(c.width())
                                     } a(">div", b).triggerHandler("_resize")
                                 }
                             }
                             function j(c) {
                                 a(c).addClass("tabs-container");
                                 a(c).wrapInner('<div class="tabs-panels"/>');
                                 a('<div class="tabs-header"><div class="tabs-scroller-left"></div><div class="tabs-scroller-right"></div><div class="tabs-wrap"><ul class="tabs"></ul></div></div>').prependTo(c);
                                 var e = a(">div.tabs-header", c);
                                 a(">div.tabs-panels>div", c).each(function() {
                                     !a(this).attr("id") && a(this).attr("id", "gen-tabs-panel" + a.fn.tabs.defaults.idSeed++);
                                     var b = {
                                         id: a(this).attr("id"),
                                         title: a(this).attr("title"),
                                         content: null,
                                         href: a(this).attr("href"),
                                         closable: a(this).attr("closable") == "true",
                                         icon: a(this).attr("icon"),
                                         selected: a(this).attr("selected") == "true",
                                         cache: a(this).attr("cache") == "false" ? false : true
                                     };
                                     a(this).attr("title", "");

                                     f(c, b)
                                 });
                                 a(".tabs-scroller-left, .tabs-scroller-right", e).hover(function() {
                                     a(this).addClass("tabs-scroller-over")
                                 },
                    function() {
                        a(this).removeClass("tabs-scroller-over")
                    });
                                 a(c).bind("_resize", function() {
                                     var e = a.data(c, "tabs").options;
                                     if (e.fit == true) { b(c); d(c) } return false
                                 })
                             }
                             function k(f) {
                                 var e = a.data(f, "tabs").options,
                                b = a(">div.tabs-header", f),
                                j = a(">div.tabs-panels", f),
                                i = a("ul.tabs", b);
                                 lia = a("li", i).first();
                                 lia.css("display", "none");

                                 if (e.plain == true) b.addClass("tabs-header-plain");
                                 else b.removeClass("tabs-header-plain");
                                 if (e.border == true) {
                                     b.removeClass("tabs-header-noborder");
                                     j.removeClass("tabs-panels-noborder")
                                 }
                                 else {
                                     b.addClass("tabs-header-noborder");
                                     j.addClass("tabs-panels-noborder")
                                 }
                                 a("li", i).unbind(".tabs").bind("click.tabs", function() {
                                     a(".tabs-selected", i).removeClass("tabs-selected");




                                     a(this).addClass("tabs-selected");
                                     a(this).blur();
                                     var pandiv = a(">div.tabs-panels>div", f);
                                     pandiv.css("display", "none");
                                     var j = a(".tabs-wrap", b),
                                                    m = h(f, this),
                                                    l = m - j.scrollLeft(),
                                                    n = l + a(this).outerWidth();
                                     if (l < 0 || n > j.innerWidth()) {
                                         var o = Math.min(m - (j.width() - a(this).width()) / 2, c(f));
                                         j.animate({ scrollLeft: o }, e.scrollDuration)
                                     }
                                     var g = a.data(this, "tabs.tab"),
                                      k = a("#" + g.id);

                                     if (g.id == 'gen-tabs-panel0') {
                                         k.css("display", "none");

                                     }
                                     else {
                                         k.css("display", "block");
                                     }
                                     //var kchild = a("#" + g.id + '>div>iframe')[0].contentDocument

                                     var kchild = a('>div', k)
                                     kchild.addClass("tabswith");

                                     g.href && (!g.loaded || !g.cache) && k.load(g.href, null, function() {
                                         a.parser && a.parser.parse(k); e.onLoad.apply(this, arguments);
                                         g.loaded = true
                                     });
                                     d(f); e.onSelect.call(k, g.title)
                                 });
                                 a("a.tabs-close", i).unbind(".tabs").bind("click.tabs", function() {
                                     var b = a(this).parent()[0], c = a.data(b, "tabs.tab"); g(f, c.title)
                                 });
                                 a(".tabs-scroller-left", b).unbind(".tabs").bind("click.tabs", function() {
                                     var c = a(".tabs-wrap", b),
                                d = c.scrollLeft() - e.scrollIncrement;
                                     c.animate({ scrollLeft: d }, e.scrollDuration)
                                 });
                                 a(".tabs-scroller-right", b).unbind(".tabs").bind("click.tabs", function() {
                                     var d = a(".tabs-wrap", b),
                                g = Math.min(d.scrollLeft() + e.scrollIncrement, c(f));
                                     d.animate({ scrollLeft: g }, e.scrollDuration)
                                 })
                             }
                             function f(g, b) {

                                 var h = a(">div.tabs-header", g),
                                f = a("ul.tabs", h),
                                d = a("<li></li>"),
                                c = a("<span></span>").html(b.title),

                                e = a('<a class="tabs-inner"></a>').attr("href", "javascript:void(0)").append(c);

                                 d.append(e).appendTo(f);
                                 if (b.title == "") {
                                     c.addClass("tabswith");
                                 }
                                 if (b.closable) {
                                     c.addClass("tabs-closable");
                                     e.after('<a href="javascript:void(0)" class="tabs-close"></a>')
                                 }
                                 if (b.icon) {
                                     c.addClass("tabs-with-icon");
                                     c.after(a("<span/>").addClass("tabs-icon").addClass(b.icon))
                                 }
                                 b.selected && d.addClass("tabs-selected");
                                 b.content && a("#" + b.id).html(b.content);
                                 a("#" + b.id).removeAttr("title"); a.data(d[0], "tabs.tab", {
                                     id: b.id, title: b.title, href: b.href, loaded: false, cache: b.cache
                                 })

                             }
                             function l(c, b) {
                                 b = a.extend(
                                              {
                                                  id: null,
                                                  title: "",
                                                  content: "",
                                                  href: null,
                                                  cache: true,
                                                  icon: null,
                                                  closable: false,
                                                  selected: true,
                                                  height: "auto",
                                                  width: "auto"
                                              },
                                               b || {}
                                            );
                                 b.selected && a(".tabs-header .tabs-wrap .tabs li", c).removeClass("tabs-selected");
                                 b.id = b.id || "gen-tabs-panel" + a.fn.tabs.defaults.idSeed++;
                                 var adiv = a("<div></div>").attr("id", b.id).attr("title", b.title).height(b.height).width(b.width).appendTo(a(">div.tabs-panels", c));
                                 f(c, b)
                             }
                             function g(d, k) {
                                 var g = a.data(d, "tabs").options,
                               f = a('>div.tabs-header li:has(a span:contains("' + k + '"))', d)[0];
                                 if (!f) return;
                                 var i = a.data(f, "tabs.tab"),
                               j = a("#" + i.id);
                                 if (g.onClose.call(j, i.title) == false) return;
                                 var l = a(f).hasClass("tabs-selected");
                                 a.removeData(f, "tabs.tab");
                                 a(f).remove();
                                 j.remove();
                                 b(d);
                                 if (l) e(d);
                                 else {
                                     var h = a(">div.tabs-header .tabs-wrap", d),
                                   m = Math.min(h.scrollLeft(),
                                   c(d));
                                     h.animate({ scrollLeft: m }, g.scrollDuration)
                                 }
                             }
                             function e(d, e) {
                                 if (e) {
                                     var c = a('>div.tabs-header li:has(a span:contains("' + e + '"))', d)[0];
                                     c && a(c).trigger("click")
                                 } else {
                                     var b = a(">div.tabs-header ul.tabs", d);
                                     if (a(".tabs-selected", b).length == 0) a("li:first", b).trigger("click");
                                     else a(".tabs-selected", b).trigger("click")
                                 }
                             }

                             function m(b, c) {
                                 return a('>div.tabs-header li:has(a span:contains("' + c + '"))', b).length > 0
                             }

                             a.fn.tabs = function(c, f) {
                                 if (typeof c == "string") switch (c) {
                                     case "resize": return this.each(
                                            function() {
                                                b(this);
                                                d(this)
                                            });
                                     case "add": return this.each(
                                           function() {
                                               l(this, f);
                                               a(this).tabs();

                                           });
                                     case "close": return this.each(
                                          function() {
                                              g(this, f)
                                          });
                                     case "select": return this.each(
                                        function() {
                                            e(this, f)
                                        });
                                     case "exists": return m(this[0], f)
                                 } c = c || {};

                                 return this.each(function() {
                                     var g = a.data(this, "tabs"), f;
                                     if (g) { f = a.extend(g.options, c); g.options = f } else {
                                         var d = a(this); f = a.extend({},
                                        a.fn.tabs.defaults,
                                        {
                                            width: parseInt(d.css("width")) || undefined, height: parseInt(d.css("height")) || undefined,
                                            fit: d.attr("fit") ? d.attr("fit") == "true" : undefined, border: d.attr("border") ? d.attr("border") == "true" : undefined,
                                            plain: d.attr("plain") ? d.attr("plain") == "true" : undefined
                                        }, c);
                                         j(this);
                                         a.data(this, "tabs", { options: f })
                                     }
                                     k(this); b(this); e(this)
                                 })
                             };
                             a.fn.tabs.defaults = {
                                 width: "auto", height: "auto", idSeed: 0, plain: false, fit: false, border: true, scrollIncrement: 100, scrollDuration: 400, onLoad: function() { },
                                 onSelect: function() { },
                                 onClose: function() { }
                             }
                         })(jQuery);           (function(a) {
                       function i(d) {
                           var b = a(d); b.addClass("tree");
                           c(b, 0);
                           function c(d, b) {
                               a(">li", d).each(function() {
                                                var d = a('<div class="tree-node"></div>').prependTo(a(this)),
                                                g = a(">span", this).addClass("tree-title").appendTo(d).text();
                                                a.data(d[0], "tree-node", { text: g });
                                                var e = a(">ul", this);
                                                if (e.length) {
                                                    a('<span class="tree-folder tree-folder-open"></span>').prependTo(d); a('<span class="tree-hit tree-expanded"></span>').prependTo(d);
                                                    c(e, b + 1)
                                                } else {
                                                    a('<span class="tree-file"></span>').prependTo(d);
                                                    a('<span class="tree-indent"></span>').prependTo(d)
                                                }
                                                for (var f = 0; f < b; f++) a('<span class="tree-indent"></span>').prependTo(d)
                                            })
                                        } return b
                                    }
                                    function d(f, c) {
                                            var g = a.data(f, "tree").options, d = a(">span.tree-hit", c);
                                            if (d.length == 0) return;
                                            if (d.hasClass("tree-collapsed")) {
                                                d.removeClass("tree-collapsed tree-collapsed-hover").addClass("tree-expanded");
                                                d.next().addClass("tree-folder-open");
                                                var e = a(c).next();
                                                if (e.length) if (g.animate) e.slideDown();
                                                else e.css("display", "block");
                                                else {
                                                    var i = a.data(a(c)[0], "tree-node").id, h = a("<ul></ul>").insertAfter(c); b(f, h, { id: i })
                                                } 
                                            } 
                                        }

                                    function e(e, c) {
                                            var d = a.data(e, "tree").options, b = a(">span.tree-hit", c);
                                            if (b.length == 0) return;
                                            if (b.hasClass("tree-expanded")) {
                                            b.removeClass("tree-expanded tree-expanded-hover").addClass("tree-collapsed");
                                            b.next().removeClass("tree-folder-open");
                                            if (d.animate) a(c).next().slideUp(); else a(c).next().css("display", "none")
                                        } 
                                   }
                       
                       function f(c, b) {
                           var f = a(">span.tree-hit", b);
                           if (f.length == 0) return;
                           if (f.hasClass("tree-expanded")) e(c, b); else d(c, b)
                       }
                           function c(d) {
                               var c = a.data(d, "tree").options,
                               b = a.data(d, "tree").tree;
                               a(".tree-node", b).unbind(".tree").bind("dblclick.tree", function() {
                               a(".tree-node-selected", b).removeClass("tree-node-selected");
                               a(this).addClass("tree-node-selected");
                               if (c.onDblClick) {
                                   var e = this, d = a.data(this, "tree-node");
                                   c.onDblClick.call(this, { id: d.id,
                                   text: d.text,
                                   attributes: d.attributes,
                                   target: e
                               })
                           } 
                       }).bind("click.tree", function() {
                       a(".tree-node-selected", b).removeClass("tree-node-selected");
                       a(this).addClass("tree-node-selected");
                       if (c.onClick) {
                           var e = this, d = a.data(this, "tree-node");
                           c.onClick.call(this,
                                 { id: d.id, 
                                 text: d.text,
                                 attributes: d.attributes, 
                                 target: e
                             })
                         } 
                     }).bind("mouseenter.tree", function() {
                         a(this).addClass("tree-node-hover"); 
                     return false }).bind("mouseleave.tree",
                                 function() { a(this).removeClass("tree-node-hover"); return false });
                     a(".tree-hit", b).unbind(".tree").bind("click.tree", function() {
                         var b = a(this).parent();
                         f(d, b); return false
                     }).bind("mouseenter.tree",
                                 function() {
                                     if (a(this).hasClass("tree-expanded"))
                                         a(this).addClass("tree-expanded-hover");
                                     else a(this).addClass("tree-collapsed-hover")
                                 }).bind("mouseleave.tree", function() {
                                 if (a(this).hasClass("tree-expanded")) a(this).removeClass("tree-expanded-hover");
                                 else a(this).removeClass("tree-collapsed-hover")
                             }); 
                                 a(".tree-checkbox", b).unbind(".tree").bind("click.tree", function() {
                                 if (a(this).hasClass("tree-checkbox0")) 
                                   a(this).removeClass("tree-checkbox0").addClass("tree-checkbox1");
                               else if (a(this).hasClass("tree-checkbox1"))
                                   a(this).removeClass("tree-checkbox1").addClass("tree-checkbox0");
                               else a(this).hasClass("tree-checkbox2") && a(this).removeClass("tree-checkbox2").addClass("tree-checkbox1");
                               e(a(this).parent());
                               g(a(this).parent()); 
                                   return false
                               });
                               function g(b) {
                                   var a = b.next().find(".tree-checkbox");
                                   a.removeClass("tree-checkbox0 tree-checkbox1 tree-checkbox2");
                                   if (b.find(".tree-checkbox").hasClass("tree-checkbox1")) a.addClass("tree-checkbox1");
                                   else a.addClass("tree-checkbox0")
                               } function e(c) {
                               var f = h(d, c[0]);
                               if (f) {
                                   var b = a(f.target).find(".tree-checkbox");
                                   b.removeClass("tree-checkbox0 tree-checkbox1 tree-checkbox2");
                                   if (g(c)) b.addClass("tree-checkbox1");
                                   else if (i(c)) b.addClass("tree-checkbox0");
                                   else b.addClass("tree-checkbox2"); 
                                   e(a(f.target))
                               }
                               function g(d) {
                                   var b = d.find(".tree-checkbox");
                                   if (b.hasClass("tree-checkbox0") || b.hasClass("tree-checkbox2")) return false;
                                   var c = true; d.parent().siblings().each(function() {
                                   if (!a(this).find(".tree-checkbox").hasClass("tree-checkbox1")) c = false
                               });
                               return c
                           }
                           function i(d) {
                               var b = d.find(".tree-checkbox");
                               if (b.hasClass("tree-checkbox1") || b.hasClass("tree-checkbox2")) return false;
                               var c = true; d.parent().siblings().each(function() {
                               if (!a(this).find(".tree-checkbox").hasClass("tree-checkbox0")) c = false
                           }); return c
                       } 
                                }
                            } function g(b, c, e) {
                                b == c && a(b).empty();
                                var f = a.data(b, "tree").options;
                                function d(l, g, h) {
                                    for (var e = 0; e < g.length; e++) {
                                        var j = a("<li></li>").appendTo(l), 
                                        b = g[e];
                                        if (b.state != "open" && b.state != "closed") b.state = "open";
                                        var c = a('<div class="tree-node"></div>').appendTo(j);
                                        c.attr("node-id", b.id);
                                        a.data(c[0], "tree-node", { id: b.id, text: b.text, attributes: b.attributes });
                                        a('<span class="tree-title"></span>').html(b.text).appendTo(c); 
                                        if (f.checkbox) if (b.checked) a('<span class="tree-checkbox tree-checkbox1"></span>').prependTo(c); 
                                        else a('<span class="tree-checkbox tree-checkbox0"></span>').prependTo(c); if (b.children) {
                                            var i = a("<ul></ul>").appendTo(j); if (b.state == "open") {
                                                a('<span class="tree-folder tree-folder-open"></span>').addClass(b.iconCls).prependTo(c);
                                                a('<span class="tree-hit tree-expanded"></span>').prependTo(c)
                                            } else {
                                                a('<span class="tree-folder"></span>').addClass(b.iconCls).prependTo(c);
                                                a('<span class="tree-hit tree-collapsed"></span>').prependTo(c); 
                                            i.css("display", "none") } d(i, b.children, h + 1)
                                        } else if (b.state == "closed") {
                                            a('<span class="tree-folder"></span>').addClass(b.iconCls).prependTo(c); 
                                        a('<span class="tree-hit tree-collapsed"></span>').prependTo(c) } else {
                                            a('<span class="tree-file"></span>').addClass(b.iconCls).prependTo(c);
                                            a('<span class="tree-indent"></span>').prependTo(c)
                                        } 
                                        for (var k = 0; k < h; k++) a('<span class="tree-indent"></span>').prependTo(c)
                                    } 
                                } var g = a(c).prev().find(">span.tree-indent,>span.tree-hit").length; d(c, e, g)
                            } function b(d, h, e) {
                                var b = a.data(d, "tree").options; if (!b.url) return; e = e || {};
                                var f = a(h).prev().find(">span.tree-folder");
                                f.addClass("tree-loading"); 
                                a.ajax({ type: "post", url: b.url, data: e, dataType: "json", success: function(a) {
                                    f.removeClass("tree-loading"); g(d, h, a); c(d);
                                    b.onLoadSuccess && b.onLoadSuccess.apply(this, arguments)
                                }, error: function() {
                                    f.removeClass("tree-loading"); 
                                b.onLoadError && b.onLoadError.apply(this, arguments) } 
                            })
                        } function h(d, c) {
                            var b = a(c).parent().parent().prev();
                            return b.length ? a.extend({}, a.data(b[0], "tree-node"),
                            { target: b[0], 
                            checked: b.find(".tree-checkbox").hasClass("tree-checkbox1") }) : null
                        } function j(c) {
                            var b = []; a(c).find(".tree-checkbox2").each(function() {
                                var c = a(this).parent();
                                b.push(a.extend({}, a.data(c[0], "tree-node"), { 
                                target: c[0], 
                                checked: c.find(".tree-checkbox").hasClass("tree-checkbox2") }))
                            }); 
                            a(c).find(".tree-checkbox1").each(function() {
                                var c = a(this).parent();
                                b.push(a.extend({}, a.data(c[0], "tree-node"), { 
                                target: c[0], 
                                checked: c.find(".tree-checkbox").hasClass("tree-checkbox1") }))
                            }); return b
                         } function j1(c) {
                            var b = []; a(c).find(".tree-checkbox1").each(function() {
                                var c = a(this).parent();
                                b.push(a.extend({}, a.data(c[0], "tree-node"), { 
                                target: c[0], 
                                checked: c.find(".tree-checkbox").hasClass("tree-checkbox1") }))
                            }); return b
                        } function k(c) {
                            var b = a(c).find("div.tree-node-selected");
                            return b.length ? a.extend({}, a.data(b[0], "tree-node"), { 
                            target: b[0], checked: b.find(".tree-checkbox").hasClass("tree-checkbox1") }) : null
                        } function l(h, b) {
                            var d = a(b.parent),
                           f = d.next(); if (f.length == 0) f = a("<ul></ul>").insertAfter(d);
                            if (b.data && b.data.length) {
                                var e = d.find("span.tree-file");
                                if (e.length) {
                                    e.removeClass("tree-file").addClass("tree-folder");
                                    var i = a('<span class="tree-hit tree-expanded"></span>').insertBefore(e);
                                    i.prev().length && i.prev().remove()
                                } 
                            } g(h, f, b.data); c(h)
                        }
                        function m(e, f) {
                            var b = a(f),
                            d = b.parent(), 
                            c = d.parent();
                            d.remove();
                            if (c.find("li").length == 0) {
                                var b = c.prev();
                                b.find(".tree-folder").removeClass("tree-folder").addClass("tree-file");
                                b.find(".tree-hit").remove();
                                a('<span class="tree-indent"></span>').prependTo(b); c[0] != e && c.remove()
                            } 
                        }
                        function n(b, c) {
                            a("div.tree-node-selected", b).removeClass("tree-node-selected");
                            a(c).addClass("tree-node-selected")
                        }
                        function o(e, c) {
                            var b = a(c), d = a(">span.tree-hit", b);
                            return d.length == 0
                        } a.fn.tree = function(p, g) {
                            if (typeof p == "string") switch (p) {
                                case "options": return a.data(this[0], "tree").options;
                                case "reload": return this.each(function() { a(this).empty(); b(this, this) });
                                case "getParent": return h(this[0], g);
                                case "getChecked": return j1(this[0]);
                                case "getChecked1": return j(this[0]);
                                case "getSelected": return k(this[0]);
                                case "isLeaf": return o(this[0], g);
                                case "select": return this.each(function() { n(this, g) });
                                case "collapse": return this.each(function() { e(this, a(g)) });
                                case "expand": return this.each(function() { d(this, a(g)) });
                                case "append": return this.each(function() { l(this, g) });
                                case "toggle": return this.each(function() { f(this, a(g)) });
                                case "remove": return this.each(function() { m(this, g) })
                            } var p = p || {};
                            return this.each(function() {
                                var e = a.data(this, "tree"),
                           d;
                                if (e) {
                                    d = a.extend(e.options, p); 
                                e.options = d }
                                else {
                                    d = a.extend({},
                           a.fn.tree.defaults,
                           { url: a(this).attr("url"),
                               animate: a(this).attr("animate") ? a(this).attr("animate") == "true" : undefined
                           }, p); 
                           a.data(this, "tree", { options: d, tree: i(this) }) } d.url && b(this, this); c(this) }) };
                            a.fn.tree.defaults = { url: null, animate: false, checkbox: false,
                            onLoadSuccess: function() { }, 
                            onLoadError: function() { }, 
                            onClick: function() { },
                            onDblClick: function() { } }
                        })(jQuery); 
                       (function(a) {
                       function e(b) { a(b).addClass("validatebox-text") } function f(b) { var c = a.data(b, "validatebox").tip; c && c.remove(); a(b).remove() } function g(e) { var g = a(e), h = a.data(e, "validatebox").tip, f = null; g.unbind(".validatebox").bind("focus.validatebox", function() { f && clearInterval(f); f = setInterval(function() { d(e) }, 200) }).bind("blur.validatebox", function() { clearInterval(f); f = null; b(e) }).bind("mouseover.validatebox", function() { g.hasClass("validatebox-invalid") && c(e) }).bind("mouseout.validatebox", function() { b(e) }) } function c(c) {
                           var d = a(c), e = a.data(c, "validatebox").message, b = a.data(c, "validatebox").tip;
                           if (!b) {
                               b = a('<div class="validatebox-tip"><span class="validatebox-tip-content"></span><span class="validatebox-tip-pointer"></span></div>').appendTo("body");
                            a.data(c, "validatebox").tip = b } b.find(".validatebox-tip-content").html(e); b.css({ display: "block", left: d.offset().left + d.outerWidth(), top: d.offset().top }) } function b(b) { var c = a.data(b, "validatebox").tip; if (c) { c.remove(); a.data(b, "validatebox").tip = null } } function d(d) { var e = a.data(d, "validatebox").options, o = a.data(d, "validatebox").tip, f = a(d), j = f.val(); function l(b) { a.data(d, "validatebox").message = b } var m = f.attr("disabled"); if (m == true || m == "true") return true; if (e.required) if (j == "") { f.addClass("validatebox-invalid"); l(e.missingMessage); c(d); return false } if (e.validType) { var n = /([a-zA-Z_]+)(.*)/.exec(e.validType), i = e.rules[n[1]]; if (j && i) { var g = eval(n[2]); if (!i.validator(j, g)) { f.addClass("validatebox-invalid"); var k = i.message; if (g) for (var h = 0; h < g.length; h++) k = k.replace(new RegExp("\\{" + h + "\\}", "g"), g[h]); l(e.invalidMessage || k); c(d); return false } } } f.removeClass("validatebox-invalid"); b(d); return true } a.fn.validatebox = function(b) { if (typeof b == "string") switch (b) { case "destroy": return this.each(function() { f(this) }); case "validate": return this.each(function() { d(this) }); case "isValid": return d(this[0]) } b = b || {}; return this.each(function() { var d = a.data(this, "validatebox"); if (d) a.extend(d.options, b); else { e(this); var c = a(this); d = a.data(this, "validatebox", { options: a.extend({}, a.fn.validatebox.defaults, { required: c.attr("required") ? c.attr("required") == "true" || c.attr("required") == true : undefined, validType: c.attr("validType") || undefined, missingMessage: c.attr("missingMessage") || undefined, invalidMessage: c.attr("invalidMessage") || undefined }, b) }) } g(this) }) }; a.fn.validatebox.defaults = { required: false, validType: null, missingMessage: "This field is required.", invalidMessage: null,
                            rules:
                 { email: {
                     validator: function(a) { return /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i.test(a) }, message: "Please enter a valid email address."
                 }, url: { validator: function(a) { return /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i.test(a) }, message: "Please enter a valid URL." }, length: { validator: function(d, b) { var c = a.trim(d).length; return c >= b[0] && c <= b[1] }, message: "Please enter a value between {0} and {1}."}}}
             })(jQuery); 
             (function(a) {
             function d(b) { a(b).panel("resize") } 
                 function c(e, j) {
                     var c = a.data(e, "window"), d;
                     if (c) d = a.extend(c.opts, j);
                     else {
                         var f = a(e);
                         d = a.extend({},
                      a.fn.window.defaults,
                      {
                          title: f.attr("title"),
                          collapsible: f.attr("collapsible") ?
                           f.attr("collapsible") == "true" : undefined,
                          minimizable: f.attr("minimizable") ? f.attr("minimizable") == "true" : undefined,
                          maximizable: f.attr("maximizable") ? f.attr("maximizable") == "true" : undefined,
                          closable: f.attr("closable") ? f.attr("closable") == "true" : undefined, closed:
                         f.attr("closed") ? f.attr("closed") == "true" : undefined,
                          shadow: f.attr("shadow") ? f.attr("shadow") == "true" : undefined,
                          modal: f.attr("modal") ? f.attr("modal") == "true" : undefined
                      }, j);
                      a(e).attr("title", ""); c = a.data(e, "window", {})
                  }
                  var g = a(e).panel(a.extend({}, d,
                         { border: false, doSize: true,
                             closed: true, cls: "window",
                             headerCls: "window-header",
                             bodyCls: "window-body", 
                            onBeforeDestroy: function() {
                         if (d.onBeforeDestroy) if (d.onBeforeDestroy.call(e) == false) return false;
                         var b = a.data(e, "window");
                         b.shadow && b.shadow.remove(); b.mask && b.mask.remove()
                     },
                     onClose: function() {
                         var b = a.data(e, "window");
                         b.shadow && b.shadow.hide();
                         b.mask && b.mask.hide();
                         d.onClose && d.onClose.call(e)
                     },
                     onOpen: function() {
                         var b = a.data(e, "window");
                         b.mask && b.mask.css({ display: "block", zIndex: a.fn.window.defaults.zIndex++ });
                         b.shadow && b.shadow.css({ display: "block", zIndex: a.fn.window.defaults.zIndex++,
                         left: b.options.left, top: b.options.top,
                         width: b.window.outerWidth(),
                         height: b.window.outerHeight()
                     });
                     b.window.css("z-index", a.fn.window.defaults.zIndex++);
                     d.onOpen && d.onOpen.call(e)
                 },
                 onResize: function(c, f) {
                     var b = a.data(e, "window");
                     b.shadow && b.shadow.css({ left: b.options.left,
                     top: b.options.top,
                     width: b.window.outerWidth(),
                     height: b.window.outerHeight()
                 });
                 d.onResize && d.onResize.call(e, c, f)
             },
             onMove: function(c, f) {
                 var b = a.data(e, "window");
                 b.shadow && b.shadow.css({ left: b.options.left, top: b.options.top });
                 d.onMove && d.onMove.call(e, c, f)
             },
             onMinimize: function() {
                 var b = a.data(e, "window");
                 b.shadow && b.shadow.hide();
                 b.mask && b.mask.hide();
                 d.onMinimize && d.onMinimize.call(e)
             },
             onBeforeCollapse: function() {
             if (d.onBeforeCollapse) if (d.onBeforeCollapse.call(e) == false) return false;
             var b = a.data(e, "window");
             b.shadow && b.shadow.hide()
         },
         onExpand: function() {
             var b = a.data(e, "window");
             b.shadow && b.shadow.show(); d.onExpand && d.onExpand.call(e)
         } 
     }));
     c.options = g.panel("options");
     c.opts = d; c.window = g.panel("panel");
     c.mask && c.mask.remove();
     if (d.modal == true) {
         c.mask = a('<div class="window-mask"></div>').appendTo("body");
         c.mask.css({ width: b().width, height: b().height, display: "none" })
     }
     c.shadow && c.shadow.remove();
     if (d.shadow == true) {
         c.shadow = a('<div class="window-shadow"></div>').insertAfter(c.window);
         c.shadow.css({ display: "none" })
     }
     if (c.options.left == null) {
         var h = c.options.width; if (isNaN(h)) h = c.window.outerWidth();
         c.options.left = (a(window).width() - h) / 2 + a(document).scrollLeft()
     }
     if (c.options.top == null) {
         var i = c.window.height;
         if (isNaN(i)) i = c.window.outerHeight();
         c.options.top = (a(window).height() - i) / 2 + a(document).scrollTop()
     }
     g.window("move"); c.opts.closed == false && g.window("open")
 }
 function e(c) {
     var b = a.data(c, "window");
     b.window.draggable({ handle: ">div.panel-header>div.panel-title",
     disabled: b.options.draggable == false,
     onStartDrag: function(c) {
         b.mask && b.mask.css("z-index", a.fn.window.defaults.zIndex++);
         b.shadow && b.shadow.css("z-index", a.fn.window.defaults.zIndex++);
         b.window.css("z-index", a.fn.window.defaults.zIndex++);
         if (!b.proxy) b.proxy = a('<div class="window-proxy"></div>').insertAfter(b.window);
         b.proxy.css({ display: "none", zIndex: a.fn.window.defaults.zIndex++,
         left: c.data.left, top: c.data.top, 
         width: a.boxModel == true ? b.window.outerWidth() - (b.proxy.outerWidth() - b.proxy.width()) : b.window.outerWidth(),
         height: a.boxModel == true ? b.window.outerHeight() - (b.proxy.outerHeight() - b.proxy.height()) : b.window.outerHeight()
     });
     setTimeout(function() { b.proxy && b.proxy.show() }, 500)
 },
 onDrag: function(a) {
     b.proxy.css({ display: "block", left: a.data.left, top: a.data.top });
     return false
 },
 onStopDrag: function(d) {
     b.options.left = d.data.left;
     b.options.top = d.data.top;
     a(c).window("move");
     b.proxy.remove(); b.proxy = null
 } 
});
b.window.resizable({ disabled: b.options.resizable == false,
onStartResize: function(c) {
    if (!b.proxy) b.proxy = a('<div class="window-proxy"></div>').insertAfter(b.window);
    b.proxy.css({ zIndex: a.fn.window.defaults.zIndex++, 
    left: c.data.left,
    top: c.data.top, width: a.boxModel == true ? c.data.width - (b.proxy.outerWidth() - b.proxy.width()) : c.data.width,
    height: a.boxModel == true ? c.data.height - (b.proxy.outerHeight() - b.proxy.height()) : c.data.height
})
},
onResize: function(c) {
    b.proxy.css({ left: c.data.left, top: c.data.top, width: a.boxModel == true ? c.data.width - (b.proxy.outerWidth() - b.proxy.width()) : c.data.width,
    height: a.boxModel == true ? c.data.height - (b.proxy.outerHeight() - b.proxy.height()) : c.data.height
}); return false
},
onStopResize: function(a) {
    b.options.left = a.data.left;
    b.options.top = a.data.top;
    b.options.width = a.data.width;
    b.options.height = a.data.height; d(c); b.proxy.remove();
    b.proxy = null
} 
})
}
function b() {
    return document.compatMode == "BackCompat" ? {
    width: Math.max(document.body.scrollWidth, document.body.clientWidth),
    height: Math.max(document.body.scrollHeight, document.body.clientHeight)} :
         { width: Math.max(document.documentElement.scrollWidth, document.documentElement.clientWidth),
             height: Math.max(document.documentElement.scrollHeight, document.documentElement.clientHeight)}
         }
         a(window).resize(function() {
             a(".window-mask").css({ width: a(window).width(), height: a(window).height() });
             setTimeout(function() { a(".window-mask").css({ width: b().width, height: b().height }) }, 50)
         });
         a.fn.window = function(d, b) {
             if (typeof d == "string")
                 switch (d) {
                 case "options": return a.data(this[0], "window").options;
                 case "window": return a.data(this[0], "window").window;
                 case "setTitle": return this.each(function() { a(this).panel("setTitle", b) });
                 case "open": return this.each(function() { a(this).panel("open", b) });
                 case "close": return this.each(function() { a(this).panel("close", b) });
                 case "destroy": return this.each(function() { a(this).panel("destroy", b) });
                 case "refresh": return this.each(function() { a(this).panel("refresh") });
                 case "resize": return this.each(function() { a(this).panel("resize", b) });
                 case "move": return this.each(function() { a(this).panel("move", b) })
             } d = d || {};
             return this.each(function() { c(this, d); e(this) })
         };
         a.fn.window.defaults = { zIndex: 9e3,
         draggable: true, resizable: true, shadow: true, modal: false,
         title:"New Window",collapsible:true,minimizable:true,maximizable:true,closable:true,closed:false}})(jQuery)