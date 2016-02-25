$(document).ready(function () {

    $("#leftFeatured").click(function (event) {
        window.location.href = "#"; /*Will redirect to the product's page*/
    });

    $("#rightFeatured").click(function (event) {
        window.location.href = "#"; /*Will redirect to the product's page*/
    });

    $("#bottomOne").click(function (event) {
        window.location.href = "#"; /*Will redirect to the product's page*/
    });

    $("#bottomTwo").click(function (event) {
        window.location.href = "#"; /*Will redirect to the product's page*/
    });

    $("#bottomThree").click(function (event) {
        window.location.href = "#"; /*Will redirect to the product's page*/
    });

    $("#signIn").click(function() {
        $("#signInContent").css("visibility", "visible");
    });
    
    



    

});

$(document).mouseup(function (e) {
    var container = $("#signInContent");

    if (!container.is(e.target)
        && container.has(e.target).length == 0) {
        $(container).css("visibility", "hidden");
    }
});