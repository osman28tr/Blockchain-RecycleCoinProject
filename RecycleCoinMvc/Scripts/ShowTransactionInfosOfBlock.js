if (window.innerWidth < 768) {
    $("[data-bss-disabled-mobile]").removeClass("animated").removeAttr("data-aos data-bss-hover-animate data-bss-parallax-bg data-bss-scroll-zoom");
}

$(document).ready(function () {
    AOS.init();

    $("[data-bss-hover-animate]")
        .mouseenter(function () { var elem = $(this); elem.addClass(`animated ${elem.attr("data-bss-hover-animate")}`) })
        .mouseleave(function () { var elem = $(this); elem.removeClass(`animated ${elem.attr("data-bss-hover-animate")}`) });
});
$(document).ready(function () {
    $("#TransactionViewer").slideUp(1);
});

$(window).click(function () {
    if ($("#TransactionViewer.show")[0] == undefined) {
        $("#TransactionViewer").slideUp(300);
        $("#blocks").css("filter", "blur(0)");
    }
    $("#TransactionViewer.show").removeClass("show");

});
$(".block").click(function () {


    $("#blocks").css("filter", "blur(2px)");
    $("#TransactionViewer")
        .slideDown(300)
        .addClass("show");
    const hash = this.dataset["hash"];
    $("#TransactionViewer tbody").empty();
    $.ajax({
        type: "GET",
        dataType: "Json",
        data: { hash: hash },
        url: `http://localhost:5000/api/Blockchain/getBlockByHash/${hash}`,
        success: function (data) {
            for (var [value, transaction] of data["transactions"].entries()) {
                $("#TransactionViewer tbody").append(`
         <tr style="background-color:transparent;">
            <td>${value+1}</td>
            <td style="word-break: break-all">${transaction["fromAddress"] == null ? "System" : transaction["fromAddress"]}</td>
            <td style="word-break: break-all">${transaction["toAddress"]}</td>
            <td>${transaction["amount"]}</td>
            <td>${transaction["timestamp"]}</td>
            <td>${transaction["TransactionisValid"]}</td>
        </tr>`);
            }
        }
    });
    console.log($("#TransactionViewer"));
});

$("#TransactionTable").click(function () {
    $("#TransactionViewer").addClass("show");
});