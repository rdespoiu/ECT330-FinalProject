﻿$(document).ready(function () {

    $("#leftFeatured").click(function (event) {
        window.location.href = "climbing.aspx"; /*Will redirect to the product's page*/
    });

    $("#rightFeatured").click(function (event) {
        window.location.href = "hiking.aspx"; /*Will redirect to the product's page*/
    });

    $("#bottomOne").click(function (event) {
        window.location.href = "product.aspx?Id=10"; /*Will redirect to the product's page*/
    });

    $("#bottomTwo").click(function (event) {
        window.location.href = "product.aspx?Id=1"; /*Will redirect to the product's page*/
    });

    $("#bottomThree").click(function (event) {
        window.location.href = "product.aspx?Id=3"; /*Will redirect to the product's page*/
    });

    $("#logo").click(function (event) {
        window.location.href = "/index.aspx";
    });

    $("#signIn").click(function() {
        $("#signInContent").css("visibility", "visible");
    });

});

$(document).mousedown(function (e) {
    var container = $("#signInContent");

    if (!container.is(e.target)
        && container.has(e.target).length == 0) {
        $(container).css("visibility", "hidden");
    }
});

