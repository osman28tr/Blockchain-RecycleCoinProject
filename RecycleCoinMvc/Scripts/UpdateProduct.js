$(".updateBtn").click(function () {
    var productId = this.dataset.id;
    var inputValue = this.parentElement.parentElement.children[0].value;

    // ajax ile controller'a get işlemi yapılacak parametre olarak productId ve inputValue gönderilecek
    // controller'da bu değerler ile update işlemi yapılacak

    $.ajax({
        type: "POST",
        url: "/Admin/Settings/UpdateProduct",
        data: { productId: productId, inputValue: inputValue },
        success: function (response) {
            console.log(response);
            // response ile gelen verileri kullanarak update işlemi gerçekleştirilecek
        }
    });

});