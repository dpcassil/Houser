﻿/// <reference path="touch.js" />

        var alt = {};
        alt.userID = -1;
        alt.saleDates = {};
        alt.selectedDate = -1;
        alt.list = "1";
        alt.propData = {};
        alt.swipeDirection = null;
        alt.x = null;
        alt.y = null;
        // get properties.
        alt.getProperties = function(saleDate, list) {
            var data;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/WebUtilities/DetailsWebService.asmx/GetPropertiesBySaleDate',
                data: "{sDate: '" + saleDate + "', list: '" + list + "', sUserID: '" + alt.userID + "'}",
                dataType: "json",
                async: false,
                success: function (responce) {
                    if (responce.d != "") {
                        data = eval('(' + responce.d + ');');
                    } else {
                        data = null;
                    }
                },
                error: function (error) {
                    data = error;
                }
            });
            return data;
        }
        alt.renderProperties = function(properties) {
            if (alt.propData != null) {
                var template = $("#tmpPropertyData").html();
                $(".wrapper").html();
                $(".wrapper").html(_.template(template,{propData:alt.propData}));
            }
        }
        alt.getSaleDates = function() {
            var dates;
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/WebUtilities/DetailsWebService.asmx/GetSherifSaleDates',
                dataType: "json",
                async: false,
                success: function (responce) {
                    if (responce.d != "") {
                        dates = responce.d;
                    } else {
                        dates = null;
                    }
                },
                error: function (error) {
                    dates = error;
                }
            });
            return dates;
        }
        alt.addToReviewList = function (accountNumber, userID) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/WebUtilities/DetailsWebService.asmx/AddToReviewList',
                data: "{accountNumber: '" + accountNumber + "', listID: '" + "1" + "', userID: '" + userID + "'}",
                dataType: "json",
                async: false,
                success: function (responce) {
                    if (responce.d != "") {
                        //success
                    } else {
                        //fail
                    }
                },
                error: function (error) {
                    //fail
                }
            });
        }
        alt.saveNote = function (note, accountID, userID) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/WebUtilities/NoteWebService.asmx/SaveAccountNote',
                data: "{accountNumber: '" + accountID + "', userID: '" + userID + "', note: '" + note + "'}",
                dataType: "json",
                async: false
                });
        }
        alt.removeFromList = function (accountNumber, userID) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '/WebUtilities/DetailsWebService.asmx/RemovePropertyFromList',
                data: "{accountNumber: '" + accountNumber + "', listID: '" + "1" + "', userID: '" + userID + "'}",
                dataType: "json",
                async: false,
                success: "",
                error: ""
            });
        }
        alt.blockSwipe = function (event) {
            if (window.innerHeight > window.innerWidth) {
                // Tell Safari not to move the window.
                event.preventDefault();
                // Parse the swipe event and find the direction
                alt.swipeDirection = touch.getSwipeDirection(event);

                //get direction and scroll accordingly
                if (touch.swipeDirection !== null) {
                    if (alt.swipeDirection === touch.down || alt.swipeDirection === touch.right) {
                        alt.scrollToNextProperty(event);
                    }
                    //get direction and scroll accordingly
                    if (alt.swipeDirection === touch.up || alt.swipeDirection === touch.left) {
                        alt.scrollToPreviousProperty(event);
                    }
                }
            }
        }
        alt.scrollToNextProperty = function(event) {
            var scrollTo = $(event.target).parents(".propPage").next(".propPage").position().top;
            $('html, body').animate({
                scrollTop: (scrollTo - 30)
            }, 400);
            //$.scrollTo(0, scrollTo.top); 
        }
        alt.scrollToPreviousProperty = function (event) {
            var scrollTo = $(event.target).parents(".propPage").prev(".propPage").position().top;
            $('html, body').animate({
                scrollTop: (scrollTo - 30)
            }, 400);
            //$.scrollTo(0, scrollTo.top); 
        }
        jQuery(function ($) {
            _.templateSettings = { interpolate: /\{\{(.+?)\}\}/g,      // print value: {{ value_name }}
                evaluate: /\{%([\s\S]+?)%\}/g,   // excute code: {% code_to_execute %}
                escape: /\{%-([\s\S]+?)%\}/g
            }; // excape HTML: {%- <script> %} prints &lt;script&gt;

            alt.userID = xuid;
            alt.selectedDate = xdate;
            alt.propData = alt.getProperties(alt.selectedDate, alt.list);
            alt.renderProperties(alt.propData);
            alt.saleDates = alt.getSaleDates();

            //UI functions
            $.each(alt.saleDates, function (index, value) {
                $('.datesList').append($('<option/>', {
                    value: value,
                    text: value
                }));
            });
            $("body").on("click", '#addToList', function () {
                var account = $(this).parent().attr('id');
                alt.addToReviewList(account, alt.userID);
            });
            $("body").on("click", '#removeFromList', function () {
                var account = $(this).parent().attr('id');
                alt.removeFromList(account, alt.userID);
            });
            $(".propList").on("change", function () {
                alt.list = $(".propList").val();
                alt.propData = alt.getProperties(alt.selectedDate, alt.list);
                alt.renderProperties(alt.propData);
            });
            $(".datesList").on("change", function () {
                alt.selectedDate = $(".datesList").val();
                alt.propData = alt.getProperties(alt.selectedDate, alt.list);
                alt.renderProperties(alt.propData);
            });
            $(".notes textarea").on("blur", function () {
                var accountID = $(this).parent().attr("id");
                var note = $(this).val();
                alt.saveNote(note, accountID, alt.userID);
                $(this).css('height', '30px');
                var scrollTo = $(this).parents(".propPage").position().top;
                $('html, body').animate({
                    scrollTop: (scrollTo - 30)
                }, 300);
            });
            $(".notes textarea").on("focus", function () {
                $(this).css('height', '120px');
            });
        });