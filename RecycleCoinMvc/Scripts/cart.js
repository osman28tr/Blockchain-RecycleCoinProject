$("#cartViewer").click(function () {
    if ($("#cart.show")[0] == undefined) {
        $("#cart").css({ "transform": "scale(1)", "opacity": "1" }).toggleClass("show");
    }
    else {
        $("#cart").css({ "transform": "scale(0)", "opacity": "0" }).toggleClass("show");
    }

});

$("#recycleSubmit").click(function () {
    var toAddress = $("#toAddress")[0].value;
    var dataRows = $("#cartData tr");
    var totalCarbon = 0;
    for (data of dataRows) {
        totalCarbon += parseInt(data.children[2].innerText);
    }
    $.ajax({
        type: "GET",
        url: "/Admin/RecycleCenter/RecyleItems",
        data: { toAddress: toAddress, totalCarbon: totalCarbon },
        success: function (response) {
            console.log(response);
            // response ile gelen verileri kullanarak update işlemi gerçekleştirilecek
        }
    });

});

