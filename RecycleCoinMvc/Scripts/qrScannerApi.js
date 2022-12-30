$("#QrReadBtn").click(function () {
    $('#recyclePanel').toggleClass("activeQrPanel");
    $('#QrPanel').toggleClass("activeQrPanel");
    $("#QrCamera").attr("src", "");

    setTimeout(function () {

        if ($("#QrPanel.activeQrPanel")[0]) {
            $("#QrCamera").attr("src", "http://127.0.0.1:3500/video_feed");
        } else {
            $.ajax({
                type: "Post",
                url: "http://127.0.0.1:3500/requests",
                success: function (response) {
                    console.log(response);
                    if (response["response"] !== "No QR code detected") {
                        $.ajax({
                            type: "Get",
                            url: "/Admin/RecycleCenter/QrCodeGetResult?response=" + response["response"]

                        });
                        window.location.reload();
                    };
                }
            });
        }

    }, 200);


});